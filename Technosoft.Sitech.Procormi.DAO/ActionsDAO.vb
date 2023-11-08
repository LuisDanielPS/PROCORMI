Imports System.Reflection
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class ActionsDAO

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As ActionsDAO
        Return New ActionsDAO
    End Function

    Dim sentence As String = ""

    Public Function PostActionDao(ByVal action As ActionEN) As Reply(Of ActionEN)

        Dim reply As New Reply(Of ActionEN)

        Try

            sentence = "INSERT INTO actions (Action_Description, Action_Date, Action_User) VALUES ('" & action.Action_Description & "', now(), '" & action.Action_User & "')"

            ConexionDAO.Instancia.EjecutarSentenciaSimple(sentence)
            reply.ok = True
            reply.msg = "Acción agregada con éxito"


        Catch ex As Exception
            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)
            reply.ok = False
            reply.msg = "No fue posible ejecutar la consulta: " & ex.Message
            Return reply
        End Try


        Return reply


    End Function

End Class
