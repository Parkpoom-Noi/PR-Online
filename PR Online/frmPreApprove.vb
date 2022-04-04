Imports PR_Online.BLL
Imports System.Threading
Imports System.IO

Public Class frmPreApprove
    Dim Bll As BLL_Load = New BLL_Load
    Dim _tStatus As Threading.Thread
    Dim StatusRun As Boolean

    Dim strPr As String
    Dim strPrID As String

    Dim strUser As String
    Dim strUserID As String

    Dim strTypeBtn As String
    Dim strTypeBtnID As String

    Dim dtPR As New DataTable
    Dim dtTagPR As New DataTable
    Dim dtItemPR As New DataTable
    Dim prUrgent As Integer


    Dim PrOltag As String
    Dim TotalQty As Integer = 0
    Dim TotalAmount As Integer = 0
    Dim prStatus As Integer


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

    Public Property _strTypeBtn() As String
        Get
            Return strTypeBtn
        End Get
        Set(ByVal value As String)
            strTypeBtn = value
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
            prUrgent = dtTagPR.Rows(0)("pr_ol_urgent")

            tbGlAc.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_GlAccount")), "", dtTagPR.Rows(0)("pr_ol_GlAccount"))
            tbGlDe.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_GlDetail")), "", dtTagPR.Rows(0)("pr_ol_GlDetail"))
            lbGlOwner.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_GlName")), "", "GL Owner : " & dtTagPR.Rows(0)("pr_ol_GlName"))
            '
            If dtTagPR.Rows(0)("pr_ol_req_mgrStatus") = 5 Then
                pbStatusReqMgr.Image = My.Resources.spam
            ElseIf dtTagPR.Rows(0)("pr_ol_req_mgrStatus") = 0 Then
                pbStatusReqMgr.Image = My.Resources.timer
            ElseIf dtTagPR.Rows(0)("pr_ol_req_mgrStatus") = 1 Then
                pbStatusReqMgr.Image = My.Resources.approved__1_
            ElseIf dtTagPR.Rows(0)("pr_ol_req_mgrStatus") = 2 Then
                pbStatusReqMgr.Image = My.Resources.rejected__2_
            Else
                pbStatusReqMgr.Image = My.Resources._error
            End If
            lbManager.Text = dtTagPR.Rows(0)("pr_ol_req_mgrName")
            tbMgr.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_req_mgrMsg")), "", dtTagPR.Rows(0)("pr_ol_req_mgrMsg"))

            If IsDBNull(dtTagPR.Rows(0)("pr_ol_req_mgrDate")) Then
                lbDateMgr.Text = "-"
            Else
                lbDateMgr.Text = dtTagPR.Rows(0)("pr_ol_req_mgrDate")
            End If
            '

            If IsDBNull(dtTagPR.Rows(0)("pr_ol_GlStatus")) Then
                pbStatusGl.Image = My.Resources.spam
            ElseIf dtTagPR.Rows(0)("pr_ol_GlStatus") = 0 Then
                pbStatusGl.Image = My.Resources.timer
            ElseIf dtTagPR.Rows(0)("pr_ol_GlStatus") = 1 Then
                pbStatusGl.Image = My.Resources.approved__1_
            ElseIf dtTagPR.Rows(0)("pr_ol_GlStatus") = 2 Then
                pbStatusGl.Image = My.Resources.rejected__2_
            Else
                pbStatusReqMgr.Image = My.Resources._error
            End If
            lbGlMgr.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_GlName")), "", dtTagPR.Rows(0)("pr_ol_GlName"))
            tbGL.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_GlMsg")), "", dtTagPR.Rows(0)("pr_ol_GlMsg"))

            If IsDBNull(dtTagPR.Rows(0)("pr_ol_GlDate")) Then
                lbDateGl.Text = "-"
            Else
                lbDateGl.Text = dtTagPR.Rows(0)("pr_ol_GlDate")
            End If
            '


            '
            If dtTagPR.Rows(0)("pr_ol_gmStatus") = 5 Then
                pbStatusGM.Visible = False
                pbGmNo.Visible = True
                lbGm.Visible = False
                lbGm2.Visible = False
                lbGm3.Visible = False
                lbGm4.Visible = False
                lbDateGm.Visible = False
                tbGm.Visible = False
            ElseIf dtTagPR.Rows(0)("pr_ol_gmStatus") = 0 Then
                pbStatusGM.Image = My.Resources.timer
            ElseIf dtTagPR.Rows(0)("pr_ol_gmStatus") = 1 Then
                pbStatusGM.Image = My.Resources.approved__1_
            ElseIf dtTagPR.Rows(0)("pr_ol_gmStatus") = 2 Then
                pbStatusGM.Image = My.Resources.rejected__2_
            Else
                pbStatusGM.Image = My.Resources._error
            End If
            lbGm.Text = dtTagPR.Rows(0)("pr_ol_gmName")
            tbGm.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_gmMsg")), "", dtTagPR.Rows(0)("pr_ol_gmMsg"))
            If IsDBNull(dtTagPR.Rows(0)("pr_ol_gmDate")) Then
                lbDateGm.Text = "-"
            Else
                lbDateGm.Text = dtTagPR.Rows(0)("pr_ol_gmDate")
            End If

            '
            If IsDBNull(dtTagPR.Rows(0)("pr_ol_scMgr_status")) Then
                pbStatusScm.Image = My.Resources.spam
            ElseIf dtTagPR.Rows(0)("pr_ol_scMgr_status") = 0 Then
                pbStatusScm.Image = My.Resources.timer
            ElseIf dtTagPR.Rows(0)("pr_ol_scMgr_status") = 1 Then
                pbStatusScm.Image = My.Resources.approved__1_
            ElseIf dtTagPR.Rows(0)("pr_ol_scMgr_status") = 2 Then
                pbStatusScm.Image = My.Resources.rejected__2_
            Else
                pbStatusScm.Image = My.Resources._error
            End If
            lbScm.Text = dtTagPR.Rows(0)("pr_ol_scMgr_name")
            tbScm.Text = IIf(IsDBNull(dtTagPR.Rows(0)("pr_ol_scMgr_msg")), "", dtTagPR.Rows(0)("pr_ol_scMgr_msg"))
            If IsDBNull(dtTagPR.Rows(0)("pr_ol_scMgr_date")) Then
                lbDateScm.Text = "-"
            Else
                lbDateScm.Text = dtTagPR.Rows(0)("pr_ol_scMgr_date")
            End If

            ' 
            If IsDBNull(dtTagPR.Rows(0)("pr_ol_poNo")) Then
                lbPoNo.Text = "-"
            Else
                lbPoNo.Text = dtTagPR.Rows(0)("pr_ol_poNo")
            End If
            ' 
            If IsDBNull(dtTagPR.Rows(0)("pr_ol_assignPrepareName")) Then
                lbPrepareBy.Text = "-"
            Else
                lbPrepareBy.Text = dtTagPR.Rows(0)("pr_ol_assignPrepareName")
            End If
            ' 
            If IsDBNull(dtTagPR.Rows(0)("pr_ol_assignDate")) Then
                lbAssignDate.Text = "-"
            Else
                lbAssignDate.Text = dtTagPR.Rows(0)("pr_ol_assignDate")
            End If
            '
            prStatus = dtTagPR.Rows(0)("pr_ol_prStatus")
            lbPlants.Text = dtTagPR.Rows(0)("pr_ol_Plants")
            If Trim(dtTagPR.Rows(0)("pr_ol_type")) = 1 Then
                'Checked
                lbType.Text = "PR no CER"
            ElseIf Trim(dtTagPR.Rows(0)("pr_ol_type")) = 2 Then
                'Checked
                lbType.Text = "Asset no CER"
            ElseIf Trim(dtTagPR.Rows(0)("pr_ol_type")) = 3 Then
                'Checked
                lbType.Text = "Plant ART1 CER No. - " & Trim(dtTagPR.Rows(0)("pr_ol_CerNo"))
            ElseIf Trim(dtTagPR.Rows(0)("pr_ol_type")) = 4 Then
                'Checked
                lbType.Text = "Plant ART3 CER No. - " & Trim(dtTagPR.Rows(0)("pr_ol_CerNo"))
            Else
                'Checked
                lbType.Text = "Material"
            End If
        End If
    End Sub
    Public Sub GetItemPr()
        dtPR.Clear()
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
                                dtItemPR.Rows(i)("pr_item_amount"),
                                dtItemPR.Rows(i)("pr_item_poPronto"),
                                dtItemPR.Rows(i)("pr_item_logEdit_date"))
            Next

            dgvItemPR.DataSource = dtPR
        End If
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

    Public Sub frmPreApprove_Load() Handles MyBase.Load
        btnApprovePr.Visible = False
        btnPurAction.Visible = False
        btnScmAss.Visible = False
        strPrID = strPr.ToString
        lbTagID.Text = strPrID

        strUserID = strUser.ToString
        lbUserID.Text = strUserID

        strTypeBtnID = strTypeBtn.ToString
        lbTypeBtn.Text = strTypeBtnID

        If strTypeBtn = "MgrApp" Then
            btnApprovePr.Visible = True
            btnPurAction.Visible = False
            btnScmAss.Visible = False
        ElseIf strTypeBtn = "MgrNonApp" Then
            btnApprovePr.Visible = False
            btnPurAction.Visible = False
            btnScmAss.Visible = False
        ElseIf strTypeBtn = "Purchase" Then
            btnApprovePr.Visible = False
            btnPurAction.Visible = True
            btnScmAss.Visible = False
        ElseIf strTypeBtn = "ScMgr" Then
            btnApprovePr.Visible = False
            btnPurAction.Visible = False
            btnScmAss.Visible = True
        End If

        dtPR.Columns.Clear()
        dtPR.Columns.Add("ItemID")
        dtPR.Columns.Add("Require Date")
        dtPR.Columns.Add("Recommend Supplier")
        dtPR.Columns.Add("RFQ No")
        dtPR.Columns.Add("Discription")
        dtPR.Columns.Add("Job")
        dtPR.Columns.Add("Q'ty")
        dtPR.Columns.Add("Unit Price")
        dtPR.Columns.Add("Amount")
        dtPR.Columns.Add("PO in Pronto")
        dtPR.Columns.Add("PO date")

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


    Private Sub btnOpenPdf_Click(sender As Object, e As EventArgs) Handles btnOpenPdf.Click
        Dim PDF_PATH As String = "P:/IT/PR Online Attach Files/" & Trim(lbAttachFile.Text)
        'Process.Start(PDF_PATH) 'works
        System.Diagnostics.Process.Start(PDF_PATH)
    End Sub

    Private Sub btnApprovePr_Click(sender As Object, e As EventArgs) Handles btnApprovePr.Click

        frmApprove._strPr = lbTagID.Text
        frmApprove._strUser = lbUserID.Text ' 
        frmApprove.Show()
        Me.Hide()
    End Sub

    Private Sub btnPurAction_Click(sender As Object, e As EventArgs) Handles btnPurAction.Click

        frmPurchase._strPr = lbTagID.Text
        frmPurchase._strUser = lbUserID.Text '
        frmPurchase.Show()
        Me.Hide()
    End Sub

    Private Sub btnScmAss_Click(sender As Object, e As EventArgs) Handles btnScmAss.Click

        frmScMgr._strPr = lbTagID.Text
        frmScMgr._strUser = lbUserID.Text ' 
        frmScMgr.Show()
        Me.Hide()
    End Sub


    Private Sub frmPreApprove_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim TagID As String = lbPrTag.Text
        frmReport._strPr = TagID.ToString ' 
        frmReport.Show()
    End Sub

#End Region
End Class