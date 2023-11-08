Imports System.Reflection
Imports Technosoft.Sitech.Procormi.DAO
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT
Imports Technosoft.Sitech.Procormi.UT.Technosoft.Sitech.Procormi.UT

Public Class ActionsBLL

    Private nameClass As String = MethodBase.GetCurrentMethod().DeclaringType.Name

    Public Shared Function Instance() As ActionsBLL
        Return New ActionsBLL
    End Function

    Public Function PostActionBLL(ByVal action As ActionEN) As Reply(Of ActionEN)


        Dim reply As Reply(Of ActionEN) = Nothing

        Try
            If action IsNot Nothing Then

                reply = ActionsDAO.Instance.PostActionDao(action)
            End If

        Catch ex As Exception

            EscritorVisorEventos.Instancia().EscribirEvento(nameClass, MethodBase.GetCurrentMethod().Name, ex)

        End Try

        Return reply

    End Function

End Class
