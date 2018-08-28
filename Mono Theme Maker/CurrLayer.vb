Public Class CurrLayer
    Public Shape As Maker._Shapes
    Public pt1 As Point
    Public pt2 As Point
    Public Rect As Rectangle
    Public Color As Color
    Public image As Image
    Public Color2 As Color
    Public Grad As Boolean = False
    Public fill As Boolean = False
    Public Radious As Integer
    Public Angle As Decimal
    Public Thick As Integer
    Public Index As Integer
    Public Enabledd As Boolean
    Public mewidth As Boolean
    Public meheight As Boolean
    Public mex As Boolean
    Public mey As Boolean
    Public fontt As Font
    Public textt As String
    Public align As StringFormat
    Public currrect As Boolean
    Public Shared Event RefreshProperties()
    Property MakerD As Maker
    Private Sub text_Click(sender As Object, e As EventArgs) Handles text_btn.Click
        MakerD.Shape = Maker._Shapes.text
        MakerD.Refresh()
    End Sub

    Friend Sub CurrLayer_RefreshProperties() Handles Me.RefreshProperties
        x_txt.Text = Rect.X
        y_txt.Text = Rect.Y
        w_txt.Text = Rect.Width
        h_txt.Text = Rect.Height

    End Sub

    Private Sub mewidthcb_CheckedChanged(sender As Object, e As EventArgs) Handles mewidthcb.CheckedChanged
        MakerD.currmewidth = mewidthcb.Checked
        MakerD.Refresh()

    End Sub

    Private Sub w_txt_TextChanged(sender As Object, e As EventArgs) Handles w_txt.TextChanged
        Try
            MakerD.CurRect.Width = w_txt.Text
            MakerD.Refresh()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub x_txt_TextChanged(sender As Object, e As EventArgs) Handles x_txt.TextChanged
        Try
            MakerD.CurRect.X = x_txt.Text
            MakerD.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub y_txt_TextChanged(sender As Object, e As EventArgs) Handles y_txt.TextChanged
        Try
            MakerD.CurRect.Y = y_txt.Text
            MakerD.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub h_txt_TextChanged(sender As Object, e As EventArgs) Handles h_txt.TextChanged
        Try
            MakerD.CurRect.Height = h_txt.Text
            MakerD.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub meheightcb_CheckedChanged(sender As Object, e As EventArgs) Handles meheightcb.CheckedChanged
        MakerD.currmeheight = meheightcb.Checked
        MakerD.Refresh()
    End Sub

    Private Sub circle_btn_Click(sender As Object, e As EventArgs) Handles circle_btn.Click
        MakerD.Shape = Maker._Shapes.Circle
        MakerD.Refresh()
    End Sub

    Private Sub line_btn_Click(sender As Object, e As EventArgs) Handles line_btn.Click
        MakerD.Shape = Maker._Shapes.Line
        MakerD.Refresh()
    End Sub

    Private Sub rr__btn_Click(sender As Object, e As EventArgs) Handles rr__btn.Click
        MakerD.Shape = Maker._Shapes.RRect
        MakerD.Refresh()
    End Sub
    Function OpenAnImageInPicturebox() As Bitmap
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
            Return My.Resources.asdas
        End Try
    End Function
    Private Sub rect_btn_Click(sender As Object, e As EventArgs) Handles rect_btn.Click
        MakerD.Shape = Maker._Shapes.Rect
        MakerD.Refresh()
    End Sub

    Private Sub img_btn_Click(sender As Object, e As EventArgs) Handles img_btn.Click
        MakerD.Image = OpenAnImageInPicturebox()
        MakerD.Shape = Maker._Shapes.image

        MakerD.Refresh()
    End Sub

    Private Sub fill_btn_Click(sender As Object, e As EventArgs) Handles fill_btn.Click
        MakerD.fill = True
        MakerD.Refresh()
    End Sub

    Private Sub draw_btn_Click(sender As Object, e As EventArgs) Handles draw_btn.Click
        MakerD.fill = False
        MakerD.Refresh()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles xcb.CheckedChanged
        MakerD.mex = xcb.Checked
        MakerD.Refresh()
    End Sub

    Private Sub ycb_CheckedChanged(sender As Object, e As EventArgs) Handles ycb.CheckedChanged
        MakerD.mey = ycb.Checked
        MakerD.Refresh()
    End Sub
End Class
