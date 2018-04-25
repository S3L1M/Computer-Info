Imports System.Management
Imports Microsoft.Win32

Public Class Form1
    Public Function GetTime(ByVal Time As Long) As Date
        Dim Hrs As Integer
        Dim Min As Integer
        Dim Sec As Integer
        Sec = Time Mod 60
        Min = ((Time - Sec) / 60) Mod 60
        Hrs = ((Time - (Sec + (Min * 60))) / 3600) Mod 60
        Return Format(Hrs, "00") & ":" & Format(Min, "00") & ":" & Format(Sec, "00")
    End Function

    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, _
                                                                                   ByVal lpstrReturnString As String, _
                                                                                   ByVal uReturnLength As Integer, _
                                                                                   ByVal hwndCallback As Integer) As Integer

    Public Function SerialNum(ByVal Drive As String) As String 'Get HD Serial Number
        If Drive = "" OrElse Drive Is Nothing Then
            Drive = "C"
        End If
        Dim moHD As New ManagementObject("Win32_LogicalDisk.DeviceID=""" + Drive + ":""")
        moHD.[Get]()
        Return moHD("VolumeSerialNumber").ToString()
    End Function

    Private obj1 As ManagementObjectSearcher
    Private obj2 As ManagementObjectSearcher
    Private m_Manufacturer As String
    Private m_Model As String
    Private m_SystemType As String
    Private m_TPM As String
    Private m_WindowsDir As String

    Public Sub NewInfo()
        obj1 = New ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
        obj2 = New ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem")
        For Each objMgmt In obj1.Get
            m_WindowsDir = objMgmt("windowsdirectory").ToString()
        Next
        For Each objMgmt In obj2.Get
            m_Manufacturer = objMgmt("manufacturer").ToString()
            m_Model = objMgmt("model").ToString()
            m_SystemType = objMgmt("systemtype").ToString
        Next
    End Sub

    Dim t As Single = My.Computer.Info.TotalPhysicalMemory / 1073741824
    Dim a As Single = My.Computer.Info.AvailablePhysicalMemory / 1073741824
    Dim cdrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("C:\")
    Dim ddrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("D:\")
    Dim edrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("E:\")
    Dim fdrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("F:\")
    Dim gdrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("G:\")
    Dim hdrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("H:\")
    Dim idrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("I:\")
    Dim jdrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("J:\")
    Dim kdrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("K:\")
    Dim ldrive As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo("L:\")

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Computer.Audio.Play(My.Resources.Bye, AudioPlayMode.Background)
        MsgBox("Bye ;) Thanks for using", MsgBoxStyle.Information, "Closed")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Lod.Show()
        TabPage1.Select()
        Me.Size = New Size(GroupBox1.Size.Width + 40, GroupBox1.Size.Height + 102)
        TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
        Me.ForeColor = Color.Black
        Label1.Text = "Computer Name : " & My.Computer.Name
        Label2.Text = "OS Name : " & My.Computer.Info.OSFullName
        Label3.Text = "OS Version : " & My.Computer.Info.OSVersion
        Label4.Text = "OS Platform : " & My.Computer.Info.OSPlatform
        If Label2.Text.Contains("Windows") = True Or Label4.Text = "Win32NT" Then
            PictureBox8.Image = My.Resources.Windows1
            Label34.Text = "Windows"
        ElseIf Label2.Text.Contains("Apple") = True Then
            PictureBox8.Image = My.Resources.Apple_Rainbow
            Label34.Text = "Windows"
        ElseIf Label2.Text.Contains("Debian") = True Then
            PictureBox8.Image = My.Resources.Debian
            Label34.Text = "Debian"
        ElseIf Label2.Text.Contains("Etoile") = True Then
            PictureBox8.Image = My.Resources.Etoile
            Label34.Text = "Etoile"
        ElseIf Label2.Text.Contains("Fedora") = True Then
            PictureBox8.Image = My.Resources.Fedora
            Label34.Text = "Fedora"
        ElseIf Label2.Text.Contains("Finder") = True Then
            PictureBox8.Image = My.Resources.Finder
            Label34.Text = "Finder"
        ElseIf Label2.Text.Contains("Freespire") = True Then
            PictureBox8.Image = My.Resources.Freespire
            Label34.Text = "Freespire"
        ElseIf Label2.Text.Contains("Globe") = True Then
            PictureBox8.Image = My.Resources.Globe
            Label34.Text = "Globe"
        ElseIf Label2.Text.Contains("Gnome") = True Then
            PictureBox8.Image = My.Resources.Gnome
            Label34.Text = "Gnome"
        ElseIf Label2.Text.Contains("KDE") = True Then
            PictureBox8.Image = My.Resources.KDE
            Label34.Text = "KDE"
        ElseIf Label2.Text.Contains("Konqueror") = True Then
            PictureBox8.Image = My.Resources.Konqueror
            Label34.Text = "Konqueror"
        ElseIf Label2.Text.Contains("Linux") = True Then
            PictureBox8.Image = My.Resources.Linux
            Label34.Text = "Linux"
        ElseIf Label2.Text.Contains("Mandriva") = True Then
            PictureBox8.Image = My.Resources.Mandriva
            Label34.Text = "Mandriva"
        ElseIf Label2.Text.Contains("Ubuntu") = True Then
            PictureBox8.Image = My.Resources.Ubuntu
            Label34.Text = "Ubuntu"
        Else
            Label34.Text = "Other or Not Detcted"
            PictureBox1.Hide()
        End If
        Label5.Text = "Total of RAM : " & t & " GB" & " ≈ " & t \ 1 & " GB"
        Label6.Text = "Used of RAM : " & t - a & " GB" & " ≈ " & (t - a) \ 1 & " GB"
        Label7.Text = "Available of RAM : " & a & " GB" & " ≈ " & a \ 1 & " GB"
        Label32.Text = ((t - a) / t) * 100 \ 1 & " %"
        ProgressBar2.Value = ((t - a) / t) * 100 \ 1
        Label8.Text = "Network Working : " & My.Computer.Network.IsAvailable
        If My.Computer.Network.IsAvailable = True Then
            PictureBox10.Show()
            PictureBox9.Hide()
        ElseIf My.Computer.Network.IsAvailable = False Then
            PictureBox9.Show()
            PictureBox10.Hide()
        End If
        If cdrive.IsReady = True Then ListBox1.Items.Add(cdrive.VolumeLabel & "(C:)")
        If ddrive.IsReady = True Then ListBox1.Items.Add(ddrive.VolumeLabel & "(D:)")
        If edrive.IsReady = True Then ListBox1.Items.Add(edrive.VolumeLabel & "(E:)")
        If fdrive.IsReady = True Then ListBox1.Items.Add(fdrive.VolumeLabel & "(F:)")
        If gdrive.IsReady = True Then ListBox1.Items.Add(gdrive.VolumeLabel & "(G:)")
        If hdrive.IsReady = True Then ListBox1.Items.Add(hdrive.VolumeLabel & "(H:)")
        If idrive.IsReady = True Then ListBox1.Items.Add(idrive.VolumeLabel & "(I:)")
        If jdrive.IsReady = True Then ListBox1.Items.Add(jdrive.VolumeLabel & "(J:)")
        If kdrive.IsReady = True Then ListBox1.Items.Add(kdrive.VolumeLabel & "(K:)")
        If ldrive.IsReady = True Then ListBox1.Items.Add(ldrive.VolumeLabel & "(L:)")
        ListBox1.SelectedIndex = 0
        Label19.Text = "Device Count : " & ListBox1.Items.Count
        Label13.Text = "Computer IP : " & System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString
        Label20.Text = "Host Name : " & System.Net.Dns.GetHostName
        Label14.Text = "Device Name : " & My.Computer.Screen.DeviceName
        Label15.Text = "Size : " & My.Computer.Screen.Bounds.Size.ToString
        Label16.Text = "Colors in pixel : " & My.Computer.Screen.BitsPerPixel & " Color/Pixel"
        Label17.Text = "Is Primary : " & My.Computer.Screen.Primary
        Label36.Text = My.Computer.Screen.Bounds.Size.Width
        Label37.Text = My.Computer.Screen.Bounds.Size.Height
        NewInfo()
        Label21.Text = "Manufacturer : " & m_Manufacturer
        Label22.Text = "Model : " & m_Model
        Label23.Text = "System Type : " & m_SystemType
        Label24.Text = "System Languge : " & System.Globalization.CultureInfo.CurrentCulture.DisplayName
        Label25.Text = "Windows Directory : " & m_WindowsDir
        For Each p As Process In Process.GetProcesses
            ListBox2.Items.Add(p.ProcessName)
        Next
        For Each p As Process In Process.GetProcesses
            ListBox3.Items.Add(p.MainWindowTitle)
        Next
        For Each p As Process In Process.GetProcesses
            ListBox4.Items.Add(p.Id & ";" & p.Responding)
        Next
        Lod.Close()
        Tool.Show()
        My.Computer.Audio.Play(My.Resources.Welcome, AudioPlayMode.Background)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Label1.Text = "Computer Name : " & My.Computer.Name
        Label2.Text = "OS Name : " & My.Computer.Info.OSFullName
        Label3.Text = "OS Version : " & My.Computer.Info.OSVersion
        Label4.Text = "OS Platform : " & My.Computer.Info.OSPlatform
        If Label2.Text.Contains("Windows") = True Or Label4.Text = "Win32NT" Then
            PictureBox8.Image = My.Resources.Windows1
            Label34.Text = "Windows"
        ElseIf Label2.Text.Contains("Apple") = True Then
            PictureBox8.Image = My.Resources.Apple_Rainbow
            Label34.Text = "Windows"
        ElseIf Label2.Text.Contains("Debian") = True Then
            PictureBox8.Image = My.Resources.Debian
            Label34.Text = "Debian"
        ElseIf Label2.Text.Contains("Etoile") = True Then
            PictureBox8.Image = My.Resources.Etoile
            Label34.Text = "Etoile"
        ElseIf Label2.Text.Contains("Fedora") = True Then
            PictureBox8.Image = My.Resources.Fedora
            Label34.Text = "Fedora"
        ElseIf Label2.Text.Contains("Finder") = True Then
            PictureBox8.Image = My.Resources.Finder
            Label34.Text = "Finder"
        ElseIf Label2.Text.Contains("Freespire") = True Then
            PictureBox8.Image = My.Resources.Freespire
            Label34.Text = "Freespire"
        ElseIf Label2.Text.Contains("Globe") = True Then
            PictureBox8.Image = My.Resources.Globe
            Label34.Text = "Globe"
        ElseIf Label2.Text.Contains("Gnome") = True Then
            PictureBox8.Image = My.Resources.Gnome
            Label34.Text = "Gnome"
        ElseIf Label2.Text.Contains("KDE") = True Then
            PictureBox8.Image = My.Resources.KDE
            Label34.Text = "KDE"
        ElseIf Label2.Text.Contains("Konqueror") = True Then
            PictureBox8.Image = My.Resources.Konqueror
            Label34.Text = "Konqueror"
        ElseIf Label2.Text.Contains("Linux") = True Then
            PictureBox8.Image = My.Resources.Linux
            Label34.Text = "Linux"
        ElseIf Label2.Text.Contains("Mandriva") = True Then
            PictureBox8.Image = My.Resources.Mandriva
            Label34.Text = "Mandriva"
        ElseIf Label2.Text.Contains("Ubuntu") = True Then
            PictureBox8.Image = My.Resources.Ubuntu
            Label34.Text = "Ubuntu"
        Else
            Label34.Text = "Other or Not Detcted"
            PictureBox1.Hide()
        End If
        Label5.Text = "Total of RAM : " & t & " GB" & " ≈ " & t \ 1 & " GB"
        Label6.Text = "Used of RAM : " & t - a & " GB" & " ≈ " & (t - a) \ 1 & " GB"
        Label7.Text = "Available of RAM : " & a & " GB" & " ≈ " & a \ 1 & " GB"
        Label8.Text = "Network Working : " & My.Computer.Network.IsAvailable
        If My.Computer.Network.IsAvailable = True Then
            PictureBox10.Show()
            PictureBox9.Hide()
        ElseIf My.Computer.Network.IsAvailable = False Then
            PictureBox9.Show()
            PictureBox10.Hide()
        End If
        ListBox1.Items.Clear()
        If cdrive.IsReady = True Then ListBox1.Items.Add(cdrive.VolumeLabel & "(C:)")
        If ddrive.IsReady = True Then ListBox1.Items.Add(ddrive.VolumeLabel & "(D:)")
        If edrive.IsReady = True Then ListBox1.Items.Add(edrive.VolumeLabel & "(E:)")
        If fdrive.IsReady = True Then ListBox1.Items.Add(fdrive.VolumeLabel & "(F:)")
        If gdrive.IsReady = True Then ListBox1.Items.Add(gdrive.VolumeLabel & "(G:)")
        If hdrive.IsReady = True Then ListBox1.Items.Add(hdrive.VolumeLabel & "(H:)")
        If idrive.IsReady = True Then ListBox1.Items.Add(idrive.VolumeLabel & "(I:)")
        If jdrive.IsReady = True Then ListBox1.Items.Add(jdrive.VolumeLabel & "(J:)")
        If kdrive.IsReady = True Then ListBox1.Items.Add(kdrive.VolumeLabel & "(K:)")
        If ldrive.IsReady = True Then ListBox1.Items.Add(ldrive.VolumeLabel & "(L:)")
        Label19.Text = "Device Count : " & ListBox1.Items.Count
        Label13.Text = "Computer IP : " & System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString
        Label20.Text = "Host Name : " & System.Net.Dns.GetHostName
        Label14.Text = "Device Name : " & My.Computer.Screen.DeviceName
        Label15.Text = "Size : " & My.Computer.Screen.Bounds.Size.ToString
        Label16.Text = "Colors in pixel : " & My.Computer.Screen.BitsPerPixel & " Color/Pixel"
        Label17.Text = "Is Primary : " & My.Computer.Screen.Primary
        NewInfo()
        Label21.Text = "Manufacturer : " & m_Manufacturer
        Label22.Text = "Model : " & m_Model
        Label24.Text = "System Languge : " & System.Globalization.CultureInfo.CurrentCulture.DisplayName
        Label23.Text = "System Type : " & m_SystemType
        Label25.Text = "Windows Directory : " & m_WindowsDir
        TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
        ListBox2.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox2.Items.Add(p.ProcessName)
        Next
        ListBox3.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox3.Items.Add(p.MainWindowTitle)
        Next
        ListBox4.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox4.Items.Add(p.Id & ";" & p.Responding)
        Next
        Me.Hide()
        Me.Show()
        Me.Refresh()
        My.Computer.Audio.Play(My.Resources.Refreshed, AudioPlayMode.Background)
        MsgBox("Program has been refreshed", MsgBoxStyle.Information, "Refersh")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub RightsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightsToolStripMenuItem.Click
        My.Computer.Audio.Play(My.Resources.Rights, AudioPlayMode.Background)
        MsgBox("ALL Rights © Are Reserved To *-'Mohamed Selim'-*", MsgBoxStyle.SystemModal, "Credits")
    End Sub

    Private Sub VersoinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VersoinToolStripMenuItem.Click
        My.Computer.Audio.Play(My.Resources.V, AudioPlayMode.Background)
        MsgBox("Computer Information v3.0 (The Lastest Version)", MsgBoxStyle.Information, "VerSion")
    End Sub

    Private Sub TransparentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranspatToolStripMenuItem.Click
        Me.BackColor = Color.Snow
        TabPage1.BackColor = Me.BackColor
        TabPage2.BackColor = Me.BackColor
        TabPage3.BackColor = Me.BackColor
        TabPage4.BackColor = Me.BackColor
        TabPage5.BackColor = Me.BackColor
        TabPage6.BackColor = Me.BackColor
        TabPage7.BackColor = Me.BackColor
        ListBox1.BackColor = Me.BackColor
        LinkLabel1.BackColor = Me.BackColor
        LinkLabel8.BackColor = Me.BackColor
        LinkLabel9.BackColor = Me.BackColor
        TranspatToolStripMenuItem.Checked = True
        WhiteToolStripMenuItem1.Checked = False
        LightBlueToolStripMenuItem.Checked = False
        LightRedToolStripMenuItem.Checked = False
        LmeToolStripMenuItem.Checked = False
        SandToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem1.Checked = False
    End Sub

    Private Sub TimeDateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeDateToolStripMenuItem1.Click
        My.Computer.Audio.Play(My.Resources.untitled, AudioPlayMode.Background)
        MsgBox("Time&Dare : " & Now)
    End Sub

    Private Sub TimeOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeOnlyToolStripMenuItem.Click
        My.Computer.Audio.Play(My.Resources.Time, AudioPlayMode.Background)
        MsgBox("Time : " & TimeOfDay)
    End Sub

    Private Sub DateOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateOnlyToolStripMenuItem.Click
        My.Computer.Audio.Play(My.Resources._Date, AudioPlayMode.Background)
        MsgBox("Date : " & Today)
    End Sub

    Private Sub TheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TheToolStripMenuItem.Click
        If My.Computer.Clock.TickCount = 0 Then
            MsgBox("Your clock battary of the computer not working, Chech it out" & vbCrLf & "Replace your matherboard battary If it not working", MsgBoxStyle.Exclamation)
        Else
            My.Computer.Audio.Play(My.Resources.O, AudioPlayMode.Background)
            MsgBox("The Computer Opened From : " & My.Computer.Clock.TickCount \ 60000 & " Minute", MsgBoxStyle.Information, "The Computer Opened From")
        End If
    End Sub

    Private Sub ComputerOpiningTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComputerOpiningTimeToolStripMenuItem.Click
        Try
            If My.Computer.Clock.TickCount = 0 Then
                MsgBox("Your clock battary of the computer not working, Chech it out" & vbCrLf & "Replace your mathterborad battary If it not working", MsgBoxStyle.Exclamation, "Error")
            Else
                Dim a As Long = (My.Computer.Clock.LocalTime.Hour * 3600 + My.Computer.Clock.LocalTime.Minute * 60 _
                 + My.Computer.Clock.LocalTime.Second) - (My.Computer.Clock.TickCount \ 1000)
                My.Computer.Audio.Play(My.Resources.OO, AudioPlayMode.Background)
                MsgBox("Today : " & GetTime(a), MsgBoxStyle.Information, "Computer Opening Time")
            End If
        Catch p1y1 As Exception
            Try
                Dim a0 As Long = (My.Computer.Clock.LocalTime.Hour * 3600 + My.Computer.Clock.LocalTime.Minute * 60 _
                                     + My.Computer.Clock.LocalTime.Second) + (24 * 3600) - (My.Computer.Clock.TickCount \ 1000)
                My.Computer.Audio.Play(My.Resources.OO, AudioPlayMode.Background)
                MsgBox("Yesterday : " & GetTime(a0), MsgBoxStyle.Information, "Computer Opening Time")
            Catch p1y2 As Exception
                Try
                    Dim a0 As Long = (My.Computer.Clock.LocalTime.Hour * 3600 + My.Computer.Clock.LocalTime.Minute * 60 _
                                         + My.Computer.Clock.LocalTime.Second) + (48 * 3600) - (My.Computer.Clock.TickCount \ 1000)
                    My.Computer.Audio.Play(My.Resources.OO, AudioPlayMode.Background)
                    MsgBox("From 2 Days at : " & GetTime(a0), MsgBoxStyle.Information, "Computer Opening Time")
                Catch p1y3 As Exception
                    Try
                        Dim a0 As Long = (My.Computer.Clock.LocalTime.Hour * 3600 + My.Computer.Clock.LocalTime.Minute * 60 _
                                         + My.Computer.Clock.LocalTime.Second) + (3 * 24 * 3600) - (My.Computer.Clock.TickCount \ 1000)
                        My.Computer.Audio.Play(My.Resources.OO, AudioPlayMode.Background)
                        MsgBox("From 3 Days : " & GetTime(a0), MsgBoxStyle.Information, "Computer Opening Time")
                    Catch p1y4 As Exception
                        Try
                            Dim a0 As Long = (My.Computer.Clock.LocalTime.Hour * 3600 + My.Computer.Clock.LocalTime.Minute * 60 _
                                         + My.Computer.Clock.LocalTime.Second) + (4 * 24 * 3600) - (My.Computer.Clock.TickCount \ 1000)
                            My.Computer.Audio.Play(My.Resources.OO, AudioPlayMode.Background)
                            MsgBox("From 4 Days : " & GetTime(a0), MsgBoxStyle.Information, "Computer Openong Time")
                        Catch p1y5 As Exception
                            Try
                                Dim a0 As Long = (My.Computer.Clock.LocalTime.Hour * 3600 + My.Computer.Clock.LocalTime.Minute * 60 _
                                         + My.Computer.Clock.LocalTime.Second) + (5 * 24 * 3600) - (My.Computer.Clock.TickCount \ 1000)
                                My.Computer.Audio.Play(My.Resources.OO, AudioPlayMode.Background)
                                MsgBox("From 5 Days at : " & GetTime(a0), MsgBoxStyle.Information, "Coputer Opening Time")
                                MsgBox("Please Shutdown You Copmuter Now" & vbCrLf & "That's alot, to Save The Compuer Healthy" & vbCrLf & "If You Have a Laptop this program Calculate from last shutdown not Hibernat", MsgBoxStyle.Exclamation, "Computer Opening Time")
                                My.Computer.Audio.Play(My.Resources.E, AudioPlayMode.Background)
                            Catch p00 As Exception
                                My.Computer.Audio.Play(My.Resources.E0, AudioPlayMode.Background)
                                MsgBox("Out of Calculating Time, please Shutdown your Computer and Try again", MsgBoxStyle.Exclamation, "Error")
                            End Try
                        End Try
                    End Try
                End Try
            End Try
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Me.Opacity = 1
        ToolStripMenuItem2.Checked = True
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        DeafultToolStripMenuItem.Checked = False
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Me.Opacity = 0.8
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = True
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        DeafultToolStripMenuItem.Checked = False
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Me.Opacity = 0.6
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = True
        ToolStripMenuItem5.Checked = False
        DeafultToolStripMenuItem.Checked = False
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Me.Opacity = 0.4
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = True
        DeafultToolStripMenuItem.Checked = False
    End Sub

    Private Sub DeafultToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeafultToolStripMenuItem.Click
        Me.Opacity = 1
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        DeafultToolStripMenuItem.Checked = True
    End Sub

    Private Sub DefaultToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultToolStripMenuItem1.Click
        Me.BackColor = Color.WhiteSmoke
        ListBox1.BackColor = Color.White
        TabPage1.BackColor = Me.BackColor
        TabPage2.BackColor = Me.BackColor
        TabPage3.BackColor = Me.BackColor
        TabPage4.BackColor = Me.BackColor
        TabPage5.BackColor = Me.BackColor
        TabPage6.BackColor = Me.BackColor
        TabPage7.BackColor = Me.BackColor
        LinkLabel1.BackColor = ListBox1.BackColor
        LinkLabel8.BackColor = Me.BackColor
        LinkLabel9.BackColor = Me.BackColor
        TranspatToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem1.Checked = False
        LightBlueToolStripMenuItem.Checked = False
        LightRedToolStripMenuItem.Checked = False
        LmeToolStripMenuItem.Checked = False
        SandToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem1.Checked = True
    End Sub

    Private Sub SandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SandToolStripMenuItem.Click
        Me.BackColor = Color.SandyBrown
        ListBox1.BackColor = Me.BackColor
        TabPage1.BackColor = Me.BackColor
        TabPage2.BackColor = Me.BackColor
        TabPage3.BackColor = Me.BackColor
        TabPage4.BackColor = Me.BackColor
        TabPage5.BackColor = Me.BackColor
        TabPage6.BackColor = Me.BackColor
        TabPage7.BackColor = Me.BackColor
        LinkLabel1.BackColor = ListBox1.BackColor
        LinkLabel8.BackColor = Me.BackColor
        LinkLabel9.BackColor = Me.BackColor
        TranspatToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem1.Checked = False
        LightBlueToolStripMenuItem.Checked = False
        LightRedToolStripMenuItem.Checked = False
        LmeToolStripMenuItem.Checked = False
        SandToolStripMenuItem.Checked = True
        DefaultToolStripMenuItem1.Checked = False
    End Sub

    Private Sub LmeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LmeToolStripMenuItem.Click
        Me.BackColor = Color.Lime
        ListBox1.BackColor = Me.BackColor
        TabPage1.BackColor = Me.BackColor
        TabPage2.BackColor = Me.BackColor
        TabPage3.BackColor = Me.BackColor
        TabPage4.BackColor = Me.BackColor
        TabPage5.BackColor = Me.BackColor
        TabPage6.BackColor = Me.BackColor
        TabPage7.BackColor = Me.BackColor
        LinkLabel1.BackColor = ListBox1.BackColor
        LinkLabel8.BackColor = Me.BackColor
        LinkLabel9.BackColor = Me.BackColor
        TranspatToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem1.Checked = False
        LightBlueToolStripMenuItem.Checked = False
        LightRedToolStripMenuItem.Checked = False
        LmeToolStripMenuItem.Checked = True
        SandToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem1.Checked = False
    End Sub

    Private Sub LightRedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LightRedToolStripMenuItem.Click
        Me.BackColor = Color.Pink
        ListBox1.BackColor = Me.BackColor
        TabPage1.BackColor = Me.BackColor
        TabPage2.BackColor = Me.BackColor
        TabPage3.BackColor = Me.BackColor
        TabPage4.BackColor = Me.BackColor
        TabPage5.BackColor = Me.BackColor
        TabPage6.BackColor = Me.BackColor
        TabPage7.BackColor = Me.BackColor
        LinkLabel1.BackColor = ListBox1.BackColor
        LinkLabel8.BackColor = Me.BackColor
        LinkLabel9.BackColor = Me.BackColor
        TranspatToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem1.Checked = False
        LightBlueToolStripMenuItem.Checked = False
        LightRedToolStripMenuItem.Checked = True
        LmeToolStripMenuItem.Checked = False
        SandToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem1.Checked = False
    End Sub

    Private Sub LightBlueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LightBlueToolStripMenuItem.Click
        Me.BackColor = Color.Aqua
        ListBox1.BackColor = Me.BackColor
        TabPage1.BackColor = Me.BackColor
        TabPage2.BackColor = Me.BackColor
        TabPage3.BackColor = Me.BackColor
        TabPage4.BackColor = Me.BackColor
        TabPage5.BackColor = Me.BackColor
        TabPage6.BackColor = Me.BackColor
        TabPage7.BackColor = Me.BackColor
        LinkLabel1.BackColor = ListBox1.BackColor
        LinkLabel8.BackColor = Me.BackColor
        LinkLabel9.BackColor = Me.BackColor
        TranspatToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem1.Checked = False
        LightBlueToolStripMenuItem.Checked = True
        LightRedToolStripMenuItem.Checked = False
        LmeToolStripMenuItem.Checked = False
        SandToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem1.Checked = False
    End Sub

    Private Sub WhiteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhiteToolStripMenuItem1.Click
        Me.BackColor = Color.White
        ListBox1.BackColor = Me.BackColor
        TabPage1.BackColor = Me.BackColor
        TabPage2.BackColor = Me.BackColor
        TabPage3.BackColor = Me.BackColor
        TabPage4.BackColor = Me.BackColor
        TabPage5.BackColor = Me.BackColor
        TabPage6.BackColor = Me.BackColor
        TabPage7.BackColor = Me.BackColor
        LinkLabel1.BackColor = ListBox1.BackColor
        LinkLabel8.BackColor = Me.BackColor
        LinkLabel9.BackColor = Me.BackColor
        TranspatToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem1.Checked = True
        LightBlueToolStripMenuItem.Checked = False
        LightRedToolStripMenuItem.Checked = False
        LmeToolStripMenuItem.Checked = False
        SandToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem1.Checked = False
    End Sub

    Private Sub SizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeToolStripMenuItem.Click
        Me.ForeColor = Color.Black
        ListBox1.ForeColor = Me.ForeColor
        MenuStrip1.ForeColor = Me.ForeColor
        SizeToolStripMenuItem.Checked = True
        WhiteToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        BlueToolStripMenuItem.Checked = False
        GlodToolStripMenuItem.Checked = False
        GreenToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem.Checked = False
    End Sub

    Private Sub DefaultToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultToolStripMenuItem.Click
        Me.ForeColor = Color.Black
        ListBox1.ForeColor = Color.Black
        MenuStrip1.ForeColor = Color.Black
        SizeToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        BlueToolStripMenuItem.Checked = False
        GlodToolStripMenuItem.Checked = False
        GreenToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem.Checked = True
    End Sub

    Private Sub GreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreenToolStripMenuItem.Click
        Me.ForeColor = Color.Green
        ListBox1.ForeColor = Me.ForeColor
        MenuStrip1.ForeColor = Me.ForeColor
        SizeToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        BlueToolStripMenuItem.Checked = False
        GlodToolStripMenuItem.Checked = False
        GreenToolStripMenuItem.Checked = True
        DefaultToolStripMenuItem.Checked = False
    End Sub

    Private Sub GlodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlodToolStripMenuItem.Click
        Me.ForeColor = Color.Gold
        ListBox1.ForeColor = Me.ForeColor
        MenuStrip1.ForeColor = Me.ForeColor
        SizeToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        BlueToolStripMenuItem.Checked = False
        GlodToolStripMenuItem.Checked = True
        GreenToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem.Checked = False
    End Sub

    Private Sub BlueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlueToolStripMenuItem.Click
        Me.ForeColor = Color.Blue
        ListBox1.ForeColor = Me.ForeColor
        MenuStrip1.ForeColor = Me.ForeColor
        SizeToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        BlueToolStripMenuItem.Checked = True
        GlodToolStripMenuItem.Checked = False
        GreenToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem.Checked = False
    End Sub

    Private Sub RedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedToolStripMenuItem.Click
        Me.ForeColor = Color.Red
        ListBox1.ForeColor = Me.ForeColor
        MenuStrip1.ForeColor = Me.ForeColor
        SizeToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = True
        BlueToolStripMenuItem.Checked = False
        GlodToolStripMenuItem.Checked = False
        GreenToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem.Checked = False
    End Sub

    Private Sub WhiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhiteToolStripMenuItem.Click
        Me.ForeColor = Color.White
        ListBox1.ForeColor = Me.ForeColor
        MenuStrip1.ForeColor = Me.ForeColor
        SizeToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem.Checked = True
        RedToolStripMenuItem.Checked = False
        BlueToolStripMenuItem.Checked = False
        GlodToolStripMenuItem.Checked = False
        GreenToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem.Checked = False
    End Sub

    Private Sub TimeDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeDateToolStripMenuItem.Click
        Try
            Dim regStartUp As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            Dim value As String
            value = regStartUp.GetValue("Computer Info v3.0")
            If value <> Application.ExecutablePath.ToString() Then
                regStartUp.CreateSubKey("Computer Info v3.0")
                regStartUp.SetValue("Computer Info v3.0", Application.ExecutablePath.ToString())
            End If
            My.Computer.Audio.Play(My.Resources.StartupS, AudioPlayMode.Background)
            MsgBox("Computer Info v3.0 Added On Startup Successfully", MsgBoxStyle.Information, "StartUp")
        Catch p11 As Exception
            Try
                Dim regStartUp As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                Dim value As String
                value = regStartUp.GetValue("Computer Info v3.0")
                If value <> Application.ExecutablePath.ToString() Then
                    regStartUp.CreateSubKey("Computer Info v3.0")
                    regStartUp.SetValue("Computer Info v3.0", Application.ExecutablePath.ToString())
                End If
                My.Computer.Audio.Play(My.Resources.StartupS, AudioPlayMode.Background)
                MsgBox("Computer Info v3.0 Added On Startup Successfully", MsgBoxStyle.Information, "StartUp")
            Catch p011 As Exception
                My.Computer.Audio.Play(My.Resources.StartupF, AudioPlayMode.Background)
                MsgBox("Faild To Add Coputer Info v3.0 On Startup", MsgBoxStyle.Exclamation, "StartUp")
            End Try
        End Try
    End Sub

    Private Sub RemoveFromStartupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveFromStartupToolStripMenuItem.Click
        Try
            Dim regStartUp As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            Dim value As String
            value = regStartUp.GetValue("Computer Info v3.0")
            If value <> Application.ExecutablePath.ToString() Then
                regStartUp.OpenSubKey("Computer Info v3.0")
                regStartUp.DeleteValue("Computer Info v3.0")
            Else
                regStartUp.OpenSubKey("Computer Info v3.0")
                regStartUp.DeleteValue("Computer Info v3.0")
                regStartUp.Close()
            End If
            My.Computer.Audio.Play(My.Resources.RS, AudioPlayMode.Background)
            MsgBox("Computer Info v3.0 Removed From Startup Successfully", MsgBoxStyle.Information)
        Catch p012 As Exception
            Try
                Dim regStartUp As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                Dim value As String
                value = regStartUp.GetValue("Computer Info v3")
                If value <> Application.ExecutablePath.ToString() Then
                    regStartUp.OpenSubKey("Computer Info v3")
                    regStartUp.DeleteValue("Computer Info v3")
                Else
                    regStartUp.OpenSubKey("Computer Info v3")
                    regStartUp.DeleteValue("Computer Info v3")
                    regStartUp.Close()
                End If
                My.Computer.Audio.Play(My.Resources.RS, AudioPlayMode.Background)
                MsgBox("Computer Info v3.0 Removed From Startup Successfully", MsgBoxStyle.Information)
            Catch p12 As Exception
                My.Computer.Audio.Play(My.Resources.RF, AudioPlayMode.Background)
                MsgBox("Failed To Remove Computer Info v3.0 From Startup", MsgBoxStyle.Exclamation, "StartUp")
            End Try
        End Try
    End Sub

    Private Sub WhiteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhiteToolStripMenuItem2.Click
        MenuStrip1.BackColor = Color.White
        WhiteToolStripMenuItem2.Checked = True
        AquaToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        GreenToolStripMenuItem1.Checked = False
        PurpleToolStripMenuItem.Checked = False
        OrangeToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem2.Checked = False
    End Sub

    Private Sub AquaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AquaToolStripMenuItem.Click
        MenuStrip1.BackColor = Color.Blue
        WhiteToolStripMenuItem2.Checked = False
        AquaToolStripMenuItem.Checked = True
        RedToolStripMenuItem.Checked = False
        GreenToolStripMenuItem1.Checked = False
        PurpleToolStripMenuItem.Checked = False
        OrangeToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem2.Checked = False
    End Sub

    Private Sub RedToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedToolStripMenuItem1.Click
        MenuStrip1.BackColor = Color.Red
        WhiteToolStripMenuItem2.Checked = False
        AquaToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = True
        GreenToolStripMenuItem1.Checked = False
        PurpleToolStripMenuItem.Checked = False
        OrangeToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem2.Checked = False
    End Sub

    Private Sub GreenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreenToolStripMenuItem1.Click
        MenuStrip1.BackColor = Color.Green
        WhiteToolStripMenuItem2.Checked = False
        AquaToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        GreenToolStripMenuItem1.Checked = True
        PurpleToolStripMenuItem.Checked = False
        OrangeToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem2.Checked = False
    End Sub

    Private Sub PurpleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurpleToolStripMenuItem.Click
        MenuStrip1.BackColor = Color.Purple
        WhiteToolStripMenuItem2.Checked = False
        AquaToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        GreenToolStripMenuItem1.Checked = False
        PurpleToolStripMenuItem.Checked = True
        OrangeToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem2.Checked = False
    End Sub

    Private Sub OrangeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrangeToolStripMenuItem.Click
        MenuStrip1.BackColor = Color.Orange
        WhiteToolStripMenuItem2.Checked = False
        AquaToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        GreenToolStripMenuItem1.Checked = False
        PurpleToolStripMenuItem.Checked = False
        OrangeToolStripMenuItem.Checked = True
        DefaultToolStripMenuItem2.Checked = False
    End Sub

    Private Sub DefaultToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultToolStripMenuItem2.Click
        MenuStrip1.BackColor = Color.WhiteSmoke
        WhiteToolStripMenuItem2.Checked = False
        AquaToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        GreenToolStripMenuItem1.Checked = False
        PurpleToolStripMenuItem.Checked = False
        OrangeToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem2.Checked = True
    End Sub

    Private Sub Style1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Style1ToolStripMenuItem.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Icon = My.Resources.My_Computer
        Me.ShowIcon = False
        Me.ControlBox = True
        Style1ToolStripMenuItem.Checked = True
        Style2ToolStripMenuItem.Checked = False
        Style3ToolStripMenuItem.Checked = False
        Style4ToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem3.Checked = False
    End Sub

    Private Sub Style2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Style2ToolStripMenuItem.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.ShowIcon = True
        Me.ControlBox = False
        Style1ToolStripMenuItem.Checked = False
        Style2ToolStripMenuItem.Checked = True
        Style3ToolStripMenuItem.Checked = False
        Style4ToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem3.Checked = False
    End Sub

    Private Sub Style3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Style3ToolStripMenuItem.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.ShowIcon = True
        Me.ControlBox = True
        Style1ToolStripMenuItem.Checked = False
        Style2ToolStripMenuItem.Checked = False
        Style3ToolStripMenuItem.Checked = True
        Style4ToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem3.Checked = False
    End Sub

    Private Sub Style4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Style4ToolStripMenuItem.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.ShowIcon = False
        Me.ControlBox = False
        Style1ToolStripMenuItem.Checked = False
        Style2ToolStripMenuItem.Checked = False
        Style3ToolStripMenuItem.Checked = False
        Style4ToolStripMenuItem.Checked = True
        DefaultToolStripMenuItem3.Checked = False
    End Sub

    Private Sub DefaultToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultToolStripMenuItem3.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.ShowIcon = True
        Me.ControlBox = True
        Style1ToolStripMenuItem.Checked = False
        Style2ToolStripMenuItem.Checked = False
        Style3ToolStripMenuItem.Checked = False
        Style4ToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem3.Checked = True
    End Sub

    Private Sub RestoreAtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreAtToolStripMenuItem.Click
        Me.BackColor = Color.WhiteSmoke
        Me.ForeColor = Color.Black
        Me.ShowIcon = True
        Me.ControlBox = True
        TabPage1.BackColor = Me.BackColor
        TabPage2.BackColor = Me.BackColor
        TabPage3.BackColor = Me.BackColor
        TabPage4.BackColor = Me.BackColor
        TabPage5.BackColor = Me.BackColor
        TabPage6.BackColor = Me.BackColor
        TabPage7.BackColor = Me.BackColor
        LinkLabel8.BackColor = Me.BackColor
        LinkLabel9.BackColor = Me.BackColor
        MenuStrip1.BackColor = Color.WhiteSmoke
        MenuStrip1.ForeColor = Color.Black
        ListBox1.ForeColor = Color.Black
        ListBox1.BackColor = Color.White
        LinkLabel1.BackColor = Color.White
        Me.Opacity = 1
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Style1ToolStripMenuItem.Checked = False
        Style2ToolStripMenuItem.Checked = False
        Style3ToolStripMenuItem.Checked = False
        Style4ToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem3.Checked = True
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        DeafultToolStripMenuItem.Checked = True
        SizeToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        BlueToolStripMenuItem.Checked = False
        GlodToolStripMenuItem.Checked = False
        GreenToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem.Checked = True
        WhiteToolStripMenuItem2.Checked = False
        AquaToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        GreenToolStripMenuItem1.Checked = False
        PurpleToolStripMenuItem.Checked = False
        OrangeToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem2.Checked = True
        TranspatToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem1.Checked = False
        LightBlueToolStripMenuItem.Checked = False
        LightRedToolStripMenuItem.Checked = False
        LmeToolStripMenuItem.Checked = False
        SandToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem1.Checked = True
        My.Computer.Audio.Play(My.Resources.R, AudioPlayMode.Background)
        Me.Hide()
        Me.Show()
        MsgBox("All Default Have Been Restored")
    End Sub

    Private Sub GroupBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox1.MouseUp
        Dim c As Control = CType(sender, Control)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStrip1.Show(c, e.Location, ToolStripDropDownDirection.Default)
        End If
    End Sub

    Private Sub GroupBox2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox2.MouseUp
        Dim c As Control = CType(sender, Control)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStrip1.Show(c, e.Location, ToolStripDropDownDirection.Default)
        End If
    End Sub

    Private Sub GroupBox3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox3.MouseUp
        Dim c As Control = CType(sender, Control)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStrip1.Show(c, e.Location, ToolStripDropDownDirection.Default)
        End If
    End Sub

    Private Sub GroupBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox4.MouseUp
        Dim c As Control = CType(sender, Control)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStrip1.Show(c, e.Location, ToolStripDropDownDirection.Default)
        End If
    End Sub

    Private Sub GroupBox5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox5.MouseUp
        Dim c As Control = CType(sender, Control)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStrip1.Show(c, e.Location, ToolStripDropDownDirection.Default)
        End If
    End Sub

    Private Sub GroupBox6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox6.MouseUp
        Dim c As Control = CType(sender, Control)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStrip1.Show(c, e.Location, ToolStripDropDownDirection.Default)
        End If
    End Sub

    Private Sub GroupBox7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox7.MouseUp
        Dim c As Control = CType(sender, Control)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStrip1.Show(c, e.Location, ToolStripDropDownDirection.Default)
        End If
    End Sub

    Private Sub GetSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If TabControl1.SelectedIndex = 0 Then
            Me.Size = New Size(GroupBox1.Size.Width + 40, GroupBox1.Size.Height + 102)
            TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
            Me.Icon = My.Resources.My_Computer
        End If
        If TabControl1.SelectedIndex = 1 Then
            Me.Size = New Size(GroupBox6.Size.Width + 40, GroupBox6.Size.Height + 102)
            TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
            Me.Icon = My.Resources.Windows
        End If
        If TabControl1.SelectedIndex = 2 Then
            Me.Size = New Size(GroupBox4.Size.Width + 40, GroupBox4.Size.Height + 102)
            TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
            Me.Icon = My.Resources.Web
        End If
        If TabControl1.SelectedIndex = 3 Then
            Me.Size = New Size(GroupBox5.Size.Width + 40, GroupBox5.Size.Height + 102)
            TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
            Me.Icon = My.Resources.Screen
        End If
        If TabControl1.SelectedIndex = 4 Then
            Me.Size = New Size(GroupBox7.Size.Width + 40, GroupBox7.Size.Height + 102)
            TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
            Me.Icon = My.Resources.Stats
        End If
        If TabControl1.SelectedIndex = 5 Then
            Me.Size = New Size(GroupBox3.Size.Width + 40, GroupBox3.Size.Height + 102)
            TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
            Me.Icon = My.Resources.HD
        End If
        If TabControl1.SelectedIndex = 6 Then
            Me.Size = New Size(GroupBox2.Size.Width + 40, GroupBox2.Size.Height + 102)
            TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
            Me.Icon = My.Resources.Temporary
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ListBox1.Items.Clear()
        If cdrive.IsReady = True Then ListBox1.Items.Add(cdrive.VolumeLabel & "(C:)")
        If ddrive.IsReady = True Then ListBox1.Items.Add(ddrive.VolumeLabel & "(D:)")
        If edrive.IsReady = True Then ListBox1.Items.Add(edrive.VolumeLabel & "(E:)")
        If fdrive.IsReady = True Then ListBox1.Items.Add(fdrive.VolumeLabel & "(F:)")
        If gdrive.IsReady = True Then ListBox1.Items.Add(gdrive.VolumeLabel & "(G:)")
        If hdrive.IsReady = True Then ListBox1.Items.Add(hdrive.VolumeLabel & "(H:)")
        If idrive.IsReady = True Then ListBox1.Items.Add(idrive.VolumeLabel & "(I:)")
        If jdrive.IsReady = True Then ListBox1.Items.Add(jdrive.VolumeLabel & "(J:)")
        If kdrive.IsReady = True Then ListBox1.Items.Add(kdrive.VolumeLabel & "(K:)")
        If ldrive.IsReady = True Then ListBox1.Items.Add(ldrive.VolumeLabel & "(L:)")
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            If ListBox1.SelectedItem = cdrive.VolumeLabel & "(C:)" Then
                Label9.Text = "Total Space : " & (cdrive.TotalSize / 1073741824) & " GB" & " ≈ " & (cdrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & cdrive.TotalSize / 1073741824 - cdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (cdrive.TotalSize / 1073741824 - cdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & cdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (cdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((cdrive.TotalSize - cdrive.TotalFreeSpace) / 1073741824) / (cdrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((cdrive.TotalSize - cdrive.TotalFreeSpace) / 1073741824) / (cdrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & cdrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("C")
                Label28.Text = "Volume Name : " & cdrive.VolumeLabel
            End If
        Catch p As Exception
        End Try
        Try
            If ListBox1.SelectedItem = ddrive.VolumeLabel & "(D:)" Then
                Label9.Text = "Total Space : " & (ddrive.TotalSize / 1073741824) & " GB" & " ≈ " & (ddrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & ddrive.TotalSize / 1073741824 - ddrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (ddrive.TotalSize / 1073741824 - ddrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & ddrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (ddrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((ddrive.TotalSize - ddrive.TotalFreeSpace) / 1073741824) / (ddrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((ddrive.TotalSize - ddrive.TotalFreeSpace) / 1073741824) / (ddrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & ddrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("D")
                Label28.Text = "Volume Name : " & ddrive.VolumeLabel
            End If
        Catch p2 As Exception
        End Try
        Try
            If ListBox1.SelectedItem = edrive.VolumeLabel & "(E:)" Then
                Label9.Text = "Total Space : " & (edrive.TotalSize / 1073741824) & " GB" & " ≈ " & (edrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & edrive.TotalSize / 1073741824 - edrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (edrive.TotalSize / 1073741824 - edrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & edrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (edrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((edrive.TotalSize - edrive.TotalFreeSpace) / 1073741824) / (edrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((edrive.TotalSize - edrive.TotalFreeSpace) / 1073741824) / (edrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & edrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("E")
                Label28.Text = "Volume Name : " & edrive.VolumeLabel
            End If
        Catch p3 As Exception
        End Try
        Try
            If ListBox1.SelectedItem = fdrive.VolumeLabel & "(F:)" Then
                Label9.Text = "Total Space : " & (fdrive.TotalSize / 1073741824) & " GB" & " ≈ " & (fdrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & fdrive.TotalSize / 1073741824 - fdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (fdrive.TotalSize / 1073741824 - fdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & fdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (fdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((fdrive.TotalSize - fdrive.TotalFreeSpace) / 1073741824) / (fdrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((fdrive.TotalSize - fdrive.TotalFreeSpace) / 1073741824) / (fdrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & fdrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("F")
                Label28.Text = "Volume Name : " & fdrive.VolumeLabel
            End If
        Catch p4 As Exception
        End Try
        Try
            If ListBox1.SelectedItem = gdrive.VolumeLabel & "(G:)" Then
                Label9.Text = "Total Space : " & (gdrive.TotalSize / 1073741824) & " GB" & " ≈ " & (gdrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & gdrive.TotalSize / 1073741824 - gdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (gdrive.TotalSize / 1073741824 - gdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & gdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (gdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((gdrive.TotalSize - gdrive.TotalFreeSpace) / 1073741824) / (gdrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((gdrive.TotalSize - gdrive.TotalFreeSpace) / 1073741824) / (gdrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & gdrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("G")
                Label28.Text = "Volume Name : " & gdrive.VolumeLabel
            End If
        Catch p5 As Exception
        End Try
        Try
            If ListBox1.SelectedItem = hdrive.VolumeLabel & "(H:)" Then
                Label9.Text = "Total Space : " & (hdrive.TotalSize / 1073741824) & " GB" & " ≈ " & (hdrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & hdrive.TotalSize / 1073741824 - hdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (hdrive.TotalSize / 1073741824 - hdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & hdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (hdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((hdrive.TotalSize - hdrive.TotalFreeSpace) / 1073741824) / (hdrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((hdrive.TotalSize - hdrive.TotalFreeSpace) / 1073741824) / (hdrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & hdrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("H")
                Label28.Text = "Volume Name : " & hdrive.VolumeLabel
            End If
        Catch p6 As Exception
        End Try
        Try
            If ListBox1.SelectedItem = idrive.VolumeLabel & "(I:)" Then
                Label9.Text = "Total Space : " & (idrive.TotalSize / 1073741824) & " GB" & " ≈ " & (idrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & idrive.TotalSize / 1073741824 - idrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (idrive.TotalSize / 1073741824 - idrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & idrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (idrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((idrive.TotalSize - idrive.TotalFreeSpace) / 1073741824) / (idrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((idrive.TotalSize - idrive.TotalFreeSpace) / 1073741824) / (idrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & idrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("I")
                Label28.Text = "Volume Name : " & idrive.VolumeLabel
            End If
        Catch p7 As Exception
        End Try
        Try
            If ListBox1.SelectedItem = jdrive.VolumeLabel & "(J:)" Then
                Label9.Text = "Total Space : " & (jdrive.TotalSize / 1073741824) & " GB" & " ≈ " & (jdrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & jdrive.TotalSize / 1073741824 - jdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (jdrive.TotalSize / 1073741824 - jdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & jdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (jdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((jdrive.TotalSize - jdrive.TotalFreeSpace) / 1073741824) / (jdrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((jdrive.TotalSize - jdrive.TotalFreeSpace) / 1073741824) / (jdrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & jdrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("J")
                Label28.Text = "Volume Name : " & jdrive.VolumeLabel
            End If
        Catch p8 As Exception
        End Try
        Try
            If ListBox1.SelectedItem = kdrive.VolumeLabel & "(K:)" Then
                Label9.Text = "Total Space : " & (kdrive.TotalSize / 1073741824) & " GB" & " ≈ " & (kdrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & kdrive.TotalSize / 1073741824 - kdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (kdrive.TotalSize / 1073741824 - kdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & kdrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (kdrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((kdrive.TotalSize - kdrive.TotalFreeSpace) / 1073741824) / (kdrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((kdrive.TotalSize - kdrive.TotalFreeSpace) / 1073741824) / (kdrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & kdrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("K")
                Label28.Text = "Volume Name : " & kdrive.VolumeLabel
            End If
        Catch p9 As Exception
        End Try
        Try
            If ListBox1.SelectedItem = ldrive.VolumeLabel & "(L:)" Then
                Label9.Text = "Total Space : " & (ldrive.TotalSize / 1073741824) & " GB" & " ≈ " & (ldrive.TotalSize / 1073741824) \ 1 & " GB"
                Label10.Text = "Used Space : " & ldrive.TotalSize / 1073741824 - ldrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (ldrive.TotalSize / 1073741824 - ldrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label11.Text = "Free Space : " & ldrive.TotalFreeSpace / 1073741824 & " GB" & " ≈ " & (ldrive.TotalFreeSpace / 1073741824) \ 1 & " GB"
                Label12.Text = (((ldrive.TotalSize - ldrive.TotalFreeSpace) / 1073741824) / (ldrive.TotalSize / 1073741824) * 100) \ 1 & "%"
                ProgressBar1.Value = (((ldrive.TotalSize - ldrive.TotalFreeSpace) / 1073741824) / (ldrive.TotalSize / 1073741824) * 100) \ 1
                Label18.Text = "Format Type : " & ldrive.DriveFormat
                Label27.Text = "Serial Number : " & SerialNum("L")
                Label28.Text = "Volume Name : " & ldrive.VolumeLabel
            End If
            Label19.Text = "Device Count : " & ListBox1.Items.Count
        Catch p0 As Exception
        End Try
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ListBox3.SelectedItem = Nothing
            ListBox4.SelectedItem = Nothing
            If ListBox2.SelectedItem.ToString <> "" Then
                For Each proc As Process In Process.GetProcesses
                    If proc.ProcessName = ListBox2.SelectedItem.ToString Then
                        proc.Kill()
                        My.Computer.Audio.Play(My.Resources.ky, AudioPlayMode.Background)
                        MsgBox("Process killed Successfully")
                        Exit For
                    End If
                Next
            Else
                My.Computer.Audio.Play(My.Resources.K, AudioPlayMode.Background)
                MsgBox("Select Process First")
            End If
        Catch kk As Exception
            My.Computer.Audio.Play(My.Resources.kk, AudioPlayMode.Background)
            MsgBox("Unalbe to kill this process", MsgBoxStyle.Exclamation, "Process")
        End Try
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Dim tr As Single = My.Computer.Info.TotalPhysicalMemory / 1073741824
        Dim ar As Single = My.Computer.Info.AvailablePhysicalMemory / 1073741824
        Label5.Text = "Total of RAM : " & tr & " GB" & " ≈ " & tr \ 1 & " GB"
        Label6.Text = "Used of RAM : " & tr - ar & " GB" & " ≈ " & (tr - ar) \ 1 & " GB"
        Label7.Text = "Available of RAM : " & ar & " GB" & " ≈ " & ar \ 1 & " GB"
        Label32.Text = ((tr - ar) / tr) * 100 \ 1 & " %"
        ProgressBar2.Value = ((tr - ar) / tr) * 100 \ 1
    End Sub

    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        ListBox2.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox2.Items.Add(p.ProcessName)
        Next
        ListBox3.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox3.Items.Add(p.MainWindowTitle)
        Next
        ListBox4.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox4.Items.Add(p.Id & ";" & p.Responding)
        Next
    End Sub

    Private Sub RefreshToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem1.Click
        Label1.Text = "Computer Name : " & My.Computer.Name
        Label2.Text = "OS Name : " & My.Computer.Info.OSFullName
        Label3.Text = "OS Version : " & My.Computer.Info.OSVersion
        Label4.Text = "OS Platform : " & My.Computer.Info.OSPlatform
        If Label2.Text.Contains("Windows") = True Or Label4.Text = "Win32NT" Then
            PictureBox8.Image = My.Resources.Windows1
            Label34.Text = "Windows"
        ElseIf Label2.Text.Contains("Apple") = True Then
            PictureBox8.Image = My.Resources.Apple_Rainbow
            Label34.Text = "Windows"
        ElseIf Label2.Text.Contains("Debian") = True Then
            PictureBox8.Image = My.Resources.Debian
            Label34.Text = "Debian"
        ElseIf Label2.Text.Contains("Etoile") = True Then
            PictureBox8.Image = My.Resources.Etoile
            Label34.Text = "Etoile"
        ElseIf Label2.Text.Contains("Fedora") = True Then
            PictureBox8.Image = My.Resources.Fedora
            Label34.Text = "Fedora"
        ElseIf Label2.Text.Contains("Finder") = True Then
            PictureBox8.Image = My.Resources.Finder
            Label34.Text = "Finder"
        ElseIf Label2.Text.Contains("Freespire") = True Then
            PictureBox8.Image = My.Resources.Freespire
            Label34.Text = "Freespire"
        ElseIf Label2.Text.Contains("Globe") = True Then
            PictureBox8.Image = My.Resources.Globe
            Label34.Text = "Globe"
        ElseIf Label2.Text.Contains("Gnome") = True Then
            PictureBox8.Image = My.Resources.Gnome
            Label34.Text = "Gnome"
        ElseIf Label2.Text.Contains("KDE") = True Then
            PictureBox8.Image = My.Resources.KDE
            Label34.Text = "KDE"
        ElseIf Label2.Text.Contains("Konqueror") = True Then
            PictureBox8.Image = My.Resources.Konqueror
            Label34.Text = "Konqueror"
        ElseIf Label2.Text.Contains("Linux") = True Then
            PictureBox8.Image = My.Resources.Linux
            Label34.Text = "Linux"
        ElseIf Label2.Text.Contains("Mandriva") = True Then
            PictureBox8.Image = My.Resources.Mandriva
            Label34.Text = "Mandriva"
        ElseIf Label2.Text.Contains("Ubuntu") = True Then
            PictureBox8.Image = My.Resources.Ubuntu
            Label34.Text = "Ubuntu"
        Else
            Label34.Text = "Other or Not Detcted"
            PictureBox1.Hide()
        End If
        Label5.Text = "Total of RAM : " & t & " GB" & " ≈ " & t \ 1 & " GB"
        Label6.Text = "Used of RAM : " & t - a & " GB" & " ≈ " & (t - a) \ 1 & " GB"
        Label7.Text = "Available of RAM : " & a & " GB" & " ≈ " & a \ 1 & " GB"
        Label8.Text = "Network Working : " & My.Computer.Network.IsAvailable
        If My.Computer.Network.IsAvailable = True Then
            PictureBox10.Show()
            PictureBox9.Hide()
        ElseIf My.Computer.Network.IsAvailable = False Then
            PictureBox9.Show()
            PictureBox10.Hide()
        End If
        ListBox1.Items.Clear()
        If cdrive.IsReady = True Then ListBox1.Items.Add(cdrive.VolumeLabel & "(C:)")
        If ddrive.IsReady = True Then ListBox1.Items.Add(ddrive.VolumeLabel & "(D:)")
        If edrive.IsReady = True Then ListBox1.Items.Add(edrive.VolumeLabel & "(E:)")
        If fdrive.IsReady = True Then ListBox1.Items.Add(fdrive.VolumeLabel & "(F:)")
        If gdrive.IsReady = True Then ListBox1.Items.Add(gdrive.VolumeLabel & "(G:)")
        If hdrive.IsReady = True Then ListBox1.Items.Add(hdrive.VolumeLabel & "(H:)")
        If idrive.IsReady = True Then ListBox1.Items.Add(idrive.VolumeLabel & "(I:)")
        If jdrive.IsReady = True Then ListBox1.Items.Add(jdrive.VolumeLabel & "(J:)")
        If kdrive.IsReady = True Then ListBox1.Items.Add(kdrive.VolumeLabel & "(K:)")
        If ldrive.IsReady = True Then ListBox1.Items.Add(ldrive.VolumeLabel & "(L:)")
        Label19.Text = "Device Count : " & ListBox1.Items.Count
        Label13.Text = "Computer IP : " & System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString
        Label20.Text = "Host Name : " & System.Net.Dns.GetHostName
        Label14.Text = "Device Name : " & My.Computer.Screen.DeviceName
        Label15.Text = "Size : " & My.Computer.Screen.Bounds.Size.ToString
        Label16.Text = "Colors in pixel : " & My.Computer.Screen.BitsPerPixel & " Color/Pixel"
        Label17.Text = "Is Primary : " & My.Computer.Screen.Primary
        NewInfo()
        Label21.Text = "Manufacturer : " & m_Manufacturer
        Label22.Text = "Model : " & m_Model
        Label24.Text = "System Languge : " & System.Globalization.CultureInfo.CurrentCulture.DisplayName
        Label23.Text = "System Type : " & m_SystemType
        Label25.Text = "Windows Directory : " & m_WindowsDir
        TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
        ListBox2.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox2.Items.Add(p.ProcessName)
        Next
        ListBox3.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox3.Items.Add(p.MainWindowTitle)
        Next
        ListBox4.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox4.Items.Add(p.Id & ";" & p.Responding)
        Next
        Me.Hide()
        Me.Show()
        Me.Refresh()
        My.Computer.Audio.Play(My.Resources.Refreshed, AudioPlayMode.Background)
        MsgBox("Program has been refreshed", MsgBoxStyle.Information, "Refersh")
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditsToolStripMenuItem.Click
        My.Computer.Audio.Play(My.Resources.Rights, AudioPlayMode.Background)
        MsgBox("ALL Rights © Are Reserved To *-'Mohamed Selim'-*", MsgBoxStyle.SystemModal, "Credits")
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        My.Computer.Audio.Play(My.Resources.V, AudioPlayMode.Background)
        MsgBox("Computer Information v3.0 (The Lastest Version)", MsgBoxStyle.Information, "VerSion")
    End Sub

    Private Sub HToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        mciSendString("set cdaudio door open", 0, 0, 0)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        mciSendString("set cdaudio door closed", 0, 0, 0)
    End Sub

    Private Sub MovableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovableToolStripMenuItem.Click
        If MovableToolStripMenuItem.Checked = True Then
            Tool.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Tool.ControlBox = False
        Else
            Tool.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        End If
    End Sub

    Private Sub TopMostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopMostToolStripMenuItem.Click
        If TopMostToolStripMenuItem.Checked = True Then
            Tool.TopMost = True
        Else
            Tool.TopMost = False
        End If
    End Sub

    Private Sub ShowHideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHideToolStripMenuItem.Click
        If ShowHideToolStripMenuItem.Checked = True Then
            Tool.Visible = True
        Else
            Tool.Visible = False
        End If
    End Sub

    Private Sub OpenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem1.Click
        Tool.Show()
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Tool.Close()
    End Sub

    Private Sub ShowHideIconToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHideIconToolStripMenuItem.Click
        If ShowHideIconToolStripMenuItem.Checked = True Then
            Tool.ShowInTaskbar = True
        Else
            Tool.ShowInTaskbar = False
        End If
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Label1.Text = "Computer Name : " & My.Computer.Name
        Label2.Text = "OS Name : " & My.Computer.Info.OSFullName
        Label3.Text = "OS Version : " & My.Computer.Info.OSVersion
        Label4.Text = "OS Platform : " & My.Computer.Info.OSPlatform
        If Label2.Text.Contains("Windows") = True Or Label4.Text = "Win32NT" Then
            PictureBox8.Image = My.Resources.Windows1
            Label34.Text = "Windows"
        ElseIf Label2.Text.Contains("Apple") = True Then
            PictureBox8.Image = My.Resources.Apple_Rainbow
            Label34.Text = "Windows"
        ElseIf Label2.Text.Contains("Debian") = True Then
            PictureBox8.Image = My.Resources.Debian
            Label34.Text = "Debian"
        ElseIf Label2.Text.Contains("Etoile") = True Then
            PictureBox8.Image = My.Resources.Etoile
            Label34.Text = "Etoile"
        ElseIf Label2.Text.Contains("Fedora") = True Then
            PictureBox8.Image = My.Resources.Fedora
            Label34.Text = "Fedora"
        ElseIf Label2.Text.Contains("Finder") = True Then
            PictureBox8.Image = My.Resources.Finder
            Label34.Text = "Finder"
        ElseIf Label2.Text.Contains("Freespire") = True Then
            PictureBox8.Image = My.Resources.Freespire
            Label34.Text = "Freespire"
        ElseIf Label2.Text.Contains("Globe") = True Then
            PictureBox8.Image = My.Resources.Globe
            Label34.Text = "Globe"
        ElseIf Label2.Text.Contains("Gnome") = True Then
            PictureBox8.Image = My.Resources.Gnome
            Label34.Text = "Gnome"
        ElseIf Label2.Text.Contains("KDE") = True Then
            PictureBox8.Image = My.Resources.KDE
            Label34.Text = "KDE"
        ElseIf Label2.Text.Contains("Konqueror") = True Then
            PictureBox8.Image = My.Resources.Konqueror
            Label34.Text = "Konqueror"
        ElseIf Label2.Text.Contains("Linux") = True Then
            PictureBox8.Image = My.Resources.Linux
            Label34.Text = "Linux"
        ElseIf Label2.Text.Contains("Mandriva") = True Then
            PictureBox8.Image = My.Resources.Mandriva
            Label34.Text = "Mandriva"
        ElseIf Label2.Text.Contains("Ubuntu") = True Then
            PictureBox8.Image = My.Resources.Ubuntu
            Label34.Text = "Ubuntu"
        Else
            Label34.Text = "Other or Not Detcted"
            PictureBox1.Hide()
        End If
        Label5.Text = "Total of RAM : " & t & " GB" & " ≈ " & t \ 1 & " GB"
        Label6.Text = "Used of RAM : " & t - a & " GB" & " ≈ " & (t - a) \ 1 & " GB"
        Label7.Text = "Available of RAM : " & a & " GB" & " ≈ " & a \ 1 & " GB"
        Label8.Text = "Network Working : " & My.Computer.Network.IsAvailable
        If My.Computer.Network.IsAvailable = True Then
            PictureBox10.Show()
            PictureBox9.Hide()
        ElseIf My.Computer.Network.IsAvailable = False Then
            PictureBox9.Show()
            PictureBox10.Hide()
        End If
        ListBox1.Items.Clear()
        If cdrive.IsReady = True Then ListBox1.Items.Add(cdrive.VolumeLabel & "(C:)")
        If ddrive.IsReady = True Then ListBox1.Items.Add(ddrive.VolumeLabel & "(D:)")
        If edrive.IsReady = True Then ListBox1.Items.Add(edrive.VolumeLabel & "(E:)")
        If fdrive.IsReady = True Then ListBox1.Items.Add(fdrive.VolumeLabel & "(F:)")
        If gdrive.IsReady = True Then ListBox1.Items.Add(gdrive.VolumeLabel & "(G:)")
        If hdrive.IsReady = True Then ListBox1.Items.Add(hdrive.VolumeLabel & "(H:)")
        If idrive.IsReady = True Then ListBox1.Items.Add(idrive.VolumeLabel & "(I:)")
        If jdrive.IsReady = True Then ListBox1.Items.Add(jdrive.VolumeLabel & "(J:)")
        If kdrive.IsReady = True Then ListBox1.Items.Add(kdrive.VolumeLabel & "(K:)")
        If ldrive.IsReady = True Then ListBox1.Items.Add(ldrive.VolumeLabel & "(L:)")
        Label19.Text = "Device Count : " & ListBox1.Items.Count
        Label13.Text = "Computer IP : " & System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString
        Label20.Text = "Host Name : " & System.Net.Dns.GetHostName
        Label14.Text = "Device Name : " & My.Computer.Screen.DeviceName
        Label15.Text = "Size : " & My.Computer.Screen.Bounds.Size.ToString
        Label16.Text = "Colors in pixel : " & My.Computer.Screen.BitsPerPixel & " Color/Pixel"
        Label17.Text = "Is Primary : " & My.Computer.Screen.Primary
        NewInfo()
        Label21.Text = "Manufacturer : " & m_Manufacturer
        Label22.Text = "Model : " & m_Model
        Label24.Text = "System Languge : " & System.Globalization.CultureInfo.CurrentCulture.DisplayName
        Label23.Text = "System Type : " & m_SystemType
        Label25.Text = "Windows Directory : " & m_WindowsDir
        TabControl1.Size = New Size(Me.Size.Width - 14, Me.Size.Height - 61)
        ListBox2.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox2.Items.Add(p.ProcessName)
        Next
        ListBox3.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox3.Items.Add(p.MainWindowTitle)
        Next
        ListBox4.Items.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox4.Items.Add(p.Id & ";" & p.Responding)
        Next
        Me.Hide()
        Me.Show()
        Me.Refresh()
        My.Computer.Audio.Play(My.Resources.Refreshed, AudioPlayMode.Background)
        MsgBox("Program has been refreshed", MsgBoxStyle.Information, "Refersh")
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        TabControl1.SelectedIndex = 2
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        TabControl1.SelectedIndex = 3
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        TabControl1.SelectedIndex = 4
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        TabControl1.SelectedIndex = 5
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        TabControl1.SelectedIndex = 6
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox2.BorderStyle = BorderStyle.None
        PictureBox3.BorderStyle = BorderStyle.None
        PictureBox4.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
        PictureBox7.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        PictureBox2.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox3.BorderStyle = BorderStyle.None
        PictureBox4.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
        PictureBox7.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        PictureBox3.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox2.BorderStyle = BorderStyle.None
        PictureBox4.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
        PictureBox7.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        PictureBox4.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        PictureBox4.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox2.BorderStyle = BorderStyle.None
        PictureBox3.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
        PictureBox7.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseDown
        PictureBox5.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter
        PictureBox5.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox2.BorderStyle = BorderStyle.None
        PictureBox3.BorderStyle = BorderStyle.None
        PictureBox4.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
        PictureBox7.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        PictureBox6.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseEnter
        PictureBox6.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox2.BorderStyle = BorderStyle.None
        PictureBox3.BorderStyle = BorderStyle.None
        PictureBox4.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox7.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox7_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox7.MouseDown
        PictureBox7.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox7_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseEnter
        PictureBox7.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox2.BorderStyle = BorderStyle.None
        PictureBox3.BorderStyle = BorderStyle.None
        PictureBox4.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseLeave
        PictureBox7.BorderStyle = BorderStyle.None
    End Sub

    Private Sub OpactiyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpactiyToolStripMenuItem.Click
        If OpactiyToolStripMenuItem.Checked = True Then Tool.Opacity = 0.8 Else Tool.Opacity = 1
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        Shell("Shutdown -s -t 0")
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        Shell("Shutdown -r -t 0")
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffToolStripMenuItem.Click
        Shell("Shutdown -l -t 0")
        MsgBox("Maybe It doesn't work on win 7", MsgBoxStyle.Exclamation, "Log off")
    End Sub

    Private Sub ToolStripTextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.Click
        ToolStripTextBox1.Text = ""
    End Sub

    Private Sub LockOnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockOnToolStripMenuItem.Click
        If ToolStripTextBox1.Text = "Set password" Or ToolStripTextBox1.Text = "" Or ToolStripTextBox1.Text = " " Then
            My.Computer.Audio.Play(My.Resources.sp, AudioPlayMode.Background)
            MsgBox("Set password First", MsgBoxStyle.Exclamation, "Locker v3.0")
        Else
            My.Computer.Audio.Play(My.Resources.ln, AudioPlayMode.Background)
            Loker.Show()
            Tool.Hide()
            Me.Hide()
        End If
    End Sub

    Private Sub SaveInfoAsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveInfoAsToolStripMenuItem1.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveInfoAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveInfoAsToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Try
            Dim info As String
            info = "Computer :" & vbCrLf & _
            "==========" & vbCrLf & _
            Label1.Text & vbCrLf & _
            Label24.Text & vbCrLf & _
            Label21.Text & vbCrLf & _
            Label22.Text & vbCrLf & _
            "___________________________________________________________" & vbCrLf & _
            "System(OS) :" & vbCrLf & _
            "============" & vbCrLf & _
            Label2.Text & vbCrLf & _
            Label3.Text & vbCrLf & _
            Label4.Text & vbCrLf & _
            Label23.Text & vbCrLf & _
            Label25.Text & vbCrLf & _
            "___________________________________________________________" & vbCrLf & _
            "NetWork :" & vbCrLf & _
            "============" & vbCrLf & _
            Label13.Text & vbCrLf & _
            Label20.Text & vbCrLf & _
            Label8.Text & vbCrLf & _
            "___________________________________________________________" & vbCrLf & _
            "Screen :" & vbCrLf & _
            "============" & vbCrLf & _
            Label14.Text & vbCrLf & _
            Label15.Text & vbCrLf & _
            Label16.Text & vbCrLf & _
            Label17.Text & vbCrLf & _
            "___________________________________________________________" & vbCrLf & _
            "RAM :" & vbCrLf & _
            "============" & vbCrLf & _
            Label5.Text & vbCrLf & _
            Label6.Text & vbCrLf & _
            Label7.Text & vbCrLf & _
            Label32.Text & vbCrLf & _
            "___________________________________________________________" & vbCrLf & _
            "Disk Space :" & vbCrLf & _
            "============" & vbCrLf & _
            ListBox1.Text & vbCrLf & _
            Label28.Text & vbCrLf & _
            Label9.Text & vbCrLf & _
            Label10.Text & vbCrLf & _
            Label11.Text & vbCrLf & _
            Label12.Text & vbCrLf & _
            Label18.Text & vbCrLf & _
            Label27.Text & vbCrLf & _
            Label19.Text & vbCrLf & "Time at : " & TimeOfDay & "Date : " & Today & "    , Made By Mohamed Selim"
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, info, True)
            My.Computer.Audio.Play(My.Resources.info, AudioPlayMode.Background)
            MsgBox("Your Computer Information have been saved", MsgBoxStyle.Information, "Saved")
        Catch spi As Exception
            My.Computer.Audio.Play(My.Resources.fs, AudioPlayMode.Background)
            MsgBox("Failed to save, please Try again", MsgBoxStyle.Exclamation, "Save Failed")
        End Try
    End Sub

    Private Sub OtherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        Me.BackColor = ColorDialog1.Color
        ListBox1.BackColor = Me.BackColor
        TabPage1.BackColor = Me.BackColor
        TabPage2.BackColor = Me.BackColor
        TabPage3.BackColor = Me.BackColor
        TabPage4.BackColor = Me.BackColor
        TabPage5.BackColor = Me.BackColor
        TabPage6.BackColor = Me.BackColor
        TabPage7.BackColor = Me.BackColor
        LinkLabel1.BackColor = ListBox1.BackColor
        LinkLabel8.BackColor = Me.BackColor
        LinkLabel9.BackColor = Me.BackColor
        TranspatToolStripMenuItem.Checked = False
        WhiteToolStripMenuItem1.Checked = False
        LightBlueToolStripMenuItem.Checked = False
        LightRedToolStripMenuItem.Checked = False
        LmeToolStripMenuItem.Checked = False
        SandToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem1.Checked = False
    End Sub

    Private Sub OtherToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherToolStripMenuItem1.Click
        ColorDialog1.ShowDialog()
        MenuStrip1.BackColor = ColorDialog1.Color
        WhiteToolStripMenuItem2.Checked = False
        AquaToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        GreenToolStripMenuItem1.Checked = False
        PurpleToolStripMenuItem.Checked = False
        OrangeToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem2.Checked = False
    End Sub

    Private Sub OtherToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherToolStripMenuItem2.Click
        ColorDialog1.ShowDialog()
        Me.ForeColor = ColorDialog1.Color
        ListBox1.ForeColor = Me.ForeColor
        MenuStrip1.ForeColor = Me.ForeColor
        SizeToolStripMenuItem.Checked = True
        WhiteToolStripMenuItem.Checked = False
        RedToolStripMenuItem.Checked = False
        BlueToolStripMenuItem.Checked = False
        GlodToolStripMenuItem.Checked = False
        GreenToolStripMenuItem.Checked = False
        DefaultToolStripMenuItem.Checked = False
    End Sub
End Class
