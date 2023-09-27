Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class ProjectDAO

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As ProjectDAO
        Return New ProjectDAO
    End Function

    Dim sentence As String = ""

    Public Function GetProjectsAllDAO() As Reply(Of List(Of ProjectEN))

        Dim reply As New Reply(Of List(Of ProjectEN))
        Dim dr As MySqlDataReader
        Dim proyectos As New List(Of ProjectEN)()

        Try

            sentence = "SELECT * FROM project"

            dr = ConexionDAO.Instancia.ExecuteConsultGetAllProjects(sentence)

            While dr.Read
                Dim proyecto As New ProjectEN
                proyecto.Id_project = dr(0)
                proyecto.Project_Name = dr(1)
                proyecto.Description_Project = dr(2)
                proyecto.Id_State = dr(3)
                proyecto.Users = dr(4)
                proyecto.Creation_Date = dr(5)




                proyectos.Add(proyecto)

            End While

            If proyectos.Count > 0 Then
                reply.obj = proyectos
                reply.ok = True
                reply.msg = "Proyectos encontrados"
            Else
                reply.obj = Nothing
                reply.ok = False
                reply.msg = "Proyectos no encontrados"
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


    Public Function GetProjectDAO(ByVal pIdProject As String) As Reply(Of ProjectEN)

        Dim reply As New Reply(Of ProjectEN)
        Dim dr As MySqlDataReader

        Try

            sentence = "SELECT * FROM project WHERE Id_Project = @filtro1 "

            dr = ConexionDAO.Instancia.ExecuteConsultGetProject(sentence, pIdProject)

            While dr.Read
                Dim proyecto As New ProjectEN
                proyecto.Id_project = dr(0)
                proyecto.Project_Name = dr(1)
                proyecto.Description_Project = dr(2)
                proyecto.Id_State = dr(3)
                proyecto.Users = dr(4)
                proyecto.Creation_Date = dr(5)

                reply.obj = proyecto
            End While

            If reply.obj IsNot Nothing Then
                reply.ok = True
                reply.msg = "Proyecto encontrado"
            ElseIf reply.obj Is Nothing Then
                reply.ok = False
                reply.msg = "Proyecto no encontrado"
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




    Public Function PostProjectDAO(ByVal pProjectEn As ProjectEN) As Reply(Of ProjectEN)

        Dim reply As New Reply(Of ProjectEN)

        Try
            If pProjectEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto del projecto esta Vacio"


            ElseIf pProjectEn IsNot Nothing Then
                sentence = "INSERT INTO project (Id_Project, Project_Name, Description_Project, Id_State, Users, Date_Creation) VALUES (@parameter1, @parameter2, @parameter3, @parameter4, @parameter5, @parameter6)"

                ConexionDAO.Instancia.ExecuteInsertProject(sentence, pProjectEn)
                reply.ok = True
                reply.msg = "Se ha creado Correctamente  encontrado"

            End If



        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

    Public Function PutProjectDAO(ByVal pProjectEn As ProjectEN) As Reply(Of ProjectEN)

        Dim reply As New Reply(Of ProjectEN)

        Try
            If pProjectEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto del projecto esta Vacio"


            ElseIf pProjectEn IsNot Nothing Then
                sentence = "UPDATE project SET Project_Name = @parameter1, Description_Project = @parameter2 ,Id_State= @parameter3 , Users= @parameter4 ,Date_Creation = @parameter5 WHERE Id_project = @Condition"

                ConexionDAO.Instancia.ExecuteUpdateProject(sentence, pProjectEn)
                reply.ok = True
                reply.msg = "Se ha modificado correctamente el proyecto"

            End If



        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

    Public Function DeleteProjectDAO(ByVal pIdProject As String) As Reply(Of ProjectEN)

        Dim reply As New Reply(Of ProjectEN)

        Try
            If pIdProject Is Nothing Then
                reply.ok = False
                reply.msg = "No se encontro un proyecto relacionado"


            ElseIf pIdProject IsNot Nothing Then
                sentence = "DELETE FROM project WHERE Id_project = @Condition"

                ConexionDAO.Instancia.ExecuteDeleteProject(sentence, pIdProject)
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
