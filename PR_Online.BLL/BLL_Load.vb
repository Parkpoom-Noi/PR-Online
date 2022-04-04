Imports outlook = Microsoft.Office.Interop.Outlook
Imports System.Net
Imports System.Net.Mail
Imports PR_Online.DAL
Imports System.Security.Cryptography

Public Class BLL_Load

    Dim objDB As objDB = New objDB
    Private TripleDes As New TripleDESCryptoServiceProvider
    Public Function AlertEmail(ByVal prFile As String, ByVal toEmail As String, ByVal reqBy As String, ByVal colName As String, ByVal TypeMessage As String, ByVal UrgentStatus As Integer) As Boolean
        Dim OutlookMessage As outlook.MailItem
        Dim AppOutlook As outlook.Application
        Dim UserRequest As String = colName
        Dim strFolderPath As String = "P:/IT/PR Online Attach Files/"
        'toEmail = "parkpoom@airradiators.co.th"
        Dim SubjectMes, BodyMes As String
        Dim UrgentHead, UrgentBody As String
        If UrgentStatus = 1 Then
            UrgentHead = "Urgent PR !"
            UrgentBody = "<p style='color:red'>Urgent PR !</p> <br>"
        Else
            UrgentHead = ""
            UrgentBody = ""
        End If
        If TypeMessage = "ReqMgr" Then
            SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
            BodyMes = "Dear " & colName & " (Dept. Manager), <br> <br>
" & UrgentBody & "
<p>Please review and approval in PR online No." & prFile & "  <br>
Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a> <br>
Please don’t’ reply for this email. <br></p>
 <br>
Best Regards, <br>
PR Online Servers <br>
 <br>
---------------------------------------------------------------- <br>
 <br>
"
        ElseIf TypeMessage = "GlMgr" Then
            SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
            BodyMes = "Dear " & colName & " (GL Manager), <br>
" & UrgentBody & "
Please review and approval in PR online No." & prFile & " <br>
<p>Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a></p>
Please don’t’ reply for this email. <br>
 <br>
Best Regards, <br>
PR Online Servers <br>
 <br>
---------------------------------------------------------------- <br>
 <br>
"
        ElseIf TypeMessage = "ReqMgr&GLMgr" Then
            SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
            BodyMes = "Dear " & colName & " (Dept Manager & GL Manager), <br>
" & UrgentBody & "
Please review and approval in PR online No." & prFile & " <br>
<p>Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a></p>
Please don’t’ reply for this email. <br>
 <br>
Best Regards, <br>
PR Online Servers <br>
 <br>
---------------------------------------------------------------- <br>
 <br>
"
        ElseIf TypeMessage = "GMgr" Then
            SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
            BodyMes = "Dear " & colName & " (General Manager), <br>
" & UrgentBody & "
Please review and approval in PR online No." & prFile & " <br>
<p>Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a></p>
Please don’t’ reply for this email. <br>
 <br>
Best Regards, <br>
PR Online Servers <br>
 <br>
---------------------------------------------------------------- <br>
 <br>
"
        ElseIf TypeMessage = "ScMgr" Then
            SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
            BodyMes = "Dear " & colName & " (Supply Chain Manager), <br>
" & UrgentBody & "
Please review and approval in PR online No." & prFile & " <br>
<p>Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a></p>
Please don’t’ reply for this email. <br>
 <br>
Best Regards, <br>
PR Online Servers <br>
 <br>
---------------------------------------------------------------- <br>
 <br>
"
        ElseIf TypeMessage = "CpUser" Then
            SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
            BodyMes = "Dear " & colName & " (Pr online owner), <br>
" & UrgentBody & "
Please see the update status of PR online No." & prFile & ",  your PR online is Complete.  <br>
<p>Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a></p>
Please don’t’ reply for this email. <br>
 <br>
Best Regards, <br>
PR Online Servers <br>
 <br>
---------------------------------------------------------------- <br>
 <br>
"

        ElseIf TypeMessage = "RjUser" Then
            SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
            BodyMes = "Dear " & colName & " (Pr online owner), <br>
" & UrgentBody & "
Please see the update status of PR online No." & prFile & ", your PR online has been Rejected.  <br>
<p>Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a></p>
Please don’t’ reply for this email. <br>
 <br>
Best Regards, <br>
PR Online Servers <br>
 <br>
---------------------------------------------------------------- <br>
 <br>
"
        ElseIf TypeMessage = "CancelPR" Then
            SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
            BodyMes = "Dear " & colName & " (Pr online owner), <br>
" & UrgentBody & "
Please see the update status of PR online No." & prFile & ", your PR online has been Canceled.  <br>
<p>Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a></p>
Please don’t’ reply for this email. <br>
 <br>
Best Regards, <br>
PR Online Servers <br>
 <br>
---------------------------------------------------------------- <br>
 <br>
"
        ElseIf TypeMessage = "Purchase" Then
            SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
            BodyMes = "Dear " & colName & " (Purchasing team), <br>
" & UrgentBody & "
Please see the PR assignment and update status of PR online No." & prFile & "  <br>
<p>Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a></p>
Please don’t’ reply for this email. <br>
 <br>
Best Regards, <br>
PR Online Servers <br>
 <br>
---------------------------------------------------------------- <br>
 <br>
"
        End If

        Try
            AppOutlook = New outlook.Application
            OutlookMessage = AppOutlook.CreateItem(outlook.OlItemType.olMailItem)
            AppOutlook = CreateObject("Outlook.Application")
            Dim Recipents As outlook.Recipients = OutlookMessage.Recipients
            'Change email to root approve
            Recipents.Add(toEmail) 'Email first permission workflow like a approve flow and P'KN for manage to P'Noon and P'Learm

            'Dim dt_CERCheck As DataTable
            'Dim CER As String = ""
            'dt_CERCheck = GetCERCheck(prFile)
            'If dt_CERCheck.Rows.Count > 0 Then
            '    For i As Integer = 0 To dt_CERCheck.Rows.Count - 1
            '        CER = dt_CERCheck.Rows(i)("pr_ol_GlAccount").ToString()
            '    Next
            '    If Trim(CER) = "2599993100" Then
            '        Recipents.cc("adchaya@airradiators.co.th")
            '        toEmail = toEmail & "+CC"
            '    End If
            'End If

            OutlookMessage.Subject = SubjectMes
            OutlookMessage.HTMLBody = "<html><body>"
            OutlookMessage.HTMLBody += BodyMes
            OutlookMessage.HTMLBody += "</body></html>"

            'If Trim(prFile) <> "" Then
            '    If System.IO.File.Exists(strFolderPath & prFile & ".pdf") Then
            '        OutlookMessage.Attachments.Add(strFolderPath & prFile & ".pdf")  'Change to atchfiles 
            '    End If
            'End If

            OutlookMessage.Send()

            InsertLogSendEmail(prFile, toEmail, reqBy, colName, TypeMessage, "True")
            Return True
        Catch ex As Exception
            InsertLogSendEmail(prFile, toEmail, reqBy, colName, TypeMessage, "False")
            Return False
        Finally
            OutlookMessage = Nothing
            AppOutlook = Nothing
        End Try
    End Function
    Public NotInheritable Class Simple3Des
        Private TripleDes As New TripleDESCryptoServiceProvider
        Private Function TruncateHash(
    ByVal key As String,
    ByVal length As Integer) As Byte()

            Dim sha1 As New SHA1CryptoServiceProvider

            ' Hash the key.
            Dim keyBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(key)
            Dim hash() As Byte = sha1.ComputeHash(keyBytes)

            ' Truncate or pad the hash.
            ReDim Preserve hash(length - 1)
            Return hash
        End Function
        Public Function EncryptData(
    ByVal plaintext As String) As String

            ' Convert the plaintext string to a byte array.
            Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the encoder to write to the stream.
            Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
            encStream.FlushFinalBlock()

            ' Convert the encrypted stream to a printable string.
            Return Convert.ToBase64String(ms.ToArray)
        End Function
        Public Function DecryptData(
    ByVal encryptedtext As String) As String

            ' Convert the encrypted text string to a byte array.
            Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the decoder to write to the stream.
            Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
            decStream.FlushFinalBlock()

            ' Convert the plaintext stream to a string.
            Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
        End Function
        '
        Sub New(ByVal key As String)
            ' Initialize the crypto provider.
            TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
        End Sub
    End Class


    Public Function PassEncoding(ByVal RawPass As String) As String

        Dim wrapper As New Simple3Des("gsd#$%UJH25sjSDFGE%GDBS+(=AW&*(jdsg;ADGSERGSg")
        Dim cipherText As String = wrapper.EncryptData(RawPass)

        Return cipherText
    End Function

    Public Function TestDecoding() As String
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments &
                "\cipherText.txt")
        Dim password As String = InputBox("Enter the password:")
        Dim wrapper As New Simple3Des(password)

        ' DecryptData throws if the wrong password is used.
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            MsgBox("The plain text is: " & plainText)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
        End Try
    End Function

