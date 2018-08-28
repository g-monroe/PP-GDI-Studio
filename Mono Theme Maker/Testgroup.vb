Partial Public Class FlatGroupBox
    Inherits Panel
    Property Downsize As Size = New Size(386, 146)
    Property UporDown As Boolean = True
    Property OutBorderColor As Color = Color.FromArgb(229, 229, 229)
    Property InBorderColor As Color = Color.FromArgb(219, 219, 219)
    Property HeaderColor As Color = Color.FromArgb(255, 255, 255)
    Property BoxColor As Color = Color.FromArgb(242, 242, 242)
    Property OddColor As Color = Color.FromArgb(27, 132, 188)
    Property Collasble As Boolean = True
    Property PopOddColor As Color = Color.FromArgb(17, 122, 178)
    Property _text As String = "Box"
    Sub New()
        Me.Padding = New Padding(2, 37, 2, 2)
        Me.DoubleBuffered = True
    End Sub
    Property updown2 As Boolean = False
    Private Sub FlatGroupBox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(BoxColor)
        If updown2 = True Then
            e.Graphics.DrawRectangle(New Pen(InBorderColor), New Rectangle(0, 35, Me.Width - 2, Me.Height - 36))
            e.Graphics.DrawRectangle(New Pen(OutBorderColor), New Rectangle(0, 36, Me.Width - 3, Me.Height - 37))
        End If
        e.Graphics.FillRectangle(New SolidBrush(HeaderColor), New Rectangle(0, 0, Me.Width, 35))
        If UporDown = True Then
            e.Graphics.FillRectangle(New SolidBrush(OddColor), New Rectangle(Me.Width - 27, 22, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(PopOddColor), New Rectangle(Me.Width - 27, 26, 20, 2))
            e.Graphics.FillRectangle(New SolidBrush(OddColor), New Rectangle(Me.Width - 27, 14, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(PopOddColor), New Rectangle(Me.Width - 27, 18, 20, 2))
            e.Graphics.FillRectangle(New SolidBrush(OddColor), New Rectangle(Me.Width - 27, 6, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(PopOddColor), New Rectangle(Me.Width - 27, 10, 20, 2))
            Me.Size = New Size(Me.Width, 250)
        Else
            e.Graphics.FillRectangle(New SolidBrush(InBorderColor), New Rectangle(Me.Width - 27, 22, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(OutBorderColor), New Rectangle(Me.Width - 27, 26, 20, 2))
            e.Graphics.FillRectangle(New SolidBrush(InBorderColor), New Rectangle(Me.Width - 27, 14, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(OutBorderColor), New Rectangle(Me.Width - 27, 18, 20, 2))
            e.Graphics.FillRectangle(New SolidBrush(InBorderColor), New Rectangle(Me.Width - 27, 6, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(OutBorderColor), New Rectangle(Me.Width - 27, 10, 20, 2))
            Me.Size = New Size(Me.Width, 36)
        End If
        e.Graphics.DrawString(_text, New Font("Arial", 12.5, FontStyle.Regular), New SolidBrush(Color.FromArgb(130, 130, 130)), 5, 8)
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        Dim clickRect As New Rectangle(Me.Width - 27, 10, 20, 20)
        If clickRect.Contains(New Point(e.X, e.Y)) Then
            If Collasble = True Then
                UporDown = Not UporDown
                Me.Refresh()
            End If
        End If
        '

        MyBase.OnMouseDown(e)
    End Sub

    Private Sub FlatGroupBox_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
End Class