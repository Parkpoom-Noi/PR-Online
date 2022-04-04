Imports PR_Online.BLL
Imports System.Threading
Imports outlook = Microsoft.Office.Interop.Outlook
Imports System.Net
Imports System.Net.Mail
Imports System.IO

Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmMain
    Dim Bll As BLL_Load = New BLL_Load
    Dim _tStatus As Threading.Thread
    Dim StatusRun As Boolean
    Dim dtPR As New DataTable
    Dim strUser As String
    Dim strID As String
    '
    Dim dtUserData As DataTable
    Dim dtMgrData As DataTable
    Dim colStatus As Integer
    Dim colID As Integer
    Dim colName As String
    Dim colOnline As Integer
    Dim colEmail As String
    Dim colDept As String

    Dim colMgrUserID As String
    Dim colMgrName As String
    Dim colMgrEmail As String

    'Dim colGmUserID As String
    'Dim colGmname As String
    'Dim colGmEmail As String

    Dim DeptName As String

    Dim GlUserID As String
    Dim GlEmail As String
    Dim Glname As String
    '

    Dim TotalQty As Integer = 0
    Dim TotalAmount As Integer = 0

    'for attach files
    Dim strFolderPath As String = "P:/IT/PR Online Attach Files/"
    Dim dlg As New OpenFileDialog()
    'for attach files

    Public Sub frmMain_Load() Handles MyBase.Load
        tbReqDate.Format = DateTimePickerFormat.Custom
        tbReqDate.CustomFormat = "dd/MM/yyyy"

        dtPR.Columns.Clear()
        dtPR.Rows.Clear()
        dgvCreatePR.DataSource = dtPR
        dtPR.Columns.Add("Require Date")
        dtPR.Columns.Add("Recommend Supplier")
        dtPR.Columns.Add("RFQ No")
        dtPR.Columns.Add("Discription")
        dtPR.Columns.Add("Job")
        dtPR.Columns.Add("Q'ty")
        dtPR.Columns.Add("Estimate Price")
        dtPR.Columns.Add("Amount")
        dgvCreatePR.DataSource = dtPR
        dgvCreatePR.Columns(0).ReadOnly = True
        dgvCreatePR.Columns(5).ReadOnly = True
        dgvCreatePR.Columns(6).ReadOnly = True
        dgvCreatePR.Columns(7).ReadOnly = True
        dgvCreatePR.AutoSize = True
        strID = strUser
        dtUserData = Bll.GetUserData(CInt(strID))
        If dtUserData.Rows.Count > 0 Then
            For i As Integer = 0 To dtUserData.Rows.Count - 1
                colID = dtUserData.Rows(0)("user_id").ToString
                colStatus = dtUserData.Rows(0)("user_permission_pr").ToString
                colName = dtUserData.Rows(0)("user_fullname").ToString
                colOnline = dtUserData.Rows(0)("user_stOnline").ToString
                colEmail = dtUserData.Rows(0)("user_email").ToString
                colDept = dtUserData.Rows(0)("user_dept").ToString
            Next


            If TabControl1.TabPages.Count = 9 Then
                If colStatus = 1 Then 'Operators
                    TabControl1.TabPages.RemoveAt(8)
                    TabControl1.TabPages.RemoveAt(7)
                    TabControl1.TabPages.RemoveAt(6)
                    TabControl1.TabPages.RemoveAt(5)
                    TabControl1.TabPages.RemoveAt(4)
                    TabControl1.TabPages.RemoveAt(3)

                    dgvMyPr.DataSource = Bll.GetMyPrOnline(colID)
                    dgvMyPr.Columns(0).Visible = False
                    dgvMyComp.DataSource = Bll.GetMyCompPrOnline(colID)
                    dgvMyComp.Columns(0).Visible = False

                ElseIf colStatus = 2 Then 'Mgr. Approve
                    TabControl1.TabPages.RemoveAt(7)
                    TabControl1.TabPages.RemoveAt(6)
                    TabControl1.TabPages.RemoveAt(5)

                    dgvMyPr.DataSource = Bll.GetMyPrOnline(colID)
                    dgvMyPr.Columns(0).Visible = False
                    dgvMyComp.DataSource = Bll.GetMyCompPrOnline(colID)
                    dgvMyComp.Columns(0).Visible = False

                    dgvMyApprovePR.DataSource = Bll.GetMyApprovePR(colID)
                    dgvMyApprovePR.Columns(0).Visible = False
                    dgvMyApproved.DataSource = Bll.GetMyApproved(colID)
                    dgvMyApproved.Columns(0).Visible = False

                ElseIf colStatus = 3 Then 'SC Dept.
                    TabControl1.TabPages.RemoveAt(7)
                    TabControl1.TabPages.RemoveAt(4)
                    TabControl1.TabPages.RemoveAt(3)

                    dgvMyPr.DataSource = Bll.GetMyPrOnline(colID)
                    dgvMyPr.Columns(0).Visible = False
                    dgvMyComp.DataSource = Bll.GetMyCompPrOnline(colID)
                    dgvMyComp.Columns(0).Visible = False

                    dgvPurchase.DataSource = Bll.GetMyPrAssign(colID)
                    dgvPurchase.Columns(0).Visible = False
                    dgvCompPrJob.DataSource = Bll.GetMyCompJob(colID)
                    dgvCompPrJob.Columns(0).Visible = False

                    dgvAllPr.DataSource = Bll.GetAllPR()
                    dgvAllPr.Columns(0).Visible = False

                ElseIf colStatus = 4 Then 'SC Mgr.
                    dgvMyPr.DataSource = Bll.GetMyPrOnline(colID)
                    dgvMyPr.Columns(0).Visible = False
                    dgvMyComp.DataSource = Bll.GetMyCompPrOnline(colID)
                    dgvMyComp.Columns(0).Visible = False

                    dgvMyApprovePR.DataSource = Bll.GetMyApprovePR(colID)
                    dgvMyApprovePR.Columns(0).Visible = False
                    dgvMyApproved.DataSource = Bll.GetMyApproved(colID)
                    dgvMyApproved.Columns(0).Visible = False

                    dgvPurchase.DataSource = Bll.GetMyPrAssign(colID)
                    dgvPurchase.Columns(0).Visible = False
                    dgvCompPrJob.DataSource = Bll.GetMyCompJob(colID)
                    dgvCompPrJob.Columns(0).Visible = False

                    dgvScMgr.DataSource = Bll.GetAssignPR(colID)
                    dgvScMgr.Columns(0).Visible = False
                    dgvAllPr.DataSource = Bll.GetAllPR()
                    dgvAllPr.Columns(0).Visible = False

                End If
            Else

                If colStatus = 1 Then 'Operators 

                    dgvMyPr.DataSource = Bll.GetMyPrOnline(colID)
                    dgvMyPr.Columns(0).Visible = False
                    dgvMyComp.DataSource = Bll.GetMyCompPrOnline(colID)
                    dgvMyComp.Columns(0).Visible = False

                ElseIf colStatus = 2 Then 'Mgr. Approve 

                    dgvMyPr.DataSource = Bll.GetMyPrOnline(colID)
                    dgvMyPr.Columns(0).Visible = False
                    dgvMyComp.DataSource = Bll.GetMyCompPrOnline(colID)
                    dgvMyComp.Columns(0).Visible = False

                    dgvMyApprovePR.DataSource = Bll.GetMyApprovePR(colID)
                    dgvMyApprovePR.Columns(0).Visible = False
                    dgvMyApproved.DataSource = Bll.GetMyApproved(colID)
                    dgvMyApproved.Columns(0).Visible = False

                    dgvAllPr.DataSource = Bll.GetAllPR()
                    dgvAllPr.Columns(0).Visible = False
                ElseIf colStatus = 3 Then 'SC Dept. 

                    dgvMyPr.DataSource = Bll.GetMyPrOnline(colID)
                    dgvMyPr.Columns(0).Visible = False
                    dgvMyComp.DataSource = Bll.GetMyCompPrOnline(colID)
                    dgvMyComp.Columns(0).Visible = False

                    dgvPurchase.DataSource = Bll.GetMyPrAssign(colID)
                    dgvPurchase.Columns(0).Visible = False
                    dgvCompPrJob.DataSource = Bll.GetMyCompJob(colID)
                    dgvCompPrJob.Columns(0).Visible = False

                    dgvAllPr.DataSource = Bll.GetAllPR()
                    dgvAllPr.Columns(0).Visible = False

                ElseIf colStatus = 4 Then 'SC Mgr.
                    dgvMyPr.DataSource = Bll.GetMyPrOnline(colID)
                    dgvMyPr.Columns(0).Visible = False
                    dgvMyComp.DataSource = Bll.GetMyCompPrOnline(colID)
                    dgvMyComp.Columns(0).Visible = False

                    dgvMyApprovePR.DataSource = Bll.GetMyApprovePR(colID)
                    dgvMyApprovePR.Columns(0).Visible = False
                    dgvMyApproved.DataSource = Bll.GetMyApproved(colID)
                    dgvMyApproved.Columns(0).Visible = False

                    dgvPurchase.DataSource = Bll.GetMyPrAssign(colID)
                    dgvPurchase.Columns(0).Visible = False
                    dgvCompPrJob.DataSource = Bll.GetMyCompJob(colID)
                    dgvCompPrJob.Columns(0).Visible = False

                    dgvScMgr.DataSource = Bll.GetAssignPR(colID)
                    dgvScMgr.Columns(0).Visible = False
                    dgvAllPr.DataSource = Bll.GetAllPR()
                    dgvAllPr.Columns(0).Visible = False

                End If


            End If

            dtMgrData = Bll.GetMgrData(CInt(colDept))
            If dtMgrData.Rows.Count > 0 Then
                For i As Integer = 0 To dtMgrData.Rows.Count - 1
                    colMgrUserID = dtMgrData.Rows(0)("user_id")
                    colMgrName = dtMgrData.Rows(0)("dept_mgrName").ToString
                    colMgrEmail = dtMgrData.Rows(0)("dept_mgrEmail").ToString
                    DeptName = dtMgrData.Rows(0)("dept_name").ToString
                Next
            End If

        End If
        Me.lb_name.Text = colName
        Me.tb_id.Text = colID
        tbDept.Text = DeptName
        GetDataGlCode()
        'other Tab 

        ' 
        _tStatus = New Threading.Thread(AddressOf Run)
        _tStatus.IsBackground = True
        _tStatus.Start()
    End Sub
