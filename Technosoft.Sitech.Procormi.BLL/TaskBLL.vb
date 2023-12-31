﻿
Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT
Public Class TaskBLL

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As TaskBLL
        Return New TaskBLL
    End Function



    Public Function GetAllTasksBLL(idSprint As Integer) As Reply(Of List(Of TaskEN))



        Dim reply As Reply(Of List(Of TaskEN)) = Nothing

        Try

            reply = TaskDao.Instance.GetTasksAllDAO(idSprint)

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar proyectos"
        End Try

        Return reply

    End Function


    Public Function GetAllTasksBLL(ByVal sprintId As String) As Reply(Of List(Of TaskEN))

        Dim reply As Reply(Of List(Of TaskEN)) = Nothing

        Try

            reply = TaskDao.Instance.GetTasksAllDAO(sprintId)

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar proyectos"
        End Try

        Return reply

    End Function

    Public Function GetTaskSubTasksBLL(ByVal pIdTask As Integer) As Reply(Of TaskEN)

        Dim reply As Reply(Of TaskEN) = Nothing

        Try
            If pIdTask <> 0 Then

                reply = TaskDao.Instance.GetTaskSubTasksDAO(pIdTask)

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "GetTaskSubTasksBLL: Error al tratar de realizar la búsqueda"
        End Try

        Return reply

    End Function

    Public Function GetTaskAllReportUserBLL(ByVal pUsuLogin As String) As Reply(Of List(Of SpringTaskStatusReportVM))

        Dim reply As Reply(Of List(Of SpringTaskStatusReportVM)) = Nothing

        Try
            If pUsuLogin IsNot Nothing Then


                reply = TaskDao.Instance.GetTaskReportUserDAO(pUsuLogin)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar un proyecto"
        End Try

        Return reply

    End Function


    Public Function GetTaskBLL(ByVal pIdTask As String) As Reply(Of TaskEN)


        Dim reply As Reply(Of TaskEN) = Nothing

        Try
            If pIdTask IsNot Nothing Then


                reply = TaskDao.Instance.GetTaskDAO(pIdTask)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar un proyecto"
        End Try

        Return reply

    End Function


    Public Function PostTaskBLL(ByVal pTask As TaskEN) As Reply(Of TaskEN)
        Dim reply As Reply(Of TaskEN) = Nothing

        Try
            If pTask IsNot Nothing Then
                reply = TaskDao.Instance.PostTaskDAO(pTask)
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al crear proyecto"
        End Try

        Return reply

    End Function


    Public Function PutTaskBLL(ByVal pTask As TaskEN) As Reply(Of TaskEN)


        Dim reply As Reply(Of TaskEN) = Nothing

        Try
            If pTask IsNot Nothing Then
                Return TaskDao.Instance.PutTaskDAO(pTask)
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al modificar tarea"
        End Try

        Return reply

    End Function

    Public Function PutTaskBLLAsFinished(ByVal pTaskId As String) As Reply(Of TaskEN)


        Dim reply As Reply(Of TaskEN) = Nothing

        Try
            If pTaskId IsNot Nothing Then
                Return TaskDao.Instance.PutTaskDAOAsFinished(pTaskId)
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al finalizar la tarea"
        End Try

        Return reply

    End Function

    Public Function PutTaskBLLByDisabling(ByVal pTaskId As String) As Reply(Of TaskEN)


        Dim reply As Reply(Of TaskEN) = Nothing

        Try
            If pTaskId IsNot Nothing Then
                Return TaskDao.Instance.PutTaskDAOByDisabling(pTaskId)
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al desactivar tarea"
        End Try

        Return reply

    End Function


    Public Function DeleteTaskBLL(ByVal pIdTask As String) As Reply(Of TaskEN)

        Dim reply As Reply(Of TaskEN) = Nothing

        Try
            If pIdTask IsNot Nothing Then

                reply = TaskDao.Instance.DeleteTaskDAO(pIdTask)
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de eliminar tarea"
        End Try

        Return reply

    End Function


End Class
