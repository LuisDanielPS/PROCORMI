import CrearEncuesta from "./CrearEncuesta.vue"

const route = [
    {
        path: '/CrearEncuesta',
        name: 'CrearEncuesta',
        component: CrearEncuesta
    },
    {
        path: '/EditarEncuesta/:id',
        name: 'EditarEncuesta',
        component: CrearEncuesta,
    },
];

export default route;