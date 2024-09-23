Public Class EBooksReader

    Private start As Integer = 0


    Private Sub EBooksReader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myurl As String

        myurl = NovelName
        WebBrowser1.ScriptErrorsSuppressed = True
        WebBrowser1.Url = New System.Uri(myurl)
        WebBrowser1.Visible = True

        Me.Text = "Reading: " + TitleText


    End Sub


    Private Sub btnEbook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEbook.Click


        NovelName = ""
        Me.Close()



    End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'Dim startindex As Integer = 0
        'Dim indexOfSearchText As Integer = 0
        'Dim mylength As Integer


        'If txtSearch.Text.Length > 0 Then
        '    mylength = RTE1.Text.Length

        '    'startindex = FindMyText(txtSearch.Text.Trim(), start, RTE1.Text.Length)
        '    startindex = FindMyText(txtSearch.Text, start, mylength)
        'End If

        '' If string was found in the RichTextBox, highlight it
        'If startindex >= 0 Then
        '    ' Find the end index. End Index = number of characters in textbox
        '    Dim endindex As Integer = txtSearch.Text.Length
        '    ' Highlight the search string
        '    RTE1.Select(startindex, endindex)
        '    RTE1.Focus()

        '    start = startindex + endindex
        'End If

    End Sub

    Public Function FindMyText(ByVal txtToSearch As String, ByVal searchStart As Integer, ByVal searchEnd As Integer) As Integer
        'Dim indexOfSearchText As Integer = 0

        'If searchStart > 0 AndAlso searchEnd > 0 AndAlso indexOfSearchText >= 0 Then
        '    RTE1.Undo()
        'End If
        'Dim retVal As Integer = -1


        '' A valid starting index should be specified.
        '' if indexOfSearchText = -1, the end of search
        'If searchStart >= 0 AndAlso indexOfSearchText >= 0 Then
        '    ' A valid ending index
        '    If searchEnd > searchStart OrElse searchEnd = -1 Then
        '        ' Find the position of search string in RichTextBox
        '        indexOfSearchText = RTE1.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None)
        '        ' Determine whether the text was found in richTextBox1.
        '        If indexOfSearchText <> -1 Then
        '            ' Return the index to the specified search text.
        '            retVal = indexOfSearchText
        '        End If
        '    End If
        'End If
        'Return retVal

    End Function


    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    '    RTE1.Font = New Font("Microsoft Sans Serif", 12)

    'End Sub

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

    '    RTE1.Font = New Font("Microsoft Sans Serif", 14)

    'End Sub

    'Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

    '    RTE1.Font = New Font("Microsoft Sans Serif", 16)

    'End Sub

    'Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

    '    RTE1.Font = New Font("Microsoft Sans Serif", 18)

    'End Sub

    'Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

    '    RTE1.Font = New Font("Microsoft Sans Serif", 20)

    'End Sub
End Class