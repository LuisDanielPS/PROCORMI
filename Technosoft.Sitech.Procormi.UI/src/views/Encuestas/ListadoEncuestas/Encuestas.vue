<template>
    <div class="vistaPrincipal">
        <!--<HeaderPrincipal :cuadroLoaderPrincipal="$refs.cuadroLoader" />-->
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">

                <!--Menú Lateral /-->

                <MenuLateral />

                <!--Menú Lateral /-->

                <!--Modal eliminar Encuesta-->

                <div class="modal fade" id="eliminarEncuesta" tabindex="-1" aria-labelledby="eliminarEncuesta" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar Encuesta</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea eliminar la encuesta?</p>
                                </div>
                                <div>
                                    <label>Digite su contraseña</label>
                                    <br />
                                    <div class="row" style="margin-top: 15px;">
                                        <input class="col-10" style="margin-left: 10px; border-radius: 5px;" type="text" required placeholder="Contraseña">
                                        <button class="btn btn-success col-1" style="margin-left: 5px;"><span class="fas fa-check"></span></button>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-success">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal eliminar Encuesta-->

                <div class="w-100 listadoGeneral">

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

                    <div class="w-100 vld-parent col-12" style="min-height: 85vh;">

                        <!--Lista de encuestas /-->

                        <div class="row" style="padding:15px; min-height: 95vh; padding-right: 45px;">
                            <div class="col-12 estiloTabla" style="padding:15px;">
                                <div class="card" style="border: none;" ref="cuadroLoader">
                                    <div class="encabezado">
                                        <div style="text-align: left;">
                                            <FiltroSuperior class="justify-content-center buscador" />
                                        </div>
                                        <div style="text-align: center; padding-top: 10px; cursor: default;">
                                            <h4>Listado de Encuestas</h4>
                                        </div>
                                        <ul style="text-align: right;">
                                            <router-link class="li agregarBlt agregarResponsive" role="button" :to="{ name: 'CrearEncuesta' }"><span class="fas fa-plus"></span> Crear Encuesta</router-link>
                                            <router-link class="li agregarBlt agregarResponsivePlus" role="button" :to="{ name: 'CrearEncuesta' }"><span class="fas fa-plus"></span></router-link>
                                        </ul>
                                    </div>

                                    <div class="row">
                                        <div class="col-3">
                                            <div>
                                                <a class="text-black fas fa-calendar-alt"></a>
                                                <label class="text-black p-3 Td">Fecha inicio</label>
                                            </div>
                                            <input type="date" id="fechaInicio" class="diseñoSelectLateral" style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fechaI">
                                        </div>

                                        <div class="col-3">
                                            <div>
                                                <a class="text-black fas fa-calendar-alt"></a>
                                                <label class="text-black p-3 Td">Fecha Fin</label>
                                            </div>
                                            <input type="date" id="fechaFin" class="diseñoSelectLateral" style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fechaF">
                                        </div>
                                        
                                        <div class="col-3">
                                            <div>
                                                <a class="text-black fas fa-check-square" style="text-decoration: none;"></a>
                                                <label class="text-black p-3 Td">Estado</label>
                                            </div>
                                            <select class="form-select diseñoSelectLateral" v-model="Filtros.estado">
                                                <option value="">Todos</option>
                                                <!--<option v-bind:value="Estado.gen_EstadoCodigo"
                                                        v-for="Estado in ListaEstados"
                                                        v-bind:key="Estado.gen_EstadoID">
                                                    {{Estado.gen_EstadoDescripcion}}
                                                </option>-->
                                            </select>
                                        </div>

                                        <div v-if="recuperarUsuTipo() == 'Administrador'" class="col-3">
                                            <div>
                                                <a class="text-black fas fa-user"></a>
                                                <label class="text-black p-3 Td">Usuario</label>
                                            </div>
                                            <select class="form-select diseñoSelectLateral" v-model="Filtros.usuario">
                                                <option value="">Todos</option>
                                                <!--<option v-bind:value="Usuario.usu_Login"
                                                        v-for="Usuario in ListaUsuarios"
                                                        v-bind:key="Usuario.usu_Login">
                                                    {{Usuario.usu_Login}}
                                                </option>-->
                                            </select>
                                        </div>
                                    </div>

                                    <!--<div class="sinResultadosAct">
                                        <p>No hay encuestas para mostrar</p>
                                    </div>-->
                                    <div class="contenidoTabla">
                                        <table class="table table-stryped" style="text-align: center;">
                                            <thead>
                                                <tr>
                                                    <th class="col-1" style="min-width: 75px;"># Encuesta</th>
                                                    <th class="col-4" style="min-width: 150px;">Nombre</th>
                                                    <th class="col-3" style="min-width: 125px;">Fecha de creación</th>
                                                    <th class="col-2" style="min-width: 125px;">Opciones</th>
                                                </tr>
                                            </thead>
                                            <tbody style="font-size: large;">
                                                <tr>
                                                    <td>1</td>
                                                    <td>Encuesta Procormi</td>
                                                    <td>01/05/2023</td>
                                                    <td class="text-white">
                                                        <button class="btn btn-primary" role="button" @click="VerEncuesta">
                                                            <span class="fas fa-eye" b-tooltip.hover title="Ver Encuesta"></span>
                                                        </button>
                                                        <button style="margin-left: 5px;" type="button" class="btn btn-success" @click="EditarEncuesta(1)">
                                                            <span class="fas fa-pen" b-tooltip.hover title="Editar Encuesta"></span>
                                                        </button>
                                                        <button type="button" class="btn btn-danger" style="margin-left: 5px;">
                                                            <span class="fas fa-trash" b-tooltip.hover title="Eliminar Encuesta" data-bs-toggle="modal" data-bs-target="#eliminarEncuesta"></span>
                                                        </button>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                            <nav aria-label="Page navigation example" style="position: absolute; bottom: 25px; margin-left: 25px;">
                                <ul class="pagination">
                                    <li class="page-item"><a class="page-link" href="#">Anterior</a></li>
                                    <li class="page-item"><a class="page-link" href="#">1</a></li>
                                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item"><a class="page-link" href="#">Siguiente</a></li>
                                </ul>
                            </nav>
                        </div>

                        <!--Lista de encuestas /-->

                    </div>
                </div>

            </div>
        </div>
    </div>
