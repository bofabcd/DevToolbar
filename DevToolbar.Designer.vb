<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevToolbar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevToolbar))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.VS2010ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CMDToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.SqlServerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.IISToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.IISConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.IISStartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IISRestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolsToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ServicesToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ManageToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TaskManagerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripMenuItemFIPS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButtonRegEx = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.DockToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.DockTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DockBottomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DockLeftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DockRightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DockFloatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutohideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.LockToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CloseToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SettingsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VS2010ToolStripButton, Me.CMDToolStripButton1, Me.ToolStripSeparator10, Me.SqlServerToolStripButton, Me.IISToolStripDropDownButton, Me.SystemToolsToolStripDropDownButton, Me.ToolStripButtonRegEx, Me.ToolStripSeparator14, Me.SettingsToolStripButton, Me.ToolStripSeparator9, Me.LockToolStripButton, Me.CloseToolStripButton})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(1)
        Me.ToolStrip1.Size = New System.Drawing.Size(1620, 103)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'VS2010ToolStripButton
        '
        Me.VS2010ToolStripButton.Image = CType(resources.GetObject("VS2010ToolStripButton.Image"), System.Drawing.Image)
        Me.VS2010ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.VS2010ToolStripButton.Name = "VS2010ToolStripButton"
        Me.VS2010ToolStripButton.Size = New System.Drawing.Size(82, 28)
        Me.VS2010ToolStripButton.Text = "VS2010"
        Me.VS2010ToolStripButton.ToolTipText = "Microsoft Visual Studio 2010 [ADMIN]"
        Me.VS2010ToolStripButton.Visible = False
        '
        'CMDToolStripButton1
        '
        Me.CMDToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CMDToolStripButton1.Image = CType(resources.GetObject("CMDToolStripButton1.Image"), System.Drawing.Image)
        Me.CMDToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CMDToolStripButton1.Name = "CMDToolStripButton1"
        Me.CMDToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.CMDToolStripButton1.ToolTipText = "Command Prompt [ADMIN]"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 23)
        '
        'SqlServerToolStripButton
        '
        Me.SqlServerToolStripButton.Image = CType(resources.GetObject("SqlServerToolStripButton.Image"), System.Drawing.Image)
        Me.SqlServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SqlServerToolStripButton.Name = "SqlServerToolStripButton"
        Me.SqlServerToolStripButton.Size = New System.Drawing.Size(102, 28)
        Me.SqlServerToolStripButton.Text = "SQL Server"
        Me.SqlServerToolStripButton.ToolTipText = "SQL Server Management Studio"
        Me.SqlServerToolStripButton.Visible = False
        '
        'IISToolStripDropDownButton
        '
        Me.IISToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IISConsoleToolStripMenuItem, Me.ToolStripSeparator3, Me.IISStartToolStripMenuItem, Me.IISRestartToolStripMenuItem})
        Me.IISToolStripDropDownButton.Image = CType(resources.GetObject("IISToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.IISToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.IISToolStripDropDownButton.Name = "IISToolStripDropDownButton"
        Me.IISToolStripDropDownButton.Size = New System.Drawing.Size(60, 28)
        Me.IISToolStripDropDownButton.Text = "IIS"
        Me.IISToolStripDropDownButton.Visible = False
        '
        'IISConsoleToolStripMenuItem
        '
        Me.IISConsoleToolStripMenuItem.Name = "IISConsoleToolStripMenuItem"
        Me.IISConsoleToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IISConsoleToolStripMenuItem.Text = "Console..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(149, 6)
        '
        'IISStartToolStripMenuItem
        '
        Me.IISStartToolStripMenuItem.Name = "IISStartToolStripMenuItem"
        Me.IISStartToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IISStartToolStripMenuItem.Text = "Start"
        '
        'IISRestartToolStripMenuItem
        '
        Me.IISRestartToolStripMenuItem.Name = "IISRestartToolStripMenuItem"
        Me.IISRestartToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IISRestartToolStripMenuItem.Text = "Restart"
        '
        'SystemToolsToolStripDropDownButton
        '
        Me.SystemToolsToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServicesToolStripButton, Me.ManageToolStripButton, Me.TaskManagerToolStripButton, Me.ToolStripMenuItemFIPS})
        Me.SystemToolsToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SystemToolsToolStripDropDownButton.Name = "SystemToolsToolStripDropDownButton"
        Me.SystemToolsToolStripDropDownButton.Size = New System.Drawing.Size(100, 20)
        Me.SystemToolsToolStripDropDownButton.Text = "System Tools"
        '
        'ServicesToolStripButton
        '
        Me.ServicesToolStripButton.Image = CType(resources.GetObject("ServicesToolStripButton.Image"), System.Drawing.Image)
        Me.ServicesToolStripButton.Name = "ServicesToolStripButton"
        Me.ServicesToolStripButton.Size = New System.Drawing.Size(85, 28)
        Me.ServicesToolStripButton.Text = "Services"
        '
        'ManageToolStripButton
        '
        Me.ManageToolStripButton.Image = CType(resources.GetObject("ManageToolStripButton.Image"), System.Drawing.Image)
        Me.ManageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ManageToolStripButton.Name = "ManageToolStripButton"
        Me.ManageToolStripButton.Size = New System.Drawing.Size(82, 28)
        Me.ManageToolStripButton.Text = "Manage"
        Me.ManageToolStripButton.ToolTipText = "Computer Management"
        '
        'TaskManagerToolStripButton
        '
        Me.TaskManagerToolStripButton.Image = CType(resources.GetObject("TaskManagerToolStripButton.Image"), System.Drawing.Image)
        Me.TaskManagerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TaskManagerToolStripButton.Name = "TaskManagerToolStripButton"
        Me.TaskManagerToolStripButton.Size = New System.Drawing.Size(117, 28)
        Me.TaskManagerToolStripButton.Text = "Task Manager"
        '
        'ToolStripMenuItemFIPS
        '
        Me.ToolStripMenuItemFIPS.Name = "ToolStripMenuItemFIPS"
        Me.ToolStripMenuItemFIPS.Size = New System.Drawing.Size(161, 22)
        Me.ToolStripMenuItemFIPS.Text = "Enable FIPS"
        '
        'ToolStripButtonRegEx
        '
        Me.ToolStripButtonRegEx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRegEx.Image = CType(resources.GetObject("ToolStripButtonRegEx.Image"), System.Drawing.Image)
        Me.ToolStripButtonRegEx.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRegEx.Name = "ToolStripButtonRegEx"
        Me.ToolStripButtonRegEx.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonRegEx.ToolTipText = "RegEx"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 23)
        '
        'SettingsToolStripButton
        '
        Me.SettingsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SettingsToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DockToolStripDropDownButton, Me.AutohideToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripSeparator7, Me.ExitToolStripMenuItem})
        Me.SettingsToolStripButton.Image = CType(resources.GetObject("SettingsToolStripButton.Image"), System.Drawing.Image)
        Me.SettingsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SettingsToolStripButton.Name = "SettingsToolStripButton"
        Me.SettingsToolStripButton.ShowDropDownArrow = False
        Me.SettingsToolStripButton.Size = New System.Drawing.Size(28, 28)
        Me.SettingsToolStripButton.ToolTipText = "Settings"
        '
        'DockToolStripDropDownButton
        '
        Me.DockToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DockToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DockTopToolStripMenuItem, Me.DockBottomToolStripMenuItem, Me.DockLeftToolStripMenuItem, Me.DockRightToolStripMenuItem, Me.DockFloatToolStripMenuItem})
        Me.DockToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DockToolStripDropDownButton.Name = "DockToolStripDropDownButton"
        Me.DockToolStripDropDownButton.Size = New System.Drawing.Size(51, 20)
        Me.DockToolStripDropDownButton.Text = "Dock"
        '
        'DockTopToolStripMenuItem
        '
        Me.DockTopToolStripMenuItem.Name = "DockTopToolStripMenuItem"
        Me.DockTopToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.DockTopToolStripMenuItem.Text = "Top"
        '
        'DockBottomToolStripMenuItem
        '
        Me.DockBottomToolStripMenuItem.Name = "DockBottomToolStripMenuItem"
        Me.DockBottomToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.DockBottomToolStripMenuItem.Text = "Bottom"
        '
        'DockLeftToolStripMenuItem
        '
        Me.DockLeftToolStripMenuItem.Name = "DockLeftToolStripMenuItem"
        Me.DockLeftToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.DockLeftToolStripMenuItem.Text = "Left"
        '
        'DockRightToolStripMenuItem
        '
        Me.DockRightToolStripMenuItem.Name = "DockRightToolStripMenuItem"
        Me.DockRightToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.DockRightToolStripMenuItem.Text = "Right"
        '
        'DockFloatToolStripMenuItem
        '
        Me.DockFloatToolStripMenuItem.Name = "DockFloatToolStripMenuItem"
        Me.DockFloatToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.DockFloatToolStripMenuItem.Text = "Float"
        '
        'AutohideToolStripMenuItem
        '
        Me.AutohideToolStripMenuItem.CheckOnClick = True
        Me.AutohideToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AutohideToolStripMenuItem.Name = "AutohideToolStripMenuItem"
        Me.AutohideToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AutohideToolStripMenuItem.Text = "Auto-hide"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(149, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 23)
        '
        'LockToolStripButton
        '
        Me.LockToolStripButton.Image = CType(resources.GetObject("LockToolStripButton.Image"), System.Drawing.Image)
        Me.LockToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LockToolStripButton.Name = "LockToolStripButton"
        Me.LockToolStripButton.Size = New System.Drawing.Size(28, 28)
        Me.LockToolStripButton.ToolTipText = "Lock Workstation"
        '
        'CloseToolStripButton
        '
        Me.CloseToolStripButton.Image = CType(resources.GetObject("CloseToolStripButton.Image"), System.Drawing.Image)
        Me.CloseToolStripButton.Name = "CloseToolStripButton"
        Me.CloseToolStripButton.Size = New System.Drawing.Size(28, 28)
        Me.CloseToolStripButton.ToolTipText = "Exit"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "DevToolbar"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem1, Me.ToolStripSeparator18, Me.ExitToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(101, 54)
        '
        'SettingsToolStripMenuItem1
        '
        Me.SettingsToolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1"
        Me.SettingsToolStripMenuItem1.Size = New System.Drawing.Size(100, 22)
        Me.SettingsToolStripMenuItem1.Text = "Settings..."
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(97, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(100, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'DevToolbar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(1620, 103)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DevToolbar"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "DevToolbar"
        Me.TopMost = True
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents CloseToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SettingsToolStripButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents DockTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockBottomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockLeftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockRightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockFloatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutohideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VS2010ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LockToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SystemToolsToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ServicesToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ManageToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TaskManagerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SqlServerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents IISToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents IISConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents IISStartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IISRestartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemFIPS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButtonRegEx As System.Windows.Forms.ToolStripButton
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMDToolStripButton1 As System.Windows.Forms.ToolStripButton

End Class
