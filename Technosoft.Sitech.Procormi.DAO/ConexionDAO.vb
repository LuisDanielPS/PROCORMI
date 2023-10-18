Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.EN
Imports System.Data.SqlClient

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



    'Metodos Refactorizacion' 

    'Este metodo se utiliza cuando quieres imprimir un tabla sin mandar parametros'
    Public Function ExecuteConsult(ByVal psSql As String
                                             ) As MySqlDataReader
        Try
            If dr IsNot Nothing Then dr.Close()

            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
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

    'Este metodo se utiliza cuando quieres mandar un solo parametro de tipo string se tiene que utilizar @filtro1'
    Public Function ExecuteConsultOneParameterString(ByVal psSql As String, ByVal pParam As String) As MySqlDataReader
        Try
            If dr IsNot Nothing Then dr.Close()

            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@filtro1", pParam)
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

    'Este metodo se utiliza cuando quieres mandar un solo parametro de tipo integer se tiene que utilizar @filtro1'
    Public Function ExecuteConsultOneParameterInteger(ByVal psSql As String, ByVal pParam As Integer) As MySqlDataReader
        Try
            If dr IsNot Nothing Then dr.Close()

            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@filtro1", pParam)
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


    'Este metodo se utiliza cuando quieres mandar dos parametro de tipo string se tiene que utilizar @filtro1 y @filtro2' 
    Public Function ExecuteConsultTwoParameterString(ByVal psSql As String,
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




    'Este metodo se utiliza cuando quieres mandar un parametro integer  y se utiliza @Condition'
    Public Sub ExecuteConsultCondition(ByVal psSql As String, ByVal pParam As Integer)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@Condition", pParam)
            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la consulta")
        End Try
    End Sub




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


    Public Function ExecutePriorityById(ByVal idPriority As String) As MySqlDataReader
        Try
            If dr IsNot Nothing Then dr.Close()

            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand("SELECT Priority_Name from priority where Id_Priority=@filtro1", conn)
            sql.Parameters.AddWithValue("@filtro1", idPriority)
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


    Public Function ExecutePriorityByName(ByVal priorityName As String) As MySqlDataReader
        Try
            If dr IsNot Nothing Then dr.Close()

            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand("SELECT Id_Priority from priority where Priority_Name=@filtro1", conn)
            sql.Parameters.AddWithValue("@filtro1", priorityName)
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


    Public Sub ExecuteInsertProject(ByVal psSql As String, ByVal Pproject As ProjectEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@parameter1", Pproject.Project_Name)
            sql.Parameters.AddWithValue("@parameter2", Pproject.Description_Project)
            sql.Parameters.AddWithValue("@parameter3", 1)
            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub

    Public Sub ExecuteInsertFile(ByVal psSql As String, ByVal Pfile As FileEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@parameter1", Pfile.File_Name)
            sql.Parameters.AddWithValue("@parameter2", Pfile.File_Type)
            sql.Parameters.AddWithValue("@parameter3", Pfile.File_Size)
            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub


    Public Sub ExecuteInsertSegUsuProject(ByVal psSql As String, ByVal PSegUsuProject As SegUsuProjectEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@parameter1", PSegUsuProject.User_Login)
            sql.Parameters.AddWithValue("@parameter2", PSegUsuProject.Id_Project)
            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub


    Public Sub ExecuteInsertProjectFile(ByVal psSql As String, ByVal pProjectFile As ProjectFileEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@parameter1", pProjectFile.Id_Project)
            sql.Parameters.AddWithValue("@parameter2", pProjectFile.File_ID)
            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub


    Public Sub ExecuteUpdateProject(ByVal psSql As String, ByVal Pproject As ProjectEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@Condition", Pproject.Id_project)
            sql.Parameters.AddWithValue("@parameter1", Pproject.Project_Name)
            sql.Parameters.AddWithValue("@parameter2", Pproject.Description_Project)
            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub


    Public Sub ExecuteInsertSprint(ByVal psSql As String, ByVal parametros As List(Of IDataParameter))
        Try
            conn = New MySqlConnection(conStr)
            sql = CrearCommand(psSql, CommandType.Text, conn, parametros)
            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            sql.Dispose()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub


    Public Sub ExecuteUpdateSprint(ByVal psSql As String, ByVal Psprint As SprintEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@Condition", Psprint.Id_Sprint)
            sql.Parameters.AddWithValue("@parameter1", Psprint.Sprint_Name)
            sql.Parameters.AddWithValue("@parameter2", Psprint.Start_Date)
            sql.Parameters.AddWithValue("@parameter3", Psprint.End_Date)
            sql.Parameters.AddWithValue("@parameter4", Psprint.User_Login)
            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub


    Public Function ExecuteStateById(ByVal idState As String) As MySqlDataReader
        Try
            If dr IsNot Nothing Then dr.Close()

            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand("SELECT Status_Name from status where Id_Status=@filtro1", conn)
            sql.Parameters.AddWithValue("@filtro1", idState)
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

    Public Function ExecuteStateByName(ByVal stateName As String) As MySqlDataReader
        Try
            If dr IsNot Nothing Then dr.Close()

            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand("SELECT Id_Status from status where Status_Name=@filtro1", conn)
            sql.Parameters.AddWithValue("@filtro1", stateName)
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

    Public Sub ExecuteInsertTask(ByVal psSql As String, ByVal Ptask As TaskEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@parameter2", Ptask.Task_Name)
            sql.Parameters.AddWithValue("@parameter3", Ptask.Description_Task)
            sql.Parameters.AddWithValue("@parameter4", Ptask.Id_Sprint)



            Dim dr1 As MySqlDataReader
            dr1 = ConexionDAO.Instancia.ExecuteStateByName("Activo")
            If (dr1.Read) Then
                sql.Parameters.AddWithValue("@parameter5", dr1(0))
            End If

            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub

    Public Sub ExecuteUpdateTask(ByVal psSql As String, ByVal Ptask As TaskEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@Condition", Ptask.Id_Task)
            sql.Parameters.AddWithValue("@parameter1", Ptask.Task_Name)
            sql.Parameters.AddWithValue("@parameter2", Ptask.Description_Task)
            sql.Parameters.AddWithValue("@parameter3", Ptask.Id_Sprint)

            Dim dr1 As MySqlDataReader
            dr1 = ConexionDAO.Instancia.ExecuteStateByName(Ptask.Id_Status)
            If (dr1.Read) Then
                sql.Parameters.AddWithValue("@parameter4", dr1(0))
            End If

            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub


    Public Sub ExecuteInsertSubTask(ByVal psSql As String, ByVal PsubTask As SubTaskEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)

            sql.Parameters.AddWithValue("@parameter1", PsubTask.Title)
            sql.Parameters.AddWithValue("@parameter2", PsubTask.Description)
            sql.Parameters.AddWithValue("@parameter3", PsubTask.Required_Time)
            sql.Parameters.AddWithValue("@parameter4", PsubTask.Id_Task)

            ' Insertar id de status en ves de string
            Dim dr1 As MySqlDataReader
            dr1 = ConexionDAO.Instancia.ExecuteStateByName(PsubTask.Id_Status)
            If (dr1.Read) Then
                sql.Parameters.AddWithValue("@parameter5", dr1(0))
            End If

            ' Insertar id de priority en ves de string
            dr1 = ConexionDAO.Instancia.ExecutePriorityByName(PsubTask.Id_Priority)
            If (dr1.Read) Then
                sql.Parameters.AddWithValue("@parameter6", dr1(0))
            End If

            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub

    Public Sub ExecuteUpdateSubTask(ByVal psSql As String, ByVal PsubTask As SubTaskEN)
        Try
            conn = New MySqlConnection(conStr)
            sql = New MySqlCommand(psSql, conn)
            sql.Parameters.AddWithValue("@Condition", PsubTask.Id_Sub_Task)
            sql.Parameters.AddWithValue("@parameter1", PsubTask.Title)
            sql.Parameters.AddWithValue("@parameter2", PsubTask.Description)
            sql.Parameters.AddWithValue("@parameter3", PsubTask.Required_Time)
            sql.Parameters.AddWithValue("@parameter4", PsubTask.Id_Task)

            Dim dr1 As MySqlDataReader
            dr1 = ConexionDAO.Instancia.ExecuteStateByName(PsubTask.Id_Status)
            If (dr1.Read) Then
                sql.Parameters.AddWithValue("@parameter5", dr1(0))
            End If

            dr1 = ConexionDAO.Instancia.ExecutePriorityByName(PsubTask.Id_Priority)
            If (dr1.Read) Then
                sql.Parameters.AddWithValue("@parameter6", dr1(0))
            End If

            sql.CommandType = CommandType.Text
            conn.Open()
            sql.ExecuteNonQuery()
            conn.Close()
        Catch ex As MySqlException
            EscritorVisorEventos.Instancia().EscribirEvento(nombreClase, MethodBase.GetCurrentMethod().Name, ex)
            Throw New Exception("Error al ejecutar la inserción")
        End Try
    End Sub


    Public Sub Cerrar()
        If dr IsNot Nothing Then dr.Close()
        If conn IsNot Nothing Then
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End If
    End Sub

End Class
