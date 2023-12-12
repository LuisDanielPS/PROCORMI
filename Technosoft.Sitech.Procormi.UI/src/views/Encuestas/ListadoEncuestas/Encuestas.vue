<template>
    <div class="vistaPrincipal">
        <!--<HeaderPrincipal :cuadroLoaderPrincipal="$refs.cuadroLoader" />-->
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">

                <!--Menú Lateral /-->

                <MenuLateral />

                <!--Menú Lateral /-->

                <!--Modal eliminar Encuesta-->

                <div class="modal fade" id="eliminarEncuesta" tabindex="-1" aria-labelledby="eliminarEncuesta" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar Encuesta</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea eliminar la encuesta?</p>
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

                <!--Modal eliminar Encuesta-->

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
                            <div class="col-8 textoBlanco" style="text-align: center; min-width: 150px;">
                                <router-link role="button" :to="{ name: 'Inicio' }" class="textoBlanco textoEncuestas" style="text-decoration: none;" exact-active-class="active-link">Proyectos&nbsp;&nbsp;<i class="text-white fas fa-project-diagram" style="cursor: pointer; font-size: 14px;"></i></router-link>
                            </div>
                        </div>
                        
                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center; min-width: 150px;">
                                <router-link role="button" :to="{ name: 'Encuestas' }" class="textoBlanco textoEncuestas" style="text-decoration: none;" exact-active-class="active-link">Encuestas&nbsp;&nbsp;<i class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center;">
                                <router-link role="button" :to="{ name: 'Reportes' }" class="textoBlanco textoEncuestas" style="text-decoration: none;" exact-active-class="active-link">Reportes&nbsp;&nbsp;<i class="text-white far fa-file-alt" style="cursor: pointer;"></i></router-link>
                            </div>
                        </div>

                        <div style="text-align: center; font-size: large; padding-top: 40px; cursor: pointer; margin-left: 20px;" v-if="filtroDesplegar" v-on:click="desplegarFiltros()">
                            <a class="text-white fas fa-angle-up" style="text-decoration: none;"></a>
                        </div>

                    </div>

                    <!--Filtros responsive /-->

                    <div class="w-100 vld-parent col-12" style="min-height: 85vh;">

                        <!--Lista de encuestas /-->

                        <div class="row" style="padding:15px; min-height: 95vh; padding-right: 45px; position:relative;">
                            <div class="col-12 estiloTabla tableHeight" style="padding:10px;">
                                <div class="card" style="border: none;" ref="cuadroLoader">
                                    <div class="encabezado">
                                        <div style="text-align: left;">
                                            <div>
                                            </div>
                                        </div>
                                        <div style="text-align: center; padding-top: 10px; cursor: default;">
                                            <h4>Listado de Encuestas</h4>
                                        </div>
                                        <ul style="text-align: right;">
                                            <router-link class="li agregarBlt agregarResponsive" role="button" :to="{ name: 'CrearEncuesta' }"><span class="fas fa-plus"></span> Crear Encuesta</router-link>
                                            <router-link class="li agregarBlt agregarResponsivePlus" role="button" :to="{ name: 'CrearEncuesta' }"><span class="fas fa-plus"></span></router-link>
                                        </ul>
                                    </div>

                                    <div class="row">
                                        <div class="col-5" style="min-width: 105px;">
                                            <div>
                                                <a class="text-black fas fa-calendar-alt"></a>
                                                <label class="text-black p-3 Td">Fecha</label>
                                            </div>
                                            <input type="date" id="fechaInicio" class="diseñoSelectLateral"
                                                style="cursor: pointer; border-radius: 5px;" v-model="Filtros.fecha">
                                        </div>

                                        <div class="col-6" style="min-width: 95px;">
                                            <div>
                                                <a class="text-black fas fa-pen-square" style="text-decoration: none;"></a>
                                                <label class="text-black p-3 Td">Palabra</label>
                                            </div>
                                            <div>
                                                <input @keyup="aplyFilter(Filtros.fecha, Filtros.palabra)" autocomplete="off" maxlength="70" class="diseñoSelectLateral"
                                                    type="search" id="pClaveInput" placeholder="Buscar"
                                                    v-model="Filtros.palabra">
                                            </div>
                                        </div>

                                        <div class="col-1">
                                            <div>
                                                <label class="text-white p-3 Td">.</label>
                                            </div>
                                            <div>
                                                <button type="button" class="btn btn-success"
                                                    @click="aplyFilter(Filtros.fecha, Filtros.palabra)"><span
                                                        class="fas fa-search"></span></button>
                                            </div>
                                        </div>

                                    </div>

                                    <div v-if="paginateData.length == 0" class="sinResultadosAct">
                                        <p>No hay encuestas para mostrar</p>
                                    </div>

                                    <div v-if="paginateData.length > 0" class="contenidoTabla">
                                        <table class="table table-stryped" style="text-align: center;">
                                            <thead>
                                                <tr>
                                                    <th class="col-3" style="min-width: 75px;">Nombre</th>
                                                    <th class="col-4" style="min-width: 150px;">Descripción</th>
                                                    <th class="col-2" style="min-width: 125px;">Fecha de creación</th>
                                                    <th class="col-2" style="min-width: 125px;">Opciones</th>
                                                </tr>
                                            </thead>
                                            <tbody style="font-size: large;">
                                                <tr v-for="poll in paginateData" :key="poll.Id_Poll">
                                                    <td>{{ $filters.CortarTexto(poll.Name, 20) }}</td>
                                                    <td><p>{{ QuitarHTML($filters.CortarTexto(poll.Description, 30)) }}</p></td>
                                                    <td>{{ $filters.FormatearFecha(poll.Creation_Date) }}</td>
                                                    <td class="text-white">
                                                        <button class="btn btn-primary" role="button" b-tooltip.hover title="Ver Encuesta" @click="VerEncuesta(poll.Id_Poll)">
                                                            <span class="fas fa-eye"></span>
                                                        </button>
                                                        <button style="margin-left: 5px;" type="button" b-tooltip.hover title="Editar Encuesta" class="btn btn-warning" @click="EditarEncuesta(poll.Id_Poll)">
                                                            <span class="fas fa-pen text-white"></span>
                                                        </button>
                                                        <button type="button" b-tooltip.hover title="Eliminar Encuesta" class="btn btn-danger" style="margin-left: 5px;" @click="DeletePoll(poll.Id_Poll)">
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

                        <!--Lista de encuestas /-->

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
import CryptoJS from 'crypto-js';

