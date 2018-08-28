Public Class Form1

    
    Private Sub CreateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateToolStripMenuItem.Click
        Dim Tab As New TabPage
        Dim tabmake As New ControlTab
        tabmake.Dock = DockStyle.Fill
        Tab.BackColor = Color.White
        tabmake.Maker1.Size = New Size(w_txt.Text, h_txt.Text)
        tabmake.Defaulsize = New Size(w_txt.Text, h_txt.Text)
        Tab.Name = name_txt.Text
        Tab.Text = name_txt.Text
        Tab.Controls.Add(tabmake)
        Dim int As Integer = 0
        For Each _Tab As TabPage In ControlTabSelecter.TabPages
            If _Tab.Name = name_txt.Text Then
                int += 1
            End If
        Next
        If int = 0 Then
            ControlTabSelecter.TabPages.Add(Tab)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
