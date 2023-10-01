﻿Imports System.Reflection
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
                proyecto.Creation_Date = dr(4)




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
                proyecto.Creation_Date = dr(4)

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

    Public Function GetUserListProjectDAO(ByVal pIdProject As Integer) As Reply(Of List(Of UserListProjectVM))

        Dim reply As New Reply(Of List(Of UserListProjectVM))
        Dim dr As MySqlDataReader
        Dim UserListProject As New List(Of UserListProjectVM)()
        Try

            sentence = "SELECT p.Id_Project , su.usu_Login , usu_Nombre FROM seg_usu AS su JOIN seg_usu_project AS sup ON su.usu_Login = sup.User_Login JOIN project AS p ON sup.Id_Project = p.Id_Project where p.Id_Project = @filtro1"

            dr = ConexionDAO.Instancia.ExecuteConsultJoinSegUsuProject(sentence, pIdProject)

            While dr.Read
                Dim user As New UserListProjectVM
                user.Id_project = dr(0)
                user.Usu_Login = dr(1)
                user.Usu_Nombre = dr(2)

                UserListProject.Add(user)

            End While

            If UserListProject.Count > 0 Then
                reply.obj = UserListProject
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


    Public Function GetFileListProjectDAO(ByVal pIdProject As Integer) As Reply(Of List(Of FileEN))

        Dim reply As New Reply(Of List(Of FileEN))
        Dim dr As MySqlDataReader
        Dim FileListProject As New List(Of FileEN)()
        Try

            sentence = "SELECT f.File_ID, f.File_Name , f.File_Type, f.File_Size, f.Creation_Date FROM project p INNER JOIN project_files pf ON p.Id_Project = pf.Id_Project INNER JOIN files f ON pf.File_ID = f.File_ID WHERE p.Id_Project=@filtro1"

            dr = ConexionDAO.Instancia.ExecuteConsultJoinFileProject(sentence, pIdProject)

            While dr.Read
                Dim file As New FileEN
                file.File_ID = dr(0)
                file.File_Name = dr(1)
                file.File_Type = dr(2)
                file.File_Size = dr(3)
                file.Creation_Date = dr(4)

                FileListProject.Add(file)

            End While

            If FileListProject.Count > 0 Then
                reply.obj = FileListProject
                reply.ok = True
                reply.msg = "Archivos encontrados"
            Else
                reply.obj = Nothing
                reply.ok = False
                reply.msg = "Archivos no encontrados"
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
                sentence = "INSERT INTO project (Project_Name, Description_Project, Id_State, Date_Creation) VALUES (@parameter1, @parameter2, @parameter3, NOW())"

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

    Public Function PostAddUserProjectDAO(ByVal pAddUserProject As SegUsuProjectEN) As Reply(Of SegUsuProjectEN)

        Dim reply As New Reply(Of SegUsuProjectEN)

        Try
            If pAddUserProject Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto del projecto esta Vacio"


            ElseIf pAddUserProject IsNot Nothing Then
                sentence = "INSERT INTO seg_usu_project (User_Login, Id_Project) VALUES (@parameter1, @parameter2)"

                ConexionDAO.Instancia.ExecuteInsertSegUsuProject(sentence, pAddUserProject)
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


    Public Function PostAddFileProjectDAO(ByVal pAddFileProject As ProjectFileEN) As Reply(Of ProjectFileEN)

        Dim reply As New Reply(Of ProjectFileEN)

        Try
            If pAddFileProject Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto del projecto esta Vacio"


            ElseIf pAddFileProject IsNot Nothing Then
                sentence = "INSERT INTO project_files (Id_Project, File_ID) VALUES (@parameter1, @parameter2)"

                ConexionDAO.Instancia.ExecuteInsertProjectFile(sentence, pAddFileProject)
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




    'El metodo permite buscar el Ultimo ID que inserto el usuario de cualquier tabla con autoincremental'
    Public Function GetLastInsertIdDAO() As Reply(Of Integer)

        Dim reply As New Reply(Of Integer)
        Dim dr As MySqlDataReader

        Try

            sentence = "SELECT LAST_INSERT_ID()"

            dr = ConexionDAO.Instancia.ExecuteConsultLastInsertId(sentence)

            While dr.Read
                Dim Last_Id_Insert As Integer
                Last_Id_Insert = dr(0)


                reply.obj = Last_Id_Insert
            End While

            If reply.obj <> 0 Then
                reply.ok = True
                reply.msg = "Se encontro el ultimo id insertado"
            ElseIf reply.obj = 0 Then
                reply.ok = False
                reply.msg = "No se encontro el ultimo id insertado"
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




    Public Function PutProjectDAO(ByVal pProjectEn As ProjectEN) As Reply(Of ProjectEN)

        Dim reply As New Reply(Of ProjectEN)

        Try
            If pProjectEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto del projecto esta Vacio"


            ElseIf pProjectEn IsNot Nothing Then
                sentence = "UPDATE project SET Project_Name = @parameter1, Description_Project = @parameter2  WHERE Id_project = @Condition"

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


    Public Function DeleteProjectFileDAO(ByVal pIdProject As Integer) As Reply(Of ProjectFileEN)

        Dim reply As New Reply(Of ProjectFileEN)

        Try
            If pIdProject = 0 Then
                reply.ok = False
                reply.msg = "No se encontro el archivo relacionado"


            ElseIf pIdProject <> 0 Then
                sentence = "DELETE FROM project_files WHERE Id_Project = @Condition"

                ConexionDAO.Instancia.ExecuteDeleteListUserFileProject(sentence, pIdProject)
                reply.ok = True
                reply.msg = "Se ha eliminado  la lista de archivo del proyecto"

            End If



        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function
    Public Function DeleteSegUsuDAO(ByVal pIdProject As Integer) As Reply(Of SegUsuProjectEN)

        Dim reply As New Reply(Of SegUsuProjectEN)

        Try
            If pIdProject <> 0 Then
                reply.ok = False
                reply.msg = "No se encontro usuarios relacionados"


            ElseIf pIdProject = 0 Then
                sentence = "DELETE FROM seg_usu_project WHERE Id_Project = @Condition"

                ConexionDAO.Instancia.ExecuteDeleteListUserFileProject(sentence, pIdProject)
                reply.ok = True
                reply.msg = "Se ha eliminado la lista de usuarios relacionados con el proyecto"

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
