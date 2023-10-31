Imports System.Runtime.Serialization

Public Class QuestionOptionsEN

    Private _Id_Question_Option As Integer

    <DataMember()>
    Public Property Id_Question_Option() As Integer
        Get
            Return _Id_Question_Option
        End Get
        Set(value As Integer)
            _Id_Question_Option = value
        End Set
    End Property

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

    Private _Option_Text As String

    <DataMember()>
    Public Property Option_Text() As String
        Get
            Return _Option_Text
        End Get
        Set(value As String)
            _Option_Text = value
        End Set
    End Property

End Class
