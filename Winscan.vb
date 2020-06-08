'This module's settings and imports.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Environment
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.Marshal
Imports System.Threading.Thread
Imports System.Windows.Forms

'This module contains this program's core procedures.
Public Module WindowScannerModule
   'The Microsoft Windows API constants, functions, and structures used by this program.
   Public Structure RECT
      Public Left As Integer
      Public Top As Integer
      Public Right As Integer
      Public Bottom As Integer
   End Structure

   Public Const ES_PASSWORD As Integer = &H20%
   Public Const GWL_STYLE As Integer = &HFFFFFFF0%
   Public Const HWND_BOTTOM As Integer = &H1%
   Public Const HWND_NOTOPMOST As Integer = &HFFFFFFFE%
   Public Const HWND_TOP As Integer = &H0%
   Public Const HWND_TOPMOST As Integer = &HFFFFFFFF%
   Public Const SW_HIDE As Integer = &H0%
   Public Const SW_RESTORE As Integer = &H9%
   Public Const SW_SHOWMAXIMIZED As Integer = &H3%
   Public Const SW_SHOWMINIMIZED As Integer = &H2%
   Public Const SW_SHOWNA As Integer = &H8%
   Public Const SWP_DRAWFRAME As Integer = &H20%
   Public Const SWP_NOACTIVATE As Integer = &H10%
   Public Const SWP_NOMOVE As Integer = &H2%
   Public Const SWP_SHOWWINDOW As Integer = &H40%
   Public Const WM_CLOSE As Integer = &H10%
   Public Const WM_SETTEXT As Integer = &HC%
   Public Const WS_CHILD As Integer = &H40000000%
   Public Const WS_GROUP As Integer = &H20000%
   Public Const WS_POPUP As Integer = &H80000000%
   Public Const WS_TABSTOP As Integer = &H10000%
   Private Const EM_GETPASSWORDCHAR As Integer = &HD2%
   Private Const EM_SETPASSWORDCHAR As Integer = &HCC%
   Private Const ERROR_ACCESS_DENIED As Integer = 5
   Private Const ERROR_SUCCESS As Integer = 0
   Private Const GCL_HMODULE As Integer = &HFFFFFFF0%
   Private Const PROCESS_ALL_ACCESS As Integer = &H1F0FFF%
   Private Const PROCESS_QUERY_INFORMATION As Integer = &H400%
   Private Const WM_GETTEXT As Integer = &HD%
   Private Const WM_GETTEXTLENGTH As Integer = &HE%

   <DllImport("User32.dll", SetLastError:=True)> Public Function BringWindowToTop(ByVal hwnd As Integer) As Integer
   End Function
   <DllImport("Kernel32.dll", SetLastError:=True)> Private Function CloseHandle(ByVal hObject As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function EnableWindow(ByVal hwnd As Integer, ByVal fEnable As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Private Function EnumChildWindows(ByVal hWndParent As Integer, ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function EnumWindows(ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Private Function GetClassLongA(ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Private Function GetClassLongPtr(ByVal hwnd As Integer, ByVal nIndex As Integer) As Long
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Private Function GetClassNameW(ByVal hWnd As Integer, ByVal lpClassName As IntPtr, ByVal nMaxCount As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function GetDesktopWindow() As Integer
   End Function
#If PLATFORM = "x86" Then
   <DllImport("Psapi.dll", SetLastError:=True)> Private Function GetModuleFileNameExW(ByVal hProcess As Integer, ByVal hModule As Integer, ByVal ModuleName As IntPtr, ByVal nSize As Integer) As Integer
   End Function
#ElseIf PLATFORM = "x64" Then
   <DllImport("Psapi.dll", SetLastError:=True)> Private Function GetModuleFileNameExW(ByVal hProcess As Integer, ByVal hModule As Long, ByVal ModuleName As IntPtr, ByVal nSize As Integer) As Integer
   End Function
#End If
   <DllImport("User32.dll", SetLastError:=True)> Public Function GetParent(ByVal hwnd As Integer) As Integer
   End Function
   <DllImport("Psapi.dll", SetLastError:=True)> Private Function GetProcessImageFileNameW(ByVal hProcess As Integer, ByVal lpImageFileName As IntPtr, ByVal nSize As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function GetWindowLongA(ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function GetWindowRect(ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Private Function GetWindowThreadProcessId(ByVal hwnd As Integer, ByRef lpdwProcessId As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsIconic(ByVal hwnd As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsWindow(ByVal hwnd As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsWindowEnabled(ByVal hwnd As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsWindowUnicode(ByVal hwnd As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsWindowVisible(ByVal hwnd As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function MoveWindow(ByVal hwnd As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Integer) As Integer
   End Function
   <DllImport("Kernel32.dll", SetLastError:=True)> Private Function OpenProcess(ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Private Function PostMessageA(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function RealGetWindowClassW(ByVal hwnd As Integer, ByVal pszType As IntPtr, ByVal cchType As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function ScreenToClient(ByVal hwnd As Integer, ByRef lpPoint As Drawing.Point) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function SendMessageW(ByVal hwnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function SetParent(ByVal hWndChild As Integer, ByVal hWndNewParent As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function SetWindowLongA(ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function ShowWindow(ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function SetWindowPos(ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function UpdateWindow(ByVal hwnd As Integer) As Integer
   End Function

   'The delegates used by this program.
   Public Delegate Function EnumWindowsProc(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer

   'This structure defines the thread, module and process information of a window.
   Public Structure WindowProcessStr
#If PLATFORM = "x86" Then          '
      Public ModuleH As Integer    '
#ElseIf PLATFORM = "x64" Then      'The handle of the module that created the window.
      Public ModuleH As Long       '
#End If                            '
      Public ModulePath As String  'The path of the module that created the window.
      Public ProcessH As Integer   'The handle of the process to which the window belongs.
      Public ProcessId As Integer  'The id of the process to which the window belongs.
      Public ProcessPath As String 'The path of the process' executable to which the window belongs.
      Public ThreadId As Integer   'The window's thread id.
   End Structure

   Public WindowHs As New List(Of Integer) 'Contains the list of any active windows found.

   'This procedure checks whether an error has occurred during the most recent Windows API call.
   Public Function CheckForError(Optional ReturnValue As Object = Nothing, Optional ResetSuppression As Boolean = False) As Object
      Try
         Dim Description As String = Nothing
         Dim ErrorCode As Integer = GetLastWin32Error()
         Dim Message As String = Nothing
         Static SuppressAPIErrors As Boolean = False

         If ResetSuppression Then SuppressAPIErrors = False

         If Not (ErrorCode = ERROR_SUCCESS OrElse ErrorCode = ERROR_ACCESS_DENIED) Then
            Description = New Win32Exception(ErrorCode).Message

            If Not SuppressAPIErrors Then
               Message = $"API error code: {ErrorCode} - {Description}{NewLine}"
               Message &= $"Return value: {ReturnValue}{NewLine}"
               Message &= "Continue displaying API error messages?"

               SuppressAPIErrors = (MessageBox.Show(Message, My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No)
            End If
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return ReturnValue
   End Function

   'This procedure returns the specified window's base class.
   Public Function GetWindowBaseClass(WindowH As Integer) As String
      Try
         Dim Buffer As IntPtr = AllocHGlobal(UShort.MaxValue)
         Dim Length As Integer = CInt(CheckForError(RealGetWindowClassW(WindowH, Buffer, UShort.MaxValue)))
         Dim WindowBaseClass As String = ""

         WindowBaseClass = If(Length > 0, PtrToStringUni(Buffer).Substring(0, Length), "")

         FreeHGlobal(Buffer)

         Return WindowBaseClass
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return ""
   End Function

   'This procedure returns the specified window's class.
   Public Function GetWindowClass(WindowH As Integer) As String
      Try
         Dim Buffer As IntPtr = AllocHGlobal(UShort.MaxValue)
         Dim Length As Integer = CInt(CheckForError(GetClassNameW(WindowH, Buffer, UShort.MaxValue)))
         Dim WindowClass As String = ""

         WindowClass = If(Length > 0, PtrToStringUni(Buffer).Substring(0, Length), "")

         FreeHGlobal(Buffer)

         Return WindowClass
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return ""
   End Function

   'This procedure returns the process information for the specified window.
   Public Function GetWindowProcess(WindowH As Integer) As WindowProcessStr
      Try
         Dim Buffer As New IntPtr
         Dim Length As New Integer
         Dim WindowProcess As New WindowProcessStr

         With WindowProcess
#If PLATFORM = "x86" Then
            .ModuleH = CInt(CheckForError(GetClassLongA(WindowH, GCL_HMODULE)))
#ElseIf PLATFORM = "x64" Then
            .ModuleH = CLng(CheckForError(GetClassLongPtr(WindowH, GCL_HMODULE)))
#End If
            .ModulePath = ""
            .ProcessPath = ""
            .ThreadId = CInt(CheckForError(GetWindowThreadProcessId(WindowH, .ProcessId)))

            .ProcessH = CInt(CheckForError(OpenProcess(PROCESS_ALL_ACCESS, CInt(False), .ProcessId)))
            If Not .ProcessH = Nothing Then
               Buffer = AllocHGlobal(UShort.MaxValue)
               Length = CInt(CheckForError(GetModuleFileNameExW(.ProcessH, .ModuleH, Buffer, UShort.MaxValue)))
               CheckForError(CloseHandle(.ProcessH))

               .ModulePath = PtrToStringUni(Buffer)
               FreeHGlobal(Buffer)
               .ModulePath = If(Length > 0, .ModulePath.Substring(0, Length), "")
            End If

            .ProcessH = CInt(CheckForError(OpenProcess(PROCESS_QUERY_INFORMATION, CInt(False), .ProcessId)))
            If Not .ProcessH = 0 Then
               Buffer = AllocHGlobal(UShort.MaxValue)
               Length = CInt(CheckForError(GetProcessImageFileNameW(.ProcessH, Buffer, UShort.MaxValue)))
               CheckForError(CloseHandle(.ProcessH))

               .ProcessPath = PtrToStringUni(Buffer)
               FreeHGlobal(Buffer)
               .ProcessPath = If(Length > 0, .ProcessPath.Substring(0, Length), "")
            End If
         End With

         Return WindowProcess
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return New WindowProcessStr
   End Function

   'This procedure returns the text contained by the specified window.
   Public Function GetWindowText(WindowH As Integer) As String
      Try
         Dim Buffer As New IntPtr
         Dim Length As New Integer
         Dim PasswordCharacter As New Integer
         Dim WindowText As String = ""

         If WindowHasStyle(WindowH, ES_PASSWORD) Then
            PasswordCharacter = CInt(CheckForError(SendMessageW(WindowH, EM_GETPASSWORDCHAR, Nothing, Nothing)))
            If Not PasswordCharacter = Nothing Then
               CheckForError(PostMessageA(WindowH, EM_SETPASSWORDCHAR, Nothing, Nothing))
               Sleep(1000)
            End If
         End If

         Length = CInt(CheckForError(SendMessageW(WindowH, WM_GETTEXTLENGTH, Nothing, Nothing))) + 1
         Buffer = AllocHGlobal(UShort.MaxValue)
         Length = CInt(CheckForError(SendMessageW(WindowH, WM_GETTEXT, Length, Buffer)))
         WindowText = PtrToStringUni(Buffer)
         FreeHGlobal(Buffer)

         WindowText = If(Length <= WindowText.Length, WindowText.Substring(0, Length), "")

         If Not PasswordCharacter = Nothing Then CheckForError(PostMessageA(WindowH, EM_SETPASSWORDCHAR, PasswordCharacter, Nothing))

         Return WindowText
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return ""
   End Function

   'This procedure handles any errors that occur and notifies the user.
   Public Sub HandleError(ExceptionO As Exception)
      Try
         If ExceptionO.GetType().Name = "Win32Exception" Then
            Dim WindowsException As Win32Exception = DirectCast(ExceptionO, Win32Exception)
            MessageBox.Show($"Error: {WindowsException.NativeErrorCode}{NewLine}{WindowsException.Message}", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            MessageBox.Show($"Error: {ExceptionO.Message}", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If
      Catch
         InterfaceWindow.Close()
      End Try
   End Sub

   'This procedure handles any active child windows found.
   Private Function HandleChildWindow(hWnd As Integer, lParam As Integer) As Integer
      Try
         WindowHs.Add(hWnd)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return CInt(True)
   End Function

   'This procedure handles any active windows found.
   Public Function HandleWindow(hWnd As Integer, lParam As Integer) As Integer
      Try
         WindowHs.Add(hWnd)
         EnumChildWindows(hWnd, AddressOf HandleChildWindow, Nothing)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return CInt(True)
   End Function

   'This procedure indicates whether the specified handle refers to a window.
   Public Function RefersToWindow(WindowH As Integer) As Boolean
      Dim HIsWindow As Boolean = False

      Try
         Dim Message As String = Nothing

         HIsWindow = CBool(CheckForError(IsWindow(WindowH)))

         If Not HIsWindow Then
            Message = $"The selected object is not a window.{NewLine}"
            Message &= $"This could be due to the following causes:{NewLine}"
            Message &= $"The window no longer exists,{NewLine}"
            Message &= "or its handle has changed."
            MessageBox.Show(Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return HIsWindow
   End Function

   'This procedure displays the input dialog and returns the user's input.
   Public Function ShowInputDialog(Optional Prompt As String = Nothing, Optional Input As String = Nothing, Optional ByRef Button As DialogResult = Nothing) As String
      Try
         With InputDialog
            .PromptLabel.Text = Prompt
            .TextBox.Text = Input
            Button = .ShowDialog()
            Return If(Button = DialogResult.Cancel, Nothing, .TextBox.Text)
         End With
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure indicates whether a window has the specified style.
   Public Function WindowHasStyle(WindowH As Integer, Style As Integer) As Boolean
      Try
         Return ((CInt(CheckForError(GetWindowLongA(WindowH, GWL_STYLE), )) And Style) = Style)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return False
   End Function
End Module
