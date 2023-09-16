<template>
    <div class="vistaPrincipal">
        <!--<HeaderPrincipal :cuadroLoaderPrincipal="$refs.cuadroLoader" />-->
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">

                <!--Modal crear Sprint-->

                <div class="modal fade" id="staticBackdrop" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Crear Sprint</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Nombre</label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input required style="border-radius: 5px;" type="text" placeholder="Nombre">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Inicia</label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input required style="border-radius: 5px;" type="date">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Finaliza</label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input required style="border-radius: 5px;" type="date">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Usario asignado</label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select required name="usuarios" id="usuarios" class="form-select text-black" style="min-height: 48px;">
                                            <option value="">Seleccione un usuario</option>
                                            <option value="1">Johan Aguilar</option>
                                            <option value="2">Luis Fallas</option>
                                        </select>
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

                <!--Modal crear Sprint-->

                <!--Modal eliminar Sprint-->

                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar Sprint</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea eliminar el sprint?</p>
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

                <!--Modal eliminar Sprint-->

                <!--Menú Lateral /-->

                <div class="posicion1 menuLateralCelular">
                    <div class="d-flex col-3">
                        <div class="col-8" style="min-width: 15em;">
                            <br />
                            <div style="margin-left: 15px;">
                                <div class="col-11 ml-4">
                                    <div>
                                        <div style="text-align: center;">
                                            <div style="text-align: center;">
                                                <a class="text-white fas fa-calendar-alt"></a>
                                                <label class="text-white p-3 Td">Fecha inicio</label>
                                            </div>
                                            <input type="date" id="fechaInicio" class="diseñoSelectLateral" style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fechaI">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-11 ml-4" style="margin-top: 5px;">
                                    <div>
                                        <div style="text-align: center;">
                                            <div style="text-align: center;">
                                                <a class="text-white fas fa-calendar-alt"></a>
                                                <label class="text-white p-3 Td">Fecha Fin</label>
                                            </div>
                                            <input type="date" id="fechaFin" class="diseñoSelectLateral" style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fechaF">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-11 ml-4" style="margin-top: 5px;">
                                    <div>
                                        <div style="text-align: center;">
                                            <div style="text-align: center;">
                                                <a class="text-white fas fa-check-square"></a>
                                                <label class="text-white p-3 Td">Estado</label>
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
                                    </div>
                                </div>
                                <div class="col-11 ml-4" style="margin-top: 5px;">
                                    <div>
                                        <div v-if="recuperarUsuTipo() == 'Administrador'" style="text-align: center;">
                                            <div style="text-align: center;">
                                                <a class="text-white fas fa-user-check"></a>
                                                <label class="text-white p-3 Td">Usuario</label>
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
                                </div>
                                <br />
                                <br />
                                <div class="col-11 ml-4">
                                    <div class="col-12">
                                        <div class="col-12 filtro">
                                            <button style="padding-top: 10px" class="col-12" role="button" v-on:click="FiltrarBoletas(Filtros.fechaI, Filtros.fechaF, Filtros.estado, Filtros.usuario)">
                                                <b class="text-gradient-yellow-orange-black">
                                                    <i class="text-gradient-yellow-orange-black fas fa-filter"></i> 
                                                    Aplicar Filtro
                                                </b>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                                <div class="row textoBlanco" style="padding-top: 25px;">
                                    <div class="col-11" style="color: white;"><hr /></div>
                                </div>
                                <div class="row justify-content-center">
                                    <li class="col-8 textoBlanco botonEncuestas">
                                        <router-link role="button" :to="{ name: 'Inicio' }" class="textoBlanco textoEncuestas">Proyectos&nbsp;&nbsp;<i class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                                    </li>
                                </div>
                                <br />
                                <div class="row justify-content-center">
                                    <li class="col-8 textoBlanco botonEncuestas">
                                        <router-link role="button" :to="{ name: 'Encuestas' }" class="textoBlanco textoEncuestas">Encuestas&nbsp;&nbsp;<i class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                                    </li>
                                </div>
                                <br />
                                <div class="row justify-content-center">
                                    <li class="col-8 textoBlanco botonEncuestas">
                                        <router-link role="button" :to="{ name: 'Reportes' }" class="textoBlanco textoEncuestas">Reportes&nbsp;&nbsp;<i class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                                    </li>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Menú Lateral /-->

                <div class="w-100 listadoGeneral">

                    <!--Filtros responsive /-->

                    <div class="row justify-content-center filtrosCelularBotones">
                        <div class="col-5"></div>
                        <div class="col-1 filtrosCelularBoton" style="margin-right: 1px;" v-if="!filtroDesplegar" v-on:click="desplegarFiltros()">
                            <a class="text-gradient-yellow-orange-black fas fa-filter"></a>
                        </div>
                        <router-link :to="{ name: 'Encuestas' }" class="col-1 filtrosCelularBoton" v-if="!filtroDesplegar" v-on:click="desplegarFiltros()">
                            <a class="text-gradient-yellow-orange-black fas fa-chart-line"></a>
                        </router-link>
                        <div class="col-5"></div>
                    </div>

                    <div class="filtrosCelular w-100 vld-parent col-12" v-if="filtroDesplegar">
                        <div>
                            <div class="col-12" style="margin-top: 15px;">
                                <div style="text-align: center; font-size: medium;">
                                    <div style="text-align: center;">
                                        <div style="text-align: center;">
                                            <a class="text-white fas fa-calendar-alt"></a>
                                            <label class="text-white p-3 Td">Fecha inicio</label>
                                        </div>
                                        <input type="date" id="fechaInicio" class="diseñoSelect" style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fechaI">
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div style="text-align: center; font-size: medium;">
                                    <div style="text-align: center;">
                                        <div style="text-align: center;">
                                            <a class="text-white fas fa-calendar-alt"></a>
                                            <label class="text-white p-3 Td">Fecha Fin</label>
                                        </div>
                                        <input type="date" id="fechaFin" class="diseñoSelect" style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fechaF">
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div>
                                    <div style="text-align: center; font-size: medium;">
                                        <div style="text-align: center;">
                                            <a class="text-white fas fa-check-square"></a>
                                            <label class="text-white p-3 Td">Estado</label>
                                        </div>
                                        <select class="form-select diseñoSelect" v-model="Filtros.estado" style="min-height: 35px; font-size: medium;">
                                            <option value="">Todos</option>
                                            <!--<option v-bind:value="Estado.gen_EstadoCodigo"
                                                    v-for="Estado in ListaEstados"
                                                    v-bind:key="Estado.gen_EstadoID">
                                                {{Estado.gen_EstadoDescripcion}}
                                            </option>-->
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div>
                                    <div v-if="recuperarUsuTipo() == 'Administrador'" style="text-align: center; font-size: medium;">
                                        <div style="text-align: center;">
                                            <a class="text-white fas fa-user-check"></a>
                                            <label class="text-white p-3 Td">Usuario</label>
                                        </div>
                                        <select class="form-select diseñoSelect" v-model="Filtros.usuario" style="min-height: 35px; font-size: medium;">
                                            <option value="">Todos</option>
                                            <!--<option v-bind:value="Usuario.usu_Login"
                                                    v-for="Usuario in ListaUsuarios"
                                                    v-bind:key="Usuario.usu_Login">
                                                {{Usuario.usu_Login}}
                                            </option>-->
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="col-12">
                                <div class="col-12">
                                    <div class="col-12 filtro" style="font-size: medium;">
                                        <button style="padding-top: 10px" class="col-12" role="button" v-on:click="FiltrarBoletas(Filtros.fechaI, Filtros.fechaF, Filtros.estado, Filtros.usuario)">
                                            <b class="text-gradient-yellow-orange-black">
                                                <i class="text-gradient-yellow-orange-black fas fa-filter"></i> 
                                                Aplicar Filtro
                                            </b>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div style="text-align: center; font-size: large; padding-top: 25px; cursor: pointer;" v-if="filtroDesplegar" v-on:click="desplegarFiltros()">
                            <a class="text-gradient-yellow-orange-black fas fa-angle-up"></a>
                        </div>

                        </div>

                    <div class="w-100 vld-parent col-12" style="min-height: 85vh;">

                        <!--Lista de Sprints /-->

                        <div class="row">
                            <div class="col-md-12" style="padding:15px;">
                                <div class="card" style="border: none;" ref="cuadroLoader">
                                    <div class="encabezado">
                                        <ul style="text-align: left;">
                                            <router-link class="li agregarBlt" role="button" :to="{ name: 'Inicio' }"><span class="fas fa-arrow-left"></span></router-link>
                                        </ul>
                                        <div style="text-align: center; padding-top: 10px; cursor: default;">
                                            <h4>Listado de Sprints</h4>
                                        </div>
                                        <ul style="text-align: right;">
                                            <a class="li agregarBlt agregarResponsive" role="button" data-bs-toggle="modal" data-bs-target="#staticBackdrop"><span class="fas fa-plus"></span> Crear Sprint</a>
                                            <a class="li agregarBlt agregarResponsivePlus" role="button" data-bs-toggle="modal" data-bs-target="#staticBackdrop"><span class="fas fa-plus"></span></a>
                                        </ul>
                                    </div>
                                    <!--<div class="sinResultadosAct">
                                        <p>No hay sprints para mostrar</p>
                                    </div>-->
                                    <div class="contenidoTabla">
                                        <table class="table table-stryped" style="text-align: center;">
                                            <thead>
                                                <tr>
                                                    <th class="col-1" style="min-width: 75px;"># Sprint</th>
                                                    <th class="col-4" style="min-width: 150px;">Nombre</th>
                                                    <th class="col-2" style="min-width: 125px;">Fecha inicio</th>
                                                    <th class="col-2" style="min-width: 125px;">Fecha finalización</th>
                                                    <th class="col-1" style="min-width: 125px;">Estado</th>
                                                    <th class="col-2" style="min-width: 125px;">Opciones</th>
                                                </tr>
                                            </thead>
                                            <tbody style="font-size: large;">
                                                <tr>
                                                    <td @click="verTareas" class="claseTD">1</td>
                                                    <td @click="verTareas" class="claseTD">Procormi</td>
                                                    <td @click="verTareas" class="claseTD">01/05/2023</td>
                                                    <td @click="verTareas" class="claseTD">16/05/2023</td>
                                                    <td @click="verTareas" class="claseTD">En proceso</td>
                                                    <td class="text-white">
                                                        <button class="btn btn-primary" role="button" @click="verTareas">
                                                            <span class="fas fa-eye" b-tooltip.hover title="Ver Sprint"></span>
                                                        </button>
                                                        <button style="margin-left: 5px;" type="button" class="btn btn-success" v-on:click="EditarSprint(1)">
                                                            <span class="fas fa-pen" b-tooltip.hover title="Editar Sprint"></span>
                                                        </button>
                                                        <button type="button" class="btn btn-danger" style="margin-left: 5px;" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                                            <span class="fas fa-trash" b-tooltip.hover title="Eliminar Sprint"></span>
                                                        </button>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <nav aria-label="Page navigation example" style="position: absolute; bottom: 0px; margin-left: 15px;">
                            <ul class="pagination">
                                <li class="page-item"><a class="page-link" href="#">Anterior</a></li>
                                <li class="page-item"><a class="page-link" href="#">1</a></li>
                                <li class="page-item"><a class="page-link" href="#">2</a></li>
                                <li class="page-item"><a class="page-link" href="#">3</a></li>
                                <li class="page-item"><a class="page-link" href="#">Siguiente</a></li>
                            </ul>
                        </nav>

                        <!--Lista de proyectos /-->

                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Cookies from 'js-cookie';
