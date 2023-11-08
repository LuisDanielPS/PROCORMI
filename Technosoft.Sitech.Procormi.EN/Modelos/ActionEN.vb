Imports System.Runtime.Serialization

Public Class ActionEN

    Private _Id_Actions As Integer

    <DataMember()>
    Public Property Id_Actions() As Integer
        Get
            Return _Id_Actions
        End Get
        Set(value As Integer)
            _Id_Actions = value
        End Set
    End Property

    Private _Action_Description As String

    <DataMember()>
    Public Property Action_Description() As String
        Get
            Return _Action_Description
        End Get
        Set(value As String)
            _Action_Description = value
        End Set
    End Property

    Private _Action_User As String

    <DataMember()>
    Public Property Action_User() As String
        Get
            Return _Action_User
        End Get
        Set(value As String)
            _Action_User = value
        End Set
    End Property

End Class
