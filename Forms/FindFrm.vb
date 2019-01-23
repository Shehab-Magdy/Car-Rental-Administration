Imports System.Data
Imports System.Data.SqlClient

Public Class FindFrm
    Dim command As New SqlCommand
    Dim position As Integer

    Sub Get_Owner()
        ownercode = Findcode
        query = "select o.code as 'code' , o.name as 'ownername' , o.address as 'owneraddress' , o.phone1 as 'phone1' , o.phone2 as 'pone2' , p.name as 'paymenttype' , b.name as 'bankname' , o.accountno  as 'accountno' from ownertbl as o, BanksTbl as b, PaymentTypeTbl as p where o.cashtype = p.code and o.bankcode=b.code and o.code = '" & ownercode & "'"
        Dim Dtowner As New DataTable
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            Dtowner.Clear()
            Dtowner.Load(command.ExecuteReader)
            connection.Close()
            With CarOwners
                .TextBox5.Text = Dtowner.Rows(0).Item("code")
                .TextBox6.Text = Dtowner.Rows(0).Item("ownername")
                .TextBox1.Text = Dtowner.Rows(0).Item("owneraddress")
                .TextBox2.Text = Dtowner.Rows(0).Item("phone1")
                .TextBox3.Text = Dtowner.Rows(0).Item("pone2")
                .TextBox4.Text = Dtowner.Rows(0).Item("accountno")
                .ComboBox1.Text = Dtowner.Rows(0).Item("paymenttype")
                .ComboBox2.Text = Dtowner.Rows(0).Item("bankname")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub

    Sub Get_Contract()
        contractcode = Findcode
        query = "SELECT con.code as [code], br.name as [branchname], con.contdate as [contdate], cust.name as [custname], cust.idtype as [idtypecode], idt.name as [idtype], cust.idno as [idno],  cust.lictype as [lictypecode], drlt.name as [lictype], cust.licno as [licno],  cust.licvalid as [licvalid], cust.notes as [notes] ,cust.tel1  as [tel], ca.ctype as [cartypecode],  ct.name as [cartype],  ca.cmodel as [carmodelcode], cust.custtype as [custtypecode], custt.name as [custtype], cm.carmodelname as [carmodel], con.carlicpno as [carlicpno] ,  con.dayprice as [dayprice], con.daykm as [daykm], con.daysno as [daysno],  con.fromdate as [fromdate],  con.todate as [todate], con.kmout as [kmout],  con.extrakmprice as [exkmprice], con.tankout as [tankout], con.notes as [connotes], ca.notes as [carnotes], ca.kmperday as [kmperday], ca.licdend as [licdateend], ca.lictype as [lictypecode], carlt.name as [carlictype], ca.carstatus as [carstatuscode], cas.name as [carstatusname] FROM CarConditionTbl as cas , CarLicTypeTbl as carlt , contracttbl as con, customerstbl as cust, carstbl as ca, CarTypeTbl as ct, CarModelsTbl as cm, branchestbl as br, IdTypeTbl as idt, DriveLicTypeTbl as drlt, CustTypeTbl as custt where ca.lictype=carlt.code and con.custcode=cust.code and con.carcode=ca.code and ca.ctype=ct.code and ca.ctype=cm.carcode and ca.cmodel=cm.carmodelcode and con.branchcode=br.code and cust.idtype=idt.code and cust.lictype=drlt.code and cust.custtype=custt.code and ca.carstatus=cas.code and con.code = '" & contractcode & "'"
        Dim dtcontract As New DataTable
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            dtcontract.Clear()
            dtcontract.Load(command.ExecuteReader)
            connection.Close()
            With RentCar
                .TextBox1.Text = dtcontract.Rows(0).Item("code")
                .TextBox2.Text = dtcontract.Rows(0).Item("idtype")
                .TextBox3.Text = dtcontract.Rows(0).Item("idno")
                .TextBox4.Text = dtcontract.Rows(0).Item("tel")
                .TextBox5.Text = dtcontract.Rows(0).Item("lictype")
                .TextBox6.Text = dtcontract.Rows(0).Item("licno")
                .TextBox7.Text = dtcontract.Rows(0).Item("custtype")
                .TextBox8.Text = dtcontract.Rows(0).Item("licvalid")
                .TextBox9.Text = dtcontract.Rows(0).Item("notes")
                .TextBox10.Text = dtcontract.Rows(0).Item("carnotes")
                .TextBox11.Text = dtcontract.Rows(0).Item("kmperday")
                .TextBox12.Text = dtcontract.Rows(0).Item("dayprice")
                .TextBox13.Text = dtcontract.Rows(0).Item("daykm")
                .TextBox14.Text = dtcontract.Rows(0).Item("licdateend")
                .TextBox15.Text = dtcontract.Rows(0).Item("carlictype")
                .TextBox16.Text = dtcontract.Rows(0).Item("daysno")
                .TextBox17.Text = dtcontract.Rows(0).Item("tankout")
                .TextBox18.Text = dtcontract.Rows(0).Item("kmout")
                .TextBox19.Text = dtcontract.Rows(0).Item("dayprice")
                .TextBox20.Text = dtcontract.Rows(0).Item("exkmprice")
                .TextBox21.Text = dtcontract.Rows(0).Item("connotes")
                .TextBox22.Text = dtcontract.Rows(0).Item("carstatusname")

                .ComboBox1.Text = dtcontract.Rows(0).Item("branchname")
                .ComboBox2.Text = dtcontract.Rows(0).Item("custname")
                .ComboBox3.Text = dtcontract.Rows(0).Item("cartype")
                .ComboBox4.Text = dtcontract.Rows(0).Item("carmodel")
                .ComboBox5.Text = dtcontract.Rows(0).Item("carlicpno")

                .DateTimePicker1.Value = dtcontract.Rows(0).Item("contdate")
                .DateTimePicker2.Value = dtcontract.Rows(0).Item("fromdate")
                .DateTimePicker3.Value = dtcontract.Rows(0).Item("todate")

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Sub Get_Branches()
        branchcode = Findcode
        query = " SELECT br.code as [code], br.name as [brname], br.address as [braddress], br.phone1 as [phone1], br.phone2 as [phone2], br.faxno as [fax], br.ipaddress as [ipaddress], br.curbranch as [curbranch], u.empname as [empname] FROM branchestbl as br, userstbl as u where br.responsable=u.code and br.code = '" & branchcode & "'"
        Dim DtBranch As New DataTable
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            DtBranch.Clear()
            DtBranch.Load(command.ExecuteReader)
            connection.Close()
            With AllSettings
                .TextBox1.Text = DtBranch.Rows(0).Item("braddress")
                .TextBox2.Text = DtBranch.Rows(0).Item("phone1")
                .TextBox3.Text = DtBranch.Rows(0).Item("phone2")
                .TextBox4.Text = DtBranch.Rows(0).Item("fax")
                .TextBox5.Text = DtBranch.Rows(0).Item("code")
                .TextBox6.Text = DtBranch.Rows(0).Item("brname")
                .TextBox7.Text = DtBranch.Rows(0).Item("ipaddress")
                .ComboBox1.Text = DtBranch.Rows(0).Item("empname")
                .CheckBox1.Checked = DtBranch.Rows(0).Item("curbranch")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Sub Get_cash()
        cashcode = Findcode
        query = "select c.code as [code], br.name as [brname], ltrim(rtrim(vc.name)) as [cashtype], b.name as [ptype], d.name as [Destination],vp.name as [pname], c.value as [value], c.cashdate as [cashdate], c.notes as [notes], ltrim(rtrim(vm.name)) as [checkcash], c.checkno as [checkno], vb.name as [checkbank], c.checkdate as [checkdate] from cashestbl c, branchestbl br, BanksTbl b, MonyDestinationTbl d, v_checkbank vb, v_cashtype vc, v_method vm, v_cashbenefit vp where br.code = c.branchcode and c.bankcode=b.code and c.cashbenefittype = d.code and c.checkbank=vb.code and c.cashtype=vc.code and c.method=vm.code and c.cashbenefit=vp.pcode and c.cashbenefittype=vp.code and c.id = '" & cashcode & "'"
        Dim dtcash As New DataTable
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            dtcash.Clear()
            dtcash.Load(command.ExecuteReader)
            connection.Close()
            With CashManagement
                .ComboBox1.Text = dtcash.Rows(0).Item("brname")
                .ComboBox2.Text = dtcash.Rows(0).Item("Destination")
                .ComboBox3.Text = dtcash.Rows(0).Item("pname")
                .ComboBox4.Text = dtcash.Rows(0).Item("checkbank")
                .ComboBox5.Text = dtcash.Rows(0).Item("ptype")
                .TextBox1.Text = dtcash.Rows(0).Item("code")
                .TextBox2.Text = dtcash.Rows(0).Item("checkno")
                .TextBox6.Text = dtcash.Rows(0).Item("value")
                .TextBox8.Text = dtcash.Rows(0).Item("notes")
            End With
            If dtcash.Rows(0).Item("cashtype") = "استلام نقدية".Trim Then
                CashManagement.RadioButton1.Checked = True
            Else
                CashManagement.RadioButton2.Checked = True
            End If
            If dtcash.Rows(0).Item("checkcash") = "كاش".Trim Then
                CashManagement.RadioButton3.Checked = True
            Else
                CashManagement.RadioButton4.Checked = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
        MsgBox("يجب عليك قبل التعديل اعادة فتح واختيار الجهة والطرف")
    End Sub

    Sub Get_user()
        usercode = Findcode
        query = "SELECT emp.code as [code], emp.empname as [empname], emp.phone as [phone], emp.logname as [loginname], emp.logpass as [loginpass], j.name as [jobname], emp.hasaccess as [hasaccess], emp.isdriver as [isdriver] FROM userstbl as emp, JobsTbl as j where emp.empjob=j.code and emp.code = '" & usercode & "'"
        Dim DtUsers As New DataTable
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            DtUsers.Clear()
            DtUsers.Load(command.ExecuteReader)
            connection.Close()
            With Employees
                .TextBox1.Text = DtUsers.Rows(0).Item("code")
                .TextBox2.Text = DtUsers.Rows(0).Item("empname")
                .TextBox3.Text = DtUsers.Rows(0).Item("loginname")
                .TextBox4.Text = DtUsers.Rows(0).Item("loginpass")
                .TextBox5.Text = DtUsers.Rows(0).Item("loginpass")
                .TextBox6.Text = DtUsers.Rows(0).Item("phone")
                .ComboBox4.Text = DtUsers.Rows(0).Item("jobname")
                .CheckBox1.Checked = DtUsers.Rows(0).Item("hasaccess")
                .CheckBox2.Checked = DtUsers.Rows(0).Item("isdriver")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim DtFind As New DataTable

        If FindWhat = 1 Then
            query = "SELECT cu.code as 'كود', cu.name as 'اسم العميل', cu.address as 'العنوان', cu.jobtitle as 'الوظيفة', cu.tel1 as 'تليفون 1', cu.tel2 as 'تليفون 2', cut.name  as 'تصنيف العميل', cu.notes as 'ملاحظات', idt.name  as 'نوع البطاقة', dlt.name  as 'نوع رخصة القيادة' FROM customerstbl as CU, NatonalityTbl as NA, CustTypeTbl as CUT, IdTypeTbl as IDT, DriveLicTypeTbl as DLT, HowtoKnowTbl FT where cu.nationality = na.code and cu.custtype=CUT.code and cu.idtype=IDT.code and cu.lictype=DLT.code and cu.fromtype=ft.code and cu.code like @varcode and cu.name like @varname and cu.code like @varcode and cu.code in (Select code from V_Phones where phone like @varphone) "
        ElseIf FindWhat = 2 Then
            query = "SELECT c.code as [كود], ct.name as [النوع], cm.carmodelname as [الموديل], c.cyear as [السنة], c.chassisno as [رقم الشاسيه], c.motorno as [رقم الموتور], co.name as [اللون], ow.name as [اسم المالك], c.licpno as [رقم اللوحة], cc.name as [حالة السيارة], lict.name as [نوع الرخصة], c.licsource as [جهة الاصدار], c.licno as [رقم الرخصة], c.licdend as [تاريخ الانتهاء], c.inscar as [رقم التأمين], c.notes as [ملاحظات], c.dayprice as [سعر اليوم], c.kmperday as [عدد كيلومترات اليوم] FROM carstbl as c, CarTypeTbl ct, CarModelsTbl as cm, ColorsTbl as co, ownertbl as ow ,CarConditionTbl as cc, CarLicTypeTbl as lict  where c.ctype=ct.code and c.ctype=cm.carcode and c.cmodel=cm.carmodelcode and c.carcolor=co.code and c.ownerid=ow.code and c.carstatus=cc.code and c.lictype=lict.code"
        ElseIf FindWhat = 3 Then
            query = "SELECT con.code as [كود], con.contdate as [تاريخ التعاقد], cust.name as [اسم العميل], cust.tel1  as [رقم التليفون], ca.ctype as [كود نوع السيارة], ct.name as [نوع السيارة], ca.cmodel as [كود الموديل], cm.carmodelname as [الموديل], con.carlicpno as [رقم اللوحة] , con.dayprice as [سعر اليوم], con.daykm as [عدد الكيلومترات لليوم], con.daysno as [عدد الايام], con.fromdate as [بدء التعاقد], con.todate as [نهاية التعاقد], con.kmout as [العداد وقت التسليم] FROM contracttbl as con, customerstbl as cust, carstbl as ca, CarTypeTbl as ct, CarModelsTbl as cm where con.custcode=cust.code and con.carcode=ca.code and ca.ctype=ct.code and ca.ctype=cm.carcode and ca.cmodel=cm.carmodelcode"
        ElseIf FindWhat = 5 Then
            query = "SELECT br.code as [كود], br.name as [اسم الفرع], br.address as [العنوان], br.phone1 as [تليفون 1], br.phone2 as [تليفون 2], br.faxno as [فاكس], br.ipaddress as [IP_Address], br.curbranch as [الفرع الحالى], u.empname as [المدير المسئول] FROM branchestbl as br, userstbl as u where br.responsable=u.code and br.code like @varcode and br.name like @varname and br.address like @varaddress and br.phone1 like @varphone"
        ElseIf FindWhat = 6 Then
            query = "SELECT con.code as [كود], con.contdate as [تاريخ التعاقد], cust.name as [اسم العميل], cust.tel1  as [رقم التليفون], ca.ctype as [كود نوع السيارة], ct.name as [نوع السيارة], ca.cmodel as [كود الموديل], cm.carmodelname as [الموديل], con.carlicpno as [رقم اللوحة] , con.dayprice as [سعر اليوم], con.daykm as [عدد الكيلومترات لليوم], con.daysno as [عدد الايام], con.fromdate as [بدء التعاقد], con.todate as [نهاية التعاقد], con.kmout as [العداد وقت التسليم] FROM contracttbl as con, customerstbl as cust, carstbl as ca, CarTypeTbl as ct, CarModelsTbl as cm where con.custcode=cust.code and con.carcode=ca.code and ca.ctype=ct.code and ca.ctype=cm.carcode and ca.cmodel=cm.carmodelcode and con.contractstatus = 0"
        ElseIf FindWhat = 7 Then
            query = "select c.id as [id], ltrim(rtrim(vc.name)) as [نوع الحركة], b.name as [الخزينة], d.name as [الجهة],vp.name as [المستفيد], c.value as [القيمة], c.cashdate as [التاريخ], ltrim(rtrim(vm.name)) as [طبيعة التعامل] from cashestbl c, branchestbl br, BanksTbl b, MonyDestinationTbl d, v_checkbank vb, v_cashtype vc, v_method vm, v_cashbenefit vp where br.code = c.branchcode and c.bankcode=b.code and c.cashbenefittype = d.code and c.checkbank=vb.code and c.cashtype=vc.code and c.method=vm.code and c.cashbenefit=vp.pcode and c.cashbenefittype=vp.code and c.code like @varcode"
        ElseIf FindWhat = 9 Then
            query = "SELECT emp.code as [كود], emp.empname as [اسم الموظف], emp.phone as [تليفون], emp.logname as [اسم الدخول], j.name as [الوظيفة], emp.hasaccess as [مستخدم] FROM userstbl as emp, JobsTbl as j where emp.empjob=j.code and emp.phone like @varphone and emp.empname like  @varname and emp.code like @varcode"
        ElseIf FindWhat = 10 Then
            query = "select o.code as 'كود' , o.name as 'الاسم' , o.address as 'العنوان' , o.phone1 as 'تليفون 1' , o.phone2 as 'تليفون 2' , p.name as 'طريقة الدفع' , b.name as 'اسم البنك' , o.accountno  as 'رقم الحساب' from ownertbl as o, BanksTbl as b, PaymentTypeTbl as p where o.cashtype = p.code and o.bankcode=b.code and o.code like @varcode and o.name like @varname and o.phone1 like @varphone"
        End If

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            command.Parameters.Add("@varcode", SqlDbType.NVarChar).Value = "%" & Trim(TextBox1.Text) & "%"
            command.Parameters.Add("@varname", SqlDbType.NVarChar).Value = "%" & Trim(TextBox2.Text) & "%"
            command.Parameters.Add("@varphone", SqlDbType.NVarChar).Value = "%" & Trim(TextBox3.Text) & "%"
            command.Parameters.Add("@varaddress", SqlDbType.NVarChar).Value = "%" & Trim(TextBox4.Text) & "%"
            DtFind.Load(command.ExecuteReader)
            connection.Close()
            DGV1.DataSource = DtFind
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try


    End Sub

    Private Sub DGV1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellDoubleClick

        position = DGV1.CurrentRow.Index
        Findcode = DGV1.Rows(position).Cells(0).Value

        If FindWhat = 10 Then
            Get_Owner()
        ElseIf FindWhat = 1 Then
            custcode = Findcode
            customers.Load_customer_from_btn()
        ElseIf FindWhat = 2 Then
            carcode = Findcode
            Cars.Load_car_from_btn()
        ElseIf FindWhat = 3 Then
            Get_Contract()
            With RentCar
                .ComboBox2.Enabled = False
                .ComboBox3.Enabled = False
                .ComboBox4.Enabled = False
                .ComboBox5.Enabled = False
                .TextBox9.Enabled = False
                .TextBox10.Enabled = False
            End With
        ElseIf FindWhat = 5 Then
            Get_Branches()
        ElseIf FindWhat = 6 Then
            Get_Contract()
            RetrieveCar.TextBox1.Text = Findcode
        ElseIf FindWhat = 7 Then
            Get_cash()
        ElseIf FindWhat = 9 Then
            Get_user()
        End If

        Me.Close()


    End Sub

    Private Sub FindFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FindWhat = 1 Then
            Label1.Visible = True       'code
            Label2.Visible = True       'name
            Label3.Visible = True       'phone
            Label4.Visible = False      'address
            Label5.Visible = False      'car Type
            Label6.Visible = False      'Car Model
            TextBox1.Visible = True     'code
            TextBox2.Visible = True     'name
            TextBox3.Visible = True     'phone
            TextBox4.Visible = False    'address
            CbBox1.Visible = False      'car Type
            CbBox2.Visible = False      'Car Model

        ElseIf FindWhat = 22 Then
            Label1.Visible = True
            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = True
            Label6.Visible = True
            TextBox1.Visible = True
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            CbBox1.Visible = True
            CbBox2.Visible = True

            query = "select code,name from CarTypeTbl where bcode = '30' order by name"
            Try
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If
                Dim dtable As New Data.DataTable
                command = New SqlCommand(query, connection)
                dtable.Clear()
                dtable.Load(command.ExecuteReader)
                'With CbBox1
                '    .DataSource = dtable
                '    .DisplayMember = "name"
                '    .ValueMember = "code"
                'End With
                connection.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                connection.Close()
            End Try
            
        ElseIf FindWhat = 3 Then

        ElseIf FindWhat = 5 Then
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = False
            Label6.Visible = False
            TextBox1.Visible = True
            TextBox2.Visible = True
            TextBox3.Visible = True
            TextBox4.Visible = True
            CbBox1.Visible = False
            CbBox2.Visible = False

        ElseIf FindWhat = 6 Then
            Label1.Visible = True       'code
            Label2.Visible = True       'name
            Label3.Visible = False       'phone
            Label4.Visible = False      'address
            Label5.Visible = False      'car Type
            Label6.Visible = False      'Car Model
            TextBox1.Visible = True     'code
            TextBox2.Visible = True     'name
            TextBox3.Visible = False     'phone
            TextBox4.Visible = False    'address
            CbBox1.Visible = False      'car Type
            CbBox2.Visible = False      'Car Model

        ElseIf FindWhat = 7 Then
            Label1.Visible = True       'code
            Label2.Visible = False      'name
            Label3.Visible = False       'phone
            Label4.Visible = False      'address
            Label5.Visible = False      'car Type
            Label6.Visible = False      'Car Model
            TextBox1.Visible = True     'code
            TextBox2.Visible = False      'name
            TextBox3.Visible = False     'phone
            TextBox4.Visible = False    'address
            CbBox1.Visible = False      'car Type
            CbBox2.Visible = False      'Car Model

        ElseIf FindWhat = 9 Then
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            TextBox1.Visible = True
            TextBox2.Visible = True
            TextBox3.Visible = True
            TextBox4.Visible = False
            CbBox1.Visible = False
            CbBox2.Visible = False

        ElseIf FindWhat = 10 Then
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            TextBox1.Visible = True
            TextBox2.Visible = True
            TextBox3.Visible = True
            TextBox4.Visible = False
            CbBox1.Visible = False
            CbBox2.Visible = False

        End If
    End Sub

    Private Sub CbBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles CbBox2.MouseClick
        Dim carcod As String = "0"
        Try
            carcod = CbBox1.SelectedValue.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim query2 As String = "select carmodelcode, carmodelname from carmodelstbl where carcode = " & carcod & " and del = '0' order by carmodelname"
        Dim dt2 As New DataTable
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
        Try
            Dim command2 As New SqlCommand(query2, connection)
            dt2.Load(command2.ExecuteReader)
            With CbBox2
                .DataSource = dt2
                .DisplayMember = "carmodelname"
                .ValueMember = "carmodelcode"
            End With
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub

End Class