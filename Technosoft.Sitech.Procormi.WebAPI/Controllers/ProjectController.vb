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


        <HttpGet>
        Public Function GetLastInsertId() As Reply(Of Integer)

            Dim reply As Reply(Of Integer) = New Reply(Of Integer)
            reply = ProjectBLL.Instance.GetLastInsertIdBLL()
            Return reply

        End Function

        <HttpGet>
        Public Function GetUserListProject(ByVal pIdProject As Integer) As Reply(Of List(Of UserListProjectVM))

            Dim reply As Reply(Of List(Of UserListProjectVM))
            reply = ProjectBLL.Instance.GetUserListProjectBLL(pIdProject)
            Return reply

        End Function

        <HttpGet>
        Public Function GetFileListProject(ByVal pIdProject As Integer) As Reply(Of List(Of FileEN))

            Dim reply As Reply(Of List(Of FileEN))
            reply = ProjectBLL.Instance.GetFileListProjectBLL(pIdProject)
            Return reply

        End Function

        <HttpPost>
        Public Function PostProject(pProject As ProjectEN) As Reply(Of ProjectEN)

            Dim reply As Reply(Of ProjectEN) = New Reply(Of ProjectEN)
            reply = ProjectBLL.Instance.PostProjectBLL(pProject)
            Return reply

        End Function

        <HttpPost>
        Public Function PostAddUserProject(ByVal pAddUserProject As SegUsuProjectEN) As Reply(Of SegUsuProjectEN)

            Dim reply As Reply(Of SegUsuProjectEN) = New Reply(Of SegUsuProjectEN)
            reply = ProjectBLL.Instance.PostAddUserProjectBLL(pAddUserProject)
            Return reply

        End Function

        <HttpPost>
        Public Function PostAddFileProject(ByVal pAddFileProject As ProjectFileEN) As Reply(Of ProjectFileEN)

            Dim reply As Reply(Of ProjectFileEN) = New Reply(Of ProjectFileEN)
            reply = ProjectBLL.Instance.PostAddFileProjectBLL(pAddFileProject)
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

        <HttpDelete>
        Public Function DeleteFileProject(pIdProject As Integer) As Reply(Of ProjectFileEN)
            Dim reply As Reply(Of ProjectFileEN) = New Reply(Of ProjectFileEN)
            reply = ProjectBLL.Instance.DeleteProjectFileBLL(pIdProject)
            Return reply
        End Function

        <HttpDelete>
        Public Function DeleteUserListProject(pIdProject As Integer) As Reply(Of SegUsuProjectEN)
            Dim reply As Reply(Of SegUsuProjectEN) = New Reply(Of SegUsuProjectEN)
            reply = ProjectBLL.Instance.DeleteSegUsuBLL(pIdProject)
            Return reply
        End Function


    End Class

End Namespace