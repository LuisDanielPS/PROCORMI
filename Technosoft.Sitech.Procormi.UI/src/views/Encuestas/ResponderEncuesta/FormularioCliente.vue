<template>
    <div class="vistaPrincipal fondoEncuestas">
        <HeaderPrincipal />
        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">
                <MenuLateral
                    v-if="recuperarUsuLog() != '' && recuperarUsuLog() != null && recuperarUsuLog() != undefined" />
                <div class="w-100">

                    <!--Filtros responsive /-->

                    <div v-if="recuperarUsuLog() != '' && recuperarUsuLog() != null && recuperarUsuLog() != undefined">
                        <div class="row justify-content-center filtrosCelularBotones">
                            <div class="col-5"></div>
                            <div class="col-2 filtrosCelularBoton" v-if="!filtroDesplegar" v-on:click="desplegarFiltros()">
                                <a class="text-gradient-yellow-orange-black fas fa-bars"></a>
                            </div>
                            <div class="col-5"></div>
                        </div>

                        <div class="filtrosCelular row justify-content-center" v-if="filtroDesplegar">

                            <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                                <div class="col-8 textoBlanco" style="text-align: center; min-width: 150px;">
                                    <router-link role="button" :to="{ name: 'Inicio' }" class="textoBlanco textoEncuestas"
                                        style="text-decoration: none;"
                                        exact-active-class="active-link">Proyectos&nbsp;&nbsp;<i
                                            class="text-white fas fa-project-diagram"
                                            style="cursor: pointer; font-size: 14px;"></i></router-link>
                                </div>
                            </div>

                            <div v-if="recuperarUsuTipo() == 'Administrador'"
                                class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                                <div class="col-8 textoBlanco" style="text-align: center; min-width: 150px;">
                                    <router-link role="button" :to="{ name: 'Encuestas' }"
                                        class="textoBlanco textoEncuestas" style="text-decoration: none;"
                                        exact-active-class="active-link">Encuestas&nbsp;&nbsp;<i
                                            class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                                </div>
                            </div>

                            <div v-if="recuperarUsuTipo() == 'Administrador'"
                                class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                                <div class="col-8 textoBlanco" style="text-align: center;">
                                    <router-link role="button" :to="{ name: 'Reportes' }" class="textoBlanco textoEncuestas"
                                        style="text-decoration: none;"
                                        exact-active-class="active-link">Reportes&nbsp;&nbsp;<i
                                            class="text-white far fa-file-alt" style="cursor: pointer;"></i></router-link>
                                </div>
                            </div>

                            <div style="text-align: center; font-size: large; padding-top: 40px; cursor: pointer; margin-left: 20px;"
                                v-if="filtroDesplegar" v-on:click="desplegarFiltros()">
                                <a class="text-white fas fa-angle-up" style="text-decoration: none;"></a>
                            </div>

                        </div>
                    </div>

                    <!--Filtros responsive /-->

                    <div class="col-12" style="margin-top: 30px;">
                        <h4 style="text-align: center; font-size: 25px; color: #0a3a66;">Responder encuesta</h4>
                        <br />
                        <div>
                            <div>
                                <div class="estiloForm">
                                    <div style="padding: 50px;">

                                        <!--Preguntas-->
                                        <form @submit.prevent="SendAnswer()">
                                            <div>
                                                <h4 style="text-align: center; font-size: 25px; color: #0a3a66;">{{
                                                    poll.Name }}
                                                </h4>
                                                <br>
                                                <div style="text-align: center; font-size: 15px; color: #000000;"
                                                    v-html="poll.Description"></div>
                                                <br>

                                                <div v-if="(recuperarUsuLog() != '' && recuperarUsuLog() != null && recuperarUsuLog() != undefined) && recuperarUsuTipo() == 'Administrador'"
                                                    style="text-align: center;">
                                                    <p class="cardPersonalizado"
                                                        style="text-align: center; font-size: 15px; color: #000000; cursor: default; padding: 15px;">
                                                        <b>Enlace:</b>&nbsp;<a>{{ fullLink }}</a>
                                                        <br>
                                                    </p>
                                                    <button type="button" class="btn btn-success" b-tooltip.hover
                                                        title="Copiar enlace" @click="copiarLink()"
                                                        style="cursor: pointer; margin-top: 15px;">Copiar&nbsp;&nbsp;<span
                                                            class="fas fa-paperclip"></span></button>
                                                </div>

                                                <div>
                                                    <div>
                                                        <div class="cardPersonalizado"
                                                            v-for="(question, index) in poll.Questions" :key="index">
                                                            <div class="cardInside">

                                                                <h5
                                                                    style="text-align: center; font-size: 25px; background-color: #0a3a66; color: #fff; border-radius: 15px;">
                                                                    {{ question.TextQuestion }}</h5>
                                                                <hr />

                                                                <label v-if="question.Id_Question_Type == 1"
                                                                    style="font-size: medium; float: left;"><span
                                                                        style="color: rgb(199, 0, 0);"><b>Tipo:</b></span>
                                                                    Texto
                                                                </label>
                                                                <label v-if="question.Id_Question_Type == 2"
                                                                    style="font-size: medium; float: left;"><span
                                                                        style="color: rgb(199, 0, 0);"><b>Tipo:</b></span>
                                                                    Respuesta única
                                                                </label>
                                                                <label v-if="question.Id_Question_Type == 3"
                                                                    style="font-size: medium; float: left;"><span
                                                                        style="color: rgb(199, 0, 0);"><b>Tipo:</b></span>
                                                                    Selección múltiple
                                                                </label>

                                                                <input v-if="question.Id_Question_Type == 1"
                                                                    style="border-radius: 15px; margin-bottom: 10px; margin-top: 25px"
                                                                    placeholder="Respuesta"
                                                                    @change="updateAnswerText(question, $event.target.value)"
                                                                    maxlength="150" />
                                                                <span :ref="'ErrorTextInput' + question.Id_Question"
                                                                    style="visibility: hidden; color: red;"> ss</span>
                                                                <br />
                                                                <br />

                                                                <div
                                                                    v-if="question.Id_Question_Type == 2 || question.Id_Question_Type == 3">
                                                                    <h5 class="margin-5px-bottom"
                                                                        style="font-size: 20px; color: #0a3a66;">Opciones
                                                                    </h5>
                                                                    <br />
                                                                    <div v-if="question.Id_Question_Type == 2">
                                                                        <div class="form-check"
                                                                            v-for="(option, index) in question.Question_Options"
                                                                            :key="index">


                                                                            <input :name="question.Id_Question" type="radio"
                                                                                class="estiloRadios" :id="'opcion' + option"
                                                                                :value="JSON.stringify(option)"
                                                                                @change="updateAnswerOptions(option, question)" />


                                                                            <label class="form-check-label">
                                                                                {{ option.Option_Text }}
                                                                            </label>



                                                                        </div>
                                                                        <span :ref="'ErrorRadioBox' + question.Id_Question"
                                                                            style="visibility: hidden; color: red;">aa
                                                                        </span>
                                                                    </div>
                                                                    <div v-if="question.Id_Question_Type == 3">
                                                                        <div class="form-check"
                                                                            v-for="(option, index) in question.Question_Options"
                                                                            :key="index">
                                                                            <input :name="question.Id_Question"
                                                                                type="checkbox"
                                                                                @change="updateAnswerOptionsCheckBox(option, question)"
                                                                                class="estiloRadios" id="opcion1">
                                                                            <label class="form-check-label">
                                                                                {{ option.Option_Text }}
                                                                            </label>



                                                                        </div>
                                                                        <span :ref="'ErrorCheckBox' + question.Id_Question"
                                                                            style="visibility: hidden; color: red;"> </span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>

                                            <!--Preguntas-->

                                            <br />
                                            <br />
                                            <div class="row justify-content-end">
                                                <div class="col-12">
                                                    <button type="submit" class="btn btn-success"
                                                        style="min-width: 150px !important; font-size: 20px; float: right;">Enviar
                                                        respuestas
                                                    </button>
                                                </div>
                                            </div>
                                        </form>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import HeaderPrincipal from '@/components/HeaderPrincipal.vue'
