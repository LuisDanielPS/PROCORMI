﻿
Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT
Public Class SprintBLL

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As SprintBLL
        Return New SprintBLL
    End Function


    Public Function GetAllSprintsBLL() As Reply(Of List(Of SprintEN))

        Dim reply As Reply(Of List(Of SprintEN)) = Nothing

        Try

            reply = SprintDAO.Instance.GetSprintsAllDAO()

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar los sprints"
        End Try

        Return reply

    End Function

    Public Function GetSprintBLL(ByVal pIdSprint As String) As Reply(Of SprintEN)


        Dim reply As Reply(Of SprintEN) = Nothing

        Try
            If pIdSprint IsNot Nothing Then

                reply = SprintDAO.Instance.GetSprintDAO(pIdSprint)

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar un sprint"
        End Try

        Return reply

    End Function

    Public Function PostSprintBLL(ByVal pSprint As SprintEN) As Reply(Of SprintEN)


        Dim reply As Reply(Of SprintEN) = Nothing

        Try
            If pSprint IsNot Nothing Then

                reply = SprintDAO.Instance.PostSprintDAO(pSprint)
                reply.ok = True
                reply.msg = "Se creo el sprint correctamente"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al crear sprint"
        End Try

        Return reply

    End Function


    Public Function PutSprintBLL(ByVal pSprint As SprintEN) As Reply(Of SprintEN)


        Dim reply As Reply(Of SprintEN) = Nothing

        Try
            If pSprint IsNot Nothing Then

                reply = SprintDAO.Instance.PutSprintDAO(pSprint)
                reply.ok = True
                reply.msg = "Se ha modificado correctamente el sprint"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al modificar sprint"
        End Try

        Return reply

    End Function


    Public Function DeleteSprintBLL(ByVal pIdSprint As String) As Reply(Of SprintEN)

        Dim reply As Reply(Of SprintEN) = Nothing

        Try
            If pIdSprint IsNot Nothing Then

                reply = SprintDAO.Instance.DeleteSprintDAO(pIdSprint)

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de eliminar sprint"
        End Try

        Return reply

    End Function

End Class