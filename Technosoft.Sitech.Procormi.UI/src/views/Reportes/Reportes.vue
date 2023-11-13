<template>
    <div class="vistaPrincipal" style="min-height: calc(100vh - 50px);">
        <!--<HeaderPrincipal :cuadroLoaderPrincipal="$refs.cuadroLoader" />-->
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">
                <MenuLateral />


                <div class="modal fade" id="listprojectreport" tabindex="-1" aria-labelledby="exampleModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Generar reporte de proyecto por usuario
                                </h1>
                                <button @click="closeModals()" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="content-icon">

                                    <span class="fas fa-file-excel"></span>

                                </div>

                                <div>
                                    <label>Busque el usuario del que desea generar el reporte</label>
                                    <br />
                                    <div class="row" style="margin-top: 15px;">
                                        <select v-model="elementSelectUsuLogin" required name="usuarios" id="usuarios"
                                            class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option :value="null">Seleccione una opción</option>
                                            <option v-for="item in listUsers" :key="item.usu_Login"
                                                :value="JSON.stringify(item)">{{ item.usu_Nombre }} : {{ item.usu_email }}
                                            </option>
                                        </select>
                                    </div>
                                    <p ref="error" style="visibility: hidden;color: red;"></p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button @click="closeModals()" type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button class="btn btn-success" @click="downloadExcelReportProject()">Generar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal fade" id="listSprintreport" tabindex="-1" aria-labelledby="exampleModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Generar reporte de sprint por usuario
                                </h1>
                                <button @click="closeModals()" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="content-icon">

                                    <span class="fas fa-file-excel"></span>

                                </div>

                                <div>
                                    <label>Busque el usuario del que desea generar el reporte</label>
                                    <br />
                                    <div class="row" style="margin-top: 15px;">
                                        <select v-model="elementSelectUsuLogin" required name="usuarios" id="usuarios"
                                            class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option :value="null">Seleccione una opción</option>
                                            <option v-for="item in listUsers" :key="item.usu_Login"
                                                :value="JSON.stringify(item)">{{ item.usu_Nombre }} : {{ item.usu_email }}
                                            </option>
                                        </select>
                                    </div>
                                    <p ref="error2" style="visibility: hidden;color: red;"></p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button @click="closeModals()" type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button class="btn btn-success" @click="downloadExcelReportSprint()">Generar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal fade" id="listTaskReport" tabindex="-1" aria-labelledby="exampleModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Generar reporte de tareas por usuario
                                </h1>
                                <button @click="closeModals()" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="content-icon">

                                    <span class="fas fa-file-excel"></span>

                                </div>

                                <div>
                                    <label>Busque el usuario del que desea generar el reporte</label>
                                    <br />
                                    <div class="row" style="margin-top: 15px;">
                                        <select v-model="elementSelectUsuLogin" required name="usuarios" id="usuarios"
                                            class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option :value="null">Seleccione una opción</option>
                                            <option v-for="item in listUsers" :key="item.usu_Login"
                                                :value="JSON.stringify(item)">{{ item.usu_Nombre }} : {{ item.usu_email }}
                                            </option>
                                        </select>
                                    </div>
                                    <p ref="error3" style="visibility: hidden;color: red;"></p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button @click="closeModals()" type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button class="btn btn-success" @click="downloadExcelReportTask()">Generar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="listSubTaskReport" tabindex="-1" aria-labelledby="exampleModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Generar reporte de sub tareas por
                                    usuario
                                </h1>
                                <button @click="closeModals()" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="content-icon">

                                    <span class="fas fa-file-excel"></span>

                                </div>

                                <div>
                                    <label>Busque el usuario del que desea generar el reporte</label>
                                    <br />
                                    <div class="row" style="margin-top: 15px;">
                                        <select v-model="elementSelectUsuLogin" required name="usuarios" id="usuarios"
                                            class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option :value="null">Seleccione una opción</option>
                                            <option v-for="item in listUsers" :key="item.usu_Login"
                                                :value="JSON.stringify(item)">{{ item.usu_Nombre }} : {{ item.usu_email }}
                                            </option>
                                        </select>
                                    </div>
                                    <p ref="error4" style="visibility: hidden;color: red;"></p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button @click="closeModals()" type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button @click="downloadExcelReportSubTask()" class="btn btn-success">Generar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal fade" id="listPollReport" tabindex="-1" aria-labelledby="exampleModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Generar reporte de encuesta

                                </h1>
                                <button @click="closeModals()" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="content-icon">

                                    <span class="fas fa-file-excel"></span>

                                </div>

                                <div>
                                    <label>Busque el usuario del que desea generar la encuesta</label>
                                    <br />
                                    <div class="row" style="margin-top: 15px;">
                                        <select v-model="elementSelectPoll" required name="poll" id="poll"
                                            class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option :value="null">Seleccione una opción</option>
                                            <option v-for="item in listPoll" :key="item.Id_Poll"
                                                :value="JSON.stringify(item)">{{ item.Name }}
                                            </option>
                                        </select>
                                    </div>
                                    <p ref="error5" style="visibility: hidden;color: red;"></p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button @click="closeModals()" type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button @click="downloadExcelReportPoll()" class="btn btn-success">Generar</button>
                            </div>
                        </div>
                    </div>
                </div>

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

                        <!--Lista de reportes /-->

                        <div class="row" style="padding:15px; min-height: 95vh; padding-right: 45px;">
                            <div class="col-12 estiloTabla" style="padding:15px;">
                                <div class="card" style="border: none;" ref="cuadroLoader">
                                    <div class="encabezado">
                                        <ul style="text-align: left;">
                                            <router-link class="li agregarBlt" role="button" :to="{ name: 'Inicio' }"><span
                                                    class="fas fa-arrow-left"></span> <span class="linkResponsiveCelular">
                                                    Inicio</span></router-link>
                                        </ul>
                                        <div style="text-align: center; padding-top: 10px; cursor: default;">
                                            <h4>Listado de Reportes</h4>
                                        </div>
                                    </div>
                                    <div class="contenidoTabla">
                                        <table class="table table-striped table-bordered" style="text-align: left;">
                                            <thead>
                                                <tr>
                                                    <th class="col-10" style="min-width: 150px;">Descripción</th>
                                                    <th class="col-2" style="min-width: 125px;">Opciones</th>
                                                </tr>
                                            </thead>
                                            <tbody style="font-size: large;">
                                                <tr>
                                                    <td>Listado de proyectos por usuario</td>
                                                    <td class="text-white">
                                                        <button data-bs-toggle="modal" data-bs-target="#listprojectreport"
                                                            type="button" class="btn btn-primary" style="margin-left: 5px;">
                                                            <span class="fas fa-file-download" b-tooltip.hover
                                                                title="Excel"></span>
                                                        </button>
                                                        <!--<button class="btn btn-success" role="button" @click="verSprints">
                                                            <span class="fas fa-file-excel" b-tooltip.hover title="EXCEL"></span>
                                                        </button>
                                                        <button style="margin-left: 5px;" type="button" class="btn btn-primary">
                                                            <span class="fas fa-file-word" b-tooltip.hover title="WORD"></span>
                                                        </button>
                                                        <button type="button" class="btn btn-danger" style="margin-left: 5px;">
                                                            <span class="fas fa-file-pdf" b-tooltip.hover title="PDF"></span>
                                                        </button>-->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Listado de sprints por usuario</td>
                                                    <td class="text-white">
                                                        <button data-bs-toggle="modal" data-bs-target="#listSprintreport"
                                                            type="button" class="btn btn-primary" style="margin-left: 5px;">
                                                            <span class="fas fa-file-download" b-tooltip.hover
                                                                title="Excel"></span>
                                                        </button>
                                                        <!--<button class="btn btn-success" role="button" @click="verSprints">
                                                            <span class="fas fa-file-excel" b-tooltip.hover title="EXCEL"></span>
                                                        </button>
                                                        <button style="margin-left: 5px;" type="button" class="btn btn-primary">
                                                            <span class="fas fa-file-word" b-tooltip.hover title="WORD"></span>
                                                        </button>
                                                        <button type="button" class="btn btn-danger" style="margin-left: 5px;">
                                                            <span class="fas fa-file-pdf" b-tooltip.hover title="PDF"></span>
                                                        </button>-->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Listado de tareas por usuario</td>
                                                    <td class="text-white">
                                                        <button data-bs-toggle="modal" data-bs-target="#listTaskReport"
                                                            type="button" class="btn btn-primary" style="margin-left: 5px;">
                                                            <span class="fas fa-file-download" b-tooltip.hover
                                                                title="Excel"></span>
                                                        </button>
                                                        <!--<button class="btn btn-success" role="button" @click="verSprints">
                                                            <span class="fas fa-file-excel" b-tooltip.hover title="EXCEL"></span>
                                                        </button>
                                                        <button style="margin-left: 5px;" type="button" class="btn btn-primary">
                                                            <span class="fas fa-file-word" b-tooltip.hover title="WORD"></span>
                                                        </button>
                                                        <button type="button" class="btn btn-danger" style="margin-left: 5px;">
                                                            <span class="fas fa-file-pdf" b-tooltip.hover title="PDF"></span>
                                                        </button>-->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Listado de subtareas por usuario</td>
                                                    <td class="text-white">
                                                        <button data-bs-toggle="modal" data-bs-target="#listSubTaskReport"
                                                            type="button" class="btn btn-primary" style="margin-left: 5px;">
                                                            <span class="fas fa-file-download" b-tooltip.hover
                                                                title="Excel"></span>
                                                        </button>
                                                        <!--<button class="btn btn-success" role="button" @click="verSprints">
                                                            <span class="fas fa-file-excel" b-tooltip.hover title="EXCEL"></span>
                                                        </button>
                                                        <button style="margin-left: 5px;" type="button" class="btn btn-primary">
                                                            <span class="fas fa-file-word" b-tooltip.hover title="WORD"></span>
                                                        </button>
                                                        <button type="button" class="btn btn-danger" style="margin-left: 5px;">
                                                            <span class="fas fa-file-pdf" b-tooltip.hover title="PDF"></span>
                                                        </button>-->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Reporte de encuestas</td>
                                                    <td class="text-white">
                                                        <button data-bs-toggle="modal" data-bs-target="#listPollReport"
                                                            type="button" class="btn btn-primary" style="margin-left: 5px;">
                                                            <span class="fas fa-file-download" b-tooltip.hover
                                                                title="Excel"></span>
                                                        </button>
                                                        <!--<button class="btn btn-success" role="button" @click="verSprints">
                                                            <span class="fas fa-file-excel" b-tooltip.hover title="EXCEL"></span>
                                                        </button>
                                                        <button style="margin-left: 5px;" type="button" class="btn btn-primary">
                                                            <span class="fas fa-file-word" b-tooltip.hover title="WORD"></span>
                                                        </button>
                                                        <button type="button" class="btn btn-danger" style="margin-left: 5px;">
                                                            <span class="fas fa-file-pdf" b-tooltip.hover title="PDF"></span>
                                                        </button>-->
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <!--Lista de reportes /-->

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
import ExcelJS from 'exceljs';

