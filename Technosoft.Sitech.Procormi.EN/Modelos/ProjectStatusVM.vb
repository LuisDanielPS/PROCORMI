Imports System.Runtime.Serialization

Public Class ProjectStatusVM

    Private _Id_project As Integer

    <DataMember()>
    Public Property Id_project() As Integer
        Get
            Return _Id_project
        End Get
        Set(value As Integer)
            _Id_project = value
        End Set
    End Property

    Private _Project_Name As String

    <DataMember()>
    Public Property Project_Name() As String
        Get
            Return _Project_Name
        End Get
        Set(value As String)
            _Project_Name = value
        End Set
    End Property

    Private _Description_Project As String

    <DataMember()>
    Public Property Description_Project() As String
        Get
            Return _Description_Project
        End Get
        Set(value As String)
            _Description_Project = value
        End Set
    End Property

    Private _Status_Name As String

    <DataMember()>
    Public Property Status_Name() As String
        Get
            Return _Status_Name
        End Get
        Set(value As String)
            _Status_Name = value
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

End Class
