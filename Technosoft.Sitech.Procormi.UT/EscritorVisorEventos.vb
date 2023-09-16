Imports System.Configuration
Imports System.Data.Entity.Validation
Imports Newtonsoft.Json

Namespace Technosoft.Sitech.Procormi.UT
    Public Class EscritorVisorEventos
        Public Shared Function Instancia() As EscritorVisorEventos
            Try
                Return New EscritorVisorEventos()
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private logName As String
        Private origen As String

        Public Sub New()
            Try
                Dim nombreOrigen As String = ConfigurationSettings.AppSettings.[Get]("VisorEventosOrigen")

                If nombreOrigen IsNot Nothing AndAlso nombreOrigen.Trim() <> "" Then
                Else
                    nombreOrigen = "TestConocormi"
                End If

                logName = nombreOrigen
                origen = nombreOrigen
            Catch ex As Exception
                EventLog.WriteEntry("Application", $"Error en VisorEventos-EscritorVisorEventos(). \n\nError: {ex.Message}. \n\nTrazabilidad: {ex.StackTrace}. \n\nRastreabilidad: {ex.TargetSite}", System.Diagnostics.EventLogEntryType.[Error])
            End Try
        End Sub

        Private Function ValidarExistenciaRegistro() As Boolean
            Dim existe As Boolean = False

            Try

                If Not EventLog.SourceExists(origen) Then
                    EventLog.CreateEventSource(origen, Me.logName)
                    existe = True
                Else
                    existe = True
                End If

            Catch ex As Exception
                EventLog.WriteEntry("Application", $"Error en VisorEventos-ValidarExistenciaRegistro. \n\nError: {ex.Message}. \n\nTrazabilidad: {ex.StackTrace}. \n\nRastreabilidad: {ex.TargetSite}", System.Diagnostics.EventLogEntryType.[Error])
            End Try

            Return existe
        End Function

        Public Sub EscribirEvento(ByVal nombreClase As String, ByVal nombreMetodo As String, ByVal ex As Exception, ByVal Optional tipo As Integer = 1, ByVal Optional mensaje As String = "")
            Try

                If ValidarExistenciaRegistro() Then
                    Dim evento = New System.Diagnostics.EventLog()
                    evento.Source = origen
                    Dim texto As String = $"Clase: {nombreClase} \n\nMétodo: {nombreMetodo}"

                    If ex IsNot Nothing Then
                        texto += $"\n\nError: {ex.Message} \n\nTrazabilidad: {ex.StackTrace} \n\nRastreabilidad: {ex.TargetSite}"

                        If ex.InnerException IsNot Nothing Then
                            texto += $"\n\nInner Exception: {ex.InnerException.ToString()}"
                        End If

                        Try
                            Dim jsonn As String = JsonConvert.SerializeObject(ex)
                            Dim exx As EntityValidationError = JsonConvert.DeserializeObject(Of EntityValidationError)(jsonn)

                            If exx IsNot Nothing Then

                                If exx.EntityValidationErrors IsNot Nothing Then

                                    If exx.EntityValidationErrors.Count > 0 Then
                                        texto += vbLf & vbLf & "Errores del Entity: " & vbLf

                                        For Each error1 As EntityValidationErrors In exx.EntityValidationErrors

                                            For Each error2 As ValidationErrors In error1.ValidationErrors
                                                texto += $"Propiedad: {error2.PropertyName} - Error: {error2.ErrorMessage} \n"
                                            Next
                                        Next
                                    End If
                                End If
                            End If

                        Catch exxx As Exception
                            EventLog.WriteEntry("Application", $"Error en VisorEventos-EscribirEvento-Json-Entity. \n\nError: {exxx.Message}. \n\nTrazabilidad: {exxx.StackTrace}. \n\nRastreabilidad: {exxx.TargetSite}", System.Diagnostics.EventLogEntryType.[Error])
                        End Try
                    End If

                    If mensaje IsNot Nothing AndAlso mensaje <> "" Then
                        texto += $"\n\nError: {mensaje}"
                    End If

                    evento.WriteEntry(texto, (If(tipo = 1, EventLogEntryType.[Error], (If(tipo = 2, EventLogEntryType.Information, (If(tipo = 3, EventLogEntryType.Warning, EventLogEntryType.[Error])))))))
                End If

            Catch exxx As Exception
                EventLog.WriteEntry("Application", $"Error en VisorEventos-EscribirEvento. \n\nError: {exxx.Message}. \n\nTrazabilidad: {exxx.StackTrace}. \n\nRastreabilidad: {exxx.TargetSite}", System.Diagnostics.EventLogEntryType.[Error])
            End Try
        End Sub

        Public Sub EscribirEventoEntity(ByVal nombreClase As String, ByVal nombreMetodo As String, ByVal ex As DbEntityValidationException, ByVal Optional tipo As Integer = 1)
            Try

                If ValidarExistenciaRegistro() Then
                    Dim evento = New System.Diagnostics.EventLog()
                    evento.Source = origen
                    Dim texto As String = $"Clase: {nombreClase} \n\nMétodo: {nombreMetodo}"
                    texto += $"\n\nError: {ex.Message} \n\nTrazabilidad: {ex.StackTrace} \n\nRastreabilidad: {ex.TargetSite}"

                    If ex.InnerException IsNot Nothing Then
                        texto += $"\n\nExcepción: {ex.InnerException.ToString()}"
                    End If

                    If ex.EntityValidationErrors IsNot Nothing Then
                        texto += vbLf & vbLf & "Errores del Entity: " & vbLf

                        For Each error1 As DbEntityValidationResult In ex.EntityValidationErrors

                            For Each error2 As DbValidationError In error1.ValidationErrors
                                texto += $"Propiedad: {error2.PropertyName} - Error: {error2.ErrorMessage} \n"
                            Next
                        Next
                    End If

                    evento.WriteEntry(texto, (If(tipo = 1, EventLogEntryType.[Error], (If(tipo = 2, EventLogEntryType.Information, (If(tipo = 3, EventLogEntryType.Warning, EventLogEntryType.[Error])))))))
                End If

            Catch exxx As Exception
                EventLog.WriteEntry("Application", $"Error en VisorEventos-EscribirEvento. \n\nError: {exxx.Message}. \n\nTrazabilidad: {exxx.StackTrace}. \n\nRastreabilidad: {exxx.TargetSite}", System.Diagnostics.EventLogEntryType.[Error])
            End Try
        End Sub

        Public Sub EliminarEvento()
            Try
                EventLog.DeleteEventSource(origen)
            Catch ex As Exception
                EventLog.WriteEntry("Application", $"Error en VisorEventos-EliminarEvento. \n\nError: {ex.Message}. \n\nTrazabilidad: {ex.StackTrace}. \n\nRastreabilidad: {ex.TargetSite}", System.Diagnostics.EventLogEntryType.[Error])
            End Try
        End Sub

        Private Class EntityValidationError
            Public Property EntityValidationErrors As List(Of EntityValidationErrors)
        End Class

        Private Class EntityValidationErrors
            Public Property ValidationErrors As List(Of ValidationErrors)
        End Class

        Private Class ValidationErrors
            Public Property PropertyName As String
            Public Property ErrorMessage As String
        End Class
    End Class
End Namespace