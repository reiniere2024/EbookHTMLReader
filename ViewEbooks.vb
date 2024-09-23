Imports System.Data.SqlClient

Public Class ViewEbooks
    Private d_quote As String = Chr(34)
    Private ds_playlist As New DataSet
    Private s_drive As String
    Private ds1 As New DataSet

    Private VLCPath As String
    Private MPCPath As String
    Private MPLPath As String
    Private SMPath As String

    Private EBookFolder As String


    Private Sub PlayMusic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim srv, user, pwd, db, mystring, mysql, s1 As String
        Dim ds As DataSet
        Dim datemp As New SqlDataAdapter
        Dim dstemp As New DataSet


        EBookFolder = CurDir() + "\EBooks"


        cb3.Items.Clear()
        Me.listfiles("*.*")


    End Sub


    Private Sub listfiles(ByVal pattern As String)
        'Dim pattern As String = "*.*"
        Dim dir_info As New System.IO.DirectoryInfo(EBookFolder)

        Try
            'list files in listbox
            Dim fs_infos() As System.IO.FileInfo = dir_info.GetFiles(pattern)
            For Each fs_info As System.IO.FileInfo In fs_infos
                'lbFiles.Items.Add(fs_info.FullName)
                cb3.Items.Add(fs_info.Name)
            Next fs_info
            fs_infos = Nothing

        Catch ex As Exception

            MsgBox("There are no RTF EBooks availible yet !")

        End Try

    End Sub





    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()

    End Sub


    Private Sub btnEbook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEbook.Click

        NovelName = cb3.Text
        NovelText = EBookFolder + "\" + cb3.Text

        Dim myform As New EBooksReader()
        Me.Hide()
        myform.ShowDialog()
        Me.Show()
        'Me.Location = New Point(0, 0)
        Me.Refresh()


    End Sub
End Class