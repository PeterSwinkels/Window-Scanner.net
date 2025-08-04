'This module's settings and imports.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Windows.Forms

'This module contains the dialog window.
Public Class InputDialog
   'This procedure initializes this window
   Public Sub New(Prompt As String, Input As String)
      Try
         Dim PreviousHeight As New Integer

         InitializeComponent()

         Me.Text = My.Application.Info.Title

         PromptLabel.Text = Prompt
         TextBox.Text = Input

         With Me.CreateGraphics
            PreviousHeight = Panel.Height
            Panel.Height = CInt(CreateGraphics.MeasureString(PromptLabel.Text, PromptLabel.Font).Height + 32)
            Me.Height += Panel.Height - PreviousHeight
         End With

         PromptLabel.MaximumSize = Panel.Size
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure closes this window and indicates that the cancel button was pressed.
   Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
      Try
         Me.DialogResult = DialogResult.Cancel
         Me.Close()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure initializes this window.
   Private Sub InputDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      Try
         TextBox.Focus()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure closes this window and indicates that the ok button was pressed.
   Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
      Try
         Me.DialogResult = DialogResult.OK
         Me.Close()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub
End Class
