Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class LoginBLL

    Private nombreClase As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instancia() As LoginBLL
        Return New LoginBLL
    End Function

    Public Function GetLoginBLL(ByVal pUsuario As String, ByVal pPass As String) As Reply(Of UsuarioEN)

        Dim Usuario As String = ""
        Dim Password As String = ""
        Dim reply As Reply(Of UsuarioEN) = Nothing

        Try
            If pUsuario IsNot Nothing And pPass IsNot Nothing Then
                Usuario = pUsuario
                Password = pPass

                reply = LoginDAO.Instancia.GetLoginDAO(Usuario, Password)

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de iniciar sesión"
        End Try

        Return reply

    End Function

End Class
