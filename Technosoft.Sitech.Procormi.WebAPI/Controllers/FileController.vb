Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Web.Http
Imports Technosoft.Sitech.Procormi.BLL
Imports Technosoft.Sitech.Procormi.EN
Imports Technosoft.Sitech.Procormi.UT


Namespace Controllers
    Public Class FileController
        Inherits ApiController



        <HttpGet>
        Public Function DownloadFile(ByVal nombreArchivo As String) As HttpResponseMessage
            Try
                Dim rutaArchivo As String = HttpContext.Current.Server.MapPath("~/uploads/" & nombreArchivo)

                If System.IO.File.Exists(rutaArchivo) Then
                    Dim stream As New FileStream(rutaArchivo, FileMode.Open)

                    Dim response As New HttpResponseMessage(HttpStatusCode.OK)
                    response.Content = New StreamContent(stream)
                    response.Content.Headers.ContentDisposition = New ContentDispositionHeaderValue("attachment")
                    response.Content.Headers.ContentDisposition.FileName = nombreArchivo
                    response.Content.Headers.ContentType = New MediaTypeHeaderValue("application/octet-stream")

                    Return response
                Else
                    Return Request.CreateResponse(HttpStatusCode.NotFound)
                End If
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex)
            End Try
        End Function


        <HttpPost>
        Public Function PostFile(ByVal pFile As FileEN) As Reply(Of FileEN)
            Dim reply As Reply(Of FileEN) = New Reply(Of FileEN)
            reply = FileBLL.Instance.PostFileBLL(pFile)
            Return reply
        End Function

        <HttpPost>
        Public Function PostUploadFile(ByVal pIdProject As Integer, ByVal pCreationdate As String) As IHttpActionResult
            Try
                Dim httpRequest = HttpContext.Current.Request

                If httpRequest.Files.Count > 0 Then
                    For i As Integer = 0 To httpRequest.Files.Count - 1
                        Dim file As HttpPostedFile = httpRequest.Files(i)
                        Dim FileNameOriginal As String = file.FileName
                        Dim rutaArchivo As String = HttpContext.Current.Server.MapPath("~/uploads/" & FileNameOriginal)

                        Dim FileNameNew As String = ObtenerNuevoNombreUnico(FileNameOriginal, pIdProject, pCreationdate)
                        rutaArchivo = HttpContext.Current.Server.MapPath("~/uploads/" & FileNameNew)

                        file.SaveAs(rutaArchivo)
                    Next

                    Return Ok("Archivos subidos con éxito.")
                Else
                    Return BadRequest("No se recibieron archivos para subir.")
                End If
            Catch ex As Exception
                Return InternalServerError(ex)
            End Try
        End Function

        Private Function ObtenerNuevoNombreUnico(originalName As String, pIdProject As Integer, pCreationdate As String) As String
            Dim nameBase As String = Path.GetFileNameWithoutExtension(originalName)
            Dim extension As String = Path.GetExtension(originalName)

            Dim newname As String = nameBase

            ' Verificar si el archivo ya existe y agregar sufijo único

            newname = $"{pIdProject}_{pCreationdate}_{nameBase}"


            Return $"{newname}{extension}"
        End Function




    End Class
End Namespace