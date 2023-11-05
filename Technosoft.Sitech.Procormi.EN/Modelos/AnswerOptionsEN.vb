Imports System.Runtime.Serialization

Public Class AnswerOptionsEN

    Private _Id_Answer_Option As Integer

    <DataMember()>
    Public Property Id_Answer_Option() As Integer
        Get
            Return _Id_Answer_Option
        End Get
        Set(value As Integer)
            _Id_Answer_Option = value
        End Set
    End Property

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

End Class
