Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class NotificationController
        Inherits ApiController

        <HttpGet>
        Public Function GetAllNotificationByUser(username As String) As Reply(Of List(Of NotificationEN))
            Dim reply As Reply(Of List(Of NotificationEN))
            reply = NotificationBLL.Instance.GetAllNotificationByUser(username)
            Return reply
        End Function

        <HttpPut>
        Public Function PutReadNotification(pIdNotification As Integer) As Reply(Of NotificationEN)
            Dim reply As Reply(Of NotificationEN)
            reply = NotificationBLL.Instance.ReadNotification(pIdNotification)
            Return reply
        End Function

    End Class
End Namespace