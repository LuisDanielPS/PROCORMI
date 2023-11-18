import { createWebHistory, createRouter } from "vue-router";

import Login from "@/views/Login/route.js";
import Inicio from "@/views/Inicio/route.js";
import CrearProyecto from "@/views/Proyectos/route.js";
import Reportes from "@/views/Reportes/route.js";
import Encuestas from "@/views/Encuestas/ListadoEncuestas/route.js";
import CrearEncuesta from "@/views/Encuestas/CrearEncuesta/route.js";
import FormularioCliente from "@/views/Encuestas/ResponderEncuesta/route.js";
import MensajeEncuesta from "@/views/Encuestas/MensajeEncuesta/route.js";
import EditarSprint from "@/views/Sprints/EditarSprint/route.js";
import Sprints from "@/views/Sprints/ListadoSprints/route.js";
import Tareas from "@/views/Tareas/ListadoTareas/route.js";

let routes = [
    { path: '/:catchAll(.*)', redirect:'/404' }
];
routes = routes.concat(
    Login,
    Inicio,
    Encuestas,
    CrearEncuesta,
    MensajeEncuesta,
    CrearProyecto,
    Sprints,
    EditarSprint,
    Tareas,
    Reportes,
    FormularioCliente,
    

)

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
    scrollBehavior() {
        return { top: 0 }
    },
})

export default router