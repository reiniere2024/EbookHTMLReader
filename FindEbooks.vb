Public Class FindEbooks
    Private ds, ds_server As New DataSet
    Private MainDir, MainDrive As String
    Private RootPath As String
    Private RootNode, CurNode As New TreeNode
    Private mystorefolder As String
    Private mycount As Integer
    Private PhotoMap As String = ""


    Private Sub BijwerkenFotoarchief_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim srv, user, pwd, db, mysql, type, cat, catid, catlvl, catpar, mydrive, mydir As String

        'Me.Location = New Point(0, 0)

        'ds.ReadXml(CurDir() + "\xml\program.xml")
        'mydrive = ds.Tables(0).Rows(0).Item(0)
        'mydir = ds.Tables(0).Rows(0).Item(2)
        'mystorefolder = mydrive + "\" + mydir

        mystorefolder = CurDir() + "\EBooks"



        ' get the directory representing this node  
        Dim mNodeDirectory As IO.DirectoryInfo
        mNodeDirectory = New IO.DirectoryInfo(mystorefolder)
        ' add each subdirectory from the file system to the expanding node as a child node  
        For Each mDirectory As IO.DirectoryInfo In mNodeDirectory.GetDirectories
            ' declare a child TreeNode for the next subdirectory  
            Dim mDirectoryNode As New TreeNode
            ' store the full path to this directory in the child TreeNode's Tag property  
            mDirectoryNode.Tag = mDirectory.FullName
            ' set the child TreeNodes's display text  
            mDirectoryNode.Text = mDirectory.Name
            ' add a dummy TreeNode to this child TreeNode to make it expandable  
            mDirectoryNode.Nodes.Add("*DUMMY*")
            ' add this child TreeNode to the expanding TreeNode  
            TV1.Nodes.Add(mDirectoryNode)
        Next

        'Me.LoadNodes()

    End Sub

    Private Sub TV1_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV1.AfterExpand

        If mycount > 0 Then
            TV1.SelectedNode = RootNode
        End If

    End Sub

    Private Sub TV1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles TV1.AfterLabelEdit
        Dim mytext, mydirold, mydirnew, myparent, tvtext, tvpath, myfileold, myfilenew As String
        Dim mDirectoryNode As TreeNode
        Dim rc As Integer

        If e.Label Is Nothing Then
            'geen wijziging
            Return
        End If
        If e.Node.Level = 1 Then  'only update level 1 nodes
            If e.Node.IsExpanded = True Then
                MsgBox("When pictures are shown you cannot change the name !")
                e.CancelEdit = True
                Return
            End If
            mytext = e.Label
            tvtext = e.Node.Text
            tvpath = e.Node.Tag
            mDirectoryNode = e.Node.Parent
            myparent = mDirectoryNode.Tag
            mydirold = myparent + "\" + tvtext
            mydirnew = myparent + "\" + mytext
            IO.Directory.Move(mydirold, mydirnew)
            e.Node.Text = mytext
            e.Node.Tag = mydirnew
        ElseIf e.Node.Level = 2 Then 'photo name update
            'MsgBox(e.Label)
            'MsgBox(e.Node.Text)
            'MsgBox(e.Node.Tag)
            rc = MsgBox("Do you want to update the name of the picture ?", MsgBoxStyle.YesNo)
            If rc = MsgBoxResult.Yes Then
                mDirectoryNode = e.Node.Parent
                myparent = mDirectoryNode.Tag
                mytext = e.Label
                tvtext = e.Node.Text
                myfileold = myparent + "\" + tvtext
                myfilenew = mytext
                My.Computer.FileSystem.RenameFile(myfileold, myfilenew)
                myfilenew = myparent + "\" + mytext
                e.Node.Tag = myfilenew

            Else
                Return
            End If


        End If

    End Sub

    Private Sub TV1_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TV1.BeforeExpand

        mycount = 0
        ' clear the expanding node so we can re-populate it, or else we end up with duplicate nodes  
        e.Node.Nodes.Clear()
        If e.Node.Level = 0 Then  'Map expansie
            ' get the directory representing this node  
            Dim mNodeDirectory As IO.DirectoryInfo
            mNodeDirectory = New IO.DirectoryInfo(e.Node.Tag.ToString)
            ' add each subdirectory from the file system to the expanding node as a child node  
            For Each mDirectory As IO.DirectoryInfo In mNodeDirectory.GetDirectories
                ' declare a child TreeNode for the next subdirectory  
                Dim mDirectoryNode As New TreeNode
                ' store the full path to this directory in the child TreeNode's Tag property  
                mDirectoryNode.Tag = mDirectory.FullName
                ' set the child TreeNodes's display text  
                mDirectoryNode.Text = mDirectory.Name
                ' add a dummy TreeNode to this child TreeNode to make it expandable  
                mDirectoryNode.Nodes.Add("*DUMMY*")
                ' add this child TreeNode to the expanding TreeNode  
                e.Node.Nodes.Add(mDirectoryNode)
            Next

        Else 'Photo expansie
            If e.Node.Level = 1 Then
                Dim mNodeDirectory As IO.DirectoryInfo
                mNodeDirectory = New IO.DirectoryInfo(e.Node.Tag.ToString)
                For Each mFile As IO.FileInfo In mNodeDirectory.GetFiles
                    Dim mFileNode As New TreeNode
                    mFileNode.Tag = mFile.FullName
                    mFileNode.Text = mFile.Name
                    mFileNode.Nodes.Add("*DUMMY*")
                    e.Node.Nodes.Add(mFileNode)
                    mycount = mycount + 1
                    If mycount = 1 Then
                        Rootnode = mFileNode
                    End If
                Next

            End If


        End If

    End Sub

    Private Sub TV1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV1.AfterSelect

    End Sub

    Private Sub TV1_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TV1.BeforeSelect
        Dim mydir As String
        Dim filnam As String
        Dim MyOrigImage, MyImage As Bitmap
        Dim pic_width, pic_height, pb_width, pb_height, new_width, new_height As Integer
        Dim factor, factor1, factor2 As Double
        Dim myurl, text As String

        If e.Node.Level = 2 Then
            'pb_width = pbPhoto.Width
            'pb_height = pbPhoto.Height
            mydir = e.Node.Tag
            text = e.Node.Text

            NovelName = mydir
            TitleText = text


            If IO.File.Exists(mydir) Then

                myurl = mydir
                WebBrowser1.ScriptErrorsSuppressed = True
                WebBrowser1.Url = New System.Uri(myurl)
                WebBrowser1.Visible = True

                'MyOrigImage = New Bitmap(mydir)
                'pic_width = MyOrigImage.Size.Width
                'pic_height = MyOrigImage.Size.Height
                'pbPhoto.Image = MyOrigImage
                'pbPhoto.SizeMode = PictureBoxSizeMode.Normal

            Else
                MsgBox("Photo cannot be shown !")
                Return
            End If



            CurNode = e.Node
            If Not MyOrigImage Is Nothing Then
                MyOrigImage.Dispose()
            End If

        End If


    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mytext, mydirold, mydirnew, myparent, tvtext, tvpath, myfileold, myfilenew As String
        Dim mDirectoryNode As TreeNode
        Dim rc As Integer

        If TV1.SelectedNode.Level = 1 Then 'Map Delete
            rc = MsgBox("Do you want to delete the complete map with photos ?", MsgBoxStyle.YesNo)
            If rc = MsgBoxResult.Yes Then
                myfileold = TV1.SelectedNode.Tag
                'remove physical file
                My.Computer.FileSystem.DeleteDirectory(myfileold, FileIO.DeleteDirectoryOption.DeleteAllContents)
                'remove treenode
                TV1.SelectedNode.Remove()
            Else
                Return
            End If

        ElseIf TV1.SelectedNode.Level = 2 Then 'Photo Delete
            rc = MsgBox("Do you want to delete this picture ?", MsgBoxStyle.YesNo)
            If rc = MsgBoxResult.Yes Then
                myfileold = TV1.SelectedNode.Tag
                'remove physical file
                My.Computer.FileSystem.DeleteFile(myfileold)
                'remove treenode
                TV1.SelectedNode.Remove()
            Else
                Return
            End If
        End If



    End Sub

    Private Sub tbWidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbWidth.TextChanged

        tbHeight.Text = tbWidth.Text

    End Sub


    Private Sub tbHeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbHeight.TextChanged

        tbWidth.Text = tbHeight.Text

    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        Me.Close()

    End Sub

    Private Sub btnEbook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEbook.Click

        'NovelName = cb3.Text
        'NovelText = EBookFolder + "\" + cb3.Text

        Dim myform As New EBooksReader()
        Me.Hide()
        myform.ShowDialog()
        Me.Show()
        'Me.Location = New Point(0, 0)
        Me.Refresh()

        'WebBrowser1.Document.Body.


    End Sub
End Class