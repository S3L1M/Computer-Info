Public Class Loker
    Dim a As Boolean = True
    Dim pw As String = Form1.ToolStripTextBox1.Text

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox2.Show()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.Text = "None" Then
            PictureBox1.Hide()
            Me.BackgroundImage = Nothing
        End If

        If ListBox2.Text = "N4S World" Then
            PictureBox1.Show()
            Me.BackgroundImage = My.Resources.need_for_speed_world_wide
            PictureBox1.BackgroundImage = My.Resources.need_for_speed_world_wide
            Label1.BackColor = Color.Transparent
            GroupBox1.BackColor = Color.Transparent
        End If

        If ListBox2.Text = "Windows 7" Then
            PictureBox1.Show()
            Me.BackgroundImage = My.Resources.img0
            PictureBox1.BackgroundImage = My.Resources.img0
            Label1.BackColor = Color.Transparent
            GroupBox1.BackColor = Color.Transparent
        End If

        If ListBox2.Text = "WaterFalls" Then
            PictureBox1.Show()
            Label1.BackColor = Color.Transparent
            GroupBox1.BackColor = Color.Transparent
            Me.BackgroundImage = My.Resources.img10
            PictureBox1.BackgroundImage = My.Resources.img10
        End If

        If ListBox2.Text = "IceLand" Then
            PictureBox1.Show()
            Label1.BackColor = Color.Transparent
            GroupBox1.BackColor = Color.Transparent
            Me.BackgroundImage = My.Resources.img8
            PictureBox1.BackgroundImage = My.Resources.img8
        End If

        If ListBox2.Text = "DimBoys" Then
            PictureBox1.Show()
            Label1.BackColor = Color.Transparent
            GroupBox1.BackColor = Color.Transparent
            Me.BackgroundImage = My.Resources.img24
            PictureBox1.BackgroundImage = My.Resources.img24
        End If

        If ListBox2.Text = "N4S Mazda" Then
            PictureBox1.Show()
            Label1.BackColor = Color.Transparent
            GroupBox1.BackColor = Color.Transparent
            Me.BackgroundImage = My.Resources._39
            PictureBox1.BackgroundImage = My.Resources._39
        End If

        If ListBox2.Text = "N4S HD" Then
            PictureBox1.Show()
            Label1.BackColor = Color.Transparent
            GroupBox1.BackColor = Color.Transparent
            Me.BackgroundImage = My.Resources._564651345
            PictureBox1.BackgroundImage = My.Resources._564651345
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.Text = "Color Gray" Then Me.BackColor = Color.Gray
        If ListBox1.Text = "Color Blue" Then Me.BackColor = Color.SkyBlue
        If ListBox1.Text = "Color Lime" Then Me.BackColor = Color.Lime
        If ListBox1.Text = "Color White" Then Me.BackColor = Color.Snow
        If ListBox1.Text = "Color Aqua" Then Me.BackColor = Color.Aqua
        If ListBox1.Text = "Color Red" Then Me.BackColor = Color.Red
        If ListBox1.Text = "Color Pink" Then Me.BackColor = Color.Pink
        GroupBox1.BackColor = Me.BackColor
        Label1.BackColor = Me.BackColor
        If ListBox1.Text = "Transparent" Then
            GroupBox1.BackColor = Color.Transparent
            Label1.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GroupBox1.Hide()
        Button2.Hide()
        TextBox2.Hide()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = pw Then
            TextBox2.Hide()
            GroupBox1.Show()
            Button2.Show()
            TextBox2.Clear()
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If a = True Then
            e.Cancel = True
        ElseIf a = False Then
            e.Cancel = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = pw Then
            a = False
            Me.Close()
            Form1.Show()
            Tool.Show()
        Else
            a = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Visible = False And Button2.Visible = False Then TextBox2.Show()
        GroupBox1.ForeColor = Color.Blue
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Me.TopMost = True
            Me.BringToFront()
            Me.Focus()
            For Each proc As Process In Process.GetProcesses
                If proc.ProcessName = "taskmgr" Then
                    proc.Kill()
                    Exit For
                End If
            Next
        Catch p01 As Exception
        End Try
        Timer1.Enabled = True
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Opacity = 0.7
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Opacity = 1
    End Sub
End Class
