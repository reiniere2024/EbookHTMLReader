<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewEbooks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewEbooks))
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.tb2 = New System.Windows.Forms.TextBox
        Me.cb3 = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.cbG = New System.Windows.Forms.CheckBox
        Me.cbF = New System.Windows.Forms.CheckBox
        Me.cbE = New System.Windows.Forms.CheckBox
        Me.cbD = New System.Windows.Forms.CheckBox
        Me.cbC = New System.Windows.Forms.CheckBox
        Me.FBD1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.btnEbook = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(412, 448)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(56, 31)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Close"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button10.Enabled = False
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.Location = New System.Drawing.Point(116, 460)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 31
        Me.Button10.Text = "VlcPlay"
        Me.Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button10.UseVisualStyleBackColor = True
        Me.Button10.Visible = False
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(379, 1)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(89, 26)
        Me.Button5.TabIndex = 30
        Me.Button5.Text = "Movie Map"
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'tb2
        '
        Me.tb2.Location = New System.Drawing.Point(34, 4)
        Me.tb2.Name = "tb2"
        Me.tb2.Size = New System.Drawing.Size(322, 20)
        Me.tb2.TabIndex = 29
        Me.tb2.Visible = False
        '
        'cb3
        '
        Me.cb3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb3.FormattingEnabled = True
        Me.cb3.ItemHeight = 20
        Me.cb3.Location = New System.Drawing.Point(12, 12)
        Me.cb3.Name = "cb3"
        Me.cb3.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.cb3.Size = New System.Drawing.Size(456, 424)
        Me.cb3.TabIndex = 28
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Enabled = False
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(281, 460)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "WMPlay"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Enabled = False
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(35, 460)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "MPlay32"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cbG
        '
        Me.cbG.AutoSize = True
        Me.cbG.Enabled = False
        Me.cbG.Location = New System.Drawing.Point(510, 74)
        Me.cbG.Name = "cbG"
        Me.cbG.Size = New System.Drawing.Size(37, 17)
        Me.cbG.TabIndex = 67
        Me.cbG.Text = "G:"
        Me.cbG.UseVisualStyleBackColor = True
        Me.cbG.Visible = False
        '
        'cbF
        '
        Me.cbF.AutoSize = True
        Me.cbF.Enabled = False
        Me.cbF.Location = New System.Drawing.Point(510, 59)
        Me.cbF.Name = "cbF"
        Me.cbF.Size = New System.Drawing.Size(35, 17)
        Me.cbF.TabIndex = 66
        Me.cbF.Text = "F:"
        Me.cbF.UseVisualStyleBackColor = True
        Me.cbF.Visible = False
        '
        'cbE
        '
        Me.cbE.AutoSize = True
        Me.cbE.Enabled = False
        Me.cbE.Location = New System.Drawing.Point(510, 44)
        Me.cbE.Name = "cbE"
        Me.cbE.Size = New System.Drawing.Size(36, 17)
        Me.cbE.TabIndex = 65
        Me.cbE.Text = "E:"
        Me.cbE.UseVisualStyleBackColor = True
        Me.cbE.Visible = False
        '
        'cbD
        '
        Me.cbD.AutoSize = True
        Me.cbD.Enabled = False
        Me.cbD.Location = New System.Drawing.Point(510, 29)
        Me.cbD.Name = "cbD"
        Me.cbD.Size = New System.Drawing.Size(37, 17)
        Me.cbD.TabIndex = 64
        Me.cbD.Text = "D:"
        Me.cbD.UseVisualStyleBackColor = True
        Me.cbD.Visible = False
        '
        'cbC
        '
        Me.cbC.AutoSize = True
        Me.cbC.Enabled = False
        Me.cbC.Location = New System.Drawing.Point(510, 14)
        Me.cbC.Name = "cbC"
        Me.cbC.Size = New System.Drawing.Size(36, 17)
        Me.cbC.TabIndex = 63
        Me.cbC.Text = "C:"
        Me.cbC.UseVisualStyleBackColor = True
        Me.cbC.Visible = False
        '
        'Button11
        '
        Me.Button11.Enabled = False
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.Location = New System.Drawing.Point(553, 66)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(32, 25)
        Me.Button11.TabIndex = 68
        Me.Button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button11.UseVisualStyleBackColor = True
        Me.Button11.Visible = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button4.Enabled = False
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(197, 460)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 69
        Me.Button4.Text = "SMPlay"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'btnEbook
        '
        Me.btnEbook.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEbook.Location = New System.Drawing.Point(12, 448)
        Me.btnEbook.Name = "btnEbook"
        Me.btnEbook.Size = New System.Drawing.Size(105, 31)
        Me.btnEbook.TabIndex = 268
        Me.btnEbook.Text = "Read EBook"
        Me.btnEbook.UseVisualStyleBackColor = True
        '
        'ViewEbooks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 485)
        Me.Controls.Add(Me.btnEbook)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.tb2)
        Me.Controls.Add(Me.cbG)
        Me.Controls.Add(Me.cb3)
        Me.Controls.Add(Me.cbF)
        Me.Controls.Add(Me.cbE)
        Me.Controls.Add(Me.cbD)
        Me.Controls.Add(Me.cbC)
        Me.Name = "ViewEbooks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RTF EBooks Collection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cb3 As System.Windows.Forms.ListBox
    Friend WithEvents cbG As System.Windows.Forms.CheckBox
    Friend WithEvents cbF As System.Windows.Forms.CheckBox
    Friend WithEvents cbE As System.Windows.Forms.CheckBox
    Friend WithEvents cbD As System.Windows.Forms.CheckBox
    Friend WithEvents cbC As System.Windows.Forms.CheckBox
    Friend WithEvents tb2 As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents FBD1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnEbook As System.Windows.Forms.Button
End Class
