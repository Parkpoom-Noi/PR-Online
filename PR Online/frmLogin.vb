Imports System
Imports PR_Online.BLL

Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Public Class frmLogin
#Region "Public Variables"
    Dim Bll As BLL_Load = New BLL_Load
    Dim dataUserID As Integer
    Dim _tStatus As Threading.Thread
    Dim StatusRun As Boolean
    Dim strHostName As String

    Dim strIPAddress As String

#End Region
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Exit application?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub tb_password_KeyDown(sender As Object, e As KeyEventArgs) Handles tbPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login()
    End Sub
    Private Sub Login()
        Dim dtUserData As DataTable
        Dim colStatus As Integer
        Dim colID As Integer
        Dim colName As String
        Dim colOnline As Integer

        Dim EncryptPass As String = Bll.PassEncoding(tbPassword.Text)


        dtUserData = Bll.GetCheckLogin(tbUsername.Text, EncryptPass)
        If dtUserData.Rows.Count > 0 Then
            For i As Integer = 0 To dtUserData.Rows.Count - 1
                colID = dtUserData.Rows(0)("user_id")
                colStatus = IIf(IsDBNull(dtUserData.Rows(0)("user_permission_pr")), 0, dtUserData.Rows(0)("user_permission_pr").ToString)
                colName = dtUserData.Rows(0)("user_fullname").ToString
                colOnline = dtUserData.Rows(0)("user_stOnline").ToString
                dataUserID = dtUserData.Rows(0)("user_id")
            Next
            If colStatus <> 0 Then
                'If colOnline = 0 Then
                Bll.lockLogin(colID)
                    frmMain._strUser = colID.ToString
                    frmMain.frmMain_Load()
                frmMain.Show()
                If cbRemember.Checked = True Then
                    Dim INS As Boolean = Bll.UpdateRemember(1, colID, strHostName)
                End If
                Me.Hide()
                'lockLogin(dataUserID)
                'Else
                '    MessageBox.Show("Now this user is logged in.")
                'End If

            Else
                MessageBox.Show("You don't have permission to access.")
            End If
        Else
            MessageBox.Show("Username or Password Incorrect!")
        End If

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DotNetVersion As String = System.Environment.Version.Major.ToString
        If CInt(DotNetVersion) < 4 Then
            MsgBox("Your .net framework version is not 4.0 please contact IT!", MsgBoxStyle.Critical, "Contact IT!")
            Application.Exit()
        End If
        GetIPAddress()
        Dim dtIpData = Bll.GetCheckIP(Trim(strHostName))
        Dim MyIP As String
        Dim MyHost As String
        Dim MyUser As String
        Dim MyStRemember As Integer
        If dtIpData.Rows.Count > 0 Then
            For i As Integer = 0 To dtIpData.Rows.Count - 1
                MyHost = dtIpData.Rows(0)("user_host")
                MyStRemember = dtIpData.Rows(0)("user_remember")
                MyUser = Trim(dtIpData.Rows(0)("user_username"))
            Next
            tbUsername.Text = MyUser.ToString
            If MyStRemember = 1 Then
                cbRemember.Checked = True
            End If
        End If

        'Chart
        'Fetch the Statistical data from database.


        Dim dt As DataTable = Bll.GetChart()

        'Get the names of Cities.
        Dim x As String() = (From p In dt.AsEnumerable()
                             Order By p.Field(Of String)("status_detail")
                             Select p.Field(Of String)("status_detail")).ToArray()

        'Get the Total of Orders for each City.
        Dim y As Integer() = (From p In dt.AsEnumerable()
                              Order By p.Field(Of String)("status_detail")
                              Select p.Field(Of Integer)("Total")).ToArray()

        Chart1.Series(0).ChartType = SeriesChartType.Doughnut
        Chart1.Series(0).Points.DataBindXY(x, y)
        Chart1.Legends(0).Enabled = True
        Chart1.Series(0).IsValueShownAsLabel = True
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True


        'Chart

        ' 
        _tStatus = New Threading.Thread(AddressOf Run)
        _tStatus.IsBackground = True
        _tStatus.Start()

    End Sub
    Private Sub GetIPAddress()



        strHostName = System.Net.Dns.GetHostName()

        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()



    End Sub
    Private Sub Run()
        While _tStatus.IsAlive
            Try
                'Dim StatusClose As Integer = Bll.GetStatusClose()
                'If StatusClose = 1 Then
                '    tbPassword.ReadOnly = True
                '    tbUsername.ReadOnly = True
                '    btnLogin.Enabled = False
                '    MsgBox("Now IT updating program and server. Please wait till already complete update.", MsgBoxStyle.Critical, "Updating program!")
                '    Application.Exit()
                'End If
                If My.Computer.Network.IsAvailable Then
                    If My.Computer.Network.Ping("10.50.0.8") Then
                        btnStatus.BackColor = Color.Green
                        btnStatus.ForeColor = Color.White
                    Else
                        btnStatus.BackColor = Color.Red
                        btnStatus.ForeColor = Color.Black
                    End If

                    Threading.Thread.Sleep(1000)
                    btnStatus.BackColor = Color.Gainsboro
                    btnStatus.ForeColor = Color.Black
                Else
                    btnStatus.BackColor = Color.Red
                    btnStatus.ForeColor = Color.Black
                End If



                Threading.Thread.Sleep(3000)
                btnStatus.BackColor = Color.Gainsboro
                btnStatus.ForeColor = Color.Black
            Catch ex As Exception

            End Try
        End While
    End Sub

End Class