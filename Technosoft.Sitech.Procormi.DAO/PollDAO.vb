Imports System.Configuration
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class PollDAO

    Public rutaEncuesta As String = ConfigurationManager.AppSettings("rutaEncuesta")
    Private nombreClase As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As PollDAO
        Return New PollDAO
    End Function

    Dim sentence As String = ""

    Public Function PostNewPoll(poll As PollEN) As Reply(Of Boolean)

        Dim reply As New Reply(Of Boolean)
        Dim creationDate As New DateTime
        Dim idPoll As New Integer
        creationDate = DateTime.Now
        Dim format As String = "yyyy-MM-dd HH:mm:ss"
        Dim formatDate As String = creationDate.ToString(format)
        'Dim idEncriptado As String

        Try

            sentence = "INSERT INTO poll (Name, Description, Creation_Date) VALUES ('" & poll.Name & "', '" & poll.Description & "', '" & formatDate & "');"

            ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)

            idPoll = LastPoll()

            For Each question In poll.Questions

                sentence = ""
                sentence = "INSERT INTO question (TextQuestion, Id_Poll, Id_Question_Type) VALUES ('" & question.TextQuestion & "', " & idPoll & ", " & question.Id_Question_Type & ");"

                ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)

                Dim idQuestion As New Integer
                idQuestion = LastQuestion()

                If question.Question_Options IsNot Nothing Then
                    For Each opt In question.Question_Options
                        sentence = ""
                        sentence = "INSERT INTO question_options (Id_Question, Option_Text) VALUES (" & idQuestion & ", '" & opt.Option_Text & "');"

                        ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)
                    Next
                End If

            Next

            'idEncriptado = Encrypt(idPoll)

            reply.ok = True
            reply.obj = True
            reply.msg = "Encuesta registrada con éxito. Puede consultar el link desde la sección de visualizar encuesta."

        Catch ex As Exception

            reply.ok = False
            reply.obj = False
            reply.msg = "Error al registrar la encuesta: " & ex.Message

        End Try

        Return reply

    End Function

    Public Function UpdatePull(poll As PollEN) As Reply(Of Boolean)
        Dim reply As New Reply(Of Boolean)
        Dim editingPoll As New PollEN

        Try

            editingPoll = GetPoll(Encrypt(poll.Id_Poll))

            sentence = "UPDATE Poll set Name = '" & poll.Name & "', Description = '" & poll.Description & "' WHERE Id_Poll = " & poll.Id_Poll & ";"

            ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)

            For Each question In editingPoll.Questions

                sentence = ""
                sentence = "Delete FROM question_options WHERE Id_Question = " & question.Id_Question & ";"

                ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)

                sentence = ""
                sentence = "Delete FROM question WHERE Id_Question = " & question.Id_Question & ";"

                ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)

            Next

            For Each question In poll.Questions

                sentence = ""
                sentence = "INSERT INTO question (TextQuestion, Id_Poll, Id_Question_Type) VALUES ('" & question.TextQuestion & "', " & poll.Id_Poll & ", " & question.Id_Question_Type & ");"

                ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)

                Dim idQuestion As New Integer
                idQuestion = LastQuestion()

                If question.Question_Options IsNot Nothing Then
                    For Each opt In question.Question_Options
                        sentence = ""
                        sentence = "INSERT INTO question_options (Id_Question, Option_Text) VALUES (" & idQuestion & ", '" & opt.Option_Text & "');"

                        ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)
                    Next
                End If

            Next

            reply.ok = True
            reply.obj = True
            reply.msg = "Encuesta modificada con éxito."

        Catch ex As Exception

            reply.ok = False
            reply.obj = False
            reply.msg = "Error al modificar la encuesta: " & ex.Message

        End Try

        Return reply

    End Function

    Public Function PostSendAnswer(poll As PollEN) As Reply(Of Boolean)

        Dim reply As New Reply(Of Boolean)


        Try


            For Each question In poll.Questions

                If question.AnswerText IsNot Nothing Then

                    sentence = "INSERT INTO answer_text (Text, Id_Question) VALUES ('" & question.AnswerText.Text & "', " & question.Id_Question & ");"

                    ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)
                End If


                If question.AnswerOptions IsNot Nothing Then
                    For Each opt In question.AnswerOptions
                        sentence = ""
                        sentence = "INSERT INTO answer_options (Id_Question_Option) VALUES ('" & opt.Id_Question_Option & "');"

                        ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)
                    Next
                End If

            Next


            reply.ok = True
            reply.obj = True
            reply.msg = "Se envio correctamente la encuesta"

        Catch ex As Exception

            reply.ok = False
            reply.obj = False
            reply.msg = "Error al enviar la encuesta " & ex.Message

        End Try

        Return reply

    End Function


    Public Function getLink() As String
        Try
            Return rutaEncuesta
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

