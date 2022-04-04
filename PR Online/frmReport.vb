
Imports PR_Online.BLL
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frmReport
    Dim Bll As BLL_Load = New BLL_Load
    Dim strPr As String
    Dim strPrID As String
    Public Property _strPr() As String
        Get
            Return strPr
        End Get
        Set(ByVal value As String)
            strPr = value
        End Set
    End Property
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        strPrID = strPr.ToString
        'Set the processing mode for the ReportViewer to Local   
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        Dim localReport As LocalReport
        localReport = ReportViewer1.LocalReport

        ReportViewer1.LocalReport.ReportPath = "\\art1\Public\01 ART Program Center\PR Online\reportPR.rdlc"

        Dim dataset As New DataSet("DatasetPrTag")

        Dim PrOnlineTag As String = strPrID 'Get value from button

        'Get the sales order data  
        GetPr_onlineTagData(PrOnlineTag, dataset)

        'Create a report data source for the sales order data  
        Dim dsPrOnlineTag As New ReportDataSource()
        dsPrOnlineTag.Name = "dsPrOnlineTag"
        dsPrOnlineTag.Value = dataset.Tables("dsPrOnlineTag")

        localReport.DataSources.Add(dsPrOnlineTag)

        'Get the sales order detail data  
        GetPr_onlineDetailData(PrOnlineTag, dataset)

        'Create a report data source for the sales   
        'order detail data  
        Dim dsPrOnlineDetail As New ReportDataSource()
        dsPrOnlineDetail.Name = "dsPrOnlineDetail"
        dsPrOnlineDetail.Value = dataset.Tables("dsPrOnlineDetail")

        localReport.DataSources.Add(dsPrOnlineDetail)

        'Create a report parameter for the sales order number   
        Dim rpPR_onlineNumber As New ReportParameter()
        rpPR_onlineNumber.Name = "pr_ol_tag"
        rpPR_onlineNumber.Values.Add(PrOnlineTag)

        'Set the report parameters for the report  
        Dim parameters() As ReportParameter = {rpPR_onlineNumber}
        localReport.SetParameters(parameters)

        'Refresh the report  
        ReportViewer1.RefreshReport()

    End Sub

    Private Sub GetPr_onlineTagData(ByVal PrOnlineTag As String,
                               ByRef dsPrOnlineTag As DataSet)

        Dim sqlPrOnlineTag As String =
            "SELECT        pr_ol_id, pr_ol_tag, pr_ol_date, pr_ol_suppiler, pr_ol_dept, pr_ol_rfq, pr_ol_req_by, pr_ol_req_email, pr_ol_req_mgrName, pr_ol_req_mgrEmail, pr_ol_req_mgrStatus, pr_ol_req_mgrMsg, pr_ol_req_mgrDate, pr_ol_req_mgrIP, 
                         pr_ol_gmName, pr_ol_gmEmail, pr_ol_gmStatus, pr_ol_gmMsg, pr_ol_gmDate, pr_ol_gmIP, pr_ol_assignPrepare, pr_ol_assignToEmail, pr_ol_assignDate, pr_ol_assignBy, pr_ol_assignEmail, pr_ol_assignIP, pr_ol_prStatus, 
                         pr_ol_poNo, pr_ol_scMgr_name, pr_ol_scMgr_email, pr_ol_scMgr_status, pr_ol_scMgr_msg, pr_ol_scMgr_date, pr_ol_scMgr_ip, pr_ol_logOpen_date, pr_ol_logOpen_ip, pr_ol_logEdit_date, pr_ol_logEdit_ip, pr_ol_attachFile, 
                         pr_ol_req_byID, pr_ol_req_mgrID, pr_ol_gmID, pr_ol_assignToID, pr_ol_scMgrID, pr_ol_assignPrepareName, pr_ol_StatusEdit, pr_ol_assignCloseDate, pr_ol_assignCloseIP, pr_ol_GlName, pr_ol_GlEmail, pr_ol_GlStatus, 
                         pr_ol_GlMsg, pr_ol_GlDate, pr_ol_GlIp, pr_ol_GlUserID, pr_ol_GlAccount, pr_ol_GlDetail, pr_ol_urgent
                FROM            pr_online
                WHERE        (pr_ol_tag = @pr_ol_tag)"
        Dim conDb As String = "packet size=4096;user id=sa;data source=ART_SQL\SQLEXPRESS; persist security info=True;initial catalog=ART_INTRA;password=PasswordSQL16"
        Dim conn As New SqlConnection(conDb)
        Dim command As New SqlCommand(sqlPrOnlineTag, conn)
        command.CommandTimeout = 600
        Dim da As New SqlDataAdapter(command)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        Dim parameter As New SqlParameter("pr_ol_tag",
                PrOnlineTag)
            command.Parameters.Add(parameter)

            Dim PrOnlineTagAdapter As New SqlDataAdapter(command)

            PrOnlineTagAdapter.Fill(dsPrOnlineTag, "dsPrOnlineTag")
        conn.Close()

    End Sub

    Private Sub GetPr_onlineDetailData(ByVal PrOnlineTag As String,
                               ByRef dsPrOnlineTag As DataSet)

        Dim sqlPrOnlineDetail As String =
            "SELECT        pr_item_id, pr_ol_tag, pr_item_reqDate, pr_item_detail, pr_item_glAccount, pr_item_glDetail, pr_item_glName, pr_item_glEmail, pr_item_glStatus, pr_item_glMsg, pr_item_glDate, pr_item_glIP, pr_item_job, pr_item_qty, 
                         pr_item_unitPrice, pr_item_amount, pr_item_logOpen_date, pr_item_logOpen_ip, pr_item_logEdit_date, pr_item_logEdit_ip, pr_item_glUserID, pr_item_poPronto, pr_item_suppiler, pr_item_rfq
                FROM            pr_online_item
                WHERE        (pr_ol_tag = @pr_ol_tag)"

        Dim conDb As String = "packet size=4096;user id=sa;data source=ART_SQL\SQLEXPRESS; persist security info=True;initial catalog=ART_INTRA;password=PasswordSQL16"
        Dim conn As New SqlConnection(conDb)
        Dim command As New SqlCommand(sqlPrOnlineDetail, conn)
        command.CommandTimeout = 600
        Dim da As New SqlDataAdapter(command)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        Dim parameter As New SqlParameter("pr_ol_tag",
                PrOnlineTag)
        command.Parameters.Add(parameter)

        Dim PrOnlineDetailAdapter As New SqlDataAdapter(command)

        PrOnlineDetailAdapter.Fill(dsPrOnlineTag,
                "dsPrOnlineDetail")
        conn.Close()




    End Sub

End Class

