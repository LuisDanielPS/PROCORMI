Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class PollBLL

    Private nombreClase As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As PollBLL
        Return New PollBLL
    End Function

    Public Function PostNewPoll(poll As PollEN) As Reply(Of Boolean)

        Dim reply As New Reply(Of Boolean)
        reply = PollDAO.Instance.PostNewPoll(poll)
        Return reply

    End Function

    Public Function getLink() As String
        Dim reply As String
        reply = PollDAO.Instance.getLink()
        Return reply
    End Function

    Public Function GetAllPolls() As Reply(Of List(Of PollEN))

        Dim Lista As Reply(Of List(Of PollEN)) = Nothing

        Try
            Lista = PollDAO.Instance.GetAllPolls()
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
        End Try
        Return Lista

    End Function

    Public Function GetPoll(pollIdEncrypted As String) As PollEN

        Dim poll As PollEN = Nothing

        Try
            poll = PollDAO.Instance.GetPoll(pollIdEncrypted)
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
        End Try
        Return poll

    End Function

    Public Function DeletePoll(pollId As Integer) As Task(Of Reply(Of Boolean))

        Dim reply As Task(Of Reply(Of Boolean))
        reply = PollDAO.Instance.DeletePoll(pollId)
        Return reply

    End Function

End Class
