Imports System.ComponentModel

Public Class PlisticBlue_Seperator
    Inherits Control
    <Category("Colors")>
    Property Main_Color As Color = Color.FromArgb(96, 105, 131)
    <Category("Colors")>
    Property Back_color As Color = Color.FromArgb(25, 38, 69)
    <Category("Colors")>
    Property Side_Color As Color = Color.FromArgb(0, 174, 85)
    <Category("Misc")>
    Property SubtractSep As Integer = 40
    Sub New()
        Me.DoubleBuffered = True
        Me.Height = 6
        Me.Width = 100
    End Sub

    Private Sub PlisticBlue_Spe_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Back_color)
        e.Graphics.DrawLine(New Pen(Side_Color), New Point(3, Me.Height / 2), New Point(Me.Width - 4, Me.Height / 2))
        e.Graphics.DrawLine(New Pen(Main_Color), New Point(SubtractSep - 1, Me.Height / 2), New Point(Me.Width - SubtractSep, Me.Height / 2))
    End Sub
End Class