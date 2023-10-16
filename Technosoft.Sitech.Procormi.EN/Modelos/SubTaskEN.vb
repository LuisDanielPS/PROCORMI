Imports System.Runtime.Serialization

Public Class SubTaskEN

    Private _Id_Sub_Task As Integer

    <DataMember()>
    Public Property Id_Sub_Task() As Integer
        Get
            Return _Id_Sub_Task
        End Get
        Set(value As Integer)
            _Id_Sub_Task = value
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

    Private _Description As String

    <DataMember()>
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
        End Set
    End Property

    Private _Required_Time As Integer

    <DataMember()>
    Public Property Required_Time() As Integer
        Get
            Return _Required_Time
        End Get
        Set(value As Integer)
            _Required_Time = value
        End Set
    End Property

    Private _Id_Task As Integer

    <DataMember()>
    Public Property Id_Task() As Integer
        Get
            Return _Id_Task
        End Get
        Set(value As Integer)
            _Id_Task = value
        End Set
    End Property

    Private _Id_Status As String

    <DataMember()>
    Public Property Id_Status() As String
        Get
            Return _Id_Status
        End Get
        Set(value As String)
            _Id_Status = value
        End Set
    End Property

    Private _Id_Priority As String

    <DataMember()>
    Public Property Id_Priority() As String
        Get
            Return _Id_Priority
        End Get
        Set(value As String)
            _Id_Priority = value
        End Set
    End Property
End Class
