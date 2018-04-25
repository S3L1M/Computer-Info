Public Class Tool
    
    Private Sub PCRF()
        Dim T As Long = (My.Computer.Clock.TickCount / 1000) \ 1
        Dim h As Integer
        Dim m As Short
        Dim s As Short
        s = T Mod 60
        m = ((T - s) / 60) Mod 60
        h = ((T - (s + (m * 60))) / 3600) Mod 60
        Label3.Text = "PC Ran From : " & h & "h" & " " & m & "m" & " " & s & "s"
    End Sub

    Private Sub Tool_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form1.MovableToolStripMenuItem.Checked = False
        Form1.TopMostToolStripMenuItem.Checked = False
        Form1.OpactiyToolStripMenuItem.Checked = True
        Form1.ShowHideToolStripMenuItem.Checked = True
        Form1.ShowHideIconToolStripMenuItem.Checked = False
        Form1.MovableToolStripMenuItem.Enabled = False
        Form1.TopMostToolStripMenuItem.Enabled = False
        Form1.OpactiyToolStripMenuItem.Enabled = False
        Form1.ShowHideToolStripMenuItem.Enabled = False
        Form1.ShowHideIconToolStripMenuItem.Enabled = False
        Form1.CloseToolStripMenuItem1.Enabled = False
        Form1.OpenToolStripMenuItem1.Enabled = True
    End Sub

    Private Sub Tool_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point((My.Computer.Screen.Bounds.Size.Width - Me.Size.Width), (My.Computer.Screen.Bounds.Size.Height - Me.Size.Height) / 2)
        Form1.MovableToolStripMenuItem.Enabled = True
        Form1.TopMostToolStripMenuItem.Enabled = True
        Form1.OpactiyToolStripMenuItem.Enabled = True
        Form1.ShowHideToolStripMenuItem.Enabled = True
        Form1.ShowHideIconToolStripMenuItem.Enabled = True
        Form1.CloseToolStripMenuItem1.Enabled = True
        Form1.OpenToolStripMenuItem1.Enabled = False
        Timer1.Start()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = TimeOfDay
        Label2.Text = Today
        PCRF()
        If My.Computer.Network.IsAvailable = True Then
            PictureBox3.Visible = False
        Else
            PictureBox3.Visible = True
        End If
        ProgressBar1.Value = ((My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory) / My.Computer.Info.TotalPhysicalMemory) * 100 \ 1
        Label4.Text = "RAM Usage : " & ProgressBar1.Value & "%"
        Label6.Text = Cursor.Position.ToString
        If My.Computer.Keyboard.NumLock = True Then Label7.ForeColor = Color.Lime Else Label7.ForeColor = Color.Red
        If My.Computer.Keyboard.CapsLock = True Then Label8.ForeColor = Color.Lime Else Label8.ForeColor = Color.Red
        If My.Computer.Keyboard.CtrlKeyDown = True Then Label9.ForeColor = Color.Lime Else Label9.ForeColor = Color.Red
        If My.Computer.Keyboard.ShiftKeyDown = True Then Label10.ForeColor = Color.Lime Else Label10.ForeColor = Color.Red
        If My.Computer.Keyboard.AltKeyDown = True Then Label11.ForeColor = Color.Lime Else Label11.ForeColor = Color.Red
        If MouseButtons = Windows.Forms.MouseButtons.None Then PictureBox5.Image = My.Resources.Mouse
        If MouseButtons = Windows.Forms.MouseButtons.Left Then PictureBox5.Image = My.Resources.MouseL
        If MouseButtons = Windows.Forms.MouseButtons.Right Then PictureBox5.Image = My.Resources.MouseR
        If MouseButtons = Windows.Forms.MouseButtons.Middle Then PictureBox5.Image = My.Resources.MouseM
        Timer1.Start()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        MsgBox("There isn't any EnterNet", MsgBoxStyle.Information, "Network")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        MsgBox("There is an EnterNet", MsgBoxStyle.Information, "Network")
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        AxWindowsMediaPlayer1.URL = OpenFileDialog1.FileName
        PictureBox4.Visible = False
        Label5.Visible = False
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        PictureBox4.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        PictureBox4.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub AxWindowsMediaPlayer1_ClickEvent(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_ClickEvent) Handles AxWindowsMediaPlayer1.ClickEvent
        If MouseButtons = Windows.Forms.MouseButtons.Right Then
        Else
            OpenFileDialog1.ShowDialog()
        End If
    End Sub
End Class