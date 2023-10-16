Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class SubTaskController
        Inherits ApiController

        <HttpGet>
        Public Function GetALLSubTasks(taskId As String) As Reply(Of List(Of SubTaskEN))
            Dim reply As Reply(Of List(Of SubTaskEN))
            reply = SubTaskBLL.Instance.GetAllSubTasksBLL(taskId)
            Return reply
        End Function

        <HttpGet>
        Public Function GetALLStatus() As Reply(Of List(Of String))
            Dim reply As Reply(Of List(Of String))
            reply = SubTaskBLL.Instance.GetAllStatus()
            Return reply
        End Function

        <HttpGet>
        Public Function GetALLPriorities() As Reply(Of List(Of String))
            Dim reply As Reply(Of List(Of String))
            reply = SubTaskBLL.Instance.GetAllPriorities()
            Return reply
        End Function

        <HttpPost>
        Public Function PostTask(pSubTask As SubTaskEN) As Reply(Of SubTaskEN)

            Dim reply As Reply(Of SubTaskEN) = New Reply(Of SubTaskEN)
            reply = SubTaskBLL.Instance.PostSubTaskBLL(pSubTask)
            Return reply

        End Function

        <HttpPut>
        Public Function PutSubTask(pSubTask As SubTaskEN) As Reply(Of SubTaskEN)

            Dim reply As Reply(Of SubTaskEN) = New Reply(Of SubTaskEN)
            reply = SubTaskBLL.Instance.PutSubTaskBLL(pSubTask)
            Return reply

        End Function

        <HttpPut>
        Public Function PutTaskByDisabling(pSubTaskId As String) As Reply(Of SubTaskEN)
            Dim reply As Reply(Of SubTaskEN) = New Reply(Of SubTaskEN)
            reply = SubTaskBLL.Instance.PutSubTaskBLLByDisabling(pSubTaskId)
            Return reply
        End Function

        <HttpPut>
        Public Function PutSubTaskAsFinished(pSubTaskId As String) As Reply(Of SubTaskEN)
            Dim reply As Reply(Of SubTaskEN) = New Reply(Of SubTaskEN)
            reply = SubTaskBLL.Instance.PutSubTaskBLLAsFinished(pSubTaskId)
            Return reply
        End Function

    End Class

End Namespace