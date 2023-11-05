Imports System.Net
Imports System.Reflection
Imports System.Threading.Tasks
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class PollController
        Inherits ApiController

        Private nombreClase As String = MethodBase.GetCurrentMethod().DeclaringType.Name

        <HttpPost>
        Public Function PostNewPoll(poll As PollEN)

            Dim reply As New Reply(Of Boolean)
            reply = PollBLL.Instance.PostNewPoll(poll)
            Return reply

        End Function

        Public Function UpdatePull(poll As PollEN) As Reply(Of Boolean)

            Dim reply As New Reply(Of Boolean)
            reply = PollBLL.Instance.UpdatePull(poll)
            Return reply

        End Function

        <HttpPost>
        Public Function PostSendAnswer(poll As PollEN)

            Dim reply As New Reply(Of Boolean)
            reply = PollBLL.Instance.PostSendAnswer(poll)
            Return reply

        End Function

        Public Function getLink() As String
            Dim reply As String
            reply = PollBLL.Instance.getLink()
            Return reply
        End Function

        Public Function GetAllPolls() As Reply(Of List(Of PollEN))

            Dim Lista As Reply(Of List(Of PollEN)) = Nothing

            Try
                Lista = PollBLL.Instance.GetAllPolls()
            Catch ex As Exception
                EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            End Try
            Return Lista

        End Function

        Public Function GetPoll(pollIdEncrypted As String) As PollEN

            Dim poll As PollEN = Nothing

            Try
                poll = PollBLL.Instance.GetPoll(pollIdEncrypted)
            Catch ex As Exception
                EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            End Try
            Return poll

        End Function

        <HttpDelete>
        Public Function DeletePoll(pollId As Integer) As Task(Of Reply(Of Boolean))

            Dim reply As Task(Of Reply(Of Boolean))
            reply = PollBLL.Instance.DeletePoll(pollId)
            Return reply

        End Function

    End Class
End Namespace