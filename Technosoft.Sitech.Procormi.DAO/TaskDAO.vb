Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class TaskDao

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As TaskDao
        Return New TaskDao
    End Function

    Dim sentence As String = ""

    Public Function GetTasksAllDAO(idSprint As Integer) As Reply(Of List(Of TaskEN))

        Dim reply As New Reply(Of List(Of TaskEN))
        Dim dr As MySqlDataReader
        Dim dr1 As MySqlDataReader
        Dim tareas As New List(Of TaskEN)()

        Try

            sentence = "SELECT * FROM task where not Id_Status = 2 and Id_Sprint = " & idSprint & ";"

            dr = ConexionDAO.Instancia.ExecuteConsultGetAllProjects(sentence)

            While dr.Read
                Dim task As New TaskEN
                task.Id_Task = dr(0)
                task.Task_Name = dr(1)
                task.Description_Task = dr(2)
                task.Id_Sprint = dr(3)
                task.Id_Status = dr(4)

                tareas.Add(task)
            End While

            If tareas.Count > 0 Then
                reply.obj = tareas
                reply.ok = True
                reply.msg = "Tareas encontradas"
            Else
                reply.obj = Nothing
                reply.ok = False
                reply.msg = "Tareas no encontrados"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply

        End Try
        dr.Close()
        dr.Dispose()

        Return reply
    End Function

    Public Function GetTasksAllDAO(ByVal sprintId As String) As Reply(Of List(Of TaskEN))

        Dim reply As New Reply(Of List(Of TaskEN))
        Dim dr As MySqlDataReader
        Dim dr1 As MySqlDataReader
        Dim tareas As New List(Of TaskEN)()

        Try

            sentence = "SELECT * FROM task where Id_Sprint=@filtro1 and Id_Status= 1"
            dr = ConexionDAO.Instancia.ExecuteConsultGetAllTasks(sentence, sprintId)

            While dr.Read
                Dim task As New TaskEN
                task.Id_Task = dr(0)
                task.Task_Name = dr(1)
                task.Description_Task = dr(2)
                task.Id_Sprint = dr(3)
                task.Id_Status = dr(4)

                ' Get state name instead of id
                dr1 = ConexionDAO.Instancia.ExecuteStateById(task.Id_Status)
                If (dr1.Read) Then
                    task.Id_Status = dr1(0)
                End If

                tareas.Add(task)
            End While

            If tareas.Count > 0 Then
                reply.obj = tareas
                reply.ok = True
                reply.msg = "Tareas encontradas"
            Else
                reply.obj = Nothing
                reply.ok = False
                reply.msg = "Tareas no encontrados"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply

        End Try
        dr.Close()
        dr.Dispose()

        Return reply
    End Function


    Public Function GetTaskDAO(ByVal pIdTask As String) As Reply(Of TaskEN)

        Dim reply As New Reply(Of TaskEN)
        Dim dr As MySqlDataReader

        Try

            sentence = "SELECT * FROM task WHERE Id_Task = @filtro1 "

            dr = ConexionDAO.Instancia.ExecuteConsultGetProject(sentence, pIdTask)

            While dr.Read
                Dim task As New TaskEN
                task.Id_Task = dr(0)
                task.Task_Name = dr(1)
                task.Description_Task = dr(2)
                task.Id_Sprint = dr(3)
                task.Id_Status = dr(4)

                reply.obj = task
            End While

            If reply.obj IsNot Nothing Then
                reply.ok = True
                reply.msg = "Tarea encontrada"
            ElseIf reply.obj Is Nothing Then
                reply.ok = False
                reply.msg = "Tarea no encontrada"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try

        dr.Close()
        dr.Dispose()

        Return reply


    End Function


    Public Function PostTaskDAO(ByVal pTaskEn As TaskEN) As Reply(Of TaskEN)

        Dim reply As New Reply(Of TaskEN)

        Try
            If pTaskEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto de la tarea esta Vacio"


            ElseIf pTaskEn IsNot Nothing Then
                sentence = "INSERT INTO task (Task_Name, Description_Task, Id_Sprint, Id_Status) VALUES (@parameter2, @parameter3, @parameter4, @parameter5)"
                ConexionDAO.Instancia.ExecuteInsertTask(sentence, pTaskEn)

                reply.ok = True
                reply.msg = "Se ha creado Correctamente"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try

        Return reply

    End Function

    Public Function PutTaskDAO(ByVal pTaskEn As TaskEN) As Reply(Of TaskEN)

        Dim reply As New Reply(Of TaskEN)

        Try
            If pTaskEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto de la tarea esta Vacio"

            ElseIf pTaskEn IsNot Nothing Then
                sentence = "UPDATE task SET Task_Name = @parameter1, Description_Task = @parameter2 ,Id_Sprint= @parameter3 , Id_Status= @parameter4 WHERE Id_Task = @Condition"

                ConexionDAO.Instancia.ExecuteUpdateTask(sentence, pTaskEn)
                reply.ok = True
                reply.msg = "Se ha modificado correctamente el la tarea"

            End If



        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

    Public Function PutTaskDAOByDisabling(ByVal pTaskEn As String) As Reply(Of TaskEN)

        Dim reply As New Reply(Of TaskEN)
        Try
            If pTaskEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto de la tarea esta Vacio"

            ElseIf pTaskEn IsNot Nothing Then
                sentence = "UPDATE task SET Id_Status = 2 WHERE Id_Task = @Condition"

                ConexionDAO.Instancia.ExecuteUpdateTaskByDisabling(sentence, pTaskEn)
                reply.ok = True
                reply.msg = "Se ha modificado correctamente la tarea"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function


    Public Function DeleteTaskDAO(ByVal pIdProject As String) As Reply(Of TaskEN)

        Dim reply As New Reply(Of TaskEN)

        Try
            If pIdProject Is Nothing Then
                reply.ok = False
                reply.msg = "No se encontro un proyecto relacionado"


            ElseIf pIdProject IsNot Nothing Then
                sentence = "DELETE FROM task WHERE Id_Task = @Condition"

                ConexionDAO.Instancia.ExecuteDeleteTask(sentence, pIdProject)
                reply.ok = True
                reply.msg = "Se ha eliminado correctamente el proyecto"

            End If



        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function


End Class