import MenuLateral from '@/components/MenuLateral.vue'
import 'quill/dist/quill.snow.css'
import Cookies from 'js-cookie';
import AdminApi from '@/Api/Api';
import CryptoJS from 'crypto-js';
import router from '@/router/index'
export default {

    components: {
        HeaderPrincipal, MenuLateral
    },

    data() {
        return {
            selectedOption: null,
            filtroDesplegar: false,
            poll: {
                Name: '',
                Description: '',
                Questions:
                {
                    Id_Question: 1,
                    TextQuestion: "",
                    Id_Poll: 1,
                    Id_Question_Type: 1,
                    Question_Options: [],
                    AnswerOptions: [],
                    AnswerText: {
                        Id_Answer: 1,
                        Text: "",
                        Id_Question: ""
                    }
                }
            },
            link: "",
            fullLink: "",
            valid: false

        }
    },

    methods: {

        copiarLink: function () {
            const textarea = document.createElement('textarea');
            textarea.value = this.fullLink;
            document.body.appendChild(textarea);
            textarea.select();

            try {
                document.execCommand('copy');
                this.$swal.fire({
                    icon: 'success',
                    text: 'Enlace copiado en el portapapeles',
                    showConfirmButton: false,
                    timer: 1500
                });
            } catch (err) {
                console.error('Error al intentar copiar el enlace: ', err);
            } finally {
                document.body.removeChild(textarea);
            }
        },

        desplegarFiltros: function () {
            this.filtroDesplegar = !this.filtroDesplegar;
        },

        cerrarFiltros: function () {
            this.filtroDesplegar = false;
        },

        getPoll: async function () {
            let id = this.$route.params.encuesta
            //var url = window.location.href;
            //let id = url.substring(url.lastIndexOf('/') + 1);


            await AdminApi.getLink()
                .then(async response => {
                    if (response.data != null) {
                        this.link = response.data
                    }
                })

            this.fullLink = this.link + "/" + id

            let idDesencrypted = this.Decrypt(id)

            await AdminApi.GetPollSimple(idDesencrypted)
                .then(async response => {
                    if (response.data != null) {
                        this.poll = response.data
                    }
                })
        },

        Decrypt: function (encryptedValue) {
            const clave = CryptoJS.enc.Base64.parse("prmDMvIvPNlrmcsgLM1/c34GHjA7D2P2");
            const iv = CryptoJS.enc.Utf8.parse("cmprmasr");

            const decrypted = CryptoJS.TripleDES.decrypt(encryptedValue, clave, {
                iv: iv
            });

            return decrypted.toString(CryptoJS.enc.Utf8);
        },

        SendAnswer: async function () {

            this.valid = true;

            for (const item of this.poll.Questions) {
                const refName = `Error${item.Id_Question_Type === 1 ? 'TextInput' : (item.Id_Question_Type === 2 ? 'RadioBox' : 'CheckBox')}${item.Id_Question}`;
                const error = this.$refs[refName];

                error[0].textContent = "";
                error[0].style.visibility = "hidden";
            }

            for (const item of this.poll.Questions) {
                const refName = `Error${item.Id_Question_Type === 1 ? 'TextInput' : (item.Id_Question_Type === 2 ? 'RadioBox' : 'CheckBox')}${item.Id_Question}`;
                const error = this.$refs[refName];


                if ((item.Id_Question_Type === 1 && item.AnswerText === null || item.Id_Question_Type === 1 && item.AnswerText.Text === "") ||
                    (item.Id_Question_Type === 2 && item.AnswerOptions === null) ||
                    (item.Id_Question_Type === 3 && item.AnswerOptions === null || item.Id_Question_Type === 3 && item.AnswerOptions.length === 0)) {
                    const errorMsg = (item.Id_Question_Type === 1) ? "La respuesta no puede estar vacía" :
                        ((item.Id_Question_Type === 2) ? "Selecciona una opción" : "Selecciona al menos una opción");

                    if (error && error.length > 0) {
                        error[0].textContent = errorMsg;
                        error[0].style.visibility = "visible";
                        this.valid = false;
                        break;
                    }
                    break;
                }

            }

            if (this.valid) {  // Realizar el post solo si es válido
                await AdminApi.PostSendAnswer(this.poll)
                router.push({ name: 'MensajeEncuesta' })
            }
        }
        ,

        updateAnswerOptions(opcion, question) {



            question.AnswerOptions = [];

            const newAnswerOption = {
                Id_Answer_Option: 0,
                Id_Question_Option: opcion.Id_Question_Option,
            };

            question.AnswerOptions.push(newAnswerOption);

        }
        ,
        updateAnswerOptionsCheckBox(opcion, question) {

            if (!question.AnswerOptions) {
                question.AnswerOptions = [];
            }

            const existingOptionIndex = question.AnswerOptions.findIndex(
                (answerOption) => answerOption.Id_Question_Option === opcion.Id_Question_Option
            );

            if (existingOptionIndex === -1) {

                const newAnswerOption = {
                    Id_Answer_Option: 0,
                    Id_Question_Option: opcion.Id_Question_Option,
                };

                question.AnswerOptions.push(newAnswerOption);

            } else {
                question.AnswerOptions.splice(existingOptionIndex, 1);

            }


        }
        ,
        updateAnswerText(question, value) {
            const newAnswerText = {
                Id_Answer: 0,
                Text: value,
                Id_Question: question.Id_Question // Asigna el ID de la pregunta relacionada.
            };
            question.AnswerText = newAnswerText;

        },
        clearAnswers() {
            // Limpiar todas las selecciones en las preguntas de casilla de verificación
            this.poll.Questions.forEach(question => {
                question.SelectedOptions = [];
            });
        },


        QuitarHTML(html) {
            var temporal = document.createElement('div')
            temporal.innerHTML = html
            return temporal.textContent || temporal.innerText || ""
        },

        limpiarEditor: function () {
            this.quill.root.innerHTML = ""
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
            let nombre = this.recuperarUsuNombre()
            if (login == null || (nombre == undefined || nombre == null || nombre == '')) {
                this.$router.push("/");
                this.$swal({ icon: 'warning', text: 'Aún no ha iniciado sesión, por favor verifique' });
            }

        },

        cerrarMenu: async function () {
            await this.$root.CerrarMenu.call();
            await this.$root.CerrarMenuAplicaciones.call();
        },

    },

    mounted: async function () {
        let loader = this.$loading.show({
            opacity: 1
        })
        setTimeout(() => {
            loader.hide()
        }, 500)
    },

    created: async function () {
        await this.getPoll()
        await this.$root.validarLoginFooter.call();
    }

}
</script>

