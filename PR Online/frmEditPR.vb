Imports PR_Online.BLL
Imports System.Threading
Imports System.IO
Imports outlook = Microsoft.Office.Interop.Outlook

Public Class frmEditPR
    Dim Bll As BLL_Load = New BLL_Load
    Dim _tStatus As Threading.Thread
    Dim StatusRun As Boolean
    Dim strPr As String
    Dim strPrID As String

    Dim dtPR As New DataTable
    Dim dtTagPR As New DataTable
    Dim dtItemPR As New DataTable
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


    Dim DeptName As String
    Dim OwnerPR As Integer
    Dim PrOltag As String

    Dim TotalQty As Integer = 0
    Dim TotalAmount As Integer = 0

    'for attach files
    Dim strFolderPath As String = "P:/IT/PR Online Attach Files/"
    Dim dlg As New OpenFileDialog()
    'for attach files

    Dim GlUserID As String
    Dim GlEmail As String
    Dim Glname As String

    'For Send Email

    Dim ReqMgrEmail As String
    Dim ReqMgrname As String
    Dim ReqName As String

#Region "All Sub and Function"
    Public Property _strPr() As String
        Get
            Return strPr
        End Get
        Set(ByVal value As String)
            strPr = value
        End Set
    End Property
    Public Sub GetTagPr()
        dtTagPR = Bll.GetPrTagData(CInt(strPrID))
        If dtTagPR.Rows.Count > 0 Then
            PrOltag = Trim(dtTagPR.Rows(0)("pr_ol_tag"))
            lbPrTag.Text = "PR No. : " & Trim(dtTagPR.Rows(0)("pr_ol_tag"))
            tbDept.Text = dtTagPR.Rows(0)("pr_ol_dept")

            tbGlAc.Text = dtTagPR.Rows(0)("pr_ol_GlAccount")
            tbGlDe.Text = dtTagPR.Rows(0)("pr_ol_GlDetail")
            lbGlOwner.Text = "GL Owner : " & dtTagPR.Rows(0)("pr_ol_GlName")

            If Trim(dtTagPR.Rows(0)("pr_ol_type")) = 2 Then
                'Checked
                rbASTnoCER.Checked = True
                tbCERtxt.Enabled = False
                tbGlAc.Text = "2599993100"
                tbGlAc.Enabled = False
                tbGlDe.Text = "BS  Capital WIP"
                lbGlOwner.Text = "GL Owner : Adchaya LAGAN"
                GlUserID = 5
                Glname = "Adchaya LAGAN"
                GlEmail = "adchaya@airradiators.co.th"
            ElseIf Trim(dtTagPR.Rows(0)("pr_ol_type")) = 3 Then
                'Checked
                rbCER1.Checked = True
                tbCERtxt.Enabled = True
                tbCERtxt.Text = Trim(dtTagPR.Rows(0)("pr_ol_CerNo"))
                tbGlAc.Text = "2599993100"
                tbGlAc.Enabled = False
                tbGlDe.Text = "BS  Capital WIP"
                lbGlOwner.Text = "GL Owner : Adchaya LAGAN"
                GlUserID = 5
                Glname = "Adchaya LAGAN"
                GlEmail = "adchaya@airradiators.co.th"
            ElseIf Trim(dtTagPR.Rows(0)("pr_ol_type")) = 4 Then
                'Checked
                rbCER3.Checked = True
                tbCERtxt.Enabled = True
                tbCERtxt.Text = Trim(dtTagPR.Rows(0)("pr_ol_CerNo"))
                tbGlAc.Text = "2599993100"
                tbGlAc.Enabled = False
                tbGlDe.Text = "BS  Capital WIP"
                lbGlOwner.Text = "GL Owner : Adchaya LAGAN"
                GlUserID = 5
                Glname = "Adchaya LAGAN"
                GlEmail = "adchaya@airradiators.co.th"
            ElseIf Trim(dtTagPR.Rows(0)("pr_ol_type")) = 5 Then
                'Checked
                rbMat.Checked = True
                tbCERtxt.Enabled = False
                tbGlAc.Text = "2599991200"
                tbGlAc.Enabled = False
                tbGlDe.Text = "BS  Raw Material"
                lbGlOwner.Text = "GL Owner : Kiettipoom NINLAMAI"
                GlUserID = 4
                Glname = "Kiettipoom NINLAMAI"
                GlEmail = "kiettipoom@airradiators.co.th"

            End If

            ReqMgrEmail = dtTagPR.Rows(0)("pr_ol_req_mgrEmail")
            ReqMgrname = dtTagPR.Rows(0)("pr_ol_req_mgrName")
            ReqName = dtTagPR.Rows(0)("pr_ol_req_by")
        End If
    End Sub
    Public Sub GetItemPr()
        dtPR.Rows.Clear()
        dtItemPR.Rows.Clear()
        dgvEditPR.DataSource = dtPR

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
            dgvEditPR.DataSource = dtPR
            TotalQty = 0
            TotalAmount = 0
            'if you have the other column to get the result you  could add a new one like these above 
            For index As Integer = 0 To dgvEditPR.RowCount - 1
                TotalQty += Convert.ToInt32(dgvEditPR.Rows(index).Cells(6).Value)
                TotalAmount += Convert.ToInt32(dgvEditPR.Rows(index).Cells(8).Value)
                'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
            Next
            lbTotalQty.Text = "Total Q'ty : " & TotalQty
            lbTotalAmount.Text = "Total Amount : " & TotalAmount
            'if you have the other column to get the result you  could add a new one like these above  
        End If
        StatusEditPr()
    End Sub
    Public Sub ClearText()

        tbDisc.Text = ""
        tbJob.Text = ""
        tbQty.Text = ""
        tbPrice.Text = ""
        tbAmount.Text = ""
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

                Threading.Thread.Sleep(1000)
                btnStatus.BackColor = Color.Gainsboro
                btnStatus.ForeColor = Color.Black
            Catch ex As Exception

            End Try
        End While
    End Sub

    Public Sub StatusEditPr()
        lbStatusEdit.Text = Bll.GetStatusEditPr(CInt(lbTagID.Text))
    End Sub

