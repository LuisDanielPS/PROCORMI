<template>
    <div class="vistaPrincipal fondoEncuestas">
        <HeaderPrincipal />
        <div>
            <div class="col-12" style="margin-top: 30px;">
                <h4 style="text-align: center; font-size: 25px; color: #0a3a66;" v-if="!esEditar">Crear encuesta</h4>
                <h4 style="text-align: center; font-size: 25px; color: #0a3a66;" v-if="esEditar">Editar encuesta</h4>
                <br />
                <div>
                    <div>
                        <div class="estiloForm">
                            <div style="padding: 50px;">
                                <div>
                                    <label class="margin-15px-bottom text-black" style="font-size: large;">Título</label>
                                    <input maxlength="50" class="small-input inputsGeneral" placeholder="Escriba el título de la encuesta" type="text">
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black" style="font-size: large;">Descripción</label>
                                            <div>
                                                <div ref="Quill" style="min-height: 200px; border-bottom-left-radius: 15px; border-bottom-right-radius: 15px;"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />

                                <!--Preguntas-->
                                
                                <hr />
                                <br />
                                <br />
                                <div>
                                    <h4 style="text-align: center; font-size: 25px; color: #0a3a66;">Agregar preguntas</h4>
                                    <br />
                                    <br />
                                    <div class="row">
                                        <div class="col-8">
                                            <label class="margin-15px-bottom text-black" style="font-size: large;">Pregunta</label>
                                            <textarea class="small-input inputsGeneral" style="height: 35px !important;" placeholder="Escriba la pregunta" v-model="preguntaActual.texto"></textarea>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="col-4">
                                            <label class="margin-15px-bottom text-black" style="font-size: large;">Tipo</label>
                                            <select class="form-select inputsGeneral" v-model="preguntaActual.tipo" @click="seleccionarTipo(preguntaActual.tipo)">
                                                <option v-for="(tipo, index) in tiposPregunta" :key="index">{{ tipo }}</option>
                                            </select>
                                        </div>
                                    </div>
                                    <br />
                                    <div v-if="preguntaActual.tipo === 'Respuesta única' || preguntaActual.tipo === 'Selección múltiple'">
                                        <label class="margin-15px-bottom text-black" style="font-size: large; cursor: default;">Opciones</label>&nbsp;&nbsp;<a @click="agregarOpcion" class="fas fa-plus" style="cursor: pointer; text-decoration: none; font-size: 15px;"></a>
                                        <div v-for="(opcion, index) in preguntaActual.opciones" :key="index">
                                            <input type="text" class="small-input inputsGeneral" placeholder="Escriba una opción" style="margin-bottom: 30px;" v-model="opcion.texto">
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="row justify-content-center">
                                        <div class="col-6">

                                        </div>
                                        <div class="col-6">
                                            <button class="btn btn-primary botones" style="float: right;" @click="agregarPregunta" b-tooltip.hover title="Agregar pregunta a la lista"><span class="fas fa-plus"></span> Pregunta</button>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />
                                <div v-if="encuesta.preguntas.length > 0">
                                    <h4 style="text-align: center; font-size: 25px; color: #0a3a66;">Listado de preguntas</h4>
                                    <div>
                                        <div>
                                            <div class="cardPersonalizado" v-for="(pregunta, index) in encuesta.preguntas" :key="index">
                                                <div class="cardInside">
                                                    <h5 style="text-align: center; font-size: 25px; background-color: #0a3a66; color: #fff; border-radius: 15px;">{{ pregunta.texto }}</h5>
                                                    <hr />
                                                    <input v-if="pregunta.tipo === 'Texto'" style="border-radius: 15px; margin-bottom: 10px; background-color: rgb(241, 241, 241);" disabled placeholder="Respuesta" />
                                                    <div v-if="pregunta.tipo === 'Respuesta única' || pregunta.tipo === 'Selección múltiple'">
                                                        <h5 class="margin-5px-bottom" style="font-size: 20px; color: #0a3a66;">Opciones</h5>
                                                        <br />
                                                        <p style="font-size: medium;" v-for="(opcion, opcionIndex) in pregunta.opciones" :key="opcionIndex"><span class="far">&#xf0c8;</span>&nbsp;&nbsp;{{ opcion.texto }}</p>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-6">
                                                            <label style="font-size: medium; float: left;"><span style="color: rgb(199, 0, 0);"><b>Tipo</b></span> {{ pregunta.tipo }}</label>
                                                        </div>
                                                        <div class="col-6">
                                                            <a class="fas fa-trash" style="font-size: medium; text-decoration: none; cursor: pointer; float: right; margin-right: 10px;" @click="EliminarPregunta(index)"></a>
                                                            <a class="fas fa-pen" style="font-size: medium; text-decoration: none; cursor: pointer; float: right; margin-right: 10px;" @click="EditarPregunta(index)"></a>
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
                                        <button class="btn btn-success" style="min-width: 100px; position: absolute; right: 210px;">Enviar</button>
                                    </div>
                                    <div class="col-2">
                                        <router-link role="button" :to="{ name: 'Encuestas' }" class="btn btn-danger" style="min-width: 100px; position: absolute; right: 100px;">Cancelar</router-link>
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
import Quill from 'quill'
import 'quill/dist/quill.snow.css'
import Cookies from 'js-cookie';

