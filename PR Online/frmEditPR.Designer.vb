<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditPR
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditPR))
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbTotalQty = New System.Windows.Forms.Label()
        Me.lbTotalAmount = New System.Windows.Forms.Label()
        Me.lbGlOwner = New System.Windows.Forms.Label()
        Me.tbPathUpload = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbReqDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbAmount = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbPrice = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbJob = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbGlDe = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbGlAc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbDisc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbRfq = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbDept = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbSupplier = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvEditPR = New System.Windows.Forms.DataGridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lbPrTag = New System.Windows.Forms.Label()
        Me.lbItemID = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbTagID = New System.Windows.Forms.Label()
        Me.btnSaveClose = New System.Windows.Forms.Button()
        Me.lbStatusEdit = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbCERtxt = New System.Windows.Forms.TextBox()
        Me.rbCER1 = New System.Windows.Forms.RadioButton()
        Me.rbPRnoCER = New System.Windows.Forms.RadioButton()
        Me.rbCER3 = New System.Windows.Forms.RadioButton()
        Me.rbMat = New System.Windows.Forms.RadioButton()
        Me.rbASTnoCER = New System.Windows.Forms.RadioButton()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbART1 = New System.Windows.Forms.RadioButton()
        Me.rbART3 = New System.Windows.Forms.RadioButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        CType(Me.dgvEditPR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStatus
        '
        Me.btnStatus.BackColor = System.Drawing.Color.White
        Me.btnStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnStatus.ForeColor = System.Drawing.Color.Black
        Me.btnStatus.Location = New System.Drawing.Point(685, 15)
        Me.btnStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(128, 41)
        Me.btnStatus.TabIndex = 100
        Me.btnStatus.Text = "Server Status"
        Me.btnStatus.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(120, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(522, 41)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "P.R. ( Purchase Request ) Online"
        '
        'lbTotalQty
        '
        Me.lbTotalQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbTotalQty.BackColor = System.Drawing.Color.White
        Me.lbTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbTotalQty.Location = New System.Drawing.Point(507, 720)
        Me.lbTotalQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTotalQty.Name = "lbTotalQty"
        Me.lbTotalQty.Size = New System.Drawing.Size(335, 48)
        Me.lbTotalQty.TabIndex = 179
        Me.lbTotalQty.Text = "Total Q'ty : -"
        Me.lbTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbTotalQty.UseCompatibleTextRendering = True
        '
        'lbTotalAmount
        '
        Me.lbTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbTotalAmount.BackColor = System.Drawing.Color.White
        Me.lbTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbTotalAmount.Location = New System.Drawing.Point(851, 720)
        Me.lbTotalAmount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTotalAmount.Name = "lbTotalAmount"
        Me.lbTotalAmount.Size = New System.Drawing.Size(442, 48)
        Me.lbTotalAmount.TabIndex = 178
        Me.lbTotalAmount.Text = "Total Amount : -"
        Me.lbTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbTotalAmount.UseCompatibleTextRendering = True
        '
        'lbGlOwner
        '
        Me.lbGlOwner.AutoSize = True
        Me.lbGlOwner.BackColor = System.Drawing.Color.White
        Me.lbGlOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbGlOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbGlOwner.Location = New System.Drawing.Point(947, 162)
        Me.lbGlOwner.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbGlOwner.Name = "lbGlOwner"
        Me.lbGlOwner.Size = New System.Drawing.Size(119, 30)
        Me.lbGlOwner.TabIndex = 177
        Me.lbGlOwner.Text = "GL Owner : -"
        Me.lbGlOwner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbGlOwner.UseCompatibleTextRendering = True
        '
        'tbPathUpload
        '
        Me.tbPathUpload.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbPathUpload.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbPathUpload.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbPathUpload.BackColor = System.Drawing.Color.White
        Me.tbPathUpload.Location = New System.Drawing.Point(1105, 251)
        Me.tbPathUpload.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbPathUpload.Multiline = True
        Me.tbPathUpload.Name = "tbPathUpload"
        Me.tbPathUpload.ReadOnly = True
        Me.tbPathUpload.Size = New System.Drawing.Size(187, 30)
        Me.tbPathUpload.TabIndex = 176
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.Location = New System.Drawing.Point(917, 251)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(168, 30)
        Me.Label16.TabIndex = 175
        Me.Label16.Text = "Upload attach file :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label16.UseCompatibleTextRendering = True
        '
        'tbReqDate
        '
        Me.tbReqDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.tbReqDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbReqDate.Location = New System.Drawing.Point(295, 213)
        Me.tbReqDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbReqDate.Name = "tbReqDate"
        Me.tbReqDate.Size = New System.Drawing.Size(161, 29)
        Me.tbReqDate.TabIndex = 174
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(19, 193)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1275, 16)
        Me.Label4.TabIndex = 173
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.Location = New System.Drawing.Point(23, 351)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(227, 48)
        Me.Label14.TabIndex = 172
        Me.Label14.Text = "Total in PR :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label14.UseCompatibleTextRendering = True
        '
        'tbAmount
        '
        Me.tbAmount.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbAmount.BackColor = System.Drawing.Color.White
        Me.tbAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbAmount.Location = New System.Drawing.Point(957, 289)
        Me.tbAmount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbAmount.Multiline = True
        Me.tbAmount.Name = "tbAmount"
        Me.tbAmount.ReadOnly = True
        Me.tbAmount.Size = New System.Drawing.Size(335, 30)
        Me.tbAmount.TabIndex = 171
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(759, 290)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(178, 30)
        Me.Label13.TabIndex = 170
        Me.Label13.Text = "Amount / จำนวนเงิน :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label13.UseCompatibleTextRendering = True
        '
        'tbPrice
        '
        Me.tbPrice.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbPrice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbPrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbPrice.Location = New System.Drawing.Point(548, 290)
        Me.tbPrice.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbPrice.Multiline = True
        Me.tbPrice.Name = "tbPrice"
        Me.tbPrice.Size = New System.Drawing.Size(201, 30)
        Me.tbPrice.TabIndex = 169
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(233, 290)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(287, 30)
        Me.Label12.TabIndex = 168
        Me.Label12.Text = "Estimate Price / ราคาประมาณการ :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label12.UseCompatibleTextRendering = True
        '
        'tbQty
        '
        Me.tbQty.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbQty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbQty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbQty.Location = New System.Drawing.Point(153, 290)
        Me.tbQty.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbQty.Multiline = True
        Me.tbQty.Name = "tbQty"
        Me.tbQty.Size = New System.Drawing.Size(71, 30)
        Me.tbQty.TabIndex = 167
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(23, 290)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 30)
        Me.Label11.TabIndex = 166
        Me.Label11.Text = "Q'ty / จำนวน :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label11.UseCompatibleTextRendering = True
        '
        'tbJob
        '
        Me.tbJob.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbJob.Location = New System.Drawing.Point(188, 251)
        Me.tbJob.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbJob.Multiline = True
        Me.tbJob.Name = "tbJob"
        Me.tbJob.Size = New System.Drawing.Size(720, 30)
        Me.tbJob.TabIndex = 165
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 251)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 30)
        Me.Label10.TabIndex = 164
        Me.Label10.Text = "Job / การใช้งาน : "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.UseCompatibleTextRendering = True
        '
        'tbGlDe
        '
        Me.tbGlDe.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbGlDe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbGlDe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbGlDe.BackColor = System.Drawing.SystemColors.Control
        Me.tbGlDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGlDe.Location = New System.Drawing.Point(663, 162)
        Me.tbGlDe.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbGlDe.Multiline = True
        Me.tbGlDe.Name = "tbGlDe"
        Me.tbGlDe.ReadOnly = True
        Me.tbGlDe.Size = New System.Drawing.Size(275, 30)
        Me.tbGlDe.TabIndex = 163
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(400, 162)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(238, 30)
        Me.Label9.TabIndex = 162
        Me.Label9.Text = "GL. Detail / รายละเอียดรหัส : "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.UseCompatibleTextRendering = True
        '
        'tbGlAc
        '
        Me.tbGlAc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbGlAc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbGlAc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbGlAc.Location = New System.Drawing.Point(259, 162)
        Me.tbGlAc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbGlAc.Name = "tbGlAc"
        Me.tbGlAc.Size = New System.Drawing.Size(132, 29)
        Me.tbGlAc.TabIndex = 161
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 162)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(213, 30)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "GL. Account / รหัสสินค้า :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.UseCompatibleTextRendering = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 213)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(263, 30)
        Me.Label7.TabIndex = 159
        Me.Label7.Text = "Require Date / วันที่ต้องการ :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label7.UseCompatibleTextRendering = True
        '
        'tbDisc
        '
        Me.tbDisc.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbDisc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbDisc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbDisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbDisc.Location = New System.Drawing.Point(712, 213)
        Me.tbDisc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbDisc.Multiline = True
        Me.tbDisc.Name = "tbDisc"
        Me.tbDisc.Size = New System.Drawing.Size(580, 30)
        Me.tbDisc.TabIndex = 158
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(467, 213)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(222, 30)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "Discription / รายการสินค้า :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.UseCompatibleTextRendering = True
        '
        'tbRfq
        '
        Me.tbRfq.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbRfq.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbRfq.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbRfq.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbRfq.Location = New System.Drawing.Point(1153, 80)
        Me.tbRfq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbRfq.Multiline = True
        Me.tbRfq.Name = "tbRfq"
        Me.tbRfq.Size = New System.Drawing.Size(139, 30)
        Me.tbRfq.TabIndex = 156
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(1049, 80)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 30)
        Me.Label3.TabIndex = 155
        Me.Label3.Text = "RFQ No :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label3.UseCompatibleTextRendering = True
        '
        'tbDept
        '
        Me.tbDept.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbDept.BackColor = System.Drawing.SystemColors.Control
        Me.tbDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbDept.Location = New System.Drawing.Point(825, 80)
        Me.tbDept.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbDept.Multiline = True
        Me.tbDept.Name = "tbDept"
        Me.tbDept.ReadOnly = True
        Me.tbDept.Size = New System.Drawing.Size(215, 30)
        Me.tbDept.TabIndex = 154
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(601, 80)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 30)
        Me.Label2.TabIndex = 153
        Me.Label2.Text = "Requested from Dept :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label2.UseCompatibleTextRendering = True
        '
        'tbSupplier
        '
        Me.tbSupplier.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbSupplier.BackColor = System.Drawing.Color.White
        Me.tbSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbSupplier.Location = New System.Drawing.Point(249, 80)
        Me.tbSupplier.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbSupplier.Name = "tbSupplier"
        Me.tbSupplier.Size = New System.Drawing.Size(343, 29)
        Me.tbSupplier.TabIndex = 152
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 80)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(205, 30)
        Me.Label6.TabIndex = 151
        Me.Label6.Text = "Recommend Supplier :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label6.UseCompatibleTextRendering = True
        '
        'dgvEditPR
        '
        Me.dgvEditPR.AllowUserToAddRows = False
        Me.dgvEditPR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEditPR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEditPR.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEditPR.Location = New System.Drawing.Point(23, 423)
        Me.dgvEditPR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvEditPR.Name = "dgvEditPR"
        Me.dgvEditPR.ReadOnly = True
        Me.dgvEditPR.RowHeadersWidth = 51
        Me.dgvEditPR.Size = New System.Drawing.Size(1279, 283)
        Me.dgvEditPR.TabIndex = 150
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(23, 711)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(245, 171)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 180
        Me.PictureBox2.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(1089, 350)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(204, 48)
        Me.btnEdit.TabIndex = 183
        Me.btnEdit.Text = "Edit PR"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnDel.Location = New System.Drawing.Point(640, 350)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(204, 48)
        Me.btnDel.TabIndex = 182
        Me.btnDel.Text = "Delete from PR"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(467, 350)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(165, 48)
        Me.btnAdd.TabIndex = 181
        Me.btnAdd.Text = "Add to PR"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lbPrTag
        '
        Me.lbPrTag.AutoSize = True
        Me.lbPrTag.BackColor = System.Drawing.Color.White
        Me.lbPrTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbPrTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbPrTag.Location = New System.Drawing.Point(1049, 20)
        Me.lbPrTag.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbPrTag.Name = "lbPrTag"
        Me.lbPrTag.Size = New System.Drawing.Size(93, 30)
        Me.lbPrTag.TabIndex = 184
        Me.lbPrTag.Text = "PR No. : -"
        Me.lbPrTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbPrTag.UseCompatibleTextRendering = True
        '
        'lbItemID
        '
        Me.lbItemID.AutoSize = True
        Me.lbItemID.BackColor = System.Drawing.Color.White
        Me.lbItemID.Location = New System.Drawing.Point(259, 382)
        Me.lbItemID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbItemID.Name = "lbItemID"
        Me.lbItemID.Size = New System.Drawing.Size(14, 16)
        Me.lbItemID.TabIndex = 185
        Me.lbItemID.Text = "0"
        Me.lbItemID.Visible = False
        '
        'Label17
        '
        Me.Label17.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(5, 11)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(1309, 875)
        Me.Label17.TabIndex = 186
        '
        'lbTagID
        '
        Me.lbTagID.AutoSize = True
        Me.lbTagID.BackColor = System.Drawing.Color.White
        Me.lbTagID.Location = New System.Drawing.Point(259, 350)
        Me.lbTagID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTagID.Name = "lbTagID"
        Me.lbTagID.Size = New System.Drawing.Size(56, 16)
        Me.lbTagID.TabIndex = 187
        Me.lbTagID.Text = "lbTagID"
        Me.lbTagID.Visible = False
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnSaveClose.Location = New System.Drawing.Point(1049, 795)
        Me.btnSaveClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(244, 71)
        Me.btnSaveClose.TabIndex = 188
        Me.btnSaveClose.Text = "Resubmit"
        Me.btnSaveClose.UseVisualStyleBackColor = True
        '
        'lbStatusEdit
        '
        Me.lbStatusEdit.Location = New System.Drawing.Point(859, 370)
        Me.lbStatusEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lbStatusEdit.Name = "lbStatusEdit"
        Me.lbStatusEdit.Size = New System.Drawing.Size(132, 22)
        Me.lbStatusEdit.TabIndex = 192
        Me.lbStatusEdit.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.tbCERtxt)
        Me.Panel2.Controls.Add(Me.rbCER1)
        Me.Panel2.Controls.Add(Me.rbPRnoCER)
        Me.Panel2.Controls.Add(Me.rbCER3)
        Me.Panel2.Controls.Add(Me.rbMat)
        Me.Panel2.Controls.Add(Me.rbASTnoCER)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Location = New System.Drawing.Point(419, 118)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(877, 33)
        Me.Panel2.TabIndex = 196
        '
        'tbCERtxt
        '
        Me.tbCERtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.tbCERtxt.Location = New System.Drawing.Point(560, 2)
        Me.tbCERtxt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbCERtxt.Name = "tbCERtxt"
        Me.tbCERtxt.Size = New System.Drawing.Size(164, 29)
        Me.tbCERtxt.TabIndex = 159
        '
        'rbCER1
        '
        Me.rbCER1.AutoSize = True
        Me.rbCER1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rbCER1.Location = New System.Drawing.Point(289, 4)
        Me.rbCER1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbCER1.Name = "rbCER1"
        Me.rbCER1.Size = New System.Drawing.Size(112, 24)
        Me.rbCER1.TabIndex = 160
        Me.rbCER1.TabStop = True
        Me.rbCER1.Text = "CER ART1"
        Me.rbCER1.UseVisualStyleBackColor = True
        '
        'rbPRnoCER
        '
        Me.rbPRnoCER.AutoSize = True
        Me.rbPRnoCER.Checked = True
        Me.rbPRnoCER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rbPRnoCER.Location = New System.Drawing.Point(8, 4)
        Me.rbPRnoCER.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbPRnoCER.Name = "rbPRnoCER"
        Me.rbPRnoCER.Size = New System.Drawing.Size(116, 24)
        Me.rbPRnoCER.TabIndex = 164
        Me.rbPRnoCER.TabStop = True
        Me.rbPRnoCER.Text = "PR no CER"
        Me.rbPRnoCER.UseVisualStyleBackColor = True
        '
        'rbCER3
        '
        Me.rbCER3.AutoSize = True
        Me.rbCER3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rbCER3.Location = New System.Drawing.Point(425, 4)
        Me.rbCER3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbCER3.Name = "rbCER3"
        Me.rbCER3.Size = New System.Drawing.Size(112, 24)
        Me.rbCER3.TabIndex = 161
        Me.rbCER3.TabStop = True
        Me.rbCER3.Text = "CER ART3"
        Me.rbCER3.UseVisualStyleBackColor = True
        '
        'rbMat
        '
        Me.rbMat.AutoSize = True
        Me.rbMat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rbMat.Location = New System.Drawing.Point(769, 4)
        Me.rbMat.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbMat.Name = "rbMat"
        Me.rbMat.Size = New System.Drawing.Size(90, 24)
        Me.rbMat.TabIndex = 163
        Me.rbMat.TabStop = True
        Me.rbMat.Text = "Material"
        Me.rbMat.UseVisualStyleBackColor = True
        '
        'rbASTnoCER
        '
        Me.rbASTnoCER.AutoSize = True
        Me.rbASTnoCER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rbASTnoCER.Location = New System.Drawing.Point(139, 4)
        Me.rbASTnoCER.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbASTnoCER.Name = "rbASTnoCER"
        Me.rbASTnoCER.Size = New System.Drawing.Size(136, 24)
        Me.rbASTnoCER.TabIndex = 162
        Me.rbASTnoCER.Text = "Asset no CER"
        Me.rbASTnoCER.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(733, -5)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(26, 39)
        Me.Label19.TabIndex = 157
        Me.Label19.Text = "|"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.rbART1)
        Me.Panel1.Controls.Add(Me.rbART3)
        Me.Panel1.Location = New System.Drawing.Point(181, 122)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(228, 27)
        Me.Panel1.TabIndex = 195
        '
        'rbART1
        '
        Me.rbART1.AutoSize = True
        Me.rbART1.Checked = True
        Me.rbART1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rbART1.Location = New System.Drawing.Point(4, 0)
        Me.rbART1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbART1.Name = "rbART1"
        Me.rbART1.Size = New System.Drawing.Size(100, 24)
        Me.rbART1.TabIndex = 154
        Me.rbART1.TabStop = True
        Me.rbART1.Text = "PR ART1"
        Me.rbART1.UseVisualStyleBackColor = True
        '
        'rbART3
        '
        Me.rbART3.AutoSize = True
        Me.rbART3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rbART3.Location = New System.Drawing.Point(119, 0)
        Me.rbART3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbART3.Name = "rbART3"
        Me.rbART3.Size = New System.Drawing.Size(100, 24)
        Me.rbART3.TabIndex = 155
        Me.rbART3.TabStop = True
        Me.rbART3.Text = "PR ART3"
        Me.rbART3.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.White
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label20.Location = New System.Drawing.Point(23, 119)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(146, 30)
        Me.Label20.TabIndex = 194
        Me.Label20.Text = "Type PR-Online"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label20.UseCompatibleTextRendering = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(404, 112)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(26, 39)
        Me.Label18.TabIndex = 193
        Me.Label18.Text = "|"
        '
        'frmEditPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(1319, 897)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lbStatusEdit)
        Me.Controls.Add(Me.btnSaveClose)
        Me.Controls.Add(Me.lbTagID)
        Me.Controls.Add(Me.lbItemID)
        Me.Controls.Add(Me.lbPrTag)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lbTotalQty)
        Me.Controls.Add(Me.lbTotalAmount)
        Me.Controls.Add(Me.lbGlOwner)
        Me.Controls.Add(Me.tbPathUpload)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.tbReqDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tbAmount)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tbPrice)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tbQty)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tbJob)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tbGlDe)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbGlAc)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbDisc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbRfq)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbDept)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbSupplier)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvEditPR)
        Me.Controls.Add(Me.btnStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label17)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmEditPR"
        Me.Text = "P.R. ( Purchase Request ) Online"
        CType(Me.dgvEditPR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStatus As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lbTotalQty As Label
    Friend WithEvents lbTotalAmount As Label
    Friend WithEvents lbGlOwner As Label
    Friend WithEvents tbPathUpload As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents tbReqDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents tbAmount As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tbPrice As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tbQty As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents tbJob As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tbGlDe As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbGlAc As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tbDisc As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbRfq As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbDept As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbSupplier As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvEditPR As DataGridView
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDel As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents lbPrTag As Label
    Friend WithEvents lbItemID As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lbTagID As Label
    Friend WithEvents btnSaveClose As Button
    Friend WithEvents lbStatusEdit As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tbCERtxt As TextBox
    Friend WithEvents rbCER1 As RadioButton
    Friend WithEvents rbPRnoCER As RadioButton
    Friend WithEvents rbCER3 As RadioButton
    Friend WithEvents rbMat As RadioButton
    Friend WithEvents rbASTnoCER As RadioButton
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbART1 As RadioButton
    Friend WithEvents rbART3 As RadioButton
    Friend WithEvents Label20 As Label
    Friend WithEvents Label18 As Label
End Class
