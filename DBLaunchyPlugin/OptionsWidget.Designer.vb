<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsWidget
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.lblServer = New System.Windows.Forms.Label
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.lblUser = New System.Windows.Forms.Label
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.lblPass = New System.Windows.Forms.Label
        Me.lblDB = New System.Windows.Forms.Label
        Me.txtDB = New System.Windows.Forms.TextBox
        Me.lblCmd = New System.Windows.Forms.Label
        Me.txtCmd = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(113, 15)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(192, 20)
        Me.txtServer.TabIndex = 0
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(14, 18)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(41, 13)
        Me.lblServer.TabIndex = 1
        Me.lblServer.Text = "Server:"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(113, 65)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(100, 20)
        Me.txtUser.TabIndex = 0
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(14, 68)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(32, 13)
        Me.lblUser.TabIndex = 1
        Me.lblUser.Text = "User:"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(113, 90)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(100, 20)
        Me.txtPass.TabIndex = 0
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Location = New System.Drawing.Point(14, 93)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(33, 13)
        Me.lblPass.TabIndex = 1
        Me.lblPass.Text = "Pass:"
        '
        'lblDB
        '
        Me.lblDB.AutoSize = True
        Me.lblDB.Location = New System.Drawing.Point(14, 43)
        Me.lblDB.Name = "lblDB"
        Me.lblDB.Size = New System.Drawing.Size(56, 13)
        Me.lblDB.TabIndex = 3
        Me.lblDB.Text = "Database:"
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(113, 40)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(100, 20)
        Me.txtDB.TabIndex = 2
        '
        'lblCmd
        '
        Me.lblCmd.AutoSize = True
        Me.lblCmd.Location = New System.Drawing.Point(14, 118)
        Me.lblCmd.Name = "lblCmd"
        Me.lblCmd.Size = New System.Drawing.Size(93, 13)
        Me.lblCmd.TabIndex = 5
        Me.lblCmd.Text = "Stored Procedure:"
        '
        'txtCmd
        '
        Me.txtCmd.Location = New System.Drawing.Point(113, 115)
        Me.txtCmd.Name = "txtCmd"
        Me.txtCmd.Size = New System.Drawing.Size(192, 20)
        Me.txtCmd.TabIndex = 4
        '
        'OptionsWidget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblCmd)
        Me.Controls.Add(Me.txtCmd)
        Me.Controls.Add(Me.lblDB)
        Me.Controls.Add(Me.txtDB)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtServer)
        Me.Name = "OptionsWidget"
        Me.Size = New System.Drawing.Size(331, 190)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents lblDB As System.Windows.Forms.Label
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents lblCmd As System.Windows.Forms.Label
    Friend WithEvents txtCmd As System.Windows.Forms.TextBox

End Class
