<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditRegexForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditRegexForm))
        Me.TextBoxPattern = New System.Windows.Forms.TextBox()
        Me.TextBoxReplacement = New System.Windows.Forms.TextBox()
        Me.RichTextBoxInput = New System.Windows.Forms.RichTextBox()
        Me.RichTextBoxOutput = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.LabelArgException = New System.Windows.Forms.Label()
        Me.ButtonPaste = New System.Windows.Forms.Button()
        Me.ButtonCopy = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ButtonQuickReference = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'TextBoxPattern
        '
        Me.TextBoxPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxPattern.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPattern.Location = New System.Drawing.Point(12, 49)
        Me.TextBoxPattern.Multiline = True
        Me.TextBoxPattern.Name = "TextBoxPattern"
        Me.TextBoxPattern.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxPattern.Size = New System.Drawing.Size(802, 88)
        Me.TextBoxPattern.TabIndex = 0
        Me.TextBoxPattern.WordWrap = False
        '
        'TextBoxReplacement
        '
        Me.TextBoxReplacement.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxReplacement.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.TextBoxReplacement.Location = New System.Drawing.Point(12, 457)
        Me.TextBoxReplacement.Name = "TextBoxReplacement"
        Me.TextBoxReplacement.Size = New System.Drawing.Size(904, 22)
        Me.TextBoxReplacement.TabIndex = 1
        Me.TextBoxReplacement.WordWrap = False
        '
        'RichTextBoxInput
        '
        Me.RichTextBoxInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxInput.DetectUrls = False
        Me.RichTextBoxInput.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBoxInput.Location = New System.Drawing.Point(12, 165)
        Me.RichTextBoxInput.Name = "RichTextBoxInput"
        Me.RichTextBoxInput.Size = New System.Drawing.Size(904, 264)
        Me.RichTextBoxInput.TabIndex = 2
        Me.RichTextBoxInput.Text = ""
        Me.RichTextBoxInput.WordWrap = False
        '
        'RichTextBoxOutput
        '
        Me.RichTextBoxOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxOutput.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.RichTextBoxOutput.Location = New System.Drawing.Point(12, 507)
        Me.RichTextBoxOutput.Name = "RichTextBoxOutput"
        Me.RichTextBoxOutput.ReadOnly = True
        Me.RichTextBoxOutput.Size = New System.Drawing.Size(904, 264)
        Me.RichTextBoxOutput.TabIndex = 3
        Me.RichTextBoxOutput.Text = ""
        Me.RichTextBoxOutput.WordWrap = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 486)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Output"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Input / Matches"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 442)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Replacement"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Pattern"
        '
        'ButtonClose
        '
        Me.ButtonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClose.Location = New System.Drawing.Point(843, 788)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 8
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'LabelArgException
        '
        Me.LabelArgException.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelArgException.AutoEllipsis = True
        Me.LabelArgException.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelArgException.ForeColor = System.Drawing.Color.Red
        Me.LabelArgException.Location = New System.Drawing.Point(74, 10)
        Me.LabelArgException.Name = "LabelArgException"
        Me.LabelArgException.Size = New System.Drawing.Size(843, 38)
        Me.LabelArgException.TabIndex = 11
        Me.LabelArgException.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ButtonPaste
        '
        Me.ButtonPaste.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPaste.Location = New System.Drawing.Point(820, 81)
        Me.ButtonPaste.Name = "ButtonPaste"
        Me.ButtonPaste.Size = New System.Drawing.Size(104, 23)
        Me.ButtonPaste.TabIndex = 14
        Me.ButtonPaste.Text = "Paste"
        Me.ButtonPaste.UseVisualStyleBackColor = True
        '
        'ButtonCopy
        '
        Me.ButtonCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCopy.Location = New System.Drawing.Point(820, 114)
        Me.ButtonCopy.Name = "ButtonCopy"
        Me.ButtonCopy.Size = New System.Drawing.Size(104, 23)
        Me.ButtonCopy.TabIndex = 15
        Me.ButtonCopy.Text = "Copy"
        Me.ButtonCopy.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 788)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(133, 13)
        Me.LinkLabel1.TabIndex = 16
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Regular Expression Syntax"
        '
        'ButtonQuickReference
        '
        Me.ButtonQuickReference.Location = New System.Drawing.Point(820, 48)
        Me.ButtonQuickReference.Name = "ButtonQuickReference"
        Me.ButtonQuickReference.Size = New System.Drawing.Size(104, 23)
        Me.ButtonQuickReference.TabIndex = 17
        Me.ButtonQuickReference.Text = "Quick Reference"
        Me.ButtonQuickReference.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'EditRegexForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 823)
        Me.Controls.Add(Me.ButtonQuickReference)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.ButtonCopy)
        Me.Controls.Add(Me.ButtonPaste)
        Me.Controls.Add(Me.LabelArgException)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RichTextBoxOutput)
        Me.Controls.Add(Me.RichTextBoxInput)
        Me.Controls.Add(Me.TextBoxReplacement)
        Me.Controls.Add(Me.TextBoxPattern)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditRegexForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditRegexForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TextBoxPattern As System.Windows.Forms.TextBox
    Public WithEvents TextBoxReplacement As System.Windows.Forms.TextBox
    Public WithEvents RichTextBoxInput As System.Windows.Forms.RichTextBox
    Public WithEvents RichTextBoxOutput As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents LabelArgException As System.Windows.Forms.Label
    Friend WithEvents ButtonPaste As System.Windows.Forms.Button
    Friend WithEvents ButtonCopy As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents ButtonQuickReference As System.Windows.Forms.Button
    Friend WithEvents Timer1 As Timer
End Class
