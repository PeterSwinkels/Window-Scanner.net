<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputDialog
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
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
      Me.OKButton = New System.Windows.Forms.Button()
      Me.AbortButton = New System.Windows.Forms.Button()
      Me.TextBox = New System.Windows.Forms.TextBox()
      Me.Panel = New System.Windows.Forms.Panel()
      Me.PromptLabel = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(260, 10)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(67, 23)
        Me.OKButton.TabIndex = 1
        Me.OKButton.TabStop = False
        Me.OKButton.Text = "&OK"
        '
        'AbortButton
        '
        Me.AbortButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AbortButton.Location = New System.Drawing.Point(260, 39)
        Me.AbortButton.Name = "AbortButton"
        Me.AbortButton.Size = New System.Drawing.Size(67, 23)
        Me.AbortButton.TabIndex = 2
        Me.AbortButton.TabStop = False
        Me.AbortButton.Text = "&Cancel"
        '
        'TextBox
        '
        Me.TextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TextBox.Location = New System.Drawing.Point(12, 68)
        Me.TextBox.Name = "TextBox"
        Me.TextBox.Size = New System.Drawing.Size(315, 20)
        Me.TextBox.TabIndex = 0
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.PromptLabel)
        Me.Panel.Location = New System.Drawing.Point(12, 10)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(242, 51)
        Me.Panel.TabIndex = 4
        '
        'PromptLabel
        '
        Me.PromptLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PromptLabel.AutoEllipsis = True
        Me.PromptLabel.AutoSize = True
        Me.PromptLabel.Location = New System.Drawing.Point(0, 0)
        Me.PromptLabel.Name = "PromptLabel"
        Me.PromptLabel.Size = New System.Drawing.Size(0, 13)
        Me.PromptLabel.TabIndex = 5
        '
        'InputDialog
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AbortButton
        Me.ClientSize = New System.Drawing.Size(339, 98)
        Me.Controls.Add(Me.TextBox)
        Me.Controls.Add(Me.AbortButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InputDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OKButton As System.Windows.Forms.Button
   Friend WithEvents AbortButton As System.Windows.Forms.Button
   Friend WithEvents TextBox As System.Windows.Forms.TextBox
   Friend WithEvents Panel As System.Windows.Forms.Panel
   Friend WithEvents PromptLabel As System.Windows.Forms.Label
End Class
