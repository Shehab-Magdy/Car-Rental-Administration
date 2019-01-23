Imports System.Data
Imports System.Data.SqlClient

Public Class customers
    Dim command As New SqlCommand
    Sub Load_customer_from_btn()
        query = "SELECT cust.code as code, cust.name as custname, cust.address as address, cust.jobtitle as jobtitle, nat.name as nationality, cust.tel1 as tel1, cust.tel2 as tel2, cust.tel3 as tel3, cust.dofbirth as dofbirth, ct.name as custtype, cust.notes, idt.name as idtype, cust.idno, cust.idsource, cust.idvalid,dlt.name as lictype, cust.licno, cust.licsource, cust.licvalid, ft.name as fromtype, cust.fromname, cust.fromphone FROM customerstbl as cust, NatonalityTbl as nat, CustTypeTbl as ct, IdTypeTbl as idt, DriveLicTypeTbl as dlt, HowtoKnowTbl as ft WHERE nat.code = cust.nationality and ct.code=cust.custtype and idt.code = cust.idtype and dlt.code=cust.lictype and ft.code = cust.fromtype and cust.code = '" & custcode & "'"
        Dim dtcustomers As New DataTable
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            dtcustomers.Clear()
            command = New SqlCommand(query, connection)
            dtcustomers.Load(command.ExecuteReader)
            connection.Close()
            TextBox1.Text = dtcustomers.Rows(0).Item("code").ToString
            TextBox2.Text = dtcustomers.Rows(0).Item("custname").ToString
            TextBox3.Text = dtcustomers.Rows(0).Item("address").ToString
            TextBox4.Text = dtcustomers.Rows(0).Item("jobtitle").ToString
            TextBox5.Text = dtcustomers.Rows(0).Item("tel1").ToString
            TextBox6.Text = dtcustomers.Rows(0).Item("tel2").ToString
            TextBox7.Text = dtcustomers.Rows(0).Item("tel3").ToString
            TextBox8.Text = dtcustomers.Rows(0).Item("notes").ToString
            TextBox9.Text = dtcustomers.Rows(0).Item("idno").ToString
            TextBox10.Text = dtcustomers.Rows(0).Item("idsource").ToString
            TextBox11.Text = dtcustomers.Rows(0).Item("licno").ToString
            TextBox12.Text = dtcustomers.Rows(0).Item("licsource").ToString
            TextBox13.Text = dtcustomers.Rows(0).Item("fromname").ToString
            TextBox14.Text = dtcustomers.Rows(0).Item("fromphone").ToString

            DateTimePicker1.Value = dtcustomers.Rows(0).Item("dofbirth").ToString
            DateTimePicker2.Value = dtcustomers.Rows(0).Item("idvalid").ToString
            DateTimePicker3.Value = dtcustomers.Rows(0).Item("licvalid").ToString

            ComboBox1.Text = dtcustomers.Rows(0).Item("nationality").ToString
            ComboBox2.Text = dtcustomers.Rows(0).Item("custtype").ToString
            ComboBox3.Text = dtcustomers.Rows(0).Item("fromtype").ToString
            ComboBox4.Text = dtcustomers.Rows(0).Item("lictype").ToString
            ComboBox5.Text = dtcustomers.Rows(0).Item("idtype").ToString

        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Sub New_customer()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker3.Text = Today

        TextBox2.Focus()
    End Sub

    Sub Load_Combobox()

        query = "select code,name from NatonalityTbl where bcode= '10' and del = '0' order by name"
        Dim adapter = New SqlDataAdapter(query, connection)

        Dim query2 As String = "select code,name from CustTypeTbl where bcode = '20' and del = '0' order by name"
        Dim adapter2 = New SqlDataAdapter(query2, connection)
        Dim dt2 As New DataTable

        Dim query3 As String = "select code,name from HowtoKnowTbl where bcode = '50' and del = '0' order by name"
        Dim adapter3 = New SqlDataAdapter(query3, connection)
        Dim dt3 As New DataTable

        Dim query4 As String = "select code,name from DriveLicTypeTbl where bcode = '70' and del = '0' order by name"
        Dim adapter4 = New SqlDataAdapter(query4, connection)
        Dim dt4 As New DataTable

        Dim query5 As String = "select code,name from IdTypeTbl where bcode = '60' and del = '0' order by name"
        Dim adapter5 = New SqlDataAdapter(query5, connection)
        Dim dt5 As New DataTable

        Try
            Dim dtable As New Data.DataTable
            dtable.Clear()
            adapter.Fill(dtable)
            With ComboBox1
                .DataSource = dtable
                .DisplayMember = "name"
                .ValueMember = "code"
            End With

            adapter2.Fill(dt2)
            With ComboBox2
                .DataSource = dt2
                .DisplayMember = "name"
                .ValueMember = "code"
            End With

            adapter3.Fill(dt3)
            With ComboBox3
                .DataSource = dt3
                .DisplayMember = "name"
                .ValueMember = "code"
            End With

            adapter4.Fill(dt4)
            With ComboBox4
                .DataSource = dt4
                .DisplayMember = "name"
                .ValueMember = "code"
            End With

            adapter5.Fill(dt5)
            With ComboBox5
                .DataSource = dt5
                .DisplayMember = "name"
                .ValueMember = "code"
            End With

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CustomerFrmLoad = 0 Then
            Load_Combobox()
        ElseIf CustomerFrmLoad = 1 Then
            Load_customer_from_btn()
        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
        MainForm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pubcod = "10"
        Settings.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pubcod = "20"
        Settings.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        pubcod = "60"
        Settings.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pubcod = "70"
        Settings.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pubcod = "50"
        Settings.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        New_customer()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim nam, addr, job, nation, pho1, pho2, pho3, custtype, notes, idtype, idno, idsorc, drlictype, drlicno, drlicsorc, knowtype, knownam, knowphon As String
        Dim bofdate, idvalid, drlicvalid As Date

        nation = ComboBox1.SelectedValue.ToString
        custtype = ComboBox2.SelectedValue.ToString
        knowtype = ComboBox3.SelectedValue.ToString
        drlictype = ComboBox4.SelectedValue.ToString
        idtype = ComboBox5.SelectedValue.ToString

        bofdate = DateTimePicker1.Value
        idvalid = DateTimePicker2.Value
        drlicvalid = DateTimePicker3.Value

        nam = TextBox2.Text
        addr = TextBox3.Text
        job = TextBox4.Text
        pho1 = TextBox5.Text
        pho2 = TextBox6.Text
        pho3 = TextBox7.Text
        notes = TextBox8.Text
        idno = TextBox9.Text
        idsorc = TextBox10.Text
        drlicno = TextBox11.Text
        drlicsorc = TextBox12.Text
        knownam = TextBox13.Text
        knowphon = TextBox14.Text

        If TextBox1.Text = "" Then
            query = "exec SP_CustomerSave @nam = '" & nam & "',@addr='" & addr & "',@pho1='" & pho1 & "',@pho2='" & pho2 & "',@job='" & job & "',@nation='" & nation & "',@pho3='" & pho3 & "',@custtype='" & custtype & "',@notes='" & notes & "',@idtype='" & idtype & "',@idno='" & idno & "',@idsorc='" & idsorc & "',@drlictype='" & drlictype & "',@drlicno='" & drlicno & "',@drlicsorc='" & drlicsorc & "',@knowtype='" & knowtype & "',@knownam='" & knownam & "',@knowphon='" & knowphon & "',@bofdate='" & bofdate & "',@idvalid='" & idvalid & "',@drlicvalid='" & drlicvalid & "'"
        End If

        If TextBox1.Text <> "" Then
            query = "update customerstbl set name = '" & nam & "', address = '" & addr & "', jobtitle = '" & job & "', nationality = '" & nation & "', tel1 = '" & pho1 & "', tel2 = '" & pho2 & "', tel3 = '" & pho3 & "', dofbirth = '" & bofdate & "', custtype = '" & custtype & "', notes = '" & notes & "', IdType = '" & idtype & "', idno = '" & idno & "', idsource = '" & idsorc & "', idvalid = '" & idvalid & "', lictype = '" & drlictype & "', licno = '" & drlicno & "', licsource = '" & drlicsorc & "', licvalid = '" & drlicvalid & "', fromtype = '" & knowtype & "', fromname = '" & knownam & "', fromphone  = '" & knowphon & "' where code = '" & custcode & "'"
        End If

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

        New_customer()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Load_Combobox()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        RentCar.Show()
        Me.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FindWhat = 1
        FindFrm.Show()
    End Sub
End Class
