<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePass
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePass))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb_id = New System.Windows.Forms.TextBox()
        Me.tbConNewpass = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbNewpass = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.tb_password = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_username = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_red = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tb_id)
        Me.GroupBox1.Controls.Add(Me.tbConNewpass)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbNewpass)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnChange)
        Me.GroupBox1.Controls.Add(Me.tb_password)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tb_username)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(39, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 214)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Change Password"
        '
        'tb_id
        '
        Me.tb_id.Location = New System.Drawing.Point(23, 175)
        Me.tb_id.Name = "tb_id"
        Me.tb_id.ReadOnly = True
        Me.tb_id.Size = New System.Drawing.Size(52, 21)
        Me.tb_id.TabIndex = 10
        Me.tb_id.Visible = False
        '
        'tbConNewpass
        '
        Me.tbConNewpass.Location = New System.Drawing.Point(121, 130)
        Me.tbConNewpass.Name = "tbConNewpass"
        Me.tbConNewpass.Size = New System.Drawing.Size(193, 21)
        Me.tbConNewpass.TabIndex = 9
        Me.tbConNewpass.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Confirm Password"
        '
        'tbNewpass
        '
        Me.tbNewpass.Location = New System.Drawing.Point(121, 95)
        Me.tbNewpass.Name = "tbNewpass"
        Me.tbNewpass.Size = New System.Drawing.Size(193, 21)
        Me.tbNewpass.TabIndex = 7
        Me.tbNewpass.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "New Password"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(239, 169)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 33)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(103, 169)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(128, 33)
        Me.btnChange.TabIndex = 4
        Me.btnChange.Text = "Change Password"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'tb_password
        '
        Me.tb_password.Location = New System.Drawing.Point(121, 60)
        Me.tb_password.Name = "tb_password"
        Me.tb_password.Size = New System.Drawing.Size(193, 21)
        Me.tb_password.TabIndex = 3
        Me.tb_password.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Old Password"
        '
        'tb_username
        '
        Me.tb_username.Location = New System.Drawing.Point(121, 27)
        Me.tb_username.Name = "tb_username"
        Me.tb_username.ReadOnly = True
        Me.tb_username.Size = New System.Drawing.Size(193, 21)
        Me.tb_username.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Username"
        '
        'lb_red
        '
        Me.lb_red.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_red.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lb_red.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_red.Location = New System.Drawing.Point(-6, -1)
        Me.lb_red.Name = "lb_red"
        Me.lb_red.Size = New System.Drawing.Size(452, 78)
        Me.lb_red.TabIndex = 90
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Location = New System.Drawing.Point(-6, 226)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(452, 88)
        Me.Label4.TabIndex = 91
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(416, 31)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "P.R. ( Purchase Request ) Online"
        '
        'frmChangePass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 313)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lb_red)
        Me.Controls.Add(Me.Label4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChangePass"
        Me.Text = "P.R. ( Purchase Request ) Online"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tb_id As TextBox
    Friend WithEvents tbConNewpass As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbNewpass As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnChange As Button
    Friend WithEvents tb_password As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tb_username As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lb_red As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
End Class