#Region "All Sub and Function"

    Public Property _strUser() As String
        Get
            Return strUser
        End Get
        Set(ByVal value As String)
            strUser = value
        End Set
    End Property
    Public Sub GetDataGlCode()
        Dim dt_GlAcc As DataTable
        Dim A As String

        Dim col As New AutoCompleteStringCollection
        dt_GlAcc = Bll.GetGlData("")
        For i As Integer = 0 To dt_GlAcc.Rows.Count - 1
            col.Add(dt_GlAcc.Rows(i)("gl_code").ToString())
            A = dt_GlAcc.Rows(i)("gl_code").ToString()
        Next
        tbGlAc.AutoCompleteSource = AutoCompleteSource.CustomSource
        tbGlAc.AutoCompleteCustomSource = col
        tbGlAc.AutoCompleteMode = AutoCompleteMode.Suggest


    End Sub
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

                Dim StatusClose As Integer = Bll.GetStatusClose()
                If StatusClose = 1 And colID <> "1" Then
                    Application.Exit()
                End If

                Threading.Thread.Sleep(3000)
                btnStatus.BackColor = Color.Gainsboro
                btnStatus.ForeColor = Color.Black
            Catch ex As Exception

            End Try
        End While
    End Sub


#End Region
    '
    '
    '
    '
    '
    '
    '
