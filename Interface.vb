'This module's settings and imports.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Convert
Imports System.Diagnostics
Imports System.Drawing
Imports System.Environment
Imports System.IO
Imports System.Runtime.InteropServices.Marshal
Imports System.Text
Imports System.Threading.Thread
Imports System.Windows.Forms

'This module contains the main interface window's procedures.
Public Class InterfaceWindow

   'This enumeration lists the window properties which can be excluded from the search results.
   Private Enum ExcludableE As Integer
      ExcludeNone = -1    'Exclude no windows.
      ExcludeChild        'Child windows.
      ExcludeParent       'Parent windows.
      ExcludeDisabled     'Disabled windows.
      ExcludeEnabled      'Enabled windows.
      ExcludeHidden       'Hidden windows.
      ExcludeVisible      'Visible windows.
      ExcludeNonGroup     'Non-Group windows.
      ExcludeGroup        'Group windows.
      ExcludeNonPopup     'Non-popup windows.
      ExcludePopup        'Popup windows.
      ExcludeNonTabStop   'Non-TabStop windows.
      ExcludeTabStop      'TabStop windows.
      ExcludeNonUnicode   'Non-Unicode windows.
      ExcludeUnicode      'Unicode windows.
   End Enum

   'This procedure initializes this window when this program is started.
   Public Sub New()
      Try
         InitializeComponent()

         EnterDebugMode()

         Me.Text = ProgramInformation()

         With My.Computer.Screen.Bounds
            Me.Size = New Size(CInt(.Width / 2), CInt(.Height / 2))
         End With

         UpdateMenus()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure sets the selected window's dimensions and position. 
   Private Sub ChangePositionDimensionsMenu_Click(sender As Object, e As EventArgs) Handles ChangePositionDimensionsMenu.Click
      Try
         Dim Coordinate As New Point
         Dim Dimensions As New RECT
         Dim NewXywh(3) As String
         Dim ParentH As New IntPtr
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)
         Dim Xywh As String = Nothing

         If RefersToWindow(WindowH) Then
            CheckForError(GetWindowRect(WindowH, Dimensions))

            With Dimensions
               NewXywh(2) = CStr(.Right - .Left)
               NewXywh(3) = CStr(.Bottom - .Top)

               ParentH = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowParentColumn").Value, IntPtr)
               If Not ParentH = IntPtr.Zero Then
                  Coordinate.X = .Left
                  Coordinate.Y = .Top
                  CheckForError(ScreenToClient(ParentH, Coordinate))
                  .Left = Coordinate.X
                  .Top = Coordinate.Y
               End If

               NewXywh(0) = CStr(.Left)
               NewXywh(1) = CStr(.Top)
            End With

            Xywh = ShowInputDialog("New dimensions and position (x, y, width, height):", String.Join(","c, NewXywh))
            If Not Xywh = Nothing Then
               NewXywh = Xywh.Replace(" ", Nothing).Split(","c)

               CheckForError(MoveWindow(WindowH, ToInt32(NewXywh(0)), ToInt32(NewXywh(1)), ToInt32(NewXywh(2)), ToInt32(NewXywh(3)), CInt(True)))
               RefreshWindow(WindowH)
               UpdateSearchResults()
            End If
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure changes the selected window's parent window.
   Private Sub ChangeParentMenu_Click(sender As Object, e As EventArgs) Handles ChangeParentMenu.Click
      Try
         Dim NewParent As String = Nothing
         Dim ParentH As New IntPtr
         Dim Styles As New UInteger
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)

         If RefersToWindow(WindowH) Then
            NewParent = CStr(DirectCast(SearchResultsTable.CurrentRow.Cells("WindowParentColumn").Value, IntPtr))
            NewParent = ShowInputDialog("New parent window:", NewParent)
            If Not NewParent = Nothing Then
               CheckForError(SetParent(WindowH, New IntPtr(ToInt64(NewParent))))

               Styles = CUInt(CheckForError(GetWindowLongA(WindowH, GWL_STYLE)))
               If ToInt64(NewParent) = Nothing Then
                  If WindowHasStyle(WindowH, WS_CHILD) Then Styles = Styles Xor WS_CHILD
               Else
                  Styles = Styles Or WS_CHILD
               End If
               CheckForError(SetWindowLongA(WindowH, GWL_STYLE, Styles))

               RefreshWindow(WindowH)
               UpdateSearchResults()
            End If
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to change the selected window's state.
   Private Sub ChangeStateMenu_Click(sender As Object, e As EventArgs) Handles MaximizeMenu.Click, MinimizeMenu.Click, RestoreMenu.Click
      Try
         Select Case DirectCast(sender, ToolStripMenuItem).Name
            Case "MaximizeMenu"
               ChangeState(SW_SHOWMAXIMIZED)
            Case "MinimizeMenu"
               ChangeState(SW_SHOWMINIMIZED)
            Case "RestoreMenu"
               ChangeState(SW_RESTORE)
         End Select
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure changes the selected window's text.
   Private Sub ChangeTextMenu_Click(sender As Object, e As EventArgs) Handles ChangeTextMenu.Click
      Try
         Dim Button As New DialogResult
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)
         Dim WindowText As String = Nothing

         If RefersToWindow(WindowH) Then
            WindowText = GetWindowText(WindowH)
            WindowText = ShowInputDialog("New window text:", WindowText, Button)
            If Button = DialogResult.OK Then
               CheckForError(SendMessageW(WindowH, WM_SETTEXT, IntPtr.Zero, StringToHGlobalUni(WindowText)))
               RefreshWindow(WindowH)
               UpdateSearchResults()
            End If
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure closes the selected window.
   Private Sub CloseWindowMenu_Click(sender As Object, e As EventArgs) Handles CloseWindowMenu.Click
      Try
         Dim ParentH As New IntPtr
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)

         If RefersToWindow(WindowH) Then
            ParentH = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowParentColumn").Value, IntPtr)
            CheckForError(SendMessageW(WindowH, WM_CLOSE, IntPtr.Zero, IntPtr.Zero))
            If Not ParentH = IntPtr.Zero Then RefreshWindow(ParentH)
            UpdateSearchResults()
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to change the selected window's z-order.
   Private Sub ChangeZOrderMenu_Click(sender As Object, e As EventArgs) Handles BottomMenu.Click, MiddleMenu.Click, PermanentlyOnTopMenu.Click, TopMenu.Click
      Try
         Select Case DirectCast(sender, ToolStripMenuItem).Name
            Case "BottomMenu"
               ChangeZorder(HWND_BOTTOM)
            Case "MiddleMenu"
               ChangeZorder(HWND_NOTOPMOST)
            Case "PermanentlyOnTopMenu"
               ChangeZorder(HWND_TOPMOST)
            Case "TopMenu"
               ChangeZorder(HWND_TOP)
         End Select
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure copies the selected window information to the clipboard.
   Private Sub CopyMenu_Click(sender As Object, e As EventArgs) Handles CopyMenu.Click
      Try
         Select Case SearchResultsTable.CurrentCell.Value.GetType
            Case GetType(IntPtr)
               My.Computer.Clipboard.SetText(CStr(DirectCast(SearchResultsTable.CurrentCell.Value, IntPtr)), TextDataFormat.Text)
            Case Else
               My.Computer.Clipboard.SetText(CStr(SearchResultsTable.CurrentCell.Value), TextDataFormat.Text)
         End Select
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure enables or disables the selected window.
   Private Sub EnableDisableWindowMenu_Click(sender As Object, e As EventArgs) Handles EnableDisableWindowMenu.Click
      Try
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)

         If RefersToWindow(WindowH) Then
            CheckForError(EnableWindow(WindowH, Not CBool(CheckForError(IsWindowEnabled(WindowH)))))
            RefreshWindow(WindowH)
            UpdateSearchResults()
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to toggle the exclusion state of the selected window property.
   Private Sub ExcludeMenu_Click(sender As Object, e As EventArgs)
      Try
         Dim Item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
         Dim Index As Integer = ExcludeMainMenu.DropDownItems.IndexOfKey(Item.Name)
         Dim OtherIndex As Integer = If(Index Mod 2 = 0, Index + 1, Index - 1)

         Item.Checked = Not Item.Checked

         DirectCast(ExcludeMainMenu.DropDownItems.Item(OtherIndex), ToolStripMenuItem).Checked = False

         SearchForWindows()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to request the user to specify a search text.
   Private Sub FindNextMatchMenu_Click(sender As Object, e As EventArgs) Handles FindNextMatchMenu.Click
      Try
         FindText(FindNext:=True)
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to request the user to specify a search text.
   Private Sub FindTextMenu_Click(sender As Object, e As EventArgs) Handles FindTextMenu.Click
      Try
         FindText(FindNext:=False)
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure flashes the selected window.
   Private Sub FlashWindowMenu_Click(sender As Object, e As EventArgs) Handles FlashWindowMenu.Click
      Try
         Dim ParentH As New IntPtr
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)

         If RefersToWindow(WindowH) Then
            Do
               CheckForError(EnableWindow(WindowH, True))
               CheckForError(ShowWindow(WindowH, SW_SHOWNA))
               CheckForError(BringWindowToTop(WindowH))
               If CBool(CheckForError(IsIconic(WindowH))) Then CheckForError(ShowWindow(WindowH, SW_RESTORE))

               ParentH = DirectCast(CheckForError(GetParent(WindowH)), IntPtr)
               If ParentH = IntPtr.Zero Then Exit Do
               WindowH = ParentH
            Loop

            Cursor = Cursors.WaitCursor
            WindowH = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)
            CheckForError(ShowWindow(WindowH, SW_SHOWNA))
            For Flash As Integer = 0 To 9
               CheckForError(ShowWindow(WindowH, SW_HIDE))
               My.Application.DoEvents()
               Sleep(250)
               CheckForError(ShowWindow(WindowH, SW_SHOWNA))
               My.Application.DoEvents()
               Sleep(250)
            Next Flash

            UpdateSearchResults()
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   'This procedure displays the selected window's base class information.
   Private Sub GetBaseClassInformationMenu_Click(sender As Object, e As EventArgs) Handles GetBaseClassInformationMenu.Click
      Try
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)

         If RefersToWindow(WindowH) Then
            MessageBox.Show($"Base class: {GetWindowBaseClass(WindowH)}.", $"{My.Application.Info.Title} - {WindowH}", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure displays the selected window's process information.
   Private Sub GetProcessInformationMenu_Click(sender As Object, e As EventArgs) Handles GetProcessInformationMenu.Click
      Try
         Dim Message As New StringBuilder
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)
         Dim WindowProcess As New WindowProcessStr

         If RefersToWindow(WindowH) Then
            WindowProcess = GetWindowProcess(WindowH)

            With WindowProcess
               Message.Append($"Process: { .ProcessH} - { .ProcessPath}{NewLine}")
               Message.Append($"Process id: { .ProcessId}{NewLine}")
               Message.Append($"Thread id: { .ThreadId}{NewLine}")
               Message.Append($"Module: { .ModuleH} - { .ModulePath}")
            End With

            MessageBox.Show(Message.ToString(), $"{My.Application.Info.Title} - {WindowH}", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to open this program's help file.
   Private Sub HelpMenu_Click(sender As Object, e As EventArgs) Handles HelpMenu.Click
      Try
         Dim HelpPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Winscan.hta")
         Dim HelpProcess As New Process

         If Not File.Exists(HelpPath) Then
            MessageBox.Show("Could not find the help file.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            HelpProcess.StartInfo.FileName = HelpPath
            HelpProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
            HelpProcess.Start()
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure displays information about this program.
   Private Sub InformationMenu_Click(sender As Object, e As EventArgs) Handles InformationMenu.Click
      Try
         MessageBox.Show(My.Application.Info.Description, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure is called when this window is closed.
   Private Sub InterfaceWindow_FormClosing(sender As Object, e As EventArgs) Handles Me.FormClosing
      Try
         Process.LeaveDebugMode()
      Catch ExceptionO As Exception
         If Not ExceptionO.GetType().Name = "Win32Exception" Then DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to scan for active windows.
   Private Sub InterfaceWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
      Try
         SearchForWindows()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure closes this window.
   Private Sub QuitMenu_Click(sender As Object, e As EventArgs) Handles QuitMenu.Click
      Try
         Me.Close()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to start searching for any active windows that meet the specified search criteria.
   Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
      Try
         CheckForError(ResetSuppression:=True)
         SearchForWindows()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure displays the action menu for the selected window when the user double clicks the search results.
   Private Sub SearchResultsTable_DoubleClick(sender As Object, e As EventArgs) Handles SearchResultsTable.DoubleClick
      Try
         WindowContextMenu.Show(Cursor.Position)
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to update the action menu when a window is selected.
   Private Sub SearchResultsTable_Enter(sender As Object, e As EventArgs) Handles SearchResultsTable.CellEnter
      Try
         UpdateMenus()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure adjust the search result table's columns to its new size.
   Private Sub SearchResultsTable_Resize(sender As Object, e As EventArgs) Handles SearchResultsTable.Resize
      Try
         For Each Column As DataGridViewColumn In SearchResultsTable.Columns
            Column.Width = CInt(SearchResultsTable.Width / 4.1)
         Next Column
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure shows or hides the selected window.
   Private Sub ShowHideWindowMenu_Click(sender As Object, e As EventArgs) Handles ShowHideWindowMenu.Click
      Try
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)

         If RefersToWindow(WindowH) Then
            CheckForError(ShowWindow(WindowH, If(CBool(CheckForError(IsWindowVisible(WindowH))), SW_HIDE, SW_SHOWNA)))

            RefreshWindow(WindowH)
            UpdateSearchResults()
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure handles the window menu's events.
   Private Sub WindowMainMenuItem_Click(sender As Object, e As EventArgs) Handles WindowMainMenu.Click
      Try
         Dim Item As New ToolStripMenuItem
         Dim SubItem As New ToolStripMenuItem

         For Index As Integer = 0 To WindowContextMenu.Items.Count - 1
            If TypeOf WindowContextMenu.Items(Index) IsNot ToolStripSeparator Then
               Item = DirectCast(WindowContextMenu.Items(Index), ToolStripMenuItem)
               If Item.HasDropDownItems Then
                  For SubIndex As Integer = 0 To Item.DropDownItems.Count - 1
                     If TypeOf Item.DropDownItems(SubIndex) IsNot ToolStripSeparator Then
                        SubItem = DirectCast(Item.DropDownItems(SubIndex), ToolStripMenuItem)
                        If SubItem.Text = DirectCast(sender, ToolStripMenuItem).Text Then SubItem.PerformClick()
                     End If
                  Next SubIndex
               ElseIf Item.Text = DirectCast(sender, ToolStripMenuItem).Text Then
                  Item.PerformClick()
               End If
            End If
         Next Index
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure builds specific parts of the interface.
   Private Sub BuildInterface()
      Try
         Dim Item As ToolStripItem = Nothing
         Dim Items(WindowContextMenu.Items.Count - 1) As ToolStripItem
         Dim SubItem As ToolStripItem = Nothing
         Dim SubItems() As ToolStripItem = Nothing

         For Each Item In ExcludeMainMenu.DropDownItems
            RemoveHandler Item.Click, AddressOf ExcludeMenu_Click
            AddHandler Item.Click, AddressOf ExcludeMenu_Click
         Next Item

         For Index As Integer = Items.GetLowerBound(0) To Items.GetUpperBound(0)
            Item = WindowContextMenu.Items(Index)
            If TypeOf Item Is ToolStripMenuItem Then
               Items(Index) = New ToolStripMenuItem(Item.Text)
               DirectCast(Items(Index), ToolStripMenuItem).ShortcutKeys = DirectCast(Item, ToolStripMenuItem).ShortcutKeys
               AddHandler Items(Index).Click, AddressOf WindowMainMenuItem_Click

               If DirectCast(Item, ToolStripMenuItem).HasDropDownItems Then
                  ReDim SubItems(DirectCast(Item, ToolStripMenuItem).DropDownItems.Count - 1)
                  For SubIndex As Integer = SubItems.GetLowerBound(0) To SubItems.GetUpperBound(0)
                     SubItem = DirectCast(Item, ToolStripMenuItem).DropDownItems(SubIndex)
                     If TypeOf SubItem Is ToolStripMenuItem Then
                        SubItems(SubIndex) = New ToolStripMenuItem(SubItem.Text)
                        DirectCast(SubItems(SubIndex), ToolStripMenuItem).ShortcutKeys = DirectCast(SubItem, ToolStripMenuItem).ShortcutKeys
                        AddHandler SubItems(SubIndex).Click, AddressOf WindowMainMenuItem_Click
                     ElseIf TypeOf SubItem Is ToolStripSeparator Then
                        SubItems(SubIndex) = New ToolStripSeparator
                     End If
                  Next SubIndex

                  DirectCast(Items(Index), ToolStripMenuItem).DropDownItems.Clear()
                  DirectCast(Items(Index), ToolStripMenuItem).DropDownItems.AddRange(SubItems)
               End If
            ElseIf TypeOf Item Is ToolStripSeparator Then
               Items(Index) = New ToolStripSeparator
            End If
         Next Index

         WindowMainMenu.DropDownItems.Clear()
         WindowMainMenu.DropDownItems.AddRange(Items)
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure maximizes, minimizes, or restores the selected window.
   Private Sub ChangeState(NewState As UInteger)
      Try
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)

         If RefersToWindow(WindowH) Then
            CheckForError(ShowWindow(WindowH, NewState))
            RefreshWindow(WindowH)
            UpdateSearchResults()
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If

      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure changes the selected window's z-order.
   Private Sub ChangeZorder(NewZOrder As UInteger)
      Try
         Dim Dimensions As New RECT
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)

         If RefersToWindow(WindowH) Then
            CheckForError(GetWindowRect(WindowH, Dimensions))

            With Dimensions
               CheckForError(SetWindowPos(WindowH, NewZOrder, Nothing, Nothing, .Right - .Left, .Bottom - .Top, SWP_DRAWFRAME Or SWP_NOACTIVATE Or SWP_NOMOVE Or SWP_SHOWWINDOW))
            End With

            RefreshWindow(WindowH)
            UpdateSearchResults()
         Else
            FormatSearchResult(SearchResultsTable.CurrentRow.Index)
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure searches the search results for the specified text.
   Private Sub FindInSearchResults(SearchText As String, FindNext As Boolean, ByRef FoundColumn? As Integer, ByRef FoundRow? As Integer)
      Try
         Dim Matched As Boolean = False
         Dim StartColumn As New Integer

         Cursor = Cursors.WaitCursor
         With SearchResultsTable
            .Focus()
            FoundColumn = Nothing
            FoundRow = Nothing
            StartColumn = If(FindNext, .CurrentCell.ColumnIndex + 1, .CurrentCell.ColumnIndex)

            For Row As Integer = .CurrentRow.Index To .RowCount - 1
               For Column As Integer = StartColumn To .ColumnCount - 1
                  If .Rows(Row).Cells(Column).Value IsNot Nothing Then
                     Select Case .Rows(Row).Cells(Column).Value.GetType
                        Case GetType(IntPtr)
                           Matched = Match(CStr(DirectCast(.Rows(Row).Cells(Column).Value, IntPtr)), SearchText.ToUpper)
                        Case Else
                           Matched = Match(CStr(.Rows(Row).Cells(Column).Value).ToUpper, SearchText.ToUpper)
                     End Select
                  End If

                  If Matched Then
                     FoundColumn = Column
                     FoundRow = Row
                     .CurrentCell = .Rows(Row).Cells(Column)
                     Cursor = Cursors.Default
                     Exit For
                  End If
               Next Column
               If Matched Then Exit For
               StartColumn = 0
            Next Row
         End With
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   'This procedure gives the command to search the search results for the specified text.
   Private Sub FindText(FindNext As Boolean)
      Try
         Dim FoundColumn? As Integer = Nothing
         Dim FoundRow? As Integer = Nothing
         Dim NewSearchText As String = Nothing
         Static SearchText As String = Nothing

         If (SearchText = Nothing) OrElse (Not FindNext) Then
            NewSearchText = ShowInputDialog("Find:", SearchText)
            If Not NewSearchText = Nothing Then SearchText = NewSearchText
         End If

         If Not SearchText = Nothing Then
            FindInSearchResults(SearchText, FindNext, FoundColumn, FoundRow)
            If FoundColumn Is Nothing AndAlso FoundRow Is Nothing Then
               If MessageBox.Show($"Could not find ""{SearchText}"".{NewLine}Search again from start?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                  With SearchResultsTable
                     If .RowCount > 0 Then .CurrentCell = .Rows(0).Cells(0)
                  End With
                  FindInSearchResults(SearchText, FindNext, FoundColumn, FoundRow)
                  If FoundColumn Is Nothing AndAlso FoundRow Is Nothing Then MessageBox.Show($"Could not find ""{SearchText}.""", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            End If
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure formats the specified search result.
   Private Sub FormatSearchResult(Row As Integer)
      Try
         Dim ParentH As IntPtr = DirectCast(SearchResultsTable.Rows(Row).Cells("WindowParentColumn").Value, IntPtr)
         Dim WindowH As IntPtr = DirectCast(SearchResultsTable.Rows(Row).Cells("WindowHandleColumn").Value, IntPtr)

         With SearchResultsTable.Rows(Row)
            .Cells("WindowParentColumn").Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Height = 17
            If Not ParentH = IntPtr.Zero Then .Cells("WindowHandleColumn").Style.Alignment = DataGridViewContentAlignment.MiddleRight

            If CBool(CheckForError(IsWindow(WindowH))) Then
               .DefaultCellStyle.BackColor = If(WindowHasStyle(WindowH, WS_POPUP), Color.Cyan, Color.White)
               .DefaultCellStyle.ForeColor = If(CBool(CheckForError(IsWindowEnabled(WindowH))), Color.Black, Color.Red)
               .DefaultCellStyle.Font = New Font(SearchResultsTable.Font, If(CBool(CheckForError(IsWindowVisible(WindowH))), SearchResultsTable.Font.Style Or FontStyle.Bold, SearchResultsTable.Font.Style Or FontStyle.Regular))
               If WindowHasStyle(WindowH, ES_PASSWORD) Then .DefaultCellStyle.Font = New Font(SearchResultsTable.Font, SearchResultsTable.Font.Style Or FontStyle.Italic)
               If CBool(CheckForError(IsHungAppWindow(WindowH))) Then .DefaultCellStyle.Font = New Font(SearchResultsTable.Font, SearchResultsTable.Font.Style Or FontStyle.Underline)
            ElseIf Not CBool(CheckForError(IsWindow(WindowH))) Then
               .DefaultCellStyle.BackColor = Color.White
               .DefaultCellStyle.ForeColor = Color.Yellow
               .DefaultCellStyle.Font = New Font(SearchResultsTable.Font, SearchResultsTable.Font.Style Or FontStyle.Bold)
            End If
         End With
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure checks whether the specified window has an excluded property and returns the result.
   Private Function IsExcluded(WindowH As IntPtr) As Boolean
      Try
         Dim Excluded As Boolean = False
         Dim Exclusion As ExcludableE = ExcludableE.ExcludeNone
         Dim Item As New ToolStripMenuItem

         For Exclusion = 0 To DirectCast(ExcludeMainMenu.DropDownItems.Count - 1, ExcludableE)
            Item = DirectCast(ExcludeMainMenu.DropDownItems.Item(Exclusion), ToolStripMenuItem)
            If Item.Checked Then
               Select Case Exclusion
                  Case ExcludableE.ExcludeChild
                     Excluded = (Not DirectCast(CheckForError(GetParent(WindowH)), IntPtr) = IntPtr.Zero)
                  Case ExcludableE.ExcludeParent
                     Excluded = (DirectCast(CheckForError(GetParent(WindowH)), IntPtr) = IntPtr.Zero)
                  Case ExcludableE.ExcludeDisabled
                     Excluded = Not CBool(CheckForError(IsWindowEnabled(WindowH)))
                  Case ExcludableE.ExcludeEnabled
                     Excluded = CBool(CheckForError(IsWindowEnabled(WindowH)))
                  Case ExcludableE.ExcludeHidden
                     Excluded = Not CBool(CheckForError(IsWindowVisible(WindowH)))
                  Case ExcludableE.ExcludeVisible
                     Excluded = CBool(CheckForError(IsWindowVisible(WindowH)))
                  Case ExcludableE.ExcludeNonGroup
                     Excluded = Not WindowHasStyle(WindowH, WS_GROUP)
                  Case ExcludableE.ExcludeGroup
                     Excluded = WindowHasStyle(WindowH, WS_GROUP)
                  Case ExcludableE.ExcludeNonPopup
                     Excluded = Not WindowHasStyle(WindowH, WS_POPUP)
                  Case ExcludableE.ExcludePopup
                     Excluded = WindowHasStyle(WindowH, WS_POPUP)
                  Case ExcludableE.ExcludeNonTabStop
                     Excluded = Not WindowHasStyle(WindowH, WS_TABSTOP)
                  Case ExcludableE.ExcludeTabStop
                     Excluded = WindowHasStyle(WindowH, WS_TABSTOP)
                  Case ExcludableE.ExcludeNonUnicode
                     Excluded = Not CBool(CheckForError(IsWindowUnicode(WindowH)))
                  Case ExcludableE.ExcludeUnicode
                     Excluded = CBool(CheckForError(IsWindowUnicode(WindowH)))
               End Select
            End If
            If Excluded Then Exit For
         Next Exclusion

         Return Excluded
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure checks whether the specified texts match using the options selected by the user and returns the result.
   Private Function Match(CompareText As String, SearchText As String) As Boolean
      Try
         If CompareText Is Nothing Then CompareText = String.Empty
         If SearchText Is Nothing Then SearchText = String.Empty

         If Not CaseSensitiveBox.Checked Then
            CompareText = CompareText.ToUpper()
            SearchText = SearchText.ToUpper()
         End If

         If IgnoreAmpersandsBox.Checked Then
            CompareText = CompareText.Replace("&"c, String.Empty)
            SearchText = SearchText.Replace("&"c, String.Empty)
            If CompareText.StartsWith("SWI") Then
               Diagnostics.Debug.WriteLine($"CompareText: ""{CompareText}"", SearchText: ""{SearchText}""{NewLine}")
            End If
         End If

         If SearchText = Nothing Then
            Return True
         ElseIf Not SearchText = Nothing Then
            Return If(WholePhrasesOnlyBox.Checked, (SearchText = CompareText), CompareText.Contains(SearchText))
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return False
   End Function

   'This procedure refreshes the specified window and any parent windows.
   Private Sub RefreshWindow(WindowH As IntPtr)
      Try
         Do
            CheckForError(UpdateWindow(WindowH))
            WindowH = DirectCast(CheckForError(GetParent(WindowH)), IntPtr)
            My.Application.DoEvents()
         Loop Until WindowH = IntPtr.Zero
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure fills the specified table with a list of active windows contained by the current desktop.
   Private Sub SearchForWindows()
      Try
         Dim ParentH As New IntPtr
         Dim WindowClass As String = Nothing
         Dim WindowParent As New IntPtr
         Dim WindowText As String = Nothing

         WindowHs.Clear()
         WindowHs.Add(DirectCast(CheckForError(GetDesktopWindow()), IntPtr))
         CheckForError(EnumWindows(AddressOf HandleWindow, IntPtr.Zero))

         SearchResultsTable.Rows.Clear()
         For Each WindowH As IntPtr In WindowHs
            If LookForParentWindowsBox.Checked Then
               WindowParent = WindowH
               Do Until (Match(GetWindowClass(WindowParent), WindowClassBox.Text) AndAlso Match(GetWindowText(WindowParent), WindowTextBox.Text)) OrElse (DirectCast(CheckForError(GetParent(WindowParent)), IntPtr) = IntPtr.Zero)
                  WindowParent = DirectCast(CheckForError(GetParent(WindowParent)), IntPtr)
               Loop
            End If

            WindowClass = If(LookForParentWindowsBox.Checked, GetWindowClass(WindowParent), GetWindowClass(WindowH))
            WindowText = If(LookForParentWindowsBox.Checked, GetWindowText(WindowParent), GetWindowText(WindowH))

            ParentH = DirectCast(CheckForError(GetParent(WindowH)), IntPtr)

            If Not IsExcluded(WindowH) Then
               If Match(WindowText, WindowTextBox.Text) AndAlso Match(WindowClass, WindowClassBox.Text) Then
                  SearchResultsTable.Rows.Add(WindowH, GetWindowText(WindowH), GetWindowClass(WindowH), ParentH)
                  FormatSearchResult(SearchResultsTable.Rows.Count - 1)
               End If
            End If
         Next WindowH

         UpdateMenus()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure updates the action menu.
   Private Sub UpdateMenus()
      Try
         Dim WindowH As New IntPtr

         With SearchResultsTable
            If .RowCount > 0 Then
               WindowH = DirectCast(SearchResultsTable.CurrentRow.Cells("WindowHandleColumn").Value, IntPtr)

               SearchResultsMainMenu.Enabled = (.CurrentRow.Index >= 0)
               WindowContextMenu.Enabled = (.CurrentRow.Index >= 0)
               WindowMainMenu.Enabled = (.CurrentRow.Index >= 0)

               If .CurrentRow.Index >= 0 Then
                  EnableDisableWindowMenu.Text = $"{If(CBool(CheckForError(IsWindowEnabled(WindowH))), "&Disable", "&Enable")} window."
                  ShowHideWindowMenu.Text = $"{If(CBool(CheckForError(IsWindowVisible(WindowH))), "&Hide", "Sh&ow")} window."
               End If
            Else
               SearchResultsMainMenu.Enabled = False
               WindowContextMenu.Enabled = False
               WindowMainMenu.Enabled = False
            End If
         End With

         BuildInterface()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure updates the search results.
   Private Sub UpdateSearchResults()
      Try
         Dim WindowH As New IntPtr

         Cursor = Cursors.WaitCursor
         With SearchResultsTable
            For Row As Integer = 0 To .RowCount - 1
               WindowH = DirectCast(.Rows(Row).Cells("WindowHandleColumn").Value, IntPtr)
               If CBool(CheckForError(IsWindow(WindowH))) Then
                  SearchResultsTable.Rows(Row).SetValues(WindowH, GetWindowText(WindowH), GetWindowClass(WindowH), DirectCast(CheckForError(GetParent(WindowH)), IntPtr))
               End If
               FormatSearchResult(SearchResultsTable.Rows(Row).Index)
            Next Row
         End With

         UpdateMenus()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub
End Class

