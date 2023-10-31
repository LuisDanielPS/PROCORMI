import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
const app = createApp(App)

import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';
app.use(VueSweetalert2);

import VueLoading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css';
app.use(VueLoading);

import VueGoodTablePlugin from 'vue-good-table-next';
import 'vue-good-table-next/dist/vue-good-table-next.css'
app.use(VueGoodTablePlugin);

import FloatingVue from 'floating-vue'
import 'floating-vue/dist/style.css'
app.use(FloatingVue)

import moment from 'moment'

app.config.globalProperties.$filters = {
    
    FormatearFecha: (fecha) =>  moment(String(fecha)).format('DD/MM/YYYY'),

    FormatearFechaHora: (fecha) =>  moment(String(fecha)).format('DD/MM/YYYY hh:mm a'),

    AcortarTexto(texto, limite = 30){
        if(texto.length > limite){
            texto = texto.substring(0, limite) + '...'
        }
        return texto
    },

    CortarTexto(texto, limite){
        if(texto.length > limite){
            texto = texto.substring(0, limite) + '...'
        }
        return texto
    },
}

app.use(store).use(router).mount('#app')