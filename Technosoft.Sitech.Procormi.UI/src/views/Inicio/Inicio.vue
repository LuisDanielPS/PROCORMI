<template>
    <div class="vistaPrincipal">
        <!--<HeaderPrincipal :cuadroLoaderPrincipal="$refs.cuadroLoader" />-->
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">

                <!--Modal Ver Proyecto-->

                <div class="modal fade" id="staticBackdrop">
                    <div class="modal-dialog modal-dialog-scrollable modal-xl">
                        <div class="modal-content contenidoModal">
                            <div class="modal-header encabezadoModal">
                                <div class="col-12">
                                    <div class="row" style="text-align: right;">
                                        <div class="col-md-1 col-xs-1">
                                            <p> </p>
                                        </div>
                                        <div class="col-md-10 col-xs-10">
                                            <h3 style="color: white; text-align: center;">Información del Proyecto</h3>
                                        </div>
                                        <div class="col-md-1 col-xs-1">
                                            <button
                                                style="border: none; background-color: transparent; min-height: 15px; min-width: 25px; font-size: 30px;"
                                                type="button" data-bs-dismiss="modal">&times;
                                            </button>
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
                                            <h1 style="text-align:center"><strong>{{ this.ViewProject.Project_Name
                                            }}</strong>
                                            </h1>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col-12" style="text-align: right;">
                                                <p style="text-align: right;">Fecha: <b>{{ this.ViewProject.Creation_Date }}
                                                    </b></p>
                                            </div>
                                        </div>
                                    </div>
                                    <hr>
                                    <br />
                                    <div class="col-md-12 col-xs-12" style="min-height: 350px; max-height: 400px">
                                        <div class="row">
                                            <div class="col-12">
                                                <h4 class="modal-title" style="text-align: center">
                                                    <strong>Descripción</strong>
                                                </h4>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="col-md-12 col-xs-12">
                                                    <div style="text-align: center;">
                                                        <div style="text-align: center;"
                                                            v-html="this.ViewProject.Description_Project"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br>

                                        <div class="row justify-content-center" style="position: relative;">

                                        </div>

                                        <br />
                                    </div>

                                </div>
                            </div>
                            <div class="modal-footer row justify-content-center">
                                <button @click="loadFileList(this.ViewProject.Id_project)" type="button"
                                    class="btn btn-primary col-5" style="text-align: center;">Descargar archivos
                                    adjuntos</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal Ver Proyecto-->

                <!--Modal completar Sprint-->

                <div class="modal fade" id="completarProyecto" tabindex="-1" aria-labelledby="completarProyecto"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="completarSprint">Completar Proyecto</h1>
                                <button @click="cerrarModalCompletar()" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea completar el proyecto? Para confirmar, primero valide su
                                        contraseña.</p>
                                </div>
                                <div>
                                    <label><strong>(Nota: <u>No se podrá volver a activar el proyecto una vez
                                                completado</u>)</strong></label>
                                    <br />
                                    <div class="row" style="margin-top: 15px;">
                                        <input v-model="verifyPassword" class="col-10"
                                            style="margin-left: 10px; border-radius: 5px;" type="password" required
                                            placeholder="Contraseña" maxlength="20">
                                        <button @click="getPasswordVerifyCompleteRow()" type="button"
                                            class="btn btn-success col-1" style="margin-left: 5px;"><span
                                                class="fas fa-check"></span></button>
                                        <p ref="error2" style="visibility: hidden;color: red;"></p>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" @click="cerrarModalCompletar()"
                                    data-bs-dismiss="modal">Cancelar</button>
                                <button class="btn btn-success" @click="CompleteStatusProject()"
                                    :disabled="!isButtonEnabled">Aceptar</button>

                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal completar Sprint-->



                <!--Modal eliminar Proyecto-->

                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar Proyecto</h1>
                                <button @click="cerrarModalCompletar()" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea eliminar el proyecto? Para confirmar, primero valide su
                                        contraseña.</p>

                                    <label><strong>(Nota: <u>No se podrá recuperar el proyecto una vez
                                                eliminado</u>)</strong></label>
                                </div>
                                <div>

                                    <div class="row" style="margin-top: 15px;">
                                        <input type="password" v-model="verifyPassword" class="col-10"
                                            style="margin-left: 10px; border-radius: 5px;" required
                                            placeholder="Contraseña">
                                        <button @click="getPasswordVerifyDeleteRow()" type="button"
                                            class="btn btn-success col-1" style="margin-left: 5px;"><span
                                                class="fas fa-check"></span></button>
                                        <p ref="error" style="visibility: hidden;color: red;"></p>

                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" @click="cerrarModalCompletar()"
                                    data-bs-dismiss="modal">Cancelar</button>
                                <button :disabled="!isButtonEnabled" @click="deleteRowList()"
                                    class="btn btn-success">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal eliminar Proyecto-->

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

                        <!--Lista de proyectos /-->

                        <div class="row" style="padding:15px; min-height: 95vh; padding-right: 45px; position: relative;">
                            <div class="col-12 estiloTabla tableHeight" style="margin-bottom: 10px;">
                                <div class="card" style="border: none;" ref="cuadroLoader">

                                    <div class="encabezado">
                                        <div style="text-align: left;">
                                            <div>
                                            </div>
                                        </div>
                                        <div style="text-align: center; padding-top: 10px; cursor: default;">
                                            <h4>Listado de Proyectos</h4>
                                        </div>
                                        <ul style="text-align: right;">
                                            <router-link v-show="showElement" class="li agregarBlt agregarResponsive"
                                                role="button" :to="{ name: 'CrearProyecto' }"><span
                                                    class="fas fa-plus"></span> Crear
                                                Proyecto</router-link>
                                            <router-link v-show="showElement" class="li agregarBlt agregarResponsivePlus"
                                                role="button" :to="{ name: 'CrearProyecto' }"><span
                                                    class="fas fa-plus"></span></router-link>
                                        </ul>
                                    </div>

                                    <div class="row">
                                        <div class="col-3" style="min-width: 105px;">
                                            <div>
                                                <a class="text-black fas fa-calendar-alt"></a>
                                                <label class="text-black p-3 Td">Fecha</label>
                                            </div>
                                            <input type="date" id="fechaInicio" class="diseñoSelectLateral"
                                                style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fechaI">
                                        </div>

                                        <div class="col-3" style="min-width: 105px;">
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

                                        <div class="col-5" style="min-width: 95px;">
                                            <div>
                                                <a class="text-black fas fa-pen-square" style="text-decoration: none;"></a>
                                                <label class="text-black p-3 Td">Palabra</label>
                                            </div>
                                            <div>
                                                <input autocomplete="off" maxlength="70" class="diseñoSelectLateral"
                                                    type="search" id="pClaveInput" placeholder="Buscar"
                                                    v-model="Filtros.palabra"
                                                    @keyup="aplyFilter(Filtros.fechaI, Filtros.estado, Filtros.palabra)">
                                            </div>
                                        </div>

                                        <div class="col-1">
                                            <div>
                                                <label class="text-white p-3 Td">.</label>
                                            </div>
                                            <div>
                                                <button type="button" class="btn btn-success"
                                                    @click="aplyFilter(Filtros.fechaI, Filtros.estado, Filtros.palabra)"><span
                                                        class="fas fa-search"></span></button>
                                            </div>
                                        </div>

                                    </div>

                                    <div v-if="paginateData.length == 0" class="sinResultadosAct">
                                        <p>No hay proyectos para mostrar</p>
                                    </div>

                                    <div v-if="paginateData.length > 0" class="contenidoTabla">
                                        <table class="table table-stryped" style="text-align: center;">
                                            <thead>
                                                <tr>
                                                    <th class="col-1" style="min-width: 75px;"># Proyecto</th>
                                                    <th class="col-4" style="min-width: 200px;">Nombre</th>
                                                    <th class="col-3" style="min-width: 125px;">Fecha Creacion</th>
                                                    <th class="col-2" style="min-width: 125px;">Estado</th>
                                                    <th class="col-2" style="min-width: 200px;">Opciones</th>
                                                </tr>
                                            </thead>
                                            <tbody style="font-size: large;">
                                                <tr v-for="proyecto in paginateData" :key="proyecto.Id_project"  class="claseTD">
                                                    <td @click="verSprints(proyecto.Id_project)">{{
                                                        proyecto.Id_project }}</td>
                                                    <td @click="verSprints(proyecto.Id_project)">{{
                                                        proyecto.Project_Name }}</td>
                                                    <td @click="verSprints(proyecto.Id_project)">{{
                                                        $filters.FormatearFecha(proyecto.Creation_Date) }}</td>
                                                    <td @click="verSprints(proyecto.Id_project)">{{
                                                        proyecto.Id_State == 1 ? "Activo" : (proyecto.Id_State == 5 ?
                                                            "Finalizado" : "Inactivo") }}</td>
                                                    <td class="text-white">
                                                        <button b-tooltip.hover title="Ver Proyecto"
                                                            @click="saveViewProjectModal(proyecto)" type="button"
                                                            class="btn btn-primary" data-bs-toggle="modal"
                                                            data-bs-target="#staticBackdrop" role="button">
                                                            <span class="fas fa-eye"></span>
                                                        </button>


                                                        <button b-tooltip.hover title="Completar Proyecto"
                                                            data-bs-target="#completarProyecto" v-show="showElement"
                                                            style="margin-left: 5px;"
                                                            @click="saveIdProjectDelete(proyecto.Id_project)" type="button"
                                                            class="btn btn-success" data-bs-toggle="modal"
                                                            :disabled="proyecto.Id_State == 5">
                                                            <span class="fas fa-check"></span>
                                                        </button>

                                                        <button b-tooltip.hover title="Editar Proyecto" v-show="showElement"
                                                            style="margin-left: 5px;" type="button" class="btn btn-warning"
                                                            @click="EditarProyecto(proyecto.Id_project)">
                                                            <span class="fas fa-pen" style="color: white"></span>
                                                        </button>
                                                        <button b-tooltip.hover title="Eliminar Proyecto"
                                                            v-show="showElement"
                                                            @click="saveIdProjectDelete(proyecto.Id_project)" type="button"
                                                            class="btn btn-danger" style="margin-left: 5px;"
                                                            data-bs-toggle="modal" data-bs-target="#exampleModal">
                                                            <span class="fas fa-trash"></span>
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
import MenuLateral from '@/components/MenuLateral.vue'
import AdminApi from '@/Api/Api';