<style scoped>
.inputsGeneral {
    border-radius: 15px;
    min-height: 50px;
}


.BotonesJ {
    display: flex;
    flex-direction: row-reverse;
    color: white;
    top: 0;
    width: 100%;
    align-content: center;
}

.BotonesJ div {
    margin-left: 10px;
    min-width: 80px;
}

.Adj {
    display: grid;
    grid-template-columns: 75% 25%;
    grid-row-gap: 25px;
}

.agregarAdj {
    display: grid;
    grid-template-columns: 30% 40% 30%;
    grid-row-gap: 25px;
}

#textBox {
    width: 600px;
    height: 300px;
    border: 2px #000000 solid;
    padding: 10px;
    overflow: scroll;
    background-color: yellow;
}

.ql-editor {
    height: 40vh;
    padding-left: 0 !important;
    padding-right: 0 !important;
    padding-bottom: 70px !important;
    overflow-y: visible !important;
}

.selectsJ {
    display: flex;
    justify-content: space-between;
    padding-left: 0px !important;
}

.selectsJ div {
    padding-left: 0px !important;
}

@media screen and (max-width: 991px) {
    .selectsJ {
        display: grid;
        grid-template-columns: 100%;
    }
}

@media screen and (max-width: 800px) {

    .quillResponsiveCelular {
        padding-bottom: 100px;
    }
}

