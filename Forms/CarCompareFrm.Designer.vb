<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CarCompareFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CarCompareFrm))
        Me.PBox1 = New System.Windows.Forms.PictureBox()
        Me.PBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PBox1
        '
        Me.PBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PBox1.Location = New System.Drawing.Point(509, 0)
        Me.PBox1.Name = "PBox1"
        Me.PBox1.Size = New System.Drawing.Size(480, 377)
        Me.PBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox1.TabIndex = 0
        Me.PBox1.TabStop = False
        '
        'PBox2
        '
        Me.PBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PBox2.Location = New System.Drawing.Point(0, 0)
        Me.PBox2.Name = "PBox2"
        Me.PBox2.Size = New System.Drawing.Size(480, 377)
        Me.PBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox2.TabIndex = 1
        Me.PBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.OliveDrab
        Me.Label1.Location = New System.Drawing.Point(652, 349)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "الصورة اثناء التعاقد"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.OliveDrab
        Me.Label2.Location = New System.Drawing.Point(152, 349)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(201, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "الصورة اثناء الأستلام"
        '
        'CarCompareFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 377)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PBox2)
        Me.Controls.Add(Me.PBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1005, 416)
        Me.Name = "CarCompareFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CarCompareFrm"
        CType(Me.PBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
