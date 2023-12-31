﻿Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class FileDAO

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As FileDAO

        Return New FileDAO
    End Function

    Dim sentence As String = ""

    Public Function PostFileDAO(ByVal pFileDAO As FileEN) As Reply(Of FileEN)

        Dim reply As New Reply(Of FileEN)

        Try
            If pFileDAO Is Nothing Then
                reply.ok = False
                reply.msg = "El objeto del projecto esta Vacio"


            ElseIf pFileDAO IsNot Nothing Then
                sentence = "INSERT INTO files (File_Name, File_Type, File_Size, Creation_Date) VALUES (@parameter1, @parameter2, @parameter3, NOW());"

                ConexionDAO.Instancia.ExecuteInsertFile(sentence, pFileDAO)
                reply.ok = True
                reply.msg = "Se ha creado Correctamente  el file"

            End If



        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply



    End Function

    Public Function DeleteProjectFileDAO(ByVal pIdFile As Integer) As Reply(Of ProjectFileEN)

        Dim reply As New Reply(Of ProjectFileEN)

        Try
            If pIdFile = 0 Then
                reply.ok = False
                reply.msg = "No se encontro el archivo relacionado"


            ElseIf pIdFile <> 0 Then
                sentence = "DELETE FROM project_files WHERE File_ID = @Condition ; DELETE FROM Files WHERE File_ID = @Condition"

                ConexionDAO.Instancia.ExecuteConsultCondition(sentence, pIdFile)
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







End Class
