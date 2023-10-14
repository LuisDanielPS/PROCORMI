<template>
    <div class="vistaPrincipal fondoGeneral">
        <HeaderPrincipal />
        <div>
            <div class="col-12" style="margin-top: 30px;">
                <h4 style="text-align: center; font-size: 25px; color: #0a3a66;" v-if="!esEditar">Crear proyecto</h4>
                <h4 style="text-align: center; font-size: 25px; color: #0a3a66;" v-if="esEditar">Editar proyecto</h4>
                <br />
                <div>
                    <div>
                        <form class="estiloForm">
                            <div style="padding: 50px;">
                                <div>
                                    <label class="margin-15px-bottom text-black">Nombre<span style="color: red;"> *</span></label>
                                    <input v-model.trim="project.Project_Name" maxlength="100"
                                        class="small-input inputsGeneral" ref="inputProjectName" type="text" required>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Descripción<span style="color: red;"> *</span></label>
                                            <div>
                                                <div ref="Quill"
                                                    style="border: 1px solid gray; min-height: 200px; border-bottom-left-radius: 15px; border-bottom-right-radius: 15px;">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label class="margin-15px-bottom text-black">Usuarios<span style="color: red;"> *</span></label>
                                    <div class="containerPlus">
                                        <div class="left-content">
                                            <select v-model="selectedUser" required name="usuarios" id="usuarios"
                                                class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                                <option :value="null">Seleccione una opción</option>
                                                <option v-for="item in listUsers" :key="item.usu_Login"
                                                    :value="JSON.stringify(item)">{{ item.usu_Nombre }}</option>
                                            </select>
                                        </div>
                                        <div class="right-content">
                                            <button type="button" @click="addListUser()" class="btn btn-success"
                                                style="min-height: 48px; min-width: 48px; float: right;"><span
                                                    class="fas fa-plus"></span></button>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 4%">
                                    <div class="col-12">
                                        <div class="table-responsive">
                                            <label class="margin-15px-bottom text-black">Listado de usuarios</label>
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
                                    <label class="margin-15px-bottom text-black">Agregar adjuntos</label>
                                    <div class="containerPlus">
                                        <div class="left-content">
                                            <div class="form-group">
                                                <div class="custom-file col-md-12" style="margin-left: 0px; padding: 0px;">
                                                    <input id="SelectFile" @change="onFileSelected" class="inputsGeneral"
                                                        type="file" ref="fileupload"
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
                                            <label class="margin-15px-bottom text-black">Listado de adjuntos</label>
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
                                            style="font-size: 16px; min-width: 100px;">Guardar</button></div>
                                    <br />
                                    <div><a href="/Inicio" class="btn btn-danger"
                                            style="font-size: 16px; min-width: 100px;">Cancelar</a></div>
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
</template>

