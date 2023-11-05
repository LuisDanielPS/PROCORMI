Imports System.Runtime.Serialization
Public Class AnswerTextEN


    Private _Id_Answer As Integer

    <DataMember()>
    Public Property Id_Answer() As Integer
        Get
            Return _Id_Answer
        End Get
        Set(value As Integer)
            _Id_Answer = value
        End Set
    End Property

    Private _Text As String

    <DataMember()>
    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(value As String)
            _Text = value
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


End Class
