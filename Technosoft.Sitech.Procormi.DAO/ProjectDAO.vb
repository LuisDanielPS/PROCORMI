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
        Dim proyectos As New List(Of ProjectEN)()

        Try

            sentence = "SELECT * FROM project WHERE Id_Status <> 2"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)

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

            End Using

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply

        End Try

        Return reply

    End Function


    Public Function GetProjectsAllOperatorDAO(ByVal pUsuLogin As String) As Reply(Of List(Of ProjectEN))

        Dim reply As New Reply(Of List(Of ProjectEN))
        Dim proyectos As New List(Of ProjectEN)()

        Try

            sentence = "SELECT p.Id_Project, p.Project_Name, p.Description_Project, p.Id_Status, p.Date_Creation
        FROM project AS p
        JOIN seg_usu_project AS sp ON p.Id_Project = sp.Id_Project
        JOIN seg_usu AS u ON sp.User_Login = u.usu_Login
        WHERE u.usu_Login = @filtro1 AND u.usu_Tipo = 'Operador' AND p.Id_Status<>2"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, pUsuLogin)

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

            End Using

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply

        End Try

        Return reply

    End Function




    Public Function GetProjectDAO(ByVal pIdProject As String) As Reply(Of ProjectEN)

        Dim reply As New Reply(Of ProjectEN)

        Try

            sentence = "SELECT * FROM project WHERE Id_Project = @filtro1 "

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, pIdProject)

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
            End Using
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

    Public Function GetUserListProjectDAO(ByVal pIdProject As Integer) As Reply(Of List(Of UserListProjectVM))

        Dim reply As New Reply(Of List(Of UserListProjectVM))
        Dim UserListProject As New List(Of UserListProjectVM)()
        Try

            sentence = "SELECT p.Id_Project , su.usu_Login , usu_Nombre FROM seg_usu AS su JOIN seg_usu_project AS sup ON su.usu_Login = sup.User_Login JOIN project AS p ON sup.Id_Project = p.Id_Project where p.Id_Project = @filtro1"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterInteger(sentence, pIdProject)

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
            End Using
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply


        End Try


        Return reply


    End Function



    Public Function GetFileListProjectDAO(ByVal pIdProject As Integer) As Reply(Of List(Of FileEN))

        Dim reply As New Reply(Of List(Of FileEN))
        Dim FileListProject As New List(Of FileEN)()
        Try

            sentence = "SELECT f.File_ID, f.File_Name , f.File_Type, f.File_Size, f.Creation_Date FROM project p INNER JOIN project_files pf ON p.Id_Project = pf.Id_Project INNER JOIN files f ON pf.File_ID = f.File_ID WHERE p.Id_Project=@filtro1"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterInteger(sentence, pIdProject)

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
            End Using
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply


        End Try
        Return reply


    End Function

    Public Function GetProjectsReportUserDAO(ByVal pUsuLogin As String) As Reply(Of List(Of ProjectStatusVM))

        Dim reply As New Reply(Of List(Of ProjectStatusVM))
        Dim proyectos As New List(Of ProjectStatusVM)()

        Try

            sentence = "SELECT 
             p.Id_Project, 
             p.Project_Name, 
             p.Description_Project, 
             s.Status_Name, 
             p.Date_Creation 
    FROM 
        project AS p 
    JOIN 
        seg_usu_project AS sp ON p.Id_Project = sp.Id_Project 
    JOIN 
        seg_usu AS u ON sp.User_Login = u.usu_Login 
    JOIN 
        status AS s ON p.Id_Status = s.Id_Status 
    WHERE  u.usu_Login = @filtro1"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, pUsuLogin)

                While dr.Read
                    Dim proyecto As New ProjectStatusVM
                    proyecto.Id_project = dr(0)
                    proyecto.Project_Name = dr(1)
                    proyecto.Description_Project = dr(2)
                    proyecto.Status_Name = dr(3)
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
            End Using
        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply


        End Try
        Return reply
    End Function


    Public Function PostProjectDAO(ByVal pProjectEn As ProjectEN) As Reply(Of ProjectEN)

        Dim reply As New Reply(Of ProjectEN)

        Try
            If pProjectEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto del projecto esta Vacio"


            ElseIf pProjectEn IsNot Nothing Then
                sentence = "INSERT INTO project (Project_Name, Description_Project, Id_Status, Date_Creation) VALUES (@parameter1, @parameter2, @parameter3, NOW())"

                ConexionDAO.Instancia.ExecuteInsertProject(sentence, pProjectEn)
                reply.ok = True
                reply.msg = "Se ha creado Correctamente el proyecto"

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

                NotificationDAO.Instance.NotifyAssignedProject(pAddUserProject.User_Login, pAddUserProject.Id_Project)

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


        Try

            sentence = "SELECT LAST_INSERT_ID()"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)

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
            End Using
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

    Public Function PutDisableStatusDAO(ByVal pIdProject As Integer) As Reply(Of ProjectEN)

        Dim reply As New Reply(Of ProjectEN)

        Try
            If pIdProject = 0 Then
                reply.ok = False
                reply.msg = "El objeto del projecto esta Vacio"


            ElseIf pIdProject <> 0 Then
                sentence = "UPDATE project SET Id_Status = 2  WHERE Id_project = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdProject)
                reply.ok = True
                reply.msg = "Se ha eliminado el proyecto"

            End If



        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

    Public Function PutCompleteStatusDAO(ByVal pIdProject As Integer) As Reply(Of ProjectEN)

        Dim reply As New Reply(Of ProjectEN)

        Try
            If pIdProject = 0 Then
                reply.ok = False
                reply.msg = "El objeto del projecto esta Vacio"


            ElseIf pIdProject <> 0 Then
                sentence = "UPDATE project SET Id_Status = 5  WHERE Id_project = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdProject)
                reply.ok = True
                reply.msg = "Se ha eliminado el proyecto"

                NotificationDAO.Instance.NotifyProjectCompleted(pIdProject)

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
                sentence = "DELETE FROM project WHERE Id_Project = @Condition"

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


    Public Function DeleteProjectFileDAO(ByVal pIdProject As Integer) As Reply(Of ProjectFileEN)

        Dim reply As New Reply(Of ProjectFileEN)

        Try
            If pIdProject = 0 Then
                reply.ok = False
                reply.msg = "No se encontro el archivo relacionado"


            ElseIf pIdProject <> 0 Then
                sentence = "DELETE FROM project_files WHERE Id_Project = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdProject)
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
            If pIdProject = 0 Then
                reply.ok = False
                reply.msg = "No se encontro usuarios relacionados"


            ElseIf pIdProject <> 0 Then
                sentence = "DELETE FROM seg_usu_project WHERE Id_Project = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdProject)
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

    Public Function GetPasswordVerifyDeleteRowDAO(ByVal pUsu As String, ByVal pPass As String) As Reply(Of UsuarioEN)

        Dim reply As New Reply(Of UsuarioEN)




        Try

            sentence = "SELECT usu_Login , usu_Password FROM seg_usu WHERE usu_Login = @filtro1 And usu_Password = @filtro2"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultTwoParameterString(sentence, pUsu, pPass)

                While dr.Read
                    Dim usu As New UsuarioEN
                    usu.usu_Login = dr(0)
                    usu.usu_Password = dr(1)
                    reply.obj = usu
                End While

                If reply.obj IsNot Nothing Then
                    reply.ok = True
                    reply.msg = "Usuario verificado para eliminar"
                ElseIf reply.obj Is Nothing Then
                    reply.ok = False
                    reply.msg = "Usuario o contraseña incorrectos"
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

End Class