#Region "Get"
    Public Function GetChart() As DataTable
        Dim dtCheckLogin As DataTable

        dtCheckLogin = objDB.SelectSQL("SELECT status_detail, COUNT(pr_ol_id ) as total from (
Select CASE
        WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
        ELSE 'Error!' END AS status_detail
		, A1.[pr_ol_id]  as pr_ol_id
     
  FROM [ART_INTRA].[dbo].[pr_online] A1 INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
  ON (A1.[pr_ol_prStatus] = A3.[status_no])
WHERE A1.[pr_ol_prStatus] <> 10 AND A1.[pr_ol_prStatus] <> 11
  ) B
  GROUP BY status_detail")
        Return dtCheckLogin
    End Function


    Public Function GetCheckLogin(ByVal Username As String, ByVal Password As String) As DataTable
        Dim dtCheckLogin As DataTable

        dtCheckLogin = objDB.SelectSQL("SELECT [user_id]
                                          ,[user_username]
                                          ,[user_password]
                                          ,[user_dept]
                                          ,[user_empcode]
                                          ,[user_fullname]
                                          ,[user_stOnline]
                                          ,[user_dateAdd] 
                                          ,[user_permission_pr]
                                      FROM [ART_INTRA].[dbo].[art_proc_user]
                                      WHERE UPPER( [user_username]) = UPPER('" & Username & "') 
                                      AND [user_password] = '" & Password & "'")
        Return dtCheckLogin
    End Function

    Public Function GetCheckIP(ByVal UserHost As String) As DataTable
        Dim dtCheckLogin As DataTable

        dtCheckLogin = objDB.SelectSQL("SELECT [user_id]
                                          ,[user_username]
                                          ,[user_password]
                                          ,[user_dept]
                                          ,[user_empcode]
                                          ,[user_fullname]
                                          ,[user_stOnline]
                                          ,[user_ip] 
                                          ,[user_remember]
                                          ,[user_host]
                                      FROM [ART_INTRA].[dbo].[art_proc_user]
                                      WHERE [user_host]  =  '" & UserHost & "' 
                                      AND [user_remember] = 1")
        Return dtCheckLogin
    End Function
    Public Function GetDataUser(ByVal ID As Integer) As DataTable
        Dim dtCheckLogin As DataTable

        dtCheckLogin = objDB.SelectSQL("SELECT [user_id]
                                          ,[user_username]
                                          ,[user_password]
                                          ,[user_dept]
                                          ,[user_empcode]
                                          ,[user_fullname]
                                          ,[user_stOnline]
                                          ,[user_dateAdd] 
                                          ,[user_permission_pr]
                                      FROM [ART_INTRA].[dbo].[art_proc_user]
                                      WHERE user_id =  " & ID & "  AND [user_permission_pr] IS NOT NULL")
        Return dtCheckLogin
    End Function

    Public Function GetPROnlineTag() As String
        Dim TagNO As Integer = Nothing
        Dim PR_DATE_TIME As String = "PR-" & DateTime.Now.ToString("yyMM", New System.Globalization.CultureInfo("en-US"))
        Dim PR_TAG As String = Nothing
        Dim dt_TAG As DataTable
        dt_TAG = objDB.SelectSQL("SELECT COUNT(pr_ol_tag) AS TAG_NO FROM [pr_online] Where pr_ol_tag LIKE '" & PR_DATE_TIME & "%'")
        If dt_TAG.Rows.Count > 0 Then
            For i As Integer = 0 To dt_TAG.Rows.Count - 1
                TagNO = Integer.Parse(dt_TAG.Rows(0)("TAG_NO").ToString) + 1
                PR_TAG = PR_DATE_TIME & Format(TagNO, "000")
            Next
        Else
            PR_TAG = PR_DATE_TIME & Format(1, "000")
        End If
        Return PR_TAG
    End Function

    Public Function GetDataREQ() As String
        Dim TagNO As Integer = Nothing
        Dim PR_DATE_TIME As String = "PR-" & DateTime.Now.ToString("yyMM")
        Dim PR_TAG As String = Nothing
        Dim dt_TAG As DataTable
        dt_TAG = objDB.SelectSQL("SELECT COUNT(pr_ol_tag) AS TAG_NO FROM [pr_online] Where pr_ol_tag LIKE '" & PR_DATE_TIME & "%'")
        If dt_TAG.Rows.Count > 0 Then
            For i As Integer = 0 To dt_TAG.Rows.Count - 1
                TagNO = Integer.Parse(dt_TAG.Rows(0)("TAG_NO").ToString) + 1
                PR_TAG = PR_DATE_TIME & Format(TagNO, "000")
            Next
        Else
            PR_TAG = PR_DATE_TIME & Format(1, "000")
        End If
        Return PR_TAG
    End Function
    Public Function GetIPAddress() As String
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        Return strIPAddress
    End Function
    Public Function GetUserData(ByVal ID As Integer) As DataTable
        Dim dtDataUser As DataTable
        dtDataUser = objDB.SelectSQL("SELECT [user_id]
                                          ,[user_username]
                                          ,[user_password]
                                          ,[user_dept]
                                          ,[user_empcode]
                                          ,[user_fullname]
                                          ,[user_stOnline]
                                          ,[user_dateAdd]
                                          ,[user_permission_mt]
                                          ,[user_permission_pr] 
                                          ,[user_email]
                                      FROM [ART_INTRA].[dbo].[art_proc_user]
                                      WHERE [user_id] = " & ID)
        Return dtDataUser
    End Function
    Public Function GetMgrData(ByVal ID As Integer) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT       [dept_id]
                                              ,[dept_name]
                                              ,[dept_mgrName]
                                              ,[dept_mgrEmail]
                                              ,[user_id]
                                          FROM [ART_INTRA].[dbo].[art_dept]
                                          WHERE [dept_id] = " & ID)
        Return dtData
    End Function
    Public Function GetApproveData(ByVal Dept As String) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT       [dept_id]
                                              ,[dept_name]
                                              ,[dept_mgrName]
                                              ,[dept_mgrEmail]
                                              ,[user_id]
                                          FROM [ART_INTRA].[dbo].[art_dept]
                                          WHERE [dept_name] = '" & Dept & "'")
        Return dtData
    End Function
    Public Function GetGlData(ByVal conWhere As String) As DataTable
        Dim dtGlAcc As DataTable
        dtGlAcc = objDB.SelectSQL("SELECT  A1.[gl_id]
                                          ,A1.[gl_code]
                                          ,A1.[gl_detail] 
                                          ,A2.[dept_mgrName] AS 'gl_mgr'
                                          ,A2.[dept_mgrEmail] AS 'gl_email'
                                          ,A2.[user_id]
                                   FROM [ART_INTRA].[dbo].[pr_online_gl] A1 JOIN [ART_INTRA].[dbo].[art_dept] A2 ON (A1.dept_id = A2.dept_id) " & conWhere & "
                                  ")
        Return dtGlAcc
    End Function

    Public Function GetPurchaseEmp() As DataTable
        Dim dtTable As DataTable
        dtTable = objDB.SelectSQL("SELECT  *
                                   FROM [ART_INTRA].[dbo].[art_proc_user] WHERE [user_dept] = 6 ")
        Return dtTable
    End Function

    Public Function GetPurchaseEmpData(ByVal conWhere As String) As DataTable
        Dim dtTable As DataTable
        dtTable = objDB.SelectSQL("SELECT  *
                                   FROM [ART_INTRA].[dbo].[art_proc_user] WHERE [user_dept] = 6 " & conWhere)
        Return dtTable
    End Function
    Public Function GetAssisnName(ByVal UserID As Integer) As String
        Dim dtTable As DataTable
        Dim DataReturn As String
        dtTable = objDB.SelectSQL("SELECT  [user_id]
                                      ,[user_username]
                                      ,[user_password]
                                      ,[user_dept]
                                      ,[user_empcode]
                                      ,[user_fullname]
                                      ,[user_stOnline]
                                      ,[user_dateAdd]
                                      ,[user_permission_mt]
                                      ,[user_permission_pr]
                                      ,[user_email]
                                  FROM [ART_INTRA].[dbo].[art_proc_user]WHERE [user_id] = " & UserID)
        For i As Integer = 0 To dtTable.Rows.Count - 1
            DataReturn = dtTable.Rows(i)("user_fullname").ToString()
        Next

        Return DataReturn
    End Function

    Public Function GetMyPrOnline(ByVal ID As Integer) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT   A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                            ,CASE
                                                WHEN  A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager' 
                                            ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Rejected'  
                                                ELSE 'Error!'
                                            END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date' 
                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date' 
                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                            ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!' 
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Rejected'  
                                                ELSE 'No need.'
                                            END AS 'GM Approve Status'  
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date'
                                          ,A1.[pr_ol_poNo]  AS 'PO No.'  
                                          ,A1.[pr_ol_attachFile]  AS 'Attach File'
                                      FROM [ART_INTRA].[dbo].[pr_online] A1
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no])  
                                      WHERE A1.[pr_ol_req_byID] = " & ID & " AND (A1.[pr_ol_tag] <> '' AND A1.[pr_ol_tag] IS NOT NULL)  AND ( A1.[pr_ol_prStatus] <> 10 AND A1.[pr_ol_prStatus] <> 11 ) ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function

    Public Function GetMyCompPrOnline(ByVal ID As Integer) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT   A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                            ,CASE
                                                WHEN  A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager' 
                                            ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Rejected'  
                                                ELSE 'Error!'
                                            END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date' 
                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date' 
                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                            ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!' 
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Rejected'  
                                                ELSE 'No need.'
                                            END AS 'GM Approve Status'  
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date'
                                          ,A1.[pr_ol_poNo]  AS 'PO No.'  
                                          ,A1.[pr_ol_attachFile]  AS 'Attach File'
                                      FROM [ART_INTRA].[dbo].[pr_online] A1
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no])  
                                      WHERE A1.[pr_ol_req_byID] = " & ID & " AND (A1.[pr_ol_tag] <> '' AND A1.[pr_ol_tag] IS NOT NULL)  AND (A1.[pr_ol_prStatus] = 10 OR A1.[pr_ol_prStatus] = 11) ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function
    Public Function GetMyApprovePR(ByVal ID As Integer) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT DISTINCT  A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager'
                                          ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Reject!' 
											END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date'

                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date'

                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                          ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Reject!' 
                                                ELSE 'No need.'
											
											END AS 'GM Approve Status' 
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date' 
                                          
                                      FROM [ART_INTRA].[dbo].[pr_online] A1  
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no]) 
									  WHERE ( A1.[pr_ol_req_mgrID] = " & ID & " AND A1.[pr_ol_req_mgrStatus]  = 0 ) OR ( A1.[pr_ol_gmID] = " & ID & " AND A1.[pr_ol_gmStatus]  = 0 AND ( A1.[pr_ol_req_mgrStatus] <> 0 AND A1.[pr_ol_GlStatus] <> 0 ))  OR (A1.[pr_ol_GlUserID] = " & ID & " AND A1.[pr_ol_GlStatus] = 0  AND (A1.[pr_ol_req_mgrID] <> " & ID & " AND A1.[pr_ol_req_mgrStatus]  <> 0 )
                                       And (A1.[pr_ol_prStatus] <> '2' AND A1.[pr_ol_prStatus] <> '4' AND A1.[pr_ol_prStatus] <> '6' AND A1.[pr_ol_prStatus] <> '8')  AND  ( A1.[pr_ol_prStatus] <> 10 AND A1.[pr_ol_prStatus] <> 11 AND A1.[pr_ol_prStatus] <> 0 ) )  
									  ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function


    Public Function GetAssignPR(ByVal ID As Integer) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT DISTINCT  A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager'
                                          ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Reject!' 
											END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date'

                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date'

                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                          ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Reject!' 
                                                ELSE 'No need.'
											
											END AS 'GM Approve Status' 
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date' 
                                          
                                      FROM [ART_INTRA].[dbo].[pr_online] A1  
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no]) 
									  WHERE ( A1.[pr_ol_scMgrID] = " & ID & ")  
									  AND (A1.[pr_ol_prStatus] = 7)  
                                      AND (A1.[pr_ol_req_mgrStatus]  <> 2 OR A1.[pr_ol_gmStatus]  <> 2  OR A1.[pr_ol_GlUserID]  <> 2 )  
									  ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function


    Public Function GetAllPR() As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT DISTINCT  A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager'
                                          ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Reject!' 
											END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date'

                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date'

                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                          ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Reject!' 
                                                ELSE 'No need.'
											
											END AS 'GM Approve Status' 
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date' 
                                          
                                      FROM [ART_INTRA].[dbo].[pr_online] A1  
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no]) 
									  ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function

    Public Function GetAllPR_WaitPO() As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT DISTINCT  A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager'
                                          ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Reject!' 
											END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date'

                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date'

                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                          ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Reject!' 
                                                ELSE 'No need.'
											
											END AS 'GM Approve Status' 
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date' 
                                          
                                      FROM [ART_INTRA].[dbo].[pr_online] A1  
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no]) 
                                      WHERE A1.[pr_ol_prStatus] = 9
									  ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function


    Public Function GetAllPR_Complete() As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT DISTINCT  A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager'
                                          ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Reject!' 
											END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date'

                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date'

                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                          ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Reject!' 
                                                ELSE 'No need.'
											
											END AS 'GM Approve Status' 
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date' 
                                          
                                      FROM [ART_INTRA].[dbo].[pr_online] A1  
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no]) 
                                      WHERE A1.[pr_ol_prStatus] = 10
									  ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function



    Public Function GetMyApproved(ByVal ID As Integer) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT DISTINCT  A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager'
                                          ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Reject!' 
											END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date'

                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date'

                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                          ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Reject!' 
                                                ELSE 'No need.'
											
											END AS 'GM Approve Status' 
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date' 
                                          
                                      FROM [ART_INTRA].[dbo].[pr_online] A1  
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no]) 
									  WHERE ( (A1.[pr_ol_req_mgrID] = " & ID & " AND A1.[pr_ol_req_mgrStatus]  <> 0 ) OR  ( A1.[pr_ol_gmID] = " & ID & " AND  A1.[pr_ol_gmStatus]  <> 0 ) OR (A1.[pr_ol_GlUserID] = " & ID & " AND A1.[pr_ol_GlStatus]  <> 0 ) )  
									  AND (A1.[pr_ol_tag] <> '' AND A1.[pr_ol_tag] IS NOT NULL)  
									  ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function


    Public Function GetMyPrAssign(ByVal ID As Integer) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT DISTINCT  A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager'
                                          ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Reject!' 
											END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date'

                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date'

                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                          ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Reject!' 
                                                ELSE 'No need.'
											
											END AS 'GM Approve Status' 
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date' 
                                          
                                      FROM [ART_INTRA].[dbo].[pr_online] A1  
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no]) 
									  WHERE ( A1.[pr_ol_assignPrepare] = " & ID & ")  
									  AND (A1.[pr_ol_prStatus] = 9 )
									  ORDER BY A2.[pr_item_reqDate], A1.[pr_ol_tag] DESC")
        Return dtData
    End Function


    Public Function GetMyCompJob(ByVal ID As Integer) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT DISTINCT  A1.[pr_ol_id] AS 'System ID'
                                          ,A1.[pr_ol_tag] AS 'PR Tag No.'
                                            ,CASE
                                                WHEN A1.[pr_ol_prStatus] = A3.[status_no] THEN A3.[status_detail] 
                                                ELSE 'Error!'
                                            END AS 'PR Online Status'
                                            ,CASE
                                                WHEN A1.[pr_ol_urgent] = 1 THEN 'Urgent!' 
                                                ELSE 'Not Urgent'
                                            END AS 'PR Urgent'
                                          ,FORMAT(A1.[pr_ol_date], 'dd-MMM-yyyy') AS 'PR date'  
                                          ,A2.[pr_item_detail]  AS 'Description'  
                                          ,A2.[pr_item_job]  AS 'Job'  
                                          ,A2.[pr_item_poPronto]  AS 'PO No.' 
                                          ,A2.[pr_item_logEdit_date] AS 'PO Date' 
                                          ,A2.[pr_item_reqDate] AS 'REQ Date' 
                                          ,A1.[pr_ol_dept] AS 'Requested from Dept.'
                                          ,A1.[pr_ol_req_by]  AS 'Requested By'
                                          ,A1.[pr_ol_req_mgrName]  AS 'Req. Manager'
                                          ,CASE
                                                WHEN A1.[pr_ol_req_mgrStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_req_mgrStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_req_mgrStatus] = 2 THEN 'Reject!' 
											END AS 'Manager Approve Status'  
                                          ,FORMAT(A1.[pr_ol_req_mgrDate], 'dd-MMM-yyyy')  AS 'Manager Approve date'

                                          ,A1.[pr_ol_GlName]  AS 'GL Mgr.'
                                          ,CASE
                                                WHEN A1.[pr_ol_GlStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_GlStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_GlStatus] = 2 THEN 'Reject!' 
											END AS 'GL Mgr. Approve Status'  
                                          ,FORMAT(A1.[pr_ol_GlDate], 'dd-MMM-yyyy')  AS 'GL Mgr. Approve date'

                                          ,A1.[pr_ol_gmName]  AS 'General Manager' 
                                          ,CASE
                                                WHEN A1.[pr_ol_gmStatus] = 0 THEN 'Waiting!'
                                                WHEN A1.[pr_ol_gmStatus] = 1 THEN 'Approved!' 
                                                WHEN A1.[pr_ol_gmStatus] = 2 THEN 'Reject!' 
                                                ELSE 'No need.'
											
											END AS 'GM Approve Status' 
                                          ,FORMAT(A1.[pr_ol_gmDate], 'dd-MMM-yyyy')  AS 'GM Approve date'
                                          ,A1.[pr_ol_assignPrepareName] AS 'Prepare by'  
                                          ,FORMAT(A1.[pr_ol_assignDate], 'dd-MMM-yyyy') AS 'Assign date' 
                                          
                                      FROM [ART_INTRA].[dbo].[pr_online] A1  
									  Left Join (SELECT  [pr_ol_tag]
												  ,[pr_item_detail] = MIN([pr_item_detail])
												  ,[pr_item_job] = MIN([pr_item_job])
												  ,[pr_item_poPronto] = MIN([pr_item_poPronto])
												  ,[pr_item_logEdit_date] = MIN([pr_item_logEdit_date])
												  ,[pr_item_reqDate] = MIN([pr_item_reqDate])
											  FROM [ART_INTRA].[dbo].[pr_online_item]  
											 GROUP BY	[pr_ol_tag]  ) A2 ON ( A1.[pr_ol_tag] = A2.[pr_ol_tag])
									  INNER  JOIN [ART_INTRA].[dbo].[pr_online_status] A3 
									  ON (A1.[pr_ol_prStatus] = A3.[status_no]) 
									  WHERE ( A1.[pr_ol_assignPrepare] = " & ID & ")  
									  AND (A1.[pr_ol_prStatus] = 10 ) 
									  ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function


    Public Function GetOwnerPR(ByVal prID As Integer) As Integer
        Dim dtData As DataTable
        Dim resultReturn As Integer = 0
        dtData = objDB.SelectSQL("SELECT  [pr_ol_req_byID] FROM [ART_INTRA].[dbo].[pr_online] WHERE ([pr_ol_req_byID] IS not null and [pr_ol_req_byID] <> '') AND [pr_ol_id] = '" & prID & "'")
        If dtData.Rows.Count > 0 Then
            For i As Integer = 0 To dtData.Rows.Count - 1
                resultReturn = dtData.Rows(0)("pr_ol_req_byID")
            Next
        End If
        Return resultReturn
    End Function

    Public Function GetPrTagData(ByVal prID As Integer) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT  *
                                      FROM [ART_INTRA].[dbo].[pr_online]
                                      WHERE ([pr_ol_req_byID] IS not null and [pr_ol_req_byID] <> '') AND [pr_ol_id] = '" & prID & "'")
        Return dtData
    End Function
    Public Function GetTypeApprove(ByVal UserID As Integer, ByVal PrTag As String) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("  SELECT DISTINCT A1.[pr_ol_tag]
                                                    ,CASE WHEN A1.[pr_ol_req_mgrID] = " & UserID & " THEN 1 ELSE 0 END AS [pr_ol_req_mgrID]
                                                    ,CASE WHEN A1.[pr_ol_gmID] = " & UserID & " THEN 1 ELSE 0 END  AS [pr_ol_gmID]
                                                    ,CASE WHEN A1.[pr_ol_GlUserID] = " & UserID & " THEN 1 ELSE 0 END AS [pr_ol_GlUserID]

                                                  FROM [ART_INTRA].[dbo].[pr_online] A1  
									              WHERE ( A1.[pr_ol_req_mgrID] = " & UserID & " OR  A1.[pr_ol_gmID] = " & UserID & " OR  A1.[pr_ol_scMgrID] = " & UserID & " OR A1.[pr_ol_GlUserID] = " & UserID & " )  
									              AND (A1.[pr_ol_tag] <> '' AND A1.[pr_ol_tag] IS NOT NULL)  
									              ORDER BY A1.[pr_ol_tag] DESC")
        Return dtData
    End Function
    Public Function GetPrItemData(ByVal prTag As String) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT   [pr_item_id] 
                                          ,[pr_item_reqDate]
                                          ,[pr_item_suppiler]
                                          ,[pr_item_rfq]
                                          ,[pr_item_detail]
                                          ,[pr_item_job]
                                          ,[pr_item_qty]
                                          ,[pr_item_unitPrice]
                                          ,[pr_item_amount] 
                                          ,[pr_item_poPronto]
                                          ,[pr_item_logEdit_date]

                                      FROM [ART_INTRA].[dbo].[pr_online_item]
                                      WHERE ([pr_ol_tag] IS not null and [pr_ol_tag] <> '') AND [pr_ol_tag] = '" & prTag & "'")
        Return dtData
    End Function


    Public Function GetStatusPR(ByVal StatusID As Integer) As String
        Dim dtData As DataTable
        Dim resultReturn As String
        dtData = objDB.SelectSQL("SELECT * FROM [ART_INTRA].[dbo].[pr_online_status] Where [status_no] = " & StatusID)
        If dtData.Rows.Count > 0 Then
            For i As Integer = 0 To dtData.Rows.Count - 1
                resultReturn = dtData.Rows(0)("status_detail").ToString
            Next
        Else
            resultReturn = "Error Status!"
        End If
        Return resultReturn
    End Function

    Public Function GetStatusEditPr(ByVal PrID As Integer) As String
        Dim dtData As DataTable
        Dim resultReturn As String
        dtData = objDB.SelectSQL("SELECT  [pr_ol_StatusEdit]  FROM [ART_INTRA].[dbo].[pr_online] Where [pr_ol_id] = " & PrID)
        If dtData.Rows.Count > 0 Then
            For i As Integer = 0 To dtData.Rows.Count - 1
                resultReturn = dtData.Rows(0)("pr_ol_StatusEdit").ToString
            Next
        End If
        Return resultReturn
    End Function
    Public Function GetCERCheck(ByVal PrTag As String) As DataTable
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT [pr_ol_tag] ,[pr_ol_GlAccount]  FROM [ART_INTRA].[dbo].[pr_online] WHERE [pr_ol_tag] = '" & PrTag & "'")
        Return dtData
    End Function
#End Region

    ''
#Region "Excute Generate PR Online"
    Public Function InsertTagPR(ByVal pr_ol_tag As String, ByVal pr_ol_dept As String,
                                 ByVal pr_ol_req_by As String, ByVal pr_ol_req_email As String, ByVal pr_ol_req_mgrName As String,
                                 ByVal pr_ol_req_mgrEmail As String, ByVal pr_ol_gmName As String, ByVal pr_ol_gmEmail As String,
                                 ByVal pr_ol_assignEmail As String, ByVal pr_ol_scMgr_name As String, ByVal pr_ol_scMgr_email As String,
                                 ByVal pr_ol_logOpen_ip As String, ByVal pr_ol_attachFile As String, ByVal pr_ol_req_byID As Integer,
                                 ByVal pr_ol_req_mgrID As Integer, ByVal pr_ol_gmID As Integer, ByVal pr_ol_scMgrID As Integer,
                                 ByVal pr_ol_GlAccount As String, ByVal pr_ol_GlDetail As String, ByVal pr_ol_GlUserID As Integer,
                                 ByVal pr_ol_GlName As String, ByVal pr_ol_GlEmail As String, ByVal pr_ol_gmStatus As Integer, ByVal pr_ol_scMgr_status As Integer,
                                 ByVal pr_ol_CerNo As String, ByVal pr_ol_Plants As String, ByVal pr_ol_type As Integer) As Boolean
        'Insert PR ONLINE
        If objDB.ExecuteSQL(" 
                            INSERT INTO [dbo].[pr_online]
                                   ([pr_ol_tag]
                                   ,[pr_ol_date]
                                   ,[pr_ol_dept]
                                   ,[pr_ol_req_by]
                                   ,[pr_ol_req_email]
                                   ,[pr_ol_req_mgrName]
                                   ,[pr_ol_req_mgrEmail]
                                   ,[pr_ol_req_mgrStatus]
                                   ,[pr_ol_gmName]
                                   ,[pr_ol_gmEmail]
                                   ,[pr_ol_assignEmail]
                                   ,[pr_ol_scMgr_name]
                                   ,[pr_ol_scMgr_email]
                                   ,[pr_ol_logOpen_date]
                                   ,[pr_ol_logOpen_ip]
                                   ,[pr_ol_attachFile]
                                   ,[pr_ol_req_byID]
                                   ,[pr_ol_req_mgrID]
                                   ,[pr_ol_gmID] 
                                   ,[pr_ol_scMgrID]
                                   ,[pr_ol_prStatus]
                                   ,[pr_ol_GlAccount]
                                   ,[pr_ol_GlDetail]   
                                   ,[pr_ol_GlUserID]
                                   ,[pr_ol_GlName] 
                                   ,[pr_ol_GlEmail] 
                                   ,[pr_ol_GlStatus]
                                   ,[pr_ol_gmStatus]
                                   ,[pr_ol_scMgr_status]
                                   ,[pr_ol_urgent]
                                   ,[pr_ol_CerNo]
                                   ,[pr_ol_Plants]
                                   ,[pr_ol_type])
                             VALUES
                                   ( '" & pr_ol_tag & "'
                                   ,GETDATE()
                                   ,'" & pr_ol_dept & "'
                                   ,'" & pr_ol_req_by & "'
                                   ,'" & pr_ol_req_email & "'
                                   ,'" & pr_ol_req_mgrName & "'
                                   ,'" & pr_ol_req_mgrEmail & "'
                                   ,0
                                   ,'" & pr_ol_gmName & "'
                                   ,'" & pr_ol_gmEmail & "'
                                   ,'" & pr_ol_assignEmail & "'
                                   ,'" & pr_ol_scMgr_name & "'
                                   ,'" & pr_ol_scMgr_email & "'
                                   ,GETDATE()
                                   ,'" & pr_ol_logOpen_ip & "'
                                   ,'" & pr_ol_attachFile & "'
                                   ,'" & pr_ol_req_byID & "'
                                   ,'" & pr_ol_req_mgrID & "'
                                   ,'" & pr_ol_gmID & "'
                                   ,'" & pr_ol_scMgrID & "'
                                   ,1
                                   ,'" & pr_ol_GlAccount & "'
                                   ,'" & pr_ol_GlDetail & "'
                                   ," & pr_ol_GlUserID & "
                                   ,'" & pr_ol_GlName & "'
                                   ,'" & pr_ol_GlEmail & "'
                                   ,0
                                   ," & pr_ol_gmStatus & "
                                   ," & pr_ol_scMgr_status & "
                                   ,0
                                   ,'" & pr_ol_CerNo & "'
                                   ,'" & pr_ol_Plants & "'
                                   ," & pr_ol_type & ")") Then

            Return True
        Else
            Return False
        End If



    End Function

    Public Function InsertItemPR(ByVal pr_ol_tag As String, ByVal pr_item_reqDate As String, ByVal pr_item_detail As String,
                                 ByVal pr_item_job As String, ByVal pr_item_qty As String, ByVal pr_item_unitPrice As String, ByVal pr_item_amount As String,
                                 ByVal pr_item_logOpen_ip As String, ByVal pr_item_suppiler As String, ByVal pr_item_rfq As String) As Boolean
        'Insert PR ITEM

        'Dim DateTimeReq = DateTime.ParseExact(pr_item_reqDate, "dd/MM/yyyy", Nothing)
        Dim DateTimeReq = pr_item_reqDate 'DateTime.Parse(pr_item_reqDate)


        Try
            If objDB.ExecuteSQL(" 
                            INSERT INTO [dbo].[pr_online_item]
                                   ([pr_ol_tag]
                                   ,[pr_item_reqDate]
                                   ,[pr_item_suppiler]
                                   ,[pr_item_rfq]
                                   ,[pr_item_detail]
                                   ,[pr_item_job]
                                   ,[pr_item_qty]
                                   ,[pr_item_unitPrice]
                                   ,[pr_item_amount]
                                   ,[pr_item_logOpen_date]
                                   ,[pr_item_logOpen_ip])
                             VALUES
                                   ( '" & pr_ol_tag & "'
                                   ,convert(datetime,'" & DateTimeReq & "',103)
                                   ,'" & Replace(pr_item_suppiler, "'", "''") & "'
                                   ,'" & Replace(pr_item_rfq, "'", "''") & "'
                                   ,'" & Replace(pr_item_detail, "'", "''") & "'
                                   ,'" & Replace(pr_item_job, "'", "''") & "'
                                   ,'" & pr_item_qty & "'
                                   ,'" & pr_item_unitPrice & "'
                                   ,'" & pr_item_amount & "'
                                   ,GETDATE()
                                   ,'" & pr_item_logOpen_ip & "')") Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function InsertLogSendEmail(ByVal prFile As String, ByVal toEmail As String, ByVal reqBy As String, ByVal colName As String, ByVal TypeMessage As String, ByVal status_send As String) As Boolean
        If objDB.ExecuteSQL(" INSERT INTO [dbo].[pr_online_send_log]
                                   ([pr_no]
                                   ,[send_to]
                                   ,[req_by]
                                   ,[to_name]
                                   ,[type_mes]
                                   ,[status_send]
                                   ,[date_send])
                             VALUES
                                   ('" & prFile & "'
                                   ,'" & toEmail & "'
                                   ,'" & reqBy & "'
                                   ,'" & colName & "'
                                   ,'" & TypeMessage & "'
                                   ,'" & status_send & "'
                                   ,GETDATE() )") Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function DeleteItemPR(ByVal pr_ol_tag As String, ByVal pr_ol_req_byID As Integer) As Boolean
        'Insert PR ITEM
        If objDB.ExecuteSQL("DELETE FROM [ART_INTRA].[dbo].[pr_online_item] WHERE [pr_ol_tag] = '" & pr_ol_tag & "'") Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function DeleteTagPR(ByVal pr_ol_tag As String, ByVal pr_ol_req_byID As Integer) As Boolean

        If objDB.ExecuteSQL("DELETE FROM [ART_INTRA].[dbo].[pr_online] WHERE [pr_ol_tag] = '" & Trim(pr_ol_tag) & "' AND pr_ol_req_byID = " & pr_ol_req_byID) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function DeleteItemPRByID(ByVal pr_ol_id As Integer) As Boolean

        If objDB.ExecuteSQL("DELETE FROM [ART_INTRA].[dbo].[pr_online_item] WHERE [pr_item_id] = '" & Trim(pr_ol_id) & "'") Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function UpdatePassword(ByVal pr_ol_id As Integer, ByVal NewPassword As String) As Boolean

        If objDB.ExecuteSQL("UPDATE [dbo].[art_proc_user]  SET  [user_password] = '" & NewPassword & "'  WHERE user_id = " & pr_ol_id) Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function UpdateRemember(ByVal StRemember As Integer, ByVal pr_ol_id As Integer, ByVal HostName As String) As Boolean

        If objDB.ExecuteSQL("UPDATE [dbo].[art_proc_user]  SET  [user_host] = '" & HostName & "' ,   [user_remember] = '" & StRemember & "'  
                              WHERE user_id = " & pr_ol_id) And objDB.ExecuteSQL("UPDATE [dbo].[art_proc_user]  SET  [user_host] = '' ,   [user_remember] = '0'  
                              WHERE user_host = '" & HostName & "' AND  user_id <> " & pr_ol_id) Then

            Return True
        Else
            Return False
        End If

    End Function

    Public Function EditTagPR(ByVal pr_ol_id As Integer, ByVal pr_ol_logEdit_ip As String,
                                 ByVal pr_ol_GlAccount As String, ByVal pr_ol_GlDetail As String, ByVal pr_ol_GlUserID As Integer,
                                 ByVal pr_ol_GlName As String, ByVal pr_ol_GlEmail As String, ByVal pr_ol_gmID As Integer,
                              ByVal pr_ol_gmName As String, ByVal pr_ol_gmEmail As String, ByVal pr_ol_gmStatus As String,
                              ByVal pr_ol_CerNo As String, ByVal pr_ol_Plants As String, ByVal pr_ol_type As Integer) As Boolean
        'Insert PR ONLINE
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
                                SET [pr_ol_prStatus] = 0
                                    ,[pr_ol_logEdit_date] = GETDATE()
                                    ,[pr_ol_logEdit_ip] = '" & pr_ol_logEdit_ip & "'  
                                    ,[pr_ol_StatusEdit]= 1
                                    ,[pr_ol_req_mgrStatus] = 0
                                    ,[pr_ol_req_mgrMsg] = ''
                                    ,[pr_ol_req_mgrDate] = ''
                                    ,[pr_ol_req_mgrIP] = ''
                                    ,[pr_ol_gmID] = " & pr_ol_gmID & "
                                    ,[pr_ol_gmName] = '" & pr_ol_gmName & "' 
                                    ,[pr_ol_gmEmail] = '" & pr_ol_gmEmail & "' 
                                    ,[pr_ol_gmStatus] = '" & pr_ol_gmStatus & "' 
                                    ,[pr_ol_gmMsg] = ''
                                    ,[pr_ol_gmDate] = ''
                                    ,[pr_ol_gmIP] = ''
                                    ,[pr_ol_scMgr_status] = 0
                                    ,[pr_ol_scMgr_msg] = ''
                                    ,[pr_ol_scMgr_date] = ''
                                    ,[pr_ol_scMgr_ip] = ''
                                    ,[pr_ol_GlStatus] = 0
                                    ,[pr_ol_GlMsg] = ''
                                    ,[pr_ol_GlDate] = ''
                                    ,[pr_ol_GlIp] = ''
                                    ,[pr_ol_GlAccount] = '" & pr_ol_GlAccount & "' 
                                    ,[pr_ol_GlDetail] = '" & pr_ol_GlDetail & "' 
                                    ,[pr_ol_GlUserID] = " & pr_ol_GlUserID & "
                                    ,[pr_ol_GlName] = '" & pr_ol_GlName & "' 
                                    ,[pr_ol_GlEmail] = '" & pr_ol_GlEmail & "' 
                                    
                                    ,[pr_ol_CerNo] = '" & pr_ol_CerNo & "' 
                                    ,[pr_ol_Plants] = '" & pr_ol_Plants & "' 
                                    ,[pr_ol_type] = " & pr_ol_type & "
                                WHERE [pr_ol_id] = " & pr_ol_id) Then

            Return True
        Else
            Return False
        End If
    End Function
    Public Function EditStatusPr(ByVal pr_ol_id As Integer, ByVal StatusNo As Integer) As Boolean
        'Insert PR ONLINE
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
                                SET [pr_ol_StatusEdit] = " & StatusNo & "
                                    ,[pr_ol_prStatus] = 0
                                WHERE [pr_ol_id] = " & pr_ol_id) Then

            Return True
        Else
            Return False
        End If
    End Function
    Public Function ChangeStatusPr(ByVal pr_ol_id As Integer, ByVal StatusNo As Integer) As Boolean
        'Insert PR ONLINE
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
                                SET [pr_ol_prStatus] = " & StatusNo & " 
                                WHERE [pr_ol_id] = " & pr_ol_id) Then

            Return True
        Else
            Return False
        End If
    End Function

    Public Function ActionReqMgr(ByVal pr_ol_id As Integer, ByVal UserID As Integer, ByVal typeApprove As Integer, ByVal MsgFeedBack As String,
                                              ByVal IpApprove As String, ByVal PrStatus As Integer, ByVal PrUrgent As Integer) As Boolean

        'Insert PR ONLINE
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
                                 SET   [pr_ol_req_mgrStatus] = " & typeApprove & "
                                      ,[pr_ol_req_mgrMsg] = '" & Replace(MsgFeedBack, "'", "''") & "'
                                      ,[pr_ol_req_mgrDate] = GETDATE()
                                      ,[pr_ol_req_mgrIP] = '" & IpApprove & "'
                                      ,[pr_ol_prStatus] = " & PrStatus & "
                                      ,[pr_ol_urgent] = " & PrUrgent & "
                                 WHERE [pr_ol_id] = '" & pr_ol_id & "' AND [pr_ol_req_mgrID] = " & UserID) Then

            Return True
        Else
            Return False
        End If
    End Function

    Public Function ActionGlMgr(ByVal pr_ol_id As Integer, ByVal UserID As Integer, ByVal typeApprove As Integer, ByVal MsgFeedBack As String,
                                              ByVal IpApprove As String, ByVal PrStatus As Integer, ByVal PrUrgent As Integer) As Boolean
        'Insert PR ONLINE
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
                                 SET   [pr_ol_GlStatus] = " & typeApprove & "
                                      ,[pr_ol_GlMsg] = '" & MsgFeedBack & "'
                                      ,[pr_ol_GlDate] = GETDATE()
                                      ,[pr_ol_GlIp] = '" & IpApprove & "'
                                      ,[pr_ol_prStatus] = " & PrStatus & "
                                 WHERE [pr_ol_id] = '" & pr_ol_id & "' AND [pr_ol_GlUserID] = " & UserID) Then

            Return True
        Else
            Return False
        End If
    End Function

    Public Function ActionGMgr(ByVal pr_ol_id As Integer, ByVal UserID As Integer, ByVal typeApprove As Integer, ByVal MsgFeedBack As String,
                                              ByVal IpApprove As String, ByVal PrStatus As Integer, ByVal PrUrgent As Integer) As Boolean
        'Insert PR ONLINE
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
                                 SET   [pr_ol_gmStatus] = " & typeApprove & "
                                      ,[pr_ol_gmMsg] = '" & MsgFeedBack & "'
                                      ,[pr_ol_gmDate] = GETDATE()
                                      ,[pr_ol_gmIP] = '" & IpApprove & "'
                                      ,[pr_ol_prStatus] = " & PrStatus & "
                                 WHERE [pr_ol_id] = '" & pr_ol_id & "' AND [pr_ol_gmID] = " & UserID) Then

            Return True
        Else
            Return False
        End If
    End Function


    Public Function ActionScMgr(ByVal pr_ol_id As Integer, ByVal TypeApprove As Integer, ByVal pr_ol_scMgr_msg As String, ByVal IpAdress As String, ByVal pr_ol_prStatus As Integer,
                                            ByVal pr_ol_assignPrepare As Integer, ByVal pr_ol_assignPrepareName As String, ByVal pr_ol_assignBy As String, ByVal pr_ol_assignToEmail As String) As Boolean
        'Insert PR ONLINE
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
                               SET [pr_ol_assignPrepare] = " & pr_ol_assignPrepare & "
                                  ,[pr_ol_assignPrepareName] = '" & pr_ol_assignPrepareName & "'
                                  ,[pr_ol_assignToEmail] = '" & pr_ol_assignToEmail & "'
                                  ,[pr_ol_assignDate] =  GETDATE()
                                  ,[pr_ol_assignBy] = '" & pr_ol_assignBy & "'
                                  ,[pr_ol_assignIP] =  '" & IpAdress & "'
                                  ,[pr_ol_scMgr_status] =  " & TypeApprove & "
                                  ,[pr_ol_scMgr_msg] = '" & pr_ol_scMgr_msg & "'
                                  ,[pr_ol_scMgr_date] = GETDATE()
                                  ,[pr_ol_scMgr_ip] = '" & IpAdress & "'
                                  ,[pr_ol_prStatus] = " & pr_ol_prStatus & "
                              WHERE [pr_ol_id] = " & pr_ol_id) Then

            Return True
        Else
            Return False
        End If
    End Function

    Public Function UpdatePurClosePr(ByVal pr_ol_id As Integer, ByVal IpAdress As String) As Boolean
        'Insert PR ONLINE 
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online] 
                               SET [pr_ol_prStatus] = 10
                                  ,[pr_ol_assignCloseDate] = GETDATE()
                                  ,[pr_ol_assignCloseIP] = '" & IpAdress & "'
                              WHERE [pr_ol_id] = " & pr_ol_id) Then

            Return True
        Else
            Return False
        End If
    End Function


    Public Function UpdatePoInItem(ByVal pr_item_id As Integer, ByVal IpAdress As String, ByVal pr_item_poPronto As Integer) As Boolean
        'Insert PR ONLINE 
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online_item]
                               SET [pr_item_poPronto] = " & pr_item_poPronto & "
                                  ,[pr_item_logEdit_date] = GETDATE()
                                  ,[pr_item_logEdit_ip] = '" & IpAdress & "'
                              WHERE [pr_item_id] = " & pr_item_id) Then

            Return True
        Else
            Return False
        End If
    End Function

    Public Function EditActiveTagPR(ByVal pr_ol_id As Integer, ByVal pr_ol_prStatus As Integer) As Boolean
        'Insert PR ONLINE
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
                                SET  [pr_ol_prStatus] = " & pr_ol_prStatus & " 
                                    ,[pr_ol_req_mgrStatus] = 0
                                    ,[pr_ol_req_mgrMsg] = ''
                                    ,[pr_ol_req_mgrDate] = ''
                                    ,[pr_ol_req_mgrIP] = ''
                                      ,[pr_ol_gmStatus] = ''
                                      ,[pr_ol_gmMsg] = ''
                                      ,[pr_ol_GlStatus] = ''
                                      ,[pr_ol_GlMsg] = ''
                                    ,[pr_ol_logEdit_date] = GETDATE()  
                                WHERE [pr_ol_id] = " & pr_ol_id) Then

            Return True
        Else
            Return False
        End If
    End Function
    Public Function EditItemPR(ByVal pr_item_id As String, ByVal pr_item_reqDate As String, ByVal pr_item_detail As String,
                                 ByVal pr_item_job As String, ByVal pr_item_qty As String, ByVal pr_item_unitPrice As String, ByVal pr_item_amount As String,
                                 ByVal pr_item_logEdit_ip As String, ByVal pr_item_suppiler As String, ByVal pr_item_rfq As String) As Boolean
        'Insert PR ITEM
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online_item]
                               SET [pr_item_reqDate] = '" & pr_item_reqDate & "'
                                  ,[pr_item_suppiler] =  '" & pr_item_suppiler & "'
                                  ,[pr_item_rfq] =  '" & pr_item_rfq & "'
                                  ,[pr_item_detail] =  '" & pr_item_detail & "'
                                  ,[pr_item_job] =  '" & pr_item_job & "'
                                  ,[pr_item_qty] =  " & pr_item_qty & "
                                  ,[pr_item_unitPrice] =  " & pr_item_unitPrice & "
                                  ,[pr_item_amount] =  " & pr_item_amount & "
                                  ,[pr_item_logEdit_date] = GETDATE()
                                  ,[pr_item_logEdit_ip] =  '" & pr_item_logEdit_ip & "'
                             WHERE [pr_item_id] = " & pr_item_id) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function EditGmPR(ByVal pr_ol_id As String, ByVal pr_ol_gmName As String, ByVal pr_ol_gmEmail As String, ByVal pr_ol_gmID As Integer, ByVal pr_item_logEdit_ip As String) As Boolean
        'Insert PR ONLINE
        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
                                SET  [pr_ol_gmName] = '" & pr_ol_gmName & "'
                                    ,[pr_ol_gmEmail] = '" & pr_ol_gmEmail & "' 
                                    ,[pr_ol_logEdit_date] = GETDATE()
                                    ,[pr_ol_logEdit_ip] = '" & pr_item_logEdit_ip & "'
                                    ,[pr_ol_gmID] = '" & pr_ol_gmID & "'
                                WHERE [pr_ol_id] = " & pr_ol_id) Then

            Return True
        Else
            Return False
        End If
    End Function




    '    Public Function CancelPR(ByVal pr_ol_id As Integer, ByVal StatusNo As Integer) As Boolean
    '        Dim stCancelStatus As Boolean
    '        Dim stCancelEmail As Boolean
    '        '*********************************
    '        If objDB.ExecuteSQL(" UPDATE [dbo].[pr_online]
    '                                SET [pr_ol_prStatus] = " & StatusNo & " 
    '                                WHERE [pr_ol_id] = " & pr_ol_id) Then

    '            stCancelStatus = True
    '        Else
    '            stCancelStatus = False
    '        End If
    '        '*********************************
    '        Dim OutlookMessage As outlook.MailItem
    '        Dim AppOutlook As outlook.Application
    '        Dim UserRequest As String = colName
    '        Dim strFolderPath As String = "P:/IT/PR Online Attach Files/"
    '        'toEmail = "parkpoom@airradiators.co.th"
    '        Dim SubjectMes, BodyMes As String
    '        Dim UrgentHead, UrgentBody As String
    '        If UrgentStatus = 1 Then
    '            UrgentHead = "Urgent PR !"
    '            UrgentBody = "<p style='color:red'>Urgent PR !</p> <br>"
    '        Else
    '            UrgentHead = ""
    '            UrgentBody = ""
    '        End If

    '        SubjectMes = UrgentHead & "Email from PR Online Create by: " & reqBy
    '        BodyMes = "Dear " & colName & " (Dept. Manager), <br> <br>
    '" & UrgentBody & "
    '<p>Please review and approval in PR online No." & prFile & "  <br>
    'Link: <a href='P:\01 ART Program Center\PR Online\PR Online.exe'>Click!</a> <br>
    'Please don’t’ reply for this email. <br></p>
    ' <br>
    'Best Regards, <br>
    'PR Online Servers <br>
    ' <br>
    '---------------------------------------------------------------- <br>
    ' <br>
    '"

    '        Try
    '            AppOutlook = New outlook.Application
    '            OutlookMessage = AppOutlook.CreateItem(outlook.OlItemType.olMailItem)
    '            AppOutlook = CreateObject("Outlook.Application")
    '            Dim Recipents As outlook.Recipients = OutlookMessage.Recipients
    '            Recipents.Add(toEmail)

    '            OutlookMessage.Subject = SubjectMes
    '            OutlookMessage.HTMLBody = "<html><body>"
    '            OutlookMessage.HTMLBody += BodyMes
    '            OutlookMessage.HTMLBody += "</body></html>"

    '            'If Trim(prFile) <> "" Then
    '            '    If System.IO.File.Exists(strFolderPath & prFile & ".pdf") Then
    '            '        OutlookMessage.Attachments.Add(strFolderPath & prFile & ".pdf")  'Change to atchfiles 
    '            '    End If
    '            'End If

    '            OutlookMessage.Send()

    '            InsertLogSendEmail(prFile, toEmail, reqBy, colName, TypeMessage, "True")
    '            stCancelEmail = True
    '        Catch ex As Exception
    '            InsertLogSendEmail(prFile, toEmail, reqBy, colName, TypeMessage, "False")
    '            stCancelEmail = False
    '        Finally
    '            OutlookMessage = Nothing
    '            AppOutlook = Nothing
    '        End Try
    '        '*********************************  
    '        If (stCancelStatus And stCancelEmail) = True Then
    '            Return True
    '        Else
    '            Return False
    '        End If

    '    End Function

#End Region

#Region "Lock Account PR Online"
    Public Sub UnlockLogin(ByVal uID As Integer)

        Dim INS As Boolean = objDB.ExecuteSQL("
                                                 UPDATE [dbo].[art_proc_user]
                                                   SET  [user_stOnline] = 0
                                                 WHERE  user_id =  " & uID & "
                                               ")
    End Sub

    Public Sub lockLogin(ByVal uID As Integer)
        Dim INS As Boolean = objDB.ExecuteSQL("
                                                 UPDATE [dbo].[art_proc_user]
                                                   SET  [user_stOnline] = 1
                                                 WHERE  user_id =  " & uID & "
                                               ")
    End Sub


    Public Sub UpdateStatusClose()
        Dim StExQ As Boolean = objDB.ExecuteSQL("UPDATE [dbo].[art_proc_noProC] SET  [noProC_closeByServer] = 0 WHERE noProC_id = 1")
    End Sub
    Public Function GetStatusClose() As Integer
        Dim StatusClose As Integer
        Dim dtData As DataTable
        dtData = objDB.SelectSQL("SELECT [noProC_closeByServer]  FROM [ART_INTRA].[dbo].[art_proc_noProC] WHERE noProC_id = 1")
        For i As Integer = 0 To dtData.Rows.Count - 1
            StatusClose = dtData.Rows(0)("noProC_closeByServer")
        Next
        Return StatusClose
    End Function
#End Region



End Class

