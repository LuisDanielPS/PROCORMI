Imports System.Runtime.Serialization


Public Class UserListSprintVM

    Private _Id_Sprint As Integer

    <DataMember()>
    Public Property Id_Sprint() As Integer
        Get
            Return _Id_Sprint
        End Get
        Set(value As Integer)
            _Id_Sprint = value
        End Set
    End Property

    <DataMember()>
    Private _usu_Login As String
    Public Property Usu_Login() As String
        Get
            Return _usu_Login
        End Get
        Set(value As String)
            _usu_Login = value
        End Set
    End Property

    <DataMember()>
    Private _usu_Nombre As String
    Public Property Usu_Nombre() As String
        Get
            Return _usu_Nombre
        End Get
        Set(value As String)
            _usu_Nombre = value
        End Set
    End Property
End Class
