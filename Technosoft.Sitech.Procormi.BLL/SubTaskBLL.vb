
Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT
Public Class SubTaskBLL

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As SubTaskBLL
        Return New SubTaskBLL
    End Function

    Public Function GetAllSubTasksBLL(ByVal taskId As String) As Reply(Of List(Of SubTaskEN))

        Dim reply As Reply(Of List(Of SubTaskEN)) = Nothing

        Try
            reply = SubTaskDao.Instance.GetSubTasksAllDAO(taskId)
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar subtareas"
        End Try

        Return reply

    End Function

    Public Function GetAllStatus() As Reply(Of List(Of String))

        Dim reply As Reply(Of List(Of String)) = Nothing

        Try
            reply = SubTaskDao.Instance.GetAllStatusInfo()
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar estados"
        End Try

        Return reply

    End Function

    Public Function GetAllPriorities() As Reply(Of List(Of String))

        Dim reply As Reply(Of List(Of String)) = Nothing

        Try
            reply = SubTaskDao.Instance.GetAllPriorityInfo()
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar prioridades"
        End Try

        Return reply

    End Function

    Public Function GetSubTaskAllReportUserBLL(ByVal pUsuLogin As String) As Reply(Of List(Of SubTaskReportVM))

        Dim reply As Reply(Of List(Of SubTaskReportVM)) = Nothing

        Try
            If pUsuLogin IsNot Nothing Then


                reply = SubTaskDao.Instance.GetSubTaskReportUserDAO(pUsuLogin)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar un proyecto"
        End Try

        Return reply

    End Function

    Public Function PostSubTaskBLL(ByVal pSubTask As SubTaskEN) As Reply(Of SubTaskEN)
        Dim reply As Reply(Of SubTaskEN) = Nothing

        Try
            If pSubTask IsNot Nothing Then
                reply = SubTaskDao.Instance.PostSubTaskDAO(pSubTask)
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al crear subtarea"
        End Try

        Return reply

    End Function


    Public Function PutSubTaskBLL(ByVal pSubTask As SubTaskEN) As Reply(Of SubTaskEN)


        Dim reply As Reply(Of SubTaskEN) = Nothing

        Try
            If pSubTask IsNot Nothing Then
                Return SubTaskDao.Instance.PutSubTaskDAO(pSubTask)
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al modificar subtarea"
        End Try

        Return reply

    End Function

    Public Function PutSubTaskBLLByDisabling(ByVal pSubTaskId As String) As Reply(Of SubTaskEN)

        Dim reply As Reply(Of SubTaskEN) = Nothing

        Try
            If pSubTaskId IsNot Nothing Then
                Return SubTaskDao.Instance.PutSubTaskDAOByDisabling(pSubTaskId)
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al desactivar subtarea"
        End Try

        Return reply

    End Function

    Public Function PutSubTaskBLLAsFinished(ByVal pSubTaskId As String) As Reply(Of SubTaskEN)

        Dim reply As Reply(Of SubTaskEN) = Nothing

        Try
            If pSubTaskId IsNot Nothing Then
                Return SubTaskDao.Instance.PutSubTaskDAOAsFinished(pSubTaskId)
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al desactivar subtarea"
        End Try

        Return reply

    End Function




End Class
