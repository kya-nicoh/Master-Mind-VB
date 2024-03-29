﻿Public Class Form1
    Dim ctr As Integer = 0
    Dim A(3), num As Integer ' creates 4 blank arrays
    Dim correctcnt As Integer = 0
    Dim endReached As Boolean = False
    Dim activated(23) As Boolean

    Public Sub reset()
        Dim loadbox() As TextBox = {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6,
            TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12, TextBox13, TextBox14,
            TextBox15, TextBox16, TextBox17, TextBox18, TextBox19, TextBox20, TextBox21, TextBox22,
            TextBox23, TextBox24}
        Dim score() As Label = {Label1, Label2, Label3, Label4, Label5, Label6}
        Dim shownum() As Label = {Label8, Label9, Label10, Label11}

        ctr = 0
        Button5.Enabled = True
        Button5.Visible = True

        For x = 0 To 5
            score(x).Text = "0"
        Next

        For x = 0 To 23
            loadbox(x).Enabled = False
            activated(x) = False
            loadbox(x).Text = ""
        Next

        For x = 0 To 3 ' sets numbers in in display
            shownum(x).Text = A(x)
            shownum(x).ForeColor = Color.Red
        Next

    End Sub

    Public Sub textBoxLoop()
        Dim col As Integer
        Dim txtbox(,) As TextBox = {{TextBox1, TextBox2, TextBox3, TextBox4},
                                    {TextBox5, TextBox6, TextBox7, TextBox8},
                                    {TextBox9, TextBox10, TextBox11, TextBox12},
                                    {TextBox13, TextBox14, TextBox15, TextBox16},
                                    {TextBox17, TextBox18, TextBox19, TextBox20},
                                    {TextBox21, TextBox22, TextBox23, TextBox24}}
        Dim shownum() As Label = {Label8, Label9, Label10, Label11}

        ' disables all except active row
        If ctr = 0 Then
            For x = 1 To 5
                For y = 0 To 3
                    txtbox(x, y).Enabled = False
                Next
            Next
        End If
        ' main game loop
        For col = 0 To 3
            If ctr = 4 Then
                txtbox(0, col).Enabled = False ' disables current row
                If txtbox(0, col).Text = A(col) Then
                    correctcnt += 1
                End If
                Label1.Text = correctcnt ' shows number of correct guesses
                For x = 0 To 3 ' enables next row of textbox
                    txtbox(0 + 1, col).Enabled = True
                Next
            ElseIf ctr = 8 Then
                txtbox(1, col).Enabled = False
                If txtbox(1, col).Text = A(col) Then
                    correctcnt += 1
                End If
                Label2.Text = correctcnt
                For x = 0 To 3
                    txtbox(1 + 1, col).Enabled = True
                Next
            ElseIf ctr = 12 Then
                txtbox(2, col).Enabled = False
                If txtbox(2, col).Text = A(col) Then
                    correctcnt += 1
                End If
                Label3.Text = correctcnt
                For x = 0 To 3
                    txtbox(2 + 1, col).Enabled = True
                Next
            ElseIf ctr = 16 Then
                txtbox(3, col).Enabled = False
                If txtbox(3, col).Text = A(col) Then
                    correctcnt += 1
                End If
                Label4.Text = correctcnt
                For x = 0 To 3
                    txtbox(3 + 1, col).Enabled = True
                Next
            ElseIf ctr = 20 Then
                txtbox(4, col).Enabled = False
                If txtbox(4, col).Text = A(col) Then
                    correctcnt += 1
                End If
                Label5.Text = correctcnt
                For x = 0 To 3
                    txtbox(4 + 1, col).Enabled = True
                Next
            ElseIf ctr > 24 Then
                txtbox(5, col).Enabled = False
                If txtbox(5, col).Text = A(col) Then
                    correctcnt += 1
                End If
                Label6.Text = correctcnt
            End If

            If col = 3 And Not correctcnt = 4 Then
                correctcnt = 0
            End If
        Next col

        ' checks if game reached the end
        If ctr = 24 And correctcnt < 4 Then
            endReached = True
        End If
        If endReached = True Then
            Label12.Text = "YOU LOSE"
            Label12.ForeColor = Color.Red
            reset()
        End If
        ' win condition
        If correctcnt = 4 Then
            Label12.Text = "YOU FOUND IT"
            Label12.ForeColor = Color.Green
            reset()
        End If

        ' DEBUG
        ' Label7.Text = Str(ctr)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Randomize()
        Dim lotnum() As Label = {Label8, Label9, Label10, Label11}
        Dim txtBox() As TextBox = {TextBox1, TextBox2, TextBox3, TextBox4}
        Dim shownum() As Label = {Label8, Label9, Label10, Label11}
        endReached = False
        Label12.Text = ""
        correctcnt = 0

        For i = 0 To 3 ' counts to 4
            A(i) = -1
        Next i

        For j = 0 To 3 ' 4 random unique numbers
            If A(j) = -1 Then
                num = Int(Rnd() * 6) + 1
                While A.Contains(num)
                    num = Int(Rnd() * 6) + 1
                End While
            End If
            A(j) = num
        Next j

        For x = 0 To 3 ' sets numbers in in display
            shownum(x).Text = "?"
            shownum(x).ForeColor = Color.Black
        Next

        For x = 0 To 3 ' enables first row
            txtBox(x).Enabled = True
        Next

        Button5.Enabled = False
        Button5.Visible = False
        textBoxLoop()
    End Sub
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim loadbox() As TextBox = {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8,
                                    TextBox9, TextBox10, TextBox11, TextBox12, TextBox13, TextBox14, TextBox15, TextBox16,
                                    TextBox17, TextBox18, TextBox19, TextBox20, TextBox21, TextBox22, TextBox23, TextBox24}
        For x = 0 To 23
            loadbox(x).Enabled = False
            activated(x) = False
        Next
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ctr += 1
        textBoxLoop()

        TextBox1.Enabled = False
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ctr += 1
        textBoxLoop()

        TextBox2.Enabled = False
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ctr += 1
        textBoxLoop()

        TextBox3.Enabled = False

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox4.Enabled = False

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox5.Enabled = False

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox6.Enabled = False

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox7.Enabled = False

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox8.Enabled = False

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox9.Enabled = False

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox10.Enabled = False

    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox11.Enabled = False

    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox12.Enabled = False

    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox13.Enabled = False

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox14.Enabled = False

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox15.Enabled = False

    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox16.Enabled = False

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox17.Enabled = False

    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox18.Enabled = False

    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox19.Enabled = False

    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox20.Enabled = False

    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox21.Enabled = False

    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox22.Enabled = False

    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox23.Enabled = False

    End Sub

    Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs) Handles TextBox24.TextChanged
        ctr += 1
        textBoxLoop()
        TextBox24.Enabled = False

    End Sub


    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        TextBox1.Text = ""
    End Sub
    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        TextBox2.Text = ""
    End Sub

    Private Sub TextBox3_GotFocus(sender As Object, e As EventArgs) Handles TextBox3.GotFocus
        TextBox3.Text = ""
    End Sub

    Private Sub TextBox4_GotFocus(sender As Object, e As EventArgs) Handles TextBox4.GotFocus
        TextBox4.Text = ""
    End Sub

    Private Sub TextBox5_GotFocus(sender As Object, e As EventArgs) Handles TextBox5.GotFocus
        TextBox5.Text = ""
    End Sub

    Private Sub TextBox6_GotFocus(sender As Object, e As EventArgs) Handles TextBox6.GotFocus
        TextBox6.Text = ""
    End Sub

    Private Sub TextBox7_GotFocus(sender As Object, e As EventArgs) Handles TextBox7.GotFocus
        TextBox7.Text = ""
    End Sub
    Private Sub TextBox8_GotFocus(sender As Object, e As EventArgs) Handles TextBox8.GotFocus
        TextBox8.Text = ""
    End Sub

    Private Sub TextBox9_GotFocus(sender As Object, e As EventArgs) Handles TextBox9.GotFocus
        TextBox9.Text = ""
    End Sub

    Private Sub TextBox10_GotFocus(sender As Object, e As EventArgs) Handles TextBox10.GotFocus
        TextBox10.Text = ""
    End Sub

    Private Sub TextBox11_GotFocus(sender As Object, e As EventArgs) Handles TextBox11.GotFocus
        TextBox11.Text = ""
    End Sub

    Private Sub TextBox12_GotFocus(sender As Object, e As EventArgs) Handles TextBox12.GotFocus
        TextBox12.Text = ""
    End Sub


    Private Sub TextBox13_GotFocus(sender As Object, e As EventArgs) Handles TextBox13.GotFocus
        TextBox13.Text = ""
    End Sub
    Private Sub TextBox14_GotFocus(sender As Object, e As EventArgs) Handles TextBox14.GotFocus
        TextBox14.Text = ""
    End Sub

    Private Sub TextBox15_GotFocus(sender As Object, e As EventArgs) Handles TextBox15.GotFocus
        TextBox15.Text = ""
    End Sub

    Private Sub TextBox16_GotFocus(sender As Object, e As EventArgs) Handles TextBox16.GotFocus
        TextBox16.Text = ""
    End Sub


    Private Sub TextBox17_GotFocus(sender As Object, e As EventArgs) Handles TextBox17.GotFocus
        TextBox17.Text = ""
    End Sub

    Private Sub TextBox18_GotFocus(sender As Object, e As EventArgs) Handles TextBox18.GotFocus
        TextBox18.Text = ""
    End Sub

    Private Sub TextBox19_GotFocus(sender As Object, e As EventArgs) Handles TextBox19.GotFocus
        TextBox19.Text = ""
    End Sub
    Private Sub TextBox20_GotFocus(sender As Object, e As EventArgs) Handles TextBox20.GotFocus
        TextBox20.Text = ""
    End Sub


    Private Sub TextBox21_GotFocus(sender As Object, e As EventArgs) Handles TextBox21.GotFocus
        TextBox21.Text = ""
    End Sub

    Private Sub TextBox22_GotFocus(sender As Object, e As EventArgs) Handles TextBox22.GotFocus
        TextBox22.Text = ""
    End Sub

    Private Sub TextBox23_GotFocus(sender As Object, e As EventArgs) Handles TextBox23.GotFocus
        TextBox23.Text = ""
    End Sub

    Private Sub TextBox24_GotFocus(sender As Object, e As EventArgs) Handles TextBox24.GotFocus
        TextBox24.Text = ""
    End Sub
End Class
