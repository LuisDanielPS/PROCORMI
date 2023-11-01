
Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT
Public Class NotificationBLL

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As NotificationBLL
        Return New NotificationBLL
    End Function

    Public Function GetAllNotificationByUser(username As String) As Reply(Of List(Of NotificationEN))



        Dim reply As Reply(Of List(Of NotificationEN)) = Nothing

        Try

            reply = NotificationDAO.Instance.GetNotificationsByUser(username)

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar notificaciones"
        End Try

        Return reply

    End Function

End Class
