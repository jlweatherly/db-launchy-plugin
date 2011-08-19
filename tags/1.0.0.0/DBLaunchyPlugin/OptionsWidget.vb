Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms


Partial Public Class OptionsWidget
    'Inherits UserControl

    Public Sub OptionsWidget()
        InitializeComponent()

    End Sub
    Public Property Server() As String
        Get
            Return txtServer.Text
        End Get
        Set(ByVal value As String)
            txtServer.Text = value
        End Set
    End Property
    Public Property User() As String
        Get
            Return txtUser.text
        End Get
        Set(ByVal value As String)
            txtUser.text = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return txtPass.Text
        End Get
        Set(ByVal value As String)
            txtPass.Text = value
        End Set
    End Property
    Public Property DB() As String
        Get
            Return txtDB.Text
        End Get
        Set(ByVal value As String)
            txtDB.Text = value
        End Set
    End Property
    Public Property SQLCommand() As String
        Get
            Return txtCmd.Text
        End Get
        Set(ByVal value As String)
            txtCmd.Text = value
        End Set
    End Property


End Class


