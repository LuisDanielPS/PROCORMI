Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class SubTaskDao

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As SubTaskDao
        Return New SubTaskDao
    End Function

    Dim sentence As String = ""

    Public Function GetSubTasksAllDAO(ByVal taskId As String) As Reply(Of List(Of SubTaskEN))

        Dim reply As New Reply(Of List(Of SubTaskEN))
        Dim dr As MySqlDataReader
        Dim dr1 As MySqlDataReader
        Dim subTareas As New List(Of SubTaskEN)()

        Try
            sentence = "SELECT * FROM sub_task where Id_Task=@filtro1 and not Id_Status = 2"
            dr = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, taskId)

            While dr.Read
                Dim subTask As New SubTaskEN
                subTask.Id_Sub_Task = dr(0)
                subTask.Title = dr(1)
                subTask.Description = dr(2)
                subTask.Required_Time = dr(3)
                subTask.Id_Task = dr(4)
                subTask.Id_Status = dr(5)

                dr1 = ConexionDAO.Instancia.ExecuteStateById(subTask.Id_Status)
                If (dr1.Read) Then
                    subTask.Id_Status = dr1(0)
                End If

                subTask.Id_Priority = dr(6)
                dr1 = ConexionDAO.Instancia.ExecutePriorityById(subTask.Id_Priority)
                If (dr1.Read) Then
                    subTask.Id_Priority = dr1(0)
                End If

                subTareas.Add(subTask)
            End While

            If subTareas.Count > 0 Then
                reply.obj = subTareas
                reply.ok = True
                reply.msg = "SubTareas encontradas"
            Else
                reply.obj = Nothing
                reply.ok = False
                reply.msg = "SubTareas no encontrados"
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


    Public Function GetSubTaskReportUserDAO(ByVal pUsuLogin As String) As Reply(Of List(Of SubTaskReportVM))

        Dim reply As New Reply(Of List(Of SubTaskReportVM))
        Dim dr As MySqlDataReader
        Dim subtasks As New List(Of SubTaskReportVM)()

        Try

            sentence = "SELECT
            st.Id_Sub_Task,
	        st.Title,
            st.Description,
            t.Id_Task,
            t.Task_Name,
            t.Description_Task,
            s.Id_Project,
            s.Sprint_Name,
            p.Priority_Name,
            st1.Status_Name
        FROM
	    sub_task AS st
        JOIN task AS t ON st.Id_Task = t.Id_Task
        JOIN sprint AS s ON t.Id_Sprint = s.Id_Sprint
        JOIN priority AS p ON st.Id_Priority = p.Id_Priority
        JOIN status AS st1 ON st.Id_Status = st1.Id_Status   where s.User_Login=@filtro1"

            dr = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, pUsuLogin)

            While dr.Read
                Dim subtask As New SubTaskReportVM
                subtask.Id_Sub_Task = dr(0)
                subtask.Title = dr(1)
                subtask.Description = dr(2)
                subtask.Id_Task = dr(3)
                subtask.Task_Name = dr(4)
                subtask.Description_Task = dr(5)
                subtask.Id_Project = dr(6)
                subtask.Sprint_Name = dr(7)
                subtask.Priority_Name = dr(8)
                subtask.Status_Name = dr(9)

                subtasks.Add(subtask)
            End While

            If subtasks.Count > 0 Then
                reply.obj = subtasks
                reply.ok = True
                reply.msg = "La tarea encontrados"
            Else
                reply.obj = Nothing
                reply.ok = False
                reply.msg = "La tarea no encontrados"
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

    Public Function GetAllPriorityInfo() As Reply(Of List(Of String))

        Dim reply As New Reply(Of List(Of String))
        Dim dr As MySqlDataReader
        Dim priorities As New List(Of String)()

        Try
            sentence = "SELECT Priority_Name FROM priority"
            dr = ConexionDAO.Instancia.ExecuteConsult(sentence)

            While dr.Read
                Dim priorityName As String = dr(0)
                priorities.Add(priorityName)
            End While

            If priorities.Count > 0 Then
                reply.obj = priorities
                reply.ok = True
                reply.msg = "Prioridades encontradas"
            Else
                reply.obj = Nothing
                reply.ok = False
                reply.msg = "Prioridades no encontrados"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Prioridades: No fue posible ejecutar la consulta: " & ex.Message
            Return reply

        End Try
        dr.Close()
        dr.Dispose()

        Return reply
    End Function

    Public Function GetAllStatusInfo() As Reply(Of List(Of String))

        Dim reply As New Reply(Of List(Of String))
        Dim dr As MySqlDataReader
        Dim priorities As New List(Of String)()

        Try
            sentence = "SELECT Status_Name FROM status"
            dr = ConexionDAO.Instancia.ExecuteConsult(sentence)

            While dr.Read
                Dim priorityName As String = dr(0)
                priorities.Add(priorityName)
            End While

            If priorities.Count > 0 Then
                reply.obj = priorities
                reply.ok = True
                reply.msg = "Status encontradas"
            Else
                reply.obj = Nothing
                reply.ok = False
                reply.msg = "Status no encontrados"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Status: No fue posible ejecutar la consulta: " & ex.Message
            Return reply

        End Try
        dr.Close()
        dr.Dispose()

        Return reply
    End Function

    Public Function PostSubTaskDAO(ByVal pSubTaskEn As SubTaskEN) As Reply(Of SubTaskEN)

        Dim reply As New Reply(Of SubTaskEN)

        Try
            If pSubTaskEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto de la subtarea esta Vacio"


            ElseIf pSubTaskEn IsNot Nothing Then
                sentence = "
                    INSERT INTO sub_task (Title,Description,Required_Time,Id_Task,Id_Status,Id_Priority)
                    VALUES (@parameter1, @parameter2, @parameter3, @parameter4, @parameter5,@parameter6)
                "
                ConexionDAO.Instancia.ExecuteInsertSubTask(sentence, pSubTaskEn)
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

    Public Function PutSubTaskDAO(ByVal pSubTaskEn As SubTaskEN) As Reply(Of SubTaskEN)

        Dim reply As New Reply(Of SubTaskEN)

        Try
            If pSubTaskEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto de la subtarea esta Vacio"

            ElseIf pSubTaskEn IsNot Nothing Then
                sentence = "UPDATE sub_task 
                        SET Title = @parameter1, 
                            Description = @parameter2,
                            Required_Time= @parameter3 , 
                            Id_Task= @parameter4,
                            Id_Status = @parameter5,
                            Id_Priority = @parameter6 
                        WHERE Id_Sub_Task = @Condition"

                ConexionDAO.Instancia.ExecuteUpdateSubTask(sentence, pSubTaskEn)
                reply.ok = True
                reply.msg = "Se ha modificado correctamente la subtarea"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

    Public Function PutSubTaskDAOByDisabling(ByVal pSubTaskEnId As String) As Reply(Of SubTaskEN)

        Dim reply As New Reply(Of SubTaskEN)
        Try
            If pSubTaskEnId Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto de la subtarea esta Vacio"

            ElseIf pSubTaskEnId IsNot Nothing Then
                sentence = "UPDATE sub_task SET Id_Status = 2 WHERE Id_Sub_Task = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pSubTaskEnId)
                reply.ok = True
                reply.msg = "Se ha modificado correctamente la subtarea"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

    Public Function PutSubTaskDAOAsFinished(ByVal pSubTaskEnId As String) As Reply(Of SubTaskEN)

        Dim reply As New Reply(Of SubTaskEN)
        Try
            If pSubTaskEnId Is Nothing Then
                reply.ok = False
                reply.msg = "El id de subtarea no es valido"

            ElseIf pSubTaskEnId IsNot Nothing Then
                sentence = "UPDATE sub_task SET Id_Status = (SELECT s.Id_Status FROM status s where s.Status_Name = 'Finalizada') WHERE Id_Sub_Task = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pSubTaskEnId)
                reply.ok = True
                reply.msg = "Se ha finalizado correctamente la subtarea"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible finalizadr la tarea: " & ex.Message
            Return reply
        End Try

        Return reply

    End Function




End Class
