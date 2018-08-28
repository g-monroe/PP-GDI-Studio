Public Class Valueitem
    Inherits Control
    Public WithEvents Value_txtbox As New TextBox With {.Text = "intvalueex"}
    Public WithEvents DefaultValue_txtbox As New TextBox With {.Text = "3"}
    Public WithEvents Type_cb As New ComboBox With {.Text = "Type"}
    Property namecontrol As String
    Property Selected As Boolean = False
    Sub New()
        Me.DoubleBuffered = True
        Me.Controls.Add(Type_cb)
        Me.Controls.Add(Value_txtbox)
        Me.Controls.Add(DefaultValue_txtbox)
        Type_cb.Items.Add("integer")
        Type_cb.Items.Add("boolean")
        Type_cb.Items.Add("string")
    End Sub

    Private Sub Valueitem_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Value_txtbox.Location = New Point(0, 0)
        Value_txtbox.Width = Me.Width / 3
        DefaultValue_txtbox.Location = New Point(Me.Width / 3, 0)
        DefaultValue_txtbox.Width = Me.Width / 3
        Type_cb.Location = New Point((Me.Width / 3) + (Me.Width / 3), 0)
        Type_cb.Width = Me.Width / 3
        Me.Height = Value_txtbox.Height
    End Sub

    Private Sub Value_txtbox_GotFocus(sender As Object, e As EventArgs) Handles Value_txtbox.GotFocus
        Selected = True
    End Sub

    Private Sub Value_txtbox_LostFocus(sender As Object, e As EventArgs) Handles Value_txtbox.LostFocus
        Selected = False
    End Sub

    Private Sub Value_txtbox_TextChanged(sender As Object, e As EventArgs) Handles Value_txtbox.TextChanged
        namecontrol = Value_txtbox.Text

    End Sub
End Class
