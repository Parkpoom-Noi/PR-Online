
Imports PR_Online.BLL
Imports System.Threading
Imports System.IO

Public Class frmScMgr
    Dim Bll As BLL_Load = New BLL_Load
    Dim _tStatus As Threading.Thread
    Dim StatusRun As Boolean
    Dim strPr As String
    Dim strPrID As String
    Dim strUser As String
    Dim strUserID As String

    Dim dtPR As New DataTable
    Dim dtTagPR As New DataTable
    Dim dtItemPR As New DataTable


    Dim PrOltag As String
    Dim TotalQty As Integer = 0
    Dim TotalAmount As Integer = 0
    Dim prStatus As Integer
    Dim prUrgent As Integer

    ' For send Email
    Dim PurName As String
    Dim PurEmail As String

    Dim ReqName As String
    Dim ReqEmail As String

#Region "All Sub and Function"
    Public Property _strPr() As String
        Get
            Return strPr
        End Get
        Set(ByVal value As String)
            strPr = value
        End Set
    End Property
    Public Property _strUser() As String
        Get
            Return strUser
        End Get
        Set(ByVal value As String)
            strUser = value
        End Set
    End Property
    Private Sub Run()
        While _tStatus.IsAlive
            Try
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

                Threading.Thread.Sleep(1000)
                btnStatus.BackColor = Color.Gainsboro
                btnStatus.ForeColor = Color.Black
            Catch ex As Exception

            End Try
        End While
    End Sub
    Public Sub GetTagPr()
        dtTagPR = Bll.GetPrTagData(CInt(strPrID))
        If dtTagPR.Rows.Count > 0 Then

            PrOltag = Trim(dtTagPR.Rows(0)("pr_ol_tag"))
            lbPrTag.Text = Trim(dtTagPR.Rows(0)("pr_ol_tag"))
            lbDept.Text = dtTagPR.Rows(0)("pr_ol_dept")
            lbReqBy.Text = dtTagPR.Rows(0)("pr_ol_req_by")
            lbDept.Text = dtTagPR.Rows(0)("pr_ol_dept")
            lbAttachFile.Text = dtTagPR.Rows(0)("pr_ol_attachFile")
            lbPrDate.Text = dtTagPR.Rows(0)("pr_ol_date")
            prStatus = dtTagPR.Rows(0)("pr_ol_prStatus")
            prUrgent = dtTagPR.Rows(0)("pr_ol_urgent")

            tbGlAc.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_GlAccount")), "", dtTagPR.Rows(0)("pr_ol_GlAccount"))
            tbGlDe.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_GlDetail")), "", dtTagPR.Rows(0)("pr_ol_GlDetail"))
            lbGlOwner.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_GlName")), "", "GL Owner : " & dtTagPR.Rows(0)("pr_ol_GlName"))


            ReqName = dtTagPR.Rows(0)("pr_ol_req_by")
            ReqEmail = dtTagPR.Rows(0)("pr_ol_req_email")
        End If
    End Sub
    Public Sub GetItemPr()
        dtItemPR = Bll.GetPrItemData(PrOltag)
        If dtItemPR.Rows.Count > 0 Then
            For i = 0 To dtItemPR.Rows.Count - 1
                dtPR.Rows.Add(dtItemPR.Rows(i)("pr_item_id"),
                                    dtItemPR.Rows(i)("pr_item_reqDate"),
                                    dtItemPR.Rows(i)("pr_item_suppiler"),
                                    dtItemPR.Rows(i)("pr_item_rfq"),
                                    dtItemPR.Rows(i)("pr_item_detail"),
                                    dtItemPR.Rows(i)("pr_item_job"),
                                    dtItemPR.Rows(i)("pr_item_qty"),
                                    dtItemPR.Rows(i)("pr_item_unitPrice"),
                                    dtItemPR.Rows(i)("pr_item_amount")) 'Recomend Supplier
            Next

            dgvItemPR.DataSource = dtPR
        End If
        TotalQty = 0
        TotalAmount = 0
        If dgvItemPR.RowCount > 0 Then
            'if you have the other column to get the result you  could add a new one like these above 
            For index As Integer = 0 To dgvItemPR.RowCount - 1
                TotalQty += Convert.ToInt32(dgvItemPR.Rows(index).Cells(6).Value)
                TotalAmount += Convert.ToInt32(dgvItemPR.Rows(index).Cells(8).Value)
                'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
            Next
            lbTotalQty.Text = "Total Q'ty : " & TotalQty
            lbTotalAmount.Text = "Total Amount : " & TotalAmount

            'if you have the other column to get the result you  could add a new one like these above 
        End If
    End Sub

    Public Sub GetPurchaseEmp()
        Dim dtData As DataTable

        Dim col As New AutoCompleteStringCollection
        dtData = Bll.GetPurchaseEmp()
        For i As Integer = 0 To dtData.Rows.Count - 1
            cbAssignTo.Items.Add(dtData.Rows(i)("user_username").ToString())
        Next
    End Sub
