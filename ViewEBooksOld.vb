Imports System
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common
'Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions

Public Class ViewEBooksOld

    Public EBookOpened As Boolean = False

    Private MyYear As String
    Private ds, dsvoc, dsvoc2, dsvocuk, ds_server, ds_categorie, ds_opbrengsten, ds_totals As New DataSet
    Private MyCountry As Integer = 0

    Private InitialDir As String = CurDir()
    Private MySearch As String = ""
    Public MyBaseMap As String = "C:\__Karaoke\"

    Public MyMap As String '= "NC\"
    Public MyTable As String = "EbooksProse"
    Public Artist As Integer = 10

    Public MyWords(1000) As Integer '= {0, 4, 11, 13, 22, 27, 29, 38, 42, 49, 51, 60, 65, 67}
    Public MyLengths(1000) As Integer '= {3, 6, 1, 8, 4, 1, 7, 3, 6, 1, 8, 4, 1, 7}
    Public MyTimes() As Integer = {0, 1, 2, 1, 1, 1, 1, 5, 1, 1, 4, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1, 3, 1, 2, 1, 1, 1, 8, 1, 2, 1, 9, 1, 2, 1, 1, 1, 1, 5, 1, 1, 2, 1, 1, 1, 2, 1, 2, 2, 2, 1, 1, 2, 1, 1, 8, 1, 2, 9}

    ' Beegees Holiday: Public MyTimes() As Integer = {28, 2, 1, 1, 14, 1, 1, 12, 2, 1, 1, 14, 1, 1, 10, 2, 3, 1, 2, 8, 1, 1, 4, 2, 2, 6, 2, 1, 2, 1, 4, 4, 3, 6, 3, 9, 2, 1, 1, 4, 4, 2, 4, 1, 1, 2, 2, 8, 1, 2, 1, 2, 2, 4, 2, 2, 2, 2, 2, 2, 10, 3, 1, 2, 2, 4, 4, 3, 1, 2, 2, 6, 1, 1, 4, 2, 2, 4, 1, 7, 1, 12, 2, 2, 1, 1, 2, 4, 2, 1, 2, 2, 3, 2, 8, 2, 2, 1, 1, 2, 4, 2, 1, 2, 2, 3, 2, 8, 2, 3, 1, 2, 2, 4, 4, 3, 1, 2, 2, 6, 1, 1, 4, 2, 2, 4, 1, 7, 1, 11, 2, 1, 1, 8, 4, 2, 1, 1, 12, 1, 2, 1, 2, 2, 4, 2, 2, 2, 1, 1, 11, 2, 3, 1, 2, 8, 1, 1, 4, 2, 2, 6, 2, 1, 2, 1, 4, 4, 3, 6, 3, 9, 2, 2, 1, 1, 2, 4, 2, 1, 1, 2, 3, 2, 8, 2, 2, 1, 1, 2, 4, 2, 1, 1, 2, 3}


    Public CurIndex As Integer = 0
    'Beegees Holiday Public MyInterval As Integer = 279 '278
    Public MyInterval As Integer = 550

    Public TextPos As Point
    Public StartSong As Boolean = True
    Private start As Integer = 0

    Private Sub ViewEBooks_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.Show()


    End Sub

    Private Sub ViewEBooks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim srv, user, pwd, db, mysql, s1, type, mysqlcat, mysqlcat2 As String
        Dim mystring As String

        Me.Location = New Point(0, 0)

        'InitialDir = CurDir()
        'ds_server.ReadXml(CurDir() + "\xml\server.xml")
        'ds.ReadXml(CurDir() + "\xml\boekingen2.xml")
        'ds_totals.ReadXml(CurDir() + "\xml\jaaranalyse.xml")
        'ds.Tables(0).Rows.RemoveAt(0)

        'Me.ds.Tables(0).DefaultView.AllowNew = False
        'Me.ds.Tables(0).DefaultView.AllowDelete = False
        'Me.DataGrid1.DataSource = Me.ds.Tables(0)
        'TextBox1.HideSelection = False

        'Me.FormatColumnHeaders()
        'Me.GetEBooks()

        Me.ShowEBook()


    End Sub


    Private Sub FormatColumnHeaders()
        Dim ts As New DataGridTableStyle
        Dim cs0, cs1, cs2, cs3, cs4, cs5, cs6, cs7, cs8, cs9, cs10, cs11 As DataGridTextBoxColumn

        ts.MappingName = MyTable

        'cs0 = New DataGridTextBoxColumn
        'cs0.MappingName = "Nr"
        'cs0.HeaderText = "Nr:"
        'cs0.Width = 0
        'ts.GridColumnStyles.Add(cs0)

        cs1 = New DataGridTextBoxColumn
        cs1.MappingName = "Author"
        cs1.HeaderText = "Author:"
        cs1.Width = 160
        ts.GridColumnStyles.Add(cs1)

        cs5 = New DataGridTextBoxColumn
        cs5.MappingName = "Title"
        cs5.HeaderText = "Name:"
        cs5.Width = 210
        ts.GridColumnStyles.Add(cs5)

        'cs3 = New DataGridTextBoxColumn
        'cs3.MappingName = "D"
        'cs3.HeaderText = "D:"
        'cs3.Width = 20
        'ts.GridColumnStyles.Add(cs3)

        'cs4 = New DataGridTextBoxColumn
        'cs4.MappingName = "N"
        'cs4.HeaderText = "N:"
        'cs4.Width = 20
        'ts.GridColumnStyles.Add(cs4)

        'cs6 = New DataGridTextBoxColumn
        'cs6.MappingName = "M"
        'cs6.HeaderText = "M:"
        'cs6.Width = 20
        'ts.GridColumnStyles.Add(cs6)

        'cs7 = New DataGridTextBoxColumn
        'cs7.MappingName = "G"
        'cs7.HeaderText = "G:"
        'cs7.Width = 20
        'ts.GridColumnStyles.Add(cs7)

        ''cs8 = New DataGridTextBoxColumn
        ''cs8.MappingName = "B"
        ''cs8.HeaderText = "B:"
        ''cs8.Width = 20
        ''ts.GridColumnStyles.Add(cs8)

        DataGrid1.TableStyles.Add(ts)


    End Sub


    Private Sub GetEBooks()
        Dim srv, user, pwd, db, mysql, catnum, mymonth, type As String
        Dim mystring, mywhere, MyCat, catnr, myorder, myordercol, strName, txtCol As String
        Dim myconnection1 As DbConnection
        Dim da As DbDataAdapter
        Dim mycommand As DbCommand
        Dim i, j, mytotals As Integer

        ds.Reset()
        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        myorder = " order by Author,title"
        Select Case type
            Case "ACCESS"
                mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
                myconnection1 = New OleDbConnection(mystring)
                'mysql = "select Nr,Title,Tekst,OWN,D,N,M,G,B,POEM,PV from " + MyTable + mywhere + myorder
                'mysql = "select nr,title,tekst,T2,T3,T4,author from " + MyTable + mywhere + myorder
                mysql = "select T,title,Author from " + MyTable + mywhere + myorder

                da = New OleDbDataAdapter
                da.SelectCommand = New OleDbCommand(mysql, myconnection1)
                mycommand = New OleDbCommand

        End Select

        Try
            myconnection1.Open()
            da.Fill(ds, MyTable)

            Me.ds.Tables(0).DefaultView.AllowNew = False
            Me.ds.Tables(0).DefaultView.AllowDelete = False
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.AllowSorting = False

            tbAantal.Text = ds.Tables(0).Rows.Count


        Catch ex As Exception
            MsgBox(ex.Message)


        Finally
            myconnection1.Close()

        End Try

    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged

        Me.ShowEBook()

    End Sub

    Private Sub ShowEBook()
        Dim srv, user, pwd, db, mysql, type, nullstr, Coin, MyDateStr, mystring, my_sql, Poem, mytitle As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim Poetnr As Integer
        Dim str, str2, str3, str4, strout, pictname, pictname2, fnam, fnam2, foldername, folderindex, cardname, cardname2 As String
        Dim rowid, booknr, foldernr As Integer

        Try


        Catch ex As Exception

        End Try





    End Sub


    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click

        Me.Close()

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim startindex As Integer = 0
        Dim indexOfSearchText As Integer = 0
        Dim mylength As Integer


        If txtSearch.Text.Length > 0 Then
            mylength = RTE1.Text.Length

            'startindex = FindMyText(txtSearch.Text.Trim(), start, RTE1.Text.Length)
            startindex = FindMyText(txtSearch.Text, start, mylength)
        End If

        ' If string was found in the RichTextBox, highlight it
        If startindex >= 0 Then
            ' Find the end index. End Index = number of characters in textbox
            Dim endindex As Integer = txtSearch.Text.Length
            ' Highlight the search string
            RTE1.Select(startindex, endindex)
            RTE1.Focus()

            start = startindex + endindex
        End If

    End Sub

    Public Function FindMyText(ByVal txtToSearch As String, ByVal searchStart As Integer, ByVal searchEnd As Integer) As Integer
        Dim indexOfSearchText As Integer = 0

        If searchStart > 0 AndAlso searchEnd > 0 AndAlso indexOfSearchText >= 0 Then
            RTE1.Undo()
        End If
        Dim retVal As Integer = -1


        ' A valid starting index should be specified.
        ' if indexOfSearchText = -1, the end of search
        If searchStart >= 0 AndAlso indexOfSearchText >= 0 Then
            ' A valid ending index
            If searchEnd > searchStart OrElse searchEnd = -1 Then
                ' Find the position of search string in RichTextBox
                indexOfSearchText = RTE1.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None)
                ' Determine whether the text was found in richTextBox1.
                If indexOfSearchText <> -1 Then
                    ' Return the index to the specified search text.
                    retVal = indexOfSearchText
                End If
            End If
        End If
        Return retVal

    End Function


    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click

        Dim Word As String
        Dim color1 As Color
        Dim pos As Integer = 0
        Dim s As String = RTE1.Text
        Dim i As Integer = 0
        Dim StopWhile As Boolean = False

        color1 = Color.Blue
        Word = txtSearch.Text.Trim()
        While Not StopWhile
            Dim j As Integer = s.IndexOf(Word, i)
            If j < 0 Then
                StopWhile = True
            Else
                RTE1.Select(j, Word.Length)
                RTE1.SelectionColor = color1
                RTE1.SelectionFont = New Font("Arial", 12, FontStyle.Bold)

                i = j + 1
            End If
        End While
        RTE1.Select(pos, 0)



    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEbook.Click
        Dim mytitle, myauthor As String

        If EBookOpened = True Then

            txtSearch.Visible = False
            btnSearch.Visible = False
            RTE1.Visible = False
            EBookOpened = False
            btnEbook.Text = "Read EBook"

            Me.Text = "EBooks DB Text Reader View EBooks"
        Else

            Dim Rownum As Long
            Rownum = DataGrid1.CurrentRowIndex
            TitleText = ds.Tables(0).Rows(Rownum).Item(1)
            AuthorText = ds.Tables(0).Rows(Rownum).Item(2)

            'txtSearch.Visible = True
            'btnSearch.Visible = True

            'RTE1.Text = TextBox1.Text
            'RTE1.Visible = True
            'EBookOpened = True
            'btnEbook.Text = "Close EBook"

            'Me.Visible = False

            NovelText = TextBox1.Text
            Dim myform As New EBooksReader()
            Me.Hide()
            myform.ShowDialog()
            Me.Show()
            Me.Location = New Point(0, 0)
            Me.Refresh()


        End If



    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        RTE1.Font = New Font("Microsoft Sans Serif", 12)
        TextBox1.Font = New Font("Microsoft Sans Serif", 12)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        RTE1.Font = New Font("Microsoft Sans Serif", 14)
        TextBox1.Font = New Font("Microsoft Sans Serif", 14)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        RTE1.Font = New Font("Microsoft Sans Serif", 16)
        TextBox1.Font = New Font("Microsoft Sans Serif", 16)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        RTE1.Font = New Font("Microsoft Sans Serif", 18)
        TextBox1.Font = New Font("Microsoft Sans Serif", 18)

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        RTE1.Font = New Font("Microsoft Sans Serif", 20)
        TextBox1.Font = New Font("Microsoft Sans Serif", 20)

    End Sub
End Class