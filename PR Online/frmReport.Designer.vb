<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReport
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.pr_onlineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DatasetPrTag = New PR_Online.DatasetPrTag()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.pr_onlineTableAdapter = New PR_Online.DatasetPrTagTableAdapters.pr_onlineTableAdapter()
        CType(Me.pr_onlineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetPrTag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pr_onlineBindingSource
        '
        Me.pr_onlineBindingSource.DataMember = "pr_online"
        Me.pr_onlineBindingSource.DataSource = Me.DatasetPrTag
        '
        'DatasetPrTag
        '
        Me.DatasetPrTag.DataSetName = "DatasetPrTag"
        Me.DatasetPrTag.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetPR_online_Tag"
        ReportDataSource1.Value = Me.pr_onlineBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.ServerReport.ReportPath = "P:\01 ART Program Center\PR Online\reportPR.rdlc"
        Me.ReportViewer1.ServerReport.ReportServerUrl = New System.Uri("", System.UriKind.Relative)
        Me.ReportViewer1.Size = New System.Drawing.Size(997, 593)
        Me.ReportViewer1.TabIndex = 0
        '
        'pr_onlineTableAdapter
        '
        Me.pr_onlineTableAdapter.ClearBeforeFill = True
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 593)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmReport"
        Me.Text = "Report PR online"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pr_onlineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetPrTag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents pr_onlineBindingSource As BindingSource
    Friend WithEvents DatasetPrTag As DatasetPrTag
    Friend WithEvents pr_onlineTableAdapter As DatasetPrTagTableAdapters.pr_onlineTableAdapter
End Class
