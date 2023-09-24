Imports System.Configuration
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class LoginDAO

    Private nombreClase As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instancia() As LoginDAO
        Return New LoginDAO
    End Function

    Dim sentencia As String = ""

    Public Function GetLoginDAO(ByVal pUsu As String, ByVal pPass As String) As Reply(Of UsuarioEN)

        Dim reply As New Reply(Of UsuarioEN)
        Dim dr As MySqlDataReader

        Dim pClave = DesencriptarContraseña(pPass)

        Try

            sentencia = "SELECT * FROM seg_usu WHERE usu_Login = @filtro1 And usu_Password = @filtro2"

            dr = ConexionDAO.Instancia.EjecutarConsultaLogin(sentencia, pUsu, pClave)

            While dr.Read
                Dim usu As New UsuarioEN
                usu.usu_Login = dr(0)
                usu.usu_Nombre = dr(1)
                usu.usu_Password = dr(2)
                usu.usu_Tipo = dr(3)
                usu.usu_Fecha = dr(4)
                usu.usu_Vigencia = dr(5)
                usu.usu_email = dr(6)
                usu.usu_remote = dr(7)
                usu.horario_numero = dr(8)
                'usu.usu_Departamento = dr(9)
                reply.obj = usu
            End While

            If reply.obj IsNot Nothing Then
                reply.ok = True
                reply.msg = "Usuario encontrado"
            ElseIf reply.obj Is Nothing Then
                reply.ok = False
                reply.msg = "Usuario o contraseña incorrectos"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try

        dr.Close()
        dr.Dispose()

        Return reply


    End Function

    Public Function DesencriptarContraseña(ByVal contraseñaEncriptada As String) As String
        Dim EncryptionKey() As Byte = Convert.FromBase64String("prmDMvIvPNlrmcsgLM1/c34GHjA7D2P2")
        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("cmprmasr")
        Dim buffer() As Byte = Convert.FromBase64String(contraseñaEncriptada)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV
        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
    End Function

End Class
