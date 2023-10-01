Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT
Public Class UsuarioBLL

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As UsuarioBLL
        Return New UsuarioBLL
    End Function


    Public Function GetAllUsersBLL() As Reply(Of List(Of UsuarioEN))



        Dim reply As Reply(Of List(Of UsuarioEN)) = Nothing

        Try

            reply = UserDAO.Instance.GetUserAllDAO()

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de encontrar usuarios"
        End Try

        Return reply

    End Function
End Class
