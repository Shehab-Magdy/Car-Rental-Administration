Imports System.Data
Imports System.Data.SqlClient

Public Class CashManagement
    Sub new_payment()
        RadioButton1.Checked = True
        RadioButton3.Checked = True
        Load_Combobox()
        ComboBox6.Enabled = True
        TextBox1.Enabled = False
        TextBox2.Text = ""
        TextBox6.Text = ""
        TextBox8.Text = ""
        'ComboBox6.Items.Clear()
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today
        RadioButton1.Focus()
        If RadioButton1.Checked Then
            RadioButton1.ForeColor = Color.Red
            RadioButton2.ForeColor = Color.Gray
        End If
        If RadioButton2.Checked Then
            RadioButton2.ForeColor = Color.Red
            RadioButton1.ForeColor = Color.Gray
        End If

    End Sub

    Sub Load_Combobox()
        query = "select code,name from branchestbl where curbranch = 1"
        Dim adapter = New SqlDataAdapter(query, connection)
        Dim dt1 As New Data.DataTable

        Dim query2 As String = "select code,name from BanksTbl where bcode = '100' and del = '0' order by name"
        Dim adapter2 = New SqlDataAdapter(query2, connection)
        Dim dt2 As New DataTable

        Dim query3 As String = "select code,name from MonyDestinationTbl where bcode = '150' and del = '0' order by name"
        Dim adapter3 = New SqlDataAdapter(query3, connection)
        Dim dt3 As New DataTable

        Dim query5 As String = "select code,name from BanksTbl where bcode = '100' and del = '0' order by name"
        Dim adapter5 = New SqlDataAdapter(query5, connection)
        Dim dt5 As New DataTable

        Try
            adapter.Fill(dt1)
            With ComboBox1
                .DataSource = dt1
                .DisplayMember = "name"
                .ValueMember = "code"
            End With

            adapter2.Fill(dt2)
            With ComboBox4
                .DataSource = dt2
                .DisplayMember = "name"
                .ValueMember = "code"
                '.SelectedIndex = -1
            End With

            adapter3.Fill(dt3)
            With ComboBox2
                .DataSource = dt3
                .DisplayMember = "name"
                .ValueMember = "code"
                .SelectedIndex = -1
            End With

            adapter5.Fill(dt5)
            With ComboBox5
                .DataSource = dt5
                .DisplayMember = "name"
                .ValueMember = "code"
                .SelectedValue = 3
                .SelectedIndex = -1
            End With
            ComboBox3.SelectedIndex = -1
            ComboBox6.SelectedIndex = -1

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Frm7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cashfrmload = 0 Then
            Load_Combobox()
            If RadioButton3.Checked = True Then
                TextBox2.Enabled = False
                DateTimePicker2.Enabled = False
                ComboBox4.Enabled = False
                Button1.Enabled = False
            Else
                TextBox2.Enabled = True
                DateTimePicker2.Enabled = True
                ComboBox4.Enabled = True
                Button1.Enabled = True
            End If
        ElseIf cashfrmload = 1 Then
            load_from_Btn()
        End If
        If RadioButton1.Checked Then
            RadioButton1.ForeColor = Color.Red
            RadioButton2.ForeColor = Color.Gray
        End If
        If RadioButton2.Checked Then
            RadioButton2.ForeColor = Color.Red
            RadioButton1.ForeColor = Color.Gray
        End If

    End Sub
    Private Sub load_from_Btn()

    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        TextBox2.Enabled = True
        DateTimePicker2.Enabled = True
        ComboBox4.Enabled = True
        Button1.Enabled = True
        TextBox2.Focus()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
        MainForm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ComboBox2_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox2.DropDownClosed
        Dim query4 As String = ""
        Dim dt4 As New DataTable
        Dim Destination As Integer = ComboBox2.SelectedValue.ToString

        Select Case Destination
            Case 2  'اصحاب السيارات
                query4 = "select code,name from ownertbl order by name"
            Case 1 'عملاء
                query4 = "select code,name from customerstbl order by name"
            Case 3 'مصروفات
                query4 = "select code,name from ExpensesTbl where bcode = '90' and del = '0' order by name"
            Case 4 'شركاء
                query4 = "select code, empname as name from userstbl order by name"
            Case 5 'ايرادات متنوعة
                query4 = "select code, name from MiscIncomeTbl where bcode = '160' and del = '0' order by name"
            Case 6 'تحويلات مالية
                query4 = "select code,name from BanksTbl where bcode = '100' and del = '0' order by name"
            Case Else
                MsgBox("لم يتم اختيار بند صحيح", MsgBoxStyle.Information, "Worng Choice")
        End Select

        Dim adapter4 = New SqlDataAdapter(query4, connection)
        adapter4.Fill(dt4)

        Try
            With ComboBox3
                .DataSource = dt4
                .DisplayMember = "name"
                .ValueMember = "code"
                .SelectedIndex = -1
            End With
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
endline:
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        TextBox2.Enabled = False
        DateTimePicker2.Enabled = False
        ComboBox4.Enabled = False
        Button1.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pubcod = "100"
        Settings.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        new_payment()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Load_Combobox()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim cashtype, branchcode, cashbenefittype, cashbenefit, notes, method, checkno, checkbank, bankcode As String
        Dim value As Decimal
        Dim cashdate, checkdate As DateTime
        Dim command As New SqlCommand
        branchcode = ComboBox1.SelectedValue.ToString
        cashbenefit = ComboBox3.SelectedValue.ToString
        cashbenefittype = ComboBox2.SelectedValue.ToString
        bankcode = ComboBox5.SelectedValue.ToString

        If ComboBox6.SelectedIndex = -1 Then
            carcode = 0
        Else
            carcode = ComboBox6.SelectedValue.ToString
        End If

        If ComboBox4.SelectedIndex = -1 Then
            checkbank = 0
        Else
            checkbank = ComboBox4.SelectedValue.ToString
        End If

        method = 0
        cashtype = 0

        If RadioButton3.Checked = True Then
            method = 10 ' كاش select from CashOrBank
        ElseIf RadioButton4.Checked = True Then
            method = 20 ' شيك select from CashOrBank
        End If

        If RadioButton1.Checked = True Then
            cashtype = 30 'استلاام نقدية select from CashOrBank
        ElseIf RadioButton2.Checked = True Then
            cashtype = 40 'صرف نقدية select from CashOrBank
        End If

        cashdate = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        checkdate = Format(DateTimePicker2.Value, "yyyy-MM-dd")

        value = Val(TextBox6.Text.Trim)
        notes = TextBox8.Text.Trim
        checkno = TextBox2.Text.Trim

        If TextBox1.Text = "" Then
            query = "exec sp_CashSave @cashtype = '" & cashtype & "',@branchcode='" & branchcode & "' ,@bankcode='" & bankcode & "',@cashbenefittype='" & cashbenefittype & "',@cashbenefit='" & cashbenefit & "',@notes='" & notes & "',@method='" & method & "',@checkno='" & checkno & "',@checkbank='" & checkbank & "',@value='" & value & "',@cashdate='" & cashdate & "',@checkdate='" & checkdate & "',@carcode='" & carcode & "'"
        End If
        If TextBox1.Text <> "" Then
            query = "update cashestbl set notes = '" & notes & "' where id = '" & cashcode & "'"
        End If
        If MsgBox("هل انت متأكد من البيانات المدخلة؟", MsgBoxStyle.YesNo, "لا يمكن تعديل البيانات المالية بعد الحفظ") = MsgBoxResult.Yes Then
            Try
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If
                command = New SqlCommand(query, connection)
                command.ExecuteNonQuery()
                connection.Close()
                MsgBox("تم الحفظ")
            Catch ex As Exception
                MsgBox(ex.Message)
                connection.Close()
            End Try

        End If
        

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FindWhat = 7
        FindFrm.Show()
    End Sub


    Private Sub ComboBox3_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox3.DropDownClosed
        Dim query4 As String = ""
        Dim dt4 As New DataTable
        Dim Destination As Integer = ComboBox2.SelectedValue.ToString
        Dim customer As Integer

        If Destination = 1 Then
            customer = ComboBox3.SelectedValue.ToString
            query4 = "select CarCode, CarName from v_carnames where contractcode in (select code from contracttbl where custcode = " & customer & ") and contractstatus = 0"
        ElseIf Destination = 2 Then
            customer = ComboBox3.SelectedValue.ToString
            query4 = "select distinct CarCode, CarName  from v_carnames where ownerid = " & customer
        Else
            ComboBox6.Enabled = False
            ComboBox6.SelectedIndex = -1
            GoTo endline
        End If

        Dim adapter4 = New SqlDataAdapter(query4, connection)
        adapter4.Fill(dt4)

        Try
            With ComboBox6
                .DataSource = dt4
                .DisplayMember = "CarName"
                .ValueMember = "CarCode"
                .SelectedIndex = -1
            End With
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
endline:
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            RadioButton1.ForeColor = Color.Red
            RadioButton2.ForeColor = Color.Gray
        End If
        If RadioButton2.Checked Then
            RadioButton2.ForeColor = Color.Red
            RadioButton1.ForeColor = Color.Gray
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            RadioButton2.ForeColor = Color.Red
            RadioButton1.ForeColor = Color.Gray
        End If
        If RadioButton1.Checked Then
            RadioButton1.ForeColor = Color.Red
            RadioButton2.ForeColor = Color.Gray
        End If

    End Sub
End Class