Public Class Reply(Of T)

    Public Sub Reply()
        Me.ok = True
        Me.msg = String.Empty
    End Sub

    Public Sub toError(msg As String, objObjeto As T)
        Me.obj = obj
        Me.ok = False
        Me.msg = msg
    End Sub

    Private _obj As T
    Private _ok As Boolean
    Private _msg As String

    Public Property obj() As T
        Get
            Return _obj
        End Get
        Set(value As T)
            _obj = value
        End Set
    End Property

    Public Property ok() As Boolean
        Get
            Return _ok
        End Get
        Set(value As Boolean)
            _ok = value
        End Set
    End Property

    Public Property msg() As String
        Get
            Return _msg
        End Get
        Set(value As String)
            _msg = value
        End Set
    End Property

End Class