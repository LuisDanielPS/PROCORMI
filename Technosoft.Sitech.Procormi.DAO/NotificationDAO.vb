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
            sentence = "SELECT Id_Notification, Message, Title, Creation_Date, `Read`, `Action`, `Type`, Type_Ref_Id, Usu_Login FROM notification where Usu_Login = '" & username & "' ORDER BY Creation_Date DESC ;"

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

End Class
