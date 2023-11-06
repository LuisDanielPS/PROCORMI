Imports System.Runtime.Serialization

Public Class PollReportVM
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


    Private _AnswerTexts As String

    <DataMember()>
    Public Property AnswerTexts() As String
        Get
            Return _AnswerTexts
        End Get
        Set(value As String)
            _AnswerTexts = value
        End Set
    End Property

    Private _TextQuestionOptions As String

    <DataMember()>
    Public Property TextQuestionOptions() As String
        Get
            Return _TextQuestionOptions
        End Get
        Set(value As String)
            _TextQuestionOptions = value
        End Set
    End Property

    Private _Question_Type_Name As String

    <DataMember()>
    Public Property Question_Type_Name() As String
        Get
            Return _Question_Type_Name
        End Get
        Set(value As String)
            _Question_Type_Name = value
        End Set
    End Property


    Private _OptionText As String

    <DataMember()>
    Public Property OptionText() As String
        Get
            Return _OptionText
        End Get
        Set(value As String)
            _OptionText = value
        End Set
    End Property

    Private _AnswerOptionCount As Integer

    <DataMember()>
    Public Property AnswerOptionCount() As Integer
        Get
            Return _AnswerOptionCount
        End Get
        Set(value As Integer)
            _AnswerOptionCount = value
        End Set
    End Property


End Class
