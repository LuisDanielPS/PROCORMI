Imports System.Runtime.Serialization

Public Class UsuarioEN

    Private _usu_Login As String
    <DataMember()>
    Public Property usu_Login() As String
        Get
            Return _usu_Login
        End Get
        Set(ByVal value As String)
            _usu_Login = value
        End Set
    End Property

    Private _usu_Nombre As String
    <DataMember()>
    Public Property usu_Nombre() As String
        Get
            Return _usu_Nombre
        End Get
        Set(ByVal value As String)
            _usu_Nombre = value
        End Set
    End Property

    Private _usu_Password As String
    <DataMember()>
    Public Property usu_Password() As String
        Get
            Return _usu_Password
        End Get
        Set(ByVal value As String)
            _usu_Password = value
        End Set
    End Property

    Private _usu_Tipo As String
    <DataMember()>
    Public Property usu_Tipo() As String
        Get
            Return _usu_Tipo
        End Get
        Set(ByVal value As String)
            _usu_Tipo = value
        End Set
    End Property

    Private _usu_Fecha As Date
    <DataMember()>
    Public Property usu_Fecha() As Date
        Get
            Return _usu_Fecha
        End Get
        Set(ByVal value As Date)
            _usu_Fecha = value
        End Set
    End Property

    Private _usu_Vigencia As Integer
    <DataMember()>
    Public Property usu_Vigencia() As Integer
        Get
            Return _usu_Vigencia
        End Get
        Set(ByVal value As Integer)
            _usu_Vigencia = value
        End Set
    End Property

    Private _usu_email As String
    <DataMember()>
    Public Property usu_email() As String
        Get
            Return _usu_email
        End Get
        Set(ByVal value As String)
            _usu_email = value
        End Set
    End Property

    Private _usu_remote As Integer
    <DataMember()>
    Public Property usu_remote() As Integer
        Get
            Return _usu_remote
        End Get
        Set(ByVal value As Integer)
            _usu_remote = value
        End Set
    End Property

    Private _horario_numero As Integer
    <DataMember()>
    Public Property horario_numero() As Integer
        Get
            Return _horario_numero
        End Get
        Set(ByVal value As Integer)
            _horario_numero = value
        End Set
    End Property

End Class