export default {

    components: {
        /* eslint-disable */
        HeaderPrincipal, Quill
        /* eslint-enable */
    },

    data() {
        return {
            idEncuesta: (this.$route.params.id != undefined) ? this.$route.params.id : 0,
            esEditar: false,
            encuesta: {
                titulo: '',
                descripcion: '',
                preguntas: []
            },
            tiposPregunta: ['Texto', 'Respuesta única', 'Selección múltiple'],
            preguntaActual: {
                tipo: 'Texto',
                texto: '',
                opciones: []
            },
        }
    },

    methods: {

        validarEditar: function () {
            if(this.idEncuesta != 0){
                this.esEditar = true;
            } else {
                this.esEditar = false;
            }
        },

        //Preguntas

        seleccionarTipo(tipo) {
            if(tipo == "Respuesta única"){
                this.preguntaActual.tipo = "Respuesta única"
            } else if(tipo == "Selección múltiple"){
                this.preguntaActual.tipo = "Selección múltiple"
            } else {
                this.preguntaActual.tipo = "Texto"
            }
        },
        
        async agregarPregunta() {
            if (this.preguntaActual.texto) {
                if((this.preguntaActual.tipo != "Texto" && this.preguntaActual.opciones.length > 0) || this.preguntaActual.tipo == "Texto"){
                    if(this.preguntaActual.tipo != "Texto"){
                        if(this.preguntaActual.opciones[0].texto == ""){
                        await this.$swal.fire({
                                //icon: 'warning',
                                position: 'top',
                                text: 'Debe agregar al menos una opción',
                                showConfirmButton: false,
                                timer: 3000
                            })
                            return
                        }
                    }
                    const nuevaPregunta = { tipo: this.preguntaActual.tipo, texto: this.preguntaActual.texto, opciones: this.preguntaActual.opciones };
                    await this.encuesta.preguntas.push(nuevaPregunta);
                    //this.preguntaActual.tipo = 'Texto',
                    this.preguntaActual.texto = '',
                    this.preguntaActual.opciones = []
                } else {
                    await this.$swal.fire({
                        //icon: 'warning',
                        position: 'top',
                        text: 'Debe agregar al menos una opción',
                        showConfirmButton: false,
                        timer: 3000
                    })
                }
            } else {
                    await this.$swal.fire({
                        //icon: 'warning',
                        position: 'top',
                        text: 'Por favor, digite una pregunta',
                        showConfirmButton: false,
                        timer: 3000
                    })
            }
        },

        EliminarPregunta(index) {
            this.encuesta.preguntas.splice(index, 1)
        },

        EditarPregunta(index) {
            var objeto = this.encuesta.preguntas[index]
            var pregunta = objeto.texto
            var tipo = objeto.tipo
            var opciones = objeto.opciones
            this.preguntaActual.texto = pregunta
            this.preguntaActual.tipo = tipo
            this.preguntaActual.opciones = opciones
            this.encuesta.preguntas.splice(index, 1)
        },

        agregarOpcion() {
            this.preguntaActual.opciones.push({ texto: '' });
        },

        //Preguntas

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
        this.quill = new Quill(this.$refs.Quill, {
            theme: 'snow'
        })
    },

    created: async function () {
        await this.verificarLog();
        await this.$root.validarLoginFooter.call();
        await this.validarEditar();
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
    transform: translate(-1px);
}

.cardInside{
    padding: 15px;
}

</style>