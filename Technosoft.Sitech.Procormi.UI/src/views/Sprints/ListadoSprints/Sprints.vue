<template>
    <div class="vistaPrincipal">
        <!--<HeaderPrincipal :cuadroLoaderPrincipal="$refs.cuadroLoader" />-->
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">

                <!--Modal Ver Sprint-->

                <div class="modal fade" id="verSprint" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
                    aria-labelledby="verSprint" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-scrollable modal-xl">
                        <div class="modal-content bg-gradient-gray">
                            <div class="modal-header">
                                <div class="col-12">
                                    <div class="row" style="text-align: right;">
                                        <div class="col-md-12 col-xs-12">
                                            <button
                                                style="border: none; background-color: transparent; min-height: 15px; min-width: 25px; font-size: 30px;"
                                                type="button" data-bs-dismiss="modal">&times;</button>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="modal-body">
                                <div class="col-md-12 col-xs-12" style="min-height: 350px; max-height: 400px">
                                    <div>
                                        <div class="col-12">
                                            <h1 style="text-align:center"><strong>{{ currentSprint ?
                                                currentSprint.Sprint_Name : '' }}</strong></h1>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="col-md-12 col-xs-12" style="min-height: 350px; max-height: 400px">
                                        <div class="row">
                                            <div class="col-12">
                                                <h4 class="modal-title" style="text-align: left">
                                                    <strong>{{ 'Fecha de Inicio: ' + (currentSprint ?
                                                        formatoFecha(currentSprint.Start_Date) : '') }}</strong>
                                                </h4>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12">
                                                <h4 class="modal-title" style="text-align: left">
                                                    <strong>{{ 'Fecha de Finalización: ' + (currentSprint ?
                                                        formatoFecha(currentSprint.End_Date) : '') }}</strong>
                                                </h4>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row justify-content-center" style="position: relative;">
                                        </div>
                                        <br />
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal Ver Sprint-->

                <!--Modal crear Sprint-->

                <div class="modal fade" id="staticBackdrop" tabindex="-1" aria-labelledby="exampleModalLabel"
                    aria-hidden="true" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Crear Sprint</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Nombre<span style="color: red;"> *</span></label>
                                    <br/>
                                    <div style="margin-top: 15px;">
                                        <input v-model.trim="sprint.Sprint_Name" ref="inputSprintName" maxlength="45"
                                            required style="border-radius: 5px;" type="text" placeholder="Nombre">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Fecha de Inicio<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="sprint.Start_Date" ref="inputStartDate" required
                                            style="border-radius: 5px;" type="date">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Fecha de Finalización<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="sprint.End_Date" ref="inputEndDate" required
                                            style="border-radius: 5px;" type="date">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Usario asignado<span style="color: red;"> *</span></label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select v-model="sprint.User_Login" ref="inputUserLogin" required name="usuarios"
                                            id="usuarios" class="form-select text-black inputsGeneral"
                                            style="min-height: 48px;">
                                            <option :value="null">Seleccione una opción</option>
                                            <option v-for="item in listUsers" :key="item.usu_Login" :value="item.usu_Login">
                                                {{ item.usu_Nombre }}</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal"
                                    @click="limpiarContenido()">Cancelar</button>
                                <button @click="createSprint" type="button" ref="inputDate" class="btn btn-success"
                                    data-bs-dismiss="modal">Guardar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal crear Sprint-->

                <!--Modal completar Sprint-->

                <div class="modal fade" id="completarSprint" tabindex="-1" aria-labelledby="completarSprint"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="completarSprint">Completar Sprint</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea completar el sprint? Para confirmar, primero valide su contraseña.</p>
                                </div>
                                <div>
                                    <label><strong>(Nota: <u>No se podrá recuperar el sprint una vez completado</u>)</strong></label>
                                    <br/>
                                    <div class="row" style="margin-top: 15px;">
                                        <input v-model="verifyPassword" class="col-10"
                                            style="margin-left: 10px; border-radius: 5px;" type="password" required                                        
                                            placeholder="Contraseña" maxlength="20">
                                        <button @click="getPasswordVerifyDeleteRow()" type="button"
                                            class="btn btn-success col-1" style="margin-left: 5px;"><span
                                                class="fas fa-check"></span></button>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal"
                                    @click="limpiarContenido()">Cancelar</button>
                                <button @click="completeRowList()" class="btn btn-success"
                                    :disabled="!isButtonEnabled">Aceptar</button>

                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal completar Sprint-->

                <!--Modal editar Sprint-->

                <div class="modal fade" id="editarSprint" tabindex="-1" aria-labelledby="editarSprint" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Editar Sprint</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Nombre<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model.trim="SprintNameEdit" @input="handleChanges" ref="EditarSprintName" maxlength="45" required
                                            style="border-radius: 5px;" type="text" placeholder="Nombre">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Fecha de Inicio<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="SprintStartDateEdit" @input="handleChanges" ref="EditarStartDate" required
                                            style="border-radius: 5px;" type="date">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Fecha de Finalización<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="SprintEndDateEdit" @input="handleChanges" ref="EditarEndDate" required
                                            style="border-radius: 5px;" type="date">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Usario asignado<span style="color: red;"> *</span></label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select v-model="SprintUsuLoginEdit" @input="handleChanges" ref="EditarUserLogin" required name="usuarios"
                                            id="usuarios" class="form-select text-black inputsGeneral"
                                            style="min-height: 48px;">
                                            <option :value="null">Seleccione una opción</option>
                                            <option v-for="item in listUsers" :key="item.usu_Login" :value="item.usu_Login">
                                                {{ item.usu_Nombre }}</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal" @click="limpiarContenido()">Cancelar</button>
                                <button @click="editSprint" type="button" class="btn btn-success" data-bs-dismiss="modal"
                                    ref="editDate">Guardar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal editar Sprint-->

                <!--Modal eliminar Sprint-->

                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar Sprint</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea eliminar el sprint? Para confirmar, primero valide su contraseña.</p>
                                </div>
                                <div>
                                    <label><strong>(Nota: <u>No se podrá recuperar el sprint una vez eliminado</u>)</strong></label>
                                    <br/>
                                    <div class="row" style="margin-top: 15px;">
                                        <input v-model="verifyPassword" class="col-10"
                                            style="margin-left: 10px; border-radius: 5px;" type="password" required
                                            placeholder="Contraseña" maxlength="20">
                                        <button @click="getPasswordVerifyDeleteRow()" type="button"
                                            class="btn btn-success col-1" style="margin-left: 5px;"><span
                                                class="fas fa-check"></span></button>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal"
                                    @click="limpiarContenido()">Cancelar</button>
                                <button @click="deleteRowList()" class="btn btn-success"
                                    :disabled="!isButtonEnabled">Aceptar</button>

                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal eliminar Sprint-->

                <!--Menú Lateral /-->

                <MenuLateral />

                <!--Menú Lateral /-->

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
                            <div class="col-8 textoBlanco" style="text-align: center;">
                                <router-link role="button" :to="{ name: 'Inicio' }" class="textoBlanco textoEncuestas"
                                    style="text-decoration: none;" exact-active-class="active-link">Proyectos&nbsp;&nbsp;<i
                                        class="text-white fas fa-project-diagram"
                                        style="cursor: pointer; font-size: 14px;"></i></router-link>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center;">
                                <router-link role="button" :to="{ name: 'Encuestas' }" class="textoBlanco textoEncuestas"
                                    style="text-decoration: none;" exact-active-class="active-link">Encuestas&nbsp;&nbsp;<i
                                        class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center;">
                                <router-link role="button" :to="{ name: 'Reportes' }" class="textoBlanco textoEncuestas"
                                    style="text-decoration: none;" exact-active-class="active-link">Reportes&nbsp;&nbsp;<i
                                        class="text-white far fa-file-alt" style="cursor: pointer;"></i></router-link>
                            </div>
                        </div>

                        <div style="text-align: center; font-size: large; padding-top: 40px; cursor: pointer; margin-left: 20px;"
                            v-if="filtroDesplegar" v-on:click="desplegarFiltros()">
                            <a class="text-white fas fa-angle-up" style="text-decoration: none;"></a>
                        </div>

                    </div>

                    <!--Filtros responsive /-->

                    <div class="w-100 vld-parent col-12" style="min-height: 85vh;">

                        <!--Lista de Sprints /-->

                        <div class="row" style="padding:15px; min-height: 95vh; padding-right: 45px; position: relative;">
                            <div class="col-12 estiloTabla tableHeight" style="padding:15px; margin-bottom: 10px;">
                                <div class="card" style="border: none;" ref="cuadroLoader">
                                    <div class="encabezado">
                                        <ul style="text-align: left;">
                                            <router-link class="li agregarBlt" role="button" :to="{ name: 'Inicio' }"><span
                                                    class="fas fa-arrow-left"></span></router-link>
                                        </ul>
                                        <div style="text-align: center; padding-top: 10px; cursor: default;">
                                            <h4>Listado de Sprints</h4>
                                        </div>
                                        <ul style="text-align: right;">
                                            <a v-if="recuperarUsuTipo() == 'Administrador'"
                                                class="li agregarBlt agregarResponsive" role="button" data-bs-toggle="modal"
                                                data-bs-target="#staticBackdrop"><span class="fas fa-plus"></span> Crear
                                                Sprint</a>
                                            <a v-if="recuperarUsuTipo() == 'Administrador'"
                                                class="li agregarBlt agregarResponsivePlus" role="button"
                                                data-bs-toggle="modal" data-bs-target="#staticBackdrop"><span
                                                    class="fas fa-plus"></span></a>
                                        </ul>
                                    </div>

                                    <div class="row">
                                        <div class="col-3">
                                            <div>
                                                <a class="text-black fas fa-calendar-alt"></a>
                                                <label class="text-black p-3 Td">Fecha inicio</label>
                                            </div>
                                            <input type="date" id="fechaInicio" class="diseñoSelectLateral"
                                                style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fechaI">
                                        </div>

                                        <div class="col-3">
                                            <div>
                                                <a class="text-black fas fa-calendar-alt"></a>
                                                <label class="text-black p-3 Td">Fecha Fin</label>
                                            </div>
                                            <input type="date" id="fechaFin" class="diseñoSelectLateral"
                                                style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fechaF">
                                        </div>

                                        <div class="col-3">
                                            <div>
                                                <a class="text-black fas fa-check-square"
                                                    style="text-decoration: none;"></a>
                                                <label class="text-black p-3 Td">Estado</label>
                                            </div>
                                            <select class="form-select diseñoSelectLateral" v-model="Filtros.estado">
                                                <option value="">Todos</option>
                                                <option value="1">Activo</option>
                                                <option value="5">Finalizado</option>
                                            </select>
                                        </div>

                                        <div v-if="recuperarUsuTipo() == 'Administrador'" class="col-3">
                                            <div>
                                                <a class="text-black fas fa-user"></a>
                                                <label class="text-black p-3 Td">Usuario</label>
                                            </div>
                                            <select class="form-select diseñoSelectLateral" v-model="Filtros.usuario">
                                                <option value="">Todos</option>
                                                <option v-bind:value="Usuario.usu_Login" v-for="Usuario in listUsers"
                                                    v-bind:key="Usuario.usu_Login">
                                                    {{ Usuario.usu_Login }}
                                                </option>
                                            </select>
                                        </div>
                                    </div>

                                    <div class="row" style="margin-top: 20px">
                                        <div class="col-6">
                                            <input autocomplete="off" maxlength="70" class="diseñoSelectLateral"
                                                type="search" id="pClaveInput" placeholder="Buscar"
                                                v-model="Filtros.palabra">
                                        </div>
                                        <div class="col-6">
                                            <button type="button" class="btn btn-success" style="float: left"
                                                @click="aplyFilter(Filtros.fechaI, Filtros.fechaF, Filtros.estado, Filtros.usuario, Filtros.palabra)"><span
                                                    class="fas fa-search"></span></button>
                                        </div>
                                    </div>

                                    <div v-if="paginateData.length == 0" class="sinResultadosAct">
                                        <p>No hay sprints para mostrar</p>
                                    </div>

                                    <div v-if="paginateData.length > 0" class="contenidoTabla">
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
                                                <tr v-for="sprint in paginateData" :key="sprint.Id_Sprint">
                                                    <td @click="verTareas(sprint.Id_Sprint)" class="claseTD">
                                                        {{ sprint.Id_Sprint }}</td>
                                                    <td @click="verTareas(sprint.Id_Sprint)" class="claseTD">
                                                        {{ sprint.Sprint_Name }}</td>
                                                    <td @click="verTareas(sprint.Id_Sprint)" class="claseTD">
                                                        {{ $filters.FormatearFecha(sprint.Start_Date) }}</td>
                                                    <td @click="verTareas(sprint.Id_Sprint)" class="claseTD">
                                                        {{ $filters.FormatearFecha(sprint.End_Date) }}</td>
                                                    <td @click="verTareas(sprint.Id_Sprint)" class="claseTD">
                                                        {{ sprint.Id_Status == 1 ? "Activo" : (sprint.Id_Status == 5 ?
                                                            "Finalizado" : "Inactivo") }}</td>
                                                    <td class="text-white" style="min-width: 130px;">

                                                        <button style="margin-left: 5px;"
                                                            @click="saveIdSprintDelete(sprint.Id_Sprint)" type="button"
                                                            class="btn btn-success" data-bs-toggle="modal"
                                                            data-bs-target="#completarSprint"
                                                            :disabled = "sprint.Id_Status == 5">
                                                            <span class="fas fa-check" b-tooltip.hover
                                                                title="Completar Sprint"></span>
                                                        </button>

                                                        <button v-if="recuperarUsuTipo() == 'Administrador'"
                                                            @click="() => startSprintEditing(sprint)"
                                                            style="margin-left: 5px;" type="button" class="btn btn-warning"
                                                            data-bs-toggle="modal" data-bs-target="#editarSprint"
                                                            :disabled = "sprint.Id_Status == 5">
                                                            <span class="fas fa-pen" style="color:white" b-tooltip.hover
                                                                title="Editar Sprint"></span>
                                                        </button>

                                                        <button v-if="recuperarUsuTipo() == 'Administrador'"
                                                            @click="saveIdSprintDelete(sprint.Id_Sprint)" type="button"
                                                            class="btn btn-danger" style="margin-left: 5px;"
                                                            data-bs-toggle="modal" data-bs-target="#exampleModal"
                                                            :disabled = "sprint.Id_Status == 5">
                                                            <span class="fas fa-trash" b-tooltip.hover
                                                                title="Eliminar Sprint"></span>
                                                        </button>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                            <nav v-if="paginate" aria-label="Page navigation example" style="margin-top: 10px;">
                                <ul class="pagination cursorPaginados">
                                    <li class="page-item"><a class="page-link" v-on:click="goBack()">Anterior</a></li>
                                    <li v-for="pagina in pageNumeration" v-bind:key="pagina" class="page-item">
                                        <a class="page-link" v-on:click="changePage(pagina)"
                                            v-bind:class="{ active: (pagina == actualPage) }">{{ pagina }}</a>
                                    </li>
                                    <li class="page-item"><a class="page-link" v-on:click="goNext()">Siguiente</a></li>
                                </ul>
                            </nav>
                        </div>

                        <!--Lista de sprints /-->

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
//import FiltroSuperior from '@/components/FiltroSuperior.vue'
import AdminApi from '@/Api/Api';

