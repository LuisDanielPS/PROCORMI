Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class TaskController
        Inherits ApiController

        <HttpGet>
        Public Function GetALLTasks(idSprint As Integer) As Reply(Of List(Of TaskEN))

            Dim reply As Reply(Of List(Of TaskEN))
            reply = TaskBLL.Instance.GetAllTasksBLL(idSprint)
            Return reply

        End Function

        <HttpGet>
        Public Function GetALLTasks(sprintId As String) As Reply(Of List(Of TaskEN))
            Dim reply As Reply(Of List(Of TaskEN))
            reply = TaskBLL.Instance.GetAllTasksBLL(sprintId)
            Return reply
        End Function

        <HttpGet>
        Public Function GetTask(pIdTask As String) As Reply(Of TaskEN)

            Dim reply As Reply(Of TaskEN) = New Reply(Of TaskEN)
            reply = TaskBLL.Instance.GetTaskBLL(pIdTask)
            Return reply

        End Function

        <HttpPost>
        Public Function PostTask(pTask As TaskEN) As Reply(Of TaskEN)

            Dim reply As Reply(Of TaskEN) = New Reply(Of TaskEN)
            reply = TaskBLL.Instance.PostTaskBLL(pTask)
            Return reply

        End Function

        <HttpPut>
        Public Function PutTask(pTask As TaskEN) As Reply(Of TaskEN)

            Dim reply As Reply(Of TaskEN) = New Reply(Of TaskEN)
            reply = TaskBLL.Instance.PutTaskBLL(pTask)
            Return reply

        End Function

        <HttpPut>
        Public Function PutTaskByDisabling(pTaskId As String) As Reply(Of TaskEN)
            Dim reply As Reply(Of TaskEN) = New Reply(Of TaskEN)
            reply = TaskBLL.Instance.PutTaskBLLByDisabling(pTaskId)
            Return reply
        End Function

        <HttpDelete>
        Public Function DeleteTask(pIdTask As String) As Reply(Of TaskEN)
            Dim reply As Reply(Of TaskEN) = New Reply(Of TaskEN)
            reply = TaskBLL.Instance.DeleteTaskBLL(pIdTask)
            Return reply
        End Function

    End Class

End Namespace