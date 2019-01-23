<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnDel = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.CarRentalDBDataSet = New Car_Rental.CarRentalDBDataSet()
        Me.ClassesdesctblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClassesdesctblTableAdapter = New Car_Rental.CarRentalDBDataSetTableAdapters.classesdesctblTableAdapter()
        Me.BtnUndo = New System.Windows.Forms.Button()
        CType(Me.CarRentalDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClassesdesctblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(99, 45)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(200, 22)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "الإعداد العام"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(99, 84)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(200, 22)
        Me.TextBox2.TabIndex = 0
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(305, 84)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(81, 33)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "اضافة"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 14)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "البند"
        '
        'BtnDel
        '
        Me.BtnDel.Location = New System.Drawing.Point(305, 123)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(81, 33)
        Me.BtnDel.TabIndex = 25
        Me.BtnDel.Text = "حذف"
        Me.BtnDel.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(305, 201)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 33)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "اغلاق"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(99, 123)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(200, 270)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 27
        '
        'CarRentalDBDataSet
        '
        Me.CarRentalDBDataSet.DataSetName = "CarRentalDBDataSet"
        Me.CarRentalDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClassesdesctblBindingSource
        '
        Me.ClassesdesctblBindingSource.DataMember = "classesdesctbl"
        Me.ClassesdesctblBindingSource.DataSource = Me.CarRentalDBDataSet
        '
        'ClassesdesctblTableAdapter
        '
        Me.ClassesdesctblTableAdapter.ClearBeforeFill = True
        '
        'BtnUndo
        '
        Me.BtnUndo.Location = New System.Drawing.Point(305, 162)
        Me.BtnUndo.Name = "BtnUndo"
        Me.BtnUndo.Size = New System.Drawing.Size(81, 33)
        Me.BtnUndo.TabIndex = 28
        Me.BtnUndo.Text = "استعادة"
        Me.BtnUndo.UseVisualStyleBackColor = True
        '
        'Frm4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 442)
        Me.Controls.Add(Me.BtnUndo)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtnDel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label5)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm4"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الاعدادات"
        CType(Me.CarRentalDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClassesdesctblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnDel As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents CarRentalDBDataSet As Car_Rental.CarRentalDBDataSet
    Friend WithEvents ClassesdesctblBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClassesdesctblTableAdapter As Car_Rental.CarRentalDBDataSetTableAdapters.classesdesctblTableAdapter
    Friend WithEvents BtnUndo As System.Windows.Forms.Button
End Class
