Imports System.Runtime.Serialization

Public Class PollEN

    Private _Id_Poll As Integer

    <DataMember()>
    Public Property Id_Poll() As Integer
        Get
            Return _Id_Poll
        End Get
        Set(value As Integer)
            _Id_Poll = value
        End Set
    End Property

    Private _Name As String

    <DataMember()>
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
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

    Private _Creation_Date As DateTime

    <DataMember()>
    Public Property Creation_Date() As Date
        Get
            Return _Creation_Date
        End Get
        Set(value As Date)
            _Creation_Date = value
        End Set
    End Property

    Private _Questions As List(Of QuestionEN)

    <DataMember()>
    Public Property Questions() As List(Of QuestionEN)
        Get
            Return _Questions
        End Get
        Set(value As List(Of QuestionEN))
            _Questions = value
        End Set
    End Property

End Class