export default {

    components: {
        HeaderPrincipal, MenuLateral
    },

    data() {
        return {
            elementSelectPoll: null,
            elementSelectUsuLogin: null,
            filtroDesplegar: false,
            selectedUser: null,
            listUsers: [],
            listPoll: [],
            dataListProjectUser: [],
            dataListSprintUser: [],
            dataListTaskUser: [],
            dataListSubTaskUser: [],
            dataListPoll: []
        }
    },

    methods: {

        desplegarFiltros: function () {
            this.filtroDesplegar = !this.filtroDesplegar;
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
            let usutipo = this.recuperarUsuTipo()


            if (login == null || (nombre == undefined || nombre == null || nombre == '')) {
                this.$router.push("/");
                this.$swal({ icon: 'warning', text: 'Aún no ha iniciado sesión, por favor verifique' });
            }

            if (usutipo === "Operador") {

                this.$router.push({ name: 'Inicio' });

                this.$swal({ icon: 'warning', text: 'No tienes permiso para acceder' });


            }

        },

        loadUserSelect: async function () {
            try {
                const response = await AdminApi.GetALLUsers();
                const userList = response.data.obj;
                this.listUsers = userList;
            } catch (error) {
                console.error('Error al cargar los proyectos desde la API:', error);
            }

        },
        loadPollSelect: async function () {
            try {
                const response = await AdminApi.GetAllPolls();
                const listPoll = response.data.obj;
                this.listPoll = listPoll;
            } catch (error) {
                console.error('Error al cargar los proyectos desde la API:', error);
            }

        },
        downloadExcelReportProject: async function () {

            const selectedUserObject = JSON.parse(this.elementSelectUsuLogin);
            const error = this.$refs.error;
            error.style.visibility = "hidden";
            if (selectedUserObject !== null) {

                try {
                    const response = await AdminApi.GetProjectsReportUser(selectedUserObject.usu_Login);
                    const data = response.data.obj;
                    this.dataListProjectUser = data;
                } catch (error) {
                    console.error('Error al cargar los proyectos desde la API:', error);
                }

                if (this.dataListProjectUser && this.dataListProjectUser.length > 0) {
                    const fontStyle = {
                        name: 'Arial',
                        size: 30,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontDataUserStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontRowStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: '000000' },
                    };
                    const HeaderStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F7F704' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };

                    const DataUserStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: '244062' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };
                    const rowStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F2F2F2' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };


                    const workbook = new ExcelJS.Workbook();
                    const worksheet = workbook.addWorksheet("Informe del usuario");

                    worksheet.getColumn(1).width = 60;
                    worksheet.getColumn(1).alignment = { horizontal: 'center', vertical: 'middle' };
                    worksheet.getColumn(2).width = 30;
                    worksheet.getColumn(3).width = 40;
                    worksheet.getColumn(4).width = 30;
                    worksheet.getColumn(5).width = 20;
                    worksheet.addRow(["Reporte de proyecto", "de usuario", "Procormi"]);
                    const cell = worksheet.getCell('A1');
                    cell.width = 100;
                    worksheet.addRow(["#Nombre del usuario", selectedUserObject.usu_Nombre, "Correo Electronico", selectedUserObject.usu_email]);
                    worksheet.addRow(["#Numero de proyecto", "Nombre del proyecto", "Descripcion", "Estado", "Fecha de creacion"]);
                    worksheet.getRow(1).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontStyle;
                    });
                    worksheet.getRow(2).eachCell((cell) => {
                        cell.fill = DataUserStyle.fill;
                        cell.border = DataUserStyle.border;
                        cell.font = fontDataUserStyle;
                    });
                    worksheet.getRow(3).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontRowStyle;
                    });
                    for (const item of this.dataListProjectUser) {
                        const row = worksheet.addRow([item.Id_project, item.Project_Name, item.Description_Project, item.Status_Name, item.Creation_Date]);


                        row.eachCell({ includeEmpty: true }, (cell) => {
                            cell.fill = rowStyle.fill;
                            cell.border = rowStyle.border;

                        });
                    }


                    workbook.xlsx.writeBuffer().then((data) => {
                        const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                        const url = window.URL.createObjectURL(blob);

                        const namewithoutspaces = selectedUserObject.usu_Nombre.replace(/\s/g, '');
                        const a = document.createElement('a');
                        a.href = url;
                        a.download = 'ReporteProyecto' + namewithoutspaces + '.xlsx';
                        a.style.display = 'none';
                        document.body.appendChild(a);
                        a.click();


                        window.URL.revokeObjectURL(url);

                        this.$swal.fire({
                            title: 'Descargando archivo',
                            icon: 'info',
                            toast: true,
                            position: 'top-end',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                        });
                    });
                } else {


                    error.textContent = "No existe ningun proyecto asociado con el usuario";
                    error.style.visibility = "visible";
                }


            } else {


                error.textContent = "Tiene que seleccionar un usuario";
                error.style.visibility = "visible";

            }


        },
        downloadExcelReportSprint: async function () {

            const selectedUserObject = JSON.parse(this.elementSelectUsuLogin);
            const error = this.$refs.error2;
            error.style.visibility = "hidden";
            if (selectedUserObject !== null) {



                try {
                    const response = await AdminApi.GetSprintReportUser(selectedUserObject.usu_Login);
                    const data = response.data.obj;
                    this.dataListSprintUser = data;
                } catch (error) {
                    console.error('Error al cargar los proyectos desde la API:', error);
                }

                if (this.dataListSprintUser && this.dataListSprintUser.length > 0) {

                    const fontStyle = {
                        name: 'Arial',
                        size: 30,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontDataUserStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontRowStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: '000000' },
                    };
                    const HeaderStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F7F704' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };

                    const DataUserStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: '244062' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };
                    const rowStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F2F2F2' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };


                    const workbook = new ExcelJS.Workbook();
                    const worksheet = workbook.addWorksheet("Informe del usuario");

                    worksheet.getColumn(1).width = 60;
                    worksheet.getColumn(1).alignment = { horizontal: 'center', vertical: 'middle' };
                    worksheet.getColumn(2).width = 30;
                    worksheet.getColumn(3).width = 40;
                    worksheet.getColumn(4).width = 30;
                    worksheet.getColumn(5).width = 30;
                    worksheet.addRow(["Reporte de sprint", "de usuario", "Procormi"]);
                    const cell = worksheet.getCell('A1');
                    cell.width = 100;
                    worksheet.addRow(["#Nombre del usuario", selectedUserObject.usu_Nombre, "Correo Electronico", selectedUserObject.usu_email]);
                    worksheet.addRow(["#Numero de Spring", "Numero del Proyecto #", "Nombre del spring", "Fecha de inicio", "Fecha final", "Estado"]);
                    worksheet.getRow(1).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontStyle;
                    });
                    worksheet.getRow(2).eachCell((cell) => {
                        cell.fill = DataUserStyle.fill;
                        cell.border = DataUserStyle.border;
                        cell.font = fontDataUserStyle;
                    });
                    worksheet.getRow(3).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontRowStyle;
                    });
                    for (const item of this.dataListSprintUser) {
                        const row = worksheet.addRow([item.Id_Sprint, item.Id_Project, item.Sprint_Name, item.Start_Date, item.End_Date, item.Status_Name]);


                        row.eachCell({ includeEmpty: true }, (cell) => {
                            cell.fill = rowStyle.fill;
                            cell.border = rowStyle.border;

                        });
                    }


                    workbook.xlsx.writeBuffer().then((data) => {
                        const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                        const url = window.URL.createObjectURL(blob);

                        const namewithoutspaces = selectedUserObject.usu_Nombre.replace(/\s/g, '');
                        const a = document.createElement('a');
                        a.href = url;
                        a.download = 'ReporteSprint' + namewithoutspaces + '.xlsx';
                        a.style.display = 'none';
                        document.body.appendChild(a);
                        a.click();


                        window.URL.revokeObjectURL(url);

                        this.$swal.fire({
                            title: 'Descargando archivo',
                            icon: 'info',
                            toast: true,
                            position: 'top-end',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                        });
                    });
                } else {
                    const error = this.$refs.error2;
                    error.textContent = "No existe ningun sprint asociado con el usuario";
                    error.style.visibility = "visible";
                }

            }

            else {
                const error = this.$refs.error2;
                error.textContent = "Tiene que seleccionar un usuario";
                error.style.visibility = "visible";

            }

        },
        downloadExcelReportTask: async function () {

            const selectedUserObject = JSON.parse(this.elementSelectUsuLogin);
            const error = this.$refs.error3;
            error.style.visibility = "hidden";
            if (selectedUserObject !== null) {

                try {
                    const response = await AdminApi.GetTaskReportUser(selectedUserObject.usu_Login);
                    const data = response.data.obj;
                    this.dataListTaskUser = data;
                } catch (error) {
                    console.error('Error al cargar los proyectos desde la API:', error);
                }

                if (this.dataListTaskUser && this.dataListTaskUser.length > 0) {

                    const fontStyle = {
                        name: 'Arial',
                        size: 30,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontDataUserStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontRowStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: '000000' },
                    };
                    const HeaderStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F7F704' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };

                    const DataUserStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: '244062' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };
                    const rowStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F2F2F2' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };


                    const workbook = new ExcelJS.Workbook();
                    const worksheet = workbook.addWorksheet("Informe del usuario");

                    worksheet.getColumn(1).width = 60;
                    worksheet.getColumn(1).alignment = { horizontal: 'center', vertical: 'middle' };
                    worksheet.getColumn(2).width = 30;
                    worksheet.getColumn(3).width = 40;
                    worksheet.getColumn(4).width = 30;
                    worksheet.getColumn(5).width = 30;
                    worksheet.getColumn(6).width = 30;
                    worksheet.addRow(["Reporte de tareas", "de usuario", "Procormi"]);
                    const cell = worksheet.getCell('A1');
                    cell.width = 100;
                    worksheet.addRow(["#Nombre del usuario", selectedUserObject.usu_Nombre, "Correo Electronico", selectedUserObject.usu_email]);
                    worksheet.addRow(["#Numero de Spring", "Nombre del Sprint ", "#Numero Proyecto", "#Numero de tarea", "Nombre de tarea", "Descripcion", "Estado"]);
                    worksheet.getRow(1).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontStyle;
                    });
                    worksheet.getRow(2).eachCell((cell) => {
                        cell.fill = DataUserStyle.fill;
                        cell.border = DataUserStyle.border;
                        cell.font = fontDataUserStyle;
                    });
                    worksheet.getRow(3).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontRowStyle;
                    });
                    for (const item of this.dataListTaskUser) {
                        const row = worksheet.addRow([item.Id_Sprint, item.Sprint_Name, item.Id_Project, item.Id_Task, item.Task_Name, item.Description_Task, item.Status_Name]);


                        row.eachCell({ includeEmpty: true }, (cell) => {
                            cell.fill = rowStyle.fill;
                            cell.border = rowStyle.border;

                        });
                    }


                    workbook.xlsx.writeBuffer().then((data) => {
                        const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                        const url = window.URL.createObjectURL(blob);

                        const namewithoutspaces = selectedUserObject.usu_Nombre.replace(/\s/g, '');
                        const a = document.createElement('a');
                        a.href = url;
                        a.download = 'ReporteTarea' + namewithoutspaces + '.xlsx';
                        a.style.display = 'none';
                        document.body.appendChild(a);
                        a.click();


                        window.URL.revokeObjectURL(url);

                        this.$swal.fire({
                            title: 'Descargando archivo',
                            icon: 'info',
                            toast: true,
                            position: 'top-end',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                        });
                    });
                } else {
                   
                    error.textContent = "No existe ningun tareas asociadas con el usuario";
                    error.style.visibility = "visible";

                }

            }

            else {
                
                error.textContent = "Tiene que seleccionar un usuario";
                error.style.visibility = "visible";
                
            }

        },
        downloadExcelReportSubTask: async function () {

            const selectedUserObject = JSON.parse(this.elementSelectUsuLogin);
            const error = this.$refs.error4;
            error.style.visibility = "hidden";

            if (selectedUserObject !== null) {

                try {
                    const response = await AdminApi.GetSubTaskReportUser(selectedUserObject.usu_Login);
                    const data = response.data.obj;
                    this.dataListSubTaskUser = data;
                } catch (error) {
                    console.error('Error al cargar los proyectos desde la API:', error);
                }

                if (this.dataListSubTaskUser && this.dataListSubTaskUser.length > 0) {

                    const fontStyle = {
                        name: 'Arial',
                        size: 30,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontDataUserStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontRowStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: '000000' },
                    };
                    const HeaderStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F7F704' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };

                    const DataUserStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: '244062' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };
                    const rowStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F2F2F2' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };


                    const workbook = new ExcelJS.Workbook();
                    const worksheet = workbook.addWorksheet("Informe del usuario");

                    worksheet.getColumn(1).width = 60;
                    worksheet.getColumn(1).alignment = { horizontal: 'center', vertical: 'middle' };
                    worksheet.getColumn(2).width = 30;
                    worksheet.getColumn(3).width = 40;
                    worksheet.getColumn(4).width = 30;
                    worksheet.getColumn(5).width = 30;
                    worksheet.getColumn(6).width = 30;
                    worksheet.getColumn(7).width = 30;
                    worksheet.getColumn(8).width = 30;
                    worksheet.getColumn(9).width = 30;
                    worksheet.getColumn(10).width = 30;
                    worksheet.addRow(["Reporte de sub tareas", "de usuario", "Procormi"]);
                    const cell = worksheet.getCell('A1');
                    cell.width = 100;
                    worksheet.addRow(["#Nombre del usuario", selectedUserObject.usu_Nombre, "Correo Electronico", selectedUserObject.usu_email]);
                    worksheet.addRow(["#Numero de Sub Tarea", "Titulo", "Descripcion", "#Numero de tarea", "Nombre de tarea", "Descripcion", "Numero de proyecto", "Nombre sprint", "Prioridad", "Estado"]);
                    worksheet.getRow(1).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontStyle;
                    });
                    worksheet.getRow(2).eachCell((cell) => {
                        cell.fill = DataUserStyle.fill;
                        cell.border = DataUserStyle.border;
                        cell.font = fontDataUserStyle;
                    });
                    worksheet.getRow(3).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontRowStyle;
                    });
                    for (const item of this.dataListSubTaskUser) {
                        const row = worksheet.addRow([item.Id_Sub_Task, item.Title, item.Description, item.Id_Task, item.Task_Name, item.Description_Task, item.Id_Project, item.Sprint_Name, item.Priority_Name, item.Status_Name]);


                        row.eachCell({ includeEmpty: true }, (cell) => {
                            cell.fill = rowStyle.fill;
                            cell.border = rowStyle.border;

                        });
                    }


                    workbook.xlsx.writeBuffer().then((data) => {
                        const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                        const url = window.URL.createObjectURL(blob);

                        const namewithoutspaces = selectedUserObject.usu_Nombre.replace(/\s/g, '');
                        const a = document.createElement('a');
                        a.href = url;
                        a.download = 'ReporteSubTarea' + namewithoutspaces + '.xlsx';
                        a.style.display = 'none';
                        document.body.appendChild(a);
                        a.click();


                        window.URL.revokeObjectURL(url);

                        this.$swal.fire({
                            title: 'Descargando archivo',
                            icon: 'info',
                            toast: true,
                            position: 'top-end',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                        });
                    });
                } else {
                
                    error.textContent = "No existe ningun sub tareas asociadas con el usuario";
                    error.style.visibility = "visible";
                }

            }

            else {
           
                error.textContent = "Tiene que seleccionar un usuario";
                error.style.visibility = "visible";
            }

        },
        downloadExcelReportPoll: async function () {

            const selectedPollObject = JSON.parse(this.elementSelectPoll);
            const error = this.$refs.error5;
            error.style.visibility = "hidden";
            if (selectedPollObject !== null) {

                try {
                    const response = await AdminApi.GetPollReport(selectedPollObject.Id_Poll);
                    const data = response.data.obj;
                    this.dataListPoll = data;
                } catch (error) {
                    console.error('Error al cargar los proyectos desde la API:', error);
                }

                if (this.dataListPoll && this.dataListPoll.length > 0) {

                    const fontStyle = {
                        name: 'Arial',
                        size: 30,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontDataUserStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: 'FFFFFF' },
                    };

                    const fontRowStyle = {
                        name: 'Arial',
                        size: 12,
                        bold: true,
                        italic: true,
                        underline: false,
                        color: { argb: '000000' },
                    };
                    const HeaderStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F7F704' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };

                    const DataUserStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: '244062' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };
                    const rowStyle = {
                        fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'F2F2F2' } },
                        border: {
                            top: { style: 'thin', color: { argb: '000000' } },
                            left: { style: 'thin', color: { argb: '000000' } },
                            bottom: { style: 'thin', color: { argb: '000000' } },
                            right: { style: 'thin', color: { argb: '000000' } },
                        },
                    };


                    const workbook = new ExcelJS.Workbook();
                    const worksheet = workbook.addWorksheet("Informe tipo pregunta texto");

                    worksheet.getColumn(1).width = 60;
                    worksheet.getColumn(1).alignment = { horizontal: 'center', vertical: 'middle' };
                    worksheet.getColumn(2).width = 90;
                    worksheet.getColumn(3).width = 30;
                    worksheet.getColumn(4).width = 30;
                    worksheet.getColumn(5).width = 30;
                    worksheet.getColumn(6).width = 30;
                    worksheet.getColumn(7).width = 30;
                    worksheet.getColumn(8).width = 30;
                    worksheet.getColumn(9).width = 30;
                    worksheet.getColumn(10).width = 30;
                    worksheet.addRow(["Reporte de Encuesta", "Procormi"]);
                    const cell = worksheet.getCell('A1');
                    cell.width = 100;
                    worksheet.addRow(["#Nombre de la encuesta", selectedPollObject.Name]);
                    worksheet.addRow(["Pregunta", "Respuesta de Texto"]);
                    worksheet.getRow(1).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontStyle;
                    });
                    worksheet.getRow(2).eachCell((cell) => {
                        cell.fill = DataUserStyle.fill;
                        cell.border = DataUserStyle.border;
                        cell.font = fontDataUserStyle;
                    });
                    worksheet.getRow(3).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontRowStyle;
                    });
                    for (const item of this.dataListPoll) {


                        if (item.Question_Type_Name === null && item.TextQuestionOptions === null) {
                            const row = worksheet.addRow([item.TextQuestion, item.AnswerTexts]);

                            row.eachCell({ includeEmpty: true }, (cell) => {
                                cell.fill = rowStyle.fill;
                                cell.border = rowStyle.border;

                            });
                        }

                    }

                    const worksheet2 = workbook.addWorksheet("Informe respuetas multiples y respuesta unica");
                    worksheet2.addRow(["Reporte de Encuesta", "Procormi"]);
                    worksheet2.addRow(["#Nombre de la encuesta", selectedPollObject.Name]);
                    worksheet2.addRow(["Pregunta", "Tipo de opcion", "Opcion", "Cantidad de opcione seleccionadas"]);
                    worksheet2.getColumn(1).width = 60;
                    worksheet2.getColumn(1).alignment = { horizontal: 'center', vertical: 'middle' };
                    worksheet2.getColumn(2).width = 90;
                    worksheet2.getColumn(3).width = 30;
                    worksheet2.getColumn(4).width = 50;
                    worksheet2.getColumn(5).width = 30;
                    worksheet2.getColumn(6).width = 30;
                    worksheet2.getColumn(7).width = 30;
                    worksheet2.getColumn(8).width = 30;
                    worksheet2.getColumn(9).width = 30;
                    worksheet2.getColumn(10).width = 30;

                    worksheet2.getRow(1).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontStyle;
                    });
                    worksheet2.getRow(2).eachCell((cell) => {
                        cell.fill = DataUserStyle.fill;
                        cell.border = DataUserStyle.border;
                        cell.font = fontDataUserStyle;
                    });
                    worksheet2.getRow(3).eachCell((cell) => {
                        cell.fill = HeaderStyle.fill;
                        cell.border = HeaderStyle.border;
                        cell.font = fontRowStyle;
                    });

                    for (const item of this.dataListPoll) {


                        if (item.Question_Type_Name !== null) {
                            const row = worksheet2.addRow([item.TextQuestion, item.Question_Type_Name, item.OptionText, item.AnswerOptionCount]);

                            row.eachCell({ includeEmpty: true }, (cell) => {
                                cell.fill = rowStyle.fill;
                                cell.border = rowStyle.border;

                            });
                        }

                    }

                    workbook.xlsx.writeBuffer().then((data) => {
                        const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                        const url = window.URL.createObjectURL(blob);

                        const namewithoutspaces = selectedPollObject.Name.replace(/\s/g, '');
                        const a = document.createElement('a');
                        a.href = url;
                        a.download = 'ReporteEncuesta' + namewithoutspaces + '.xlsx';
                        a.style.display = 'none';
                        document.body.appendChild(a);
                        a.click();


                        window.URL.revokeObjectURL(url);

                        this.$swal.fire({
                            title: 'Descargando archivo',
                            icon: 'info',
                            toast: true,
                            position: 'top-end',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                        });
                    });
                } else {
                
                        
                error.textContent = "No existe ninguna respuesta";
                error.style.visibility = "visible";
                }

            }

            else {
                
                error.textContent = "Tiene que seleccionar una encuesta";
                error.style.visibility = "visible";
                
            }

        },

        closeModals: async function () {
            const error = this.$refs.error;
            const error2 = this.$refs.error2;
            const error3 = this.$refs.error3;
            const error4 = this.$refs.error4;
            const error5 = this.$refs.error5;
            
            error.style.visibility = "hidden";
            error2.style.visibility = "hidden";
            error3.style.visibility = "hidden";
            error4.style.visibility = "hidden";
            error5.style.visibility = "hidden";

        }
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
        await this.loadUserSelect();
        await this.loadPollSelect();
        await this.$root.validarLoginFooter.call();
    }

}

</script>

<style></style>

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
    ;
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
    padding: 25px;
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

.content-icon {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
}

.content-icon span {
    margin: 15px;
    font-size: 6em;
    color: #0a3a66;
}
</style>