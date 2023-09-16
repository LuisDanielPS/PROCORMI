import CrearEncuesta from "./CrearEncuesta.vue"

const route = [
    {
        path: '/CrearEncuesta',
        name: 'CrearEncuesta',
        component: CrearEncuesta
    },
    {
        path: '/CrearEncuesta/:id',
        name: 'CrearEncuestaEdit',
        component: CrearEncuesta,
    },
];

export default route;