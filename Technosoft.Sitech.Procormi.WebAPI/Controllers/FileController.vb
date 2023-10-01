Imports System.Net
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT


Namespace Controllers
    Public Class FileController
        Inherits ApiController
        <HttpPost>
        Public Function PostFile(ByVal pFile As FileEN) As Reply(Of FileEN)
            Dim reply As Reply(Of FileEN) = New Reply(Of FileEN)
            reply = FileBLL.Instance.PostFileBLL(pFile)
            Return reply
        End Function

    End Class
End Namespace