import HeaderPrincipal from '@/components/HeaderPrincipal.vue'
//import AdminApi from '@/Api/Api';

export default {

    components: {
        HeaderPrincipal//, MenuLateral
    },

    data() {
        return {
            filtroDesplegar: false,

            Filtros: {
            fechaI: "",
            fechaF: "",
            estado: "",
            usuario: "",
            },

        }
    },

    methods: {

        EditarSprint: function(SprintID) {
            this.$router.push({
                name: "EditarSprint",
                params: {
                    id: SprintID,
                }
            })
        },

        verTareas: function() {
            this.$router.push({
                name: "Tareas"
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

.nav > li {
    float: left;
}

.nav li a {
    background-color: #262b35;
    color: #fff;
    text-decoration: none;
    padding: 10px 12px;
    display: block;
}

    .nav li a:hover {
        color: #808080;
        background-color: #262b35;
    }

.nav li ul {
    display: none;
    position: absolute;
    min-width: 140px;
}

.nav li:hover > ul {
    display: block;
}

.nav li ul li {
    position: relative;
}

.nav li ul li ul {
    right: -140px;
    top: 0px;
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
    max-width: 1800px;;
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
}

.botones{
    min-height: 40px;
    min-width: 150px;
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
    background-color: #114677;
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

.adjuntosJ {
    max-height: 240px;
    overflow-y: scroll;
    margin-bottom: 12px;
    margin-right: 1px;
    margin-left: 5px;
}

</style>