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

    GetNotificationsByUser(Usuario) {
        return apicliente.get(`Notification/GetAllNotificationByUser?username=${Usuario}`, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },

    GetProjectsAllOperator(usulogin)
    {
        return apicliente.get('Project/GetProjectsAllOperator?UsuLogin=' +usulogin, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    ,
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

    GetAllSubTasksByTask(taskId)
    {
        return apicliente.get(`SubTask/GetALLSubTasks?taskId=${taskId}` , {
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

    GetAllStatus()
    {
        return apicliente.get('SubTask/GetALLStatus' , {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    },

    GetAllPriorities()
    {
        return apicliente.get('SubTask/GetALLPriorities' , {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    },

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

    },

    GetSprint(IdSprint)
    {
        return apicliente.get('Sprint/GetSprint?pIdSprint='+ IdSprint, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    },

    GetUserListProject(IdProject)
    {
        return apicliente.get('Project/GetUserListProject?pIdProject='+ IdProject, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }
    ,

    GetUserListSprint(IdProject)
    {
        return apicliente.get('Sprint/GetUserListSprint?pIdSprint='+ IdProject, {
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
    GetProjectsReportUser(usulogin) {
        return apicliente.get('Report/GetProjectsReportUser?UsuLogin=' + usulogin, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    GetSprintReportUser(usulogin) {
        return apicliente.get('Report/GetSprintReportUser?UsuLogin=' + usulogin, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    GetTaskReportUser(usulogin) {
        return apicliente.get('Report/GetTaskReportUser?UsuLogin=' + usulogin, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    GetSubTaskReportUser(usulogin) {
        return apicliente.get('Report/GetSubTaskReportUser?UsuLogin=' + usulogin, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,
    GetDownloadFile(pNameFile) {
        return apicliente.get('File/GetDownloadFile?pNameFile=' + pNameFile, {
            responseType:'blob',
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

    PostSubTask(subTask) {
        return apicliente.post('SubTask/PostTask' ,
        subTask,
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
    PostUploadFile(idProyect,creationDate,formData){
        return apicliente.post('File/PostUploadFile?pIdProject='+idProyect+'&pCreationdate='+creationDate ,formData,{
            withCredentials: false,
            headers: { 'Content-Type': 'multipart/form-data' }
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

    PutSubTask(subTask) {
        return apicliente.put('SubTask/PutSubTask' ,subTask,{
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' },
        })
    },

    PutSubTaskDisableStatus(subTaskId) {
        return apicliente.put(`SubTask/PutTaskByDisabling?pSubTaskId=${subTaskId}`, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },

    PutSubTaskAsFinished(subTaskId) {
        return apicliente.put(`SubTask/PutSubTaskAsFinished?pSubTaskId=${subTaskId}`, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },
    
    PutDisableStatus(IdProject)
    {
        return apicliente.put('Project/PutDisableStatus?pIdProject='+ IdProject, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }, 
    PutCompleteStatus(IdProject)
    {
        return apicliente.put('Project/PutDisableComplete?pIdProject='+ IdProject, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    }, 

    PutTaskAsFinished(IdTask) {
        return apicliente.put(`Task/PutTaskAsFinished?pTaskId=${IdTask}`, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },

    PutCompleteSprintStatus(IdSprint)
    {
        return apicliente.put('Sprint/PutCompleteSprintStatus?pIdSprint='+ IdSprint, {
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

    DeleteFilesProject(IdProject)
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
    DeleteFileProject(IdFile)
    {
        return apicliente.delete('File/DeleteFileProject?pIdFile='+ IdFile, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    },

    DeleteFileUplouds(fileName)
    {
        return apicliente.delete('File/DeleteFileUplouds?fileName='+ fileName, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })

    },

    ///////////////////////////////////////////////////Poll/////////////////////////////////////////////////////////

    PostNewPoll(poll) {
        return apicliente.post('Poll/PostNewPoll', poll, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },

    UpdatePull(poll) {
        return apicliente.post('Poll/UpdatePull', poll, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },

    PostSendAnswer(poll) {
        return apicliente.post('Poll/PostSendAnswer', poll, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    }
    ,

    GetAllPolls() {
        return apicliente.get('Poll/GetAllPolls', {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },

    GetPoll(id) {
        return apicliente.get('Poll/GetPoll?pollIdEncrypted=' + id, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },

    getLink() {
        return apicliente.get('Poll/getLink', {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },
    GetPollReport(id) {
        return apicliente.get('Report/GetPollReport?pollId=' + id, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },
    

    DeletePoll(id) {
        return apicliente.delete('Poll/DeletePoll?pollId=' + id, {
            withCredentials: false,
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        })
    },

    ///////////////////////////////////////////////////Poll/////////////////////////////////////////////////////////

}