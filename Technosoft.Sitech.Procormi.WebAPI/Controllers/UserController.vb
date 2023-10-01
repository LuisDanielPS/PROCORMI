Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class UserController
        Inherits ApiController

        <HttpGet>
        Public Function GetALLUsers() As Reply(Of List(Of UsuarioEN))

            Dim reply As Reply(Of List(Of UsuarioEN))
            reply = UsuarioBLL.Instance.GetAllUsersBLL()
            Return reply

        End Function

    End Class
End Namespace