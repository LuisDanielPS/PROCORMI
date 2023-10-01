Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT
Public Class FileBLL
    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As FileBLL
        Return New FileBLL
    End Function


    Public Function PostFileBLL(ByVal pFile As FileEN) As Reply(Of FileEN)


        Dim reply As Reply(Of FileEN) = Nothing

        Try
            If pFile IsNot Nothing Then

                reply = FileDAO.Instance.PostFileDAO(pFile)
                reply.ok = True
                reply.msg = "Se creo el file correctamente"
            End If

        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "Error al crear file"
        End Try

        Return reply

    End Function

End Class