#Region "Tab Create PR Online"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If tbDept.Text = "" Or tbReqDate.Text = "" Or tbDisc.Text = "" _
            Or tbGlAc.Text = "" Or tbGlDe.Text = "" Or tbJob.Text = "" Or tbQty.Text = "" Or tbPrice.Text = "" Or tbAmount.Text = "" Then

            If tbDept.Text = "" Then
                MsgBox("Please insert Data to Requested from Dept!", MsgBoxStyle.Critical, "Requested from Dept!")
            ElseIf tbReqDate.Text = "" Then
                MsgBox("Please insert Data to Require Date / วันที่ต้องการ!", MsgBoxStyle.Critical, "Require Date / วันที่ต้องการ!")
            ElseIf tbDisc.Text = "" Then
                MsgBox("Please insert Data to Discription / รายการสินค้า!", MsgBoxStyle.Critical, "Discription / รายการสินค้า!")
            ElseIf tbGlAc.Text = "" Then
                MsgBox("Please insert Data to GL. Account / รหัสสินค้า!", MsgBoxStyle.Critical, "GL. Account / รหัสสินค้า!")
            ElseIf tbGlDe.Text = "" Then
                MsgBox("Please insert Data to GL. Detail / รายละเอียดรหัส!", MsgBoxStyle.Critical, "GL. Detail / รายละเอียดรหัส!")
            ElseIf tbJob.Text = "" Then
                MsgBox("Please insert Data to Job / การใช้งาน!", MsgBoxStyle.Critical, "Job / การใช้งาน!")
            ElseIf tbQty.Text = "" Then
                MsgBox("Please insert Data to Q'ty / จำนวน!", MsgBoxStyle.Critical, "Q'ty / จำนวน!")
            ElseIf tbPrice.Text = "" Then
                MsgBox("Please insert Data to Estimate Price / ราคาต่อหน่วย!", MsgBoxStyle.Critical, "Estimate Price / ราคาต่อหน่วย!")
            ElseIf tbAmount.Text = "" Then
                MsgBox("Please insert Data to Amount / จำนวนเงิน!", MsgBoxStyle.Critical, "Amount / จำนวนเงิน!")
            End If

        Else
            dtPR.Rows.Add(tbReqDate.Text, tbSupplier.Text, tbRfq.Text, tbDisc.Text, tbJob.Text, tbQty.Text, tbPrice.Text, tbAmount.Text) 'Recomend Supplier
            dgvCreatePR.DataSource = dtPR


        End If
        TotalQty = 0
        TotalAmount = 0
        If dgvCreatePR.RowCount > 0 Then
            'if you have the other column to get the result you  could add a new one like these above 

            For index As Integer = 0 To dgvCreatePR.RowCount - 1
                TotalQty += Convert.ToInt32(dgvCreatePR.Rows(index).Cells(5).Value)
                TotalAmount += Convert.ToInt32(dgvCreatePR.Rows(index).Cells(7).Value)
                'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
            Next
            lbTotalQty.Text = "Total Q'ty : " & TotalQty
            lbTotalAmount.Text = "Total Amount : " & TotalAmount

            'if you have the other column to get the result you  could add a new one like these above 
        End If
    End Sub
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        For Each row As DataGridViewRow In dgvCreatePR.SelectedRows
            dgvCreatePR.Rows.Remove(row)
        Next

        TotalQty = 0
        TotalAmount = 0
        If dgvCreatePR.RowCount > 0 Then
            'if you have the other column to get the result you  could add a new one like these above 
            For index As Integer = 0 To dgvCreatePR.RowCount - 1
                TotalQty += Convert.ToInt32(dgvCreatePR.Rows(index).Cells(5).Value)
                TotalAmount += Convert.ToInt32(dgvCreatePR.Rows(index).Cells(7).Value)
                'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
            Next
            lbTotalQty.Text = "Total Q'ty : " & TotalQty
            lbTotalAmount.Text = "Total Amount : " & TotalAmount

            'if you have the other column to get the result you  could add a new one like these above 
        End If
    End Sub
    Private Sub btnGen_Click(sender As Object, e As EventArgs) Handles btnGen.Click
        If dgvCreatePR.Rows.Count > 0 Then
            If MsgBox("Are you confirm data ?", MsgBoxStyle.YesNo, "Confirm Data") = MsgBoxResult.Yes Then
                '***********************InsertTagPR******************************'  
                Dim ChkNo As Integer = 0
                If (rbCER1.Checked = True And Trim(tbCERtxt.Text) = "") Or (rbCER3.Checked = True And Trim(tbCERtxt.Text) = "") Then
                    MsgBox("Please add CER No.!", MsgBoxStyle.Critical, "Please add CER No.")
                    Exit Sub
                End If

                Dim pr_ol_tag As String = Bll.GetPROnlineTag() 'Format is PR-yyMMxxx (xxx is no. of pr in month and reset every month)

                Dim pr_ol_dept As String = tbDept.Text
                Dim pr_ol_req_by As String = colName
                Dim pr_ol_req_byID As Integer = colID
                Dim pr_ol_req_email As String = colEmail

                Dim pr_ol_req_mgrID As Integer = colMgrUserID
                Dim pr_ol_req_mgrName As String = colMgrName
                Dim pr_ol_req_mgrEmail As String = colMgrEmail

                Dim pr_ol_gmID As Integer
                Dim pr_ol_gmName As String
                Dim pr_ol_gmEmail As String
                Dim pr_ol_gmStatus As Integer = 5
                Dim dtGmData As DataTable
                If TotalAmount > 10000 Then
                    dtGmData = Bll.GetApproveData("GM")
                    If dtGmData.Rows.Count > 0 Then
                        For i As Integer = 0 To dtGmData.Rows.Count - 1
                            pr_ol_gmID = dtGmData.Rows(0)("user_id")
                            pr_ol_gmName = dtGmData.Rows(0)("dept_mgrName").ToString
                            pr_ol_gmEmail = dtGmData.Rows(0)("dept_mgrEmail").ToString
                            pr_ol_gmStatus = 0
                        Next
                    End If
                End If


                Dim pr_ol_assignEmail As String = "" ' Check Need or not ? 

                Dim pr_ol_scMgrID As Integer
                Dim pr_ol_scMgr_name As String
                Dim pr_ol_scMgr_email As String
                Dim pr_ol_scMgr_status As Integer
                Dim dtScData As DataTable
                dtScData = Bll.GetApproveData("SupplyChain")
                If dtScData.Rows.Count > 0 Then
                    For i As Integer = 0 To dtScData.Rows.Count - 1
                        pr_ol_scMgrID = dtScData.Rows(0)("user_id")
                        pr_ol_scMgr_name = dtScData.Rows(0)("dept_mgrName").ToString
                        pr_ol_scMgr_email = dtScData.Rows(0)("dept_mgrEmail").ToString
                        pr_ol_scMgr_status = 0
                    Next
                End If

                Dim pr_ol_logOpen_ip As String = Bll.GetIPAddress()

                Dim pr_ol_attachFile As String
                If Trim(tbPathUpload.Text) <> "" Then
                    pr_ol_attachFile = pr_ol_tag & ".pdf" 'Rename to PR TAG ID
                Else
                    pr_ol_attachFile = ""
                End If

                '***********************InsertTagPR******************************'     

                Dim pr_ol_GlAccount As String = tbGlAc.Text
                Dim pr_ol_GlDetail As String = tbGlDe.Text
                Dim pr_ol_GlUserID As String = GlUserID
                Dim pr_ol_GlName As String = Glname
                Dim pr_ol_GlEmail As String = GlEmail

                Dim UrgentStatus As Integer = 3
                If pr_ol_req_byID = 1 Then

                    pr_ol_req_mgrID = 1
                    pr_ol_req_mgrName = "Admin admin"
                    pr_ol_req_mgrEmail = "parkpoom@airradiators.co.th"

                    pr_ol_gmID = 0
                    pr_ol_gmName = "Admin admin"
                    pr_ol_gmEmail = "parkpoom@airradiators.co.th"

                    pr_ol_GlUserID = 1
                    pr_ol_GlName = "Admin admin"
                    pr_ol_GlEmail = "parkpoom@airradiators.co.th"

                    pr_ol_scMgrID = 1
                    pr_ol_scMgr_name = "Admin admin"
                    pr_ol_scMgr_email = "parkpoom@airradiators.co.th"


                End If
                Dim pr_ol_CerNo As String
                Dim pr_ol_Plants As String
                Dim pr_ol_type As Integer

                If rbART1.Checked = True Then
                    pr_ol_Plants = "ART1"
                Else
                    pr_ol_Plants = "ART3"
                End If

                If rbPRnoCER.Checked = True Then
                    pr_ol_type = 1
                    pr_ol_CerNo = ""
                ElseIf rbASTnoCER.Checked = True Then
                    pr_ol_type = 2
                    pr_ol_CerNo = ""

                ElseIf rbMat.Checked = True Then
                    pr_ol_type = 5
                    pr_ol_CerNo = ""
                ElseIf rbCER1.Checked = True Then
                    pr_ol_type = 3
                    pr_ol_CerNo = Trim(tbCERtxt.Text)
                Else
                    pr_ol_type = 4
                    pr_ol_CerNo = Trim(tbCERtxt.Text)
                End If


                If Bll.InsertTagPR(pr_ol_tag, pr_ol_dept, pr_ol_req_by, pr_ol_req_email, pr_ol_req_mgrName,
                                   pr_ol_req_mgrEmail, pr_ol_gmName, pr_ol_gmEmail,
                                   pr_ol_assignEmail, pr_ol_scMgr_name, pr_ol_scMgr_email, pr_ol_logOpen_ip, pr_ol_attachFile, pr_ol_req_byID,
                                   pr_ol_req_mgrID, pr_ol_gmID, pr_ol_scMgrID, pr_ol_GlAccount, pr_ol_GlDetail, pr_ol_GlUserID, pr_ol_GlName,
                                   pr_ol_GlEmail, pr_ol_gmStatus, pr_ol_scMgr_status,
                                   pr_ol_CerNo, pr_ol_Plants, pr_ol_type) Then 'Insert TAG

                    For i As Integer = 0 To dgvCreatePR.Rows.Count - 1
                        'dgvCreatePR.Rows(i)
                        '************************InsertItemPR*****************************' 
                        Dim pr_item_reqDate As String = dgvCreatePR.Rows(i).Cells(0).Value
                        Dim pr_item_suppiler As String = IIf(IsDBNull(dgvCreatePR.Rows(i).Cells(1).Value), "", (dgvCreatePR.Rows(i).Cells(1).Value))
                        Dim pr_item_rfq As String = IIf(IsDBNull(dgvCreatePR.Rows(i).Cells(2).Value), "", (dgvCreatePR.Rows(i).Cells(2).Value))
                        Dim pr_item_detail As String = IIf(IsDBNull(dgvCreatePR.Rows(i).Cells(3).Value), "", (dgvCreatePR.Rows(i).Cells(3).Value))
                        Dim pr_item_job As String = IIf(IsDBNull(dgvCreatePR.Rows(i).Cells(4).Value), "", (dgvCreatePR.Rows(i).Cells(4).Value))
                        Dim pr_item_qty As String = IIf(IsDBNull(dgvCreatePR.Rows(i).Cells(5).Value), "", (dgvCreatePR.Rows(i).Cells(5).Value))
                        Dim pr_item_unitPrice As String = IIf(IsDBNull(dgvCreatePR.Rows(i).Cells(6).Value), "", (dgvCreatePR.Rows(i).Cells(6).Value))
                        Dim pr_item_amount As String = IIf(IsDBNull(dgvCreatePR.Rows(i).Cells(7).Value), "", (dgvCreatePR.Rows(i).Cells(7).Value))


                        Dim pr_item_logOpen_ip As String = Bll.GetIPAddress()

                        '***********************InsertItemPR******************************'  
                        If Bll.InsertItemPR(pr_ol_tag, pr_item_reqDate, pr_item_detail, pr_item_job, pr_item_qty, pr_item_unitPrice,
                                  pr_item_amount, pr_item_logOpen_ip, pr_item_suppiler, pr_item_rfq) Then  'Insert ITEM

                            ChkNo = ChkNo + 1
                        Else


                            MsgBox("Create Item PR Online not complete!", MsgBoxStyle.Information, "Not complete!")

                            Bll.DeleteTagPR(pr_ol_tag, CInt(pr_ol_req_byID))
                            If ChkNo <> 0 Then
                                Bll.DeleteItemPR(pr_ol_tag, CInt(pr_ol_req_byID))
                            End If

                        End If
                    Next

                    Dim PrFile As String
                    If ChkNo = dgvCreatePR.Rows.Count Then
                        If tbPathUpload.Text <> "" Then
                            Dim filePath As String = dlg.FileName
                            'Dim NameTo As String = Path.Combine(strFolderPath, fileName) 
                            File.Copy(filePath, Path.Combine(strFolderPath, pr_ol_attachFile), True)

                            ''*** Save File 
                            If Trim(tbPathUpload.Text) = "" Then
                                PrFile = ""
                            Else
                                PrFile = pr_ol_tag
                            End If
                        End If
                        MsgBox("Create PR Online complete!", MsgBoxStyle.Information, "Complete!")
                        If Bll.AlertEmail(pr_ol_tag, colMgrEmail, colName, colMgrName, "ReqMgr", UrgentStatus) Then

                            MsgBox("Send Email PR Online complete!", MsgBoxStyle.Information, "Complete!")
                            tbSupplier.Text = ""
                            tbRfq.Text = ""
                            tbGlAc.Text = ""
                            tbGlDe.Text = ""
                            tbQty.Text = ""
                            tbPrice.Text = ""
                            tbPathUpload.Text = ""
                            tbDisc.Text = ""
                            tbJob.Text = ""
                            lbGlOwner.Text = "GL Owner : -"
                            frmMain_Load()
                        Else
                            MsgBox("Send Email PR Online not complete!", MsgBoxStyle.Information, "Not Complete!")
                            tbSupplier.Text = ""
                            tbRfq.Text = ""
                            tbGlAc.Text = ""
                            tbGlDe.Text = ""
                            tbQty.Text = ""
                            tbPrice.Text = ""
                            tbPathUpload.Text = ""
                            tbDisc.Text = ""
                            tbJob.Text = ""
                            lbGlOwner.Text = "GL Owner : -"
                            Bll.DeleteTagPR(pr_ol_tag, CInt(pr_ol_req_byID))
                            Bll.DeleteItemPR(pr_ol_tag, CInt(pr_ol_req_byID))
                            frmMain_Load()
                        End If
                    Else

                    End If
                    ''*** Save File

                Else

                    MsgBox("Create Tag PR Online not complete!", MsgBoxStyle.Information, "Not complete!")
                End If

            End If

        Else
            MsgBox("Please key Item into PR before generate!", MsgBoxStyle.Critical, "Check Item!")
        End If

    End Sub
    Private Sub tbGlAc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbGlAc.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If



    End Sub
    Private Sub tbGlAc_TextChanged(sender As Object, e As EventArgs) Handles tbGlAc.TextChanged
        If Trim(tbGlAc.TextLength) = 11 Then
            Dim dt_GlDeail As DataTable
            dt_GlDeail = Bll.GetGlData("Where  A1.[gl_code] =  '" & Trim(tbGlAc.Text) & "'")
            If dt_GlDeail.Rows.Count > 0 Then
                For i As Integer = 0 To dt_GlDeail.Rows.Count - 1
                    tbGlDe.Text = dt_GlDeail.Rows(i)("gl_detail").ToString()
                    lbGlOwner.Text = "GL Owner : " & dt_GlDeail.Rows(i)("gl_mgr").ToString()
                    GlUserID = dt_GlDeail.Rows(i)("user_id")
                    Glname = dt_GlDeail.Rows(i)("gl_mgr").ToString()
                    GlEmail = Trim(dt_GlDeail.Rows(i)("gl_email").ToString())
                Next
            End If
        Else
            tbGlDe.Text = ""
            lbGlOwner.Text = "GL Owner : -"
            Glname = ""
            GlEmail = ""
        End If
    End Sub
    Private Sub tbAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbAmount.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub tbPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPrice.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub tbQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQty.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub tbPathUpload_Click(sender As Object, e As EventArgs) Handles tbPathUpload.Click
        dlg.Filter = "Pdf Only|*.pdf"
        If dlg.ShowDialog() = DialogResult.OK Then
            ''*** Create Folder
            If Not Directory.Exists(strFolderPath) Then
                Directory.CreateDirectory(strFolderPath)
            End If
            tbPathUpload.Text = dlg.FileName


        End If

    End Sub
    Private Sub tbPrice_TextChanged(sender As Object, e As EventArgs) Handles tbPrice.TextChanged
        If tbPrice.Text <> "" And tbQty.Text <> "" Then
            tbAmount.Text = CInt(tbPrice.Text) * CInt(tbQty.Text)
        Else
            tbAmount.Text = ""
        End If

    End Sub
    Private Sub tbQty_TextChanged(sender As Object, e As EventArgs) Handles tbQty.TextChanged
        If tbPrice.Text <> "" And tbQty.Text <> "" Then
            tbAmount.Text = CInt(tbPrice.Text) * CInt(tbQty.Text)
        Else
            tbAmount.Text = ""
        End If
    End Sub


