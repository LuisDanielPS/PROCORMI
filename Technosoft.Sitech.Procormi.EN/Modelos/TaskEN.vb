﻿Imports System.Runtime.Serialization

Public Class TaskEN

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

    Private _Id_Sprint As Integer

    <DataMember()>
    Public Property Id_Sprint() As Integer
        Get
            Return _Id_Sprint
        End Get
        Set(value As Integer)
            _Id_Sprint = value
        End Set
    End Property

    Private _Id_State As String

    <DataMember()>
    Public Property Id_State() As String
        Get
            Return _Id_State
        End Get
        Set(value As String)
            _Id_State = value
        End Set
    End Property

    Private _Task_State As String
    <DataMember()>
    Public Property Task_State() As String
        Get
            Return _Task_State
        End Get
        Set(value As String)
            _Task_State = value
        End Set
    End Property
End Class
