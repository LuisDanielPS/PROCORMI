Imports System.Net
Imports System.Reflection
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class ActionsController
        Inherits ApiController

        <HttpPost>
        Public Function PostNewAction(action As ActionEN)

            Dim reply As New Reply(Of ActionEN)
            reply = ActionsBLL.Instance.PostActionBLL(action)
            Return reply

        End Function
    End Class
End Namespace