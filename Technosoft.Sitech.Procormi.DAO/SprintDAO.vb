Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class SprintDAO

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As SprintDAO
        Return New SprintDAO
    End Function

    Dim sentence As String = ""

    Public Function GetSprintsAllDAO(idProyect As Integer) As Reply(Of List(Of SprintEN))

        Dim reply As New Reply(Of List(Of SprintEN))

        Dim sprints As New List(Of SprintEN)()

        Try

            sentence = "SELECT * FROM sprint where not Id_Status = 2 and Id_Project = " & idProyect & ";"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsult(sentence)

                While dr.Read
                    Dim sprint As New SprintEN
                    sprint.Id_Sprint = dr(0)
                    sprint.Sprint_Name = dr(1)
                    sprint.Start_Date = dr(2)
                    sprint.End_Date = dr(3)
                    sprint.Id_Project = dr(4)
                    sprint.Id_Status = dr(5)
                    sprint.User_Login = dr(6)

                    sprints.Add(sprint)

                End While

                If sprints.Count > 0 Then
                    reply.obj = sprints
                    reply.ok = True
                    reply.msg = "Sprints encontrados"
                Else
                    reply.obj = Nothing
                    reply.ok = False
                    reply.msg = "Sprints no encontrados"
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

    Public Function GetSprintsAllReportUserDAO(ByVal pUsuLogin As String) As Reply(Of List(Of SprintStatusReportVM))

        Dim reply As New Reply(Of List(Of SprintStatusReportVM))
        Dim sprints As New List(Of SprintStatusReportVM)()

        Try

            sentence = "SELECT
            spr.Id_Sprint,
            spr.Sprint_Name,
            spr.Start_Date,
            spr.End_Date,
            spr.Id_Project,
            spr.User_Login,
            st.Status_Name
        FROM
            sprint spr
        JOIN seg_usu usu ON spr.User_Login = usu.usu_Login
        JOIN status st ON spr.Id_Status = st.Id_Status WHERE spr.User_Login = @filtro1"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, pUsuLogin)

                While dr.Read
                    Dim sprint As New SprintStatusReportVM
                    sprint.Id_Sprint = dr(0)
                    sprint.Sprint_Name = dr(1)
                    sprint.Start_Date = dr(2)
                    sprint.End_Date = dr(3)
                    sprint.Id_Project = dr(4)
                    sprint.User_Login = dr(5)
                    sprint.Status_Name = dr(6)

                    sprints.Add(sprint)

                End While

                If sprints.Count > 0 Then
                    reply.obj = sprints
                    reply.ok = True
                    reply.msg = "Sprints encontrados"
                Else
                    reply.obj = Nothing
                    reply.ok = False
                    reply.msg = "Sprints no encontrados"
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


    Public Function GetSprintDAO(ByVal pIdSprint As String) As Reply(Of SprintEN)

        Dim reply As New Reply(Of SprintEN)


        Try

            sentence = "SELECT * FROM Sprint WHERE Id_Sprint = @filtro1 "

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterString(sentence, pIdSprint)

                While dr.Read
                    Dim sprint As New SprintEN
                    sprint.Id_Sprint = dr(0)
                    sprint.Sprint_Name = dr(1)
                    sprint.Start_Date = dr(2)
                    sprint.End_Date = dr(3)
                    sprint.Id_Project = dr(4)
                    sprint.Id_Status = dr(5)
                    sprint.User_Login = dr(6)

                    reply.obj = sprint
                End While

                If reply.obj IsNot Nothing Then
                    reply.ok = True
                    reply.msg = "Sprint encontrado"
                ElseIf reply.obj Is Nothing Then
                    reply.ok = False
                    reply.msg = "Sprint no encontrado"
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

    Public Function GetUserListSprintDAO(ByVal pIdProject As Integer) As Reply(Of List(Of UserListSprintVM))

        Dim reply As New Reply(Of List(Of UserListSprintVM))
        Dim UserListSprint As New List(Of UserListSprintVM)
        Try

            sentence = "SELECT p.Id_Project, su.usu_Login , usu_Nombre FROM seg_usu AS su 
                        JOIN seg_usu_project AS sup ON su.usu_Login = sup.User_Login 
                        JOIN project AS p ON sup.Id_Project = p.Id_Project 
                        where p.Id_Project = @filtro1"

            Using dr As MySqlDataReader = ConexionDAO.Instancia.ExecuteConsultOneParameterInteger(sentence, pIdProject)

                While dr.Read
                    Dim user As New UserListSprintVM
                    user.Id_Sprint = dr(0)
                    user.usu_Login = dr(1)
                    user.usu_Nombre = dr(2)

                    UserListSprint.Add(user)

                End While

                If UserListSprint.Count > 0 Then
                    reply.obj = UserListSprint
                    reply.ok = True
                    reply.msg = "Sprints encontrados"
                Else
                    reply.obj = Nothing
                    reply.ok = False
                    reply.msg = "Sprints no encontrados"
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

    Public Function PostSprintDAO(ByVal pSprintEn As SprintEN) As Reply(Of SprintEN)

        Dim reply As New Reply(Of SprintEN)
        Dim adlist As List(Of IDataParameter) = Nothing

        Try
            If pSprintEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto del sprint esta vacío"


            ElseIf pSprintEn IsNot Nothing Then
                sentence = "INSERT INTO sprint (Sprint_Name, Start_Date, End_Date, Id_Project, Id_Status, User_Login) VALUES (@parameter1, @parameter2, @parameter3, @parameter4, @parameter5, @parameter6)"

                adlist = New List(Of IDataParameter)
                adlist.Add(New MySqlParameter("@parameter1", pSprintEn.Sprint_Name))
                adlist.Add(New MySqlParameter("@parameter2", pSprintEn.Start_Date))
                adlist.Add(New MySqlParameter("@parameter3", pSprintEn.End_Date))
                adlist.Add(New MySqlParameter("@parameter4", pSprintEn.Id_Project))
                adlist.Add(New MySqlParameter("@parameter5", 1))
                adlist.Add(New MySqlParameter("@parameter6", pSprintEn.User_Login))

                ConexionDAO.Instancia.ExecuteInsertSprint(sentence, adlist)
                reply.ok = True
                reply.msg = "Sprint registrado con éxito"

            End If



        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

    Public Function PutSprintDAO(ByVal pSprintEn As SprintEN) As Reply(Of SprintEN)

        Dim reply As New Reply(Of SprintEN)

        Try
            If pSprintEn Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto del sprint esta Vacio"


            ElseIf pSprintEn IsNot Nothing Then
                sentence = "UPDATE sprint SET Sprint_Name = @parameter1, Start_Date = @parameter2, End_Date = @parameter3, User_Login = @parameter4  WHERE Id_Sprint = @Condition"

                ConexionDAO.Instancia.ExecuteUpdateSprint(sentence, pSprintEn)
                reply.ok = True
                reply.msg = "El Sprint se ha modificado correctamente"

            End If



        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

    Public Function PutCompleteSprintStatusDAO(ByVal pIdSprint As Integer) As Reply(Of SprintEN)

        Dim reply As New Reply(Of SprintEN)

        Try
            If pIdSprint = 0 Then
                reply.ok = False
                reply.msg = "El objeto del sprint esta Vacio"


            ElseIf pIdSprint <> 0 Then
                sentence = "UPDATE sprint SET Id_Status = 5  WHERE Id_Sprint = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdSprint)
                reply.ok = True
                reply.msg = "Se ha eliminado el sprint"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try

        Return reply

    End Function

    Public Function PutDisableStatusDAO(ByVal pIdSprint As Integer) As Reply(Of SprintEN)

        Dim reply As New Reply(Of SprintEN)

        Try
            If pIdSprint = 0 Then
                reply.ok = False
                reply.msg = "El objeto del sprint esta Vacio"


            ElseIf pIdSprint <> 0 Then
                sentence = "UPDATE sprint SET Id_Status = 2  WHERE Id_Sprint = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdSprint)
                reply.ok = True
                reply.msg = "Se ha eliminado el sprint"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try

        Return reply

    End Function
    Public Function DeleteSprintDAO(ByVal pIdSprint As String) As Reply(Of SprintEN)

        Dim reply As New Reply(Of SprintEN)

        Try
            If pIdSprint Is Nothing Then
                reply.ok = False
                reply.msg = "No se encontro un sprint relacionado"


            ElseIf pIdSprint IsNot Nothing Then
                sentence = "UPDATE sprint SET Id_Status = '2' WHERE Id_Sprint = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdSprint)
                reply.ok = True
                reply.msg = "Se ha eliminado correctamente el sprint"

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