export default {

    components: {
        HeaderPrincipal, MenuLateral
    },

    data() {
        return {
            filtroDesplegar: false,

            Filtros: {
                fecha: "",
                palabra: ""
            },

            pollList: [],

            pageElements: 10,
            actualPage: 1,
            pageNumeration: [],
            paginate: true,
            paginateData: [],

            ActionEN: {
                Action_Description: "",
                Action_User: ""
            },

        }
    },

    methods: {

        GetAllPolls: async function () {
            this.actualPage = 1

            try {
                if (this.pollList.length == 0) {
                    await AdminApi.GetAllPolls()
                        .then(response => {
                            if (response.data != null) {
                                response.data.obj.forEach(element => {
                                    this.pollList.push({
                                        Id_Poll: element.Id_Poll,
                                        Name: element.Name,
                                        Description: element.Description,
                                        Creation_Date: element.Creation_Date
                                    })
                                })
                            }
                        })


                    this.paginateData = [];

                    if (this.pollList.length < this.pageElements) {
                        for (let index = 0; index < this.pollList.length; index++) {
                            this.paginateData.push(this.pollList[index]);
                        }
                    } else {
                        for (let index = 0; index < this.pageElements; index++) {
                            this.paginateData.push(this.pollList[index]);
                        }
                    }
                } else {
                    this.paginateData = [];
                    if (this.pollList.length < this.pageElements) {
                        for (let index = 0; index < this.pollList.length; index++) {
                            this.paginateData.push(this.pollList[index]);
                        }
                    } else {
                        for (let index = 0; index < this.pageElements; index++) {
                            this.paginateData.push(this.pollList[index]);
                        }
                    }
                }
            } catch (error) {
                console.error('Error al cargar los proyectos desde la API:', error);
            }

        },

        aplyFilter: async function (date, word) {
            const response = await AdminApi.GetAllPolls();
            const tempPollList = response.data.obj;
            this.pollList = tempPollList;

            const filteredPolls = [];
            let success = false;

            for (const poll of this.pollList) {
                const matchesDate = (!date || poll.Creation_Date.includes(date));
                const matchesWord = (!word || poll.Name.toLowerCase().includes(word.toLowerCase()) || poll.Description.toLowerCase().includes(word.toLowerCase()));

                if (matchesDate && matchesWord) {
                    filteredPolls.push(poll);
                    success = true;
                }
            }

            if ((!success && (date || word))) {
                this.paginateData = []
                this.paginate = false
                this.Filtros.fecha = "";
                return
            }

            this.pollList = filteredPolls;
            await this.GetAllPolls();
            await this.cutPages();
            this.actualPage = 1;
            this.Filtros.fecha = "";
        },

        EditarEncuesta: function(EncuestaID) {
            this.$router.push({
                name: "EditarEncuesta",
                params: {
                    id: EncuestaID,
                }
            })
        },

        DeletePoll: async function (id) {
            this.$swal({
                position: 'center',
                text: '¿Seguro de que desea eliminar la encuesta?',
                showDenyButton: true,
                confirmButtonColor: 'green',
                confirmButtonText: `Aceptar`,
                denyButtonText: `Cancelar`,
            }).then(async (result) => {
                if (result.isConfirmed) {
                    let loader = this.$loading.show({
                        container: this.$refs.cuadroLoader,
                        opacity: 1
                    })
                    await AdminApi.DeletePoll(id)
                            .then(response => {
                                if (response.data != null) {
                                    this.$swal.fire({
                                        position: 'center',
                                        text: response.data.msg,
                                        showConfirmButton: false,
                                        timer: 3000
                                    })
                                }
                            })

                    this.ActionEN.Action_Description = "Eliminó la encuesta #" + id
                    this.ActionEN.Action_User = this.recuperarUsuLog();
                    await AdminApi.PostNewAction(this.ActionEN)

                    this.pollList = []
                    await this.GetAllPolls();
                    await this.cutPages();
                    loader.hide()
                }
            })
        },

        VerEncuesta: function(id) {
            var idEncripted = this.Encrypt(id)
            this.$router.push({
                name: "FormularioCliente",
                params: { encuesta: idEncripted }
            })
        },

        Encrypt: function (value) {
            const clave = CryptoJS.enc.Base64.parse("prmDMvIvPNlrmcsgLM1/c34GHjA7D2P2");
            const iv = CryptoJS.enc.Utf8.parse("cmprmasr");

            const valueAsString = value.toString();

            const encrypted = CryptoJS.TripleDES.encrypt(valueAsString, clave, {
                iv: iv
            });

            return encrypted.toString();
        },

        Decrypt: function (encryptedValue) {
            const clave = CryptoJS.enc.Base64.parse("prmDMvIvPNlrmcsgLM1/c34GHjA7D2P2");
            const iv = CryptoJS.enc.Utf8.parse("cmprmasr");

            const decrypted = CryptoJS.TripleDES.decrypt(encryptedValue, clave, {
                iv: iv
            });

            return decrypted.toString(CryptoJS.enc.Utf8);
        },

        totalPages: function () {
            return Math.ceil(this.pollList.length / this.pageElements)
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
                let total = this.pollList.length;
                if (end < total) {
                    for (let index = ini; index < end; index++) {
                        this.paginateData.push(this.pollList[index]);
                    }
                } else {
                    for (let index = ini; index < total; index++) {
                        this.paginateData.push(this.pollList[index]);
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
                let total = this.pollList.length;
                if (end < total) {
                    for (let index = ini; index < end; index++) {
                        this.paginateData.push(this.pollList[index]);
                    }
                } else {
                    for (let index = ini; index < total; index++) {
                        this.paginateData.push(this.pollList[index]);
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
                let total = this.pollList.length;
                if (end < total) {
                    for (let index = ini; index < end; index++) {
                        this.paginateData.push(this.pollList[index]);
                    }
                } else {
                    for (let index = ini; index < total; index++) {
                        this.paginateData.push(this.pollList[index]);
                    }
                }
                await this.cutPages();
            }
        },

        cutPages: async function () {
            let pages = []
            let numberOfPages = Math.ceil(this.pollList.length / this.pageElements)
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
            let quantity = this.pollList.length
            if (quantity < 11) {
                this.paginate = false
            } else {
                this.paginate = true
            }
        },

        desplegarFiltros: function () {
            this.filtroDesplegar = !this.filtroDesplegar;
        },

        cerrarFiltros: function () {
            this.filtroDesplegar = false;
        },

        QuitarHTML(html) {
            var temporal = document.createElement('div')
            temporal.innerHTML = html
            return temporal.textContent || temporal.innerText || ""
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
        await this.GetAllPolls()
        await this.cutPages();
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
    max-width: 2100px;
    overflow-x: auto;
    margin-top: 25px;
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
    background-color: #114677;;
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

</style>