#Region "Listados"

    Public Function GetAllPolls() As Reply(Of List(Of PollEN))

        Dim reply As New Reply(Of List(Of PollEN))
        Dim polls As New List(Of PollEN)
        Dim list As MySqlDataReader

        Try
            sentence = "SELECT * FROM poll"

            list = ConexionDAO.Instancia.EjecutarConsultaListados(sentence)

            While list.Read
                Dim poll As New PollEN
                poll.Id_Poll = list(0)
                poll.Name = list(1)
                poll.Description = list(2)
                poll.Creation_Date = list(3)
                polls.Add(poll)
            End While

            reply.obj = polls

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
        End Try

        list.Close()
        list.Dispose()

        Return reply

    End Function


    Public Function GetPoll(pollIdEncrypted As String) As PollEN
        Dim poll As New PollEN
        Dim pollId = Desencrypt(pollIdEncrypted)

        Try
            Dim sentence As String = "SELECT Id_Poll, Name, Description, Creation_Date FROM poll WHERE Id_Poll = " & pollId & ";"
            Dim pollList As MySqlDataReader = ConexionDAO.Instancia.EjecutarConsultaListados(sentence)
            While pollList.Read
                poll.Id_Poll = pollList(0)
                poll.Name = pollList(1)
                poll.Description = pollList(2)
                poll.Creation_Date = pollList(3)
            End While
            pollList.Close()

            If poll IsNot Nothing Then
                poll.Questions = New List(Of QuestionEN)()
                Dim questionsSentence As String = "SELECT Id_Question, TextQuestion, Id_Poll, Id_Question_Type FROM question WHERE Id_Poll = " & pollId & ";"
                Dim questionsList As MySqlDataReader = ConexionDAO.Instancia.EjecutarConsultaListados(questionsSentence)
                While questionsList.Read()
                    Dim question As New QuestionEN()
                    question.Id_Question = questionsList(0)
                    question.TextQuestion = questionsList(1)
                    question.Id_Poll = questionsList(2)
                    question.Id_Question_Type = questionsList(3)

                    question.Question_Options = New List(Of QuestionOptionsEN)()
                    Dim optionsSentence As String = "SELECT Id_Question_Option, Option_Text FROM question_options WHERE Id_Question = " & question.Id_Question & ";"
                    Dim optionsList As MySqlDataReader = ConexionDAO.Instancia.EjecutarConsultaListados(optionsSentence)
                    While optionsList.Read()
                        Dim opt As New QuestionOptionsEN()
                        opt.Id_Question_Option = optionsList(0)
                        opt.Option_Text = optionsList(1)
                        question.Question_Options.Add(opt)
                    End While
                    optionsList.Close()

                    poll.Questions.Add(question)
                End While
                questionsList.Close()
            End If

            Return poll

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
        End Try

        Return poll
    End Function

    Public Function GetPollSimple(pollId As String) As PollEN
        Dim poll As New PollEN

        Try
            Dim sentence As String = "SELECT Id_Poll, Name, Description, Creation_Date FROM poll WHERE Id_Poll = " & pollId & ";"
            Dim pollList As MySqlDataReader = ConexionDAO.Instancia.EjecutarConsultaListados(sentence)
            While pollList.Read
                poll.Id_Poll = pollList(0)
                poll.Name = pollList(1)
                poll.Description = pollList(2)
                poll.Creation_Date = pollList(3)
            End While
            pollList.Close()

            If poll IsNot Nothing Then
                poll.Questions = New List(Of QuestionEN)()
                Dim questionsSentence As String = "SELECT Id_Question, TextQuestion, Id_Poll, Id_Question_Type FROM question WHERE Id_Poll = " & pollId & ";"
                Dim questionsList As MySqlDataReader = ConexionDAO.Instancia.EjecutarConsultaListados(questionsSentence)
                While questionsList.Read()
                    Dim question As New QuestionEN()
                    question.Id_Question = questionsList(0)
                    question.TextQuestion = questionsList(1)
                    question.Id_Poll = questionsList(2)
                    question.Id_Question_Type = questionsList(3)

                    question.Question_Options = New List(Of QuestionOptionsEN)()
                    Dim optionsSentence As String = "SELECT Id_Question_Option, Option_Text FROM question_options WHERE Id_Question = " & question.Id_Question & ";"
                    Dim optionsList As MySqlDataReader = ConexionDAO.Instancia.EjecutarConsultaListados(optionsSentence)
                    While optionsList.Read()
                        Dim opt As New QuestionOptionsEN()
                        opt.Id_Question_Option = optionsList(0)
                        opt.Option_Text = optionsList(1)
                        question.Question_Options.Add(opt)
                    End While
                    optionsList.Close()

                    poll.Questions.Add(question)
                End While
                questionsList.Close()
            End If

            Return poll

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
        End Try

        Return poll
    End Function

    Public Function GetPollReportDAO(pollId As String) As Reply(Of List(Of PollReportVM))
        Dim reply As New Reply(Of List(Of PollReportVM))
        Dim pollReports As New List(Of PollReportVM)()

        Try

            Dim query1 As String = "SELECT
            p.Id_Poll,
            q.TextQuestion,
            GROUP_CONCAT(at.Text) AS AnswerTexts
        FROM
            poll p
        JOIN
            question q ON p.Id_Poll = q.Id_Poll
        LEFT JOIN
            answer_text at ON q.Id_Question = at.Id_Question
        WHERE p.Id_Poll = " + pollId + "
        GROUP BY p.Id_Poll, q.TextQuestion
        HAVING SUM(at.Text IS NOT NULL) > 0"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(query1)
                While dr.Read
                    Dim pollReport As New PollReportVM
                    pollReport.Id_Poll = dr(0)
                    pollReport.TextQuestion = dr(1)
                    pollReport.AnswerTexts = dr(2)
                    pollReports.Add(pollReport)
                End While
            End Using


            Dim query2 As String = "SELECT
            p.Id_Poll,
            q.TextQuestion,
            qt.Question_Type_Name,
            qo.Option_Text AS OptionText,
            COUNT(DISTINCT ao.Id_Answer_Option) AS AnswerOptionCount
        FROM
            poll p
        JOIN
            question q ON p.Id_Poll = q.Id_Poll
        JOIN
            question_type qt ON q.Id_Question_Type = qt.Id_Question_Type
        LEFT JOIN
            question_options qo ON q.Id_Question = qo.Id_Question
        LEFT JOIN
            answer_text at ON q.Id_Question = at.Id_Question
        LEFT JOIN
            answer_options ao ON qo.Id_Question_Option = ao.Id_Question_Option
        WHERE p.Id_Poll = " + pollId + " AND qt.Question_Type_Name <> 'Texto'
        GROUP BY p.Id_Poll, q.TextQuestion, qt.Question_Type_Name, qo.Option_Text"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(query2)
                While dr.Read
                    Dim pollReport As New PollReportVM
                    pollReport.Id_Poll = dr(0)
                    pollReport.TextQuestion = dr(1)
                    pollReport.Question_Type_Name = dr(2)
                    pollReport.OptionText = dr(3)
                    pollReport.AnswerOptionCount = dr(4)
                    pollReports.Add(pollReport)
                End While
            End Using

            If pollReports.Count > 0 Then
                reply.obj = pollReports
                reply.ok = True
                reply.msg = "Encuesta encontrados"
            Else
                reply.obj = Nothing
                reply.ok = False
                reply.msg = "Encuesta no encontrados"
            End If

        Catch ex As Exception
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try

        Return reply
    End Function


