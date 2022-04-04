Imports PR_Online.BLL
Imports System.Security.Cryptography


Public Class frmChangePass
#Region "Public Variables"
    Dim Bll As BLL_Load = New BLL_Load
    Dim dataUserID As Integer

    Private TripleDes As New TripleDESCryptoServiceProvider
#End Region
    Dim strUser As String
    Public Property _strUser() As String
        Get
            Return strUser
        End Get
        Set(ByVal value As String)
            strUser = value
        End Set
    End Property
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Dim dt_username As DataTable
        Dim u_status As Integer
        Dim u_id As Integer
        Dim u_name As String
        Dim OldPass As String = Bll.PassEncoding(tb_password.Text)
        dt_username = Bll.GetCheckLogin(tb_username.Text, OldPass)
        If dt_username.Rows.Count > 0 Then
            For i As Integer = 0 To dt_username.Rows.Count - 1
                u_id = dt_username.Rows(0)("user_id").ToString
                u_status = dt_username.Rows(0)("user_permission_pr").ToString
                u_name = dt_username.Rows(0)("user_fullname").ToString
            Next
            If tbNewpass.Text = tbConNewpass.Text Then
                Dim EncryptPass As String = Bll.PassEncoding(tbNewpass.Text)
                Dim INS As Boolean = Bll.UpdatePassword(tb_id.Text, EncryptPass)
                If INS = True Then
                    MsgBox("Change Password Complete", MsgBoxStyle.OkOnly, "Complete")

                    Me.Close()

                Else
                    MsgBox("Change Password not Complete please contact IT", MsgBoxStyle.OkOnly, "Not Complete")
                End If

            Else

                MessageBox.Show("Password Not match")
            End If


        Else
            MessageBox.Show("Old Password Incorrect")
        End If
    End Sub

    Private Sub frmChangePass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_username As DataTable

        dt_username = Bll.GetDataUser(CInt(strUser))
        If dt_username.Rows.Count > 0 Then
            Me.tb_username.Text = dt_username.Rows(0)("user_username").ToString
            Me.tb_id.Text = Trim(dt_username.Rows(0)("user_id").ToString)
        End If

    End Sub


End Class