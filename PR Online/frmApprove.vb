Imports PR_Online.BLL
Imports System.Threading
Imports System.IO

Public Class frmApprove
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
    Dim GlName As String
    Dim GlEmail As String

    Dim GmName As String
    Dim GmEmail As String

    Dim ScName As String
    Dim ScEmail As String

    Dim ReqMgrName As String
    Dim ReqMgrEmail As String

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
            tbGlAc.Text = dtTagPR.Rows(0)("pr_ol_GlAccount")
            tbGlDe.Text = dtTagPR.Rows(0)("pr_ol_GlDetail")
            lbGlOwner.Text = "GL Owner : " & dtTagPR.Rows(0)("pr_ol_GlName")

            ReqMgrName = dtTagPR.Rows(0)("pr_ol_req_mgrName")
            ReqMgrEmail = dtTagPR.Rows(0)("pr_ol_req_mgrEmail")

            GlName = dtTagPR.Rows(0)("pr_ol_GlName")
            GlEmail = dtTagPR.Rows(0)("pr_ol_GlEmail")

            GmName = dtTagPR.Rows(0)("pr_ol_gmName")
            GmEmail = dtTagPR.Rows(0)("pr_ol_gmEmail")

            ScName = dtTagPR.Rows(0)("pr_ol_scMgr_name")
            ScEmail = dtTagPR.Rows(0)("pr_ol_scMgr_email")

            ReqEmail = dtTagPR.Rows(0)("pr_ol_req_email")
             
            If dtTagPR.Rows.Count > 0 Then
                If dtTagPR.Rows(0)("pr_ol_req_mgrID").ToString = CInt(lbUserID.Text) Then
                    cbReqMgr.Checked = True
                End If
                If dtTagPR.Rows(0)("pr_ol_GlUserID") = CInt(lbUserID.Text) Then
                    cbGlMgr.Checked = True
                End If
                If dtTagPR.Rows(0)("pr_ol_gmID") = CInt(lbUserID.Text) Then
                    cbGmMgr.Checked = True
                End If

            End If
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

        GetTagPr()
        GetItemPr()
        If prUrgent = 1 Then
            cbUrgent.Checked = True
            cbUrgent.Visible = False
            pbUrgent.Visible = True
        Else
            cbUrgent.Checked = False
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



    Private Sub btnOpenPdf_Click(sender As Object, e As EventArgs) Handles btnOpenPdf.Click
        Dim PDF_PATH As String = "P:/IT/PR Online Attach Files/" & Trim(lbAttachFile.Text)
        'Process.Start(PDF_PATH) 'works
        System.Diagnostics.Process.Start(PDF_PATH)
    End Sub

    Private Sub pbApprove_Click(sender As Object, e As EventArgs) Handles pbApprove.Click
        Dim IpApprove As String = Bll.GetIPAddress()
        Dim PrStatus As Integer
        Dim StatusApprove As Boolean

        ' for send Email Process
        Dim NxtColEmail As String = ""
        Dim ReqBy As String = lbReqBy.Text
        Dim NxtColName As String = ""
        Dim NxtTypeMail As String = ""

        Dim UrgentStatus As Integer
        If cbUrgent.Checked = True Then
            UrgentStatus = 1
        Else
            UrgentStatus = 0
        End If

        If MsgBox("Are you confirm Approved data ?", MsgBoxStyle.YesNo, "Confirm Approved Data") = MsgBoxResult.Yes Then

            If cbGlMgr.Checked = False Then
                If cbReqMgr.Checked = True Then
                    PrStatus = 3 'Waiting GL Mgr Approve.
                    NxtColEmail = GlEmail.ToString
                    NxtColName = GlName.ToString
                    NxtTypeMail = "GlMgr"
                    StatusApprove = Bll.ActionReqMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 1, tbFbApprove.Text, IpApprove, PrStatus, UrgentStatus)

                ElseIf cbGmMgr.Checked = True Then
                    PrStatus = 7 'Waiting SC Mgr Assign.
                    NxtColEmail = ScEmail.ToString
                    NxtColName = ScName.ToString
                    NxtTypeMail = "ScMgr"
                    StatusApprove = Bll.ActionGMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 1, tbFbApprove.Text, IpApprove, PrStatus, UrgentStatus)
                End If


                If StatusApprove And Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtColName, NxtTypeMail, UrgentStatus) Then
                    MsgBox("Approved PR Online complete!", MsgBoxStyle.Information, "Complete!")
                Else
                    MsgBox("Approved PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                End If
            ElseIf cbGlMgr.Checked = True And cbReqMgr.Checked = False Then
                If TotalAmount > 10000 Then
                    PrStatus = 5 'Waiting GM Approve.
                    NxtColEmail = GmEmail.ToString
                    NxtColName = GmName.ToString
                    NxtTypeMail = "GMgr"
                Else
                    PrStatus = 7 'Waiting SC Mgr Assign.
                    NxtColEmail = ScEmail.ToString
                    NxtColName = ScName.ToString
                    NxtTypeMail = "ScMgr"
                End If
                StatusApprove = Bll.ActionGlMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 1, tbFbApprove.Text, IpApprove, PrStatus, UrgentStatus)

                If StatusApprove And Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtColName, NxtTypeMail, UrgentStatus) Then
                    MsgBox("Approved PR Online complete!", MsgBoxStyle.Information, "Complete!")
                Else
                    MsgBox("Approved PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                End If
            ElseIf cbGlMgr.Checked = True And cbReqMgr.Checked = True Then

                If TotalAmount > 10000 Then
                    PrStatus = 5 'Waiting GM Approve. 
                    NxtColEmail = GmEmail.ToString
                    NxtColName = GmName.ToString
                    NxtTypeMail = "GMgr"
                Else
                    PrStatus = 7 'Waiting SC Mgr Assign.
                    NxtColEmail = ScEmail.ToString
                    NxtColName = ScName.ToString
                    NxtTypeMail = "ScMgr"
                End If

                StatusApprove = (Bll.ActionGlMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 1, tbFbApprove.Text, IpApprove, PrStatus, UrgentStatus) And
                                 Bll.ActionReqMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 1, tbFbApprove.Text, IpApprove, PrStatus, UrgentStatus) And
                                 (Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtColName, NxtTypeMail, UrgentStatus)))

                If StatusApprove Then
                    MsgBox("Approved PR Online complete!", MsgBoxStyle.Information, "Complete!")
                Else
                    MsgBox("Approved PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                End If

            End If
            Dim strTypeBtnID As String = "MgrNonApp" '
            frmPreApprove._strPr = lbTagID.Text ' 
            frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
            frmPreApprove.frmPreApprove_Load()
            frmMain.frmMain_Load()
            frmPreApprove.Show()
            Me.Close()
        End If
    End Sub

    Private Sub pbReject_Click(sender As Object, e As EventArgs) Handles pbReject.Click
        If Trim(tbFbReject.Text) <> "" Then
            Dim IpApprove As String = Bll.GetIPAddress()
            Dim PrStatus As Integer
            Dim StatusApprove As Boolean

            ' for send Email Process
            Dim NxtColEmail As String = ""
            Dim ReqBy As String = lbReqBy.Text
            Dim NxtColName As String = ""
            Dim NxtTypeMail As String = ""

            Dim UrgentStatus As Integer
            If cbUrgent.Checked = True Then
                UrgentStatus = 1
            Else
                UrgentStatus = 0
            End If
            If MsgBox("Are you confirm Rejected data ?", MsgBoxStyle.YesNo, "Confirm Rejected Data") = MsgBoxResult.Yes Then

                If cbGlMgr.Checked = False Then

                    If cbReqMgr.Checked = True Then
                        PrStatus = 2 'Req.Mgr Rejected!
                        NxtColEmail = ReqEmail.ToString
                        NxtColName = ReqBy
                        NxtTypeMail = "RjUser"
                        StatusApprove = Bll.ActionReqMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 2, tbFbReject.Text, IpApprove, PrStatus, UrgentStatus)

                    ElseIf cbGmMgr.Checked = True Then
                        PrStatus = 6 'GM Rejected!
                        NxtColEmail = ReqEmail.ToString
                        NxtColName = ReqBy
                        NxtTypeMail = "RjUser"
                        StatusApprove = Bll.ActionGMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 2, tbFbReject.Text, IpApprove, PrStatus, UrgentStatus)
                    End If
                    If StatusApprove And Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtColName, NxtTypeMail, UrgentStatus) Then
                        MsgBox("Rejected PR Online complete!", MsgBoxStyle.Information, "Complete!")
                    Else
                        MsgBox("Rejected PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                    End If
                ElseIf cbGlMgr.Checked = True And cbReqMgr.Checked = False Then
                    PrStatus = 4 'GL Mgr Rejected!
                    NxtColEmail = ReqEmail.ToString
                    NxtColName = ReqBy
                    NxtTypeMail = "RjUser"
                    StatusApprove = Bll.ActionGlMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 2, tbFbReject.Text, IpApprove, PrStatus, UrgentStatus)
                    If StatusApprove And Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtColName, NxtTypeMail, UrgentStatus) Then
                        MsgBox("Rejected PR Online complete!", MsgBoxStyle.Information, "Complete!")
                    Else
                        MsgBox("Rejected PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                    End If
                ElseIf cbGlMgr.Checked = True And cbReqMgr.Checked = True Then
                    PrStatus = 4 'GL Mgr Rejected!
                    NxtColEmail = ReqEmail.ToString
                    NxtColName = ReqBy
                    NxtTypeMail = "RjUser"
                    StatusApprove = (Bll.ActionGlMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 2, tbFbReject.Text, IpApprove, PrStatus, UrgentStatus) And
                                     Bll.ActionReqMgr(CInt(lbTagID.Text), CInt(lbUserID.Text), 2, tbFbReject.Text, IpApprove, PrStatus, UrgentStatus))
                    If StatusApprove And Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtColName, NxtTypeMail, UrgentStatus) Then
                        MsgBox("Rejected PR Online complete!", MsgBoxStyle.Information, "Complete!")
                    Else
                        MsgBox("Rejected PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                    End If

                End If

            End If

            Dim strTypeBtnID As String = "MgrNonApp" '
            frmPreApprove._strPr = lbTagID.Text ' 
            frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
            frmPreApprove.frmPreApprove_Load()
            frmMain.frmMain_Load()
            frmPreApprove.Show()
            Me.Close()
        Else
            MsgBox("Please add some text to reject textbox for Feedback Message!", MsgBoxStyle.Information, "Feedback Message!")
        End If

    End Sub

    Private Sub frmApprove_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        frmPreApprove._strPr = lbTagID.Text '  
        frmPreApprove.frmPreApprove_Load()
        frmMain.frmMain_Load()
        frmPreApprove.Show()
    End Sub


End Class