#End Region

#Region "Selects"

    Public Function LastPoll() As Integer

        Dim reply As New Reply(Of Integer)
        Dim dr As MySqlDataReader
        Dim consecutivo As Integer = 0

        Try

            sentence = "SELECT Id_Poll FROM poll ORDER BY Id_Poll DESC LIMIT 1"

            dr = ConexionDAO.Instancia.EjecutarConsultaListados(sentence)

            While dr.Read
                consecutivo = dr(0)
            End While

            reply.ok = True

        Catch ex As Exception
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message & " / " & ex.InnerException.Message, EventLogEntryType.Error, EventLogEntryType.Error, EventLogEntryType.Error)
            reply.obj = Nothing
            reply.ok = False
        End Try

        dr.Close()
        dr.Dispose()

        Return consecutivo

    End Function

    Public Function LastQuestion() As Integer

        Dim reply As New Reply(Of Integer)
        Dim dr As MySqlDataReader
        Dim consecutivo As Integer = 0

        Try

            sentence = "SELECT Id_Question FROM question ORDER BY Id_Question DESC LIMIT 1"

            dr = ConexionDAO.Instancia.EjecutarConsultaListados(sentence)

            While dr.Read
                consecutivo = dr(0)
            End While

            reply.ok = True

        Catch ex As Exception
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message & " / " & ex.InnerException.Message, EventLogEntryType.Error, EventLogEntryType.Error, EventLogEntryType.Error)
            reply.obj = Nothing
            reply.ok = False
        End Try

        dr.Close()
        dr.Dispose()

        Return consecutivo

    End Function

