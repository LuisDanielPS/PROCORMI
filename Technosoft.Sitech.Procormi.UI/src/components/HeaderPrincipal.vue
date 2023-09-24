<template>
    <div>
        <header class="header bg-azul">
            <nav class="gridEncabezado">
                <div style="padding-top: 10px; text-align: center; max-width: 17em; min-width: 15em;" v-on:click="CerrarMenus()">
                    <router-link :to="{ name: 'Inicio' }">
                        <img src="/images/MilleniumLogoBlanco.png" class="default-logo ml-4 imagenResponsive" height="60" width="60">
                    </router-link>
                </div>
                <ul>
                    <li class="row">

                        <div class="row col-12 justify-content-end botonesSesion">
                            <div class="col-1">
                                <button style="float: right; position: relative;" class="nav-toggle" @click.prevent="DesplegarMenuAplicaciones()">
                                    <i class="fas fa-bell"></i>
                                    <span class="notification-badge">1</span>
                                </button>
                            </div>

                            <div class="col-1 botonAplicaciones">
                                <button style="float: right;" class="nav-toggle nav-toggleColor" @click.prevent="DesplegarMenu()">
                                    <i class="fas fa-user-circle"></i>
                                </button>
                            </div>
                        </div>

                    </li>
                </ul>
                <ul class="nav-menu"
                    :class="{
                        'nav-menu_visible': menuDesplegableDerecho
                    }">
                    <div class="nav-link textoBlanco" v-if="AgregarPublicacion" style="padding-top: 25px;">
                        <p style="cursor: default;"><a class="text-gradient-yellow-orange-black" style="font-size: 16px;"><b>Usuario: {{recuperarUsuNombre()}}</b></a></p>
                    </div>
                    <div class="nav-link textoBlanco" v-if="AgregarPublicacion" style="padding-top: 25px;">
                        <p style="cursor: default;"><a class="text-gradient-yellow-orange-black" style="font-size: 16px; position: relative; top: -20px;"><b>Perfil: {{recuperarUsuTipo()}}</b></a></p>
                        <div style="max-width: 100%;"><hr /></div>
                    </div>
                    <div class="nav-link" style="color: white; padding-top: 25px;">
                        <p style="cursor: default;">Acerca de Procormi: Versión 1.0</p>
                    </div>
                    <br />
                    <!--<li v-if="esEncuesta" @click.prevent="cambiarAplicacion()" class="nav-link textoBlanco" style="padding-top: 20px;">
                        <router-link role="button" :to="{ name: 'Inicio' }" class="nav-link textoBlanco" style="font-size: 17px;">Proyectos&nbsp;&nbsp;<i class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                        <br />
                    </li>-->
                    <div style="display: flex; align-items: center; justify-content: center;">
                        <div class="nav-link textoBlanco">
                            <a role="button" v-on:click="cerrarSesion" class="textoBlanco" style="font-size: 17px; text-decoration: none;">Cerrar Sesión&nbsp;&nbsp;<i class="fas fa-sign-out-alt"></i></a>
                        </div>
                    </div>

                </ul>

                <ul class="nav-menuAplicaciones"
                    :class="{
                        'nav-menuAplicaciones_visible': menuDesplegableAplicaciones
                    }">
                    <div class="nav-link textoBlanco" v-if="AgregarPublicacion" style="padding-top: 25px;">
                        <p style="cursor: default;"><a class="text-gradient-yellow-orange-black" style="font-size: 16px;"><b>Notificaciones</b></a></p>
                    </div>
                    <div class="nav-link textoBlanco" style="padding-top: 7px;">
                        <div style="max-width: 100%;"><hr /></div>
                    </div>
                </ul>
            </nav>
        </header>

        <button hidden type="button" id="abrirModal" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalDocumentos">Open modal</button>

    </div>
</template>

<script scoped>
import { /*mapState, */mapActions } from 'vuex';
import AdminApi from '@/Api/Api';
import Cookies from 'js-cookie';
import router from '@/router/index'

