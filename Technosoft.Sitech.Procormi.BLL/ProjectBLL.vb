
Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT
Public Class ProjectBLL

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As ProjectBLL
        Return New ProjectBLL
    End Function



    Public Function GetAllProjectsBLL() As Reply(Of List(Of ProjectEN))



        Dim reply As Reply(Of List(Of ProjectEN)) = Nothing

        Try

            reply = ProjectDAO.Instance.GetProjectsAllDAO()

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar proyectos"
        End Try

        Return reply

    End Function


    Public Function GetProjectBLL(ByVal pIdProject As String) As Reply(Of ProjectEN)


        Dim reply As Reply(Of ProjectEN) = Nothing

        Try
            If pIdProject IsNot Nothing Then


                reply = ProjectDAO.Instance.GetProjectDAO(pIdProject)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar un proyecto"
        End Try

        Return reply

    End Function


    Public Function PostProjectBLL(ByVal pProject As ProjectEN) As Reply(Of ProjectEN)


        Dim reply As Reply(Of ProjectEN) = Nothing

        Try
            If pProject IsNot Nothing Then

                reply = ProjectDAO.Instance.PostProjectDAO(pProject)
                reply.ok = True
                reply.msg = "Se creo el proyecto correctamente"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al crear proyecto"
        End Try

        Return reply

    End Function


    Public Function PutProjectBLL(ByVal pProject As ProjectEN) As Reply(Of ProjectEN)


        Dim reply As Reply(Of ProjectEN) = Nothing

        Try
            If pProject IsNot Nothing Then

                reply = ProjectDAO.Instance.PutProjectDAO(pProject)
                reply.ok = True
                reply.msg = "Se ha modificado correctamente el proyecto"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al modificar proyecto"
        End Try

        Return reply

    End Function


    Public Function DeleteProjectBLL(ByVal pIdProject As String) As Reply(Of ProjectEN)


        Dim reply As Reply(Of ProjectEN) = Nothing

        Try
            If pIdProject IsNot Nothing Then


                reply = ProjectDAO.Instance.DeleteProjectDAO(pIdProject)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de eliminar proyecto"
        End Try

        Return reply

    End Function


End Class
