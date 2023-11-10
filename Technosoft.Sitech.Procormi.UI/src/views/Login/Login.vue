<template>
    <div class="row loginGen" style="text-align: center;">
        <div id="imagenLogin" class="col-lg-9 col-md-7 col-sm-12 bg-gradient-azul">
            <img src="images/login3.png" style="min-height: 100%;">
        </div>
        <div class="col-lg-3 col-md-5 col-sm-12 row justify-content-center bg-gradient-azulLogin loginDer" style="min-height: 100vh; padding-bottom: 50px;">
            <div class="col-12 sm-margin-40px-bottom">
                <div class="contentBX" style="padding-top: 100px;">
                    <div class="formBx">
                        <form v-if="!formRegistrarse">
                            <a style="text-align: center;">
                                <img src="images/MilleniumLogoBlanco.png" class="default-logo" height="200" width="200">
                            </a>
                            <br />
                            <br />
                            <br />
                            <h5 class="alt-font font-weight-500 text-gradient-yellow-orange-black" align="center">Inicio de Sesión</h5>

                            <input maxlength="20" class="small-input bg-white margin-20px-bottom required" style="border-radius: 10px; margin-top: 25px;" type="text" placeholder="Digite su usuario" v-model="Usuario">

                            <div class="wrap-input" style="margin-top: 25px;">
                                <span class="icon-eye" id="ojo" style="font-size: 20px" v-on:click="mostrarContrasena"><i class="fas fa-eye-slash" id="ojoTechado"></i></span>
                                <input maxlength="20" class="small-input bg-white margin-20px-bottom required" style="border-radius: 10px;" type="password" placeholder="Digiste su contraseña" v-model="Clave" @keydown.enter="RealizarLogin">
                            </div>
                            <br/>
                            <div style="text-align: center">
                                <div class="row justify-content-center" style="text-align: center">
                                    <a class="btn btn-success" style="border-radius: 10px; max-width: 110px;" role="button" v-on:click="RealizarLogin">Ingresar</a>
                                </div>
                                <!--br />
                                <br />
                                <div class="row justify-content-center" style="text-align: center">
                                    <a style="border-radius: 10px; max-width: 110px; color: rgb(201, 201, 201); font-size: 15px;" role="button" v-on:click="Registrarse">Registrarse</a>
                                </div>-->
                            </div>
                        </form>
                        <form v-if="formRegistrarse">
                            <a style="text-align: center;">
                                <img src="images/MilleniumLogoBlanco.png" class="default-logo" height="200" width="200">
                            </a>
                            <br />
                            <br />
                            <br />
                            <h5 class="alt-font font-weight-500 text-gradient-yellow-orange-black" align="center">Registro de Usuario</h5>
                            <br />
                            <label class="margin-15px-bottom text text-white">Usuario</label>
                            <input maxlength="20" class="small-input bg-white margin-20px-bottom required" style="border-radius: 10px;" type="text" placeholder="Digite su usuario" v-model="UsuarioReg">
                            <label class="margin-15px-bottom text-white">Contraseña</label>
                            <div class="wrap-input">
                                <span class="icon-eye" id="ojo2" style="font-size: 20px" v-on:click="mostrarContrasena2"><i class="fas fa-eye-slash" id="ojoTechado2"></i></span>
                                <input maxlength="20" class="small-input bg-white margin-20px-bottom required" style="border-radius: 10px;" type="password" placeholder="Digiste su contraseña" v-model="ClaveReg">
                            </div>
                            <label class="margin-15px-bottom text-white">Confirmar contraseña</label>
                            <div class="wrap-input">
                                <span class="icon-eye" id="ojo3" style="font-size: 20px" v-on:click="mostrarContrasena3"><i class="fas fa-eye-slash" id="ojoTechado3"></i></span>
                                <input maxlength="20" class="small-input bg-white margin-20px-bottom required" style="border-radius: 10px;" type="password" placeholder="Digiste su contraseña" v-model="ClaveRegConfirmar" @keydown.enter="RealizarRegistro">
                            </div>
                            <br />
                            <div style="text-align: center">
                                <div class="row justify-content-center" style="text-align: center">
                                    <a class="btn btn-success" style="border-radius: 10px; max-width: 110px;" role="button" v-on:click="RealizarRegistro">Registrarse</a>
                                </div>
                                <br />
                                <br />
                                <div class="row justify-content-center" style="text-align: center">
                                    <a style="border-radius: 10px; max-width: 110px; color: rgb(201, 201, 201); font-size: 15px;" role="button" v-on:click="IniciarSesion">Iniciar Sesión</a>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

