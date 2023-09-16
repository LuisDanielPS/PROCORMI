<template>
    <div class="vistaPrincipal" style="min-height: calc(100vh - 50px);">
        <!--<HeaderPrincipal :cuadroLoaderPrincipal="$refs.cuadroLoader" />-->
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">

                <div class="row w-100 listadoGeneral">
                    <div class="w-100 vld-parent col-12" style="min-height: 85vh;">

                        <!--Lista de reportes /-->

                        <div class="row">
                            <div class="col-md-12" style="padding:15px;">
                                <div class="card" style="border: none;" ref="cuadroLoader">
                                    <div class="encabezado">
                                        <ul style="text-align: left;">
                                            <router-link class="li agregarBlt" role="button" :to="{ name: 'Inicio' }"><span class="fas fa-arrow-left"></span> <span class="linkResponsiveCelular"> Inicio</span></router-link>
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
                                                        <button type="button" class="btn btn-primary" style="margin-left: 5px;">
                                                            <span class="fas fa-file-download" b-tooltip.hover title="PDF"></span>
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
                                                        <button type="button" class="btn btn-primary" style="margin-left: 5px;">
                                                            <span class="fas fa-file-download" b-tooltip.hover title="PDF"></span>
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
                                                        <button type="button" class="btn btn-primary" style="margin-left: 5px;">
                                                            <span class="fas fa-file-download" b-tooltip.hover title="PDF"></span>
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
                                                        <button type="button" class="btn btn-primary" style="margin-left: 5px;">
                                                            <span class="fas fa-file-download" b-tooltip.hover title="PDF"></span>
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
//import AdminApi from '@/Api/Api';

export default {

    components: {
        HeaderPrincipal//, MenuLateral
    },

    data() {
        return {

        }
    },

    methods: {

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
    background: rgb(2,15,41);
    background: linear-gradient(90deg, rgba(2,15,41,1) 0%, rgba(2,15,41,1) 50%, rgba(10,58,102,1) 100%);
}

/*@media screen and (min-width: 901px) {

    .filtrosCelular{
        display: none;
    }
}*/

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
    padding: 25px;
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
    background-color: #020f29;
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