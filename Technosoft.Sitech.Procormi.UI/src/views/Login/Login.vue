<template>
    <div class="row loginGen" style="text-align: center;">
        <div id="imagenLogin" class="col-lg-9 col-md-7 col-sm-12 bg-gradient-azul">
            <img src="images/login3.png" style="min-height: 100%;">
        </div>
        <div class="col-lg-3 col-md-5 col-sm-12 row justify-content-center bg-gradient-azulLogin loginDer" style="min-height: 100vh; padding-bottom: 50px;">
            <div class="col-12 sm-margin-40px-bottom">
                <div class="contentBX" style="padding-top: 100px;">
                    <div class="formBx">
                        <form>
                            <a style="text-align: center;">
                                <img src="images/MilleniumLogoBlanco.png" class="default-logo" height="200" width="200">
                            </a>
                            <br />
                            <br />
                            <br />
                            <h5 class="alt-font font-weight-500 text-gradient-yellow-orange-black" align="center">Iniciar Sesión</h5>
                            <br />
                            <label class="margin-15px-bottom text text-white">Usuario</label>
                            <input maxlength="20" class="small-input bg-white margin-20px-bottom required" type="text" placeholder="Digite su usuario" v-model="Usuario">
                            <label class="margin-15px-bottom text-white">Contraseña</label>
                            <div class="wrap-input">
                                <span class="icon-eye" id="ojo" style="font-size: 20px" v-on:click="mostrarContrasena"><i class="fas fa-eye-slash" id="ojoTechado"></i></span>
                                <input maxlength="20" class="small-input bg-white margin-20px-bottom required" type="password" placeholder="Digiste su contraseña" v-model="Clave" @keydown.enter="RealizarLogin">
                            </div>
                            <br />
                            <div style="text-align:center" class="CentrarLogin">
                                <div class="row" style="text-align:center">
                                    <a class="btn btn-success btn-azul" role="button" v-on:click="RealizarLogin">Ingresar</a>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>

        <button hidden type="button" id="abrirModal" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalAplicaciones">Open modal</button>

        <!--Modal aplicación-->

        <div class="modal fade" id="modalAplicaciones" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" style="padding-top: 200px;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        <form>
                            <div class="mb-3" style="font-size: large;">
                                <label for="message-text" class="col-form-label">Listado de aplicaciones disponibles</label>
                                <br />
                                <br />
                                <select id="sitio" v-model="sitioNombre">
                                    <option value="">Seleccione o indique por voz una aplicación</option>
                                    <option value="CM Conocimientos">CM Conocimientos</option>
                                    <option value="CM Activos">CM Activos</option>
                                    <option value="CM Informativo">CM Informativo</option>
                                </select>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button hidden id="reconocimientoVoz" type="button" class="btn btn-primary" @click.prevent="activarReconocimientoVoz">Activar reconocimiento de voz</button>
                        <button type="button" class="btn btn-primary" @click.prevent="designarAplicacionLogin(sitioNombre)">Listo</button>
                        <button hidden id="cerrarModal" type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>

        <!--Modal aplicación-->

    </div>
</template>

<script>

import AdminApi from '@/Api/Api';
import Cookies from 'js-cookie';
import router from '@/router/index'

