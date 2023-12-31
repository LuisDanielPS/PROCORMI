﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Configuración y servicios de API web

        ' Rutas de API web
        config.MapHttpAttributeRoutes()

        Dim cors = New Cors.EnableCorsAttribute("*", "*", "*")
        config.EnableCors(cors)

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{action}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub
End Module
