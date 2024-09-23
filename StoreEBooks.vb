Imports System
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common
'Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions


Public Class StoreEBooks

    Private MyYear As String
    Private ds, dsvoc, dsvoc2, dsvocuk, ds_server, ds_categorie, ds_opbrengsten, ds_totals, ds_copy As New DataSet
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



    Private Sub Poems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim srv, user, pwd, db, mysql, s1, type, mysqlcat, mysqlcat2 As String
        Dim mystring As String

        Me.Location = New Point(0, 0)

        InitialDir = CurDir()
        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        ds.ReadXml(CurDir() + "\xml\boekingen2.xml")
        ds_copy.ReadXml(CurDir() + "\xml\boekingen2.xml")


        ds_totals.ReadXml(CurDir() + "\xml\jaaranalyse.xml")
        ds.Tables(0).Rows.RemoveAt(0)
        ds_copy.Tables(0).Rows.RemoveAt(0)


        Me.ds.Tables(0).DefaultView.AllowNew = True
        Me.ds.Tables(0).DefaultView.AllowDelete = True
        Me.ds_copy.Tables(0).DefaultView.AllowNew = True
        Me.ds_copy.Tables(0).DefaultView.AllowDelete = True


        Me.DataGrid1.DataSource = Me.ds.Tables(0)
        TextBox1.HideSelection = False

        Me.FormatColumnHeaders()
        Me.GetEBooks()
        Me.ShowEBook()


    End Sub

    Private Sub FormatColumnHeaders()
        Dim ts As New DataGridTableStyle
        Dim cs0, cs1, cs2, cs3, cs4, cs5, cs6, cs7, cs8, cs9, cs10, cs11 As DataGridTextBoxColumn

        ts.MappingName = MyTable

        cs0 = New DataGridTextBoxColumn
        cs0.MappingName = "Nr"
        cs0.HeaderText = "Nr:"
        cs0.Width = 0
        ts.GridColumnStyles.Add(cs0)

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
        ds_copy.Reset()

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
            da.Fill(ds_copy, MyTable)

            Me.ds.Tables(0).DefaultView.AllowNew = True
            Me.ds.Tables(0).DefaultView.AllowDelete = True
            Me.ds_copy.Tables(0).DefaultView.AllowNew = True
            Me.ds_copy.Tables(0).DefaultView.AllowDelete = True

            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.AllowSorting = False

            tbAantal.Text = ds.Tables(0).Rows.Count


        Catch ex As Exception
            MsgBox(ex.Message)


        Finally
            myconnection1.Close()

        End Try

    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.ShowEBook()
        Me.ShowEBook2()


    End Sub

    Private Sub ShowEBook2()

        Dim srv, user, pwd, db, mysql, type, nullstr, Coin, MyDateStr, mystring, my_sql, Poem, mytitle As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim Poetnr As Integer
        Dim str, str2, str3, str4, strout, pictname, pictname2, fnam, fnam2, foldername, folderindex, cardname, cardname2 As String
        Dim rowid, booknr, foldernr As Integer


        rowid = DataGrid1.CurrentRowIndex

        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        Poem = TextBox2.Text
        'get poem id
        Dim Rownum As Long
        Rownum = DataGrid1.CurrentRowIndex
        Poetnr = ds.Tables(0).Rows(Rownum).Item(0)
        mytitle = ds.Tables(0).Rows(Rownum).Item(1)

        my_sql = "select OWN from EbooksProse where Nr = " + Poetnr.ToString()
        mycommand.CommandText = my_sql
        Dim sqlResult As Object = mycommand.ExecuteScalar()
        If sqlResult Is Nothing Or sqlResult Is DBNull.Value Then
            str = ""
        Else
            str = sqlResult
        End If

        my_sql = "select O2 from EbooksProse where Nr = " + Poetnr.ToString()
        mycommand.CommandText = my_sql
        Dim sqlResult2 As Object = mycommand.ExecuteScalar()
        If sqlResult2 Is Nothing Or sqlResult2 Is DBNull.Value Then
            str2 = ""
        Else
            str2 = sqlResult2
        End If

        my_sql = "select O3 from EbooksProse where Nr = " + Poetnr.ToString()
        mycommand.CommandText = my_sql
        Dim sqlResult3 As Object = mycommand.ExecuteScalar()
        If sqlResult3 Is Nothing Or sqlResult3 Is DBNull.Value Then
            str3 = ""
        Else
            str3 = sqlResult3.ToString()
        End If

        my_sql = "select O4 from EbooksProse where Nr = " + Poetnr.ToString()
        mycommand.CommandText = my_sql
        Dim sqlResult4 As Object = mycommand.ExecuteScalar()
        If sqlResult4 Is Nothing Or sqlResult4 Is DBNull.Value Then
            str4 = ""
        Else
            str4 = sqlResult4.ToString()
        End If


        TextBox2.Text = str + str2 + str3 + str4

        myconnection1.Close()


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

            rowid = DataGrid1.CurrentRowIndex
            ds_server.ReadXml(InitialDir + "\xml\server.xml")
            ' Open connection
            type = ds_server.Tables(0).Rows(0).Item(0)
            srv = ds_server.Tables(0).Rows(0).Item(1)
            user = ds_server.Tables(0).Rows(0).Item(2)
            pwd = ds_server.Tables(0).Rows(0).Item(3)
            db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

            mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
            myconnection1 = New OleDbConnection(mystring)
            mycommand = New OleDbCommand
            mycommand.Connection = myconnection1
            myconnection1.Open()

            Poem = TextBox1.Text

            'get poem id
            Dim Rownum As Long
            Rownum = DataGrid1.CurrentRowIndex
            mytitle = ds.Tables(0).Rows(Rownum).Item(1)

            my_sql = "select Tekst from EbooksProse where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            Dim sqlResult As Object = mycommand.ExecuteScalar()
            If sqlResult Is Nothing Or sqlResult Is DBNull.Value Then
                str = ""
            Else
                str = sqlResult
            End If

            my_sql = "select T2 from EbooksProse where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            Dim sqlResult2 As Object = mycommand.ExecuteScalar()
            If sqlResult2 Is Nothing Or sqlResult2 Is DBNull.Value Then
                str2 = ""
            Else
                str2 = sqlResult2
            End If

            my_sql = "select T3 from EbooksProse where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            Dim sqlResult3 As Object = mycommand.ExecuteScalar()
            If sqlResult3 Is Nothing Or sqlResult3 Is DBNull.Value Then
                str3 = ""
            Else
                str3 = sqlResult3.ToString()
            End If

            my_sql = "select T4 from EbooksProse where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            Dim sqlResult4 As Object = mycommand.ExecuteScalar()
            If sqlResult4 Is Nothing Or sqlResult4 Is DBNull.Value Then
                str4 = ""
            Else
                str4 = sqlResult4.ToString()
            End If

            TextBox1.Text = str + str2 + str3 + str4

            myconnection1.Close()


        Catch ex As Exception


        End Try





    End Sub

    Public Function ChangeLinefeeds(ByVal strin As String) As String
        Dim strout, strhelp, strlf, strlf2 As String
        Dim ind, loc1, loc2, found As Integer
        Dim endstring As Boolean = False

        strhelp = strin
        strlf = vbCrLf + vbCrLf
        strlf2 = vbCrLf + vbCrLf + vbCrLf
        ind = 0

        While endstring = False
            If strhelp.IndexOf(strlf2, ind) > 0 Then
                loc1 = strhelp.IndexOf(strlf2, ind)
                strout = strout + strhelp.Substring(ind, loc1 - ind) + Environment.NewLine + Environment.NewLine
                ind = loc1 + 6
            Else
                strout = strout + strhelp.Substring(ind, strhelp.Length - ind) + Environment.NewLine
                endstring = True
            End If
        End While

        Return strout

    End Function



    Private Sub b1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b1.Click

        MyTable = cbSeries.Text
        Me.FormatColumnHeaders()
        Me.GetEBooks()

    End Sub


    Private Function Update1Column() As Integer

        Dim srv, user, pwd, db, mysql, type, nullstr, Coin, MyDateStr, mystring, my_sql, Poem, mytitle As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim Poetnr As Integer

        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        Poem = TextBox1.Text
        'get poem id
        Dim Rownum As Long
        Rownum = DataGrid1.CurrentRowIndex
        'Poetnr = ds.Tables(0).Rows(Rownum).Item(0)
        mytitle = ds.Tables(0).Rows(Rownum).Item(1)

        Try
            my_sql = "update EbooksProse set Tekst = '" + Poem + "' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            Return 0

        Catch ex As Exception

            Return 1

        Finally
            myconnection1.Close()

        End Try





    End Function

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim rc As Integer

        Me.SetQuotes()
        rc = Me.Update1Column()
        If rc = 1 Then
            rc = Me.Update2Columns()
            If rc = 1 Then
                rc = Me.Update4Columns()
                If rc = 1 Then
                    MsgBox("This EBook is to large to be stored !!!")
                Else
                    MsgBox("succeeded")
                End If
            Else
            End If
        Else
        End If

    End Sub

    Private Sub SetQuotes()

        Dim str, str2 As String
        Dim endstring = False
        Dim ind, ind2, start1, start2 As Integer

        ind = 0
        str = TextBox1.Text
        'str = TextBox2.Text
        While endstring = False
            ind2 = str.IndexOf("'", start1)
            If ind2 > 0 Then
                str2 = str2 + str.Substring(ind, ind2 - ind + 1) + "'"
                'start2 = ind2 + 1
                'ind2 = str.IndexOf("</span>", start2)
                ind = ind2 + 1
                start1 = ind
            Else
                str2 = str2 + str.Substring(ind, str.Length - ind)
                endstring = True
            End If

        End While

        TextBox1.Text = str2


    End Sub
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click

        Me.SetQuotes()


    End Sub

    Private Function Update2Columns() As Integer

        Dim str, str1, str2, str3, str4 As String
        Dim endstring = False
        Dim ind, ind2, start1, start2 As Integer
        Dim srv, user, pwd, db, mysql, type, nullstr, Coin, MyDateStr, mystring, my_sql, Poem, mytitle As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim Poetnr As Integer


        str = TextBox1.Text
        ind = str.Length / 2
        str1 = str.Substring(0, ind)
        'str2 = str.Substring(ind - 1, ind)
        str2 = str.Substring(ind, str.Length - ind - 1)

        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        'get poem id
        Dim Rownum As Long
        Rownum = DataGrid1.CurrentRowIndex
        'Poetnr = ds.Tables(0).Rows(Rownum).Item(0)
        mytitle = ds.Tables(0).Rows(Rownum).Item(1)


        Try
            my_sql = "update EbooksProse set Tekst = '" + str1 + "' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T2 = '" + str2 + "' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()
            Return 0

        Catch ex As Exception

            Return 1
        Finally
            myconnection1.Close()

        End Try



    End Function

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click

        Me.Update2Columns()

    End Sub

    Private Function Update4Columns() As Integer

        Dim str, str1, str2, str3, str4 As String
        Dim endstring = False
        Dim ind, ind2, start1, start2 As Integer
        Dim srv, user, pwd, db, mysql, type, nullstr, Coin, MyDateStr, mystring, my_sql, Poem, mytitle As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim Poetnr As Integer


        str = TextBox1.Text
        ind = str.Length / 4
        str1 = str.Substring(0, ind)
        str2 = str.Substring(ind, ind)
        str3 = str.Substring(ind + ind, ind)
        'str4 = str.Substring(ind + ind + ind, ind - 2)
        str4 = str.Substring(ind + ind + ind, str.Length - ind - ind - ind - 1)


        If ind + ind + ind + ind = str.Length Then

        ElseIf ind + ind + ind + ind = str.Length - 1 Then

        ElseIf ind + ind + ind + ind = str.Length - 2 Then

        ElseIf ind + ind + ind + ind = str.Length - 3 Then

        End If


        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        'get poem id
        Dim Rownum As Long
        Rownum = DataGrid1.CurrentRowIndex
        'Poetnr = ds.Tables(0).Rows(Rownum).Item(0)
        mytitle = ds.Tables(0).Rows(Rownum).Item(1)

        Try
            my_sql = "update EbooksProse set Tekst = '" + str1 + "' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T2 = '" + str2 + "' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T3 = '" + str3 + "' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T4 = '" + str4 + "' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            Return 0

        Catch ex As Exception

            Return 1


        Finally
            myconnection1.Close()

        End Try

    End Function


    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click

        Me.Update4Columns()

    End Sub

    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs)

    End Sub

    Private Sub cbUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click

        Dim str, str2 As String
        Dim endstring = False
        Dim ind, ind2, start1, start2 As Integer

        ind = 0
        str = TextBox2.Text
        'str = TextBox2.Text
        While endstring = False
            ind2 = str.IndexOf("'", start1)
            If ind2 > 0 Then
                str2 = str2 + str.Substring(ind, ind2 - ind + 1) + "'"
                'start2 = ind2 + 1
                'ind2 = str.IndexOf("</span>", start2)
                ind = ind2 + 1
                start1 = ind
            Else
                str2 = str2 + str.Substring(ind, str.Length - ind)
                endstring = True
            End If

        End While

        TextBox2.Text = str2


    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click

        Dim srv, user, pwd, db, mysql, type, nullstr, Coin, MyDateStr, mystring, my_sql, Poem As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim Poetnr As Integer

        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        Poem = TextBox2.Text
        'get poem id
        Dim Rownum As Long
        Rownum = DataGrid1.CurrentRowIndex
        Poetnr = ds.Tables(0).Rows(Rownum).Item(0)

        my_sql = "update EbooksProse set OWN = '" + Poem + "' where Nr = " + Poetnr.ToString()


        mycommand.CommandText = my_sql
        mycommand.ExecuteNonQuery()

        myconnection1.Close()


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        TextBox1.Font = New Font("Microsoft Sans Serif", 12)
        TextBox2.Font = New Font("Microsoft Sans Serif", 12)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        TextBox1.Font = New Font("Microsoft Sans Serif", 14)
        TextBox2.Font = New Font("Microsoft Sans Serif", 14)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        TextBox1.Font = New Font("Microsoft Sans Serif", 16)
        TextBox2.Font = New Font("Microsoft Sans Serif", 16)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        TextBox1.Font = New Font("Microsoft Sans Serif", 18)
        TextBox2.Font = New Font("Microsoft Sans Serif", 18)


    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        TextBox1.Font = New Font("Microsoft Sans Serif", 20)
        TextBox2.Font = New Font("Microsoft Sans Serif", 20)



    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TextBox2.Width = 850
        TextPos = TextBox2.Location
        TextBox2.Location = DataGrid1.Location


    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TextBox2.Width = 560
        TextBox2.Location = TextPos

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'TextBox1.TextAlign = HorizontalAlignment.Left
        'TextBox2.TextAlign = HorizontalAlignment.Left

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TextBox2.Width = 400

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TextBox2.Width = 800

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

    End Sub

    Private Sub ClearEBook()

        Dim str, str1, str2, str3, str4 As String
        Dim endstring = False
        Dim ind, ind2, start1, start2 As Integer
        Dim srv, user, pwd, db, mysql, type, nullstr, Coin, MyDateStr, mystring, my_sql, Poem, mytitle As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim Poetnr As Integer


        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        'get poem id
        Dim Rownum As Long
        Rownum = DataGrid1.CurrentRowIndex
        'Poetnr = ds.Tables(0).Rows(Rownum).Item(0)
        mytitle = ds.Tables(0).Rows(Rownum).Item(1)

        Try
            my_sql = "update EbooksProse set Tekst = ' ' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T2 = ' ' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T3 = ' ' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T4 = ' ' where Title = '" + mytitle + "'"
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

        Catch ex As Exception


        Finally
            myconnection1.Close()

        End Try


    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.ClearEBook()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Update4TestColumns()



    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        Me.Close()

    End Sub


    Private Function Update4TestColumns() As Integer

        Dim str, str1, str2, str3, str4 As String
        Dim endstring = False
        Dim ind, ind2, start1, start2 As Integer
        Dim srv, user, pwd, db, mysql, type, nullstr, Coin, MyDateStr, mystring, my_sql, Poem As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim Poetnr As Integer


        str = TextBox1.Text
        ind = str.Length / 4
        str1 = str.Substring(0, ind)
        str2 = str.Substring(ind, ind)
        str3 = str.Substring(ind + ind, ind)
        'str4 = str.Substring(ind + ind + ind, ind - 2)
        str4 = str.Substring(ind + ind + ind, str.Length - ind - ind - ind - 1)

        If ind + ind + ind + ind = str.Length Then

        ElseIf ind + ind + ind + ind = str.Length - 1 Then

        ElseIf ind + ind + ind + ind = str.Length - 2 Then

        ElseIf ind + ind + ind + ind = str.Length - 3 Then

        End If


        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        'get poem id
        Dim Rownum As Long
        Rownum = DataGrid1.CurrentRowIndex
        Poetnr = ds.Tables(0).Rows(Rownum).Item(0)

        Try
            my_sql = "update EbooksProse set Tekst = '" + str1 + "' where Nr = " + Poetnr.ToString()
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T2 = '" + str2 + "' where Nr = " + Poetnr.ToString()
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T3 = '" + str3 + "' where Nr = " + Poetnr.ToString()
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            my_sql = "update EbooksProse set T4 = '" + str4 + "' where Nr = " + Poetnr.ToString()
            mycommand.CommandText = my_sql
            mycommand.ExecuteNonQuery()

            Return 0

        Catch ex As Exception

            Return 1


        Finally
            myconnection1.Close()

        End Try

    End Function



    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        'enter the new row
        Me.DeleteRow()

        Dim myrow As DataRow = Me.ds.Tables(0).Rows(DataGrid1.CurrentRowIndex)
        myrow.Delete()

    End Sub

    Private Sub DeleteRow()

        Dim my_sql As String
        Dim srv, user, pwd, db, type, bookname As String
        Dim mystring As String
        Dim i As Integer
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim str, str2 As String

        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        bookname = ds.Tables(0).Rows(DataGrid1.CurrentRowIndex).Item(1)

        mycommand.Connection = myconnection1
        my_sql = "delete from EbooksProse where Title = '" + bookname + "'"
        mycommand.CommandText = my_sql
        mycommand.ExecuteNonQuery()


    End Sub


    Private Sub Button13_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click

        'update the rows
        Me.UpdateRows()

    End Sub

    Private Sub UpdateRows()
        Dim my_sql As String
        Dim srv, user, pwd, db, type, name, artist, song As String
        Dim mystring As String
        Dim i As Integer
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim str, str2 As String

        ds_server.ReadXml(InitialDir + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = InitialDir + "\" + ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        mycommand.Connection = myconnection1
        ds.AcceptChanges()
        str2 = ""

        For i = 0 To ds.Tables(0).Rows.Count - 1
            If i > ds_copy.Tables(0).Rows.Count - 1 Then

                artist = ds.Tables(0).Rows(i).Item(2).ToString()
                name = ds.Tables(0).Rows(i).Item(1).ToString()

                my_sql = "insert into EbooksProse values ('"
                my_sql = my_sql + artist + "','"
                my_sql = my_sql + name + "','"

                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "','"
                my_sql = my_sql + str2 + "')"



                'my_sql = my_sql + song + "','"
                'my_sql = my_sql + str2 + "','"
                'my_sql = my_sql + str2 + "','"
                'my_sql = my_sql + str2 + "')"

                mycommand.CommandText = my_sql
                mycommand.ExecuteNonQuery()

            End If

        Next



    End Sub

    Private Sub DataGrid1_CurrentCellChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged

        Me.ShowEBook()

    End Sub



    Private Sub DataGrid1_Navigate_1(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub
End Class
