


Imports PR_Online.BLL
        Imports System.Threading
        Imports System.IO

Public Class frmPurchase
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

    'for Send Email 
    Dim ReqEmail As String
    Dim ReqName As String
    Dim PurName As String

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

            ReqName = dtTagPR.Rows(0)("pr_ol_req_by")
            ReqEmail = dtTagPR.Rows(0)("pr_ol_req_email")
            PurName = dtTagPR.Rows(0)("pr_ol_assignPrepareName")
        End If
    End Sub
    Public Sub GetItemPr()

        dtPR.Rows.Clear()
        dtItemPR.Rows.Clear()
        dgvItemPR.DataSource = dtPR

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
                                    dtItemPR.Rows(i)("pr_item_poPronto"))
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
    Public Sub frmPurchase_Load() Handles MyBase.Load
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
        dtPR.Columns.Add("PO in Pronto")

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

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        If Trim(tbPoNo.Text) <> "" And lbItemID.Text <> 0 Then
            Dim IpApprove As String = Bll.GetIPAddress()

            ' for send Email Process
            Dim NxtColEmail As String = ReqEmail.ToString
            Dim ReqBy As String = ReqName.ToString
            Dim NxtPurName As String = ReqName.ToString
            Dim NxtTypeMail As String = "CpUser"

            If MsgBox("Are you confirm data ?", MsgBoxStyle.YesNo, "Confirm Data") = MsgBoxResult.Yes Then
                If Bll.UpdatePoInItem(CInt(lbItemID.Text), IpApprove, CInt(tbPoNo.Text)) Then
                    MsgBox("Save PO in PR Online complete!", MsgBoxStyle.Information, "Complete!")
                    lbItemID.Text = 0
                    tbReqDate.Text = ""
                    tbSupplier.Text = ""
                    tbRfq.Text = ""
                    tbDisc.Text = ""
                    tbJob.Text = ""
                    tbQty.Text = ""
                    tbPrice.Text = ""
                    tbAmount.Text = ""
                    tbPoNo.Text = ""
                    GetItemPr()
                    Dim TotalPO As Integer = 0
                    If dgvItemPR.RowCount > 0 Then
                        For index As Integer = 0 To dgvItemPR.RowCount - 1
                            If IsDBNull(dgvItemPR.Rows(index).Cells(9).Value) Then
                                Exit Sub
                            Else
                                TotalPO += 1
                            End If
                        Next
                        If dgvItemPR.RowCount = TotalPO Then

                            Dim UrgentStatus As Integer = 3
                            If Bll.UpdatePurClosePr(CInt(lbTagID.Text), IpApprove) And Bll.AlertEmail(lbPrTag.Text, NxtColEmail, ReqBy, NxtPurName, NxtTypeMail, UrgentStatus) Then
                                MsgBox("Save and Close PR Online complete!", MsgBoxStyle.Information, "Complete!")

                                Me.Close()
                            End If
                        End If
                    End If

                Else
                    MsgBox("Save PO in PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                End If
            End If
        Else
            MsgBox("Please add some text to PO No. textbox!", MsgBoxStyle.Information, "PO No.!")
        End If
    End Sub


    Private Sub dgvItemPR_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvItemPR.CellMouseClick
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then

            lbItemID.Text = 0
            lbItemID.Text = dgvItemPR.Rows(e.RowIndex).Cells(0).Value ' 
            tbReqDate.Text = IIf(IsDBNull(dgvItemPR.Rows(e.RowIndex).Cells(1).Value), "", dgvItemPR.Rows(e.RowIndex).Cells(1).Value)
            tbSupplier.Text = IIf(IsDBNull(dgvItemPR.Rows(e.RowIndex).Cells(2).Value), "", dgvItemPR.Rows(e.RowIndex).Cells(2).Value) '
            tbRfq.Text = IIf(IsDBNull(dgvItemPR.Rows(e.RowIndex).Cells(3).Value), "", dgvItemPR.Rows(e.RowIndex).Cells(3).Value) '
            tbDisc.Text = IIf(IsDBNull(dgvItemPR.Rows(e.RowIndex).Cells(4).Value), "", dgvItemPR.Rows(e.RowIndex).Cells(4).Value) '
            tbJob.Text = IIf(IsDBNull(dgvItemPR.Rows(e.RowIndex).Cells(5).Value), "", dgvItemPR.Rows(e.RowIndex).Cells(5).Value) '
            tbQty.Text = IIf(IsDBNull(dgvItemPR.Rows(e.RowIndex).Cells(6).Value), "", dgvItemPR.Rows(e.RowIndex).Cells(6).Value) '
            tbPrice.Text = IIf(IsDBNull(dgvItemPR.Rows(e.RowIndex).Cells(7).Value), "", dgvItemPR.Rows(e.RowIndex).Cells(7).Value) ' 
            tbAmount.Text = IIf(IsDBNull(dgvItemPR.Rows(e.RowIndex).Cells(8).Value), "", dgvItemPR.Rows(e.RowIndex).Cells(8).Value) ' 
            tbPoNo.Text = IIf(IsDBNull(dgvItemPR.Rows(e.RowIndex).Cells(9).Value), "", dgvItemPR.Rows(e.RowIndex).Cells(9).Value) ' 


        End If
    End Sub

    Private Sub frmPurchase_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim strTypeBtnID As String = "Purchase" '
        frmPreApprove._strPr = lbTagID.Text ' 
        frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
        frmPreApprove.frmPreApprove_Load()
        frmPreApprove.Show()
        frmMain.frmMain_Load()
    End Sub

End Class