<template>
    <div class="vistaPrincipal">
        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">

                <!--Menú Lateral /-->

                <div class="posicion1 menuLateralCelular">
                    <div class="d-flex col-3">
                        <div class="col-8" style="min-width: 15em;">
                            <br />
                            <div>
                                <div class="row textoBlanco" style="padding-bottom: 5px;">
                                    <div class="col-12" style="color: white;"><hr /></div>
                                </div>
                                <div class="row justify-content-center" style="margin-left: 5px;">
                                    <li class="col-8 textoBlanco botonEncuestas">
                                        <router-link role="button" :to="{ name: 'Inicio' }" class="textoBlanco textoEncuestas" exact-active-class="active-link">Proyectos&nbsp;&nbsp;<i class="text-white fas fa-project-diagram" style="cursor: pointer; font-size: 14px;"></i></router-link>
                                    </li>
                                </div>
                                <div class="row textoBlanco" style="padding-top: 5px; padding-bottom: 5px;">
                                    <div class="col-12" style="color: white;"><hr /></div>
                                </div>
                                <div class="row justify-content-center" style="margin-left: 5px;">
                                    <li class="col-8 textoBlanco botonEncuestas">
                                        <router-link role="button" :to="{ name: 'Encuestas' }" class="textoBlanco textoEncuestas" exact-active-class="active-link">Encuestas&nbsp;&nbsp;<i class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                                    </li>
                                </div>
                                <div class="row textoBlanco" style="padding-top: 5px; padding-bottom: 5px;">
                                    <div class="col-12" style="color: white;"><hr /></div>
                                </div>
                                <div class="row justify-content-center" style="margin-left: 5px;">
                                    <li v-show="showElement" class="col-8 textoBlanco botonEncuestas">
                                        <router-link role="button" :to="{ name: 'Reportes' }" class="textoBlanco textoEncuestas" exact-active-class="active-link">Reportes&nbsp;&nbsp;<i class="text-white far fa-file-alt" style="cursor: pointer;"></i></router-link>
                                    </li>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Menú Lateral /-->

            </div>
        </div>
    </div>
</template>

<script>
import Cookies from 'js-cookie';
//import AdminApi from '@/Api/Api';

export default {

    components: {
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
            showElement:true
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

        recuperarUsuLog() {
            return Cookies.get("usuarioLogin")
        },

        recuperarUsuTipo() {
            return Cookies.get("tipoU")
        },

        recuperarUsuNombre() {
            return Cookies.get("nombreUsu")
        },
        verifyUserType:function(){
       
            let usutipo = this.recuperarUsuTipo()

            if (usutipo === "Operador") {
                this.showElement=false
            }
        }

    },

    mounted: function() {
    },

    created: async function () {
        await this.verifyUserType();
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
    min-height: 107vh;
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
    background-color: rgba(10,58,102,1);
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
    margin-top: 25px;
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

    .botonEncuestas:hover{
        min-width: 12.4rem;
        background-color: #15518a;
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