export default {

    components: {
    },

    data() {
        return {
            Usuario: "",
            Clave: "",
            LoginUsu: "",
            nombreUsu: "",
            sitioNombre: "",
        }
    },

    methods: {

        mostrarContrasena: function () {

            var ojo = document.getElementById("ojo")
            var next = ojo.nextSibling
            var ojoTechado = document.getElementById("ojoTechado")
            if (next.type === 'password') {
                next.type = 'text';
                ojoTechado.classList.remove("fa-eye-slash");
                ojoTechado.classList.add("fa-eye");
            } else if (next.type === 'text') {
                next.type = 'password'
                ojoTechado.classList.remove("fa-eye");
                ojoTechado.classList.add("fa-eye-slash");
            }

        },

        guardarUsuLog(UsuCookie) {
            var usuarioLogin = UsuCookie.toLowerCase();
            Cookies.set("usuarioLogin", usuarioLogin)
        },

        guardarUsuTipo(UsuCookie) {
            Cookies.set("tipoU", UsuCookie)
        },

        guardarUsuNombre(UsuCookie) {
            Cookies.set("nombreUsu", UsuCookie)
        },

        async RealizarLogin() {
            //var botonReconocimiento = document.getElementById("reconocimientoVoz")
            if (this.Usuario == "") {
                await this.$swal.fire({
                        position: 'top-end',
                        text: 'Por favor, digite el usuario',
                        showConfirmButton: false,
                        timer: 3000
                    })
            } else if (this.Clave == "") {
                await this.$swal.fire({
                        position: 'top-end',
                        text: 'Por favor, digite la clave',
                        showConfirmButton: false,
                        timer: 3000
                    })
            } else {
                const response = await AdminApi.GetLogin(this.Usuario, this.Clave);
                if (response.data.ok == true) {
                    this.guardarUsuLog(this.Usuario);
                    var usuario = await this.validarTipo(response.data.obj.usu_Tipo);
                    this.guardarUsuTipo(usuario);
                    this.guardarUsuNombre(response.data.obj.usu_Nombre);
                    router.push({ name: 'Inicio' })
                    this.btnDesactivar = false;
                    var mensaje = new SpeechSynthesisUtterance();
                    mensaje.text = 'Bienvenido a Procormi';
                    mensaje.voice = speechSynthesis.getVoices()[9];
                    speechSynthesis.speak(mensaje);
                } else {
                    await this.$swal.fire({
                        //icon: 'error',
                        position: 'top-end',
                        text: 'Usuario o clave incorrectos, por favor verifique',
                        showConfirmButton: false,
                        timer: 3000
                    })
                }
            }
        },

        abrirModal: async function() {
            var boton = document.getElementById('abrirModal')
            await boton.click();
        },

        designarAplicacionLogin: async function(sitioNombre) {
            var sitioId = ""
            if(sitioNombre.toLowerCase() == "cm conocimiento" || sitioNombre.toLowerCase() == "cm conocimientos"
            || sitioNombre.toLowerCase() == "c m conocimiento" || sitioNombre.toLowerCase() == "c m conocimientos"){
                sitioNombre = "C M Conocimientos"
                sitioId = "CMC"
            } else if (sitioNombre.toLowerCase() == "cm activo" || sitioNombre.toLowerCase() == "cm activos"
            || sitioNombre.toLowerCase() == "c m activo" || sitioNombre.toLowerCase() == "c m activos"){
                sitioNombre = "C M Activos"
                sitioId = "CMA"
            } else if (sitioNombre.toLowerCase() == "cm informativo" || sitioNombre.toLowerCase() == "cm informativos"
            || sitioNombre.toLowerCase() == "c m informativo" || sitioNombre.toLowerCase() == "c m informativos"){
                sitioNombre = "C M Informativo"
                sitioId = "CMI"
            } else {
                sitioNombre = ""
            }
            var botonCerrar = document.getElementById('cerrarModal')
            if (sitioNombre == "" || sitioNombre == null ||sitioNombre == undefined) {
                await this.$swal.fire({
                    position: 'top-end',
                    text: 'Por favor, indique una aplicación válida',
                    showConfirmButton: false,
                    timer: 3000
                })
                await this.activarReconocimientoVoz();

            } else {
                const response = await AdminApi.GetLogin(this.Usuario, this.Clave);
                localStorage.setItem("aplicacionActiva", sitioId)
                this.guardarUsuLog(this.Usuario);
                var usuario = await this.validarTipo(response.data.obj.usu_Tipo);
                this.guardarUsuTipo(usuario);
                this.guardarUsuNombre(response.data.obj.usu_Nombre);
                this.btnDesactivar = false;
                await botonCerrar.click();
                var mensaje = new SpeechSynthesisUtterance();
                mensaje.text = 'Bienvenido a ' + sitioNombre;
                mensaje.voice = speechSynthesis.getVoices()[9];
                speechSynthesis.speak(mensaje);
                router.push({ name: 'Inicio' })
            }
        },

        activarReconocimientoVoz: function(){
            const SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition;
            if (SpeechRecognition) {
                const recognition = new SpeechRecognition();

                recognition.lang = 'es';

                recognition.onresult = event => {
                    const result = event.results[0][0].transcript;
                    if(result.length < 20){
                        this.designarAplicacionLogin(result);
                    }
                };

                recognition.start();
            } else {
                alert('El reconocimiento de voz no es compatible con este navegador.');
            }
        },

        recuperarUsuLog() {
            return Cookies.get("usuarioLogin")
        },

        recuperarUsuTipo() {
            return Cookies.get("tipoU")
        },

        recuperarUsuNombre() {
            return Cookies.get("nombreUsu")
        },

        verificarLog: function () {
            let login = this.recuperarUsuLog()
            let tipoU = this.recuperarUsuTipo()
            if ((login != undefined && login != null && login != '') && (tipoU != undefined && tipoU != null && tipoU != '')) {
                this.$router.push("/Inicio");
            }

        },

        validarTipo(cadena) {
            if (cadena.includes(';')) {
                var usuarios = cadena.split(';');

                for (var i = 0; i < usuarios.length; i++) {
                    if (usuarios[i] == 'Administrador') {
                        return usuarios[i];
                    }
                }

                for (var n = 0; n < usuarios.length; n++) {
                    if (usuarios[n] == 'Supervisor') {
                        return usuarios[n];
                    }
                }

                for (var x = 0; x < usuarios.length; x++) {
                    if (usuarios[x] == 'Operador') {
                        return usuarios[x];
                    }
                }

            } else {
                return cadena
            }
        },

    },

    created: async function () {
        await this.verificarLog();
        await this.$root.validarLoginFooter.call();
    }

}

</script>

<style scoped>

    .wrap-input {
        position: relative;
        width: 100%;
        min-height: 50px;
    }

        .wrap-input input {
            outline: none;
            width: 100%;
            height: 50px;
            padding: 10px 30px 10px 20px;
        }

    .icon-eye {
        position: absolute;
        right: 15px;
        transform: translateY(25%);
        cursor: pointer;
        transition: 0.4s ease all;
    }

        .icon-eye:hover {
            color: cadetblue;
        }

    .loginGen{
        min-height: 95vh;
    }

    .loginIzq {
        background-color: red;
    }

    .loginDer {
        min-height: 94vh;
    }

    @media (max-width: 768px) {
        #imagenLogin {
            display: none;
        }

        .loginDer {
            padding-left: 50px;
            min-height: 94vh;
        }
    }

</style>