<script>
import HeaderPrincipal from '@/components/HeaderPrincipal.vue'
import Quill from 'quill'
import 'quill/dist/quill.snow.css'
import Cookies from 'js-cookie';
import AdminApi from '@/Api/Api';
export default {

    components: {
        /* eslint-disable */
        HeaderPrincipal, Quill
        /* eslint-enable */
    },

    data() {
        return {
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
            }



        }


    },

    methods: {

        validarEditar: function () {
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

            if (this.project.Project_Name.trim() == "") {
                this.$refs.inputProjectName.focus();

                return this.$swal.fire({
                    position: 'top-end',
                    text: 'Se tiene que completar el campo del nombre del proyecto',
                    showConfirmButton: false,
                    timer: 3000
                })
            }


            if (quilltext.trim() == "") {

                this.quill.focus();
                return this.$swal.fire({
                    position: 'top-end',
                    text: 'Se tiene que completar el  campo de la descripcion',
                    showConfirmButton: false,
                    timer: 6000
                })
            }
            if (quilltext.length > maxLength) {

                const maxLengthAux = maxLength - 50;
                const truncatedText = quilltext.slice(0, maxLengthAux);
                this.quill.setText(truncatedText);
                this.quill.focus();
                return this.$swal.fire({
                    position: 'top-end',
                    text: 'No se puede un valor superior ha 1000 caracteres en la descripcion',
                    showConfirmButton: false,
                    timer: 6000
                })
            }

            if (this.UserlistAdd.length == 0) {

                return this.$swal.fire({
                    position: 'top-end',
                    text: 'Se tiene que agregar al menos un usuario',
                    showConfirmButton: false,
                    timer: 6000
                })

            }

            if (
                this.project.Project_Name.trim() != "" &&
                quilltext.trim() != "" &&
                this.UserlistAdd.length > 0

            ) {

                if (!this.esEditar) {
                    try {
                        const quillText = this.quill.getText().trim();
                        this.project.Description_Project = quillText;

                        const response = await AdminApi.PostProject(this.project);
                        const mensaje = response.data.ok
                        console.log(mensaje)

                        const idProject = await AdminApi.GetLastInsertId();
                        const idInsert = idProject.data.obj;
                        this.idProjectInsert = idInsert;

                        for (const item of this.UserlistAdd) {
                            const addUser = {
                                "Id": 0,
                                "User_Login": item.usu_Login,
                                "Id_Project": idInsert
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
                                    const idFileLastInsert = await AdminApi.GetLastInsertId();
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
                                    console.error('Error al agregar usuario al proyecto:', error);
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
                        const quillText = this.quill.getText().trim();
                        this.project.Description_Project = quillText;

                        const response = await AdminApi.PutProject(this.project);
                        const mensaje = response.data.ok;
                        console.log(mensaje)


                        if (this.ArraysEquals(this.fileListEdit,this.FileList)===true) {
                            const response2 = await AdminApi.DeleteFileProject(this.$route.params.id);
                            const mensaje2 = response2.data.ok;
                            console.log(mensaje2)
                        }
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

                                for (let i = 0; i < this.fileListEdit.length; i++) {
                                    if (this.fileListEdit[i].File_Name === item.File_Name) {
                                        fileAlreadyExists = true;
                                        break; // Si el archivo ya existe, no es necesario seguir buscando
                                    }
                                }

                                if (!fileAlreadyExists) {
                                    // Agregar el archivo al proyecto
                                    const addFile = {
                                        "File_ID": 0,
                                        "File_Name": this.idProyecto + "_" + DateFormatwithoutSpace + "_" + item.File_Name,
                                        "File_Path": "",
                                        "File_Type": item.File_Type,
                                        "File_Size": 5,
                                        "Creation_Date": "2023-09-30T13:47:37.9361279-06:00"
                                    };
                                    this.listNewFileEdit.push(addFile);

                                }
                            }
                            try {


                                for (const item of this.listNewFileEdit) {
                                    const response = await AdminApi.PostFile(item);
                                    const mensaje = response.data.ok;
                                    console.log(mensaje)

                                    const idFileLastInsert = await AdminApi.GetLastInsertId();
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
                                console.error('Error al agregar usuario al proyecto:', error);
                            }

                            this.$swal({ icon: 'success', text: 'Proyecto modificado con éxito' });
                            setTimeout(() => {
                                this.$router.push({ name: 'Inicio' });
                            }, 2000);
                        } else {
                            this.$swal({ icon: 'success', text: 'Proyecto modificado con éxito' });
                            setTimeout(() => {
                                this.$router.push({ name: 'Inicio' });
                            }, 2000);
                        }




                    } catch (error) {
                        console.error('Error al cargar los proyectos desde la API:', error);
                    }

                }

            }
            else {
                this.$swal({ icon: 'warning', text: 'No fue posible modificar el registro' });
            }
        }

        ,

        addListUser: async function () {

            if (this.selectedUser) {

                const selectedUserObject = JSON.parse(this.selectedUser);

                const isUserInList = this.UserlistAdd.some(item => item.usu_Login === selectedUserObject.usu_Login);

                if (!isUserInList) {

                    this.UserlistAdd.push({
                        usu_Login: selectedUserObject.usu_Login,
                        usu_Nombre: selectedUserObject.usu_Nombre
                    });
                }
                else {
                    this.$swal({ icon: 'warning', text: 'No se puede agregar dos veces el mismo usuario' });
                }


                this.selectedUser = null
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



        },

    ArraysEquals: function (array1, array2) {
    
            for (let i = 0; i < array1.length; i++) {
                if (array1[i] !== array2[i]) {
                    return false;
                }
            }

            return true;
        }

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
</style>