export default {

    components: {
        HeaderPrincipal, MenuLateral
    },

    data() {
        return {

            isButtonEnabled: false,
            ViewProject: {
                Id_project: this.idProyecto,
                Project_Name: "",
                Description_Project: "",
                Id_State: 0,
                Creation_Date: ""
            },
            confimPassworsDelete: false,
            idProjectDeleteVerify: 0,
            verifyPassword: "",
            showElement: true,
            proyectos: [],
            esConocormi: false,
            esActicormi: false,
            esIncormi: false,
            filtroDesplegar: false,

            Filtros: {
                palabra: "",
                fechaI: "",
                estado: "",
            },

            pageElements: 10,
            actualPage: 1,
            pageNumeration: [],
            paginate: true,
            paginateData: [],
            FileList: [],

            ActionEN: {
                Action_Description: "",
                Action_User: ""
            },
        }
    },

    props: ['show'],

    methods: {

        EditarProyecto: function (ProyectoID) {
            this.$router.push({
                name: "CrearProyectoEdit",
                params: {
                    id: ProyectoID,
                }
            })
        },

        verSprints: function (idProyect) {
            localStorage.setItem("currentProjectId", idProyect)
            this.$router.push({
                name: "Sprints"
            })
        },

        desplegarFiltros: function () {
            this.filtroDesplegar = !this.filtroDesplegar;
        },

        cerrarFiltros: function () {
            this.filtroDesplegar = false;
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

        QuitarHTML(html) {
            var temporal = document.createElement('div')
            temporal.innerHTML = html
            return temporal.textContent || temporal.innerText || ""
        },

        getProyectosDesdeAPI: async function () {
            this.actualPage = 1
            let login = this.recuperarUsuLog()
            let usutipo = this.recuperarUsuTipo()
            try {
                if (this.proyectos.length == 0) {
                    if (usutipo === "Operador") {
                        /*const response = await AdminApi.GetProjectsAllOperator(login);
                        const Projectlist = response.data.obj;
                        this.proyectos = Projectlist;*/

                        await AdminApi.GetProjectsAllOperator(login)
                            .then(async response => {
                                if (response.data != null) {
                                    response.data.obj.forEach(element => {
                                        this.proyectos.push({
                                            Id_project: element.Id_project,
                                            Project_Name: element.Project_Name,
                                            Description_Project: element.Description_Project,
                                            Id_State: element.Id_State,
                                            Creation_Date: element.Creation_Date,
                                        })
                                    })
                                }
                            }
                            )

                        this.showElement = !this.showElement;
                    } else {
                        await AdminApi.GetAllProject()
                            .then(async response => {
                                if (response.data != null) {
                                    response.data.obj.forEach(element => {
                                        this.proyectos.push({
                                            Id_project: element.Id_project,
                                            Project_Name: element.Project_Name,
                                            Description_Project: element.Description_Project,
                                            Id_State: element.Id_State,
                                            Creation_Date: element.Creation_Date,
                                        })
                                    })
                                }
                            }
                            )
                    }


                    this.paginateData = [];

                    if (this.proyectos.length < this.pageElements) {
                        for (let index = 0; index < this.proyectos.length; index++) {
                            this.paginateData.push(this.proyectos[index]);
                        }
                    } else {
                        for (let index = 0; index < this.pageElements; index++) {
                            this.paginateData.push(this.proyectos[index]);
                        }
                    }
                } else {
                    this.paginateData = [];
                    if (this.proyectos.length < this.pageElements) {
                        for (let index = 0; index < this.proyectos.length; index++) {
                            this.paginateData.push(this.proyectos[index]);
                        }
                    } else {
                        for (let index = 0; index < this.pageElements; index++) {
                            this.paginateData.push(this.proyectos[index]);
                        }
                    }
                }
            } catch (error) {
                console.error('Error al cargar los proyectos desde la API:', error);
            }

        },

        aplyFilter: async function (date, state, word) {
            let login = this.recuperarUsuLog()
            let usutipo = this.recuperarUsuTipo()
            if (usutipo === "Operador") {
                const response = await AdminApi.GetProjectsAllOperator(login);
                const Projectlist = response.data.obj;
                this.proyectos = Projectlist;
            }
            else {
                const response = await AdminApi.GetAllProject();
                const Projectlist = response.data.obj;
                this.proyectos = Projectlist;
            }

            const filteredProjects = [];
            let success = false;

            for (const project of this.proyectos) {
                const matchesDate = (!date || project.Creation_Date.includes(date));
                const matchesState = (!state || project.Id_State.toString() === state);
                const matchesWord = (!word || project.Project_Name.toLowerCase().includes(word.toLowerCase()) || project.Description_Project.toLowerCase().includes(word.toLowerCase()));

                if (matchesDate && matchesState && matchesWord) {
                    filteredProjects.push(project);
                    success = true;
                }
            }

            if ((!success && (date || state || word))) {
                this.paginateData = []
                this.paginate = false
                this.Filtros.fechaI = "";
                return
            }

            this.proyectos = filteredProjects;
            await this.getProyectosDesdeAPI();
            await this.cutPages();
            this.actualPage = 1;
            this.Filtros.fechaI = "";
        },

        totalPages: function () {
            return Math.ceil(this.proyectos.length / this.pageElements)
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
                let total = this.proyectos.length;
                if (end < total) {
                    for (let index = ini; index < end; index++) {
                        this.paginateData.push(this.proyectos[index]);
                    }
                } else {
                    for (let index = ini; index < total; index++) {
                        this.paginateData.push(this.proyectos[index]);
                    }
                }
                await this.cutPages();
            }
        },

        goBack: async function () {
            if (this.actualPage > 1) {
                this.paginateData = []
                let paginaAnt = this.actualPage - 1
                this.actualPage = paginaAnt
                let ini = (paginaAnt * this.pageElements) - this.pageElements;
                let end = (paginaAnt * this.pageElements);
                let total = this.proyectos.length;
                if (end < total) {
                    for (let index = ini; index < end; index++) {
                        this.paginateData.push(this.proyectos[index]);
                    }
                } else {
                    for (let index = ini; index < total; index++) {
                        this.paginateData.push(this.proyectos[index]);
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
                let total = this.proyectos.length;
                if (end < total) {
                    for (let index = ini; index < end; index++) {
                        this.paginateData.push(this.proyectos[index]);
                    }
                } else {
                    for (let index = ini; index < total; index++) {
                        this.paginateData.push(this.proyectos[index]);
                    }
                }
                await this.cutPages();
            }
        },

        cutPages: async function () {
            let pages = []
            let numberOfPages = Math.ceil(this.proyectos.length / this.pageElements)
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
            let quantity = this.proyectos.length
            if (quantity < 11) {
                this.paginate = false
            } else {
                this.paginate = true
            }
        },

        getPasswordVerifyDeleteRow: async function () {
            let login = this.recuperarUsuLog()
            if (this.verifyPassword.trim() === "") {
                const error = this.$refs.error;
                error.textContent = "Debes de rellenar el campo";
                error.style.visibility = "visible";
            }
            else {
                try {
                    const response = await AdminApi.GetPasswordVerifyDeleteRow(login, this.verifyPassword);
                    const mensage = response.data.ok;

                    if (mensage == true) {

                        this.confimPassworsDelete = true
                        this.$swal({ icon: 'success', text: 'Se verifico correctamente la contraseña' });
                        this.isButtonEnabled = true;
                        const error = this.$refs.error;
                        error.style.visibility = "hidden";
                    }
                    else if (mensage == false) {
                        const error = this.$refs.error;
                        error.textContent = "La contraseña es incorrecta";
                        error.style.visibility = "visible";

                    }


                } catch (error) {
                    console.error('Error al cargar los proyectos desde la API:', error);
                }
            }

        }
        ,

        getPasswordVerifyCompleteRow: async function () {
            let login = this.recuperarUsuLog()
            if (this.verifyPassword.trim() === "") {
                const error = this.$refs.error2;
                error.textContent = "Debes de rellenar el campo";
                error.style.visibility = "visible";
            }
            else {
                try {
                    const response = await AdminApi.GetPasswordVerifyDeleteRow(login, this.verifyPassword);
                    const mensage = response.data.ok;

                    if (mensage == true) {

                        this.confimPassworsDelete = true
                        this.$swal({ icon: 'success', text: 'Se verifico correctamente la contraseña' });
                        this.isButtonEnabled = true;
                        const error = this.$refs.error2;
                        error.style.visibility = "hidden";
                    }
                    else if (mensage == false) {
                        const error = this.$refs.error2;
                        error.textContent = "La contraseña es incorrecta";
                        error.style.visibility = "visible";

                    }


                } catch (error) {
                    console.error('Error al cargar los proyectos desde la API:', error);
                }
            }

        },
        cerrarModalCompletar: async function () {

            this.verifyPassword="";
            const error = this.$refs.error;
            error.textContent = "";
            error.style.visibility = "hidden";

            const error2 = this.$refs.error2;
            error2.textContent = "";
            error2.style.visibility = "hidden";


        }

        ,
        deleteRowList: async function () {

            try {

                if (this.confimPassworsDelete) {
                    const response = await AdminApi.PutDisableStatus(this.idProjectDeleteVerify);
                    const mensage = response.data.ok;
                    if (mensage) {
                        this.ActionEN.Action_Description = "Eliminó el proyecto #" + this.idProjectDeleteVerify
                        this.ActionEN.Action_User = this.recuperarUsuLog();
                        await AdminApi.PostNewAction(this.ActionEN)
                    }
                    location.reload()

                }
            

            } catch (error) {
                console.error('Error al cargar los proyectos desde la API:', error);
            }

        }
        ,
        CompleteStatusProject: async function () {

            try {

                if (this.confimPassworsDelete) {
                    const response = await AdminApi.PutCompleteStatus(this.idProjectDeleteVerify);
                    const mensage = response.data.ok;
                    if (mensage) {
                        this.ActionEN.Action_Description = "Finalizó el proyecto #" + this.idProjectDeleteVerify
                        this.ActionEN.Action_User = this.recuperarUsuLog();
                        await AdminApi.PostNewAction(this.ActionEN)
                    }
                    location.reload()

                }


            } catch (error) {
                console.error('Error al cargar los proyectos desde la API:', error);
            }

        }
        ,
        saveIdProjectDelete: function (idProject) {
            this.idProjectDeleteVerify = idProject

        },

        saveViewProjectModal: function (project) {
            this.ViewProject = project
            this.showModal = true
        }
        ,

        loadFileList: async function (idProject) {



            const response = await AdminApi.GetFileListProject(idProject);
            const fileListIndex = response.data.obj;

            if (fileListIndex && fileListIndex.length > 0) {

                for (const item of fileListIndex) {

                    try {

                        const response = await AdminApi.GetDownloadFile(item.File_Name)
                        const url = window.URL.createObjectURL(new Blob([response.data]));
                        const link = document.createElement('a');
                        link.href = url;
                        link.setAttribute('download', item.File_Name);
                        document.body.appendChild(link);
                        link.click();
                    }
                    catch (error) {

                        this.$swal({ icon: 'info', text: 'No se encontro archivos relacionados con este proyecto' });
                    }
                }
            } else {
                this.$swal({ icon: 'info', text: 'No se encontro archivos relacionados con este proyecto' });
            }


        }
        ,

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
        await this.getProyectosDesdeAPI();
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
    padding-left: 10px;
    padding-right: 10px;
    padding-bottom: 20px;
    background-color: rgba(10, 58, 102, 1);
    text-align: center;
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
    margin-top: 25px;
    max-width: 2100px;
    overflow-x: auto;
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

.botonRouter {
    min-width: 12.4rem;
    background-color: #114677;
    min-height: 35px;
    border-radius: 5px;
    padding-top: 20px;
    list-style: none;
}

.botonRouter:hover {
    min-width: 12.4rem;
    background-color: #15518a;
    min-height: 35px;
    border-radius: 5px;
    padding-top: 20px;
    list-style: none;
}

.adjuntosJ {
    max-height: 240px;
    overflow-y: scroll;
    margin-bottom: 12px;
    margin-right: 1px;
    margin-left: 5px;
}
</style>