</template>

<script>
import Cookies from 'js-cookie';
import HeaderPrincipal from '@/components/HeaderPrincipal.vue'
import MenuLateral from '@/components/MenuLateral.vue'
import FiltroSuperior from '@/components/FiltroSuperior.vue'
//import AdminApi from '@/Api/Api';

export default {

    components: {
        HeaderPrincipal, MenuLateral, FiltroSuperior
    },

    data() {
        return {
            esConocormi: false,
            esActicormi: false,
            esIncormi: false,
            filtroDesplegar: false,

            Filtros: {
            fechaI: "",
            fechaF: "",
            estado: "",
            usuario: "",
            },


            //Incormi
            IDCon: 0,
            ListaContenido: [],
            ListaContenidoTemporal: [],
            ListaDepartamentos: [],
            ListaCategorias: [],
            ListaObservaciones: [],
            ListaAdjuntos: [],
            paginate: ['ListaContenido'],
            NombreContenido: '',
            ModalContenido: false,
            ModalObservacion: false,
            ModalConfirmacion: false,
            ModalImagen: false,
            FiltroDepartamento: 400,
            FiltroCategoria: 400,
            BtnConfirmaciones: true,
            BtnAdministrador: false,
            FiltDepartamento: false,
            TablaObservaciones: true,
            TablaAdjuntos: true,
            RangoFecha: "0",
            Contenido: {
                id_gen_contenido: 0,
                id_categoria: 0,
                id_departamento: 0,
                usu_Login: "",
                titulo: "",
                descripcion: "",
                fecha: new Date().toISOString().slice(0, 10),
                obligatorio: true,
                visualizar_observacion: true,
                envio_correo: true,
                nombre_departamento: "",
                nombre_categoria: "",
                nombre_adjunto: "",
                tipo_archivo: "",
                adjunto: ""
            },
            Observacion: {
                usu_Login: "",
                asunto: "",
                mensaje: "",
                fecha: new Date().toISOString().slice(0, 10),
                id_contenido: 0
            },
            Confirmacion: {
                id_contenido: 0,
                usu_Login: "",
                Contraseña: "",
                fecha: new Date().toISOString().slice(0, 10),
            }
        }
    },

    methods: {

        EditarEncuesta: function(EncuestaID) {
            this.$router.push({
                name: "CrearEncuestaEdit",
                params: {
                    id: EncuestaID,
                }
            })
        },

        VerEncuesta: function() {
            this.$router.push({
                name: "FormularioCliente",
            })
        },

        desplegarFiltros: function () {
            this.filtroDesplegar = !this.filtroDesplegar;
        },

        cerrarFiltros: function () {
            this.filtroDesplegar = false;
        },

        seleccionarAplicacion: async function() {
            await this.$root.designarAplicacionHeaderPrincipal.call();
        },

        cerrarMenu: async function () {
            await this.$root.CerrarMenu.call();
            await this.$root.CerrarMenuAplicaciones.call();
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

    mounted: async function() {
        this.$root.cerrarMenuFiltros = this.cerrarFiltros;
        let loader = this.$loading.show({
            container: this.$refs.cuadroLoader,
            opacity: 1
        })
                
        setTimeout(() => {
            loader.hide()
        }, 500)
    },

    created: async function () {
        await this.verificarLog();
        await this.$root.validarLoginFooter.call();
    }

}

</script>

<style>
</style>

<style scoped>

#header {
    margin: auto;
    width: 500px;
    font-family: Arial, Helvetica, sans-serif;
}

ul, ol {
    list-style: none;
}

.filtro {
    height: 3em;
    background: #000;
    border-radius: 0.5em;
}

    .filtro button {
        background-color: #000;
        border-radius: 0.5em;
        border: none;
    }

    .filtro button:hover {
        background-color: #000;
        border-radius: 0.5em;
        border: none;
        font-size: 15px;
    }

/*Select*/

.diseñoSelectLateral{
    height: 30px;
}

.diseñoSelect{
    height: 35px;
}

/*Select*/

.posicion0 {
    z-index: 0;
}

.posicion1 {
    z-index: 1;
    max-width: 280px;
    min-height: 95vh;
    background-color: #0a3a66;
    min-width: 15em;
    border-bottom: 1px solid white;
}

@media screen and (max-width: 900px) {
    .posicion1{
        display: none;
    }
}

@media screen and (max-width: 700px) {

    .responsiveCelular {
        min-height: 500px;
    }

    .menuLateralCelular{
        display: none;
    }
}

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

.encabezado {
    display: grid;
    grid-template-columns: 25% 50% 25%;
    background-color: #ffffff;
    color: rgb(0, 0, 0);
    min-height: 50px;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    max-width: 1800px;
    margin-top: 25px;
}

    .encabezado ul {
            padding-top: 14px;
        }

    .li {
        font-family: sans-serif;
        color: black;
        text-decoration: none;
    }

    .encabezado div {
        text-align: center;
    }

.sinResultadosAct{
    width: 100%;
    text-align: center;
    margin-top: 30px;
    margin-bottom: 30px;
}

.contenidoTabla {
    max-width: 2100px;
    overflow-x: auto;
    margin-top: 25px;
}

.agregarBlt{
    font-family: sans-serif;
    font-size: 18px;
    text-decoration: none;
    padding-right: 10px;
    position: relative;
    top: -5px;
    color: rgb(0, 0, 0);
}

@media screen and (max-width: 975px) {
    .agregarResponsive{
        display: none;
    }
}

@media screen and (min-width: 975px) {
    .agregarResponsivePlus{
        display: none;
    }
}

@media screen and (min-width: 901px) {
    .linkResponsive{
        display: none;
    }
}

@media screen and (max-width: 610px) {
    .linkResponsiveCelular{
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

.vistaPrincipal{
    min-height: 85vh;
}

@media screen and (max-width: 900px) {
    .vistaPrincipal{
        min-height: 98vh;
    }
}

@media screen and (max-width: 400px) {
    .vistaPrincipal{
        min-height: 100vh;
    }
}

.botonEncuestas{
    margin-left: -15px;
    min-width: 12.4rem;
    background-color: #114677;;
    min-height: 35px;
    border-radius: 5px;
    padding-top: 20px;
    list-style: none;
}

.textoEncuestas{
    margin-left: 25px;
    margin-top: -15px;
    font-size: 17px;
    text-decoration: none;
    color: white;
    display: block;
    position: relative;
}

</style>