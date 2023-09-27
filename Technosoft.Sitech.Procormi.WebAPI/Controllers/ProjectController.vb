Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class ProjectController
        Inherits ApiController

        <HttpGet>
        Public Function GetALLProjects() As Reply(Of List(Of ProjectEN))

            Dim reply As Reply(Of List(Of ProjectEN))
            reply = ProjectBLL.Instance.GetAllProjectsBLL()
            Return reply

        End Function

        <HttpGet>
        Public Function GetProject(pIdProject As String) As Reply(Of ProjectEN)

            Dim reply As Reply(Of ProjectEN) = New Reply(Of ProjectEN)
            reply = ProjectBLL.Instance.GetProjectBLL(pIdProject)
            Return reply

        End Function

        <HttpPost>
        Public Function PostProject(pProject As ProjectEN) As Reply(Of ProjectEN)

            Dim reply As Reply(Of ProjectEN) = New Reply(Of ProjectEN)
            reply = ProjectBLL.Instance.PostProjectBLL(pProject)
            Return reply

        End Function

        <HttpPut>
        Public Function PutProject(pProject As ProjectEN) As Reply(Of ProjectEN)

            Dim reply As Reply(Of ProjectEN) = New Reply(Of ProjectEN)
            reply = ProjectBLL.Instance.PutProjectBLL(pProject)
            Return reply

        End Function

        <HttpDelete>
        Public Function DeleteProject(pIdProject As String) As Reply(Of ProjectEN)
            Dim reply As Reply(Of ProjectEN) = New Reply(Of ProjectEN)
            reply = ProjectBLL.Instance.DeleteProjectBLL(pIdProject)
            Return reply
        End Function

    End Class

End Namespace