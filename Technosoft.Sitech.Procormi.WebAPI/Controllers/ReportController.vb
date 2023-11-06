Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Namespace Controllers
    Public Class ReportController
        Inherits ApiController

        <HttpGet>
        Public Function GetProjectsReportUser(ByVal UsuLogin As String) As Reply(Of List(Of ProjectStatusVM))

            Dim reply As Reply(Of List(Of ProjectStatusVM))
            reply = ProjectBLL.Instance.GetProjectsReportUserBLL(UsuLogin)
            Return reply

        End Function

        <HttpGet>
        Public Function GetSprintReportUser(ByVal UsuLogin As String) As Reply(Of List(Of SprintStatusReportVM))

            Dim reply As Reply(Of List(Of SprintStatusReportVM))
            reply = SprintBLL.Instance.GetSprintsAllReportUserBLL(UsuLogin)
            Return reply

        End Function

        <HttpGet>
        Public Function GetTaskReportUser(ByVal UsuLogin As String) As Reply(Of List(Of SpringTaskStatusReportVM))

            Dim reply As Reply(Of List(Of SpringTaskStatusReportVM))
            reply = TaskBLL.Instance.GetTaskAllReportUserBLL(UsuLogin)
            Return reply

        End Function

        <HttpGet>
        Public Function GetSubTaskReportUser(ByVal UsuLogin As String) As Reply(Of List(Of SubTaskReportVM))

            Dim reply As Reply(Of List(Of SubTaskReportVM))
            reply = SubTaskBLL.Instance.GetSubTaskAllReportUserBLL(UsuLogin)
            Return reply
        End Function

        <HttpGet>
        Public Function GetPollReport(pollId As String) As Reply(Of List(Of PollReportVM))

            Dim reply As Reply(Of List(Of PollReportVM))
            reply = PollBLL.Instance.GetPollReportBLL(pollId)
            Return reply
        End Function




    End Class
End Namespace