.fondoEncuestas {
    background: rgba(238, 244, 255, 1);
    min-height: calc(100vh - 50px);
    /*background: linear-gradient(90deg, rgba(208,223,255,1) 0%, rgba(238,244,255,1) 50%, rgba(208,223,255,1) 100%);*/
}

.estiloForm {
    background: white;
    border-radius: 25px;
    margin-right: 50PX;
    margin-left: 50px;
}

.botones {
    min-height: 40px;
    color: white;
    min-width: 110px;
}

.cardPersonalizado {
    border: solid 1px rgb(184, 184, 184);
    border-radius: 20px;
    box-shadow: 5px 5px 10px rgb(176, 196, 233);
    transition: box-shadow 0.3s;
    margin-top: 35px;
}

.cardPersonalizado:hover {
    box-shadow: 5px 5px 15px rgb(152, 176, 219);
}

.cardInside {
    padding: 15px;
}

.estiloRadios {
    margin-right: 10px;
}

.labelGen {
    color: #000000;
}

.error-message {
    color: red;
    display: none;
    /* Inicialmente oculto */
}

input:valid+.error-message {
    display: block;
    /* Mostrar el mensaje de error cuando el input sea inválido */
}

.filtrosCelular {
    padding-top: 20px;
    padding-left: 50px;
    padding-right: 50px;
    padding-bottom: 20px;
    background: rgba(10, 58, 102, 1);
}

@media screen and (min-width: 901px) {

    .filtrosCelular {
        display: none;
    }
}

.filtrosCelularBoton {
    text-align: center;
    font-size: large;
    cursor: pointer;
    background-color: rgba(10, 58, 102, 1);
    height: 30px;
    border-bottom-right-radius: 10px;
    border-bottom-left-radius: 10px;
    max-width: 50px;
}

@media screen and (min-width: 901px) {
    .filtrosCelularBotones {
        display: none;
    }

    .filtrosCelularBoton {
        display: none;
    }
}</style>