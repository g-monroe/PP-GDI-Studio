<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.name_txt = New System.Windows.Forms.ToolStripTextBox()
        Me.SizeWHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.w_txt = New System.Windows.Forms.ToolStripTextBox()
        Me.h_txt = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.TypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CreateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlTabSelecter = New System.Windows.Forms.TabControl()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(819, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewControlToolStripMenuItem, Me.SaveCodeToolStripMenuItem})
        Me.FileToolStripMenuItem.Image = Global.Mono_Theme_Maker.My.Resources.Resources._1453273099_envelope_2
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewControlToolStripMenuItem
        '
        Me.NewControlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NameToolStripMenuItem, Me.ToolStripSeparator5, Me.name_txt, Me.SizeWHToolStripMenuItem, Me.ToolStripSeparator6, Me.w_txt, Me.h_txt, Me.ToolStripSeparator7, Me.TypeToolStripMenuItem, Me.ToolStripSeparator1, Me.ToolStripComboBox1, Me.ToolStripSeparator2, Me.CreateToolStripMenuItem})
        Me.NewControlToolStripMenuItem.Image = Global.Mono_Theme_Maker.My.Resources.Resources._1453273250_Add
        Me.NewControlToolStripMenuItem.Name = "NewControlToolStripMenuItem"
        Me.NewControlToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.NewControlToolStripMenuItem.Text = "New Control"
        '
        'NameToolStripMenuItem
        '
        Me.NameToolStripMenuItem.Name = "NameToolStripMenuItem"
        Me.NameToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.NameToolStripMenuItem.Text = "Name"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(178, 6)
        '
        'name_txt
        '
        Me.name_txt.Name = "name_txt"
        Me.name_txt.Size = New System.Drawing.Size(100, 23)
        Me.name_txt.Text = "Example Button"
        '
        'SizeWHToolStripMenuItem
        '
        Me.SizeWHToolStripMenuItem.Name = "SizeWHToolStripMenuItem"
        Me.SizeWHToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.SizeWHToolStripMenuItem.Text = "Size | W | H |"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(178, 6)
        '
        'w_txt
        '
        Me.w_txt.Name = "w_txt"
        Me.w_txt.Size = New System.Drawing.Size(100, 23)
        Me.w_txt.Text = "200"
        '
        'h_txt
        '
        Me.h_txt.Name = "h_txt"
        Me.h_txt.Size = New System.Drawing.Size(100, 23)
        Me.h_txt.Text = "200"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(178, 6)
        '
        'TypeToolStripMenuItem
        '
        Me.TypeToolStripMenuItem.Name = "TypeToolStripMenuItem"
        Me.TypeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TypeToolStripMenuItem.Text = "Type"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 23)
        Me.ToolStripComboBox1.Text = "Control"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(178, 6)
        '
        'CreateToolStripMenuItem
        '
        Me.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        Me.CreateToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.CreateToolStripMenuItem.Text = "Create"
        '
        'SaveCodeToolStripMenuItem
        '
        Me.SaveCodeToolStripMenuItem.Name = "SaveCodeToolStripMenuItem"
        Me.SaveCodeToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SaveCodeToolStripMenuItem.Text = "Save Code"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Image = Global.Mono_Theme_Maker.My.Resources.Resources.hammer_screwdriver
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ControlTabSelecter
        '
        Me.ControlTabSelecter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlTabSelecter.Location = New System.Drawing.Point(0, 24)
        Me.ControlTabSelecter.Name = "ControlTabSelecter"
        Me.ControlTabSelecter.SelectedIndex = 0
        Me.ControlTabSelecter.Size = New System.Drawing.Size(819, 577)
        Me.ControlTabSelecter.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 601)
        Me.Controls.Add(Me.ControlTabSelecter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "GDI Theme Studio"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents name_txt As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents SizeWHToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents w_txt As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents h_txt As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CreateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlTabSelecter As System.Windows.Forms.TabControl
    Friend WithEvents TypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
