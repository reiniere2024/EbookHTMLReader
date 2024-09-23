<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewEBooksOld
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewEBooksOld))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.TextBox1 = New System.Windows.Forms.RichTextBox
        Me.tbAantal = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.btn2 = New System.Windows.Forms.Button
        Me.btnEbook = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Button16 = New System.Windows.Forms.Button
        Me.RTE1 = New System.Windows.Forms.RichTextBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(15, 12)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 50
        Me.DataGrid1.Size = New System.Drawing.Size(430, 679)
        Me.DataGrid1.TabIndex = 219
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(458, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(532, 679)
        Me.TextBox1.TabIndex = 263
        Me.TextBox1.Text = ""
        '
        'tbAantal
        '
        Me.tbAantal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbAantal.Location = New System.Drawing.Point(588, 716)
        Me.tbAantal.Name = "tbAantal"
        Me.tbAantal.Size = New System.Drawing.Size(62, 20)
        Me.tbAantal.TabIndex = 265
        Me.tbAantal.Visible = False
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(514, 718)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 264
        Me.Label12.Text = "Amount:"
        Me.Label12.Visible = False
        '
        'btn2
        '
        Me.btn2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn2.Image = CType(resources.GetObject("btn2.Image"), System.Drawing.Image)
        Me.btn2.Location = New System.Drawing.Point(951, 693)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(32, 32)
        Me.btn2.TabIndex = 266
        Me.btn2.Tag = "sluiten"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'btnEbook
        '
        Me.btnEbook.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEbook.Location = New System.Drawing.Point(15, 694)
        Me.btnEbook.Name = "btnEbook"
        Me.btnEbook.Size = New System.Drawing.Size(105, 31)
        Me.btnEbook.TabIndex = 267
        Me.btnEbook.Text = "Read EBook"
        Me.btnEbook.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(596, 700)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(85, 23)
        Me.btnSearch.TabIndex = 268
        Me.btnSearch.Text = "Search"
        Me.btnSearch.Visible = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(149, 702)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(432, 20)
        Me.txtSearch.TabIndex = 269
        Me.txtSearch.Visible = False
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(647, 713)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(49, 23)
        Me.Button16.TabIndex = 270
        Me.Button16.Text = "ALL"
        Me.Button16.Visible = False
        '
        'RTE1
        '
        Me.RTE1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RTE1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTE1.Location = New System.Drawing.Point(15, 12)
        Me.RTE1.Name = "RTE1"
        Me.RTE1.Size = New System.Drawing.Size(975, 679)
        Me.RTE1.TabIndex = 271
        Me.RTE1.Text = ""
        Me.RTE1.Visible = False
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Button9.Location = New System.Drawing.Point(881, 699)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(32, 23)
        Me.Button9.TabIndex = 276
        Me.Button9.Text = "20"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Button8.Location = New System.Drawing.Point(840, 699)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(32, 23)
        Me.Button8.TabIndex = 275
        Me.Button8.Text = "18"
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Button7.Location = New System.Drawing.Point(799, 700)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(32, 23)
        Me.Button7.TabIndex = 274
        Me.Button7.Text = "16"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Button6.Location = New System.Drawing.Point(758, 699)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(32, 23)
        Me.Button6.TabIndex = 273
        Me.Button6.Text = "14"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Button5.Location = New System.Drawing.Point(717, 699)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(32, 23)
        Me.Button5.TabIndex = 272
        Me.Button5.Text = "12"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'ViewEBooks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 727)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.RTE1)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnEbook)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.tbAantal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "ViewEBooks"
        Me.Text = "EBooks DB Text Reader View EBooks"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents TextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents tbAantal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btnEbook As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents RTE1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
