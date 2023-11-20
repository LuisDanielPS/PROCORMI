
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


    Public Function GetAllSprintsBLL(idProyect As Integer) As Reply(Of List(Of SprintEN))

        Dim reply As Reply(Of List(Of SprintEN)) = Nothing

        Try

            reply = SprintDAO.Instance.GetSprintsAllDAO(idProyect)

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar los sprints"
        End Try

        Return reply

    End Function

    Public Function GetSprintsAllOperatorBLL(ByVal pUsuLogin As String, ByVal pId_Project As Integer) As Reply(Of List(Of SprintEN))

        Dim reply As Reply(Of List(Of SprintEN)) = Nothing

        Try
            If pUsuLogin IsNot Nothing Then

                reply = SprintDAO.Instance.GetSprintsAllOperatorDAO(pUsuLogin, pId_Project)

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar el sprint"
        End Try

        Return reply

    End Function

    Public Function GetSprintsAllReportUserBLL(ByVal pUsuLogin As String) As Reply(Of List(Of SprintStatusReportVM))

        Dim reply As Reply(Of List(Of SprintStatusReportVM)) = Nothing

        Try
            If pUsuLogin IsNot Nothing Then


                reply = SprintDAO.Instance.GetSprintsAllReportUserDAO(pUsuLogin)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar un proyecto"
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

    Public Function GetUserListSprintBLL(ByVal pIdSprint As Integer) As Reply(Of List(Of UserListSprintVM))


        Dim reply As Reply(Of List(Of UserListSprintVM)) = Nothing

        Try
            If pIdSprint <> 0 Then

                reply = SprintDAO.Instance.GetUserListSprintDAO(pIdSprint)

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar la lista de usuarios en el sprint"
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

    Public Function PutCompleteSprintStatusBLL(ByVal pIdSprint As Integer) As Reply(Of SprintEN)

        Dim reply As Reply(Of SprintEN) = Nothing

        Try
            If pIdSprint <> 0 Then

                reply = SprintDAO.Instance.PutCompleteSprintStatusDAO(pIdSprint)
                reply.ok = True
                reply.msg = "Se ha completado el sprint"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al completar el proyecto"
        End Try

        Return reply

    End Function

    Public Function PutDisableStatusBLL(ByVal pIdSprint As Integer) As Reply(Of SprintEN)

        Dim reply As Reply(Of SprintEN) = Nothing

        Try
            If pIdSprint <> 0 Then

                reply = SprintDAO.Instance.PutDisableStatusDAO(pIdSprint)
                reply.ok = True
                reply.msg = "Se ha eliminado el sprint"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al eliminar proyecto"
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
