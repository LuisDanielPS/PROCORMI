Imports System.Runtime.Serialization

Public Class SegUsuProjectEN

    Private _Id As Integer

    <DataMember()>
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Private _User_Login As String

    <DataMember()>
    Public Property User_Login() As String
        Get
            Return _User_Login
        End Get
        Set(value As String)
            _User_Login = value
        End Set
    End Property


    Private _Id_Project As Integer

    <DataMember()>
    Public Property Id_Project() As Integer
        Get
            Return _Id_Project
        End Get
        Set(value As Integer)
            _Id_Project = value
        End Set
    End Property
End Class
