Imports System.ServiceProcess
Imports System.IO
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Xml.Serialization

Public Class DevToolbar

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const WM_NCMOUSEMOVE As Integer = &HA0

    Public Const HTCAPTION As Integer = &H2

    <DllImport("User32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("User32.dll")> _
    Public Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)> Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)> Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)> Private Shared Function LockWorkStation() As Integer
    End Function

    Protected appBar As ApplicationBar
    Protected MySettings As MySettings

    Private Sub DevToolbar_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.appBar = New ApplicationBar()
        Me.appBar.Extends(Me)

        LoadMySettings()
    End Sub

    Private Sub DevToolbar_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        setLayout()
    End Sub

    Private Sub setLayout()
        If IsNothing(appBar) Then Exit Sub

        Me.ToolStrip1.Height = 26
        Select Case appBar.Edge
            Case ApplicationBar.ABEdge.abeTop, ApplicationBar.ABEdge.abeBottom
                Me.Height = Me.ToolStrip1.Height
                Me.ToolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow
            Case ApplicationBar.ABEdge.abeLeft, ApplicationBar.ABEdge.abeRight
                Me.Width = 250
                Me.ToolStrip1.Height = Me.Height
                Me.ToolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow
            Case Else
                Me.Height = Me.ToolStrip1.Height + SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight
                Me.ToolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow
        End Select
    End Sub

    Private Function IsServiceInstalled(srv As String) As Boolean
        Try
            Dim Result As Boolean = False

            For Each InstalledService As ServiceController In ServiceController.GetServices()
                If InstalledService.ServiceName = srv Then
                    Result = True
                    Exit For
                End If
            Next

            Return Result

        Catch ex As Exception
            ' Return Failed
            Return False
        End Try
    End Function

    Private Function IsServiceStarted(srv As String) As Boolean
        Try
            Dim Result As Boolean = False

            For Each InstalledService As ServiceController In ServiceController.GetServices()
                If InstalledService.ServiceName = srv Then
                    If InstalledService.Status = ServiceControllerStatus.Running Then
                        Result = True
                    End If
                    Exit For
                End If
            Next

            Return Result

        Catch ex As Exception
            ' Return Failed
            Return False
        End Try
    End Function

    Private Sub SwitchService(srv As String, onoff As ServiceControllerStatus)

        For Each InstalledService As ServiceController In ServiceController.GetServices()
            If InstalledService.ServiceName = srv Then
                Select Case onoff
                    Case ServiceControllerStatus.Running
                        InstalledService.Start()
                    Case ServiceControllerStatus.Stopped
                        InstalledService.Stop()
                End Select
                Exit For
            End If
        Next

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If IsServiceInstalled("W3SVC") Then
            Me.IISToolStripDropDownButton.BackColor = Color.OrangeRed
            Me.IISStartToolStripMenuItem.Visible = True
            Me.IISStartToolStripMenuItem.Text = "Start"
            If IsServiceStarted("W3SVC") Then
                Me.IISToolStripDropDownButton.BackColor = Color.LightGreen
                Me.IISStartToolStripMenuItem.Text = "Stop"
            End If
        Else
            Me.IISToolStripDropDownButton.BackColor = Color.Gray
            Me.IISStartToolStripMenuItem.Visible = False
            Me.IISRestartToolStripMenuItem.Visible = False
            Me.IISConsoleToolStripMenuItem.Visible = False
        End If

        Dim fips As Boolean = CBool(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\FipsAlgorithmPolicy", "Enabled", 0))
        Me.ToolStripMenuItemFIPS.Text = If(fips, "Disable FIPS", "Enable FIPS")
    End Sub

    Private Sub IISStartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IISStartToolStripMenuItem.Click
        Dim sc As New ServiceController("W3SVC")

        If IsServiceStarted("W3SVC") Then
            SwitchService("W3SVC", ServiceControllerStatus.Stopped)
        Else
            SwitchService("W3SVC", ServiceControllerStatus.Running)
        End If
    End Sub

    Private Sub IISRestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IISRestartToolStripMenuItem.Click
        Dim sc As New ServiceController("W3SVC")

        If sc.Status.Equals(ServiceControllerStatus.Running) Then
            sc.Stop()
            sc.WaitForStatus(ServiceControllerStatus.Stopped)
            Me.IISToolStripDropDownButton.BackColor = Color.OrangeRed
        End If
        If sc.Status.Equals(ServiceControllerStatus.Stopped) Then sc.Start()
    End Sub

    Private Sub ServicesToolStripButton_Click(sender As Object, e As EventArgs) Handles ServicesToolStripButton.Click
        Dim newProcess As Process = System.Diagnostics.Process.Start("services.msc")
    End Sub

    Private Sub ManageToolStripButton_Click(sender As Object, e As EventArgs) Handles ManageToolStripButton.Click
        Dim newProcess As Process = System.Diagnostics.Process.Start("compmgmt.msc")
    End Sub

    Private Sub IISConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IISConsoleToolStripMenuItem.Click
        Dim newProcess As Process = System.Diagnostics.Process.Start(Environ("systemroot") & "\system32\inetsrv\iis.msc")
    End Sub

    Private Sub SqlServerToolStripButton_Click(sender As Object, e As EventArgs) Handles SqlServerToolStripButton.Click
        Dim newProcess As Process = System.Diagnostics.Process.Start(Me.MySettings.SqlManagementPath)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripButton.Click, ExitToolStripMenuItem.Click, ExitToolStripMenuItem1.Click
        Me.Timer1.Enabled = False
        appBar.Detach()
        Me.Close()
    End Sub

    Private Sub DockToolStripDropDownButton_DropDownItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles DockToolStripDropDownButton.DropDownItemClicked
        Select Case e.ClickedItem.Text
            Case "Top"
                Me.MySettings.Edge = ApplicationBar.ABEdge.abeTop
            Case ("Bottom")
                Me.MySettings.Edge = ApplicationBar.ABEdge.abeBottom
            Case "Left"
                Me.MySettings.Edge = ApplicationBar.ABEdge.abeLeft
            Case "Right"
                Me.MySettings.Edge = ApplicationBar.ABEdge.abeRight
            Case "Float"
                Me.MySettings.Edge = ApplicationBar.ABEdge.abeFloat
        End Select
    End Sub

    Private Sub ToolStrip1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub

    Private Sub ToolStrip1_MouseEnter(sender As Object, e As EventArgs) Handles ToolStrip1.MouseEnter
        Me.Activate()
        Me.appBar.OnNcMouseMove()
    End Sub

    Private Sub AutohideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutohideToolStripMenuItem.Click
        Me.MySettings.Autohide = Me.AutohideToolStripMenuItem.Checked
    End Sub

    Private Sub VS2010ToolStripButton_Click(sender As Object, e As EventArgs) Handles VS2010ToolStripButton.Click
        Dim procInfo As New ProcessStartInfo()
        Dim RelativeRootFolderPath As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\10.0_Config\Initialization", "RelativeRootFolderPath", Nothing)

        If IsNothing(RelativeRootFolderPath) OrElse String.IsNullOrEmpty(RelativeRootFolderPath) Then Exit Sub

        procInfo.FileName = Path.Combine(RelativeRootFolderPath, "Common7\IDE\devenv.exe")
        procInfo.WorkingDirectory = ""

        If (My.Computer.Info.OSFullName.ToString.Contains("Vista") = True) Or
                     (My.Computer.Info.OSFullName.ToString.Contains("Windows 7") = True) Then

            procInfo.Verb = "runas"

        End If

        Process.Start(procInfo)
    End Sub

    Private Sub CMDToolStripButton_Click(sender As Object, e As EventArgs) Handles CMDToolStripButton1.Click
        Dim procInfo As New ProcessStartInfo()
        procInfo.FileName = "cmd.exe"
        procInfo.WorkingDirectory = ""

        If (My.Computer.Info.OSFullName.ToString.Contains("Vista") = True) Or
                     (My.Computer.Info.OSFullName.ToString.Contains("Windows 7") = True) Then

            procInfo.Verb = "runas"

        End If

        Process.Start(procInfo)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click, SettingsToolStripMenuItem1.Click
        Dim cp As New ConfigurationProperties

        cp.SelectedObject = Me.MySettings

        If cp.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.SaveMySettings()
        End If

    End Sub

    Public Sub LoadMySettings()
        'Get Files Path
        Dim Filename As String = Path.Combine(My.Application.Info.DirectoryPath, "DevToolbar.config")
        Dim x As XmlSerializer = Nothing

        Me.MySettings = New MySettings

        If IO.File.Exists(Filename) Then
            'Deserialize text file to a new object.
            Dim objStreamReader As New StreamReader(Filename)
            x = New XmlSerializer(Me.MySettings.GetType)
            Me.MySettings = x.Deserialize(objStreamReader)
            objStreamReader.Close()
        End If

        AddHandler Me.MySettings.Changed, AddressOf SaveMySettings

        Me.UpdateAppFromMySettings()
    End Sub

    Private Sub UpdateAppFromMySettings()
        Me.AutohideToolStripMenuItem.Checked = Me.MySettings.Autohide
        Me.appBar.AutoHide = Me.MySettings.Autohide
        Me.appBar.Edge = Me.MySettings.Edge

        Me.setLayout()

    End Sub

    Public Sub SaveMySettings()
        'Get Files Path
        Dim Filename As String = Path.Combine(My.Application.Info.DirectoryPath, "DevToolbar.config")
        Dim x As XmlSerializer = Nothing

        IO.File.Delete(Filename)
        Dim objStreamWriter As New StreamWriter(Filename)
        x = New XmlSerializer(Me.MySettings.GetType)
        x.Serialize(objStreamWriter, Me.MySettings)
        objStreamWriter.Close()

        Me.UpdateAppFromMySettings()
    End Sub

    Private Sub TaskManagerToolStripButton_Click(sender As Object, e As EventArgs) Handles TaskManagerToolStripButton.Click
        Dim myProcess_TaskManager_App As Process = System.Diagnostics.Process.Start("taskmgr.exe")
    End Sub

    Private Sub LockToolStripButton_Click(sender As Object, e As EventArgs) Handles LockToolStripButton.Click
        LockWorkStation()
    End Sub

    Private Sub BuildSolution(SolutionFile As String, BuildConfiguration As String)
        Dim procInfo As New ProcessStartInfo()
        Dim RelativeRootFolderPath As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\10.0_Config\Initialization", "RelativeRootFolderPath", Nothing)

        If IsNothing(RelativeRootFolderPath) Then Exit Sub

        procInfo.FileName = Path.Combine(RelativeRootFolderPath, "Common7\IDE\devenv.exe")
        procInfo.WorkingDirectory = ""
        procInfo.Arguments = """" & SolutionFile & """" & " /build " & BuildConfiguration

        If (My.Computer.Info.OSFullName.ToString.Contains("Vista") = True) Or
                     (My.Computer.Info.OSFullName.ToString.Contains("Windows 7") = True) Then

            procInfo.Verb = "runas"

        End If

        Process.Start(procInfo)
    End Sub

    Private Sub CopyOutputFile(Source, Destination)
        Try
            If Path.GetFileName(Destination) = "" Then
                Destination = Path.Combine(Destination, Path.GetFileName(Source))
            End If
            FileSystem.FileCopy(Source, Destination)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub ToolStripMenuItemFIPS_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFIPS.Click
        Dim fips As Boolean = CBool(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\FipsAlgorithmPolicy", "Enabled", 0))
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\FipsAlgorithmPolicy", "Enabled", If(fips, 0, 1))
    End Sub

    Private Sub ToolStripButtonRegEx_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRegEx.Click
        Dim f As EditRegexForm = New EditRegexForm
        f.Show()
    End Sub

End Class
