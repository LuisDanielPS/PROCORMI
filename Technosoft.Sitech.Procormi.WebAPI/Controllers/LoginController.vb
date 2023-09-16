Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT

Namespace Controllers
    Public Class LoginController
        Inherits ApiController

        Public Function GetLogin(Usu As String, Pass As String) As Reply(Of UsuarioEN)

            Dim reply As Reply(Of UsuarioEN) = New Reply(Of UsuarioEN)()
            reply = LoginBLL.Instancia.GetLoginBLL(Usu, Pass)
            Return reply

        End Function

    End Class
End Namespace