#End Region
    '
    '
    '
    '
    '
    '
    '
#Region "My PR Online"

    Private Sub dgvMyPr_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMyPr.CellMouseDoubleClick
        ' If dgvMyPr.CurrentCell.RowIndex = 0 Then Exit Sub
        Try

            Dim TagID As String = dgvMyPr.Rows(e.RowIndex).Cells(0).Value.ToString

            frmPreviews._strPr = TagID.ToString '
            frmPreviews.Show()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Private Sub dgvMyApprovePR_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMyApprovePR.CellMouseDoubleClick
        Try


            frmPreApprove._strPr = "" '
            frmPreApprove._strUser = "" '
            frmPreApprove._strTypeBtn = "" '
            Dim TagID As String = dgvMyApprovePR.Rows(e.RowIndex).Cells(0).Value.ToString
            Dim strTypeBtnID As String = "MgrApp" '
            frmPreApprove._strPr = TagID.ToString '
            frmPreApprove._strUser = strID.ToString '
            frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
            frmPreApprove.Show()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub dgvMyApproved_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMyApproved.CellMouseDoubleClick
        Try

            Dim TagID As String = ""
        frmPreApprove._strPr = "" '
        frmPreApprove._strUser = "" '
        frmPreApprove._strTypeBtn = "" '
        TagID = dgvMyApproved.Rows(e.RowIndex).Cells(0).Value.ToString
        Dim strTypeBtnID As String = "MgrNonApp" '
        frmPreApprove._strPr = TagID.ToString '
        frmPreApprove._strUser = strID.ToString '
        frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
            frmPreApprove.Show()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub dgvPurchase_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPurchase.CellMouseDoubleClick
        Try
            frmPreApprove._strPr = "" '
        frmPreApprove._strUser = "" '
        frmPreApprove._strTypeBtn = "" '
        Dim TagID As String = dgvPurchase.Rows(e.RowIndex).Cells(0).Value.ToString
        Dim strTypeBtnID As String = "Purchase" '
        frmPreApprove._strPr = TagID.ToString '
        frmPreApprove._strUser = strID.ToString '
        frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
            frmPreApprove.Show()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub dgvScMgr_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvScMgr.CellMouseDoubleClick
        Try
            frmPreApprove._strPr = "" '
        frmPreApprove._strUser = "" '
        frmPreApprove._strTypeBtn = "" '
        Dim TagID As String = dgvScMgr.Rows(e.RowIndex).Cells(0).Value.ToString
        Dim strTypeBtnID As String = "ScMgr" '
        frmPreApprove._strPr = TagID.ToString '
        frmPreApprove._strUser = strID.ToString '
        frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
            frmPreApprove.Show()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub tbSupplier_DoubleClick(sender As Object, e As EventArgs) Handles tbSupplier.DoubleClick, tbRfq.DoubleClick, tbQty.DoubleClick, tbPrice.DoubleClick, tbJob.DoubleClick, tbDisc.DoubleClick
        sender.text = ""

    End Sub

    Private Sub dgvCompPrJob_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCompPrJob.CellMouseDoubleClick
        Try
            frmPreApprove._strPr = "" '
        frmPreApprove._strUser = "" '
        frmPreApprove._strTypeBtn = "" '
        Dim TagID As String = dgvCompPrJob.Rows(e.RowIndex).Cells(0).Value.ToString
        Dim strTypeBtnID As String = "MgrNonApp" '
        frmPreApprove._strPr = TagID.ToString '
        frmPreApprove._strUser = strID.ToString '
        frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
            frmPreApprove.Show()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub dgvAllPr_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAllPr.CellMouseDoubleClick
        Try
            frmPreApprove._strPr = "" '
        frmPreApprove._strUser = "" '
        frmPreApprove._strTypeBtn = "" '
        Dim TagID As String = dgvAllPr.Rows(e.RowIndex).Cells(0).Value.ToString
        Dim strTypeBtnID As String = "MgrNonApp" '
        frmPreApprove._strPr = TagID.ToString '
        frmPreApprove._strUser = strID.ToString '
        frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
            frmPreApprove.Show()
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub dgvMyComp_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMyComp.CellMouseDoubleClick
        Try
            frmPreApprove._strPr = "" '
        frmPreApprove._strUser = "" '
        frmPreApprove._strTypeBtn = "" '
        Dim TagID As String = dgvMyComp.Rows(e.RowIndex).Cells(0).Value.ToString
        Dim strTypeBtnID As String = "MgrNonApp" '
        frmPreApprove._strPr = TagID.ToString '
        frmPreApprove._strUser = strID.ToString '
        frmPreApprove._strTypeBtn = strTypeBtnID.ToString '
            frmPreApprove.Show()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Bll.UnlockLogin(CInt(colID))
        Application.Exit()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        frmChangePass._strUser = colID.ToString
        frmChangePass.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Bll.UnlockLogin(CInt(colID))
        Application.Exit()
    End Sub
    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem

        Select Case e.Index
            Case 0
                Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
                Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
                Dim FillBrush As New SolidBrush(Color.Blue)
                Dim TextBrush As New SolidBrush(Color.White)
                Dim sf As New StringFormat
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                If CBool(e.State And DrawItemState.Selected) Then
                    FillBrush.Color = Color.White
                    TextBrush.Color = Color.Blue
                    ItemRect.Inflate(2, 2)
                End If

                If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                    Dim RotateAngle As Single = 90
                    If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                    Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                    e.Graphics.TranslateTransform(cp.X, cp.Y)
                    e.Graphics.RotateTransform(RotateAngle)
                    ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
                End If

                e.Graphics.FillRectangle(FillBrush, ItemRect)

                e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

                e.Graphics.ResetTransform()

                FillBrush.Dispose()
                TextBrush.Dispose()

            Case 1
                Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
                Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
                Dim FillBrush As New SolidBrush(Color.OrangeRed)
                Dim TextBrush As New SolidBrush(Color.White)
                Dim sf As New StringFormat
                'e.Graphics.FillRectangle(New SolidBrush(Color.LightCoral), e.Bounds)
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                'If we are currently painting the Selected TabItem we'll 
                'change the brush colors and inflate the rectangle.
                If CBool(e.State And DrawItemState.Selected) Then
                    FillBrush.Color = Color.White
                    TextBrush.Color = Color.OrangeRed
                    ItemRect.Inflate(2, 2)
                End If

                'Set up rotation for left and right aligned tabs
                If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                    Dim RotateAngle As Single = 90
                    If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                    Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                    e.Graphics.TranslateTransform(cp.X, cp.Y)
                    e.Graphics.RotateTransform(RotateAngle)
                    ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
                End If

                'Next we'll paint the TabItem with our Fill Brush
                e.Graphics.FillRectangle(FillBrush, ItemRect)

                'Now draw the text.
                e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

                'Reset any Graphics rotation
                e.Graphics.ResetTransform()

                'Finally, we should Dispose of our brushes.
                FillBrush.Dispose()
                TextBrush.Dispose()
            Case 2
                Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
                Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
                Dim FillBrush As New SolidBrush(Color.DarkMagenta)
                Dim TextBrush As New SolidBrush(Color.White)
                Dim sf As New StringFormat
                'e.Graphics.FillRectangle(New SolidBrush(Color.LightCyan), e.Bounds)
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                'If we are currently painting the Selected TabItem we'll 
                'change the brush colors and inflate the rectangle.
                If CBool(e.State And DrawItemState.Selected) Then
                    FillBrush.Color = Color.White
                    TextBrush.Color = Color.DarkMagenta
                    ItemRect.Inflate(2, 2)
                End If

                'Set up rotation for left and right aligned tabs
                If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                    Dim RotateAngle As Single = 90
                    If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                    Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                    e.Graphics.TranslateTransform(cp.X, cp.Y)
                    e.Graphics.RotateTransform(RotateAngle)
                    ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
                End If

                'Next we'll paint the TabItem with our Fill Brush
                e.Graphics.FillRectangle(FillBrush, ItemRect)

                'Now draw the text.
                e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

                'Reset any Graphics rotation
                e.Graphics.ResetTransform()

                'Finally, we should Dispose of our brushes.
                FillBrush.Dispose()
                TextBrush.Dispose()
            Case 3
                Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
                Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
                Dim FillBrush As New SolidBrush(Color.Green)
                Dim TextBrush As New SolidBrush(Color.White)
                Dim sf As New StringFormat
                'e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), e.Bounds)
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                'If we are currently painting the Selected TabItem we'll 
                'change the brush colors and inflate the rectangle.
                If CBool(e.State And DrawItemState.Selected) Then
                    FillBrush.Color = Color.White
                    TextBrush.Color = Color.Green
                    ItemRect.Inflate(2, 2)
                End If

                'Set up rotation for left and right aligned tabs
                If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                    Dim RotateAngle As Single = 90
                    If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                    Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                    e.Graphics.TranslateTransform(cp.X, cp.Y)
                    e.Graphics.RotateTransform(RotateAngle)
                    ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
                End If

                'Next we'll paint the TabItem with our Fill Brush
                e.Graphics.FillRectangle(FillBrush, ItemRect)

                'Now draw the text.
                e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

                'Reset any Graphics rotation
                e.Graphics.ResetTransform()

                'Finally, we should Dispose of our brushes.
                FillBrush.Dispose()
                TextBrush.Dispose()
            Case 4
                Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
                Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
                Dim FillBrush As New SolidBrush(Color.DeepPink)
                Dim TextBrush As New SolidBrush(Color.White)
                Dim sf As New StringFormat
                'e.Graphics.FillRectangle(New SolidBrush(Color.LightBlue), e.Bounds)

                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                'If we are currently painting the Selected TabItem we'll 
                'change the brush colors and inflate the rectangle.
                If CBool(e.State And DrawItemState.Selected) Then
                    FillBrush.Color = Color.White
                    TextBrush.Color = Color.DeepPink
                    ItemRect.Inflate(2, 2)
                End If

                'Set up rotation for left and right aligned tabs
                If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                    Dim RotateAngle As Single = 90
                    If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                    Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                    e.Graphics.TranslateTransform(cp.X, cp.Y)
                    e.Graphics.RotateTransform(RotateAngle)
                    ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
                End If

                'Next we'll paint the TabItem with our Fill Brush
                e.Graphics.FillRectangle(FillBrush, ItemRect)

                'Now draw the text.
                e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

                'Reset any Graphics rotation
                e.Graphics.ResetTransform()

                'Finally, we should Dispose of our brushes.
                FillBrush.Dispose()
                TextBrush.Dispose()
            Case 5
                Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
                Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
                Dim FillBrush As New SolidBrush(Color.SaddleBrown)
                Dim TextBrush As New SolidBrush(Color.White)
                Dim sf As New StringFormat
                'e.Graphics.FillRectangle(New SolidBrush(Color.LightGreen), e.Bounds)

                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                'If we are currently painting the Selected TabItem we'll 
                'change the brush colors and inflate the rectangle.
                If CBool(e.State And DrawItemState.Selected) Then
                    FillBrush.Color = Color.White
                    TextBrush.Color = Color.SaddleBrown
                    ItemRect.Inflate(2, 2)
                End If

                'Set up rotation for left and right aligned tabs
                If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                    Dim RotateAngle As Single = 90
                    If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                    Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                    e.Graphics.TranslateTransform(cp.X, cp.Y)
                    e.Graphics.RotateTransform(RotateAngle)
                    ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
                End If

                'Next we'll paint the TabItem with our Fill Brush
                e.Graphics.FillRectangle(FillBrush, ItemRect)

                'Now draw the text.
                e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

                'Reset any Graphics rotation
                e.Graphics.ResetTransform()

                'Finally, we should Dispose of our brushes.
                FillBrush.Dispose()
                TextBrush.Dispose()
            Case 6
                Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
                Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
                Dim FillBrush As New SolidBrush(Color.Teal)
                Dim TextBrush As New SolidBrush(Color.White)
                Dim sf As New StringFormat
                ' e.Graphics.FillRectangle(New SolidBrush(Color.LightSalmon), e.Bounds)

                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                'If we are currently painting the Selected TabItem we'll 
                'change the brush colors and inflate the rectangle.
                If CBool(e.State And DrawItemState.Selected) Then
                    FillBrush.Color = Color.White
                    TextBrush.Color = Color.Teal
                    ItemRect.Inflate(2, 2)
                End If

                'Set up rotation for left and right aligned tabs
                If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                    Dim RotateAngle As Single = 90
                    If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                    Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                    e.Graphics.TranslateTransform(cp.X, cp.Y)
                    e.Graphics.RotateTransform(RotateAngle)
                    ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
                End If

                'Next we'll paint the TabItem with our Fill Brush
                e.Graphics.FillRectangle(FillBrush, ItemRect)

                'Now draw the text.
                e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

                'Reset any Graphics rotation
                e.Graphics.ResetTransform()

                'Finally, we should Dispose of our brushes.
                FillBrush.Dispose()
                TextBrush.Dispose()
            Case 7
                Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
                Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
                Dim FillBrush As New SolidBrush(Color.Navy)
                Dim TextBrush As New SolidBrush(Color.White)
                Dim sf As New StringFormat
                'e.Graphics.FillRectangle(New SolidBrush(Color.LightSkyBlue), e.Bounds)

                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                'If we are currently painting the Selected TabItem we'll 
                'change the brush colors and inflate the rectangle.
                If CBool(e.State And DrawItemState.Selected) Then
                    FillBrush.Color = Color.White
                    TextBrush.Color = Color.Navy
                    ItemRect.Inflate(2, 2)
                End If

                'Set up rotation for left and right aligned tabs
                If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                    Dim RotateAngle As Single = 90
                    If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                    Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                    e.Graphics.TranslateTransform(cp.X, cp.Y)
                    e.Graphics.RotateTransform(RotateAngle)
                    ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
                End If

                'Next we'll paint the TabItem with our Fill Brush
                e.Graphics.FillRectangle(FillBrush, ItemRect)

                'Now draw the text.
                e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

                'Reset any Graphics rotation
                e.Graphics.ResetTransform()

                'Finally, we should Dispose of our brushes.
                FillBrush.Dispose()
                TextBrush.Dispose()
            Case 8
                Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
                Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
                Dim FillBrush As New SolidBrush(Color.Red)
                Dim TextBrush As New SolidBrush(Color.White)
                Dim sf As New StringFormat
                'e.Graphics.FillRectangle(New SolidBrush(Color.LightSeaGreen), e.Bounds)

                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                'If we are currently painting the Selected TabItem we'll 
                'change the brush colors and inflate the rectangle.
                If CBool(e.State And DrawItemState.Selected) Then
                    FillBrush.Color = Color.White
                    TextBrush.Color = Color.Red
                    ItemRect.Inflate(2, 2)
                End If

                'Set up rotation for left and right aligned tabs
                If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                    Dim RotateAngle As Single = 90
                    If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                    Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                    e.Graphics.TranslateTransform(cp.X, cp.Y)
                    e.Graphics.RotateTransform(RotateAngle)
                    ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
                End If

                'Next we'll paint the TabItem with our Fill Brush
                e.Graphics.FillRectangle(FillBrush, ItemRect)

                'Now draw the text.
                e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

                'Reset any Graphics rotation
                e.Graphics.ResetTransform()

                'Finally, we should Dispose of our brushes.
                FillBrush.Dispose()
                TextBrush.Dispose()

        End Select

        Dim paddedBounds As Rectangle = e.Bounds
        paddedBounds.Inflate(-2, -2)


    End Sub

    Private Sub Label16_DoubleClick(sender As Object, e As EventArgs) Handles Label16.DoubleClick
        tbPathUpload.Text = ""
    End Sub

    Private Sub dgvCreatePR_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCreatePR.CellMouseClick

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        Dim apppath As String = ""
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        'dialog.SelectedPath = "C:\"
        dialog.Description = "Select Application Configeration Files Path"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            apppath = dialog.SelectedPath
        Else
            Exit Sub
        End If
        'Use path and name from server

        Dim excelLocation As String = apppath.ToString & "\" & DateTime.Now.ToString("yyyy-MM-dd_HHmm") & ".xlsx"

        Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        If xlApp Is Nothing Then

            MessageBox.Show("Excel is not Install.")
            Return
        End If

        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        'Header Names
        Dim columnsCount As Integer = dgvAllPr.Columns.Count
        For Each column In dgvAllPr.Columns
            xlWorkSheet.Cells(1, column.Index + 1).Value = column.Name
        Next
        'Data
        For i As Integer = 0 To dgvAllPr.Rows.Count - 1
            Dim columnIndex As Integer = 0
            Do Until columnIndex = columnsCount
                xlWorkSheet.Cells(i + 2, columnIndex + 1).Value = dgvAllPr.Item(columnIndex, i).Value
                columnIndex += 1
            Loop
        Next

        xlWorkBook.SaveAs(excelLocation)
        xlWorkBook.Close()
        xlApp.Quit()
        MessageBox.Show("Export to Excel Complete")
        System.Diagnostics.Process.Start(excelLocation)
    End Sub
