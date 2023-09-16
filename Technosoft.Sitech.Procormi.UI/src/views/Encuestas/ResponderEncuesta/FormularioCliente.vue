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
                                
                                <br />
                                <div>
                                    <h4 style="text-align: center; font-size: 25px; color: #0a3a66;">Listado de preguntas</h4>
                                    <div>
                                        <div>
                                            <div class="cardPersonalizado">
                                                <div class="cardInside">
                                                    <h5 style="text-align: center; font-size: 25px; background-color: #0a3a66; color: #fff; border-radius: 15px;">Escriba su opinión con respecto a este sistema</h5>
                                                    <hr />
                                                    <input style="border-radius: 15px; margin-bottom: 10px;" placeholder="Respuesta" />
                                                    <br />
                                                    <br />
                                                    <div>
                                                        <h5 class="margin-5px-bottom" style="font-size: 20px; color: #0a3a66;">Opciones</h5>
                                                        <br />
                                                        <div class="form-check">
                                                            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                                                            <label class="form-check-label" for="flexRadioDefault1">
                                                                Opción 1
                                                            </label>
                                                        </div>
                                                        <div class="form-check">
                                                            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                                                            <label class="form-check-label" for="flexRadioDefault2">
                                                                Opción 2
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="cardPersonalizado">
                                                <div class="cardInside">
                                                    <h5 style="text-align: center; font-size: 25px; background-color: #0a3a66; color: #fff; border-radius: 15px;">Escriba su opinión con respecto a este sistema</h5>
                                                    <hr />
                                                    <input style="border-radius: 15px; margin-bottom: 10px;" placeholder="Respuesta" />
                                                    <br />
                                                    <br />
                                                    <div>
                                                        <h5 class="margin-5px-bottom" style="font-size: 20px; color: #0a3a66;">Opciones</h5>
                                                        <br />
                                                        <div class="form-check">
                                                            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                                                            <label class="form-check-label" for="flexRadioDefault1">
                                                                Opción 1
                                                            </label>
                                                        </div>
                                                        <div class="form-check">
                                                            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                                                            <label class="form-check-label" for="flexRadioDefault2">
                                                                Opción 2
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="cardPersonalizado">
                                                <div class="cardInside">
                                                    <h5 style="text-align: center; font-size: 25px; background-color: #0a3a66; color: #fff; border-radius: 15px;">Escriba su opinión con respecto a este sistema</h5>
                                                    <hr />
                                                    <input style="border-radius: 15px; margin-bottom: 10px;" placeholder="Respuesta" />
                                                    <br />
                                                    <br />
                                                    <div>
                                                        <h5 class="margin-5px-bottom" style="font-size: 20px; color: #0a3a66;">Opciones</h5>
                                                        <br />
                                                        <div class="form-check">
                                                            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                                                            <label class="form-check-label" for="flexRadioDefault1">
                                                                Opción 1
                                                            </label>
                                                        </div>
                                                        <div class="form-check">
                                                            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                                                            <label class="form-check-label" for="flexRadioDefault2">
                                                                Opción 2
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            
                                        </div>
                                    </div>
                                </div>

                                <!--Preguntas-->

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

export default {

    components: {
        HeaderPrincipal
    },

    data() {
        return {

        }
    },

    methods: {

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

</style>