export default {

    components: {
        HeaderPrincipal, MenuLateral//, FiltroSuperior
    },

    data() {
        return {

            selectedUser: null,
            UserlistAdd: [],
            listUsers: [],
            sprints: [],
            verifyPassword: false,
            validationMessage: '',
            confimPassworsDelete: false,
            idSprintDeleteVerify: 0,
            filtroDesplegar: false,
            isButtonEnabled: false,
            currentSprint: null,
            hasChanges: false,

            Filtros: {
                fechaI: "",
                fechaF: "",
                estado: "",
                usuario: "",
            },

            pageElements: 10,
            actualPage: 1,
            pageNumeration: [],
            paginate: true,
            paginateData: [],

            sprint: {
                Id_Project: "",
                Sprint_Name: "",
                Start_Date: "",
                End_Date: "",
                Id_Status: "",
                User_Login: "",
            },

            SprintIdEdit: "",
            SprintIdStatusEdit: "",
            SprintNameEdit: "",
            SprintStartDateEdit: "",
            SprintEndDateEdit: "",
            SprintUsuLoginEdit: "",

        }
    },

    methods: {

        async getSprintsDesdeAPI() {
            const idProyect = localStorage.getItem("currentProjectId")
            this.actualPage = 1

            try {
                if (this.sprints.length == 0) {

                    const response = await AdminApi.GetAllSprint(idProyect);
                    const Sprintlist = response.data.obj;
                    this.sprints = Sprintlist;

                    this.paginateData = [];
                    if (this.sprints.length < this.pageElements) {
                        for (let index = 0; index < this.sprints.length; index++) {
                            this.paginateData.push(this.sprints[index]);
                        }
                    } else {
                        for (let index = 0; index < this.pageElements; index++) {
                            this.paginateData.push(this.sprints[index]);
                        }
                    }
                } else {
                    this.paginateData = [];
                    if (this.sprints.length < this.pageElements) {
                        for (let index = 0; index < this.sprints.length; index++) {
                            this.paginateData.push(this.sprints[index]);
                        }
                    } else {
                        for (let index = 0; index < this.pageElements; index++) {
                            this.paginateData.push(this.sprints[index]);
                        }
                    }
                }
            } catch (error) {
                console.error('Error al cargar los sprints desde la API:', error);
            }
        },

        aplyFilter: async function (beginDate, endDate, state, user, word) {
            const idProyect = localStorage.getItem("currentProjectId")
            const response = await AdminApi.GetAllSprint(idProyect);
            const SprintList = response.data.obj;
            this.sprints = SprintList;
            const filteredSprints = [];
            let success = false;

            for (const project of this.sprints) {
                const matchesBeginDate = (!beginDate || project.Start_Date.includes(beginDate));
                const matchesEndDate = (!endDate || project.End_Date.includes(endDate));
                const matchesState = (!state || project.Id_Status.toString() === state);
                const matchesUser = (!user || project.User_Login.toLowerCase().includes(user.toLowerCase()));
                const matchesWord = (!word || project.Sprint_Name.toLowerCase().includes(word.toLowerCase()));

                if (matchesBeginDate && matchesEndDate && matchesState && matchesUser && matchesWord) {
                    filteredSprints.push(project);
                    success = true;
                }
            }

            if ((!success && (beginDate || endDate || state || user || word))) {
                this.paginateData = []
                this.paginate = false
                this.Filtros.fechaI = "";
                this.Filtros.fechaF = "";
                return
            }

            this.sprints = filteredSprints;
            await this.getSprintsDesdeAPI();
            await this.cutPages();
            this.actualPage = 1;
            this.Filtros.fechaI = "";
            this.Filtros.fechaF = "";
        },

        totalPages: function () {
            return Math.ceil(this.sprints.length / this.pageElements)
        },

        changePage: async function (pageNum) {
            if (pageNum != "...") {
                this.paginateData = []
                if (pageNum == undefined) {
                    pageNum = 1
                }
                this.actualPage = pageNum
                let ini = (pageNum * this.pageElements) - this.pageElements;
                let end = (pageNum * this.pageElements);
                let total = this.sprints.length;
                if (end < total) {
                    for (let index = ini; index < end; index++) {
                        this.paginateData.push(this.sprints[index]);
                    }
                } else {
                    for (let index = ini; index < total; index++) {
                        this.paginateData.push(this.sprints[index]);
                    }
                }
                await this.cutPages();
            }
        },

        goBack: async function () {
            if (this.actualPage > 1){
                this.paginateData = []
                let paginaAnt = this.actualPage - 1
                this.actualPage = paginaAnt
                let ini = (paginaAnt * this.pageElements) - this.pageElements;
                let end = (paginaAnt * this.pageElements);
                let total = this.sprints.length;
                if (end < total) {
                    for (let index = ini; index < end; index++) {
                        this.paginateData.push(this.sprints[index]);
                    }
                } else {
                    for (let index = ini; index < total; index++) {
                        this.paginateData.push(this.sprints[index]);
                    }
                }
                await this.cutPages();
            }
        },

        goNext: async function () {
            if (this.actualPage == this.pageNumeration.length) {
                return
            } else {
                this.paginateData = []
                let paginaAnt = this.actualPage + 1
                this.actualPage = paginaAnt
                let ini = (paginaAnt * this.pageElements) - this.pageElements;
                let end = (paginaAnt * this.pageElements);
                let total = this.sprints.length;
                if (end < total) {
                    for (let index = ini; index < end; index++) {
                        this.paginateData.push(this.sprints[index]);
                    }
                } else {
                    for (let index = ini; index < total; index++) {
                        this.paginateData.push(this.sprints[index]);
                    }
                }
                await this.cutPages();
            }
        },

        cutPages: async function () {
            let pages = []
            let numberOfPages = Math.ceil(this.sprints.length / this.pageElements)
            let actualPage = this.actualPage
            let numeration = 2
            let numerationSide = Math.floor(numeration / 2)
            let initialPage = 1
            let finalPage = numberOfPages

            if (numberOfPages > numeration) {

                if (actualPage > numerationSide) {

                    initialPage = actualPage - numerationSide

                    finalPage = actualPage + numerationSide

                } else {

                    initialPage = 1

                    finalPage = actualPage + numerationSide

                    finalPage += (numerationSide - (actualPage - 1))

                }

                if (finalPage > numberOfPages) {

                    finalPage = numberOfPages

                    initialPage = numberOfPages - numeration + 1

                }

            }

            for (let i = initialPage; i <= finalPage; i++) {

                pages.push(i)

            }

            if (actualPage > (numerationSide + 2)) { pages.unshift("...") }

            if (actualPage > (numerationSide + 1)) { pages.unshift(1) }

            if (

                (actualPage < (numberOfPages - numerationSide - 1)) &&

                numberOfPages != finalPage

            ) { pages.push("...") }

            if (

                (actualPage < (numberOfPages - numerationSide)) &&

                numberOfPages != finalPage

            ) { pages.push(numberOfPages) }

            this.pageNumeration = pages

            await this.validatePaginate();

        },

        validatePaginate: function () {
            let quantity = this.sprints.length
            if (quantity < 11) {
                this.paginate = false
            } else {
                this.paginate = true
            }
        },

        loadUserSelect: async function () {
            try {
                const response = await AdminApi.GetALLUsers();
                const userList = response.data.obj;
                this.listUsers = userList;
            } catch (error) {
                console.error('Error al cargar los sprints desde la API:', error);
            }

        }
        ,

        async postSprintToAPI(sprint) {
            try {
                const response = await AdminApi.PostSprint(sprint);
                if (response.data.ok) {
                    this.getSprintsDesdeAPI();
                } else {
                    console.log({ error: 'Error al crear el sprint', response });
                }
            } catch (error) {
                console.error('Error al crear sprint', error);
            }
        },

        async createSprint() {
            const currentProjectId = localStorage.getItem("currentProjectId");
            this.sprint.Id_Project = currentProjectId

            if (this.sprint.Sprint_Name.trim() == "") {
                this.$refs.inputSprintName.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que completar el campo del nombre del sprint',
                })
            }

            if (this.sprint.Start_Date == "") {
                this.$refs.inputStartDate.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que elegir una fecha de inicio',
                })
            }

            if (this.sprint.End_Date == "") {
                this.$refs.inputEndDate.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que elegir una fecha de finalización',
                })
            }

            const startDate = new Date(this.sprint.Start_Date);
            const endDate = new Date(this.sprint.End_Date);

            if (endDate < startDate) {
                this.$refs.inputDate.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'La fecha de finalización no puede ser previa a la de inicio',
                })
            }

            if (this.sprint.User_Login == "" || this.sprint.User_Login == null) {
                this.$refs.inputUserLogin.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que elegir un usuario',
                })
            }

            await AdminApi.PostSprint(this.sprint)
                .then(response => {
                    if (response.data.ok == true) {
                        this.$swal(response.data.msg, '', 'success')
                        this.limpiarContenido()
                        this.getSprintsDesdeAPI()
                    } else {
                        this.$swal(response.data.msg, '', 'error')
                    }
                })

            this.actualPage = 1
            this.sprints = []
            await this.getSprintsDesdeAPI();
            await this.cutPages()

        },

        limpiarContenido: function () {
            this.sprint = {
                Id_Project: "",
                Sprint_Name: "",
                Start_Date: "",
                End_Date: "",
                User_Login: "",
            }
            this.verifyPassword='';
        },

        formatDateToYYYYMMDD(date) {
            const year = date.getFullYear();
            const month = (date.getMonth() + 1).toString().padStart(2, '0');
            const day = date.getDate().toString().padStart(2, '0');
            return `${year}-${month}-${day}`;
        },

        startSprintEditing(sprint) {
            this.selectCurrentSprint(sprint);
            console.log('sprint:', sprint);
            this.SprintIdEdit = sprint.Id_Sprint
            this.SprintNameEdit = sprint.Sprint_Name;
            this.SprintStartDateEdit = this.formatDateToYYYYMMDD(new Date(sprint.Start_Date));
            this.SprintEndDateEdit = this.formatDateToYYYYMMDD(new Date(sprint.End_Date));
            this.SprintIdStatusEdit = sprint.Id_Status;
            this.SprintUsuLoginEdit = sprint.User_Login;
            this.hasChanges = false;
        },

        handleChanges() {
            this.hasChanges = true;
        },

        async editSprint() {

            let modifiedSprint = {
                Sprint_Name: this.SprintNameEdit.trim(),
                Start_Date: this.SprintStartDateEdit,
                End_Date: this.SprintEndDateEdit,
                User_Login: this.SprintUsuLoginEdit,

                Id_Sprint: this.SprintIdEdit,
                Id_Project: localStorage.getItem("currentProjectId"),
                Id_Status: this.SprintIdStatusEdit,

            }

            if (this.SprintNameEdit.trim() == "") {
                this.$refs.EditarSprintName.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que completar el campo del nombre del sprint',
                })
            }

            if (this.SprintStartDateEdit == "") {
                this.$refs.EditarStartDate.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que elegir una fecha de inicio',
                })
            }

            if (this.SprintEndDateEdit == "") {
                this.$refs.EditarEndDate.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que elegir una fecha de finalización',
                })
            }

            const editstartDate = new Date(this.SprintStartDateEdit);
            const editendDate = new Date(this.SprintEndDateEdit);

            if (editendDate < editstartDate) {
                this.$refs.editDate.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'La fecha de finalización no puede ser previa a la de inicio',
                })
            }

            if (this.SprintUsuLoginEdit == "" || this.SprintUsuLoginEdit == null) {
                this.$refs.EditarUserLogin.focus();

                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que elegir un usuario',
                })
            }

            if (!this.hasChanges) {
                return this.$swal.fire({
                    position: 'center',
                    icon: 'warning',
                    title: '¡Advertencia!',
                    text: 'No se realizó ningún cambio',
                });
            }

            try {

                const result = await AdminApi.PutSprint(modifiedSprint);
                if (result.data.ok) {

                    console.log('Respuesta de la API:', result);
                    this.SprintNameEdit = ''
                    this.SprintStartDateEdit = ''
                    this.SprintEndDateEdit = ''
                    this.SprintUsuLoginEdit = ''

                    this.$swal({ icon: 'success', text: 'Se editó correctamente el sprint' });
                    this.getSprintsDesdeAPI();
                    setTimeout(() => {
                        location.reload()
                    }, 1000);
                } else {
                    this.$swal("Hubo un error al editar el sprint");
                }
            } catch (error) {
                this.$swal("Hubo un error al editar el sprint");
            }
        },

        selectCurrentSprint(sprint) {
            this.currentSprint = sprint;
        },

        getPasswordVerifyDeleteRow: async function () {
            let login = this.recuperarUsuLog()
            try {

                const response = await AdminApi.GetPasswordVerifyDeleteRow(login, this.verifyPassword);
                const message = response.data.ok;
                if (message == true) {

                    this.confimPassworsDelete = true
                    this.$swal({ icon: 'success', text: 'Se verifico correctamente la contraseña' });
                    this.isButtonEnabled = true;

                }
                else {
                    this.$swal({ icon: 'warning', text: 'Contraseña Incorrecta' });
                    this.verifyPassword ="";
                }

            } catch (error) {
                console.error({message : 'Error al cargar los proyectos desde la API:', error});
            }

        },

        completeRowList: async function () {

            try {

                if (this.confimPassworsDelete == true) {

                    const response = await AdminApi.PutCompleteSprintStatus(this.idSprintDeleteVerify);
                    const message = response.data.ok;
                    console.log(message)
                    this.$swal({ icon: 'success', text: 'El Sprint se ha completado correctamente' });
                    setTimeout(() => {
                        location.reload()
                    }, 1000);
                    this.isButtonEnabled = false;

                }
                else {
                    this.$swal({ icon: 'warning', text: 'La contraseña no es correcta' });
                }

            } catch (error) {
                this.$swal({ icon: 'error', text: 'Error al completar el Sprint' + error });
            }

        },

        deleteRowList: async function () {

            try {

                if (this.confimPassworsDelete == true) {
                    const response = await AdminApi.PutDisableSprintStatus(this.idSprintDeleteVerify);
                    const message = response.data.ok;
                    console.log(message)
                    this.$swal({ icon: 'success', text: 'El Sprint se ha eliminado correctamente' });
                    setTimeout(() => {
                        location.reload()
                    }, 1000);
                    this.isButtonEnabled = false;

                }
                else {
                    this.$swal({ icon: 'warning', text: 'La contraseña no es correcta' });
                }

            } catch (error) {
                this.$swal({ icon: 'error', text: 'Error al eliminar el Sprint' + error });
            }

        },

        verTareas: function (Id_Sprint) {
            localStorage.setItem("currentSprintId", Id_Sprint);
            this.$router.push({
                name: "Tareas"
            })
        },

        saveIdSprintDelete: function (idSprint) {
            this.idSprintDeleteVerify = idSprint
            this.limpiarContenido();

        },

        saveViewSprintModal: function (sprint) {
            this.ViewSprint = sprint

        },

        desplegarFiltros: function () {
            this.filtroDesplegar = !this.filtroDesplegar;
        },

        cerrarFiltros: function () {
            this.filtroDesplegar = false;
        },

        deshabilitarBoton: function () {
            this.isButtonEnabled = false;
        },

        formatoFecha(fecha) {
            if (!fecha) return ''; // Manejar el caso cuando la fecha es nula o indefinida

            const options = { year: 'numeric', month: 'long', day: 'numeric' };
            return new Date(fecha).toLocaleDateString('es-ES', options);
        },

        seleccionarAplicacion: async function () {
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

    mounted: async function () {
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
        await this.getSprintsDesdeAPI();
        await this.loadUserSelect();
        await this.cutPages();
        await this.$root.validarLoginFooter.call();
    }

}

