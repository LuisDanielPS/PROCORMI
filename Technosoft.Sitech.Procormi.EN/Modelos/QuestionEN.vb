Imports System.Runtime.Serialization

Public Class QuestionEN

    Private _Id_Question As Integer

    <DataMember()>
    Public Property Id_Question() As Integer
        Get
            Return _Id_Question
        End Get
        Set(value As Integer)
            _Id_Question = value
        End Set
    End Property

    Private _TextQuestion As String

    <DataMember()>
    Public Property TextQuestion() As String
        Get
            Return _TextQuestion
        End Get
        Set(value As String)
            _TextQuestion = value
        End Set
    End Property

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

    Private _Id_Question_Type As Integer

    <DataMember()>
    Public Property Id_Question_Type() As Integer
        Get
            Return _Id_Question_Type
        End Get
        Set(value As Integer)
            _Id_Question_Type = value
        End Set
    End Property

    Private _Question_Options As List(Of QuestionOptionsEN)

    <DataMember()>
    Public Property Question_Options() As List(Of QuestionOptionsEN)
        Get
            Return _Question_Options
        End Get
        Set(value As List(Of QuestionOptionsEN))
            _Question_Options = value
        End Set
    End Property

    Private _AnswerOptions As List(Of AnswerOptionsEN)

    <DataMember()>
    Public Property AnswerOptions() As List(Of AnswerOptionsEN)
        Get
            Return _AnswerOptions
        End Get
        Set(value As List(Of AnswerOptionsEN))
            _AnswerOptions = value
        End Set
    End Property

    Private _AnswerText As AnswerTextEN

    <DataMember()>
    Public Property AnswerText() As AnswerTextEN
        Get
            Return _AnswerText
        End Get
        Set(value As AnswerTextEN)
            _AnswerText = value
        End Set
    End Property
End Class
