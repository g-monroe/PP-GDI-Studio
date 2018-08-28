Imports System.Drawing.Drawing2D

Public Class Maker
    Inherits Control
    Property mdown As Boolean = False
    Property omloc As Point
    Property CurrLayer As CurrLayer
    Property mloc As Point
    Property fill As Boolean = False
    Property Shape As _Shapes = _Shapes.Rect
    Property Color1 As Color = Color.Red
    Property Color2 As Color = Color.Blue
    Property Radious As Integer = 6
    Property Angle As Decimal = 90.0
    Property thick As Integer = 1
    Property Grad As Boolean = False
    Public CurRect As Rectangle
    Public zoom As Integer = 1
    Property CurRecton As Boolean = False
    Public Property currmeheight As Boolean = False
    Public Property currmewidth As Boolean = False
    Public Property mex As Boolean = False
    Public Property mey As Boolean = False
    Dim resz As Boolean = False
    Dim reszb As Boolean = False
    Dim reszr As Boolean = False
    Dim reszl As Boolean = False
    Dim moving As Boolean = False
    Property Image As Image
    Property curpt1 As Point
    Property curpt2 As Point
    Enum _Shapes
        Circle
        Rect
        RRect
        Line
        image
        text
    End Enum
    Sub New()
        Me.DoubleBuffered = True

    End Sub
    Dim reszy As Integer
    Dim reszx As Integer
    Dim holdr As Boolean = False
    Private Sub Maker_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.W
                If holdr = False Then
                    CurRect.Y -= 1
                Else
                    CurRect.Height -= 1
                End If
            Case Keys.S
                If holdr = False Then
                    CurRect.Y += 1
                Else
                    CurRect.Height += 1
                End If
            Case Keys.A
                If holdr = False Then
                    CurRect.X -= 1
                Else
                    CurRect.Width -= 1
                End If
            Case Keys.D
                If holdr = False Then
                    CurRect.X += 1
                Else
                    CurRect.Width += 1
                End If
            Case Keys.F1
                stat = Not stat
            Case Keys.Space
                holdr = True
        End Select
        Me.Refresh()
        updateCurrLayer()
    End Sub
    Dim stat As Boolean = False

    Private Sub Maker_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Space
                holdr = False
        End Select
        Me.Refresh()
    End Sub
    Public Sub Maker_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        Me.Focus()
        If e.Button = Windows.Forms.MouseButtons.Left Then
            mdown = True
            omloc = e.Location
            If e.Location.Y = CurRect.Y - 3 Or e.Location.Y = CurRect.Y - 2 Or e.Location.Y = CurRect.Y - 1 And e.Location.X < CurRect.X + CurRect.Width Then
                resz = True
                reszy = CurRect.Bottom
            End If
            If e.Location.Y = (CurRect.Y + CurRect.Height) Or e.Location.Y = (CurRect.Y + 1 + CurRect.Height) Or e.Location.Y = (CurRect.Y - 1 + CurRect.Height) Then
                reszb = True
            End If
            If e.Location.X = (CurRect.X + CurRect.Width) Or e.Location.X = (CurRect.X + 1 + CurRect.Width) Or e.Location.X = (CurRect.X - 1 + CurRect.Width) Then
                reszr = True
            End If
            If e.Location.X = (CurRect.X) Or e.Location.X = (CurRect.X + 1) Or e.Location.X = (CurRect.X - 1) Then
                reszl = True
                reszx = CurRect.Right
            End If
            If CurRect.Width > 9 And CurRect.Height > 9 Then
                If New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12).Contains(e.X, e.Y) Then
                    moving = True
                End If
            End If
        End If
        Me.Refresh()
        updateCurrLayer()
    End Sub
    Public Sub updateCurrLayer()
        CurrLayer.Shape = Shape
        CurrLayer.currrect = CurRecton
        CurrLayer.Rect = CurRect
        CurrLayer.Color = Color1
        CurrLayer.Color2 = Color2
        CurrLayer.Grad = Grad
        CurrLayer.x_txt.Text = CurRect.X
        CurrLayer.y_txt.Text = CurRect.Y
        CurrLayer.w_txt.Text = CurRect.Width
        CurrLayer.h_txt.Text = CurRect.Height
        CurrLayer.Refresh()
    End Sub
    Private Sub Maker_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        System.Diagnostics.Debug.WriteLine(CurRect.X + (Me.Width / 2))
        mloc = e.Location
        If CurRecton Then
            If e.Location.Y = CurRect.Y - 3 Or e.Location.Y = CurRect.Y - 2 Or e.Location.Y = CurRect.Y - 1 Or (e.Location.Y = (CurRect.Y + CurRect.Height) Or e.Location.Y = (CurRect.Y + 1 + CurRect.Height) Or e.Location.Y = (CurRect.Y - 1 + CurRect.Height)) Then
                Cursor = Cursors.SizeNS
            ElseIf e.Location.X = (CurRect.X + CurRect.Width) Or e.Location.X = (CurRect.X + 1 + CurRect.Width) Or (e.Location.X = (CurRect.X - 1 + CurRect.Width) Or e.Location.X = (CurRect.X) Or e.Location.X = (CurRect.X + 1) Or e.Location.X = (CurRect.X - 1)) Then
                Cursor = Cursors.SizeWE
            ElseIf New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12).Contains(e.X, e.Y) Then
                Cursor = Cursors.SizeAll
            Else
                Cursor = Cursors.Default
            End If
        End If
        If resz = True Then
            CurRect.Location = New Point(CurRect.X, e.Y)
            CurRect.Size = New Point(CurRect.Width, CurRect.Height + (reszy - CurRect.Bottom))
        End If
        If reszb = True Then
            CurRect.Size = New Point(CurRect.Width, mloc.Y - CurRect.Top)
        End If
        If reszr = True Then
            CurRect.Size = New Point(mloc.X - CurRect.Left, CurRect.Height)
        End If
        If reszl = True Then
            CurRect.Location = New Point(e.X, CurRect.Y)
            CurRect.Size = New Point(CurRect.Width + (reszx - CurRect.Right), CurRect.Height)
        End If
        If moving = True Then
            CurRect.Location = New Point((e.X - 6), (e.Y - 6))
        End If
        Me.Refresh()
        updateCurrLayer()
    End Sub
    Event Drawing()
    Public Sub Addob(Shape As _Shapes, rect As Rectangle, pt1 As Point, pt2 As Point, image As Image, fill As Boolean, grad As Boolean, enabled As Boolean, index As Integer, Color1 As Color, Color2 As Color, Radious As Integer, Angle As Decimal, Thick As Integer)
        Dim itm As New Draws
        itm.Angle = Angle
        itm.Color = Color1
        itm.Color2 = Color2
        itm.Radious = Radious
        itm.Index = index
        itm.Enabled = enabled
        itm.fill = fill
        itm.Grad = grad
        itm.Thick = Thick
        itm.Shape = Shape
        itm.image = image
        itm.pt1 = pt1
        itm.pt2 = pt2
        itm.Rect = rect
        DrawingList.Add(itm)
    End Sub
    Private Sub Maker_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp

        mdown = False
        If Cursor = Cursors.Default And resz = False And reszb = False And reszr = False And reszl = False And moving = False Then
            If mloc.X - omloc.X > 1 And mloc.Y - omloc.Y > 1 Then
                CurRect = New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y))
                curpt1 = omloc
                curpt2 = mloc
            End If
        ElseIf resz = True Then
            resz = False
        ElseIf reszb = True Then
            reszb = False
        ElseIf reszr = True Then
            reszr = False
        ElseIf reszl = True Then
            reszl = False
        ElseIf moving = True Then
            moving = False
        End If
        RaiseEvent Drawing()
        CurRecton = True

        Me.Refresh()
    End Sub
    Public Function setWidth(bool As Boolean, int As Integer) As Integer
        If bool Then
            Return Me.Width
        Else
            Return int * 2
        End If
    End Function
    Public Function setHeight(bool As Boolean, int As Integer) As Integer
        If bool Then
            Return Me.Height
        Else
            Return int * 2
        End If
    End Function
    Public Function sety(bool As Boolean, int As Integer) As Integer
        If bool Then
            Return Me.Height - int
        Else
            Return int
        End If
    End Function
    Public Function setx(bool As Boolean, int As Integer) As Integer
        If bool Then
            Return Me.Width - int
        Else
            Return int
        End If
    End Function
    Public Highq As Boolean = True
    Private Sub Maker_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        If Highq = True Then
            g.SmoothingMode = SmoothingMode.AntiAlias
        Else
            g.SmoothingMode = SmoothingMode.HighSpeed
        End If

        If stat Then
            g.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Black)), New Rectangle(0, 0, 220, 100))
            g.DrawString("Stats", New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Rectangle(0, 0, 100, 25))
            g.DrawString("Old Loc: " & omloc.ToString, Font, Brushes.White, New Rectangle(0, 15, 100, 25))
            g.DrawString("M Loc: " & mloc.ToString, Font, Brushes.White, New Rectangle(0, 30, 100, 25))
            g.DrawString("Currect: " & CurRect.ToString, Font, Brushes.White, New Rectangle(0, 55, 200, 25))
            g.DrawString("Currect Zoomed: " & CurRect.ToString, Font, Brushes.White, New Rectangle(0, 75, 200, 25))
        End If
        Dim i As Integer = DrawingList.Count + 1
        For ii As Integer = 0 To i
            For Each itm As Draws In DrawingList
                If itm.Index = ii Then
                    If itm.fill Then
                        Dim gbrush As LinearGradientBrush
                        If itm.Rect.Width > 0 And itm.Rect.Height > 0 Then
                            gbrush = New LinearGradientBrush(New Rectangle(New Point(itm.Rect.X, itm.Rect.Y - 1), New Point(itm.Rect.Width * zoom, itm.Rect.Height * zoom + 2)), itm.Color, itm.Color2, itm.Angle)
                        Else
                            gbrush = New LinearGradientBrush(New Rectangle(1, 1, 1, 1), itm.Color, itm.Color2, itm.Angle)
                        End If
                        Select Case itm.Shape
                            Case _Shapes.Rect
                                If itm.Grad Then
                                    g.FillRectangle(gbrush, New Rectangle(New Point(itm.Rect.X, itm.Rect.Y), New Point(itm.Rect.Width * zoom, itm.Rect.Height * zoom)))
                                Else
                                    g.FillRectangle(New SolidBrush(itm.Color), New Rectangle(New Point(itm.Rect.X, itm.Rect.Y), New Point(itm.Rect.Width * zoom, itm.Rect.Height * zoom)))
                                End If
                            Case _Shapes.Circle
                                If itm.Grad Then
                                    g.FillEllipse(gbrush, itm.Rect)
                                Else
                                    g.FillEllipse(New SolidBrush(itm.Color), New Rectangle(New Point(itm.Rect.X, itm.Rect.Y), New Point(itm.Rect.Width * zoom, itm.Rect.Height * zoom)))
                                End If
                            Case _Shapes.Line
                                g.DrawLine(New Pen(itm.Color, itm.Thick), itm.pt1, itm.pt2)
                            Case _Shapes.RRect

                                If itm.Grad Then
                                    FillRRectangle(g, gbrush, itm.Rect.X, itm.Rect.Y, itm.Rect.Width * zoom, itm.Rect.Height * zoom, itm.Radious)
                                Else
                                    FillRRectangle(g, New SolidBrush(itm.Color), itm.Rect.X, itm.Rect.Y, itm.Rect.Width * zoom, itm.Rect.Height * zoom, itm.Radious)
                                End If
                            Case _Shapes.image
                                g.DrawImage(itm.image, New Rectangle(New Point(itm.Rect.X, itm.Rect.Y), New Point(itm.Rect.Width * zoom, itm.Rect.Height * zoom)))
                                ' g.DrawRectangle(New Pen(itm.Color), itm.Rect)
                        End Select
                    Else
                        Select Case itm.Shape
                            Case _Shapes.Rect

                                g.DrawRectangle(New Pen(itm.Color), New Rectangle(New Point(itm.Rect.X, itm.Rect.Y), New Point(itm.Rect.Width * zoom, itm.Rect.Height * zoom)))
                            Case _Shapes.Circle
                                g.DrawEllipse(New Pen(itm.Color), New Rectangle(New Point(itm.Rect.X, itm.Rect.Y), New Point(itm.Rect.Width * zoom, itm.Rect.Height * zoom)))
                            Case _Shapes.Line
                                g.DrawLine(New Pen(itm.Color, itm.Thick), itm.pt1, itm.pt2)
                            Case _Shapes.RRect
                                DrawRRectangle(g, New Rectangle(New Point(itm.Rect.X, itm.Rect.Y), New Point(itm.Rect.Width * zoom, itm.Rect.Height * zoom)), itm.Radious, New Pen(itm.Color))
                            Case _Shapes.image
                                g.DrawImage(itm.image, New Rectangle(New Point(itm.Rect.X, itm.Rect.Y), New Point(itm.Rect.Width * zoom, itm.Rect.Height * zoom)))
                                ' g.DrawRectangle(New Pen(itm.Color), itm.Rect)
                        End Select
                    End If
                End If
            Next
        Next
        If mdown And resz = False And reszb = False And reszr = False And reszl = False And moving = False Then
            If fill Then
                Dim gbrush As LinearGradientBrush
                If mloc.Y - omloc.Y > 0 And mloc.X - omloc.X > 0 Then
                    gbrush = New LinearGradientBrush(New Rectangle(New Point(omloc.X, omloc.Y - 1), New Point(mloc.X - (omloc.X), mloc.Y - omloc.Y + 2)), Color1, Color2, Angle)
                Else
                    gbrush = New LinearGradientBrush(New Rectangle(1, 1, 1, 1), Color1, Color2, Angle)
                End If
                Select Case Shape
                    Case _Shapes.Rect
                        If Grad Then
                            g.FillRectangle(gbrush, New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                        Else
                            g.FillRectangle(New SolidBrush(Color1), New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                        End If
                    Case _Shapes.Circle
                        If Grad Then
                            g.FillEllipse(gbrush, New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                        Else
                            g.FillEllipse(New SolidBrush(Color1), New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                        End If
                    Case _Shapes.Line
                        g.DrawLine(New Pen(Color1, thick), New Point(omloc), New Point(mloc.X, mloc.Y))
                    Case _Shapes.RRect
                        If mloc.Y - omloc.Y > Radious Then
                            If Grad Then
                                FillRRectangle(g, gbrush, omloc.X, omloc.Y, mloc.X - omloc.X, mloc.Y - omloc.Y, Radious)
                            Else
                                FillRRectangle(g, New SolidBrush(Color1), omloc.X, omloc.Y, mloc.X - omloc.X, mloc.Y - omloc.Y, Radious)
                            End If
                        End If
                    Case _Shapes.image
                        g.DrawImage(Image, New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                        g.DrawRectangle(New Pen(Color1), New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                End Select
            Else
                Select Case Shape
                    Case _Shapes.Rect
                        g.DrawRectangle(New Pen(Color1), New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                    Case _Shapes.Circle
                        g.DrawEllipse(New Pen(Color1), New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                    Case _Shapes.Line
                        g.DrawLine(New Pen(Color1, thick), New Point(omloc), New Point(mloc))
                    Case _Shapes.RRect
                        If mloc.Y - omloc.Y > Radious Then
                            DrawRRectangle(g, New Rectangle(omloc.X, omloc.Y, mloc.X - omloc.X, mloc.Y - omloc.Y), Radious, New Pen(Color1))
                        End If
                    Case _Shapes.image
                        g.DrawImage(Image, New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                        g.DrawRectangle(New Pen(Color1), New Rectangle(omloc, New Point(mloc.X - omloc.X, mloc.Y - omloc.Y)))
                End Select
            End If
        End If
        If CurRecton = True Then
            If fill Then
                Dim gbrush As LinearGradientBrush
                If CurRect.Width > 0 And CurRect.Height > 0 Then
                    gbrush = New LinearGradientBrush(New Rectangle(New Point(CurRect.X, CurRect.Y - 1), New Point(setWidth(currmewidth, CurRect.Width) - CurRect.Width, CurRect.Height + 2)), Color1, Color2, Angle)
                Else
                    gbrush = New LinearGradientBrush(New Rectangle(1, 1, 1, 1), Color1, Color2, Angle)
                End If
                Select Case Shape
                    Case _Shapes.Rect
                        If Grad Then
                            g.FillRectangle(gbrush, New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height))
                            g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, setWidth(currmewidth, CurRect.Width) - 12, 12))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                        Else
                            g.FillRectangle(New SolidBrush(Color1), New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height))
                            g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                        End If
                    Case _Shapes.Circle
                        If Grad Then

                            g.FillEllipse(gbrush, New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height))
                            g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                        Else
                            g.FillEllipse(New SolidBrush(Color1), New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height))
                            g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                        End If
                    Case _Shapes.Line
                        g.DrawLine(New Pen(Color1, thick), curpt1, curpt2)
                    Case _Shapes.RRect
                        ' If mloc.Y - omloc.Y > Radious Then
                        If Grad Then
                            FillRRectangle(g, gbrush, setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height, Radious)
                            g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                        Else
                            FillRRectangle(g, New SolidBrush(Color1), setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height, Radious)
                            g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                            g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                        End If
                        ' End If
                    Case _Shapes.image
                        g.DrawImage(Image, New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height))
                        g.DrawRectangle(New Pen(Color1), New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height))
                End Select
            Else
                Select Case Shape
                    Case _Shapes.Rect
                        g.DrawRectangle(New Pen(Color1), New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height))
                        g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12))
                        g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                        g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                    Case _Shapes.Circle
                        g.DrawEllipse(New Pen(Color1), New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height))
                        g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12))
                        g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                        g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                    Case _Shapes.Line
                        g.DrawLine(New Pen(Color1, thick), curpt1, curpt2)
                    Case _Shapes.RRect
                        '   If mloc.Y - omloc.Y > Radious Then
                        DrawRRectangle(g, New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height), Radious, New Pen(Color1))
                        g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12))
                        g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                        g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                        '  End If
                    Case _Shapes.image
                        g.DrawImage(Image, New Rectangle(setx(mex, CurRect.X), sety(mey, CurRect.Y), setWidth(currmewidth, CurRect.Width) - CurRect.Width, setHeight(currmeheight, CurRect.Height) - CurRect.Height))
                        g.DrawEllipse(Pens.DarkGray, New Rectangle(CurRect.X - 6, CurRect.Y - 6, 12, 12))
                        g.DrawLine(Pens.DarkCyan, New Point(CurRect.X, CurRect.Y - 6), New Point(CurRect.X, CurRect.Y + 6))
                        g.DrawLine(Pens.DarkCyan, New Point(CurRect.X - 6, CurRect.Y), New Point(CurRect.X + 6, CurRect.Y))
                End Select
            End If
        End If
 
    End Sub
    Public Sub FillRRectangle(ByVal g As Graphics, ByVal brush As Brush, ByVal x As Int32, ByVal y As Int32, ByVal width As Int32, ByVal height As Int32, ByVal radius As Int32)
        Dim area As Rectangle = New Rectangle(x, y, width, height)
        Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath

        'Add the corners
        path.AddArc(area.Left, area.Top, radius * 2, radius * 2, 180, 90) 'Upper-Left
        path.AddArc(area.Right - (radius * 2), area.Top, radius * 2, radius * 2, 270, 90) 'Upper-Right
        path.AddArc(area.Right - (radius * 2), area.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90) 'Lower-Right
        path.AddArc(area.Left, area.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90) 'Lower-Left

        'Fill the rounded rectangle
        g.FillPath(brush, path)
    End Sub
    Public Sub DrawRRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal p As Pen)
        g.DrawArc(p, r.X, r.Y, d, d, 180, 90)
        g.DrawLine(p, CInt(r.X + d / 2), r.Y, CInt(r.X + r.Width - d / 2), r.Y)
        g.DrawArc(p, r.X + r.Width - d, r.Y, d, d, 270, 90)
        g.DrawLine(p, r.X, CInt(r.Y + d / 2), r.X, CInt(r.Y + r.Height - d / 2))
        g.DrawLine(p, CInt(r.X + r.Width), CInt(r.Y + d / 2), CInt(r.X + r.Width), CInt(r.Y + r.Height - d / 2))
        g.DrawLine(p, CInt(r.X + d / 2), CInt(r.Y + r.Height), CInt(r.X + r.Width - d / 2), CInt(r.Y + r.Height))
        g.DrawArc(p, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.DrawArc(p, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
    End Sub
#Region "Controls"
    Public Property DrawingList As New DrawedList
    Class DrawedList
        Inherits List(Of Draws)
    End Class
    Class Draws
        Public Shape As _Shapes
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
        Public Enabled As Integer
        Public mewidth As Boolean
        Public meheight As Boolean
        Public mex As Boolean
        Public mey As Boolean
        Public font As Font
        Public text As String
        Public align As StringFormat
    End Class
#End Region
End Class
