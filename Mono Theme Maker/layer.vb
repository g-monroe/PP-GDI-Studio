Imports System.Drawing.Drawing2D

Public Class layer
    Inherits Control
    Property LayerName As String = "Layer Name"
    Property selected As Boolean = False
    Property editname As Boolean = False
    Public WithEvents name_txt As New TextBox With {.Text = "Layer"}
    Sub New()
        Me.DoubleBuffered = True
        Me.Controls.Add(name_txt)
    End Sub

    Private Sub layer_KeyDown(sender As Object, e As KeyEventArgs) Handles name_txt.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If name_txt.Text.Count > 25 Then
                    name_txt.Text = "Too many chars..."
                Else
                    editname = False
                    LayerName = name_txt.Text
                    Me.Refresh()
                End If
        End Select
    End Sub

    Private Sub layer_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If New Rectangle(28, 8, Me.Width - 45, Me.Height - 8).Contains(e.X, e.Y) Then
            editname = True
            Me.Refresh()
        End If
    End Sub

    Private Sub layer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        'Back
        e.Graphics.Clear(Color.FromArgb(245, 245, 245))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(222, 224, 222)), New Rectangle(2, 2, Me.Width - 4, Me.Height - 5))
        'header
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(232, 233, 232)), New Rectangle(2, 2, Me.Width - 4, 25))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(212, 213, 212)), New Point(2, 26), New Point(Me.Width - 4, 26))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(232, 233, 232)), New Point(2, 27), New Point(Me.Width - 4, 27))
        Dim rect = New Rectangle(2, 2, Me.Width - 4, 23)
        Dim LGB = New LinearGradientBrush(rect, Color.FromArgb(40, 165, 165, 165), Color.FromArgb(232, 233, 232), 90.0!)
        e.Graphics.FillRectangle(LGB, rect)
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(60, 200, 200, 200)), New Rectangle(1, 1, Me.Width - 3, Me.Height - 4))
        If editname = False Then
            name_txt.Visible = False
            e.Graphics.DrawString(LayerName, Font, New SolidBrush(Color.FromArgb(102, 103, 102)), New Rectangle(28, 8, Me.Width - 45, Me.Height - 8))
        Else
            name_txt.Visible = True
            name_txt.Location = New Point(28, 5)
        End If
        If selected Then
            e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(145, 145, 145)), New Rectangle(Me.Width - 25, 7, 15, 15))
            e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(225, 225, 225)), New Rectangle(Me.Width - 24, 7, 13, 14))
            e.Graphics.DrawEllipse(Pens.DarkGray, New Rectangle(Me.Width - 25, 7, 15, 15))
            e.Graphics.DrawString("<", Font, New SolidBrush(Color.FromArgb(102, 103, 102)), New Rectangle(Me.Width - 25, 7, 13, 14), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Else

        End If
    End Sub

End Class