import AdminApi from '@/Api/Api';
import Cookies from 'js-cookie';
import router from '@/router/index'
import CryptoJS from 'crypto-js';

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

            UsuarioReg: "",
            ClaveReg: "",
            ClaveRegConfirmar: "",

            formRegistrarse: false,

            ActionEN: {
                Action_Description: "",
                Action_User: ""
            },

        }
    },

    methods: {

        RealizarRegistro: function () {
            if (this.UsuarioReg == "" || this.UsuarioReg == undefined || this.UsuarioReg == null){
                return this.$swal.fire({
                            position: 'top-end',
                            text: 'Debe digitar el usuario',
                            showConfirmButton: false,
                            timer: 3000
                        })
            } else if ((this.ClaveReg == "" || this.ClaveReg == undefined || this.ClaveReg == null)
                || (this.ClaveRegConfirmar == "" || this.ClaveRegConfirmar == undefined || this.ClaveRegConfirmar == null)){
                return this.$swal.fire({
                            position: 'top-end',
                            text: 'Debe digitar y confirmar la contraseña',
                            showConfirmButton: false,
                            timer: 3000
                        })
            } else if (this.ClaveReg.length < 6 || this.ClaveRegConfirmar.length < 6) {
                return this.$swal.fire({
                            position: 'top-end',
                            text: 'La contraseña debe tener mínimo 6 caracteres',
                            showConfirmButton: false,
                            timer: 3000
                        })
            } else if (this.ClaveReg !== this.ClaveRegConfirmar) {
                return this.$swal.fire({
                            position: 'top-end',
                            text: 'Las contraseñas no coinciden, por favor verifique',
                            showConfirmButton: false,
                            timer: 3000
                        })
            }
        },

        Registrarse: function () {
            let loader = this.$loading.show({
                container: this.$refs.cuadroLoader,
                opacity: 0.8
            })
            this.formRegistrarse = true;
            setTimeout(() => {
                loader.hide()
            }, 500)
        },

        IniciarSesion: function () {
            let loader = this.$loading.show({
                container: this.$refs.cuadroLoader,
                opacity: 0.8
            })
            this.formRegistrarse = false;
            setTimeout(() => {
                loader.hide()
            }, 500)
        },

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

        mostrarContrasena2: function () {

            var ojo = document.getElementById("ojo2")
            var next = ojo.nextSibling
            var ojoTechado = document.getElementById("ojoTechado2")
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

            mostrarContrasena3: function () {

            var ojo = document.getElementById("ojo3")
            var next = ojo.nextSibling
            var ojoTechado = document.getElementById("ojoTechado3")
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
                let claveEncriptada = this.encriptarContraseña(this.Clave)
                const response = await AdminApi.GetLogin(this.Usuario, claveEncriptada);
                if (response.data.ok == true) {
                    this.guardarUsuLog(this.Usuario);
                    var usuario = await this.validarTipo(response.data.obj.usu_Tipo);
                    this.guardarUsuTipo(usuario);
                    this.guardarUsuNombre(response.data.obj.usu_Nombre);
                    this.ActionEN.Action_Description = "Inicio de sesión"
                    this.ActionEN.Action_User = this.Usuario
                    await AdminApi.PostNewAction(this.ActionEN)
                    router.push({ name: 'Inicio' })
                    this.btnDesactivar = false;
                    var mensaje = new SpeechSynthesisUtterance();
                    mensaje.text = 'Bienvenido a Procormi';
                    mensaje.voice = speechSynthesis.getVoices()[9];
                    speechSynthesis.speak(mensaje);

                    setTimeout(() => {
                        this.$root.cerrarSesionGeneral.call();
                    }, (((1000 * 60) * 60)*5));

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

        encriptarContraseña(contraseña) {
            const clave = CryptoJS.enc.Base64.parse("prmDMvIvPNlrmcsgLM1/c34GHjA7D2P2");
            const iv = CryptoJS.enc.Utf8.parse("cmprmasr");

            const encrypted = CryptoJS.TripleDES.encrypt(contraseña, clave, {
                iv: iv
            });

            return encrypted.toString();
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