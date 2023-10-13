Imports System.Runtime.Serialization

Public Class SprintStatusReportVM
    'Esta clase sirve para almacenar la consulta join  

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

    Private _Sprint_Name As String

    <DataMember()>
    Public Property Sprint_Name() As String
        Get
            Return _Sprint_Name
        End Get
        Set(value As String)
            _Sprint_Name = value
        End Set
    End Property

    Private _Start_Date As DateTime

    <DataMember()>
    Public Property Start_Date() As Date
        Get
            Return _Start_Date
        End Get
        Set(value As Date)
            _Start_Date = value
        End Set
    End Property

    Private _End_Date As DateTime

    <DataMember()>
    Public Property End_Date() As Date
        Get
            Return _End_Date
        End Get
        Set(value As Date)
            _End_Date = value
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

    Private _Status_Name As String

    <DataMember()>
    Public Property Status_Name() As String
        Get
            Return _Status_Name
        End Get
        Set(value As String)
            _Status_Name = value
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


End Class
