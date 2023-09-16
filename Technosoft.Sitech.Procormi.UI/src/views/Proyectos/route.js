import CrearProyecto from "./CrearProyecto.vue"

const route = [
    {
        path: '/CrearProyecto',
        name: 'CrearProyecto',
        component: CrearProyecto
    },
    {
        path: '/CrearProyecto/:id',
        name: 'CrearProyectoEdit',
        component: CrearProyecto,
    },
];

export default route;