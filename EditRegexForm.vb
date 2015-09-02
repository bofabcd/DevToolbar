Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports System.IO

Public Class EditRegexForm

    Private Enum RegexSection
        None
        Character_Escapes
        Character_Classes
        Anchors
        GroupingConstructs
        Quantifiers
        Backreference_Constructs
        Alternation_Constructs
        Substitutions
        Regular_Expression_Options
        Miscellaneous_Constructs
    End Enum

    <Serializable()>
    Public Class RegexData
        Private _pattern As String
        Private _input As String
        Private _replace As String

        Public Property Pattern() As String
            Get
                Return _pattern
            End Get
            Set(ByVal value As String)
                _pattern = value
            End Set
        End Property

        Public Property Input() As String
            Get
                Return _input
            End Get
            Set(ByVal value As String)
                _input = value
            End Set
        End Property

        Public Property Replace() As String
            Get
                Return _replace
            End Get
            Set(ByVal value As String)
                _replace = value
            End Set
        End Property
    End Class

    Private Property SerializedRegexData As RegexData
    Private Working As Boolean

    Private Sub TextBoxTextChanged(sender As Object, e As EventArgs) Handles TextBoxPattern.TextChanged, RichTextBoxInput.TextChanged, TextBoxReplacement.TextChanged
        Timer1.Enabled = False
        If Working Then Exit Sub
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        If String.IsNullOrWhiteSpace(RichTextBoxInput.Text) Then Exit Sub

        Dim selectionStart As Integer = 0
        Dim selectionLength As Integer = 0

        Try
            Working = True
            Dim matchColor As Color = Color.Yellow
            Dim input As String = RichTextBoxInput.Text
            input = input.Replace(vbLf, vbCrLf)
            selectionStart = RichTextBoxInput.SelectionStart
            selectionLength = RichTextBoxInput.SelectionLength
            RichTextBoxInput.SelectAll()
            RichTextBoxInput.SelectionBackColor = Color.White
            RichTextBoxInput.DeselectAll()

            If TextBoxPattern.Text <> "" Then
                For Each m As Match In Regex.Matches(input, TextBoxPattern.Text)
                    Dim before As String = input.Substring(0, m.Index)
                    Dim OperandEnum As IEnumerator = Nothing
                    Dim crCountBefore As Integer = 0
                    Dim crCountInMatch As Integer = 0

                    OperandEnum = before.GetEnumerator()
                    While OperandEnum.MoveNext()
                        If OperandEnum.Current = vbCr Then crCountBefore += 1
                    End While

                    OperandEnum = m.Value.GetEnumerator()
                    While OperandEnum.MoveNext()
                        If OperandEnum.Current = vbCr Then crCountInMatch += 1
                    End While

                    RichTextBoxInput.Select(m.Index - crCountBefore, m.Length - crCountInMatch)
                    RichTextBoxInput.SelectionBackColor = matchColor
                    RichTextBoxInput.DeselectAll()

                    If matchColor = Color.Yellow Then
                        matchColor = Color.Orange
                    Else
                        matchColor = Color.Yellow
                    End If
                Next

                RichTextBoxOutput.Text = Regex.Replace(input, TextBoxPattern.Text, TextBoxReplacement.Text)
            Else
                RichTextBoxOutput.Clear()
            End If

            LabelArgException.Text = ""

        Catch ax As ArgumentException
            LabelArgException.Text = ax.Message.Replace("parsing """ & TextBoxPattern.Text & """ - ", "")
        Finally
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(RegexData))
            ' To write to a file, create a StreamWriter object.
            Dim path As String
            path = System.IO.Path.GetDirectoryName(
               System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\", "")
            Dim myWriter As StreamWriter = New StreamWriter(path & "\regex.xml")
            mySerializer.Serialize(myWriter, New RegexData With {.Pattern = TextBoxPattern.Text, .Input = RichTextBoxInput.Text, .Replace = TextBoxReplacement.Text})
            myWriter.Close()
            RichTextBoxInput.SelectionStart = selectionStart
            RichTextBoxInput.SelectionLength = selectionLength
            Working = False
        End Try
    End Sub

    Private Sub EditRegexForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(RegexData))
        ' To read a file, create a StreamReader object.
        Dim path As String
        path = System.IO.Path.GetDirectoryName(
           System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\", "")
        path = path & "\regex.xml"
        If My.Computer.FileSystem.FileExists(path) Then
            Dim myReader As StreamReader = New StreamReader(path)
            SerializedRegexData = mySerializer.Deserialize(myReader)
            myReader.Close()
            Working = True
            TextBoxPattern.Text = SerializedRegexData.Pattern
            TextBoxPattern.DeselectAll()
            TextBoxPattern.SelectionStart = TextBoxPattern.TextLength
            RichTextBoxInput.Text = SerializedRegexData.Input
            TextBoxReplacement.Text = SerializedRegexData.Replace
            Working = False
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub ButtonPaste_Click(sender As System.Object, e As EventArgs) Handles ButtonPaste.Click
        Dim clipboardText As String = My.Computer.Clipboard.GetText()

        If clipboardText.StartsWith("""") AndAlso clipboardText.EndsWith("""") Then
            clipboardText = clipboardText.Remove(0, 1)
            clipboardText = clipboardText.Remove(clipboardText.Length - 1, 1)
            clipboardText = Regex.Replace(clipboardText, """ & _\r\n\s*""", "")
        End If

        TextBoxPattern.Text = clipboardText
    End Sub

    Private Sub ButtonCopy_Click(sender As Object, e As EventArgs) Handles ButtonCopy.Click
        Dim clipboardText As String = TextBoxPattern.Text

        clipboardText = """" & clipboardText & """"

        Dim index As Integer = 80

        While clipboardText.Length > index
            clipboardText = clipboardText.Insert(index, """ & _" & vbCrLf & """")
            index = index + 88
        End While

        My.Computer.Clipboard.SetText(clipboardText)
    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        ' Specify that the link was visited.
        Me.LinkLabel1.LinkVisited = True

        ' Navigate to a URL.
        System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/ae5bf541(v=vs.100).aspx")
    End Sub

    Private Sub ButtonClose_Click(sender As System.Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonQuickReference_Click(sender As System.Object, e As EventArgs) Handles ButtonQuickReference.Click
        Dim RegexSyntaxQuickReference As New Form With {.Text = "RegEx Syntax Form", .Height = 600, .Width = 800, .AutoScroll = True}
        Dim QuickReference As New List(Of String())
        Dim SectionLabel As Label = Nothing
        Dim SectionListView As ListView = Nothing
        Dim CurrentRow As String() = Nothing
        Dim CurrentSection As String = ""
        Dim PreviousSection As String = ""
        Dim HeightOffest As Integer = 20

        Call InitializeRegexQuickReference(QuickReference)

        Dim ienum As IEnumerator = QuickReference.GetEnumerator

        ' Itterate quick reference list
        While ienum.MoveNext
            CurrentRow = ienum.Current
            CurrentSection = CurrentRow(0)

            ' New section?
            If PreviousSection <> CurrentSection Then
                SectionLabel = New Label With {.Text = CurrentSection}

                SectionListView = New ListView With {.View = View.Details,
                                                    .Height = 225,
                                                    .Width = RegexSyntaxQuickReference.ClientSize.Width - 10 - SystemInformation.VerticalScrollBarWidth,
                                                    .Scrollable = True,
                                                    .GridLines = True,
                                                    .Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)}

                Dim ColumnWidth As Integer = CInt(Me.Width / CurrentRow.Count)

                For NextColumn As Integer = 1 To CurrentRow.Count - 1
                    SectionListView.Columns.Add(CurrentRow(NextColumn), ColumnWidth)
                Next

                RegexSyntaxQuickReference.Controls.Add(SectionLabel)
                RegexSyntaxQuickReference.Controls.Add(SectionListView)

                HeightOffest += 10
                SectionLabel.Location = New System.Drawing.Point(10, HeightOffest)
                HeightOffest += 25
                SectionListView.Location = New System.Drawing.Point(10, HeightOffest)
                HeightOffest = SectionListView.Location.Y + SectionListView.Height

                PreviousSection = CurrentSection
            Else
                Dim lvi As New ListViewItem(CurrentRow(1))
                For NextColumn As Integer = 2 To CurrentRow.Count - 1
                    lvi.SubItems.Add(CurrentRow(NextColumn))
                Next
                SectionListView.Items.Add(lvi)
            End If
        End While

        RegexSyntaxQuickReference.StartPosition = FormStartPosition.CenterParent
        RegexSyntaxQuickReference.ShowDialog()
        RegexSyntaxQuickReference.Dispose()
        RegexSyntaxQuickReference = Nothing
    End Sub

    Public Sub InitializeRegexQuickReference(ByRef QuickReference As List(Of String()))
        Dim Section As String = ""

        Section = RegexSection.Character_Escapes.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Escaped Character", "Description", "Pattern", "Matches"})
        QuickReference.Add({Section, "\a", "Matches a bell character, \u0007.", "\a", """\u0007"" in ""Error!"" + '\u0007'"})
        QuickReference.Add({Section, "\b", "In a character class, matches a backspace, \u0008.", "[\b]{3,}", """\b\b\b\b"" in ""\b\b\b\b"""})
        QuickReference.Add({Section, "\t", "Matches a tab, \u0009.", "(\w+)\t", """item1\t"", ""item2\t"" in ""item1\titem2\t"""})
        QuickReference.Add({Section, "\r", "Matches a carriage return, \u000D. (\r is not equivalent to the newline character, \n.)", "\r\n(\w+)", """\r\nThese"" in ""\r\nThese are\ntwo lines."""})
        QuickReference.Add({Section, "\v", "Matches a vertical tab, \u000B.", "[\v]{2,}", """\v\v\v"" in ""\v\v\v"""})
        QuickReference.Add({Section, "\f", "Matches a form feed, \u000C.", "[\f]{2,}", """\f\f\f"" in ""\f\f\f"""})
        QuickReference.Add({Section, "\n", "Matches a new line, \u000A.", "\r\n(\w+)", """\r\nThese"" in ""\r\nThese are\ntwo lines."""})
        QuickReference.Add({Section, "\e", "Matches an escape, \u001B.", "\e", """\x001B"" in ""\x001B"""})
        QuickReference.Add({Section, "\ nnn", "Uses octal representation to specify a character (nnn consists of two or three digits).", "\w\040\w", """a b"", ""c d"" in ""a bc d"""})
        QuickReference.Add({Section, "\x nn", "Uses hexadecimal representation to specify a character (nn consists of exactly two digits).", "\w\x20\w", """a b"", ""c d"" in ""a bc d"""})
        QuickReference.Add({Section, "\c X"", ""\c x", "Matches the ASCII control character that is specified by X or x, where X or x is the letter of the control character.", "\cC", """\x0003"" in ""\x0003"" (Ctrl-C)"})
        QuickReference.Add({Section, "\u nnnn", "Matches a Unicode character by using hexadecimal representation (exactly four digits, as represented by nnnn).", "\w\u0020\w", """a b"", ""c d"" in ""a bc d"""})
        QuickReference.Add({Section, "\", "When followed by a character that is not recognized as an escaped character in this and other tables in this topic, matches that character. For example, \* is the same as \x2A, and \. is the same as \x2E. This allows the regular expression engine to disambiguate language elements (such as * or ?) and character literals (represented by \* or \?).", "\d+[\+-x\*]\d+\d+[\+-x\*\d+", """2+2"" and ""3*9"" in ""(2+2) * 3*9"""})

        Section = RegexSection.Character_Classes.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Character Class", "Description", "Pattern", "Matches"})
        QuickReference.Add({Section, "[ character_group ]", "Matches any single character in character_group. By default, the match is case-sensitive.", "[ae]", """a"" in ""gray"", ""a"", ""e"" in ""lane"""})
        QuickReference.Add({Section, "[^ character_group ]", "Negation: Matches any single character that is not in character_group. By default, characters in character_group are case-sensitive.", "[^aei]", """r"", ""g"", ""n"" in ""reign"""})
        QuickReference.Add({Section, "[ first - last ]", "Character range: Matches any single character in the range from first to last.", "[A-Z]", """A"", ""B"" in ""AB123"""})
        QuickReference.Add({Section, ".", "Wildcard: Matches any single character except \n. To match a literal period character (. or \u002E), you must precede it with the escape character (\.).", "a.e()", """ave"" in ""nave"", ""ate"" in ""water"""})
        QuickReference.Add({Section, "\p{ name }", "Matches any single character in the Unicode general category or named block specified by name.", "\p{Lu}, \p{IsCyrillic}", """C"", ""L"" in ""City Lights"", ""Д"", ""Ж"" in ""ДЖem"""})
        QuickReference.Add({Section, "\P{ name }", "Matches any single character that is not in the Unicode general category or named block specified by name.", "\P{Lu}, \P{IsCyrillic}", """i"", ""t"", ""y"" in ""City"", ""e"", ""m"" in ""ДЖem"""})
        QuickReference.Add({Section, "\w", "Matches any word character.", "\w", """I"", ""D"", ""A"", ""1"", ""3"" in ""ID A1.3"""})
        QuickReference.Add({Section, "\W", "Matches any non-word character.", "\W", """ "", ""."" in ""ID A1.3"""})
        QuickReference.Add({Section, "\s", "Matches any white-space character.", "\w\s", """D "" in ""ID A1.3"""})
        QuickReference.Add({Section, "\S", "Matches any non-white-space character.", "\s\S", """ _"" in ""int __ctr"""})
        QuickReference.Add({Section, "\d", "Matches any decimal digit.", "\d", """4"" in ""4 = IV"""})
        QuickReference.Add({Section, "\D", "Matches any character other than a decimal digit.", "\D", """ "", ""="", "" "", ""I"", ""V"" in ""4 = IV"""})

        Section = RegexSection.Anchors.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Assertion", "Description", "Pattern", "Matches"})
        QuickReference.Add({Section, "^", "The match must start at the beginning of the string or line.", "^\d{3}", """901"" in ""901-333-"""})
        QuickReference.Add({Section, "$", "The match must occur at the end of the string or before \n at the end of the line or string.", "-\d{3}$", """-333"" in ""-901-333"""})
        QuickReference.Add({Section, "\A", "The match must occur at the start of the string.", "\A\d{3}", """901"" in ""901-333-"""})
        QuickReference.Add({Section, "\Z", "The match must occur at the end of the string or before \n at the end of the string.", "-\d{3}\Z", """-333"" in ""-901-333"""})
        QuickReference.Add({Section, "\z", "The match must occur at the end of the string.", "-\d{3}\z", """-333"" in ""-901-333"""})
        QuickReference.Add({Section, "\G", "The match must occur at the point where the previous match ended.", "\G\(\d\)", """(1)"", ""(3)"", ""(5)"" in ""(1)(3)(5)[7](9)"""})
        QuickReference.Add({Section, "\b", "The match must occur on a boundary between a \w (alphanumeric) and a \W (nonalphanumeric) character.", "\b\w+\s\w+\b", """them theme"", ""them them"" in ""them theme them them"""})
        QuickReference.Add({Section, "\B", "The match must not occur on a \b boundary.", "\Bend\w*\b", """ends"", ""ender"" in ""end sends endure lender"""})

        Section = RegexSection.GroupingConstructs.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Grouping Construct", "Description", "Pattern", "Matches"})
        QuickReference.Add({Section, "( subexpression )", "Captures the matched subexpression and assigns it a one-based ordinal number.", "(\w)\1", """ee"" in ""deep"""})
        QuickReference.Add({Section, "(?< name > subexpression)", "Captures the matched subexpression into a named group.", "(?<double>\w)\k<double>", """ee"" in ""deep"""})
        QuickReference.Add({Section, "(?< name1 - name2 > subexpression)", "Defines a balancing group definition. For more information, see the ""Balancing Group Definition"" section in Grouping Constructs in Regular Expressions.", "(((?'Open'\()[^\(\)]*)+((?'Close-Open'\))[^\(\)]*)+)*(?(Open)(?!))$", """((1-3)*(3-1))"" in ""3+2^((1-3)*(3-1))"""})
        QuickReference.Add({Section, "(?: subexpression)", "Defines a noncapturing group.", "Write(?:Line)?", """WriteLine"" in ""Console.WriteLine()"", ""Write"" in ""Console.Write(value)"""})
        QuickReference.Add({Section, "(?imnsx-imnsx: subexpression)", "Applies or disables the specified options within subexpression. For more information, see Regular Expression Options.", "A\d{2}(?i:\w+)\b", """A12xl"", ""A12XL"" in ""A12xl A12XL a12xl"""})
        QuickReference.Add({Section, "(?= subexpression)", "Zero-width positive lookahead assertion.", "\w+(?=\.)", """is"", ""ran"", and ""out"" in ""He is. The dog ran. The sun is out."""})
        QuickReference.Add({Section, "(?! subexpression)", "Zero-width negative lookahead assertion.", "\b(?!un)\w+\b", """sure"", ""used"" in ""unsure sure unity used"""})
        QuickReference.Add({Section, "(?<= subexpression)", "Zero-width positive lookbehind assertion.", "(?<=19)\d{2}\b", """99"", ""50"", ""05"" in ""1851 1999 1950 1905 2003"""})
        QuickReference.Add({Section, "(?<! subexpression)", "Zero-width negative lookbehind assertion.", "(?<!19)\d{2}\b", """51"", ""03"" in ""1851 1999 1950 1905 2003"""})
        QuickReference.Add({Section, "(?> subexpression)", "Nonbacktracking (or ""greedy"") subexpression.", "[13579](?>A+B+)", """1ABB"", ""3ABB"", and ""5AB"" in ""1ABB 3ABBC 5AB 5AC"""})

        Section = RegexSection.Quantifiers.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Quantifier", "Description", "Pattern", "Matches"})
        QuickReference.Add({Section, "*", "Matches the previous element zero or more times.", "\d*\.\d", """.0"", ""19.9"", ""219.9"""})
        QuickReference.Add({Section, "+", "Matches the previous element one or more times.", """be+""", """bee"" in ""been"", ""be"" in ""bent"""})
        QuickReference.Add({Section, "?", "Matches the previous element zero or one time.", """rai?n""", """ran"", ""rain"""})
        QuickReference.Add({Section, "{ n }", "Matches the previous element exactly n times.", """,\d{3}""", """,043"" in ""1,043.6"", "",876"", "",543"", and "",210"" in ""9,876,543,210"""})
        QuickReference.Add({Section, "{ n ,}", "Matches the previous element at least n times.", """\d{2,}""", """166"", ""29"", ""1930"""})
        QuickReference.Add({Section, "{ n , m }", "Matches the previous element at least n times, but no more than m times.", """\d{3,5}""", """166"", ""17668"", ""19302"" in ""193024"""})
        QuickReference.Add({Section, "*?", "Matches the previous element zero or more times, but as few times as possible.", "\d*?\.\d", """.0"", ""19.9"", ""219.9"""})
        QuickReference.Add({Section, "+?", "Matches the previous element one or more times, but as few times as possible.", """be+?""", """be"" in ""been"", ""be"" in ""bent"""})
        QuickReference.Add({Section, "??", "Matches the previous element zero or one time, but as few times as possible.", """rai??n""", """ran"", ""rain"""})
        QuickReference.Add({Section, "{ n }?", "Matches the preceding element exactly n times.", """,\d{3}?""", """,043"" in ""1,043.6"", "",876"", "",543"", and "",210"" in ""9,876,543,210"""})
        QuickReference.Add({Section, "{ n ,}?", "Matches the previous element at least n times, but as few times as possible.", """\d{2,}?""", """166"", ""29"", ""1930"""})
        QuickReference.Add({Section, "{ n , m }?", "Matches the previous element between n and m times, but as few times as possible.", """\d{3,5}?""", """166"", ""17668"", ""193"", ""024"" in ""193024"""})

        Section = RegexSection.Backreference_Constructs.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Backreference Construct", "Description", "Pattern", "Matches"})
        QuickReference.Add({Section, "\ number", "Backreference. Matches the value of a numbered subexpression.", "(\w)\1", """ee"" in ""seek"""})
        QuickReference.Add({Section, "\k< name >", "Named backreference. Matches the value of a named expression.", "(?<char>\w)\k<char>", """ee"" in ""seek"""})

        Section = RegexSection.Alternation_Constructs.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Alternation Construct", "Description", "Pattern", "Matches"})
        QuickReference.Add({Section, "|", "Matches any one element separated by the vertical bar (|) character.", "th(e|is|at)", """the"", ""this"" in ""this is the day. """})
        QuickReference.Add({Section, "(?( expression ) yes | no )", "Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.", "(?(A)A\d{2}\b|\b\d{3}\b)", """A10"", ""910"" in ""A10 C103 910"""})
        QuickReference.Add({Section, "(?( name ) yes | no )", "Matches yes if name, a named or numbered capturing group, has a match; otherwise, matches the optional no.", "(?<quoted>"")?(?(quoted).+?""|\S+\s)", "Dogs.jpg, ""Yiska playing.jpg"" in ""Dogs.jpg ""Yiska playing.jpg"""""})

        Section = RegexSection.Substitutions.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Character", "Description", "Pattern", "Replacement Pattern", "Input String", "Result String"})
        QuickReference.Add({Section, "$ number", "Substitutes the substring matched by group number.", "\b(\w+)(\s)(\w+)\b", "$3$2$1", """one two""", """two one"""})
        QuickReference.Add({Section, "${ name }", "Substitutes the substring matched by the named group name.", "\b(?<word1>\w+)(\s)(?<word2>\w+)\b", "${word2} ${word1}", """one two""", """two one"""})
        QuickReference.Add({Section, "$$", "Substitutes a literal ""$"".", "\b(\d+)\s?USD", "$$$1", """103 USD""", """$103"""})
        QuickReference.Add({Section, "$&", "Substitutes a copy of the whole match.", "(\$*(\d*(\.+\d+)?){1})", "**$&", """$1.30""", """**$1.30**"""})
        QuickReference.Add({Section, "$`", "Substitutes all the text of the input string before the match.", "B+", "$`", """AABBCC""", """AAAACC"""})
        QuickReference.Add({Section, "$'", "Substitutes all the text of the input string after the match.", "B+", "$'", """AABBCC""", """AACCCC"""})
        QuickReference.Add({Section, "$+", "Substitutes the last group that was captured.", "B+(C+)", "$+", """AABBCCDD""", "AACCDD()"})
        QuickReference.Add({Section, "$_", "Substitutes the entire input string.", "B+", "$_", """AABBCC""", """AAAABBCCCC"""})

        Section = RegexSection.Regular_Expression_Options.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Option", "Description", "Pattern", "Matches"})
        QuickReference.Add({Section, "i", "Use case-insensitive matching.", "\b(?i)a(?-i)a\w+\b", """aardvark"", ""aaaAuto"" in ""aardvark AAAuto aaaAuto Adam breakfast"""})
        QuickReference.Add({Section, "m", "Use multiline mode. ^ and $ match the beginning and end of a line, instead of the beginning and end of a string.", "For an example, see the ""Multiline Mode"" section in Regular Expression Options.", ""})
        QuickReference.Add({Section, "n", "Do not capture unnamed groups.", "For an example, see the ""Explicit Captures Only"" section in Regular Expression Options.", ""})
        QuickReference.Add({Section, "s", "Use single-line mode.", "For an example, see the ""Single-line Mode"" section in Regular Expression Options.", ""})
        QuickReference.Add({Section, "x", "Ignore unescaped white space in the regular expression pattern.", "\b(?x) \d+ \s \w+", """1 aardvark"", ""2 cats"" in ""1 aardvark 2 cats IV centurions"""})

        Section = RegexSection.Miscellaneous_Constructs.ToString.Replace("_", " ")
        QuickReference.Add({Section, "Construct", "Definition", "example"})
        QuickReference.Add({Section, "(?imnsx-imnsx)", "Sets or disables options such as case insensitivity in the middle of a pattern. For more information, see Regular Expression Options.", "\bA(?i)b\w+\b matches ""ABA"", ""Able"" in ""ABA Able Act"""})
        QuickReference.Add({Section, "(?# comment)", "Inline comment. The comment ends at the first closing parenthesis.", "\bA(?#Matches words starting with A)\w+\b"})
        QuickReference.Add({Section, "# [to end of line]", "X-mode comment. The comment starts at an unescaped # and continues to the end of the line.", "(?x)\bA\w+\b#Matches words starting with A"})
    End Sub

End Class
