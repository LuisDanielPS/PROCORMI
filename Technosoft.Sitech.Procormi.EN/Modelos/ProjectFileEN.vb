Imports System.Runtime.Serialization
Public Class ProjectFileEN

    Private _ID_Project_File As Integer
    <DataMember()>
    Public Property ID_Project_File() As Integer
        Get
            Return _ID_Project_File
        End Get
        Set(value As Integer)
            _ID_Project_File = value
        End Set
    End Property

    Private _Id_Project As Integer
    <DataMember()>
    Public Property Id_Project() As Integer
        Get
            Return _Id_Project
        End Get
        Set(value As Integer)
            _Id_Project = value
        End Set
    End Property

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

End Class