</script>

<style scoped>
#header {
    margin: auto;
    width: 500px;
    font-family: Arial, Helvetica, sans-serif;
}

ul,
ol {
    list-style: none;
}

.nav>li {
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

.nav li:hover>ul {
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

.diseñoSelectLateral {
    height: 30px;
}

.diseñoSelect {
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
    .posicion1 {
        display: none;
    }
}

@media screen and (max-width: 700px) {

    .responsiveCelular {
        min-height: 500px;
    }

    .menuLateralCelular {
        display: none;
    }
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

.sinResultadosAct {
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

.botones {
    min-height: 40px;
    min-width: 150px;
}

.agregarBlt {
    font-family: sans-serif;
    font-size: 18px;
    text-decoration: none;
    padding-right: 10px;
    position: relative;
    top: -5px;
    color: rgb(0, 0, 0);
}

@media screen and (max-width: 975px) {
    .agregarResponsive {
        display: none;
    }
}

@media screen and (min-width: 975px) {
    .agregarResponsivePlus {
        display: none;
    }
}

@media screen and (min-width: 901px) {
    .linkResponsive {
        display: none;
    }
}

@media screen and (max-width: 610px) {
    .linkResponsiveCelular {
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
}

.vistaPrincipal {
    min-height: 85vh;
}

@media screen and (max-width: 900px) {
    .vistaPrincipal {
        min-height: 98vh;
    }
}

@media screen and (max-width: 400px) {
    .vistaPrincipal {
        min-height: 100vh;
    }
}

.botonEncuestas {
    margin-left: -15px;
    min-width: 12.4rem;
    background-color: #114677;
    min-height: 35px;
    border-radius: 5px;
    padding-top: 20px;
    list-style: none;
}

.textoEncuestas {
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