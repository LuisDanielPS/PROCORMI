<template>
    <div class="wrap-input">
        <input autocomplete="off" maxlength="70" class="small-input bg-white margin-20px-bottom inpuFiltro" type="search" id="pClaveInput" placeholder="Buscar" v-model.trim="pClave">
    </div>
</template>

<script>

    //import { mapState, mapActions } from 'vuex';
    //import AdminApi from '@/Api/Api';
    import Cookies from 'js-cookie';

    export default {
        name: 'HeaderS',

        props: {
            cuadroLoaderPrincipal: null
        },

        data() {
            return {
                elementosPorPaginaPrincipal: 4,
                menuDesplegableDerecho: false,

                ListaPublicacionTemporal: [],
                pClave: '',

                AgregarDepartamento: false,
                AgregarCategoria: false,
                AgregarSubcategoria: false,
                AgregarUsuario: false,
                AgregarPublicacion: false,
                Login: false,
                Logout: true,
                resultadoBusqueda: false,

                timeout: null,

                ListaTotalPublicaciones: [],
                ListaPublicacionesCalculado: [],
                numeroPublicacionesPalabra: 0,
            }
        },

        methods: {

            limpiarFiltro: async function () {
                await this.limpiarPalabra()
                document.getElementById("pClaveInput").value = ""
            },

            /*TraerPublicaciones: function () {
                AdminApi.TraerPublicaciones()
                    .then(response => {
                        if (response.data != null) {
                            this.ListaTotalPublicaciones = response.data.obj
                        }
                    })
            },*/

            /*calcularNumeroPaginas: async function () {
                await this.$root.LimpiarFiltro.call();
                var usuTipo = this.recuperarUsuTipo();
                var palabr = await document.getElementById("pClaveInput").value
                this.ListaPublicacionesCalculado = []

                if (usuTipo == "Administrador") {
                    for (let index = 0; index < this.ListaTotalPublicaciones.length; index++) {
                        if (this.ListaTotalPublicaciones[index].know_tema_titulo.toLowerCase().includes(palabr.toLowerCase())
                            || this.ListaTotalPublicaciones[index].know_tema_subtitulo.toLowerCase().includes(palabr.toLowerCase())
                            || this.ListaTotalPublicaciones[index].know_tema_palabraClave.toLowerCase().includes(palabr.toLowerCase())) {
                            this.ListaPublicacionesCalculado.push({
                                id_know_tema: this.ListaTotalPublicaciones[index].id_know_tema,
                                id_gen_departamento: this.ListaTotalPublicaciones[index].id_gen_departamento,
                                id_know_categoria: this.ListaTotalPublicaciones[index].id_know_categoria,
                                id_know_subcategoria: this.ListaTotalPublicaciones[index].id_know_subcategoria,
                                know_tema_titulo: this.ListaTotalPublicaciones[index].know_tema_titulo,
                                know_tema_subtitulo: this.ListaTotalPublicaciones[index].know_tema_subtitulo,
                                know_tema_palabraClave: this.ListaTotalPublicaciones[index].know_tema_palabraClave,
                                know_tema_contenido: this.QuitarHTML(this.ListaTotalPublicaciones[index].know_tema_contenido),
                                know_tema_tipoCliente: this.ListaTotalPublicaciones[index].know_tema_tipoCliente,
                                know_tema_cantConsul: this.ListaTotalPublicaciones[index].know_tema_cantConsul,
                                know_tema_estado: this.ListaTotalPublicaciones[index].know_tema_estado,
                                know_tema_login: this.ListaTotalPublicaciones[index].know_tema_login,
                                know_tema_nombreUsu: this.ListaTotalPublicaciones[index].know_tema_nombreUsu,
                            });
                        }
                        this.numeroPublicacionesPalabra = this.ListaPublicacionesCalculado.length
                        localStorage.setItem('numeroPublicacionesPalabra', this.numeroPublicacionesPalabra);
                    }
                } else {
                    for (let index = 0; index < this.ListaTotalPublicaciones.length; index++) {
                        if (this.ListaTotalPublicaciones[index].know_tema_titulo.toLowerCase().includes(palabr.toLowerCase()) && this.ListaTotalPublicaciones[index].know_tema_estado == 1
                            || this.ListaTotalPublicaciones[index].know_tema_subtitulo.toLowerCase().includes(palabr.toLowerCase()) && this.ListaTotalPublicaciones[index].know_tema_estado == 1
                            || this.ListaTotalPublicaciones[index].know_tema_palabraClave.toLowerCase().includes(palabr.toLowerCase()) && this.ListaTotalPublicaciones[index].know_tema_estado == 1) {
                            this.ListaPublicacionesCalculado.push({
                                id_know_tema: this.ListaTotalPublicaciones[index].id_know_tema,
                                id_gen_departamento: this.ListaTotalPublicaciones[index].id_gen_departamento,
                                id_know_categoria: this.ListaTotalPublicaciones[index].id_know_categoria,
                                id_know_subcategoria: this.ListaTotalPublicaciones[index].id_know_subcategoria,
                                know_tema_titulo: this.ListaTotalPublicaciones[index].know_tema_titulo,
                                know_tema_subtitulo: this.ListaTotalPublicaciones[index].know_tema_subtitulo,
                                know_tema_palabraClave: this.ListaTotalPublicaciones[index].know_tema_palabraClave,
                                know_tema_contenido: this.QuitarHTML(this.ListaTotalPublicaciones[index].know_tema_contenido),
                                know_tema_tipoCliente: this.ListaTotalPublicaciones[index].know_tema_tipoCliente,
                                know_tema_cantConsul: this.ListaTotalPublicaciones[index].know_tema_cantConsul,
                                know_tema_estado: this.ListaTotalPublicaciones[index].know_tema_estado,
                                know_tema_login: this.ListaTotalPublicaciones[index].know_tema_login,
                                know_tema_nombreUsu: this.ListaTotalPublicaciones[index].know_tema_nombreUsu,
                            });
                        }
                        this.numeroPublicacionesPalabra = this.ListaPublicacionesCalculado.length
                        localStorage.setItem('numeroPublicacionesPalabra', this.numeroPublicacionesPalabra);
                    }
                }

            },*/

            /*ListarPublicacionPaginado: async function () {
                await this.calcularNumeroPaginas();
                var usuTipo = this.recuperarUsuTipo();
                this.ListaPublicacionTemporal = []
                this.AsignarPublicaciones([])
                let ListaPublicaciones = []

                let loader = this.$loading.show({
                    container: this.cuadroLoaderPrincipal, //this.$refs['cuadroLoader'],
                    opacity: 1
                })

                if (usuTipo == "Administrador") {
                    if (this.ListaPublicacionesCalculado.length < this.elementosPorPaginaPrincipal) {
                        for (let index = 0; index < this.ListaPublicacionesCalculado.length; index++) {
                            if (this.ListaPublicacionesCalculado[index] != []) {
                                ListaPublicaciones.push({
                                    id_know_tema: this.ListaPublicacionesCalculado[index].id_know_tema,
                                    id_gen_departamento: this.ListaPublicacionesCalculado[index].id_gen_departamento,
                                    id_know_categoria: this.ListaPublicacionesCalculado[index].id_know_categoria,
                                    id_know_subcategoria: this.ListaPublicacionesCalculado[index].id_know_subcategoria,
                                    know_tema_titulo: this.ListaPublicacionesCalculado[index].know_tema_titulo,
                                    know_tema_subtitulo: this.ListaPublicacionesCalculado[index].know_tema_subtitulo,
                                    know_tema_palabraClave: this.ListaPublicacionesCalculado[index].know_tema_palabraClave,
                                    know_tema_contenido: this.QuitarHTML(this.ListaPublicacionesCalculado[index].know_tema_contenido),
                                    know_tema_tipoCliente: this.ListaPublicacionesCalculado[index].know_tema_tipoCliente,
                                    know_tema_cantConsul: this.ListaPublicacionesCalculado[index].know_tema_cantConsul,
                                    know_tema_estado: this.ListaPublicacionesCalculado[index].know_tema_estado,
                                    know_tema_login: this.ListaPublicacionesCalculado[index].know_tema_login,
                                    know_tema_nombreUsu: this.ListaPublicacionesCalculado[index].know_tema_nombreUsu,
                                });
                                this.AsignarPublicaciones(ListaPublicaciones)
                            }
                        }
                    } else {
                        for (let index = 0; index < this.elementosPorPaginaPrincipal; index++) {
                            if (this.ListaPublicacionesCalculado[index] != []) {
                                ListaPublicaciones.push({
                                    id_know_tema: this.ListaPublicacionesCalculado[index].id_know_tema,
                                    id_gen_departamento: this.ListaPublicacionesCalculado[index].id_gen_departamento,
                                    id_know_categoria: this.ListaPublicacionesCalculado[index].id_know_categoria,
                                    id_know_subcategoria: this.ListaPublicacionesCalculado[index].id_know_subcategoria,
                                    know_tema_titulo: this.ListaPublicacionesCalculado[index].know_tema_titulo,
                                    know_tema_subtitulo: this.ListaPublicacionesCalculado[index].know_tema_subtitulo,
                                    know_tema_palabraClave: this.ListaPublicacionesCalculado[index].know_tema_palabraClave,
                                    know_tema_contenido: this.QuitarHTML(this.ListaPublicacionesCalculado[index].know_tema_contenido),
                                    know_tema_tipoCliente: this.ListaPublicacionesCalculado[index].know_tema_tipoCliente,
                                    know_tema_cantConsul: this.ListaPublicacionesCalculado[index].know_tema_cantConsul,
                                    know_tema_estado: this.ListaPublicacionesCalculado[index].know_tema_estado,
                                    know_tema_login: this.ListaPublicacionesCalculado[index].know_tema_login,
                                    know_tema_nombreUsu: this.ListaPublicacionesCalculado[index].know_tema_nombreUsu,
                                });
                                this.AsignarPublicaciones(ListaPublicaciones)
                            }
                        }
                    }
                } else {
                    if (this.ListaPublicacionesCalculado.length < this.elementosPorPaginaPrincipal) {
                        for (let index = 0; index < this.ListaPublicacionesCalculado.length; index++) {
                            ListaPublicaciones.push({
                                id_know_tema: this.ListaPublicacionesCalculado[index].id_know_tema,
                                id_gen_departamento: this.ListaPublicacionesCalculado[index].id_gen_departamento,
                                id_know_categoria: this.ListaPublicacionesCalculado[index].id_know_categoria,
                                id_know_subcategoria: this.ListaPublicacionesCalculado[index].id_know_subcategoria,
                                know_tema_titulo: this.ListaPublicacionesCalculado[index].know_tema_titulo,
                                know_tema_subtitulo: this.ListaPublicacionesCalculado[index].know_tema_subtitulo,
                                know_tema_palabraClave: this.ListaPublicacionesCalculado[index].know_tema_palabraClave,
                                know_tema_contenido: this.QuitarHTML(this.ListaPublicacionesCalculado[index].know_tema_contenido),
                                know_tema_tipoCliente: this.ListaPublicacionesCalculado[index].know_tema_tipoCliente,
                                know_tema_cantConsul: this.ListaPublicacionesCalculado[index].know_tema_cantConsul,
                                know_tema_estado: this.ListaPublicacionesCalculado[index].know_tema_estado,
                                know_tema_login: this.ListaPublicacionesCalculado[index].know_tema_login,
                                know_tema_nombreUsu: this.ListaPublicacionesCalculado[index].know_tema_nombreUsu,
                            });
                            this.AsignarPublicaciones(ListaPublicaciones)
                        }
                    } else {
                        for (let index = 0; index < this.elementosPorPaginaPrincipal; index++) {
                            ListaPublicaciones.push({
                                id_know_tema: this.ListaPublicacionesCalculado[index].id_know_tema,
                                id_gen_departamento: this.ListaPublicacionesCalculado[index].id_gen_departamento,
                                id_know_categoria: this.ListaPublicacionesCalculado[index].id_know_categoria,
                                id_know_subcategoria: this.ListaPublicacionesCalculado[index].id_know_subcategoria,
                                know_tema_titulo: this.ListaPublicacionesCalculado[index].know_tema_titulo,
                                know_tema_subtitulo: this.ListaPublicacionesCalculado[index].know_tema_subtitulo,
                                know_tema_palabraClave: this.ListaPublicacionesCalculado[index].know_tema_palabraClave,
                                know_tema_contenido: this.QuitarHTML(this.ListaPublicacionesCalculado[index].know_tema_contenido),
                                know_tema_tipoCliente: this.ListaPublicacionesCalculado[index].know_tema_tipoCliente,
                                know_tema_cantConsul: this.ListaPublicacionesCalculado[index].know_tema_cantConsul,
                                know_tema_estado: this.ListaPublicacionesCalculado[index].know_tema_estado,
                                know_tema_login: this.ListaPublicacionesCalculado[index].know_tema_login,
                                know_tema_nombreUsu: this.ListaPublicacionesCalculado[index].know_tema_nombreUsu,
                            });
                            this.AsignarPublicaciones(ListaPublicaciones)
                        }
                    }
                }
                setTimeout(() => {
                    loader.hide()
                }, 300)
                await this.$root.ActualizarPaginas.call();
                await this.$root.ReiniciarPagina.call();
            },*/

            /*cambiarPagina: async function (noPagina) {
                let loader = this.$loading.show({
                    container: this.cuadroLoaderPrincipal,
                    opacity: 1
                })

                var usuTipo = this.recuperarUsuTipo();
                this.ListaPublicacionTemporal = []
                this.AsignarPublicaciones([])
                let ListaPublicaciones = []
                let ini = (noPagina * this.elementosPorPaginaPrincipal) - this.elementosPorPaginaPrincipal;
                let fin = (noPagina * this.elementosPorPaginaPrincipal);
                if (usuTipo == "Administrador") {
                    if (fin > this.ListaPublicacionesCalculado.length) {
                        for (let index = ini; index < this.ListaPublicacionesCalculado.length; index++) {
                            ListaPublicaciones.push({
                                id_know_tema: this.ListaPublicacionesCalculado[index].id_know_tema,
                                id_gen_departamento: this.ListaPublicacionesCalculado[index].id_gen_departamento,
                                id_know_categoria: this.ListaPublicacionesCalculado[index].id_know_categoria,
                                id_know_subcategoria: this.ListaPublicacionesCalculado[index].id_know_subcategoria,
                                know_tema_titulo: this.ListaPublicacionesCalculado[index].know_tema_titulo,
                                know_tema_subtitulo: this.ListaPublicacionesCalculado[index].know_tema_subtitulo,
                                know_tema_palabraClave: this.ListaPublicacionesCalculado[index].know_tema_palabraClave,
                                know_tema_contenido: this.QuitarHTML(this.ListaPublicacionesCalculado[index].know_tema_contenido),
                                know_tema_tipoCliente: this.ListaPublicacionesCalculado[index].know_tema_tipoCliente,
                                know_tema_cantConsul: this.ListaPublicacionesCalculado[index].know_tema_cantConsul,
                                know_tema_estado: this.ListaPublicacionesCalculado[index].know_tema_estado,
                                know_tema_login: this.ListaPublicacionesCalculado[index].know_tema_login,
                                know_tema_nombreUsu: this.ListaPublicacionesCalculado[index].know_tema_nombreUsu,
                            });
                            this.AsignarPublicaciones(ListaPublicaciones)
                        }
                    } else {
                        for (let index = ini; index < fin; index++) {
                            ListaPublicaciones.push({
                                id_know_tema: this.ListaPublicacionesCalculado[index].id_know_tema,
                                id_gen_departamento: this.ListaPublicacionesCalculado[index].id_gen_departamento,
                                id_know_categoria: this.ListaPublicacionesCalculado[index].id_know_categoria,
                                id_know_subcategoria: this.ListaPublicacionesCalculado[index].id_know_subcategoria,
                                know_tema_titulo: this.ListaPublicacionesCalculado[index].know_tema_titulo,
                                know_tema_subtitulo: this.ListaPublicacionesCalculado[index].know_tema_subtitulo,
                                know_tema_palabraClave: this.ListaPublicacionesCalculado[index].know_tema_palabraClave,
                                know_tema_contenido: this.QuitarHTML(this.ListaPublicacionesCalculado[index].know_tema_contenido),
                                know_tema_tipoCliente: this.ListaPublicacionesCalculado[index].know_tema_tipoCliente,
                                know_tema_cantConsul: this.ListaPublicacionesCalculado[index].know_tema_cantConsul,
                                know_tema_estado: this.ListaPublicacionesCalculado[index].know_tema_estado,
                                know_tema_login: this.ListaPublicacionesCalculado[index].know_tema_login,
                                know_tema_nombreUsu: this.ListaPublicacionesCalculado[index].know_tema_nombreUsu,
                            });
                            this.AsignarPublicaciones(ListaPublicaciones)
                        }
                    }
                } else {
                    if (fin > this.ListaPublicacionesCalculado.length) {
                        for (let index = ini; index < this.ListaPublicacionesCalculado.length; index++) {
                            ListaPublicaciones.push({
                                id_know_tema: this.ListaPublicacionesCalculado[index].id_know_tema,
                                id_gen_departamento: this.ListaPublicacionesCalculado[index].id_gen_departamento,
                                id_know_categoria: this.ListaPublicacionesCalculado[index].id_know_categoria,
                                id_know_subcategoria: this.ListaPublicacionesCalculado[index].id_know_subcategoria,
                                know_tema_titulo: this.ListaPublicacionesCalculado[index].know_tema_titulo,
                                know_tema_subtitulo: this.ListaPublicacionesCalculado[index].know_tema_subtitulo,
                                know_tema_palabraClave: this.ListaPublicacionesCalculado[index].know_tema_palabraClave,
                                know_tema_contenido: this.QuitarHTML(this.ListaPublicacionesCalculado[index].know_tema_contenido),
                                know_tema_tipoCliente: this.ListaPublicacionesCalculado[index].know_tema_tipoCliente,
                                know_tema_cantConsul: this.ListaPublicacionesCalculado[index].know_tema_cantConsul,
                                know_tema_estado: this.ListaPublicacionesCalculado[index].know_tema_estado,
                                know_tema_login: this.ListaPublicacionesCalculado[index].know_tema_login,
                                know_tema_nombreUsu: this.ListaPublicacionesCalculado[index].know_tema_nombreUsu,
                            });
                            this.AsignarPublicaciones(ListaPublicaciones)
                        }
                    } else {
                        for (let index = ini; index < fin; index++) {
                            ListaPublicaciones.push({
                                id_know_tema: this.ListaPublicacionesCalculado[index].id_know_tema,
                                id_gen_departamento: this.ListaPublicacionesCalculado[index].id_gen_departamento,
                                id_know_categoria: this.ListaPublicacionesCalculado[index].id_know_categoria,
                                id_know_subcategoria: this.ListaPublicacionesCalculado[index].id_know_subcategoria,
                                know_tema_titulo: this.ListaPublicacionesCalculado[index].know_tema_titulo,
                                know_tema_subtitulo: this.ListaPublicacionesCalculado[index].know_tema_subtitulo,
                                know_tema_palabraClave: this.ListaPublicacionesCalculado[index].know_tema_palabraClave,
                                know_tema_contenido: this.QuitarHTML(this.ListaPublicacionesCalculado[index].know_tema_contenido),
                                know_tema_tipoCliente: this.ListaPublicacionesCalculado[index].know_tema_tipoCliente,
                                know_tema_cantConsul: this.ListaPublicacionesCalculado[index].know_tema_cantConsul,
                                know_tema_estado: this.ListaPublicacionesCalculado[index].know_tema_estado,
                                know_tema_login: this.ListaPublicacionesCalculado[index].know_tema_login,
                                know_tema_nombreUsu: this.ListaPublicacionesCalculado[index].know_tema_nombreUsu,
                            });
                            this.AsignarPublicaciones(ListaPublicaciones)
                        }
                    }
                }
                setTimeout(() => {
                    loader.hide()
                }, 300)
            },*/

            /*...mapActions([
                'AsignarPublicaciones',
            ]),*/

            guardarPalabra: async function () {
                var inputElement = document.getElementById('pClaveInput');
                var palabra = '';
                if (inputElement) {
                    palabra = inputElement.value;
                    Cookies.set('palabraClave', palabra);
                } else {
                    palabra = '';
                    Cookies.set('palabraClave', palabra);
                }
            },

            limpiarPalabra: function () {
                Cookies.set("palabraClave", "")
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
                if (role == "Administrador") {
                    this.AgregarPublicacion = true,
                        this.AgregarDepartamento = true
                    this.AgregarCategoria = true
                    this.AgregarSubcategoria = true
                    this.AgregarUsuario = true
                } else if (role == "Supervisor") {
                    this.AgregarPublicacion = true
                    this.AgregarCategoria = true
                    this.AgregarSubcategoria = true
                } else if (role == "Operador") {
                    this.AgregarPublicacion = true
                }
                if (login == null) {
                    this.Login = true
                    this.Logout = false
                }
            }

        },

        /*computed: {
            ...mapState(
                ["ListaPublicaciones"]
            )
        },*/

        mounted: async function () {
            /*this.$root.limpiarFiltroP = this.limpiarFiltro;
            this.$root.CerrarMenu = this.CerrarMenu;
            this.$root.guardarPalabraDinamico = this.guardarPalabra;
            await this.TraerPublicaciones();
            this.$root.cambiarPagina = this.cambiarPagina;
            this.$root.pagAnt = this.pagAnt;*/
        },

        watch: {
            pClave: async function () {
                await this.guardarPalabra();
                await this.ListarPublicacionPaginado();
            }
            /*pClave: async function () {
                clearTimeout(this.timeout);

                this.timeout = setTimeout(async () => {
                    await this.guardarPalabra();
                    await this.calcularNumeroPaginas();
                    await this.ListarPublicacionPaginado();
                }, 1000)
            }*/
        },

        created: function () {
            this.verificarLog();
            this.guardarPalabra("");
        }

    }

</script>

<style scoped>

    .wrap-input {
        margin-top: 10px;
        position: relative;
        width: 100%;
        min-height: 40px;
    }

        .wrap-input input {
            outline: none;
            width: 100%;
            height: 40px;
            padding: 10px 30px 10px 20px;
            border-radius: 5px;
        }

    .inpuFiltro{
        max-width: 300px;
    }

    @media screen and (max-width: 920px) {
        .inpuFiltro{
            max-width: 280px;
        }
    }

    @media screen and (max-width: 800px) {
        .inpuFiltro{
            max-width: 200px;
        }
    }

    @media screen and (max-width: 400px) {
        .inpuFiltro{
            max-width: 150px;
        }
    }

</style>