'This module's settings and imports.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Environment
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.Marshal
Imports System.Text
Imports System.Threading.Thread
Imports System.Windows.Forms

'This module contains this program's core procedures.
Public Module WindowScannerModule
   'The Microsoft Windows API constants, functions, and structures used by this program.
   <StructLayout(LayoutKind.Sequential)>
   Public Structure RECT
      Public Left As Integer
      Public Top As Integer
      Public Right As Integer
      Public Bottom As Integer
   End Structure

   Public Const ES_PASSWORD As UInteger = &H20UI
   Public Const GWL_STYLE As UInteger = &HFFFFFFF0UI
   Public Const HWND_BOTTOM As UInteger = &H1UI
   Public Const HWND_NOTOPMOST As UInteger = &HFFFFFFFEUI
   Public Const HWND_TOP As UInteger = &H0UI
   Public Const HWND_TOPMOST As UInteger = &HFFFFFFFFUI
   Public Const SW_HIDE As UInteger = &H0UI
   Public Const SW_RESTORE As UInteger = &H9UI
   Public Const SW_SHOWMAXIMIZED As UInteger = &H3UI
   Public Const SW_SHOWMINIMIZED As UInteger = &H2UI
   Public Const SW_SHOWNA As UInteger = &H8UI
   Public Const SWP_DRAWFRAME As UInteger = &H20UI
   Public Const SWP_NOACTIVATE As UInteger = &H10UI
   Public Const SWP_NOMOVE As UInteger = &H2UI
   Public Const SWP_SHOWWINDOW As UInteger = &H40UI
   Public Const WM_CLOSE As UInteger = &H10UI
   Public Const WM_SETTEXT As UInteger = &HCUI
   Public Const WS_CHILD As UInteger = &H40000000UI
   Public Const WS_GROUP As UInteger = &H20000UI
   Public Const WS_POPUP As UInteger = &H80000000UI
   Public Const WS_TABSTOP As UInteger = &H10000UI
   Private Const EM_GETPASSWORDCHAR As UInteger = &HD2UI
   Private Const EM_SETPASSWORDCHAR As UInteger = &HCCUI
   Private Const ERROR_ACCESS_DENIED As UInteger = 5UI
   Private Const ERROR_SUCCESS As UInteger = 0UI
   Private Const GCL_HMODULE As UInteger = &HFFFFFFF0UI
   Private Const PROCESS_ALL_ACCESS As UInteger = &H1F0FFFUI
   Private Const PROCESS_QUERY_INFORMATION As UInteger = &H400UI
   Private Const WM_GETTEXT As UInteger = &HDUI
   Private Const WM_GETTEXTLENGTH As UInteger = &HEUI

   <DllImport("User32.dll", SetLastError:=True)> Public Function BringWindowToTop(ByVal hwnd As IntPtr) As Boolean
   End Function
   <DllImport("Kernel32.dll", SetLastError:=True)> Private Function CloseHandle(ByVal hObject As IntPtr) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function EnableWindow(ByVal hwnd As IntPtr, ByVal fEnable As Boolean) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Private Function EnumChildWindows(ByVal hWndParent As IntPtr, ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As IntPtr) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function EnumWindows(ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As IntPtr) As Integer
   End Function
#If PLATFORM = "x86" Then
   <DllImport("User32.dll", SetLastError:=True)> Private Function GetClassLongA(ByVal hwnd As IntPtr, ByVal nIndex As UInteger) As IntPtr
   End Function
#ElseIf PLATFORM = "x64" Then
   <DllImport("User32.dll", SetLastError:=True)> Private Function GetClassLongPtr(ByVal hwnd As IntPtr, ByVal nIndex As UInteger) As IntPtr
   End Function
