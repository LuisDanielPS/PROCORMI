<template>
    <div class="vistaPrincipal fondoEncuestas">
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">
                <MenuLateral />

                <div class="w-100">

                    <!--Filtros responsive /-->

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
                                <router-link role="button" :to="{ name: 'Inicio' }" class="textoBlanco textoEncuestas" style="text-decoration: none;" exact-active-class="active-link">Proyectos&nbsp;&nbsp;<i class="text-white fas fa-project-diagram" style="cursor: pointer; font-size: 14px;"></i></router-link>
                            </div>
                        </div>
                        
                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center; min-width: 150px;">
                                <router-link role="button" :to="{ name: 'Encuestas' }" class="textoBlanco textoEncuestas" style="text-decoration: none;" exact-active-class="active-link">Encuestas&nbsp;&nbsp;<i class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center;">
                                <router-link role="button" :to="{ name: 'Reportes' }" class="textoBlanco textoEncuestas" style="text-decoration: none;" exact-active-class="active-link">Reportes&nbsp;&nbsp;<i class="text-white far fa-file-alt" style="cursor: pointer;"></i></router-link>
                            </div>
                        </div>

                        <div style="text-align: center; font-size: large; padding-top: 40px; cursor: pointer; margin-left: 20px;" v-if="filtroDesplegar" v-on:click="desplegarFiltros()">
                            <a class="text-white fas fa-angle-up" style="text-decoration: none;"></a>
                        </div>

                    </div>

                    <!--Filtros responsive /-->

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
                                            <input v-model="encuesta.Name" maxlength="50" class="small-input inputsGeneral" placeholder="Escriba el título de la encuesta" type="text">
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
                                                    <textarea class="small-input inputsGeneral" style="height: 35px !important;" placeholder="Escriba la pregunta" v-model="preguntaActual.TextQuestion"></textarea>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="col-4">
                                                    <label class="margin-15px-bottom text-black" style="font-size: large;">Tipo</label>
                                                    <select class="form-select inputsGeneral" v-model="preguntaActual.Id_Question_Type" @change="seleccionarTipo(preguntaActual.Id_Question_Type)">
                                                        <option value="1">Texto</option>
                                                        <option value="2">Respuesta única</option>
                                                        <option value="3">Selección múltiple</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <br />
                                            <div v-if="preguntaActual.Id_Question_Type === 2 || preguntaActual.Id_Question_Type === 3">
                                                <label class="margin-15px-bottom text-black" style="font-size: large; cursor: default;">Opciones</label>&nbsp;&nbsp;<a @click="agregarOpcion" class="fas fa-plus" style="cursor: pointer; text-decoration: none; font-size: 15px;"></a>
                                                <div class="row" v-for="(opcion, index) in preguntaActual.Question_Options" :key="index">
                                                    <div class="col-11">
                                                        <input maxlength="200" type="text" class="small-input inputsGeneral" placeholder="Escriba una opción" style="margin-bottom: 30px;" v-model="opcion.Option_Text">
                                                    </div>
                                                    <div class="col-1">
                                                        <button class="btn btn-danger" style="float: right; min-height: 48px; min-width: 45px;" @click="deleteOptionInput(index)"><span class="fas fa-trash"></span></button>
                                                    </div>
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
                                        <div v-if="encuesta.Questions.length > 0">
                                            <h4 style="text-align: center; font-size: 25px; color: #0a3a66;">Listado de preguntas</h4>
                                            <div>
                                                <div>
                                                    <div class="cardPersonalizado" v-for="(pregunta, index) in encuesta.Questions" :key="index">
                                                        <div class="cardInside">
                                                            <h5 style="text-align: center; font-size: 25px; background-color: #0a3a66; color: #fff; border-radius: 15px;">{{ pregunta.TextQuestion }}</h5>
                                                            <hr />
                                                            <input v-if="pregunta.Id_Question_Type === 1" style="border-radius: 15px; margin-bottom: 10px; background-color: rgb(241, 241, 241);" disabled placeholder="Respuesta" />
                                                            <div v-if="pregunta.Id_Question_Type === 2 || pregunta.Id_Question_Type === 3">
                                                                <h5 class="margin-5px-bottom" style="font-size: 20px; color: #0a3a66;">Opciones</h5>
                                                                <br />
                                                                <p style="font-size: medium;" v-for="(opcion, opcionIndex) in pregunta.Question_Options" :key="opcionIndex"><span class="far">&#xf0c8;</span>&nbsp;&nbsp;{{ opcion.Option_Text }}</p>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-6">
                                                                    <label style="font-size: medium; float: left;"><span style="color: rgb(199, 0, 0);"><b>Tipo</b></span> {{ pregunta.Id_Question_Type }}</label>
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
                                                <button class="btn btn-success" style="min-width: 100px; position: absolute; right: 210px;" @click="sendPoll">Guardar</button>
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
        </div>
    </div>
</template>

<script>
import HeaderPrincipal from '@/components/HeaderPrincipal.vue'
import MenuLateral from '@/components/MenuLateral.vue'
import Quill from 'quill'
import 'quill/dist/quill.snow.css'
import Cookies from 'js-cookie';
import AdminApi from '@/Api/Api';

