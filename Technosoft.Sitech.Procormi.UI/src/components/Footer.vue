<template>
    <footer class="footer-dark bg-azulFooter" v-on:click="cerrarMenu()" v-if="logueado">
        <div class="footer-bottom padding-5px-tb border-color-white-transparent">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-12" style="padding-top: 10px;">
                        <p style="text-align: center; cursor: default;">Corporación Millenium. &copy; {{dato}}. Todos los derechos reservados.</p>
                    </div>
                </div>
            </div>
        </div>

        <a class="scroll-top-arrow" href="javascript:void(0);"><i class="feather icon-feather-arrow-up"></i></a>

    </footer>
</template>

<script>
import Cookies from 'js-cookie';

    export default {

        data() {
            return {
                dato: "",
                logueado: false,
            }
        },

        methods: {
            obtenerFecha: function() {
                var fecha = new Date().getFullYear()

                this.dato = fecha


            },

            cerrarMenu: async function () {
                await this.$root.CerrarMenu.call();
                await this.$root.CerrarMenuAplicaciones.call();
            },

            recuperarUsuLog() {
                return Cookies.get("usuarioLogin")
            },

            validarLogin: async function() {
                var login = await this.recuperarUsuLog();
                if(login != null && login != undefined && login != ""){
                    this.logueado = true
                } else {
                    this.logueado = false
                }
            },

        },

        mounted: async function () {
            this.$root.validarLoginFooter = this.validarLogin;
        },

        created: async function () {
            await this.validarLogin();
            await this.obtenerFecha();
        }

    }

</script>

<style scoped>

</style>