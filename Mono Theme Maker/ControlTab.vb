Public Class ControlTab
    Dim cir As Boolean = False
    Dim swu As Boolean = False
    Dim rr As Boolean = False
    Dim lin As Boolean = False
    Dim grad As Boolean = False
    Dim image As Image
    Dim img As Boolean = False
    Public Defaulsize As Size
    Private Sub ControlTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ControlTab_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Maker1.Location = New Point((Panel1.Width / 2) - (Maker1.Size.Width / 2), Panel1.Height / 2 - (Maker1.Size.Height / 2))
        'Panel1.Width = SplitContainer1.Panel1.Width / 4
    End Sub

    Private Sub SetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetToolStripMenuItem.Click
        updat()
    End Sub

    Sub updat()
        Maker1.fill = fill

        Maker1.Grad = grad
        Maker1.Angle = Angle.Text
        If lin Then
            Maker1.Shape = Maker._Shapes.Line
        ElseIf swu Then
            Maker1.Shape = Maker._Shapes.Rect
        ElseIf rr Then
            Maker1.Shape = Maker._Shapes.RRect
        ElseIf cir Then
            Maker1.Shape = Maker._Shapes.Circle
        ElseIf img Then
            Maker1.Shape = Maker._Shapes.image
        End If
        If Not Color1txt.Text.StartsWith("#") Then
            Dim Color1 As String() = Color1txt.Text.Split(",")
            Maker1.Color1 = Color.FromArgb(Color1(0), Color1(1), Color1(2), Color1(3))
        Else
            Maker1.Color1 = System.Drawing.ColorTranslator.FromHtml(Color1txt.Text)
        End If
        If Not Color2txt.Text.StartsWith("#") Then
            Dim Color2 As String() = Color2txt.Text.Split(",")
            Maker1.Color2 = Color.FromArgb(Color2(0), Color2(1), Color2(2), Color2(3))
        Else
            Maker1.Color2 = System.Drawing.ColorTranslator.FromHtml(Color2txt.Text)
        End If
        If Not backcolortxt.Text.StartsWith("#") Then
            Dim Color2 As String() = backcolortxt.Text.Split(",")
            Maker1.BackColor = Color.FromArgb(Color2(0), Color2(1), Color2(2), Color2(3))
        Else
            Maker1.BackColor = System.Drawing.ColorTranslator.FromHtml(backcolortxt.Text)
        End If
        Maker1.Radious = Radioustxt.Text
        Maker1.Image = image
        Maker1.Refresh()
    End Sub
    Private Sub SquareToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

  
    Private Sub RRectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RRectToolStripMenuItem.Click
        rr = True
        swu = False
        cir = False
        lin = False
        img = False
        updat()
    End Sub
    Dim fill As Boolean = False
    Private Sub FillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FillToolStripMenuItem.Click
        fill = True
        updat()
    End Sub

    Private Sub DrawToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawToolStripMenuItem.Click
        fill = False
        updat()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        grad = True
        updat()
    End Sub

    Private Sub ColorToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem2.Click
        grad = False
        updat()
    End Sub

    Private Sub RectangleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RectangleToolStripMenuItem.Click
        swu = True
        rr = False
        cir = False
        lin = False
        img = False
        updat()
    End Sub

    Private Sub LineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LineToolStripMenuItem.Click
        swu = False
        rr = False
        cir = False
        lin = True
        img = False
        updat()
    End Sub

    Private Sub CircleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CircleToolStripMenuItem.Click
        swu = False
        rr = False
        cir = True
        lin = False
        img = False
        updat()
    End Sub
    Function OpenAnImageInPicturebox()
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Bitmap|*.bmp|JPEG|*.jpg|PNG|*.png|JPG|*.jpg" 'If you like file type filters you can add them here
        'any other modifications to the dialog
        If ofd.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Return Nothing
        End If
        Try
            Dim bmp As New Bitmap(ofd.FileName)
            Return bmp
        Catch
            Return Nothing
        End Try
    End Function
    Private Sub ImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageToolStripMenuItem.Click
        Try : image = OpenAnImageInPicturebox() : Catch ex As Exception : End Try
        img = True
        swu = False
        rr = False
        cir = False
        lin = False
        updat()
    End Sub

    Private Sub Maker1_Drawing() Handles Maker1.Drawing
        YesToolStripMenuItem.Enabled = True
        NoToolStripMenuItem.Enabled = True
    End Sub

    Private Sub YesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YesToolStripMenuItem.Click
        Dim i As Integer = Maker1.DrawingList.Count + 1
        Maker1.Addob(Maker1.Shape, New Rectangle(Maker1.CurRect.X, Maker1.CurRect.Y, Maker1.CurRect.Width / Maker1.zoom, Maker1.CurRect.Height / Maker1.zoom), Maker1.curpt1, Maker1.curpt2, Maker1.Image, Maker1.fill, Maker1.Grad, True, i, Maker1.Color1, Maker1.Color2, Maker1.Radious, Maker1.Angle, Maker1.thick)
        Maker1.CurRecton = False
        Maker1.Refresh()
        YesToolStripMenuItem.Enabled = False
        NoToolStripMenuItem.Enabled = False
    End Sub

    Private Sub NoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoToolStripMenuItem.Click
        Maker1.CurRecton = False
        Maker1.Refresh()
        YesToolStripMenuItem.Enabled = False
        NoToolStripMenuItem.Enabled = False
    End Sub

    Private Sub BackGroundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackGroundToolStripMenuItem.Click
        If Not backcolortxt.Text.StartsWith("#") Then
            Dim Color2 As String() = backcolortxt.Text.Split(",")
            Maker1.BackColor = Color.FromArgb(Color2(0), Color2(1), Color2(2), Color2(3))
        Else
            Maker1.BackColor = System.Drawing.ColorTranslator.FromHtml(backcolortxt.Text)
        End If
        Maker1.Refresh()
    End Sub

    Private Sub X2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X2ToolStripMenuItem.Click
        Maker1.Width = Defaulsize.Width * 2
        Maker1.Height = Defaulsize.Height * 2
        Maker1.zoom = 2
        Maker1.Refresh()
        Maker1.Location = New Point((Panel1.Width / 2) - (Maker1.Size.Width / 2), Panel1.Height / 2 - (Maker1.Size.Height / 2))
    End Sub

    Private Sub X1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X1ToolStripMenuItem.Click
        Maker1.Width = Defaulsize.Width
        Maker1.Height = Defaulsize.Height
        Maker1.zoom = 1
        Maker1.Refresh()
        Maker1.Location = New Point((Panel1.Width / 2) - (Maker1.Size.Width / 2), Panel1.Height / 2 - (Maker1.Size.Height / 2))
    End Sub

    Private Sub X3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X3ToolStripMenuItem.Click
        Maker1.Width = Defaulsize.Width * 3
        Maker1.Height = Defaulsize.Height * 3
        Maker1.zoom = 3
        Maker1.Refresh()
        Maker1.Location = New Point((Panel1.Width / 2) - (Maker1.Size.Width / 2), Panel1.Height / 2 - (Maker1.Size.Height / 2))
    End Sub

    Private Sub X4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X4ToolStripMenuItem.Click
        Maker1.Width = Defaulsize.Width * 4
        Maker1.Height = Defaulsize.Height * 4
        Maker1.zoom = 4
        Maker1.Refresh()
        Maker1.Location = New Point((Panel1.Width / 2) - (Maker1.Size.Width / 2), Panel1.Height / 2 - (Maker1.Size.Height / 2))
    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub


    Private Sub Layers_Paint_1(sender As Object, e As PaintEventArgs) Handles Layers.Paint
        Dim OutBorderColor As Color = Color.FromArgb(229, 229, 229)
        Dim InBorderColor As Color = Color.FromArgb(219, 219, 219)
        e.Graphics.DrawRectangle(New Pen(InBorderColor), New Rectangle(0, 0, Layers.Width - 2, Layers.Height - 2))
        e.Graphics.DrawRectangle(New Pen(OutBorderColor), New Rectangle(0, 0, Layers.Width - 3, Layers.Height - 3))
    End Sub

    Private Sub Layers_Resize(sender As Object, e As EventArgs) Handles Layers.Resize
        Layers.Refresh()
    End Sub

    Private Sub Layers_Scroll(sender As Object, e As ScrollEventArgs) Handles Layers.Scroll
        Layers.Refresh()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Dim OutBorderColor As Color = Color.FromArgb(229, 229, 229)
        Dim InBorderColor As Color = Color.FromArgb(219, 219, 219)
        e.Graphics.DrawRectangle(New Pen(InBorderColor), New Rectangle(0, 0, Layers.Width - 2, Layers.Height - 2))
        e.Graphics.DrawRectangle(New Pen(OutBorderColor), New Rectangle(0, 0, Layers.Width - 3, Layers.Height - 3))
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub HighToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighToolStripMenuItem.Click
        Maker1.Highq = True
        Maker1.Refresh()
    End Sub

    Private Sub LowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LowToolStripMenuItem.Click
        Maker1.Highq = False
        Maker1.Refresh()
    End Sub
End Class
