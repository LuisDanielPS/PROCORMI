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
    ,
    GetALLUsers()
    {
        return apicliente.get('User/GetALLUsers' , {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    ,
    GetLastInsertId()
    {
        return apicliente.get('Project/GetLastInsertId' , {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    ,
    GetProject(IdProject)
    {
        return apicliente.get('Project/GetProject?pIdProject='+ IdProject, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    
    ,
    GetUserListProject(IdProject)
    {
        return apicliente.get('Project/GetUserListProject?pIdProject='+ IdProject, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    ,
    GetFileListProject(IdProject)
    {
        return apicliente.get('Project/GetFileListProject?pIdProject='+ IdProject, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    ,
    PostProject(project){
        return apicliente.post('Project/PostProject' ,project,{
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    PostAddUserProject(adduser){
        return apicliente.post('Project/PostAddUserProject' ,adduser,{
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    PostAddFileProject(addfile){
        return apicliente.post('Project/PostAddFileProject' ,addfile,{
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    PostFile(addfile){
        return apicliente.post('File/PostFile' ,addfile,{
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    PutProject(project){
        return apicliente.put('Project/PutProject' ,project,{
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }   
    ,
    DeleteFileProject(IdProject)
    {
        return apicliente.delete('Project/DeleteFileProject?pIdProject='+ IdProject, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    ,
    DeleteUserListProject(IdProject)
    {
        return apicliente.delete('Project/DeleteUserListProject?pIdProject='+ IdProject, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    ,
    GetAllSprint()
    {
        return apicliente.get('Sprint/GetALLSprints' , {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }

}