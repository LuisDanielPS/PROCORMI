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
        Dim tareas As New List(Of TaskEN)()

        Try

            sentence = "SELECT * FROM task where not Id_Status = 2 and Id_Sprint = " & idSprint & ";"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)

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
            End Using
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply

        End Try


        Return reply
    End Function

    Public Function GetTasksAllDAO(ByVal sprintId As String) As Reply(Of List(Of TaskEN))

        Dim reply As New Reply(Of List(Of TaskEN))
        Dim tareas As New List(Of TaskEN)()

        Try

            sentence = "SELECT * FROM task where not Id_Status = 2 and Id_Sprint=@filtro1"
            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, sprintId)

                While dr.Read
                    Dim task As New TaskEN
                    task.Id_Task = dr(0)
                    task.Task_Name = dr(1)
                    task.Description_Task = dr(2)
                    task.Id_Sprint = dr(3)
                    task.Id_Status = dr(4)

                    ' Get state name instead of id
                    Using dr1 = ConexionDAO.Instancia.ExecuteStateById(task.Id_Status)
                        If (dr1.Read) Then
                            task.Id_Status = dr1(0)
                        End If
                    End Using
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
            End Using
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply

        End Try

        Return reply
    End Function


    Public Function GetTaskReportUserDAO(ByVal pUsuLogin As String) As Reply(Of List(Of SpringTaskStatusReportVM))

        Dim reply As New Reply(Of List(Of SpringTaskStatusReportVM))
        Dim tasks As New List(Of SpringTaskStatusReportVM)()

        Try

            sentence = "SELECT 
                         spr.Id_Sprint,
                         spr.Sprint_Name,
                         spr.Id_Project,
                         t.Id_Task,
                         t.Task_Name,
                         t.Description_Task,
                         s.Status_Name
                        FROM 
                sprint spr 
            JOIN 
            task t ON spr.Id_Sprint = t.Id_Sprint 
            JOIN 
            status s ON t.Id_Status = s.Id_Status
            JOIN 
            seg_usu u ON u.usu_Login = spr.User_Login where u.usu_Login = @filtro1"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, pUsuLogin)

                While dr.Read
                    Dim task As New SpringTaskStatusReportVM
                    task.Id_Sprint = dr(0)
                    task.Sprint_Name = dr(1)
                    task.Id_Project = dr(2)
                    task.Id_Task = dr(3)
                    task.Task_Name = dr(4)
                    task.Description_Task = dr(5)
                    task.Status_Name = dr(6)

                    tasks.Add(task)
                End While

                If tasks.Count > 0 Then
                    reply.obj = tasks
                    reply.ok = True
                    reply.msg = "La tarea encontrados"
                Else
                    reply.obj = Nothing
                    reply.ok = False
                    reply.msg = "La tarea no encontrados"
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

    Public Function GetTaskDAO(ByVal pIdTask As String) As Reply(Of TaskEN)

        Dim reply As New Reply(Of TaskEN)

        Try

            sentence = "SELECT * FROM task WHERE Id_Task = @filtro1 "

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, pIdTask)

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
            End Using
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


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
                sentence = "UPDATE task SET Id_Status = (SELECT s.Id_Status FROM status s where s.Status_Name = 'Inactivo') WHERE Id_Task = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pTaskEn)
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

    Public Function PutTaskDAOAsFinished(ByVal pTaskEn As String) As Reply(Of TaskEN)

        Dim reply As New Reply(Of TaskEN)
        Try
            If pTaskEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto de la tarea esta Vacio"

            ElseIf pTaskEn IsNot Nothing Then
                sentence = "UPDATE task SET Id_Status = (SELECT s.Id_Status FROM status s where s.Status_Name = 'Finalizada') WHERE Id_Task = @Condition"
                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pTaskEn)
                reply.ok = True
                reply.msg = "Se ha modificado finalizado la tarea"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Finalizado tarea: No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try

        Return reply
    End Function



    Public Function GetTaskSubTasksDAO(ByVal pIdTask As Integer) As Reply(Of TaskEN)

        Dim reply As New Reply(Of TaskEN)

        Try

            sentence = "SELECT Id_Sub_Task
                        FROM sub_task
                        WHERE Id_Task = @filtro1 AND Id_Status IN ('3', '4', '1')"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, pIdTask)

                While dr.Read
                    Dim task As New TaskEN
                    task.Id_Task = dr(0)
                    reply.obj = task

                End While

                If reply.obj IsNot Nothing Then
                    reply.ok = False
                    reply.msg = "Se puede completar la tarea"
                ElseIf reply.obj Is Nothing Then
                    reply.ok = True
                    reply.msg = "Subtareas Activas"
                End If

            End Using

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "GetTaskSubTasksDAO: No fue posible ejecutar la consulta: " & ex.Message
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

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdProject)
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
