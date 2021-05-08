<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterfaceWindow
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterfaceWindow))
      Me.SearchResultsTable = New System.Windows.Forms.DataGridView()
      Me.WindowHandleColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.WindowTextColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.WindowClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.WindowParentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TextLabel = New System.Windows.Forms.Label()
      Me.WindowTextBox = New System.Windows.Forms.TextBox()
      Me.SearchButton = New System.Windows.Forms.Button()
      Me.WindowClassBox = New System.Windows.Forms.TextBox()
      Me.ClassLabel = New System.Windows.Forms.Label()
      Me.CaseSensitiveBox = New System.Windows.Forms.CheckBox()
      Me.LookForParentWindowsBox = New System.Windows.Forms.CheckBox()
      Me.WholePhrasesOnlyBox = New System.Windows.Forms.CheckBox()
      Me.IgnoreAmpersandsBox = New System.Windows.Forms.CheckBox()
      Me.MenuBar = New System.Windows.Forms.MenuStrip()
      Me.ProgramMainMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.InformationMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ProgramSeparator1Menu = New System.Windows.Forms.ToolStripSeparator()
      Me.QuitMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.SearchResultsMainMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.CopyMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.FindNextMatchMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.FindTextMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.WindowMainMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ExcludeMainMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ChildWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ParentWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.DisabledWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.EnabledWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.HiddenWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.VisibleWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.NongroupWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.GroupWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.NonpopupWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.PopupWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.NontabstopWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.TabstopWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.NonunicodeWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.UnicodeWindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.GetProcessInformationMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.WindowContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.CloseWindowMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.EnableDisableWindowMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ShowHideWindowMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.WindowSeparator1Menu = New System.Windows.Forms.ToolStripSeparator()
      Me.ChangePositionDimensionsMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ChangeParentMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ChangeStateMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.MaximizeMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.MinimizeMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.RestoreMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ChangeTextMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ChangeZOrderMainMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.BottomMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.MiddleMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.TopMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.PermanentlyOnTopMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.FlashWindowMenu = New System.Windows.Forms.ToolStripMenuItem()
      Me.WindowSeparator2Menu = New System.Windows.Forms.ToolStripSeparator()
        Me.GetBaseClassInformationMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SearchResultsTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuBar.SuspendLayout()
        Me.WindowContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'SearchResultsTable
        '
        Me.SearchResultsTable.AllowUserToAddRows = False
        Me.SearchResultsTable.AllowUserToDeleteRows = False
        Me.SearchResultsTable.AllowUserToResizeRows = False
        Me.SearchResultsTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchResultsTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.SearchResultsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.SearchResultsTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WindowHandleColumn, Me.WindowTextColumn, Me.WindowClassColumn, Me.WindowParentColumn})
        Me.SearchResultsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.SearchResultsTable.Location = New System.Drawing.Point(12, 163)
        Me.SearchResultsTable.MultiSelect = False
        Me.SearchResultsTable.Name = "SearchResultsTable"
        Me.SearchResultsTable.ReadOnly = True
        Me.SearchResultsTable.RowHeadersVisible = False
        Me.SearchResultsTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.SearchResultsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.SearchResultsTable.ShowCellToolTips = False
        Me.SearchResultsTable.Size = New System.Drawing.Size(280, 137)
        Me.SearchResultsTable.TabIndex = 7
        Me.ToolTip.SetToolTip(Me.SearchResultsTable, "Double click to perform an action on the selected search result.")
        '
        'WindowHandleColumn
        '
        Me.WindowHandleColumn.HeaderText = "Handle:"
        Me.WindowHandleColumn.Name = "WindowHandleColumn"
        Me.WindowHandleColumn.ReadOnly = True
        Me.WindowHandleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'WindowTextColumn
        '
        Me.WindowTextColumn.HeaderText = "Text:"
        Me.WindowTextColumn.Name = "WindowTextColumn"
        Me.WindowTextColumn.ReadOnly = True
        Me.WindowTextColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'WindowClassColumn
        '
        Me.WindowClassColumn.HeaderText = "Class:"
        Me.WindowClassColumn.Name = "WindowClassColumn"
        Me.WindowClassColumn.ReadOnly = True
        Me.WindowClassColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'WindowParentColumn
        '
        Me.WindowParentColumn.HeaderText = "Parent:"
        Me.WindowParentColumn.Name = "WindowParentColumn"
        Me.WindowParentColumn.ReadOnly = True
        Me.WindowParentColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TextLabel
        '
        Me.TextLabel.AutoSize = True
        Me.TextLabel.Location = New System.Drawing.Point(12, 36)
        Me.TextLabel.Name = "TextLabel"
        Me.TextLabel.Size = New System.Drawing.Size(31, 13)
        Me.TextLabel.TabIndex = 1
        Me.TextLabel.Text = "Text:"
        '
        'WindowTextBox
        '
        Me.WindowTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WindowTextBox.Location = New System.Drawing.Point(49, 36)
        Me.WindowTextBox.Name = "WindowTextBox"
        Me.WindowTextBox.Size = New System.Drawing.Size(243, 20)
        Me.WindowTextBox.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.WindowTextBox, "Enter the text to look for in windows in this field.")
        '
        'SearchButton
        '
        Me.SearchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchButton.Location = New System.Drawing.Point(219, 134)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 23)
        Me.SearchButton.TabIndex = 6
        Me.SearchButton.Text = "&Search"
        Me.ToolTip.SetToolTip(Me.SearchButton, "Starts looking for windows matching the specified search text and/or class.")
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'WindowClassBox
        '
        Me.WindowClassBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WindowClassBox.Location = New System.Drawing.Point(49, 62)
        Me.WindowClassBox.Name = "WindowClassBox"
        Me.WindowClassBox.Size = New System.Drawing.Size(243, 20)
        Me.WindowClassBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.WindowClassBox, "Enter the class of windows to look for in this field.")
        '
        'ClassLabel
        '
        Me.ClassLabel.AutoSize = True
        Me.ClassLabel.Location = New System.Drawing.Point(12, 62)
        Me.ClassLabel.Name = "ClassLabel"
        Me.ClassLabel.Size = New System.Drawing.Size(35, 13)
        Me.ClassLabel.TabIndex = 4
        Me.ClassLabel.Text = "Class:"
        '
        'CaseSensitiveBox
        '
        Me.CaseSensitiveBox.AutoSize = True
        Me.CaseSensitiveBox.Location = New System.Drawing.Point(15, 88)
        Me.CaseSensitiveBox.Name = "CaseSensitiveBox"
        Me.CaseSensitiveBox.Size = New System.Drawing.Size(97, 17)
        Me.CaseSensitiveBox.TabIndex = 2
        Me.CaseSensitiveBox.Text = "&Case sensitive."
        Me.ToolTip.SetToolTip(Me.CaseSensitiveBox, "The case of the text and/or class names must match the specified search text and/" &
        "or class name.")
        Me.CaseSensitiveBox.UseVisualStyleBackColor = True
        '
        'LookForParentWindowsBox
        '
        Me.LookForParentWindowsBox.AutoSize = True
        Me.LookForParentWindowsBox.Location = New System.Drawing.Point(15, 111)
        Me.LookForParentWindowsBox.Name = "LookForParentWindowsBox"
        Me.LookForParentWindowsBox.Size = New System.Drawing.Size(145, 17)
        Me.LookForParentWindowsBox.TabIndex = 3
        Me.LookForParentWindowsBox.Text = "&Look for parent windows."
        Me.ToolTip.SetToolTip(Me.LookForParentWindowsBox, "Also lists any child windows belonging to the windows matching the specified sear" &
        "ch criteria.")
        Me.LookForParentWindowsBox.UseVisualStyleBackColor = True
        '
        'WholePhrasesOnlyBox
        '
        Me.WholePhrasesOnlyBox.AutoSize = True
        Me.WholePhrasesOnlyBox.Location = New System.Drawing.Point(175, 88)
        Me.WholePhrasesOnlyBox.Name = "WholePhrasesOnlyBox"
        Me.WholePhrasesOnlyBox.Size = New System.Drawing.Size(122, 17)
        Me.WholePhrasesOnlyBox.TabIndex = 4
        Me.WholePhrasesOnlyBox.Text = "&Whole phrases only."
        Me.ToolTip.SetToolTip(Me.WholePhrasesOnlyBox, "The entire text and/or class name must match the specified text and/or class name" &
        ".")
        Me.WholePhrasesOnlyBox.UseVisualStyleBackColor = True
        '
        'IgnoreAmpersandsBox
        '
        Me.IgnoreAmpersandsBox.AutoSize = True
        Me.IgnoreAmpersandsBox.Location = New System.Drawing.Point(175, 111)
        Me.IgnoreAmpersandsBox.Name = "IgnoreAmpersandsBox"
        Me.IgnoreAmpersandsBox.Size = New System.Drawing.Size(119, 17)
        Me.IgnoreAmpersandsBox.TabIndex = 5
        Me.IgnoreAmpersandsBox.Text = "&Ignore ampersands."
        Me.ToolTip.SetToolTip(Me.IgnoreAmpersandsBox, "Some window classes do not display (all) ampersands in their text.")
        Me.IgnoreAmpersandsBox.UseVisualStyleBackColor = True
        '
        'MenuBar
        '
        Me.MenuBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramMainMenu, Me.SearchResultsMainMenu, Me.WindowMainMenu, Me.ExcludeMainMenu})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(304, 24)
        Me.MenuBar.TabIndex = 8
        '
        'ProgramMainMenu
        '
        Me.ProgramMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpMenu, Me.InformationMenu, Me.ProgramSeparator1Menu, Me.QuitMenu})
        Me.ProgramMainMenu.Name = "ProgramMainMenu"
        Me.ProgramMainMenu.Size = New System.Drawing.Size(58, 20)
        Me.ProgramMainMenu.Text = "&Program"
        '
        'HelpMenu
        '
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.ShortcutKeyDisplayString = ""
        Me.HelpMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HelpMenu.Size = New System.Drawing.Size(159, 22)
        Me.HelpMenu.Text = "&Help"
        '
        'InformationMenu
        '
        Me.InformationMenu.Name = "InformationMenu"
        Me.InformationMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.InformationMenu.Size = New System.Drawing.Size(159, 22)
        Me.InformationMenu.Text = "&Information"
        '
        'ProgramSeparator1Menu
        '
        Me.ProgramSeparator1Menu.Name = "ProgramSeparator1Menu"
        Me.ProgramSeparator1Menu.Size = New System.Drawing.Size(156, 6)
        '
        'QuitMenu
        '
        Me.QuitMenu.Name = "QuitMenu"
        Me.QuitMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.QuitMenu.Size = New System.Drawing.Size(159, 22)
        Me.QuitMenu.Text = "&Quit"
        '
        'SearchResultsMainMenu
        '
        Me.SearchResultsMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyMenu, Me.FindNextMatchMenu, Me.FindTextMenu})
        Me.SearchResultsMainMenu.Name = "SearchResultsMainMenu"
        Me.SearchResultsMainMenu.ShortcutKeyDisplayString = ""
        Me.SearchResultsMainMenu.Size = New System.Drawing.Size(86, 20)
        Me.SearchResultsMainMenu.Text = "S&earch-results"
        '
        'CopyMenu
        '
        Me.CopyMenu.Name = "CopyMenu"
        Me.CopyMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyMenu.Size = New System.Drawing.Size(171, 22)
        Me.CopyMenu.Text = "&Copy."
        '
        'FindNextMatchMenu
        '
        Me.FindNextMatchMenu.Name = "FindNextMatchMenu"
        Me.FindNextMatchMenu.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.FindNextMatchMenu.Size = New System.Drawing.Size(171, 22)
        Me.FindNextMatchMenu.Text = "Find &next match."
        '
        'FindTextMenu
        '
        Me.FindTextMenu.Name = "FindTextMenu"
        Me.FindTextMenu.ShortcutKeyDisplayString = ""
        Me.FindTextMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FindTextMenu.Size = New System.Drawing.Size(171, 22)
        Me.FindTextMenu.Text = "&Find text."
        '
        'WindowMainMenu
        '
        Me.WindowMainMenu.Name = "WindowMainMenu"
        Me.WindowMainMenu.Size = New System.Drawing.Size(58, 20)
        Me.WindowMainMenu.Text = "&Window"
        '
        'ExcludeMainMenu
        '
        Me.ExcludeMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChildWindowsMenu, Me.ParentWindowsMenu, Me.DisabledWindowsMenu, Me.EnabledWindowsMenu, Me.HiddenWindowsMenu, Me.VisibleWindowsMenu, Me.NongroupWindowsMenu, Me.GroupWindowsMenu, Me.NonpopupWindowsMenu, Me.PopupWindowsMenu, Me.NontabstopWindowsMenu, Me.TabstopWindowsMenu, Me.NonunicodeWindowsMenu, Me.UnicodeWindowsMenu})
        Me.ExcludeMainMenu.Name = "ExcludeMainMenu"
        Me.ExcludeMainMenu.Size = New System.Drawing.Size(57, 20)
        Me.ExcludeMainMenu.Text = "E&xclude"
        '
        'ChildWindowsMenu
        '
        Me.ChildWindowsMenu.Name = "ChildWindowsMenu"
        Me.ChildWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.ChildWindowsMenu.Text = "&Child windows."
        '
        'ParentWindowsMenu
        '
        Me.ParentWindowsMenu.Name = "ParentWindowsMenu"
        Me.ParentWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.ParentWindowsMenu.Text = "&Parent windows."
        '
        'DisabledWindowsMenu
        '
        Me.DisabledWindowsMenu.Name = "DisabledWindowsMenu"
        Me.DisabledWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.DisabledWindowsMenu.Text = "&Disabled windows."
        '
        'EnabledWindowsMenu
        '
        Me.EnabledWindowsMenu.Name = "EnabledWindowsMenu"
        Me.EnabledWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.EnabledWindowsMenu.Text = "&Enabled windows."
        '
        'HiddenWindowsMenu
        '
        Me.HiddenWindowsMenu.Name = "HiddenWindowsMenu"
        Me.HiddenWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.HiddenWindowsMenu.Text = "&Hidden windows."
        '
        'VisibleWindowsMenu
        '
        Me.VisibleWindowsMenu.Name = "VisibleWindowsMenu"
        Me.VisibleWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.VisibleWindowsMenu.Text = "&Visible windows."
        '
        'NongroupWindowsMenu
        '
        Me.NongroupWindowsMenu.Name = "NongroupWindowsMenu"
        Me.NongroupWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.NongroupWindowsMenu.Text = "&Non-group windows."
        '
        'GroupWindowsMenu
        '
        Me.GroupWindowsMenu.Name = "GroupWindowsMenu"
        Me.GroupWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.GroupWindowsMenu.Text = "&Group windows."
        '
        'NonpopupWindowsMenu
        '
        Me.NonpopupWindowsMenu.Name = "NonpopupWindowsMenu"
        Me.NonpopupWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.NonpopupWindowsMenu.Text = "&Non-popup windows."
        '
        'PopupWindowsMenu
        '
        Me.PopupWindowsMenu.Name = "PopupWindowsMenu"
        Me.PopupWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.PopupWindowsMenu.Text = "&Popup windows."
        '
        'NontabstopWindowsMenu
        '
        Me.NontabstopWindowsMenu.Name = "NontabstopWindowsMenu"
        Me.NontabstopWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.NontabstopWindowsMenu.Text = "&Non-tabstop windows."
        '
        'TabstopWindowsMenu
        '
        Me.TabstopWindowsMenu.Name = "TabstopWindowsMenu"
        Me.TabstopWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.TabstopWindowsMenu.Text = "&Tabstop windows."
        '
        'NonunicodeWindowsMenu
        '
        Me.NonunicodeWindowsMenu.Name = "NonunicodeWindowsMenu"
        Me.NonunicodeWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.NonunicodeWindowsMenu.Text = "&Non-unicode windows."
        '
        'UnicodeWindowsMenu
        '
        Me.UnicodeWindowsMenu.Name = "UnicodeWindowsMenu"
        Me.UnicodeWindowsMenu.Size = New System.Drawing.Size(182, 22)
        Me.UnicodeWindowsMenu.Text = "&Unicode windows."
        '
        'GetProcessInformationMenu
        '
        Me.GetProcessInformationMenu.Name = "GetProcessInformationMenu"
        Me.GetProcessInformationMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.GetProcessInformationMenu.Size = New System.Drawing.Size(271, 22)
        Me.GetProcessInformationMenu.Text = "&Get Process Information"
        '
        'WindowContextMenu
        '
        Me.WindowContextMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.WindowContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseWindowMenu, Me.EnableDisableWindowMenu, Me.ShowHideWindowMenu, Me.WindowSeparator1Menu, Me.ChangePositionDimensionsMenu, Me.ChangeParentMenu, Me.ChangeStateMenu, Me.ChangeTextMenu, Me.ChangeZOrderMainMenu, Me.FlashWindowMenu, Me.WindowSeparator2Menu, Me.GetBaseClassInformationMenu, Me.GetProcessInformationMenu})
        Me.WindowContextMenu.Name = "WindowMainMenu"
        Me.WindowContextMenu.Size = New System.Drawing.Size(272, 280)
        '
        'CloseWindowMenu
        '
        Me.CloseWindowMenu.Name = "CloseWindowMenu"
        Me.CloseWindowMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.CloseWindowMenu.Size = New System.Drawing.Size(271, 22)
        Me.CloseWindowMenu.Text = "&Close window."
        '
        'EnableDisableWindowMenu
        '
        Me.EnableDisableWindowMenu.Name = "EnableDisableWindowMenu"
        Me.EnableDisableWindowMenu.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.EnableDisableWindowMenu.Size = New System.Drawing.Size(271, 22)
        '
        'ShowHideWindowMenu
        '
        Me.ShowHideWindowMenu.Name = "ShowHideWindowMenu"
        Me.ShowHideWindowMenu.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.ShowHideWindowMenu.Size = New System.Drawing.Size(271, 22)
        '
        'WindowSeparator1Menu
        '
        Me.WindowSeparator1Menu.Name = "WindowSeparator1Menu"
        Me.WindowSeparator1Menu.Size = New System.Drawing.Size(268, 6)
        '
        'ChangePositionDimensionsMenu
        '
        Me.ChangePositionDimensionsMenu.Name = "ChangePositionDimensionsMenu"
        Me.ChangePositionDimensionsMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ChangePositionDimensionsMenu.Size = New System.Drawing.Size(271, 22)
        Me.ChangePositionDimensionsMenu.Text = "Change &position/dimensions."
        '
        'ChangeParentMenu
        '
        Me.ChangeParentMenu.Name = "ChangeParentMenu"
        Me.ChangeParentMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.ChangeParentMenu.Size = New System.Drawing.Size(271, 22)
        Me.ChangeParentMenu.Text = "Change &parent."
        '
        'ChangeStateMenu
        '
        Me.ChangeStateMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaximizeMenu, Me.MinimizeMenu, Me.RestoreMenu})
        Me.ChangeStateMenu.Name = "ChangeStateMenu"
        Me.ChangeStateMenu.Size = New System.Drawing.Size(271, 22)
        Me.ChangeStateMenu.Text = "Change &state."
        '
        'MaximizeMenu
        '
        Me.MaximizeMenu.Name = "MaximizeMenu"
        Me.MaximizeMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.MaximizeMenu.Size = New System.Drawing.Size(173, 22)
        Me.MaximizeMenu.Text = "&Maximize."
        '
        'MinimizeMenu
        '
        Me.MinimizeMenu.Name = "MinimizeMenu"
        Me.MinimizeMenu.ShortcutKeyDisplayString = ""
        Me.MinimizeMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MinimizeMenu.Size = New System.Drawing.Size(173, 22)
        Me.MinimizeMenu.Text = "&Minimize."
        '
        'RestoreMenu
        '
        Me.RestoreMenu.Name = "RestoreMenu"
        Me.RestoreMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.RestoreMenu.Size = New System.Drawing.Size(173, 22)
        Me.RestoreMenu.Text = "&Restore."
        '
        'ChangeTextMenu
        '
        Me.ChangeTextMenu.Name = "ChangeTextMenu"
        Me.ChangeTextMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.ChangeTextMenu.Size = New System.Drawing.Size(271, 22)
        Me.ChangeTextMenu.Text = "Change &text."
        '
        'ChangeZOrderMainMenu
        '
        Me.ChangeZOrderMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BottomMenu, Me.MiddleMenu, Me.TopMenu, Me.PermanentlyOnTopMenu, Me.ToolStripSeparator1})
        Me.ChangeZOrderMainMenu.Name = "ChangeZOrderMainMenu"
        Me.ChangeZOrderMainMenu.Size = New System.Drawing.Size(271, 22)
        Me.ChangeZOrderMainMenu.Text = "Change &z-order."
        '
        'BottomMenu
        '
        Me.BottomMenu.Name = "BottomMenu"
        Me.BottomMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BottomMenu.Size = New System.Drawing.Size(227, 22)
        Me.BottomMenu.Text = "&Bottom."
        '
        'MiddleMenu
        '
        Me.MiddleMenu.Name = "MiddleMenu"
        Me.MiddleMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MiddleMenu.Size = New System.Drawing.Size(227, 22)
        Me.MiddleMenu.Text = "&Middle."
        '
        'TopMenu
        '
        Me.TopMenu.Name = "TopMenu"
        Me.TopMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.TopMenu.Size = New System.Drawing.Size(227, 22)
        Me.TopMenu.Text = "&Top."
        '
        'PermanentlyOnTopMenu
        '
        Me.PermanentlyOnTopMenu.Name = "PermanentlyOnTopMenu"
        Me.PermanentlyOnTopMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.PermanentlyOnTopMenu.Size = New System.Drawing.Size(227, 22)
        Me.PermanentlyOnTopMenu.Text = "&Permanently on top."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(224, 6)
        '
        'FlashWindowMenu
        '
        Me.FlashWindowMenu.Name = "FlashWindowMenu"
        Me.FlashWindowMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FlashWindowMenu.Size = New System.Drawing.Size(271, 22)
        Me.FlashWindowMenu.Text = "&Flash window."
        '
        'WindowSeparator2Menu
        '
        Me.WindowSeparator2Menu.Name = "WindowSeparator2Menu"
        Me.WindowSeparator2Menu.Size = New System.Drawing.Size(268, 6)
        '
        'GetBaseClassInformationMenu
        '
        Me.GetBaseClassInformationMenu.Name = "GetBaseClassInformationMenu"
        Me.GetBaseClassInformationMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.GetBaseClassInformationMenu.Size = New System.Drawing.Size(271, 22)
        Me.GetBaseClassInformationMenu.Text = "&Get Base Class Information"
        '
        'InterfaceWindow
        '
        Me.AcceptButton = Me.SearchButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 315)
        Me.Controls.Add(Me.MenuBar)
        Me.Controls.Add(Me.SearchResultsTable)
        Me.Controls.Add(Me.WindowClassBox)
        Me.Controls.Add(Me.IgnoreAmpersandsBox)
        Me.Controls.Add(Me.WholePhrasesOnlyBox)
        Me.Controls.Add(Me.ClassLabel)
        Me.Controls.Add(Me.LookForParentWindowsBox)
        Me.Controls.Add(Me.CaseSensitiveBox)
        Me.Controls.Add(Me.WindowTextBox)
        Me.Controls.Add(Me.TextLabel)
        Me.Controls.Add(Me.SearchButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuBar
        Me.Name = "InterfaceWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.SearchResultsTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.WindowContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SearchResultsTable As System.Windows.Forms.DataGridView
   Friend WithEvents TextLabel As System.Windows.Forms.Label
   Friend WithEvents WindowTextBox As System.Windows.Forms.TextBox
   Friend WithEvents SearchButton As System.Windows.Forms.Button
   Friend WithEvents WindowClassBox As System.Windows.Forms.TextBox
   Friend WithEvents ClassLabel As System.Windows.Forms.Label
   Friend WithEvents CaseSensitiveBox As System.Windows.Forms.CheckBox
   Friend WithEvents LookForParentWindowsBox As System.Windows.Forms.CheckBox
   Friend WithEvents WholePhrasesOnlyBox As System.Windows.Forms.CheckBox
   Friend WithEvents IgnoreAmpersandsBox As System.Windows.Forms.CheckBox
   Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
   Friend WithEvents ProgramMainMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents SearchResultsMainMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents WindowMainMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ExcludeMainMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents GetProcessInformationMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents WindowContextMenu As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents EnableDisableWindowMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ShowHideWindowMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents InformationMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ProgramSeparator1Menu As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents QuitMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents CopyMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents FindNextMatchMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents FindTextMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents CloseWindowMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents WindowSeparator1Menu As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ChangePositionDimensionsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ChangeParentMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ChangeStateMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ChangeTextMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ChangeZOrderMainMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents FlashWindowMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents WindowSeparator2Menu As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents MaximizeMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents MinimizeMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents RestoreMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents BottomMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents MiddleMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents TopMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents PermanentlyOnTopMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ChildWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ParentWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents DisabledWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents EnabledWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents HiddenWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents VisibleWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents NongroupWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents GroupWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents NonpopupWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents PopupWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents NontabstopWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents TabstopWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents NonunicodeWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UnicodeWindowsMenu As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents WindowHandleColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents WindowTextColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents WindowClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents WindowParentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
   Friend WithEvents GetBaseClassInformationMenu As System.Windows.Forms.ToolStripMenuItem
End Class
