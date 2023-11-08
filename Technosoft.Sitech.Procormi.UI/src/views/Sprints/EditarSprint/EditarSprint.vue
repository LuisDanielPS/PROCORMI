<template>
    <div class="vistaPrincipal fondoGeneral">
        <HeaderPrincipal />
        <div>
            <div class="col-12" style="margin-top: 30px;">
                <h4 style="text-align: center; font-size: 25px; color: #0a3a66;">Editar Sprint</h4>
                <br />
                <div>
                    <div>
                        <form class="estiloForm">
                            <div style="padding: 50px;">
                                <div>
                                    <label class="margin-15px-bottom text-black">Nombre<span style="color: red;"> *</span></label>
                                    <input maxlength="50" class="small-input inputsGeneral" type="text" required>
                                </div>
                                <br />
                                <div>
                                    <label class="margin-15px-bottom text-black">Fecha de Inicio<span style="color: red;"> *</span></label>
                                    <input class="small-input inputsGeneral" type="date" required>
                                </div>
                                <br />
                                <div>
                                    <label class="margin-15px-bottom text-black">Fecha de Finalización<span style="color: red;"> *</span></label>
                                    <input class="small-input inputsGeneral" type="date" required>
                                </div>
                                <br />
                                <div>
                                    <label>Usario asignado<span style="color: red;"> *</span></label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select required name="usuarios" id="usuarios" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option :value="null">Seleccione una opción</option>
                                            <option v-for="item in listUsers" :key="item.usu_Login"
                                                :value="item.usu_Login">{{ item.usu_Nombre }}</option>
                                        </select>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="BotonesJ">
                                <div><button class="btn btn-success" style="font-size: 16px; min-width: 100px;">Guardar</button></div>
                                <br/>
                                <div><a href="/Sprints" class="btn btn-danger" style="font-size: 16px; min-width: 100px;">Cancelar</a></div>
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
import 'quill/dist/quill.snow.css'
import Cookies from 'js-cookie';
import AdminApi from '@/Api/Api';

export default {

    components: {
        HeaderPrincipal
    },

    data() {
        return {

            EditarSprint: {
                Id_sprint : "",
                Sprint_Name : "",
                Start_Date : "",
                End_Date : "",
                User_Login: "",
            },

            ActionEN: {
                Action_Description: "",
                Action_User: ""
            },

            SprintIdEdit : null,
            SprintNameEdit : '',
            SprintEditStartDate: '',
            SprintEditEndDate: '',
            SprintEditUserLogin: '',
        }
    },

    methods: {

        loadFormEdit: async function () {

            try {
                      const response = await AdminApi.GetSprint(this.idSprint);
                      const sprintData = response.data.obj;

                    this.EditarSprint = {
                        Id_sprint: sprintData.Id_sprint,
                        Sprint_Name: sprintData.Sprint_Name,
                        Start_Date: sprintData.Start_Date,
                        End_Date: sprintData.End_Date,
                        User_Login: sprintData.User_Login
                    };

            }catch (error) {
                this.$swal('Error al cargar los la información para editar', error);
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
        await this.verificarLog();
        await this.$root.validarLoginFooter.call();
        await this.loadFormEdit();
    }

}
</script>

<style scoped>

.inputsGeneral{
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

.fondoGeneral{
    background: rgba(238,244,255,1);
    min-height: calc(100vh - 50px);
}

.estiloForm{
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