<template>
    <div class="vistaPrincipal fondoGeneral">
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
                                <router-link role="button" :to="{ name: 'Inicio' }" class="textoBlanco textoEncuestas"
                                    style="text-decoration: none;" exact-active-class="active-link">Proyectos&nbsp;&nbsp;<i
                                        class="text-white fas fa-project-diagram"
                                        style="cursor: pointer; font-size: 14px;"></i></router-link>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center; min-width: 150px;">
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

                    <div class="col-12" style="margin-top: 30px;">
                        <h4 style="text-align: center; font-size: 25px; color: #0a3a66;" v-if="!esEditar">Crear proyecto
                        </h4>
                        <h4 style="text-align: center; font-size: 25px; color: #0a3a66;" v-if="esEditar">Editar proyecto
                        </h4>
                        <br />
                        <div>
                            <div>
                                <form class="estiloForm">
                                    <div style="padding: 50px;">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Nombre<span style="color: red;">
                                                    *</span></label>
                                            <input v-model.trim="project.Project_Name" maxlength="100"
                                                class="small-input inputsGeneral" ref="inputProjectName" type="text"
                                                required>
                                            
                                            <p ref="errorProjectName" style="visibility: hidden;color: red;"></p>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-12">
                                                <div>
                                                    <label class="margin-15px-bottom text-black">Descripción<span
                                                            style="color: red;"> *</span></label>
                                                    <div>
                                                        <div ref="Quill"
                                                            style="border: 1px solid gray; min-height: 200px; border-bottom-left-radius: 15px; border-bottom-right-radius: 15px;">
                                                        </div>
                                                        <br>
                                                        <p ref="errorDescrition" style="visibility: hidden;color: red;padding:5 px;"> </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <label class=" margin-15px-bottom text-black">Usuarios<span style="color: red;">
                                                    *</span></label>
                                            <div class="containerPlus">
                                                <div class="left-content">
                                                    <select v-model="selectedUser" required name="usuarios" id="usuarios"
                                                        class="form-select text-black inputsGeneral"
                                                        style="min-height: 48px;">
                                                        <option :value="null">Seleccione una opción</option>
                                                        <option v-for="item in listUsers" :key="item.usu_Login"
                                                            :value="JSON.stringify(item)">{{ item.usu_Nombre
                                                            }}</option>
                                                    </select>
                                                </div>
                                                <div class="right-content">
                                                    <button type="button" @click="addListUser()" class="btn btn-success"
                                                        style="min-height: 48px; min-width: 48px; float: right;"><span
                                                            class="fas fa-plus"></span></button>
                                                </div>

                                              

                                            </div>
                                            <p ref="errorUserList" style="visibility: hidden;color: red;"></p>
                                        </div>
                                        <div class="row" style="margin-top: 4%">
                                            <div class="col-12">
                                                <div class="table-responsive">
                                                    <label class="margin-15px-bottom text-black">Listado de
                                                        usuarios</label>
                                                    <table class="table bootstrap-datatable datatable">
                                                        <thead>
                                                            <tr>
                                                                <th style="min-width: 40px;">login</th>
                                                                <th style="min-width: 60px;">Nombre</th>
                                                                <th style="min-width: 40px;">Opciones</th>
                                                            </tr>
                                                        </thead>

                                                        <tbody>
                                                            <tr v-for="item in UserlistAdd" :key="item.usu_Login">
                                                                <td>{{ item.usu_Login }}</td>
                                                                <td>{{ item.usu_Nombre }}</td>
                                                                <td>
                                                                    <button @click="deleteElementListUser(item.usu_Login)"
                                                                        type="button" class="btn btn-danger">
                                                                        <span class="fas fa-trash" b-tooltip.hover
                                                                            title="Eliminar Adjunto"></span>
                                                                    </button>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <label class="margin-15px-bottom text-black">Agregar
                                                adjuntos</label>
                                            <div class="containerPlus">
                                                <div class="left-content">
                                                    <div class="form-group">
                                                        <div class="custom-file col-md-12"
                                                            style="margin-left: 0px; padding: 0px;">
                                                            <input id="SelectFile" @change="onFileSelected"
                                                                class="inputsGeneral" type="file" ref="fileupload"
                                                                accept=".pdf, .docx, .xlsx, .jpg, .jpeg, .png, .txt"
                                                                style="min-height: 48px;" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="right-content">
                                                    <button type="button" class="btn btn-success"
                                                        style="min-height: 48px; min-width: 48px; float: right;"><span
                                                            class="fas fa-plus"></span></button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 4%">
                                            <div class="col-12">
                                                <div class="table-responsive">
                                                    <label class="margin-15px-bottom text-black">Listado de
                                                        adjuntos</label>
                                                    <table class="table bootstrap-datatable datatable">
                                                        <thead>
                                                            <tr>
                                                                <th style="min-width: 70px;">Nombre</th>
                                                                <th style="min-width: 30px;">Tipo</th>
                                                                <th style="min-width: 40px;">Opciones</th>
                                                            </tr>
                                                        </thead>

                                                        <tbody>
                                                            <tr v-for="item in FileList" :key="item">
                                                                <td>{{ item.File_Name }}</td>
                                                                <td>{{ item.File_Type }}</td>
                                                                <td>
                                                                    <button @click="deleteElementListFile(item.File_Name)"
                                                                        type="button" class="btn btn-danger">
                                                                        <span class="fas fa-trash" b-tooltip.hover
                                                                            title="Eliminar Adjunto"></span>
                                                                    </button>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="BotonesJ">
                                            <div><button type="button" @click="insertOrEditProject" class="btn btn-success"
                                                    style="font-size: 16px; min-width: 100px;">Guardar</button>
                                            </div>
                                            <br />
                                            <div><a href="/Inicio" class="btn btn-danger"
                                                    style="font-size: 16px; min-width: 100px;">Cancelar</a>
                                            </div>
                                        </div>
                                    </div>
                                </form>
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
            errorDescription : this.$refs.errorDescrition,
            saveDateCreationFile: "",
            FileList: [],
            listNewFileEdit: [],
            listEditFile: [],
            selectedUser: null,
            UserlistAdd: [],
            listUsers: [],
            idProjectInsert: 0,//Este sirve para almacenar el id del proyecto cuando se inserta como es autoincremental
            idProyecto: (this.$route.params.id != undefined) ? this.$route.params.id : 0,
            esEditar: false,
            project: {
                Id_project: this.idProyecto,
                Project_Name: "",
                Description_Project: "",
                Id_State: 0,
                Creation_Date: ""
            },
            SegUsuProject: {
                Id: 0,
                User_Login: "",
                Id_project: ""
            },

            ActionEN: {
                Action_Description: "",
                Action_User: ""
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

        validarEditar: function () {
            let usutipo = this.recuperarUsuTipo()

            if (usutipo === "Operador") {

                this.$router.push({ name: 'Inicio' });

                this.$swal({ icon: 'warning', text: 'No tienes permiso para acceder' });


            }

            if (this.idProyecto != 0) {
                this.esEditar = true;
            } else {
                this.esEditar = false;
            }
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

        loadUserSelect: async function () {
            try {
                const response = await AdminApi.GetALLUsers();
                const userList = response.data.obj;
                this.listUsers = userList;
            } catch (error) {
                console.error('Error al cargar los proyectos desde la API:', error);
            }

        }
        ,

        insertOrEditProject: async function () {

            const quilltext = this.quill.getText();
            const maxLength = 1000;
            const errorProjectName = this.$refs.errorProjectName;
            const errorDescription = this.$refs.errorDescrition;
            const errorUserList = this.$refs.errorUserList;

            errorProjectName.style.visibility = "hidden";
            errorDescription.style.visibility = "hidden";
            errorUserList.style.visibility = "hidden";

            errorProjectName.style.display = "none";
            errorDescription.style.display = "none";
            errorUserList.style.display = "none";

            if (this.project.Project_Name.trim() == "") {
                
                errorProjectName.textContent = "Se tiene que completar el campo del nombre del proyecto";
                errorProjectName.style.visibility = "visible";
                errorProjectName.style.display = "Block";
                return
            }


            if (quilltext.trim() == "") {

                this.quill.focus();
                errorDescription.textContent = "Se tiene que completar el  campo de la descripcion";
                errorDescription.style.visibility = "visible";
                errorDescription.style.display = "Block";
                return
            }

            if (quilltext.length > maxLength) {

                const maxLengthAux = maxLength - 50;
                const truncatedText = quilltext.slice(0, maxLengthAux);
                this.quill.setText(truncatedText);
                this.quill.focus();

                errorDescription.textContent = "No se puede un valor superior ha 1000 caracteres en la descripcion";
                errorDescription.style.visibility = "visible";
                errorDescription.style.display = "Block";
                return
            }

            if (this.UserlistAdd.length == 0) {

          
                errorUserList.textContent = "  Se tiene que agregar al menos un usuario";
                errorUserList.style.visibility = "visible";
                errorUserList.style.display = "Block";
                return
            }

            if (
                this.project.Project_Name.trim() !== "" &&
                quilltext.trim() !== "" &&
                this.UserlistAdd.length > 0 && quilltext.length < maxLength

            ) {

                if (!this.esEditar) {
                    try {
                        const quillText = this.quill.root.innerHTML;
                        this.project.Description_Project = quillText;

                        const response = await AdminApi.PostProject(this.project);
                        const mensaje = response.data.ok;
                       
                        if (mensaje) {
                            this.ActionEN.Action_Description = "Creó el proyecto " + this.project.Project_Name
                            this.ActionEN.Action_User = this.recuperarUsuLog();
                            await AdminApi.PostNewAction(this.ActionEN)
                        }

                        const idProject = await AdminApi.GetLastInsertId('Project');
                        const idInsert = idProject.data.obj;
                        this.idProjectInsert = idInsert;

                        for (const item of this.UserlistAdd) {
                            const addUser = {
                                "Id": 0,
                                "User_Login": item.usu_Login,
                                "Id_Project": idInsert
                            };

                            try {
                                await AdminApi.PostAddUserProject(addUser);
                            } catch (error) {
                                console.error('Error al agregar usuario al proyecto:', error);
                            }
                        }

                        // notificar usuarios la asignacion del proyecto
                        this.notifyUsersOnProjectCreation();


                        const currentdate = new Date();
                        const options = { year: 'numeric', month: '2-digit', day: '2-digit', hour: '2-digit', minute: '2-digit', second: '2-digit' };
                        const Dateformat = new Intl.DateTimeFormat('es', options).format(currentdate);
                        const DateFormatwithoutBar = Dateformat.replace(/\//g, '-');
                        const DateFormatwithoutSpace = DateFormatwithoutBar.replace(/[-\s:]/g, '')
                        this.saveDateCreationFile = DateFormatwithoutSpace

                        if (this.FileList.length > 0) {

                            for (const item of this.FileList) {
                                const addFile = {
                                    "File_ID": 0,
                                    "File_Name": this.idProjectInsert + "_" + DateFormatwithoutSpace + "_" + item.File_Name,
                                    "File_Path": "",
                                    "File_Type": item.File_Type,
                                    "File_Size": 5,
                                    "Creation_Date": "2023-09-30T13:47:37.9361279-06:00"
                                };

                                try {

                                    const response = await AdminApi.PostFile(addFile);
                                    const idFileLastInsert = await AdminApi.GetLastInsertId('File');
                                    const idFileLastInsertObj = idFileLastInsert.data.obj;
                                    const mensaje = response.data.ok;
                                    console.log(mensaje);

                                    const FileProject = {
                                        "ID_Project_File": 0,
                                        "Id_Project": idInsert,
                                        "File_ID": idFileLastInsertObj
                                    };

                                    const response2 = await AdminApi.PostAddFileProject(FileProject);
                                    const mensaje2 = response2.data.obj;
                                    await this.uploadsFile()
                                    console.log(mensaje2)
                                    this.$swal({ icon: 'success', text: 'Se creo correctamente el proyecto' });
                                    this.$router.push({ name: 'Inicio' })

                                } catch (error) {
                                    console.error('Error al agregar archivo al proyecto:', error);
                                }


                            }

                        }
                        else {

                            this.$swal({ icon: 'success', text: 'Se creo correctamente el proyecto' });
                            this.$router.push({ name: 'Inicio' })
                        }


                    } catch (error) {
                        console.error('Error al cargar los proyectos desde la API:', error);
                    }

                } else {
                    try {
                        const quillText = this.quill.root.innerHTML;
                        this.project.Description_Project = quillText;

                        const response = await AdminApi.PutProject(this.project);
                        const mensaje = response.data.ok;
                        if (mensaje) {
                            this.ActionEN.Action_Description = "Modificó el proyecto " + this.project.Project_Name
                            this.ActionEN.Action_User = this.recuperarUsuLog();
                            await AdminApi.PostNewAction(this.ActionEN)
                        }
                        
                        if (this.fileListEdit && this.FileList) {
                            if (this.ArraysEquals(this.fileListEdit, this.FileList) === true) {
                                const response2 = await AdminApi.DeleteFilesProject(this.$route.params.id);
                                const mensaje2 = response2.data.ok;
                                console.log(mensaje2)
                            }
                        }


                        // notificar a usuarios basado en agregado/removido del proyecto actual
                        this.notifyUsersOnUserProjectModification()

                        const response3 = await AdminApi.DeleteUserListProject(this.$route.params.id);
                        const mensaje3 = response3.data.ok;
                        console.log(mensaje3)

                        for (const item of this.UserlistAdd) {
                            const addUser = {
                                "Id": 0,
                                "User_Login": item.usu_Login,
                                "Id_Project": this.idProyecto,
                            };

                            try {
                                const response3 = await AdminApi.PostAddUserProject(addUser);
                                const mensaje3 = response3.data.ok;
                                console.log(mensaje3);

                            } catch (error) {
                                console.error('Error al agregar usuario al proyecto:', error);
                            }
                        }
                        const currentdate = new Date();
                        const options = { year: 'numeric', month: '2-digit', day: '2-digit', hour: '2-digit', minute: '2-digit', second: '2-digit' };
                        const Dateformat = new Intl.DateTimeFormat('es', options).format(currentdate);
                        const DateFormatwithoutBar = Dateformat.replace(/\//g, '-');
                        const DateFormatwithoutSpace = DateFormatwithoutBar.replace(/[-\s:]/g, '')
                        this.saveDateCreationFile = DateFormatwithoutSpace;

                        if (this.FileList.length > 0) {


                            for (const item of this.FileList) {
                                let fileAlreadyExists = false;

                                if (this.fileListEdit && this.fileListEdit.length > 0) {
                                    for (let i = 0; i < this.fileListEdit.length; i++) {
                                        if (this.fileListEdit[i].File_Name === item.File_Name) {
                                            fileAlreadyExists = true;
                                            break; // Si el archivo ya existe, no es necesario seguir buscando
                                        }
                                    }
                                }

                                if (!fileAlreadyExists) {
                                    // Agregar el archivo al proyecto
                                    const addFile = {
                                        "FileData": {
                                            "File_ID": 0,
                                            "File_Name": this.idProyecto + "_" + DateFormatwithoutSpace + "_" + item.File_Name,
                                            "File_Path": "",
                                            "File_Type": item.File_Type,
                                            "File_Size": 5,
                                            "Creation_Date": "2023-09-30T13:47:37.9361279-06:00"
                                        },
                                        "File": item.File
                                    };

                                    this.listNewFileEdit.push(addFile);
                                    console.log(addFile);

                                }
                            }
                            try {
                                for (const item of this.listNewFileEdit) {
                                    const response = await AdminApi.PostFile(item.FileData);
                                    const mensaje = response.data.ok;
                                    console.log(mensaje)

                                    const idFileLastInsert = await AdminApi.GetLastInsertId('File');
                                    const idFileLastInsertObj = idFileLastInsert.data.obj;

                                    const FileProject = {
                                        "ID_Project_File": 0,
                                        "Id_Project": this.idProyecto,
                                        "File_ID": idFileLastInsertObj
                                    };

                                    const response2 = await AdminApi.PostAddFileProject(FileProject);
                                    const mensaje2 = response2.data.ok
                                    console.log(mensaje2)
                                }

                                await this.uploadsFile();

                            } catch (error) {
                                console.error('Error al agregar usuario al proyecto:' + error);
                            }
                        }

                        this.$swal({ icon: 'success', text: 'Proyecto modificado con éxito' });
                        setTimeout(() => {
                            this.$router.push({ name: 'Inicio' });
                        }, 2000);
                    } catch (error) {
                        console.error('Error al cargar los proyectos desde la API:', error);
                    }
                }

            }
      
        }

        ,

        addListUser: async function () {

       
            const errorUserList = this.$refs.errorUserList;
            errorUserList.style.display="none"
            if (this.selectedUser) {

                const selectedUserObject = JSON.parse(this.selectedUser);

                const isUserInList = this.UserlistAdd.some(item => item.usu_Login === selectedUserObject.usu_Login);

                if (!isUserInList) {

                    this.UserlistAdd.push({
                        usu_Login: selectedUserObject.usu_Login,
                        usu_Nombre: selectedUserObject.usu_Nombre
                    });
                    console.log(selectedUserObject)
                }
                else {
                    this.$swal({ icon: 'warning', text: 'No se puede agregar dos veces el mismo usuario' });
                }


                this.selectedUser = null
            }
        },

         async notifyUsersOnProjectCreation() {

            const addedUsersNotificationOnAssignment = this.UserlistAdd.map(u => u.usu_Login);

            for (const username of addedUsersNotificationOnAssignment) {
                const addedNotification = {
                    Title: 'Nuevo Proyecto',
                    Message : `Ha sido agregado al proyecto: ${this.project.Project_Name}`,
                    Action: 'Agregado',
                    Type: 'project',
                    Type_Ref_Id: this.project.Id_project,
                    Usu_Login: username
                }

                await AdminApi.PostNotification(addedNotification);
            }
        },

        async notifyUsersOnUserProjectModification() {
            const currentUsersPerProjectResponse = await AdminApi.GetUserListProject(this.idProyecto);
            const currentUsernames = currentUsersPerProjectResponse.data.obj.map(user => user.Usu_Login);
            const currentDisplayedUsers = this.UserlistAdd.map(u => u.usu_Login);

            // obtener todos los usuarios que se agregaron como completamente nuevos
            // avisar asignacion de proyecto
            const addedUsersNotificationOnAssignment = 
                this.UserlistAdd
                .filter(user => !currentUsernames.includes(user.usu_Login))
                .map(user => user.usu_Login)

            // obtener todos los usuarios que se descartaron/borraron del proyecto
            // avisar desasignacion de proyecto
            const removedUsersNotificationOnDisassignment = 
                currentUsernames
                .filter(user => !currentDisplayedUsers.includes(user))

            for (const username of addedUsersNotificationOnAssignment) {
                const addedNotification = {
                    Title: 'Nuevo Proyecto',
                    Message : `Ha sido agregado al proyecto: ${this.project.Project_Name}`,
                    Action: 'Agregado',
                    Type: 'project',
                    Type_Ref_Id: this.project.Id_project,
                    Usu_Login: username
                }

                await AdminApi.PostNotification(addedNotification);
            }

            for (const username of removedUsersNotificationOnDisassignment) {
                const removedNotification = {
                    Title: 'Eliminado del proyecto',
                    Message : `Ya no formas parte de: ${this.project.Project_Name}`,
                    Action: 'Eliminado',
                    Type: 'project',
                    Type_Ref_Id: this.project.Id_project,
                    Usu_Login: username
                }

                await AdminApi.PostNotification(removedNotification);
            }
        },


        onFileSelected: function (event) {

            const selectedFile = event.target.files[0];
            const isUserInList = this.FileList.some(item => item.File_Name === selectedFile.name);
            if (selectedFile) {
                if (!isUserInList) {
                    this.FileList.push({
                        File_Name: selectedFile.name,
                        File_Type: selectedFile.type,
                        File: selectedFile
                    });
                }
                else {
                    this.$swal({ icon: 'warning', text: 'No se puede agregar dos veces el mismo archivo' });
                }

            }


        }
        ,

        deleteElementListFile: async function (name) {
            const index = this.FileList.findIndex(item => item.File_Name == name);
            if (index !== -1) {
                this.FileList.splice(index, 1);

                // Verifica si el archivo existe en la lista de archivos existentes (this.fileListEdit)
                const existingFileIndex = this.fileListEdit.findIndex(item => item.File_Name === name);

                if (existingFileIndex !== -1) {
                    // El archivo existe en la lista de archivos existentes, elimínalo de la base de datos
                    const fileToDelete = this.fileListEdit[existingFileIndex];

                    try {
                        // Elimina el archivo de la base de datos
                        const response = await AdminApi.DeleteFileProject(fileToDelete.File_ID);
                        const mensaje = response.data.ok;
                        console.log(mensaje);
                        const response2 = await AdminApi.DeleteFileUplouds(fileToDelete.File_Name);
                        console.log(response2);

                    } catch (error) {
                        console.error('Error al eliminar el archivo de la base de datos:', error);
                    }


                    this.fileListEdit.splice(existingFileIndex, 1);
                }
            }
        }

        ,

        deleteElementListUser: async function (usu_Login) {

            const index = this.UserlistAdd.findIndex(item => item.usu_Login == usu_Login);
            if (index !== -1) {
                this.UserlistAdd.splice(index, 1);
            }
        }
        ,

        loadFormEdit: async function () {
            if (this.esEditar) {
                try {
                    const response = await AdminApi.GetProject(this.idProyecto);
                    const projectData = response.data.obj;

                    this.project = {
                        Id_project: projectData.Id_project,
                        Project_Name: projectData.Project_Name,
                        Description_Project: projectData.Description_Project,
                        Id_State: projectData.Id_State,
                        Creation_Date: projectData.Creation_Date
                    };

                    this.quill.root.innerHTML = this.project.Description_Project;

                    const response2 = await AdminApi.GetUserListProject(this.idProyecto);
                    const userListEdit = response2.data.obj;

                    for (const item of userListEdit) {
                        this.UserlistAdd.push({
                            usu_Login: item.Usu_Login,
                            usu_Nombre: item.Usu_Nombre
                        });
                    }

                    const response3 = await AdminApi.GetFileListProject(this.idProyecto);
                    const fileListEdit = response3.data.obj;

                    for (const item of fileListEdit) {
                        this.FileList.push({
                            File_Name: item.File_Name,
                            File_Type: item.File_Type
                        });
                    }
                    this.fileListEdit = fileListEdit;

                } catch (error) {
                    console.error('Error al cargar el proyecto desde la API:' + error);
                }
            }
        },

        uploadsFile: async function () {
            const formData = new FormData();

            if (!this.esEditar) {
                for (const fileData of this.FileList) {
                    const selectedFile = fileData.File;
                    formData.append('archivos', selectedFile);
                }

                try {

                    const response = await AdminApi.PostUploadFile(this.idProjectInsert, this.saveDateCreationFile, formData);
                    console.log(response)
                } catch (error) {
                    console.log(error);
                }
            } else {

                for (const fileData of this.listNewFileEdit) {
                    const selectedFile = fileData.File;
                    formData.append('archivos', selectedFile);
                }

                try {

                    const response = await AdminApi.PostUploadFile(this.idProyecto, this.saveDateCreationFile, formData);
                    console.log(response)
                } catch (error) {
                    console.log(error);
                }

            }


        },

        ArraysEquals: function (array1, array2) {
            // Verificar si ambas listas son nulas o indefinidas
            if (array1 === null || array2 === null || array1 === undefined || array2 === undefined) {
                return false;
            }

            // Verificar la longitud de ambas listas
            if (array1.length !== array2.length) {
                return false;
            }

            for (let i = 0; i < array1.length; i++) {
                if (array1[i] !== array2[i]) {
                    return false;
                }
            }

            return true;
        }


    }
    ,

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
        await this.validarEditar();
        await this.loadFormEdit();
        await this.loadUserSelect();
        await this.verificarLog();
        await this.$root.validarLoginFooter.call();
        await this.validarEditar();
    }

}
</script>

<style scoped>
.inputsGeneral {
    border-radius: 15px;
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

.fondoGeneral {
    background: rgba(238, 244, 255, 1);
    /*background: linear-gradient(90deg, rgba(208,223,255,1) 0%, rgba(238,244,255,1) 50%, rgba(208,223,255,1) 100%);*/
}

.estiloForm {
    background: white;
    border-radius: 25px;
    margin-right: 50PX;
    margin-left: 50px;
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

.containerPlus {
    display: flex;
}

.left-content {
    flex: 1;
}

.right-content {
    padding-left: 10px;
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

@media screen and (max-width: 400px) {
    .BotonesJ {
        display: inline;
        color: white;
        top: 0;
        width: 100%;
        align-content: center;
    }
}

/*-----------------------------------------*/

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
}

.error-message {
    color: red;
    display: none;
    /* Inicialmente oculto */
}

input:invalid+.error-message {
    display: block;
    /* Mostrar el mensaje de error cuando el input sea inválido */
}
</style>