#End Region
    Private Sub frmApprove_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        strPrID = strPr.ToString
        lbTagID.Text = strPrID

        strUserID = strUser.ToString
        lbUserID.Text = strUserID
        dtPR.Columns.Add("ItemID")
        dtPR.Columns.Add("Require Date")
        dtPR.Columns.Add("Recommend Supplier")
        dtPR.Columns.Add("RFQ No")
        dtPR.Columns.Add("Discription")
        dtPR.Columns.Add("Job")
        dtPR.Columns.Add("Q'ty")
        dtPR.Columns.Add("Unit Price")
        dtPR.Columns.Add("Amount")

        GetPurchaseEmp()
        GetTagPr()
        GetItemPr()

        If prUrgent = 1 Then
            pbUrgent.Visible = True
        Else
            pbUrgent.Visible = False
        End If
        lbStatusPR.Text = Bll.GetStatusPR(prStatus)
        If prStatus = 0 Then 'Inactive
            pbStatus.Image = My.Resources.delete
        ElseIf prStatus = 1 Then 'Waiting Req. Mgr Approve.
            pbStatus.Image = My.Resources.share
        ElseIf prStatus = 2 Then 'Req.Mgr Rejected!
            pbStatus.Image = My.Resources.rejected__1_
        ElseIf prStatus = 3 Then 'Waiting GL Mgr Approve.
            pbStatus.Image = My.Resources.share
        ElseIf prStatus = 4 Then 'GL Mgr Rejected!
            pbStatus.Image = My.Resources.rejected__1_
        ElseIf prStatus = 5 Then 'Waiting GM Approve.
            pbStatus.Image = My.Resources.share
        ElseIf prStatus = 6 Then 'GM Rejected!
            pbStatus.Image = My.Resources.rejected__1_
        ElseIf prStatus = 7 Then 'Waiting SC Mgr Assign.
            pbStatus.Image = My.Resources.timeline
        ElseIf prStatus = 8 Then 'SC Mgr Rejected!
            pbStatus.Image = My.Resources.rejected__1_
        ElseIf prStatus = 9 Then 'Purchasing create PO.
            pbStatus.Image = My.Resources.refresh
        ElseIf prStatus = 10 Then 'PR Online Complete!
            pbStatus.Image = My.Resources.verified
        Else 'Error
            pbStatus.Image = My.Resources.spam
        End If

        Dim PDF_PATH As String = "P:/IT/PR Online Attach Files/" & Trim(lbAttachFile.Text)
        If System.IO.File.Exists(PDF_PATH) Then
            btnOpenPdf.Text = "Open PDF"
            btnOpenPdf.Enabled = True
        Else
            btnOpenPdf.Text = "No File PDF"
            btnOpenPdf.Enabled = False
        End If

        _tStatus = New Threading.Thread(AddressOf Run)
        _tStatus.IsBackground = True
        _tStatus.Start()
    End Sub



    Private Sub btnOpenPdf_Click(sender As Object, e As EventArgs) 
        Dim PDF_PATH As String = "P:/IT/PR Online Attach Files/" & Trim(lbAttachFile.Text)
        'Process.Start(PDF_PATH) 'works
        System.Diagnostics.Process.Start(PDF_PATH)
    End Sub

    Private Sub pbApprove_Click(sender As Object, e As EventArgs) Handles pbApprove.Click

        Dim pr_ol_assignPrepareName As String = lbPrepareName.Text
        Dim IpApprove As String = Bll.GetIPAddress()
        Dim PrStatus As Integer = 9
        Dim pr_ol_assignBy As String = Bll.GetAssisnName(CInt(lbUserID.Text))
        If MsgBox("Are you confirm Approved data ?", MsgBoxStyle.YesNo, "Confirm Approved Data") = MsgBoxResult.Yes Then

            ' for send Email Process
            Dim NxtColEmail As String = lbPrepareEmail.Text
            Dim NxtColName As String = lbPrepareName.Text
            Dim ReqBy As String = ReqName.ToString
            Dim NxtTypeMail As String = "Purchase"

            Dim UrgentStatus As Integer
            If prUrgent = 1 Then
                UrgentStatus = 1
            Else
                UrgentStatus = 0
            End If
            If lbUserID.Text = 1 Then
                lbAssignTo.Text = 1
            End If
            If Bll.ActionScMgr(CInt(lbTagID.Text), 1, tbFbApprove.Text, IpApprove, PrStatus, CInt(lbAssignTo.Text), lbPrepareName.Text, pr_ol_assignBy, lbPrepareEmail.Text) And
                Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtColName, NxtTypeMail, UrgentStatus) Then
                MsgBox("Approved PR Online complete!", MsgBoxStyle.Information, "Complete!")
                frmPreApprove._strPr = lbTagID.Text
                frmPreApprove.frmPreApprove_Load()
                frmMain.frmMain_Load()
                frmPreApprove.Show()
                Me.Close()
            Else
                MsgBox("Approved PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                End If

            End If
    End Sub

    Private Sub pbReject_Click(sender As Object, e As EventArgs) Handles pbReject.Click
        If Trim(tbFbReject.Text) <> "" Then
            Dim IpApprove As String = Bll.GetIPAddress()
            Dim PrStatus As Integer = 8

            ' for send Email Process
            Dim NxtColEmail As String = ReqEmail.ToString
            Dim NxtColName As String = ReqName.ToString
            Dim ReqBy As String = ReqName.ToString
            Dim NxtTypeMail As String = "RjUser"

            Dim UrgentStatus As Integer
            If prUrgent = 1 Then
                UrgentStatus = 1
            Else
                UrgentStatus = 0
            End If
            If MsgBox("Are you confirm Rejected data ?", MsgBoxStyle.YesNo, "Confirm Rejected Data") = MsgBoxResult.Yes Then
                If Bll.ActionScMgr(CInt(lbTagID.Text), 2, tbFbReject.Text, IpApprove, PrStatus, 0, "", "", "") And
                    Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtColName, NxtTypeMail, UrgentStatus) Then
                    MsgBox("Reject PR Online complete!", MsgBoxStyle.Information, "Complete!")
                    frmPreApprove._strPr = lbTagID.Text
                    frmPreApprove.frmPreApprove_Load()
                    frmMain.frmMain_Load()
                    frmPreApprove.Show()
                    Me.Close()
                Else
                    MsgBox("Reject PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                End If
            End If
        Else
            MsgBox("Please add some text to reject textbox for Feedback Message!", MsgBoxStyle.Information, "Feedback Message!")
        End If

    End Sub


    Private Sub cbAssignTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAssignTo.SelectedIndexChanged
        Dim dt_DataDeail As DataTable
        dt_DataDeail = Bll.GetPurchaseEmpData("AND [user_username] = '" & Trim(cbAssignTo.Text) & "'")
        If dt_DataDeail.Rows.Count > 0 Then
            For i As Integer = 0 To dt_DataDeail.Rows.Count - 1
                lbAssignTo.Text = dt_DataDeail.Rows(i)("user_id").ToString()
                lbPrepareName.Text = dt_DataDeail.Rows(i)("user_fullname").ToString()
                lbPrepareEmail.Text = dt_DataDeail.Rows(i)("user_email").ToString()
            Next
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBox("Are you confirm Cancel PR ?", MsgBoxStyle.YesNo, "Confirm Cancel Data") = MsgBoxResult.Yes Then
            If Trim(tbFbReject.Text) <> "" Then
                Dim IpApprove As String = Bll.GetIPAddress()
                Dim PrStatus As Integer = 11
                Dim NxtColEmail As String = ReqEmail.ToString
                Dim NxtColName As String = ReqName.ToString
                Dim ReqBy As String = ReqName.ToString
                Dim NxtTypeMail As String = "CancelPR"

                Dim UrgentStatus As Integer
                If prUrgent = 1 Then
                    UrgentStatus = 1
                Else
                    UrgentStatus = 0
                End If

                If MsgBox("Are you confirm Rejected data ?", MsgBoxStyle.YesNo, "Confirm Cancel Data") = MsgBoxResult.Yes Then
                    If Bll.ActionScMgr(CInt(lbTagID.Text), 2, tbFbReject.Text, IpApprove, PrStatus, 0, "", "", "") And
                        Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtColName, NxtTypeMail, UrgentStatus) Then
                        MsgBox("Cancel PR Online complete!", MsgBoxStyle.Information, "Complete!")
                        frmPreApprove._strPr = lbTagID.Text
                        frmPreApprove.frmPreApprove_Load()
                        frmMain.frmMain_Load()
                        frmPreApprove.Show()
                        Me.Close()
                    Else
                        MsgBox("Cancel PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                    End If
                End If

            Else
                MsgBox("Please add some text to Cancel textbox for Feedback Message!", MsgBoxStyle.Information, "Feedback Message!")
            End If
        End If
    End Sub
End Class