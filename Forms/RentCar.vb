Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Public Class RentCar
    Dim command As New SqlCommand
    Dim dt1 As New DataTable
    Dim dt2 As New DataTable
    Dim dt3 As New DataTable
    Dim dt4 As New DataTable
    Dim dt5 As New DataTable
    Dim dt6 As New DataTable

    Dim query6 As String
    Dim mreader As SqlDataReader
    Dim cmd As New SqlCommand
    Dim reader2 As SqlDataReader
    Dim cmd2 As New SqlCommand

    Dim cartype As String
    Dim carmodel As String
    Dim picname As String

    Dim date1 As Date
    Dim date2 As Date
    Dim periodOfRent As Int32

    Sub Calc_total()
        Label38.Text = (Val(TextBox16.Text) * Val(TextBox19.Text)) + Val(TextBox23.Text)
    End Sub

    Sub Start_new()

        ComboBox1.Focus()

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
        TextBox15.Text = ""
        TextBox22.Text = ""

        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""

        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today
        DateTimePicker3.Value = Today

        dt2.Clear()
        dt3.Clear()
        dt4.Clear()
        dt5.Clear()

        PBox1.BackgroundImage = Nothing
        PBox2.BackgroundImage = Nothing
        PBox3.BackgroundImage = Nothing
        PBox4.BackgroundImage = Nothing
        PBox11.BackgroundImage = Nothing
        PBox22.BackgroundImage = Nothing
        PBox33.BackgroundImage = Nothing
        PBox44.BackgroundImage = Nothing

    End Sub

    Sub Calcperiod()
        date1 = DateTimePicker2.Value
        date2 = DateTimePicker3.Value
        periodOfRent = date2.Subtract(date1).Days + 1

    End Sub

    Sub Load_Combobox()
        query = "select code,name from branchestbl where curbranch = 1"
        Dim adapter = New SqlDataAdapter(query, connection)

        Try
            dt1.Clear()
            adapter.Fill(dt1)
            With ComboBox1
                .DataSource = dt1
                .DisplayMember = "name"
                .ValueMember = "code"
            End With

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Sub Load_combo2()
        Dim query2 As String = "select code,name from customerstbl order by name"
        Dim adapter2 As New SqlDataAdapter(query2, connection)

        dt2.Clear()
        adapter2.Fill(dt2)
        With ComboBox2
            .DataSource = dt2
            .ValueMember = "code"
            .DisplayMember = "name"
        End With

    End Sub

    Sub Load_combo3()
        Dim query3 As String = "select code,name from CarTypeTbl where code in (select distinct(ctype) from carstbl) and bcode = '30' order by name"
        command = New SqlCommand(query3, connection)

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            dt3.Clear()
            dt3.Load(command.ExecuteReader)
            With ComboBox3
                .DataSource = dt3
                .DisplayMember = "name"
                .ValueMember = "code"
            End With
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub

    Sub Load_combo4()
        Dim query4 As String = "select carmodelcode, carmodelname from carmodelstbl where carmodelcode in (select distinct(cmodel) from carstbl) and carcode = '" & cartype & "'and del = '0' order by carmodelname "
        Dim adapter4 As New SqlDataAdapter(query4, connection)
        Try
            dt4.Clear()
            adapter4.Fill(dt4)
            With ComboBox4
                .DataSource = dt4
                .DisplayMember = "carmodelname"
                .ValueMember = "carmodelcode"
            End With
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Sub Load_combo5()
        Dim query5 As String = "select code, licpno from carstbl where ctype='" & cartype & "' and cmodel ='" & carmodel & "'order by code"
        Dim adapter5 As New SqlDataAdapter(query5, connection)

        Try
            dt5.Clear()
            adapter5.Fill(dt5)
            With ComboBox5
                .DataSource = dt5
                .DisplayMember = "licpno"
                .ValueMember = "code"
            End With
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub

    Private Sub Frm3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Combobox()
        ComboBox1.Focus()
        Dim vartoday As Date
        date2 = DateTimePicker3.Value
        vartoday = date2.AddDays(1)
        DateTimePicker3.Value = vartoday


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MainForm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ComboBox2_GotFocus(sender As Object, e As EventArgs) Handles ComboBox2.GotFocus
        Load_combo2()

    End Sub

    Private Sub ComboBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox2.MouseClick
        Load_combo2()
    End Sub

    Private Sub ComboBox2_LostFocus(sender As Object, e As EventArgs) Handles ComboBox2.LostFocus
        ComboBox3.Focus()
    End Sub

    Private Sub ComboBox3_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox3.DropDownClosed
        ComboBox4.Enabled = True
    End Sub

    Private Sub ComboBox3_GotFocus(sender As Object, e As EventArgs) Handles ComboBox3.GotFocus
        Load_combo3()
    End Sub

    Private Sub ComboBox3_LostFocus(sender As Object, e As EventArgs) Handles ComboBox3.LostFocus
        cartype = ComboBox3.SelectedValue.ToString
        ComboBox4.Enabled = True
        ComboBox4.Focus()
    End Sub

    Private Sub ComboBox4_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox4.DropDownClosed
        ComboBox5.Enabled = True
    End Sub

    Private Sub ComboBox4_GotFocus(sender As Object, e As EventArgs) Handles ComboBox4.GotFocus
        Load_combo4()
    End Sub

    Private Sub ComboBox4_LostFocus(sender As Object, e As EventArgs) Handles ComboBox4.LostFocus
        carmodel = ComboBox4.SelectedValue.ToString
        ComboBox5.Focus()
    End Sub

    Private Sub ComboBox5_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox5.DropDownClosed
        carcode = ComboBox5.SelectedValue.ToString

        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
        cmd2.CommandType = CommandType.Text
        cmd2.CommandText = "select CarLicTypeTbl.name, CarsTbl.licdend, ColorsTbl.name, CarsTbl.dayprice, CarsTbl.kmperday, CarConditionTbl.name, CarsTbl.notes from CarsTbl, CarLicTypeTbl, ColorsTbl, CarConditionTbl where carstbl.lictype=carlictypetbl.code and carstbl.carcolor= ColorsTbl.code and carstbl.carstatus= CarConditionTbl.code  and CarsTbl.code = '" & carcode & "'"
        cmd2.Connection = connection
        reader2 = cmd2.ExecuteReader
        reader2.Read()

        TextBox15.Text = reader2.GetValue(0)
        TextBox14.Text = reader2.GetValue(1)
        TextBox13.Text = reader2.GetValue(2)
        TextBox12.Text = reader2.GetValue(3)
        TextBox11.Text = reader2.GetValue(4)
        TextBox22.Text = reader2.GetValue(5)
        TextBox10.Text = reader2.GetValue(6)

        If connection.State = ConnectionState.Closed Then
            connection.Open()
        Else
            connection.Close()
        End If

        DateTimePicker2.Focus()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CashManagement.Show()
        Me.Close()
    End Sub

    Private Sub DateTimePicker3_Leave(sender As Object, e As EventArgs) Handles DateTimePicker3.Leave
        Calcperiod()

        If DateTimePicker3.Value < DateTimePicker2.Value Then
            MsgBox("تاريخ انهاء العقد يجب ألا يكون اقل من تاريخ بدءالعقد")
            DateTimePicker3.Focus()
        Else
            TextBox16.Text = periodOfRent
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim branchcode As Integer
        Dim date1 As Date
        Dim startdate, enddate As Date
        Dim days, outtank, outkm, dayprice, extrakmprice, drivercost, expectedtotal, driver, refund As Integer
        Dim notes, carlicpno As String
        Dim dtimage As New DataTable

        Dim ms1 As New MemoryStream()
        PBox1.Image.Save(ms1, PBox1.Image.RawFormat)

        Dim ms2 As New MemoryStream()
        PBox2.Image.Save(ms2, PBox2.Image.RawFormat)

        Dim ms3 As New MemoryStream()
        PBox3.Image.Save(ms3, PBox3.Image.RawFormat)

        Dim ms4 As New MemoryStream()
        PBox4.Image.Save(ms4, PBox4.Image.RawFormat)

        Dim ms5 As New MemoryStream()
        PBox11.Image.Save(ms5, PBox11.Image.RawFormat)

        Dim ms6 As New MemoryStream()
        PBox22.Image.Save(ms6, PBox22.Image.RawFormat)

        Dim ms7 As New MemoryStream()
        PBox33.Image.Save(ms7, PBox33.Image.RawFormat)

        Dim ms8 As New MemoryStream()
        PBox44.Image.Save(ms8, PBox44.Image.RawFormat)

        branchcode = ComboBox1.SelectedValue.ToString
        carlicpno = ComboBox5.Text

        If CheckBox1.CheckState = CheckState.Checked Then
            driver = ComboBox6.SelectedValue.ToString
        Else
            driver = Nothing
        End If

        date1 = DateTimePicker1.Value

        days = Val(TextBox16.Text)
        outtank = Val(TextBox17.Text)
        outkm = Val(TextBox18.Text)
        dayprice = Val(TextBox19.Text)
        extrakmprice = Val(TextBox20.Text)
        notes = TextBox21.Text
        drivercost = Val(TextBox23.Text)
        expectedtotal = Val(Label38.Text)
        refund = Val(TextBox24.Text)

        startdate = DateTimePicker2.Value
        enddate = DateTimePicker3.Value

        If TextBox1.Text = "" Then
            query = "exec dbo .SP_ContractSave @branchcode = '" & branchcode & "' ,@date1= '" & date1 & "' ,@custcode = '" & custcode & "',@carcode= '" & carcode & "',@carlicpno= '" & carlicpno & "' ,@startdate = '" & startdate & "' ,@enddate = '" & enddate & "' ,@days= '" & days & "' ,@outtank = '" & outtank & "',@outkm = '" & outkm & "',@dayprice='" & dayprice & "',@extrakmprice ='" & extrakmprice & "',@notes='" & notes & "',@driver='" & driver & "',@drivercost = '" & drivercost & "',@expectedtotal = '" & expectedtotal & "',@refund = '" & refund & "'"
        ElseIf TextBox1.Text <> "" Then
            contractcode = TextBox1.Text
            query = "update contracttbl set daysno='" & days & "',tankout='" & outtank & "',kmout='" & outkm & "',dayprice='" & dayprice & "',extrakmprice='" & extrakmprice & "',notes='" & notes & "',fromdate='" & startdate & "',todate='" & enddate & "',driver='" & driver & "',drivercost = '" & drivercost & "',expectedtotal = '" & expectedtotal & "', refund = '" & refund & "' where code = '" & contractcode & "'"
        End If

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            command.ExecuteNonQuery()

            str = "select contno from branchestbl where curbranch = 1"
            command = New SqlCommand(str, connection)
            dtimage.Load(command.ExecuteReader)

            If TextBox1.Text = "" Then
                TextBox1.Text = dtimage.Rows(0).Item("contno").ToString
                query6 = "insert into contractimagestbl (contractcode, frimage, flimage, ffimage, fbimage, frimage2, flimage2, ffimage2, fbimage2) values (@cod, @image1, @image2, @image3, @image4, @image5, @image6, @image7, @image8)"
            ElseIf TextBox1.Text <> "" Then
                contractcode = TextBox1.Text
                query6 = "update contractimagestbl set frimage = @image1, flimage = @image2, ffimage = @image3, fbimage = @image4, frimage2 = @image5, flimage2 = @image6, ffimage2 = @image7, fbimage2 = @image8 where contractcode = '" & contractcode & "'"
            End If

            command = New SqlCommand(query6, connection)
            command.Parameters.Add("@cod", SqlDbType.Char).Value = TextBox1.Text
            command.Parameters.Add("@image1", SqlDbType.Image).Value = ms1.ToArray()
            command.Parameters.Add("@image2", SqlDbType.Image).Value = ms2.ToArray()
            command.Parameters.Add("@image3", SqlDbType.Image).Value = ms3.ToArray()
            command.Parameters.Add("@image4", SqlDbType.Image).Value = ms4.ToArray()
            command.Parameters.Add("@image5", SqlDbType.Image).Value = ms5.ToArray()
            command.Parameters.Add("@image6", SqlDbType.Image).Value = ms6.ToArray()
            command.Parameters.Add("@image7", SqlDbType.Image).Value = ms7.ToArray()
            command.Parameters.Add("@image8", SqlDbType.Image).Value = ms8.ToArray()
            command.ExecuteNonQuery()

            connection.Close()
            MsgBox("تم الحفظ")
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Start_new()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CustomerFrmLoad = 1
        customers.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CarsFrmLoad = 1
        Cars.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        returncarFrmLoad = 1
        contractcode = TextBox1.Text
        RetrieveCar.Show()
        Me.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FindWhat = 3
        FindFrm.Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ComboBox6.Enabled = True
            TextBox23.Enabled = True
            Dim querytxt As String = "SELECT code, empname FROM userstbl WHERE isdriver = '1' ORDER BY empname"
            Dim cmd As New SqlCommand(querytxt, connection)
            Dim dtisdriver As New DataTable
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            dtisdriver.Load(cmd.ExecuteReader)
            With ComboBox6
                .DataSource = dtisdriver
                .DisplayMember = "empname"
                .ValueMember = "code"
            End With
            connection.Close()
        End If
        If CheckBox1.Checked = False Then
            ComboBox6.Enabled = False
            TextBox23.Enabled = False
            TextBox23.Text = 0
        End If

    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox1.Image = Image.FromFile(picname)
        End If

    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox2.Image = Image.FromFile(picname)
        End If

    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox3.Image = Image.FromFile(picname)
        End If

    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox4.Image = Image.FromFile(picname)
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim contractcode As String
        Dim dt_contract_print As New DataTable

        If (TextBox1.Text <> "") Then
            contractcode = TextBox1.Text.Trim
            str = "select * from v_Contract where contractcode='" & contractcode & "'"
            command = New SqlCommand(str, connection)
            dt_contract_print.Clear()
            Try
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If
                dt_contract_print.Load(command.ExecuteReader)
                connection.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                connection.Close()
            End Try

            contno = dt_contract_print.Rows(0).Item("contractcode".Trim)
            CompanyNameAR = dt_contract_print.Rows(0).Item("CompanyName".Trim)
            usernam = dt_contract_print.Rows(0).Item("usernam".Trim)
            Duration = dt_contract_print.Rows(0).Item("Duration".Trim)
            Start_KM = dt_contract_print.Rows(0).Item("startkm".Trim)
            End_KM = dt_contract_print.Rows(0).Item("endkm".Trim)
            ContractDate = dt_contract_print.Rows(0).Item("contractdate")
            StartDate = dt_contract_print.Rows(0).Item("startdate")
            EndDate = dt_contract_print.Rows(0).Item("enddate")
            Amount = dt_contract_print.Rows(0).Item("amount")
            Total_Expected = dt_contract_print.Rows(0).Item("Total_Expected")
            CustomerName = dt_contract_print.Rows(0).Item("CustomerName".Trim)
            Nationality = dt_contract_print.Rows(0).Item("Nationality".Trim)
            IdNo = dt_contract_print.Rows(0).Item("IdNo".Trim)
            IdSource = dt_contract_print.Rows(0).Item("IdSource".Trim)
            DLicNo = dt_contract_print.Rows(0).Item("DLicNo".Trim)
            DLicSource = dt_contract_print.Rows(0).Item("DLicSource".Trim)
            CustPhone = dt_contract_print.Rows(0).Item("CustPhone".Trim)
            Address = dt_contract_print.Rows(0).Item("Address".Trim)
            DLicEndDate = dt_contract_print.Rows(0).Item("dlicenddate")
            IdEndDate = dt_contract_print.Rows(0).Item("IdEndDate")
            OwnerName = dt_contract_print.Rows(0).Item("OwnerName".Trim)
            cartype = dt_contract_print.Rows(0).Item("CarType".Trim)
            carmodel = dt_contract_print.Rows(0).Item("CarModel".Trim)
            CarColor = dt_contract_print.Rows(0).Item("CarColor".Trim)
            CarLicNo = dt_contract_print.Rows(0).Item("CarLicNo".Trim)
            MotorNo = dt_contract_print.Rows(0).Item("MotorNo".Trim)
            ChaseeNo = dt_contract_print.Rows(0).Item("ChaseeNo".Trim)

            'Report1.Show()

        Else
            MsgBox("لم يتم  اختيار اى عقد")
        End If
    End Sub

    Private Sub TextBox23_Leave(sender As Object, e As EventArgs) Handles TextBox23.Leave
        Calc_total()
    End Sub

    Private Sub TextBox19_GotFocus(sender As Object, e As EventArgs) Handles TextBox19.GotFocus
        TextBox19.Text = TextBox12.Text

    End Sub

    Private Sub ComboBox2_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox2.DropDownClosed
        custcode = ComboBox2.SelectedValue.ToString

        str = "select IdTypeTbl.name as idname, customerstbl.idno as idno, customerstbl.tel1 as phone, DriveLicTypeTbl.name as drivlicname, customerstbl.licno as licno, customerstbl.idvalid as idvaliddate, CustTypeTbl.name as custtype, customerstbl.notes as notes from customerstbl, IdTypeTbl, DriveLicTypeTbl, CustTypeTbl where customerstbl.idtype=IdTypeTbl.code and customerstbl.lictype=DriveLicTypeTbl.code and customerstbl.custtype=CustTypeTbl.code and customerstbl.code='" & custcode & "'"

        command = New SqlCommand(str, connection)
        Dim DtCustContract As New DataTable
        DtCustContract.Clear()

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            DtCustContract.Load(command.ExecuteReader)
            connection.Close()

            TextBox2.Text = DtCustContract.Rows(0).Item("idname").ToString
            TextBox3.Text = DtCustContract.Rows(0).Item("idno").ToString
            TextBox4.Text = DtCustContract.Rows(0).Item("phone").ToString
            TextBox5.Text = DtCustContract.Rows(0).Item("drivlicname").ToString
            TextBox6.Text = DtCustContract.Rows(0).Item("licno").ToString
            TextBox7.Text = DtCustContract.Rows(0).Item("custtype").ToString
            TextBox8.Text = DtCustContract.Rows(0).Item("idvaliddate").ToString
            TextBox9.Text = DtCustContract.Rows(0).Item("notes").ToString

        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub ComboBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox3.MouseClick
        Load_combo3()
    End Sub

    Private Sub ComboBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox4.MouseClick
        Load_combo4()
    End Sub

    Private Sub ComboBox5_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox5.MouseClick
        Load_combo5()
    End Sub

    Private Sub ComboBox5_MouseDown(sender As Object, e As MouseEventArgs) Handles ComboBox5.MouseDown
        Load_combo5()
    End Sub

    Private Sub TextBox19_Leave(sender As Object, e As EventArgs) Handles TextBox19.Leave
        Calc_total()
    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        Calc_total()
    End Sub

    Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox11.Image = Image.FromFile(picname)
        End If

    End Sub

    Private Sub Label41_Click(sender As Object, e As EventArgs) Handles Label41.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox22.Image = Image.FromFile(picname)
        End If

    End Sub

    Private Sub Label42_Click(sender As Object, e As EventArgs) Handles Label42.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox33.Image = Image.FromFile(picname)
        End If

    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox44.Image = Image.FromFile(picname)
        End If

    End Sub
End Class