export default {

    components: {
        /* eslint-disable */
        HeaderPrincipal, MenuLateral, Quill
        /* eslint-enable */
    },

    data() {
        return {
            idEncuesta: (this.$route.params.id != undefined) ? this.$route.params.id : 0,
            esEditar: false,
            encuesta: {
                Name: '',
                Description: '',
                Questions: []
            },
            //tiposPregunta: ['Texto', 'Respuesta única', 'Selección múltiple'],
            preguntaActual: {
                Id_Question_Type: 1,
                TextQuestion: '',
                Question_Options: []
            },
            filtroDesplegar: false,
        }
    },

    methods: {

        desplegarFiltros: function () {
            this.filtroDesplegar = !this.filtroDesplegar;
        },

        cerrarFiltros: function () {
            this.filtroDesplegar = false;
        },

        cerrarMenu: async function () {
            await this.$root.CerrarMenu.call();
            await this.$root.CerrarMenuAplicaciones.call();
        },

        sendPoll: async function () {
            let loader = this.$loading.show({
                container: this.$refs.cuadroLoader,
                opacity: 1
            })
            var description = this.quill.root.innerHTML
            if(description == "<p><br></p>"){
                description = "";
            }
            this.encuesta.Description = description

            if (this.encuesta.Name.trim() == "") {
                this.$swal.fire({
                        position: 'top-end',
                        text: 'Por favor, digite el título de la encuesta',
                        showConfirmButton: false,
                        timer: 3000
                    })
                loader.hide()
            } else if (this.encuesta.Description.trim() == "") {
                this.$swal.fire({
                        position: 'top-end',
                        text: 'Por favor, digite la descripción de la encuesta',
                        showConfirmButton: false,
                        timer: 3000
                    })
                loader.hide()
            } else if (this.encuesta.Questions.length == 0) {
                this.$swal.fire({
                        position: 'top-end',
                        text: 'Por favor, digite al menos una pregunta',
                        showConfirmButton: false,
                        timer: 3000
                    })
                loader.hide()
            }
            await AdminApi.PostNewPoll(this.encuesta)
                .then(response => {
                    if (response.data.obj == true) {
                        this.$swal.fire({
                            icon: 'success',
                            position: 'center',
                            text: response.data.msg,
                            showConfirmButton: true
                        })
                        //this.limpiarContenido()
                    }
                })
            loader.hide()
        },

        validarEditar: function () {
            if(this.idEncuesta != 0){
                this.esEditar = true;
            } else {
                this.esEditar = false;
            }
        },

        //Preguntas

        seleccionarTipo(Id_Question_Type) {
            if(Id_Question_Type == 2){
                this.preguntaActual.Id_Question_Type = 2
            } else if(Id_Question_Type == 3){
                this.preguntaActual.Id_Question_Type = 3
            } else {
                this.preguntaActual.Id_Question_Type = 1
            }
        },
        
        async agregarPregunta() {
            if (this.preguntaActual.TextQuestion) {
                if((this.preguntaActual.Id_Question_Type != 1 && this.preguntaActual.Question_Options.length > 0) || this.preguntaActual.Id_Question_Type == 1){
                    if(this.preguntaActual.Id_Question_Type != 1){
                        if(this.preguntaActual.Question_Options[0].Option_Text == ""){
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
                    const nuevaPregunta = { Id_Question_Type: this.preguntaActual.Id_Question_Type, TextQuestion: this.preguntaActual.TextQuestion, Question_Options: this.preguntaActual.Question_Options };
                    await this.encuesta.Questions.push(nuevaPregunta);
                    //this.preguntaActual.Id_Question_Type = 'Texto',
                    this.preguntaActual.TextQuestion = '',
                    this.preguntaActual.Question_Options = []
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
            this.encuesta.Questions.splice(index, 1)
        },

        EditarPregunta(index) {
            var objeto = this.encuesta.Questions[index]
            var pregunta = objeto.TextQuestion
            var Id_Question_Type = objeto.Id_Question_Type
            var Question_Options = objeto.Question_Options
            this.preguntaActual.TextQuestion = pregunta
            this.preguntaActual.Id_Question_Type = Id_Question_Type
            this.preguntaActual.Question_Options = Question_Options
            this.encuesta.Questions.splice(index, 1)
        },

        agregarOpcion() {
            this.preguntaActual.Question_Options.push({ Option_Text: '' });
        },

        deleteOptionInput(index) {
            this.preguntaActual.Question_Options.splice(index, 1)
        },

        //Preguntas

        limpiarEditor: function () {
            this.quill.root.innerHTML = ""
        },

        limpiarContenido: function () {
            this.encuesta.Name = ""
            this.encuesta.Questions = []
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

/*-----------------------------------------*/

.filtrosCelular{
    padding-top: 20px;
    padding-left: 50px;
    padding-right: 50px;
    padding-bottom: 20px;
    background: rgba(10,58,102,1);
}

@media screen and (min-width: 901px) {

    .filtrosCelular{
        display: none;
    }
}

.filtrosCelularBoton{
    text-align: center;
    font-size: large;
    cursor: pointer;
    background-color: rgba(10,58,102,1);
    height: 30px;
    border-bottom-right-radius: 10px;
    border-bottom-left-radius: 10px;
    max-width: 50px;
}

@media screen and (min-width: 901px) {
    .filtrosCelularBotones{
        display: none;
    }

    .filtrosCelularBoton{
        display: none;
    }
}

</style>