#Region "Row Color"


    Private Sub dgvMyPr_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMyPr.CellFormatting
        For Each row As DataGridViewRow In dgvMyPr.Rows
            If row.Cells(3).Value = "Urgent!" Then
                row.DefaultCellStyle.BackColor = Color.Red
                row.DefaultCellStyle.ForeColor = Color.White
            Else

                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub dgvMyApprovePR_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMyApprovePR.CellFormatting
        For Each row As DataGridViewRow In dgvMyApprovePR.Rows
            If row.Cells(3).Value = "Urgent!" Then
                row.DefaultCellStyle.BackColor = Color.Red
                row.DefaultCellStyle.ForeColor = Color.White
            Else

                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub


    Private Sub dgvPurchase_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPurchase.CellFormatting
        For Each row As DataGridViewRow In dgvPurchase.Rows
            If row.Cells(3).Value = "Urgent!" Then
                row.DefaultCellStyle.BackColor = Color.Red
                row.DefaultCellStyle.ForeColor = Color.White
            Else

                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub


    Private Sub dgvScMgr_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvScMgr.CellFormatting
        For Each row As DataGridViewRow In dgvScMgr.Rows
            If row.Cells(3).Value = "Urgent!" Then
                row.DefaultCellStyle.BackColor = Color.Red
                row.DefaultCellStyle.ForeColor = Color.White
            Else

                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub btnRefesh_Click(sender As Object, e As EventArgs) Handles btnRefesh.Click
        frmMain_Load()
    End Sub

    Private Sub rbASTnoCER_CheckedChanged(sender As Object, e As EventArgs) Handles rbASTnoCER.CheckedChanged
        If rbASTnoCER.Checked = True Then
            'Checked
            tbCERtxt.Enabled = False
            tbGlAc.Text = "2599993100"
            tbGlAc.Enabled = False
            tbGlDe.Text = "BS  Capital WIP"
            lbGlOwner.Text = "GL Owner : Adchaya LAGAN"
            GlUserID = 5
            Glname = "Adchaya LAGAN"
            GlEmail = "adchaya@airradiators.co.th"
        Else
            Dim b = 0
            tbGlAc.Text = ""
            tbGlAc.Enabled = True
            tbGlDe.Text = ""
            lbGlOwner.Text = "GL Owner : -"
            Glname = ""
            GlEmail = ""
        End If
    End Sub

    Private Sub rbCER1_CheckedChanged(sender As Object, e As EventArgs) Handles rbCER1.CheckedChanged
        If rbCER1.Checked = True Then
            'Checked
            tbCERtxt.Enabled = True
            tbGlAc.Text = "2599993100"
            tbGlAc.Enabled = False
            tbGlDe.Text = "BS  Capital WIP"
            lbGlOwner.Text = "GL Owner : Adchaya LAGAN"
            GlUserID = 5
            Glname = "Adchaya LAGAN"
            GlEmail = "adchaya@airradiators.co.th"
        Else
            Dim b = 0
            tbGlAc.Text = ""
            tbGlAc.Enabled = True
            tbGlDe.Text = ""
            lbGlOwner.Text = "GL Owner : -"
            Glname = ""
            GlEmail = ""
        End If
    End Sub

    Private Sub rbCER3_CheckedChanged(sender As Object, e As EventArgs) Handles rbCER3.CheckedChanged
        If rbCER3.Checked = True Then
            'Checked
            tbCERtxt.Enabled = True
            tbGlAc.Text = "2599993100"
            tbGlAc.Enabled = False
            tbGlDe.Text = "BS  Capital WIP"
            lbGlOwner.Text = "GL Owner : Adchaya LAGAN"
            GlUserID = 5
            Glname = "Adchaya LAGAN"
            GlEmail = "adchaya@airradiators.co.th"
        Else
            Dim b = 0
            tbGlAc.Text = ""
            tbGlAc.Enabled = True
            tbGlDe.Text = ""
            lbGlOwner.Text = "GL Owner : -"
            Glname = ""
            GlEmail = ""
        End If
    End Sub

    Private Sub rbPRnoCER_CheckedChanged(sender As Object, e As EventArgs) Handles rbPRnoCER.CheckedChanged
        If rbPRnoCER.Checked = True Then

            tbCERtxt.Enabled = False
            tbGlAc.Text = ""
            tbGlAc.Enabled = True
            tbGlDe.Text = ""
            lbGlOwner.Text = "GL Owner : -"
            Glname = ""
            GlEmail = ""
        End If
    End Sub

    Private Sub rbMat_CheckedChanged(sender As Object, e As EventArgs) Handles rbMat.CheckedChanged
        If rbMat.Checked = True Then
            'Checked 
            tbCERtxt.Enabled = False
            tbGlAc.Text = "2599991200"
            tbGlAc.Enabled = False
            tbGlDe.Text = "BS  Raw Material"
            lbGlOwner.Text = "GL Owner : Kiettipoom NINLAMAI"
            GlUserID = 4
            Glname = "Kiettipoom NINLAMAI"
            GlEmail = "kiettipoom@airradiators.co.th"
        Else
            Dim b = 0
            tbGlAc.Text = ""
            tbGlAc.Enabled = True
            tbGlDe.Text = ""
            lbGlOwner.Text = "GL Owner : -"
            Glname = ""
            GlEmail = ""
        End If
    End Sub

    Private Sub rbART3_CheckedChanged(sender As Object, e As EventArgs) Handles rbART3.CheckedChanged
        If rbART3.Checked = True Then
            rbCER1.Enabled = False
            rbCER3.Enabled = True
        End If
    End Sub

    Private Sub rbART1_CheckedChanged(sender As Object, e As EventArgs) Handles rbART1.CheckedChanged
        If rbART1.Checked = True Then
            rbCER1.Enabled = True
            rbCER3.Enabled = False
        End If

    End Sub

    Private Sub rbComplete_CheckedChanged(sender As Object, e As EventArgs) Handles rbComplete.CheckedChanged
        dgvAllPr.DataSource = Bll.GetAllPR_Complete()
    End Sub

    Private Sub rbWaitPO_CheckedChanged(sender As Object, e As EventArgs) Handles rbWaitPO.CheckedChanged
        dgvAllPr.DataSource = Bll.GetAllPR_WaitPO()
    End Sub

    Private Sub rbAllPR_CheckedChanged(sender As Object, e As EventArgs) Handles rbAllPR.CheckedChanged
        dgvAllPr.DataSource = Bll.GetAllPR()
    End Sub



#End Region




#End Region
End Class