export default {
    name: 'HeaderPrincipal',

    components: {
    },

    /*props: {
        cuadroLoaderPrincipal: null
    },*/

    data() {
        return {
            elementosPorPaginaPrincipal: 4,
            menuDesplegableDerecho: false,
            menuDesplegableAplicaciones: false,

            ListaPublicacionTemporal: [],
            pClave: '',

            AgregarDepartamento: false,
            AgregarCategoria: false,
            AgregarSubcategoria: false,
            AgregarUsuario: false,
            AgregarPublicacion: false,
            Login: false,
            resultadoBusqueda: false,

            FiltroSubcategoria: 400,
            ListaDepartamentos: [],
            ListaCategorias: [],
            ListaSubcategorias: [],

            Filtro: {
                departamento: 400,
                categoria: 400,
                subcategoria: 400,
            },
            
            esEncuesta: false,
            esProyecto: true,
            mostrarFiltro: false,

            FiltroActicormi: {
            fechaI: "",
            fechaF: "",
            estado: "P",
            usuario: "",
            },

        }
    },

    methods: {

        cambiarAplicacion: function () {
            this.esProyecto = !this.esProyecto
            this.esEncuesta = !this.esEncuesta
        },

        limpiarFiltro: function () {
            document.getElementById("pClaveInput").value = ""
            this.limpiarPalabra()
        },

        async DesplegarMenu() {
            await this.CerrarMenuAplicaciones();
            this.menuDesplegableDerecho = !this.menuDesplegableDerecho
            this.$root.cerrarMenuFiltros.call();
        },

        CerrarMenu: function () {
            this.menuDesplegableDerecho = false
        },

        async DesplegarMenuAplicaciones() {
            await this.CerrarMenu();
            this.menuDesplegableAplicaciones = !this.menuDesplegableAplicaciones
            this.$root.cerrarMenuFiltros.call();
        },

        CerrarMenuAplicaciones: function () {
            this.menuDesplegableAplicaciones = false
        },

        CerrarMenus: function () {
            this.menuDesplegableDerecho = false
            this.menuDesplegableAplicaciones = false
        },

        ...mapActions([
            'AsignarPublicaciones',
        ]),

        guardarPalabra(PalabraCookie) {
            Cookies.set("palabraClave", PalabraCookie)
        },

        limpiarPalabra: function () {
            Cookies.set("palabraClave", "")
        },

        cerrarSesion: function () {
            Cookies.remove("usuarioLogin");
            Cookies.remove("tipoU");
            Cookies.remove("nombreUsu")
            Cookies.remove("palabraClave")
            this.$root.validarLoginFooter.call();
            router.push({ name: 'Login' })
        },

        recuperarUsuNombre() {
            return Cookies.get("nombreUsu")
        },

        recuperarUsuLog() {
            return Cookies.get("usuarioLogin")
        },

        recuperarUsuTipo() {
            return Cookies.get("tipoU")
        },

        recuperarUsuPass() {
            return Cookies.get("pass")
        },

        QuitarHTML(html) {
            var temporal = document.createElement('div')
            temporal.innerHTML = html
            return temporal.textContent || temporal.innerText || ""
        },

        verificarLog: function () {
            let login = this.recuperarUsuLog()
            let role = this.recuperarUsuTipo()
            let nombre = this.recuperarUsuNombre()
            if (role == "Administrador" && (nombre !== undefined && nombre !== null && nombre !== '')) {
                this.AgregarPublicacion = true,
                this.AgregarDepartamento = true
                this.AgregarCategoria = true
                this.AgregarSubcategoria = true
                this.AgregarUsuario = true
            } else if (role == "Supervisor" && (nombre !== undefined && nombre !== null && nombre !== '')) {
                this.AgregarPublicacion = true
                this.AgregarCategoria = true
                this.AgregarSubcategoria = true
            } else if (role == "Operador" && (nombre !== undefined && nombre !== null && nombre !== '')) {
                this.AgregarPublicacion = true
            }
            if (login == null || (nombre == undefined || nombre == null || nombre == '')) {
                this.Login = true
            }
        },

        /*ListarPublicacionPaginadoCelular: async function (dpto, cat, sCat) {
            await this.$root.ListarPublicacionPaginado(dpto, cat, sCat, 1, 0);
        },*/

        ListarDepartamento: function () {
            AdminApi.GetAdminListarDepartamentos()
                .then(response => {
                    if (response.data != null) {
                        response.data.obj.forEach(element => {
                            this.ListaDepartamentos.push({
                                id_gen_departamento: element.id_gen_departamento,
                                nombre: this.cortarNombre(element.nombre),
                                correo: element.correo
                            })
                        })
                    }
                })
        },

        ListarCategoria: function () {
            AdminApi.GetAdminListarCategorias()
                .then(response => {
                    if (response.data != null) {
                        this.ListaCategorias = []
                        response.data.obj.forEach(element => {
                            this.ListaCategorias.push({
                                id_know_categoria: element.id_know_categoria,
                                id_gen_departamento: element.id_gen_departamento,
                                know_categoria_nombre: this.cortarNombre(element.know_categoria_nombre),
                            })
                        })
                    }
                })
        },

        ListarSubcategoria: function () {
            AdminApi.GetAdminListarSubcategorias()
                .then(response => {
                    if (response.data != null) {
                        this.ListaSubcategorias = []
                        response.data.obj.forEach(element => {
                            this.ListaSubcategorias.push({
                                id_know_subcategoria: element.id_know_subcategoria,
                                id_know_categoria: element.id_know_categoria,
                                know_subcategoria_nombre: this.cortarNombre(element.know_subcategoria_nombre),
                            })
                        })
                    }
                })
        },

        FiltrarCategorias: function (dpto) {
            if (dpto == "" || dpto == null) {
                dpto = 400
            }
            AdminApi.selectCategoria(dpto)
                .then(response => {

                    this.LimpiarSubcategorias()

                    if (dpto == 400) {
                        this.ListarCategoria()
                    } else if (response.data != null) {
                        this.ListaCategorias = response.data.obj
                    }
                })
        },

        FiltrarSubcategorias: function (cat, dpto) {

            if (cat == "" || cat == null) {
                cat = 400
            }
            if (dpto == "" || dpto == null) {
                dpto = 400
            }

            AdminApi.selectSubcategoria(cat, dpto)
                .then(response => {

                    if (cat == 400 && dpto == 400) {
                        this.ListarSubcategoria()
                    } else if (response.data != null) {
                        this.ListaSubcategorias = response.data.obj
                    }
                })
        },

        LimpiarCategorias: function () {
            this.ListaCategorias = [],
                this.Filtro.categoria = 400
            this.ListaSubcategorias = [],
                this.Filtro.subcategoria = 400
        },

        LimpiarSubcategorias: function () {
            this.ListaSubcategorias = [],
                this.Filtro.subcategoria = 400
        },

        LimpiarFiltro: function () {
            Cookies.set("dpto", 400)
            Cookies.set("cat", 400)
            Cookies.set("sCat", 400)
            this.Filtro.departamento = 400
            this.Filtro.categoria = 400
            this.Filtro.subcategoria = 400
        },

        cortarNombre(valor) {
            var limite = 25
            if (valor) {
                return valor.length > 25 ? valor.substring(0, limite) + '...' : valor
            }
        },

        validarFiltro: function() {
            const url = window.location.href;
            const partesURL = url.split('/');
            const ultimaParte = partesURL[partesURL.length - 1];

            if(ultimaParte == "Inicio" || ultimaParte == "Encuestas" || ultimaParte == "Sprints" || ultimaParte == "Tareas"){
                this.mostrarFiltro = true;
            } else {
                this.mostrarFiltro = false;
            }
        }

    },

    /*computed: {
        ...mapState(
            ["ListaPublicaciones"]
        )
    },*/

    mounted: async function () {
        this.$root.limpiarFiltro = this.limpiarFiltro;
        this.$root.CerrarMenu = this.CerrarMenu;
        this.$root.CerrarMenuAplicaciones = this.CerrarMenuAplicaciones;
        this.$root.cerrarSesionGeneral = this.cerrarSesion;
        //this.$root.designarAplicacionHeaderPrincipal = this.designarAplicacion;
    },

    created: async function () {
        await this.verificarLog();
        await this.validarFiltro();
        /*await this.designarAplicacion();
        this.ListarDepartamento();
        this.ListarCategoria();
        this.ListarSubcategoria();
        this.FiltrarCategorias();
        this.FiltrarSubcategorias();*/
    }

}

