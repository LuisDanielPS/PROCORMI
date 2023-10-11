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
    GetAllSprint(idProyect)
    {
        return apicliente.get('Sprint/GetALLSprints?idProyect='+ idProyect, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    ,
    GetAllTasks(idSprint)
    {
        return apicliente.get('Task/GetALLTasks?idSprint='+ idSprint, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,

    GetAllTasksBySprint(sprintId)
    {
        return apicliente.get(`Task/GetALLTasks?sprintId=${sprintId}` , {
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
    GetPasswordVerifyDeleteRow(Usuario, Clave) {
        return apicliente.get('Project/GetPasswordVerifyDeleteRow?Usu=' + Usuario + '&Pass=' + Clave, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },
    
    PostProject(project){
        return apicliente.post('Project/PostProject' ,project,{
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    PostSprint(sprint) {
        return apicliente.post('Sprint/PostSprint' ,
        sprint,
        {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' },
        })
    },
    PostTask(task) {
        return apicliente.post('Task/PostTask' ,
        task,
        {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' },
        })
    },
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
    PutSprint(sprint){
        return apicliente.put('Sprint/PutSprint' ,sprint,{
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    PutTask(task) {
        return apicliente.put('Task/PutTask' ,task,{
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' },
        })
    },
    PutDisableStatus(IdProject)
    {
        return apicliente.put('Project/PutDisableStatus?pIdProject='+ IdProject, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }, 
    
    PutDisableSprintStatus(IdSprint)
    {
        return apicliente.put('Sprint/PutDisableSprintStatus?pIdSprint='+ IdSprint, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    },
    
    PutTaskDisableStatus(IdTask) {
        return apicliente.put(`Task/PutTaskByDisabling?pTaskId=${IdTask}`, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },
    DeleteSprint(IdSprint)
    {
        return apicliente.put('Sprint/DeleteSprint?pIdSprint='+ IdSprint, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }   
    ,
    DeleteTask(taskId) {
        return apicliente.put(`Task/PutTaskByDisabling?pTaskId=${taskId}`,
        {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' },
        })
    },

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
}