#End Region


    Public Sub frmEditPR_Load() Handles MyBase.Load
        tbReqDate.Format = DateTimePickerFormat.Custom
        tbReqDate.CustomFormat = "dd/MM/yyyy"

        strPrID = strPr.ToString
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
        GetDataGlCode()
        OwnerPR = Bll.GetOwnerPR(CInt(strPrID.ToString))
        dtUserData = Bll.GetUserData(CInt(OwnerPR))
        lbTagID.Text = strPrID
        If dtUserData.Rows.Count > 0 Then
            For i As Integer = 0 To dtUserData.Rows.Count - 1
                colID = dtUserData.Rows(0)("user_id").ToString
                colStatus = dtUserData.Rows(0)("user_permission_pr").ToString
                colName = dtUserData.Rows(0)("user_fullname").ToString
                colOnline = dtUserData.Rows(0)("user_stOnline").ToString
                colEmail = dtUserData.Rows(0)("user_email").ToString
                colDept = dtUserData.Rows(0)("user_dept").ToString
            Next
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

        GetTagPr()
        GetItemPr()


        _tStatus = New Threading.Thread(AddressOf Run)
        _tStatus.IsBackground = True
        _tStatus.Start()
    End Sub

    Private Sub dgvEditPR_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEditPR.CellMouseClick
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            ClearText()
            lbItemID.Text = dgvEditPR.Rows(e.RowIndex).Cells(0).Value '
            tbReqDate.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(1).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(1).Value)
            tbSupplier.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(2).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(2).Value) '
            tbRfq.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(3).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(3).Value) '
            tbDisc.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(4).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(4).Value) '
            tbJob.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(5).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(5).Value) '
            tbQty.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(6).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(6).Value) '
            tbPrice.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(7).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(7).Value) ' 
            tbAmount.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(8).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(8).Value) ' 

        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If CInt(lbItemID.Text) <> 0 Then
            If MsgBox("Are you confirm delete data ?", MsgBoxStyle.YesNo, "Confirm delete Data") = MsgBoxResult.Yes Then


                If Bll.DeleteItemPRByID(CInt(lbItemID.Text)) And
                Bll.EditStatusPr(CInt(lbTagID.Text), 1) Then
                    MsgBox("Delete item PR Online complete!", MsgBoxStyle.Information, "Complete!")
                    GetItemPr()
                Else
                    MsgBox("Delete item PR Online Not complete!", MsgBoxStyle.Information, "Not Complete!")
                End If

            End If
            TotalQty = 0
                TotalAmount = 0
            If dgvEditPR.RowCount > 0 Then
                For index As Integer = 0 To dgvEditPR.RowCount - 1
                    TotalQty += Convert.ToInt32(dgvEditPR.Rows(index).Cells(6).Value)
                    TotalAmount += Convert.ToInt32(dgvEditPR.Rows(index).Cells(8).Value)
                Next
                lbTotalQty.Text = "Total Q'ty : " & TotalQty
                lbTotalAmount.Text = "Total Amount : " & TotalAmount
            End If

            ClearText()
        Else
            MsgBox("Please select item PR Online complete!", MsgBoxStyle.Information, "Select!")
        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim pr_ol_logOpen_ip As String = Bll.GetIPAddress()
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
            If MsgBox("Are you confirm data ?", MsgBoxStyle.YesNo, "Confirm Data") = MsgBoxResult.Yes Then

            Dim pr_item_reqDate As String = tbReqDate.Text
            Dim pr_item_detail As String = tbDisc.Text
            Dim pr_item_glAccount As String = tbGlAc.Text
            Dim pr_item_glDetail As String = tbGlDe.Text
            Dim pr_item_job As String = tbJob.Text
            Dim pr_item_qty As String = tbQty.Text
            Dim pr_item_unitPrice As String = tbPrice.Text
            Dim pr_item_amount As String = tbAmount.Text
            Dim pr_item_suppiler As String = tbSupplier.Text
            Dim pr_item_rfq As String = tbRfq.Text


            Dim pr_item_logOpen_ip As String = Bll.GetIPAddress()

            '***********************InsertItemPR******************************'  
            If Bll.InsertItemPR(PrOltag, pr_item_reqDate, pr_item_detail, pr_item_job, pr_item_qty, pr_item_unitPrice,
                              pr_item_amount, pr_item_logOpen_ip, pr_item_suppiler, pr_item_rfq) Then  'Insert ITEM


                If Trim(tbPathUpload.Text) <> "" Then
                    Dim pr_ol_attachFile As String = PrOltag & ".pdf" 'Rename to PR TAG ID  
                    Dim filePath As String = dlg.FileName
                    'Dim NameTo As String = Path.Combine(strFolderPath, fileName) 
                    File.Copy(filePath, Path.Combine(strFolderPath, pr_ol_attachFile), True)
                    ''*** Save File 

                End If
                    Bll.EditStatusPr(CInt(lbTagID.Text), 1)
                    MsgBox("Add Item PR Online complete!", MsgBoxStyle.Information, "Complete!")
                GetItemPr()


            Else
                MsgBox("Add Item PR Online not complete!", MsgBoxStyle.Information, "Not complete!")
            End If


            End If


        TotalQty = 0
        TotalAmount = 0

        If dgvEditPR.RowCount > 0 Then
            For index As Integer = 0 To dgvEditPR.RowCount - 1
                TotalQty += Convert.ToInt32(dgvEditPR.Rows(index).Cells(6).Value)
                TotalAmount += Convert.ToInt32(dgvEditPR.Rows(index).Cells(8).Value)
            Next
            lbTotalQty.Text = "Total Q'ty : " & TotalQty
            lbTotalAmount.Text = "Total Amount : " & TotalAmount
                'Dim pr_ol_gmID As Integer
                'Dim pr_ol_gmName As String = ""
                'Dim pr_ol_gmEmail As String = ""
                'Dim dtGmData As DataTable
                'If TotalAmount > 10000 Then
                '    dtGmData = Bll.GetApproveData("GM")
                '    If dtGmData.Rows.Count > 0 Then
                '        For i As Integer = 0 To dtGmData.Rows.Count - 1
                '            pr_ol_gmID = dtGmData.Rows(0)("user_id")
                '            pr_ol_gmName = dtGmData.Rows(0)("dept_mgrName").ToString
                '            pr_ol_gmEmail = dtGmData.Rows(0)("dept_mgrEmail").ToString
                '        Next
                '        Bll.EditGmPR(PrOltag, pr_ol_gmName, pr_ol_gmEmail, pr_ol_gmID, pr_ol_logOpen_ip)
                '    End If
                'End If
            End If
        End If

        Me.Refresh()
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
    Private Sub tbGlAc_TextChanged(sender As Object, e As EventArgs) Handles tbGlAc.TextChanged
        If Trim(tbGlAc.TextLength) = 10 Then
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

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

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
            If MsgBox("Are you confirm data ?", MsgBoxStyle.YesNo, "Confirm Data") = MsgBoxResult.Yes Then
                '***********************InsertTagPR******************************'  
                Dim ChkNo As Integer = 0
                If (rbCER1.Checked = True And Trim(tbCERtxt.Text) = "") Or (rbCER3.Checked = True And Trim(tbCERtxt.Text) = "") Then
                    MsgBox("Please add CER No.!", MsgBoxStyle.Critical, "Please add CER No.")
                    Exit Sub
                End If
                Dim pr_ol_gmID As Integer = 0
                Dim pr_ol_gmName As String = ""
                Dim pr_ol_gmEmail As String = ""
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
                Dim pr_ol_logEdit_ip As String = Bll.GetIPAddress()
                Dim pr_ol_id As Integer = CInt(lbTagID.Text)

                Dim pr_ol_GlAccount As String = tbGlAc.Text
                Dim pr_ol_GlDetail As String = tbGlDe.Text
                Dim pr_ol_GlUserID As String = GlUserID
                Dim pr_ol_GlName As String = Glname
                Dim pr_ol_GlEmail As String = GlEmail

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
                '***********************InsertTagPR******************************'     

                If Bll.EditTagPR(pr_ol_id, pr_ol_logEdit_ip, pr_ol_GlAccount, pr_ol_GlDetail,
                                 pr_ol_GlUserID, pr_ol_GlName, pr_ol_GlEmail, pr_ol_gmID,
                                 pr_ol_gmName, pr_ol_gmEmail, pr_ol_gmStatus,
                                 pr_ol_CerNo, pr_ol_Plants, pr_ol_type) Then 'Insert TAG

                    Dim pr_item_reqDate As String = tbReqDate.Text
                    Dim pr_item_suppiler As String = tbSupplier.Text
                    Dim pr_item_rfq As String = tbRfq.Text
                    Dim pr_item_detail As String = tbDisc.Text
                    Dim pr_item_job As String = tbJob.Text
                    Dim pr_item_qty As String = tbQty.Text
                    Dim pr_item_unitPrice As String = tbPrice.Text
                    Dim pr_item_amount As String = tbAmount.Text


                    Dim pr_item_logOpen_ip As String = Bll.GetIPAddress()
                    Dim pr_item_id As Integer = CInt(lbItemID.Text)

                    '***********************InsertItemPR******************************'  
                    If Bll.EditItemPR(pr_item_id, pr_item_reqDate, pr_item_detail, pr_item_job, pr_item_qty, pr_item_unitPrice,
                                  pr_item_amount, pr_item_logOpen_ip, pr_item_suppiler, pr_item_rfq) Then  'Insert ITEM

                        If Trim(tbPathUpload.Text) <> "" Then
                            Dim pr_ol_attachFile As String = PrOltag & ".pdf" 'Rename to PR TAG ID 
                            Dim filePath As String = dlg.FileName
                            'Dim NameTo As String = Path.Combine(strFolderPath, fileName) 
                            File.Copy(filePath, Path.Combine(strFolderPath, pr_ol_attachFile), True)
                            ''*** Save File 

                        End If
                        MsgBox("Edit PR Online complete!", MsgBoxStyle.Information, "Edit Complete!")
                        GetItemPr()
                    Else

                        MsgBox("Edit PR Online not complete!", MsgBoxStyle.Information, "Edit Not complete!")
                    End If
                Else
                    MsgBox("Edit PR Online not complete!", MsgBoxStyle.Information, "Edit Not complete!")
                End If

            End If

        End If


        TotalQty = 0
        TotalAmount = 0
        If dgvEditPR.RowCount > 0 Then
            'if you have the other column to get the result you  could add a new one like these above 
            For index As Integer = 0 To dgvEditPR.RowCount - 1
                TotalQty += Convert.ToInt32(dgvEditPR.Rows(index).Cells(6).Value)
                TotalAmount += Convert.ToInt32(dgvEditPR.Rows(index).Cells(8).Value)
                'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
            Next
            lbTotalQty.Text = "Total Q'ty : " & TotalQty
            lbTotalAmount.Text = "Total Amount : " & TotalAmount
            'if you have the other column to get the result you  could add a new one like these above 
        End If

    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        'Dim StatusEdit As Integer = CInt(lbStatusEdit.Text)
        'If StatusEdit <> 0 Then
        If MsgBox("Are you confirm Save and Send data ?", MsgBoxStyle.YesNo, "Confirm Data") = MsgBoxResult.Yes Then

                Dim UrgentStatus As Integer = 3

                ' for send Email Process
                Dim NxtColEmail As String = ReqMgrEmail.ToString
                Dim ReqBy As String = ReqName.ToString
                Dim NxtColName As String = ReqMgrname.ToString
                Dim NxtTypeMail As String = "ReqMgr"

                If Bll.EditActiveTagPR(CInt(lbTagID.Text), 1) And Bll.AlertEmail(lbPrTag.Text, NxtColEmail, NxtColName, NxtColName, NxtTypeMail, UrgentStatus) Then
                    MsgBox("Active PR Online complete!", MsgBoxStyle.Information, "Complete!")
                    frmPreviews._strPr = lbTagID.Text
                    frmPreviews.frmPreviews_Load()
                    frmMain.frmMain_Load()
                    frmPreviews.Show()
                    Me.Close()
                End If
            End If
        'Else
        '    frmPreviews._strPr = lbTagID.Text
        '    frmPreviews.frmPreviews_Load()
        '    frmMain.frmMain_Load()
        '    frmPreviews.Show()
        '    Me.Close()
        'End If

    End Sub



    Private Sub dgvEditPR_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEditPR.CellClick
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            ClearText()
            lbItemID.Text = dgvEditPR.Rows(e.RowIndex).Cells(0).Value '
            tbReqDate.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(1).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(1).Value)
            tbSupplier.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(2).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(2).Value) '
            tbRfq.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(3).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(3).Value) '
            tbDisc.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(4).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(4).Value) '
            tbJob.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(5).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(5).Value) '
            tbQty.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(6).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(6).Value) '
            tbPrice.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(7).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(7).Value) ' 
            tbAmount.Text = IIf(IsDBNull(dgvEditPR.Rows(e.RowIndex).Cells(8).Value), "", dgvEditPR.Rows(e.RowIndex).Cells(8).Value) ' 

        End If
    End Sub

    Private Sub rbASTnoCER_CheckedChanged(sender As Object, e As EventArgs) Handles rbASTnoCER.CheckedChanged
        If rbASTnoCER.Checked = True Then
            'Checked
            tbCERtxt.Enabled = False
            tbGlAc.Text = "25199993100"
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
            tbGlAc.Text = "25199993100"
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
            tbGlAc.Text = "25399993100"
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
            tbGlAc.Text = "25199991200"
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

    Private Sub frmEditPR_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPreviews._strPr = lbTagID.Text
        frmPreviews.frmPreviews_Load()
        frmMain.frmMain_Load()
        frmPreviews.Show()
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
End Class