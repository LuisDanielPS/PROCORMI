
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

    Public Function GetProjectsAllOperatorBLL(ByVal pUsuLogin As String) As Reply(Of List(Of ProjectEN))

        Dim reply As Reply(Of List(Of ProjectEN)) = Nothing

        Try
            If pUsuLogin IsNot Nothing Then


                reply = ProjectDAO.Instance.GetProjectsAllOperatorDAO(pUsuLogin)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar un proyecto"
        End Try

        Return reply

    End Function

    Public Function GetProjectsReportUserBLL(ByVal pUsuLogin As String) As Reply(Of List(Of ProjectStatusVM))

        Dim reply As Reply(Of List(Of ProjectStatusVM)) = Nothing

        Try
            If pUsuLogin IsNot Nothing Then

                reply = ProjectDAO.Instance.GetProjectsReportUserDAO(pUsuLogin)

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar un proyecto"
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


    Public Function GetUserListProjectBLL(ByVal pIdProject As Integer) As Reply(Of List(Of UserListProjectVM))


        Dim reply As Reply(Of List(Of UserListProjectVM)) = Nothing

        Try
            If pIdProject <> 0 Then


                reply = ProjectDAO.Instance.GetUserListProjectDAO(pIdProject)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar la lista de usuarios en el proyecto"
        End Try

        Return reply

    End Function

    Public Function GetFileListProjectBLL(ByVal pIdProject As Integer) As Reply(Of List(Of FileEN))


        Dim reply As Reply(Of List(Of FileEN)) = Nothing

        Try
            If pIdProject <> 0 Then


                reply = ProjectDAO.Instance.GetFileListProjectDAO(pIdProject)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de buscar la lista de archivo en el proyecto"
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

    Public Function PostAddUserProjectBLL(ByVal pAddUserProject As SegUsuProjectEN) As Reply(Of SegUsuProjectEN)


        Dim reply As Reply(Of SegUsuProjectEN) = Nothing

        Try
            If pAddUserProject IsNot Nothing Then

                reply = ProjectDAO.Instance.PostAddUserProjectDAO(pAddUserProject)
                reply.ok = True
                reply.msg = "Se agrego el usuario ala lista del proyecto "
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al  agregar el usuario a la lista del proyecto "
        End Try

        Return reply

    End Function

    Public Function PostAddFileProjectBLL(ByVal pAddFileProject As ProjectFileEN) As Reply(Of ProjectFileEN)


        Dim reply As Reply(Of ProjectFileEN) = Nothing

        Try
            If pAddFileProject IsNot Nothing Then

                reply = ProjectDAO.Instance.PostAddFileProjectDAO(pAddFileProject)
                reply.ok = True
                reply.msg = "Se agrego un archivo ala lista del proyecto "
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al  agregar un archivo a la lista del proyecto "
        End Try

        Return reply

    End Function

    Public Function GetLastInsertIdBLL(ByVal NombreTabla As String) As Reply(Of Integer)


        Dim reply As Reply(Of Integer) = Nothing

        Try

            reply = ProjectDAO.Instance.GetLastInsertIdDAO(NombreTabla)

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar el ultimo id insertado"
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

    Public Function PutDisableStatusBLL(ByVal pIdProject As Integer) As Reply(Of ProjectEN)


        Dim reply As Reply(Of ProjectEN) = Nothing

        Try
            If pIdProject <> 0 Then

                reply = ProjectDAO.Instance.PutDisableStatusDAO(pIdProject)
                reply.ok = True
                reply.msg = "Se ha eliminado el proyecto"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al eliminar proyecto"
        End Try

        Return reply

    End Function

    Public Function PutCompleteStatusBLL(ByVal pIdProject As Integer) As Reply(Of ProjectEN)


        Dim reply As Reply(Of ProjectEN) = Nothing

        Try
            If pIdProject <> 0 Then

                reply = ProjectDAO.Instance.PutCompleteStatusDAO(pIdProject)
                reply.ok = True
                reply.msg = "Se ha completado el proyecto"

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al eliminar proyecto"
        End Try

        Return reply

    End Function



    Public Function GetPasswordVerifyDeleteRowBLL(ByVal pUsuario As String, ByVal pPass As String) As Reply(Of UsuarioEN)

        Dim Usuario As String = ""
        Dim Password As String = ""
        Dim reply As Reply(Of UsuarioEN) = Nothing

        Try
            If pUsuario IsNot Nothing And pPass IsNot Nothing Then
                Usuario = pUsuario
                Password = pPass

                reply = ProjectDAO.Instance.GetPasswordVerifyDeleteRowDAO(Usuario, Password)

            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de eliminar"
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

    Public Function DeleteProjectFileBLL(ByVal pIdProject As Integer) As Reply(Of ProjectFileEN)


        Dim reply As Reply(Of ProjectFileEN) = Nothing

        Try
            If pIdProject <> 0 Then


                reply = ProjectDAO.Instance.DeleteProjectFileDAO(pIdProject)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de eliminar "
        End Try

        Return reply

    End Function

    Public Function DeleteSegUsuBLL(ByVal pIdProject As Integer) As Reply(Of SegUsuProjectEN)


        Dim reply As Reply(Of SegUsuProjectEN) = Nothing

        Try
            If pIdProject <> 0 Then


                reply = ProjectDAO.Instance.DeleteSegUsuDAO(pIdProject)


            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al tratar de eliminar "
        End Try

        Return reply

    End Function

End Class
