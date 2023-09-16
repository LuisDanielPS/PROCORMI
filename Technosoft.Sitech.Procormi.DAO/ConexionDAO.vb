Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class ConexionDAO

    Private nombreClase As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Private conStr As String
    Private conn As MySqlConnection
    Public sql As MySqlCommand
    Private sBD As String
    Private susuario As String
    Private spass As String

    Private dr As MySqlDataReader = Nothing

    Public Property Conexion() As String
        Get
            Return conStr
        End Get
        Set(ByVal value As String)
            conStr = value
        End Set
    End Property

    Public Property BD() As String
        Get
            Return sBD
        End Get
        Set(ByVal value As String)
            sBD = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return susuario
        End Get
        Set(ByVal value As String)
            susuario = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return spass
        End Get
        Set(ByVal value As String)
            spass = value
        End Set
    End Property

    Sub New()
        conStr = System.Configuration.ConfigurationManager.ConnectionStrings("Conn").ConnectionString
    End Sub

    Public Shared Function Instancia() As ConexionDAO
        Return New ConexionDAO
    End Function

    Public Function abrirConexion() As MySqlConnection
        Dim conn As MySqlConnection = Nothing
        Try
            conn = New MySqlConnection(conStr)
            Return conn
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al conectar a la Base de Datos")
        End Try
        Return conn
    End Function

    Public Function EjecutarConsultaLogin(ByVal psSql As String,
                                             ByVal param1 As String,
                                             ByVal param2 As String) As MySqlDataReader
        Try
            If dr IsNot Nothing Then dr.Close()

            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@filtro1", param1)
            sql.Parameters.AddWithValue("@filtro2", param2)
            sql.CommandType = CommandType.Text
            conn.Open()
            dr = sql.ExecuteReader(CommandBehavior.CloseConnection)
            sql.Dispose()
            sql = Nothing
            Return dr

        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la consulta")
        End Try

    End Function

    Private Function CrearCommand(ByVal p_strConsulta As String,
                                  ByVal p_modo As CommandType,
                                  ByVal p_objCon As MySqlConnection,
                                  ByVal p_objParam As List(Of IDataParameter)) As MySqlCommand

        Dim cmd As MySqlCommand = Nothing
        Try
            cmd = New MySqlCommand(p_strConsulta, p_objCon)
            cmd.CommandType = p_modo
            cmd.Parameters.Clear()
            For Each parametro As IDataParameter In p_objParam
                cmd.Parameters.Add(parametro)
            Next
        Catch ex As Exception
            System.Diagnostics.EventLog.WriteEntry("Application", String.Format("Error ejecutando consulta {0}, Error {1}", p_strConsulta, ex.Message))
            Throw New Exception("Imposible ejecutar consulta.")
        End Try
        Return cmd
    End Function

    Public Sub Cerrar()
        If dr IsNot Nothing Then dr.Close()
        If conn IsNot Nothing Then
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End If
    End Sub

End Class
