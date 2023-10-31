<template>
    <div class="vistaPrincipal fondoEncuestas">
        <HeaderPrincipal />
        <div>
            <div class="col-12" style="margin-top: 30px;">
                <h4 style="text-align: center; font-size: 25px; color: #0a3a66;">Responder encuesta</h4>
                <br />
                <div>
                    <div>
                        <div class="estiloForm">
                            <div style="padding: 50px;">

                                <!--Preguntas-->
                                
                                <div>
                                    <h4 style="text-align: center; font-size: 25px; color: #0a3a66;">{{ poll.Name }}</h4>
                                    <br>
                                    <p style="text-align: center; font-size: 15px; color: #000000;">{{ QuitarHTML(poll.Description) }}</p>
                                    <br>
                                    <p style="text-align: center; font-size: 15px; color: #000000;"><b>Link:</b> <a>{{ fullLink }}</a></p>
                                    <div>
                                        <div>
                                            <div class="cardPersonalizado" v-for="(question, index) in poll.Questions" :key="index">
                                                <div class="cardInside">
                                                    <h5 style="text-align: center; font-size: 25px; background-color: #0a3a66; color: #fff; border-radius: 15px;">{{ question.TextQuestion }}</h5>
                                                    <hr />
                                                    <input v-if="question.Id_Question_Type == 1" style="border-radius: 15px; margin-bottom: 10px;" placeholder="Respuesta" />
                                                    <br />
                                                    <br />
                                                    <div v-if="question.Id_Question_Type == 2 || question.Id_Question_Type == 3">
                                                        <h5 class="margin-5px-bottom" style="font-size: 20px; color: #0a3a66;">Opciones</h5>
                                                        <br />
                                                        <div v-if="question.Id_Question_Type == 2">
                                                            <div class="form-check" v-for="(option, index) in question.Question_Options" :key="index">
                                                                <input type="radio" class="estiloRadios" :id="'opcion' + index" name="options" v-model="selectedOption">
                                                                <label class="form-check-label">
                                                                    {{ option.Option_Text }}
                                                                </label>
                                                            </div>
                                                        </div>
                                                        <div v-if="question.Id_Question_Type == 3">
                                                            <div class="form-check" v-for="(option, index) in question.Question_Options" :key="index">
                                                                <input type="checkbox" class="estiloRadios" id="opcion1">
                                                                <label class="form-check-label">
                                                                    {{ option.Option_Text }}
                                                                </label>
                                                            </div>
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
                                    <div class="col-2">
                                        <button class="btn btn-success" style="min-width: 120px; font-size: 20px; float: right;">Enviar respuestas</button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
            </div>
        </div>
    </div>
</template>

<script>
import HeaderPrincipal from '@/components/HeaderPrincipal.vue'
import 'quill/dist/quill.snow.css'
import Cookies from 'js-cookie';
import AdminApi from '@/Api/Api';

export default {

    components: {
        HeaderPrincipal
    },

    data() {
        return {
            poll: [],
            link: "",
            fullLink: ""
        }
    },

    methods: {

        getPoll: async function () {
            let id = this.$route.params.encuesta
            await AdminApi.getLink()
                .then(async response => {
                    if (response.data != null) {
                        this.link = response.data
                    }
                })

            this.fullLink = this.link + "/" + id

            await AdminApi.GetPoll(id)
                .then(async response => {
                    if (response.data != null) {
                        this.poll = response.data
                    }
                })

            console.log(this.poll)
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

.inputsGeneral{
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

.fondoEncuestas{
    background: rgba(238,244,255,1);
    min-height: calc(100vh - 50px);
    /*background: linear-gradient(90deg, rgba(208,223,255,1) 0%, rgba(238,244,255,1) 50%, rgba(208,223,255,1) 100%);*/
}

.estiloForm{
    background: white;
    border-radius: 25px;
    margin-right: 50PX;
    margin-left: 50px;
}

.botones{
    min-height: 40px;
    color: white;
    min-width: 110px;
}

.cardPersonalizado{
    border: solid 1px rgb(184, 184, 184);
    border-radius: 20px;
    box-shadow: 5px 5px 10px rgb(176, 196, 233);
    transition: box-shadow 0.3s;
    margin-top: 35px;
}

.cardPersonalizado:hover{
    box-shadow: 5px 5px 15px rgb(152, 176, 219);
}

.cardInside{
    padding: 15px;
}

.estiloRadios {
    margin-right: 10px;
}

.labelGen {
    color: #000000;
}

</style>