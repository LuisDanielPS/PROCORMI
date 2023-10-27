Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class UserDAO
    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As UserDAO
        Return New UserDAO
    End Function

    Dim sentence As String = ""

    Public Function GetUserAllDAO() As Reply(Of List(Of UsuarioEN))

        Dim reply As New Reply(Of List(Of UsuarioEN))
        Dim UsersList As New List(Of UsuarioEN)()

        Try

            sentence = "SELECT usu_Login , usu_Nombre , usu_Tipo , usu_Fecha , usu_Vigencia , usu_email , usu_remote , horario_numero FROM seg_usu"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)

                While dr.Read
                    Dim user As New UsuarioEN
                    user.usu_Login = dr(0)
                    user.usu_Nombre = dr(1)
                    user.usu_Tipo = dr(2)
                    user.usu_Fecha = dr(3)
                    user.usu_Vigencia = dr(4)
                    user.usu_email = dr(5)
                    user.usu_remote = dr(6)
                    user.horario_numero = dr(7)

                    UsersList.Add(user)

                End While

                If UsersList.Count > 0 Then
                    reply.obj = UsersList
                    reply.ok = True
                    reply.msg = "Usuarios encontrados"
                Else
                    reply.obj = Nothing
                    reply.ok = False
                    reply.msg = "Usuarios no encontrados"
                End If
            End Using
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply


        End Try

        Return reply
    End Function

End Class
