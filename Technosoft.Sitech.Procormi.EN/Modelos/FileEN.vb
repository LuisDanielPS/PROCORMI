Imports System.Runtime.Serialization
Public Class FileEN

    Private _File_ID As Integer

    <DataMember()>
    Public Property File_ID() As Integer
        Get
            Return _File_ID
        End Get
        Set(value As Integer)
            _File_ID = value
        End Set
    End Property


    Private _File_Name As String

    <DataMember()>
    Public Property File_Name() As String
        Get
            Return _File_Name
        End Get
        Set(value As String)
            _File_Name = value
        End Set
    End Property


    Private _File_Path As String

    <DataMember()>
    Public Property File_Path() As String
        Get
            Return _File_Path
        End Get
        Set(value As String)
            _File_Path = value
        End Set
    End Property


    Private _File_Type As String

    <DataMember()>
    Public Property File_Type() As String
        Get
            Return _File_Type
        End Get
        Set(value As String)
            _File_Type = value
        End Set
    End Property


    Private _File_Size As Integer

    <DataMember()>
    Public Property File_Size() As Integer
        Get
            Return _File_Size
        End Get
        Set(value As Integer)
            _File_Size = value
        End Set
    End Property


    Private _Creation_Date As Date

    <DataMember()>
    Public Property Creation_Date() As Date
        Get
            Return _Creation_Date
        End Get
        Set(value As Date)
            _Creation_Date = value
        End Set
    End Property

End Class
