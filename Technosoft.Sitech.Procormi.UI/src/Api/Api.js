import axios from 'axios'
import Api from '@/Confi.js'

const apicliente = axios.create({
    baseURL: Api.ApiURL
})

export default {

    GetLogin(Usuario, Clave) {
        return apicliente.get('Login/GetLogin?Usu=' + Usuario + '&Pass=' + Clave, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },

    GetAllProject()
    {
        return apicliente.get('Project/GetALLProjects' , {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }

}