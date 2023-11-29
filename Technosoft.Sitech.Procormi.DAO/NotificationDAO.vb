Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class NotificationDAO

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As NotificationDAO
        Return New NotificationDAO
    End Function

    Dim sentence As String = ""

    Public Function GetNotificationsByUser(username As String) As Reply(Of List(Of NotificationEN))

        Dim reply As New Reply(Of List(Of NotificationEN))
        Dim data As New List(Of NotificationEN)()

        Try
            sentence = "SELECT Id_Notification, Message, Title, Creation_Date, `Read`, `Action`, `Type`, Type_Ref_Id, Usu_Login FROM notification where `Read` = 0 AND Usu_Login = '" & username & "' ORDER BY Creation_Date DESC ;"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)
                While dr.Read
                    Dim obj As New NotificationEN
                    obj.Id_Notification = dr(0)
                    obj.Message = dr(1)
                    obj.Title = dr(2)
                    obj.Creation_Date = dr(3)
                    obj.Read = dr(4)
                    obj.Action = dr(5)
                    obj.Type = dr(6)
                    obj.Type_Ref_Id = dr(7)
                    obj.Usu_Login = dr(8)
                    data.Add(obj)
                End While

                If data.Count > 0 Then
                    reply.obj = data
                    reply.ok = True
                    reply.msg = "Notificaciones encontradas"
                Else
                    reply.obj = Nothing
                    reply.ok = False
                    reply.msg = "Notificaciones no encontrados"
                End If
            End Using

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Notificaciones: No fue posible ejecutar la consulta: " & ex.Message
            Return reply

        End Try
        Return reply
    End Function


    Public Function PostNotification(ByVal pNotification As NotificationEN) As Reply(Of NotificationEN)

        Dim reply As New Reply(Of NotificationEN)

        Try
            If pNotification Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto de la notification esta vacio"

            ElseIf pNotification IsNot Nothing Then
                sentence = "INSERT INTO notification (Message, Title, Action, Type, Type_Ref_Id, Usu_Login) VALUES (@Message, @Title, @Action, @Type, @Type_Ref_Id, @Usu_Login)"
                ConexionDAO.Instancia.ExecuteInsertNotification(sentence, pNotification)

                reply.ok = True
                reply.msg = "Se ha creado Correctamente"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Notification: No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try

        Return reply

    End Function


    Public Function NotifyAssignedSprint(ByVal pUser As String, ByVal pIdSprint As Integer) As Reply(Of NotificationEN)
        Dim reply As New Reply(Of NotificationEN)
        Try
            Dim notification = New NotificationEN()
            notification.Action = "Agregado"
            notification.Title = "Nuevo Sprint"

            sentence = "SELECT Sprint_Name from sprint where Id_Sprint = " & pIdSprint
            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)
                If dr.Read Then
                    notification.Message = "Se le ha asignado el sprint: " + dr(0)
                End If
            End Using

            notification.Usu_Login = pUser
            notification.Type = "sprint"
            notification.Type_Ref_Id = pIdSprint

            Return PostNotification(notification)
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "NotifyAssignedSprint: No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try
    End Function


    Public Function NotifyUnassignedSprint(ByVal pUser As String, ByVal pIdSprint As Integer) As Reply(Of NotificationEN)
        Dim reply As New Reply(Of NotificationEN)
        Try
            Dim notification = New NotificationEN()
            notification.Action = "DESASIGNADO"
            notification.Title = "Desasignacion de sprint"

            sentence = "SELECT Sprint_Name from sprint where Id_Sprint = " & pIdSprint
            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)
                If dr.Read Then
                    notification.Message = "El sprint " + dr(0) + " te ha sido desasignado"
                End If
            End Using

            notification.Usu_Login = pUser
            notification.Type = "sprint"
            notification.Type_Ref_Id = pIdSprint

            Return PostNotification(notification)
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "NotifyUnassignedSprint: No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try
    End Function


    Public Function NotifySprintCompleted(ByVal pIdSprint As Integer) As Reply(Of NotificationEN)
        Dim reply As New Reply(Of NotificationEN)
        Try
            Dim pUser As String = ""
            Dim notification = New NotificationEN()
            notification.Action = "Finalizado"
            notification.Title = "Sprint completado"

            sentence = "SELECT Sprint_Name, User_Login from sprint where Id_Sprint = " & pIdSprint
            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)
                If dr.Read Then
                    notification.Message = "El sprint " + dr(0) + " ha finalizado"
                    pUser = dr(1)
                End If
            End Using

            notification.Usu_Login = pUser
            notification.Type = "sprint"
            notification.Type_Ref_Id = pIdSprint

            Return PostNotification(notification)
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "NotifySprintCompleted: No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try
    End Function


    Public Function NotifyProjectCompleted(ByVal pIdProject As Integer) As Reply(Of List(Of NotificationEN))
        Dim reply As New Reply(Of List(Of NotificationEN))
        Try
            Dim notifications = New List(Of NotificationEN)
            Dim pUser As String = ""
            Dim notification = New NotificationEN()
            notification.Action = "Finalizado"
            notification.Title = "Proyecto completado"

            sentence = "SELECT  Project_Name, su.User_Login from project p  join seg_usu_project su on su.Id_Project = p.Id_Project where  p.Id_Project = " & pIdProject
            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)
                While dr.Read
                    notification.Message = "El proyecto " + dr(0) + " ha finalizado"
                    pUser = dr(1)

                    notification.Usu_Login = pUser
                    notification.Type = "project"
                    notification.Type_Ref_Id = pIdProject

                    notifications.Add(notification)
                    PostNotification(notification)
                End While
            End Using
            reply.obj = notifications
            Return reply
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "NotifyProjectCompleted: No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try
    End Function


    Public Function NotifySprintDatesChanged(ByVal pUpdatedSprint As SprintEN, ByVal pCurrentSprint As SprintEN) As Reply(Of NotificationEN)
        Dim reply As New Reply(Of NotificationEN)
        Try
            Dim pUser As String = ""
            Dim notification = New NotificationEN()
            notification.Action = "MODIFICATION"
            notification.Title = "Cambios en sprint"

            If (pUpdatedSprint.Equals(pCurrentSprint)) Then
                Return reply
            End If

            sentence = "SELECT Sprint_Name, User_Login from sprint where Id_Sprint = " & pCurrentSprint.Id_Sprint
            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)
                If dr.Read Then
                    If (Not pUpdatedSprint.Start_Date.Equals(pCurrentSprint.Start_Date) And Not pUpdatedSprint.End_Date.Equals(pCurrentSprint.End_Date)) Then
                        notification.Message = "La fecha de inicio y fin han cambiado del sprint " + dr(0)
                    ElseIf Not pUpdatedSprint.End_Date.Equals(pCurrentSprint.End_Date) Then
                        notification.Message = "La fecha de fin ha cambiado del sprint " + dr(0)
                    ElseIf Not pUpdatedSprint.Start_Date.Equals(pCurrentSprint.Start_Date) Then
                        notification.Message = "La fecha de inicio ha cambiado del sprint " + dr(0)
                    End If
                    pUser = dr(1)
                End If
            End Using

            notification.Usu_Login = pUser
            notification.Type = "sprint"
            notification.Type_Ref_Id = pCurrentSprint.Id_Sprint

            Return PostNotification(notification)
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "NotifySprintCompleted: No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try
    End Function



    Public Function ReadNotification(ByVal pIdNotification As Integer) As Reply(Of NotificationEN)

        Dim reply As New Reply(Of NotificationEN)

        Try
            sentence = "UPDATE notification SET `Read` = 1 WHERE Id_Notification = @Condition"
            ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdNotification)

            reply.ok = True
            reply.msg = "Se ha marcado como leida Correctamente"

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Notification (read): No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try

        Return reply

    End Function


End Class