#End If
   <DllImport("User32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> Private Function GetClassNameW(ByVal hWnd As IntPtr, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function GetDesktopWindow() As IntPtr
   End Function
   <DllImport("Psapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> Private Function GetModuleFileNameExW(ByVal hProcess As IntPtr, ByVal hModule As IntPtr, ByVal ModuleName As StringBuilder, ByVal nSize As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function GetParent(ByVal hwnd As IntPtr) As IntPtr
   End Function
   <DllImport("Psapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> Private Function GetProcessImageFileNameW(ByVal hProcess As IntPtr, ByVal lpImageFileName As StringBuilder, ByVal nSize As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function GetWindowLongA(ByVal hwnd As IntPtr, ByVal nIndex As UInteger) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function GetWindowRect(ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Private Function GetWindowThreadProcessId(ByVal hwnd As IntPtr, ByRef lpdwProcessId As UInteger) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsHungAppWindow(ByVal hwnd As IntPtr) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsIconic(ByVal hwnd As IntPtr) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsWindow(ByVal hwnd As IntPtr) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsWindowEnabled(ByVal hwnd As IntPtr) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsWindowUnicode(ByVal hwnd As IntPtr) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function IsWindowVisible(ByVal hwnd As IntPtr) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function MoveWindow(ByVal hwnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Integer) As Boolean
   End Function
   <DllImport("Kernel32.dll", SetLastError:=True)> Private Function OpenProcess(ByVal dwDesiredAccess As UInteger, ByVal bInheritHandle As Integer, ByVal dwProcessId As UInteger) As IntPtr
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Private Function PostMessageA(ByVal hwnd As IntPtr, ByVal wMsg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
   End Function
   <DllImport("User32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> Private Function RealGetWindowClassW(ByVal hwnd As IntPtr, ByVal pszType As StringBuilder, ByVal cchType As Integer) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function ScreenToClient(ByVal hwnd As IntPtr, ByRef lpPoint As Drawing.Point) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function SendMessageW(ByVal hwnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function SetWindowLongA(ByVal hwnd As IntPtr, ByVal nIndex As UInteger, ByVal dwNewLong As UInteger) As Integer
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As UInteger) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function SetWindowPos(ByVal hwnd As IntPtr, ByVal hWndInsertAfter As UInteger, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Boolean
   End Function
   <DllImport("User32.dll", SetLastError:=True)> Public Function UpdateWindow(ByVal hwnd As IntPtr) As Boolean
   End Function

   'The delegates used by this program.
   Public Delegate Function EnumWindowsProc(ByVal hWnd As IntPtr, ByVal lParam As IntPtr) As Integer

   'The structures and variables used by this program.

   'This structure defines the thread, module and process information of a window.
   Public Structure WindowProcessStr
      Public ModuleH As IntPtr         'Defines the handle of the module that created the window.
      Public ModulePath As String      'Defines the path of the module that created the window.
      Public ProcessH As IntPtr        'Defines the handle of the process to which the window belongs.
      Public ProcessId As UInteger     'Defines the id of the process to which the window belongs.
      Public ProcessPath As String     'Defines the path of the process' executable to which the window belongs.
      Public ThreadId As UInteger      'Defines the window's thread id.
   End Structure

   Public WindowHs As New List(Of IntPtr)   'Contains the list of any active windows found.

   'This procedure checks whether an error has occurred during the most recent Windows API call and returns the specified return value.
   Public Function CheckForError(Optional ReturnValue As Object = Nothing, Optional ResetSuppression As Boolean = False) As Object
      Try
         Dim Description As String = Nothing
         Dim ErrorCode As Integer = GetLastWin32Error()
         Dim Message As New StringBuilder
         Static SuppressAPIErrors As Boolean = False

         If ResetSuppression Then SuppressAPIErrors = False

         If Not (ErrorCode = ERROR_SUCCESS OrElse ErrorCode = ERROR_ACCESS_DENIED) Then
            Description = New Win32Exception(ErrorCode).Message

            If Not SuppressAPIErrors Then
               Message.Append($"API error code: {ErrorCode} - {Description}{NewLine}")
               Message.Append($"Return value: {ReturnValue}{NewLine}")
               Message.Append("Continue displaying API error messages?")

               SuppressAPIErrors = (MessageBox.Show(Message.ToString(), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No)
            End If
         End If
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return ReturnValue
   End Function

   'This procedure displays any exceptions that occur and notifies the user.
   Public Sub DisplayException(ExceptionO As Exception)
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

   'This procedure attempts to enter debug mode.
   Public Sub EnterDebugMode()
      Try
         Process.EnterDebugMode()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try
   End Sub

   'This procedure returns the specified window's base class.
   Public Function GetWindowBaseClass(WindowH As IntPtr) As String
      Try
         Dim Buffer As New StringBuilder(UShort.MaxValue)
         Dim Length As Integer = CInt(CheckForError(RealGetWindowClassW(WindowH, Buffer, Buffer.Capacity)))
         Dim WindowBaseClass As String = Nothing

         WindowBaseClass = If(Length > 0, Buffer.ToString(), Nothing)

         Return WindowBaseClass
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure returns the specified window's class.
   Public Function GetWindowClass(WindowH As IntPtr) As String
      Try
         Dim Buffer As New StringBuilder(UShort.MaxValue)
         Dim Length As Integer = CInt(CheckForError(GetClassNameW(WindowH, Buffer, Buffer.Capacity)))
         Dim WindowClass As String = If(Length > 0, Buffer.ToString(), Nothing)

         Return WindowClass
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure returns the specified window's process information.
   Public Function GetWindowProcess(WindowH As IntPtr) As WindowProcessStr
      Try
         Dim Buffer As New StringBuilder(UShort.MaxValue)
         Dim Length As New Integer
         Dim WindowProcess As New WindowProcessStr

         With WindowProcess
#If PLATFORM = "x86" Then
            .ModuleH = DirectCast(CheckForError(GetClassLongA(WindowH, GCL_HMODULE)), IntPtr)
#ElseIf PLATFORM = "x64" Then
            .ModuleH = DirectCast(CheckForError(GetClassLongPtr(WindowH, GCL_HMODULE)), IntPtr)
#End If
            .ModulePath = Nothing
            .ProcessPath = Nothing
            .ThreadId = CUInt(CheckForError(GetWindowThreadProcessId(WindowH, .ProcessId)))

            .ProcessH = DirectCast(CheckForError(OpenProcess(PROCESS_ALL_ACCESS, CInt(False), .ProcessId)), IntPtr)
            If Not .ProcessH = Nothing Then
               Length = CInt(CheckForError(GetModuleFileNameExW(.ProcessH, .ModuleH, Buffer, Buffer.Capacity)))
               CheckForError(CloseHandle(.ProcessH))

               .ModulePath = Buffer.ToString()
               .ModulePath = If(Length > 0, .ModulePath.Substring(0, Length), Nothing)
            End If

            .ProcessH = DirectCast(CheckForError(OpenProcess(PROCESS_QUERY_INFORMATION, CInt(False), .ProcessId)), IntPtr)
            If Not .ProcessH = Nothing Then
               Buffer = New StringBuilder(UShort.MaxValue)
               Length = CInt(CheckForError(GetProcessImageFileNameW(.ProcessH, Buffer, Buffer.Capacity)))
               CheckForError(CloseHandle(.ProcessH))

               .ProcessPath = Buffer.ToString()
               .ProcessPath = If(Length > 0, .ProcessPath, Nothing)
            End If
         End With

         Return WindowProcess
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return New WindowProcessStr
   End Function

   'This procedure returns the specified window's text.
   Public Function GetWindowText(WindowH As IntPtr) As String
      Try
         Dim Buffer As New IntPtr
         Dim Length As New Integer
         Dim PasswordCharacter As New Integer
         Dim WindowText As String = String.Empty

         If Not CBool(CheckForError(IsHungAppWindow(WindowH))) Then
            If WindowHasStyle(WindowH, ES_PASSWORD) Then
               PasswordCharacter = CInt(CheckForError(SendMessageW(WindowH, EM_GETPASSWORDCHAR, IntPtr.Zero, IntPtr.Zero)))
               If Not PasswordCharacter = Nothing Then
                  CheckForError(PostMessageA(WindowH, EM_SETPASSWORDCHAR, IntPtr.Zero, IntPtr.Zero))
                  Sleep(1000)
               End If
            End If

            Length = CInt(CheckForError(SendMessageW(WindowH, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero))) + 1
            Buffer = AllocHGlobal(UShort.MaxValue)
            Length = CInt(CheckForError(SendMessageW(WindowH, WM_GETTEXT, CType(Length, IntPtr), Buffer)))
            WindowText = PtrToStringUni(Buffer)
            FreeHGlobal(Buffer)

            WindowText = If(Length <= WindowText.Length, WindowText.Substring(0, Length), Nothing)

            If Not PasswordCharacter = Nothing Then CheckForError(PostMessageA(WindowH, EM_SETPASSWORDCHAR, CType(PasswordCharacter, IntPtr), IntPtr.Zero))
         End If

         Return WindowText
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure handles any child windows that are found and returns whether the enumeration should continue.
   Private Function HandleChildWindow(hWnd As IntPtr, lParam As IntPtr) As Integer
      Try
         WindowHs.Add(hWnd)
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return CInt(True)
   End Function

   'This procedure handles any top level windows that are found and returns whether the enumeration should continue.
   Public Function HandleWindow(hWnd As IntPtr, lParam As IntPtr) As Integer
      Try
         WindowHs.Add(hWnd)
         EnumChildWindows(hWnd, AddressOf HandleChildWindow, IntPtr.Zero)
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return CInt(True)
   End Function

   'This procedure returns information about this program.
   Public Function ProgramInformation() As String
      Try
         Dim Information As New StringBuilder

         With My.Application.Info
            Information.Append($"{ .Title} v{ .Version} - by: { .CompanyName}")

#If PLATFORM = "x86" Then
            Information.Append(" (x86)")
#ElseIf PLATFORM = "x64" Then
            Information.Append(" (x64)")
#End If
         End With

         Return Information.ToString()
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure checks whether the specified handle refers to a window and returns the result.
   Public Function RefersToWindow(WindowH As IntPtr) As Boolean
      Try
         Dim HIsWindow As Boolean = False
         Dim Message As New StringBuilder

         HIsWindow = CBool(CheckForError(IsWindow(WindowH)))

         If Not HIsWindow Then
            Message.Append($"The selected object is not a window.{NewLine}")
            Message.Append($"This could be due to the following causes:{NewLine}")
            Message.Append($"The window no longer exists,{NewLine}")
            Message.Append("or its handle has changed.")
            MessageBox.Show(Message.ToString(), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

         Return HIsWindow
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return False
   End Function

   'This procedure displays the input dialog and returns the user's input.
   Public Function ShowInputDialog(Optional Prompt As String = Nothing, Optional Input As String = Nothing, Optional ByRef Button As DialogResult = Nothing) As String
      Try
         Dim Text As String = Nothing

         With New InputDialog(Prompt, Input)
            Button = .ShowDialog()
            Text = .TextBox.Text
         End With

         Return If(Button = DialogResult.Cancel, Nothing, Text)
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure checks whether a window has the specified style and returns the result.
   Public Function WindowHasStyle(WindowH As IntPtr, Style As UInteger) As Boolean
      Try
         Return ((CInt(CheckForError(GetWindowLongA(WindowH, GWL_STYLE))) And Style) = Style)
      Catch ExceptionO As Exception
         DisplayException(ExceptionO)
      End Try

      Return False
   End Function
End Module
