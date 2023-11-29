Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class SprintController
        Inherits ApiController

        <HttpGet>
        Public Function GetALLSprints(idProyect As Integer) As Reply(Of List(Of SprintEN))

            Dim reply As Reply(Of List(Of SprintEN))
            reply = SprintBLL.Instance.GetAllSprintsBLL(idProyect)
            Return reply

        End Function

        <HttpGet>
        Public Function GetSprint(pIdSprint As String) As Reply(Of SprintEN)

            Dim reply As Reply(Of SprintEN) = New Reply(Of SprintEN)
            reply = SprintBLL.Instance.GetSprintBLL(pIdSprint)
            Return reply

        End Function

        <HttpGet>
        Public Function GetUserListSprint(ByVal pIdSprint As Integer) As Reply(Of List(Of UserListSprintVM))

            Dim reply As Reply(Of List(Of UserListSprintVM))
            reply = SprintBLL.Instance.GetUserListSprintBLL(pIdSprint)
            Return reply

        End Function

        <HttpGet>
        Public Function GetSprintsAllOperator(ByVal UsuLogin As String, ByVal Id_Project As Integer) As Reply(Of List(Of SprintEN))

            Dim reply As Reply(Of List(Of SprintEN))
            reply = SprintBLL.Instance.GetSprintsAllOperatorBLL(UsuLogin, Id_Project)
            Return reply

        End Function

        <HttpGet>
        Public Function GetSprintTask(pIdSprint As Integer) As Reply(Of SprintEN)

            Dim reply As Reply(Of SprintEN)
            reply = SprintBLL.Instance.GetSprintTaskBLL(pIdSprint)
            Return reply

        End Function

        <HttpPost>
        Public Function PostSprint(pSprint As SprintEN) As Reply(Of SprintEN)

            Dim reply As Reply(Of SprintEN) = New Reply(Of SprintEN)
            reply = SprintBLL.Instance.PostSprintBLL(pSprint)
            Return reply

        End Function

        <HttpPut>
        Public Function PutSprint(pSprint As SprintEN) As Reply(Of SprintEN)

            Dim reply As Reply(Of SprintEN) = New Reply(Of SprintEN)
            reply = SprintBLL.Instance.PutSprintBLL(pSprint)
            Return reply

        End Function

        <HttpPut>
        Public Function PutCompleteSprintStatus(pIdSprint As Integer) As Reply(Of SprintEN)

            Dim reply As Reply(Of SprintEN) = New Reply(Of SprintEN)
            reply = SprintBLL.Instance.PutCompleteSprintStatusBLL(pIdSprint)
            Return reply

        End Function

        <HttpPut>
        Public Function PutDisableSprintStatus(pIdSprint As Integer) As Reply(Of SprintEN)

            Dim reply As Reply(Of SprintEN) = New Reply(Of SprintEN)
            reply = SprintBLL.Instance.PutDisableStatusBLL(pIdSprint)
            Return reply

        End Function

        <HttpDelete>
        Public Function DeleteSprint(pIdSprint As String) As Reply(Of SprintEN)
            Dim reply As Reply(Of SprintEN) = New Reply(Of SprintEN)
            reply = SprintBLL.Instance.DeleteSprintBLL(pIdSprint)
            Return reply

        End Function

    End Class

End Namespace