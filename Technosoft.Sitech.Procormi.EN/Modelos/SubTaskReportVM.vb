﻿Imports System.Runtime.Serialization

Public Class SubTaskReportVM

    Private _Id_Sub_Task As Integer

    <DataMember()>
    Public Property Id_Sub_Task() As Integer
        Get
            Return _Id_Sub_Task
        End Get
        Set(value As Integer)
            _Id_Sub_Task = value
        End Set
    End Property

    Private _Title As String

    <DataMember()>
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(value As String)
            _Title = value
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

    Private _Id_Task As Integer

    <DataMember()>
    Public Property Id_Task() As Integer
        Get
            Return _Id_Task
        End Get
        Set(value As Integer)
            _Id_Task = value
        End Set
    End Property

    Private _Task_Name As String

    <DataMember()>
    Public Property Task_Name() As String
        Get
            Return _Task_Name
        End Get
        Set(value As String)
            _Task_Name = value
        End Set
    End Property

    Private _Description_Task As String

    <DataMember()>
    Public Property Description_Task() As String
        Get
            Return _Description_Task
        End Get
        Set(value As String)
            _Description_Task = value
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


    Private _Sprint_Name As String

    <DataMember()>
    Public Property Sprint_Name() As String
        Get
            Return _Sprint_Name
        End Get
        Set(value As String)
            _Sprint_Name = value
        End Set
    End Property

    Private _Priority_Name As String

    <DataMember()>
    Public Property Priority_Name() As String
        Get
            Return _Priority_Name
        End Get
        Set(value As String)
            _Priority_Name = value
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

End Class