</script>

<style scoped>

    .textoBlanco {
        color: #ffffff;
        font-size: medium;
    }

        .textoBlanco:hover {
            background: linear-gradient(to right, #F7FF0A 0%, #CF8E2E 100%);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
        }

    .filtro {
        min-width: 9em;
        height: 3em;
        background: #000;
        border-radius: 0.5em;
    }

        .filtro button {
            background-color: #000;
            border-radius: 0.5em;
            border: none;
        }

        .filtro:hover {
            background: #000;
            border: 1px solid #000;
        }

    @media screen and (min-width: 501px) {
        .menuLateralCelularScoped {
            display: none;
        }
    }

    @media screen and (max-width: 767px) {
        .botonesSesion{
            position: relative;
            top: -10px;
        }
    }

    @media screen and (max-width: 400px) {
        .buscador{
            margin-right: 25px;
        }

        .botonAplicaciones{
            margin-left: 20px;
        }

        .imagenResponsive{
            display: none;
        }
    }
    
    @media screen and (max-width: 950px) {
        .botonAplicaciones{
            margin-left: 20px;
        }
    }

    body {
        overflow-x: hidden !important;
    }

    .header {
        height: 60px;
    }

    .nav-menu {
        flex-direction: column;
        align-items: center;
        list-style: none;
        background-color: #0a3a66;
        position: absolute;
        right: 0;
        top: 60px;
        width: 25%;
        text-align: center;
        min-height: 50vh;
        overflow-y: auto;
        z-index: 3;
        display: none;
        border-bottom-left-radius: 10px;
        border-bottom-right-radius: 10px;
    }

    .nav-menuAplicaciones {
        flex-direction: column;
        align-items: center;
        list-style: none;
        background-color: #0a3a66;
        position: absolute;
        right: 0;
        top: 60px;
        width: 25%;
        text-align: center;
        min-height: 50vh;
        overflow-y: auto;
        z-index: 3;
        display: none;
        border-bottom-left-radius: 10px;
        border-bottom-right-radius: 10px;
    }

    @media screen and (max-width: 900px) {
        .nav-menu {
            flex-direction: column;
            align-items: center;
            list-style: none;
            background-color: #0a3a66;
            position: absolute;
            right: 0;
            top: 60px;
            width: 200px;
            text-align: center;
            overflow-y: auto;
            z-index: 3;
            display: none;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        .nav-menuAplicaciones {
            flex-direction: column;
            align-items: center;
            list-style: none;
            background-color: #0a3a66;
            position: absolute;
            right: 0;
            top: 60px;
            width: 200px;
            text-align: center;
            overflow-y: auto;
            z-index: 3;
            display: none;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
        }
    }

    @media screen and (max-width: 400px) {
        .nav-menu {
            flex-direction: column;
            align-items: center;
            list-style: none;
            background-color: #0a3a66;
            position: absolute;
            right: 0;
            top: 60px;
            width: 50%;
            text-align: center;
            min-height: 89vh;
            max-height: 89vh;
            overflow-y: auto;
            z-index: 3;
            display: none;
            border: none;
        }

        .nav-menuAplicaciones {
            flex-direction: column;
            align-items: center;
            list-style: none;
            background-color: #0a3a66;
            position: absolute;
            right: 0;
            top: 60px;
            width: 50%;
            text-align: center;
            min-height: 89vh;
            max-height: 89vh;
            overflow-y: auto;
            z-index: 3;
            display: none;
            border: none;
        }
    }

    .nav-toggle {
        display: block;
    }

        .nav-toggleColor:hover {
            display: block;
            background: linear-gradient(to right, #F7FF0A 0%, #CF8E2E 100%);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
        }

    .nav-menu_visible {
        display: block;
    }

    .nav-menuAplicaciones_visible {
        display: block;
    }

    @media screen and (max-width: 400px) {

        .nav-menu {
            flex-direction: column;
            align-items: center;
            list-style: none;
            background-color: #0a3a66;
            position: absolute;
            right: 0;
            top: 60px;
            min-width: 50%;
            text-align: center;
            min-height: 91.7vh;
            overflow-y: auto;
            left: 100%;
            z-index: 4;
        }

        .nav-menuAplicaciones {
            flex-direction: column;
            align-items: center;
            list-style: none;
            background-color: #0a3a66;
            position: absolute;
            right: 0;
            top: 60px;
            min-width: 50%;
            text-align: center;
            min-height: 91.7vh;
            overflow-y: auto;
            left: 100%;
            z-index: 4;
        }

        .nav-toggle {
            display: block;
        }

            .nav-toggleColor:hover {
                display: block;
                background: linear-gradient(to right, #F7FF0A 0%, #CF8E2E 100%);
                -webkit-background-clip: text;
                -webkit-text-fill-color: transparent;
            }

        .nav-menu_visible {
            left: 50%;
            transition: left 0.3s;
        }

        .nav-menuAplicaciones_visible {
            left: 50%;
            transition: left 0.3s;
        }
    }

    .sitioMenu:hover{
        cursor: pointer;
    }

@media screen and (min-width: 400px){
    .posicion1 {
        z-index: 1;
        min-height: 85vh;
        max-height: 99.5vh;
    }
}

.notification-badge {
    display: inline-block;
    background-color: red;
    color: white;
    font-size: 12px;
    width: 18px;
    height: 18px;
    line-height: 18px;
    text-align: center;
    border-radius: 50%;
    position: absolute;
    top: 30px;
    right: 45px;
}

.notification-badge:hover {
    display: inline-block;
    background-color: red;
    color: white;
    font-size: 15px;
    width: 21px;
    height: 21px;
    line-height: 21px;
    text-align: center;
    border-radius: 50%;
    position: absolute;
    top: 30px;
    right: 45px;
}

@media screen and (max-width: 400px){
    .notification-badge {
        display: inline-block;
        background-color: red;
        color: white;
        font-size: 12px;
        width: 18px;
        height: 18px;
        line-height: 18px;
        text-align: center;
        border-radius: 50%;
        position: absolute;
        top: 30px;
        right: 30px;
    }
}

</style>