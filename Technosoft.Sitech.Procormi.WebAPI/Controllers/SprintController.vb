Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class SprintController
        Inherits ApiController

        <HttpGet>
        Public Function GetALLSprints() As Reply(Of List(Of SprintEN))

            Dim reply As Reply(Of List(Of SprintEN))
            reply = SprintBLL.Instance.GetAllSprintsBLL()
            Return reply

        End Function

        <HttpGet>
        Public Function GetSprint(pIdSprint As String) As Reply(Of SprintEN)

            Dim reply As Reply(Of SprintEN) = New Reply(Of SprintEN)
            reply = SprintBLL.Instance.GetSprintBLL(pIdSprint)
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

        <HttpDelete>
        Public Function DeleteSprint(pIdSprint As String) As Reply(Of SprintEN)
            Dim reply As Reply(Of SprintEN) = New Reply(Of SprintEN)
            reply = SprintBLL.Instance.DeleteSprintBLL(pIdSprint)
            Return reply

        End Function

    End Class

End Namespace