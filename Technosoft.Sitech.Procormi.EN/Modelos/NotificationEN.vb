Imports System.Runtime.Serialization

Public Class NotificationEN

    Private _Id_Notification As Integer

    <DataMember()>
    Public Property Id_Notification() As Integer
        Get
            Return _Id_Notification
        End Get
        Set(value As Integer)
            _Id_Notification = value
        End Set
    End Property

    Private _Message As String

    <DataMember()>
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(value As String)
            _Message = value
        End Set
    End Property

    Private _Title As String

    <DataMember()>
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(value As String)
            _Title = value
        End Set
    End Property

    Private _Creation_Date As DateTime

    <DataMember()>
    Public Property Creation_Date() As DateTime
        Get
            Return _Creation_Date
        End Get
        Set(value As DateTime)
            _Creation_Date = value
        End Set
    End Property

    Private _Read As Boolean

    <DataMember()>
    Public Property Read() As Boolean
        Get
            Return _Read
        End Get
        Set(value As Boolean)
            _Read = value
        End Set
    End Property

    Private _Action As String

    <DataMember()>
    Public Property Action() As String
        Get
            Return _Action
        End Get
        Set(value As String)
            _Action = value
        End Set
    End Property

    Private _Type As String

    <DataMember()>
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(value As String)
            _Type = value
        End Set
    End Property

    Private _Type_Ref_Id As Integer

    <DataMember()>
    Public Property Type_Ref_Id() As Integer
        Get
            Return _Type_Ref_Id
        End Get
        Set(value As Integer)
            _Type_Ref_Id = value
        End Set
    End Property

    Private _Usu_Login As String

    <DataMember()>
    Public Property Usu_Login() As String
        Get
            Return _Usu_Login
        End Get
        Set(value As String)
            _Usu_Login = value
        End Set
    End Property
End Class
