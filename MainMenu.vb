Public Class MainMenu





    Private Sub CardsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardsToolStripMenuItem.Click

        Dim myform As New StoreEBooks()

        myform.MdiParent = Me
        myform.Show()

    End Sub




    Private Sub MainMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub ViewBooksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewBooksToolStripMenuItem.Click

        Dim myform As New ViewEBooksOld()

        myform.MdiParent = Me
        myform.Show()

    End Sub
End Class