#End Region

#Region "Deletes"

    Public Async Function DeletePoll(pollId As Integer) As Task(Of Reply(Of Boolean))
        Dim reply As New Reply(Of Boolean)
        Dim Id_Question As New Integer
        Dim Id_Question_Type As String
        Dim dr As MySqlDataReader

        Try

            sentence = "select Id_Question, Id_Question_Type from question where Id_Poll = " & pollId & ";"
            dr = ConexionDAO.Instancia.EjecutarConsultaListados(sentence)

            While dr.Read
                Id_Question = dr(0)
                Id_Question_Type = dr(1)

                If Id_Question_Type = 2 Or Id_Question_Type = 3 Then
                    Await DeleteQuestionOptions(Id_Question)
                End If

            End While

            Await DeleteQuestions(pollId)

            sentence = "DELETE from poll where Id_Poll = " & pollId & ";"
            ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)

            reply.ok = True
            reply.obj = True
            reply.msg = "Encuesta eliminada con éxito"

        Catch ex As Exception

            reply.ok = False
            reply.obj = False
            reply.msg = "Error al eliminar la encuesta: " & ex.Message

        End Try

        Return reply

    End Function

    Public Async Function DeleteQuestions(pollId As Integer) As Task(Of Reply(Of Boolean))

        Dim reply As New Reply(Of Boolean)
        Dim Id_Question As New Integer

        Try

            sentence = "DELETE from question where Id_Poll = " & pollId & ";"
            ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)

            reply.ok = True
            reply.obj = True
            reply.msg = "Pregunta eliminada con éxito"

        Catch ex As Exception

            reply.ok = False
            reply.obj = False
            reply.msg = "Error al eliminar la pregunta: " & ex.Message

        End Try

        Return reply

    End Function

    Public Async Function DeleteQuestionOptions(QId As Integer) As Task(Of Reply(Of Boolean))

        Dim reply As New Reply(Of Boolean)
        Dim Id_Question As New Integer

        Try

            sentence = "DELETE from question_options where Id_Question = " & QId & ";"
            ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)

            reply.ok = True
            reply.obj = True
            reply.msg = "Opción eliminada con éxito"

        Catch ex As Exception

            reply.ok = False
            reply.obj = False
            reply.msg = "Error al eliminar la opción: " & ex.Message

        End Try

        Return reply

    End Function

#End Region

#Region "Encriptación"

    Public Function Encrypt(ByVal valor As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("cmprmasr")
        Dim EncryptionKey() As Byte = Convert.FromBase64String("prmDMvIvPNlrmcsgLM1/c34GHjA7D2P2")
        Dim buffer() As Byte = Encoding.UTF8.GetBytes(valor)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV

        Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function


    Public Function Desencrypt(ByVal valor As String) As String
        Dim EncryptionKey() As Byte = Convert.FromBase64String("prmDMvIvPNlrmcsgLM1/c34GHjA7D2P2")
        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("cmprmasr")
        Dim buffer() As Byte = Convert.FromBase64String(valor)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV
        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
    End Function

#End Region

End Class
