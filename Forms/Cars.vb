Imports System.Data
Imports System.Data.SqlClient

Public Class Cars
    Dim command As New SqlCommand
    Sub Load_car_from_btn()
        query = "select car.code as code, ct.name as ctype, cm.carmodelname as cmodel, car.cyear as cyear, car.chassisno as chassisno, car.motorno as motorno, co.name as carcolor,ow.name as ownerid, car.licpno as licpno, st.name as carstatus, clt.name as lictype, car.licsource as licsource, car.licno as licno, car.licdend as licdend, car.inscar as inscar, car.notes as notes , car.dayprice as dayprice, car.kmperday as kmperday from carstbl as car, CarTypeTbl as ct, CarModelsTbl as cm, ColorsTbl as co, ownertbl as ow, CarConditionTbl as st, CarLicTypeTbl as clt where ct.code = car.ctype and cm.carmodelcode=car.cmodel and cm.carcode=car.lictype and co.code = car.carcolor and ow.code = car.ownerid and st.code = car.carstatus and clt.code=car.lictype and car.code = '" & carcode & "'"
        Dim dtcars As New DataTable
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            'dtcars.Clear()
            command = New SqlCommand(query, connection)
            dtcars.Load(command.ExecuteReader)
            connection.Close()

            TextBox1.Text = dtcars.Rows(0).Item("code").ToString
            TextBox2.Text = dtcars.Rows(0).Item("chassisno").ToString
            TextBox3.Text = dtcars.Rows(0).Item("motorno").ToString
            TextBox4.Text = dtcars.Rows(0).Item("licpno").ToString
            TextBox5.Text = dtcars.Rows(0).Item("inscar").ToString
            TextBox6.Text = dtcars.Rows(0).Item("dayprice").ToString
            TextBox7.Text = dtcars.Rows(0).Item("kmperday").ToString
            TextBox8.Text = dtcars.Rows(0).Item("notes").ToString
            TextBox9.Text = dtcars.Rows(0).Item("cyear").ToString
            TextBox11.Text = dtcars.Rows(0).Item("licno").ToString
            TextBox12.Text = dtcars.Rows(0).Item("licsource").ToString

            DateTimePicker3.Value = dtcars.Rows(0).Item("licdend").ToString

            ComboBox1.Text = dtcars.Rows(0).Item("ctype").ToString
            ComboBox2.Text = dtcars.Rows(0).Item("cmodel").ToString
            ComboBox3.Text = dtcars.Rows(0).Item("carcolor").ToString
            ComboBox4.Text = dtcars.Rows(0).Item("lictype").ToString
            ComboBox5.Text = dtcars.Rows(0).Item("carstatus").ToString
            ComboBox6.Text = dtcars.Rows(0).Item("ownerid").ToString


        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try


    End Sub

    Sub New_car()
        ComboBox1.Focus()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""

    End Sub

    Sub Load_Combobox()
        query = "select code,name from CarTypeTbl where bcode = '30' order by name"
        Dim adapter = New SqlDataAdapter(query, connection)

        Dim query3 As String = "select code,name from ColorsTbl where bcode = '120' and del = '0' order by name"
        Dim adapter3 = New SqlDataAdapter(query3, connection)
        Dim dt3 As New DataTable

        Dim query4 As String = "select code,name from CarLicTypeTbl where bcode = '80' and del = '0' order by name"
        Dim adapter4 = New SqlDataAdapter(query4, connection)
        Dim dt4 As New DataTable

        Dim query5 As String = "select code,name from CarConditionTbl where bcode = '140' and del = '0' order by name"
        Dim adapter5 = New SqlDataAdapter(query5, connection)
        Dim dt5 As New DataTable

        Dim query6 As String = "select code, name from ownertbl order by name"
        Dim adapter6 = New SqlDataAdapter(query6, connection)
        Dim dt6 As New DataTable

        Try
            Dim dtable As New Data.DataTable
            dtable.Clear()
            adapter.Fill(dtable)
            With ComboBox1
                .DataSource = dtable
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

            adapter6.Fill(dt6)
            With ComboBox6
                .DataSource = dt6
                .DisplayMember = "name"
                .ValueMember = "code"
            End With

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
        MainForm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Frm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CarsFrmLoad = 0 Then
            Load_Combobox()
        ElseIf CarsFrmLoad = 1 Then
            Load_car_from_btn()
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pubcod = "30"
        Settings.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pubcod = "120"
        Settings.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        pubcod = "140"
        Settings.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CarOwners.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pubcod = "80"
        Settings.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim licno, ctyp, cmodel, cyear, chassisno, motorno, carcolor, ownerid, licpno, notes, carstatus, lictype, licsource, inscar, dayprice, kmperday As String
        Dim licdend As Date

        ctyp = ComboBox1.SelectedValue.ToString
        cmodel = ComboBox2.SelectedValue.ToString
        carcolor = ComboBox3.SelectedValue.ToString
        lictype = ComboBox4.SelectedValue.ToString
        carstatus = ComboBox5.SelectedValue.ToString
        ownerid = ComboBox6.SelectedValue.ToString

        licdend = DateTimePicker3.Value

        carcode = TextBox1.Text
        chassisno = TextBox2.Text
        motorno = TextBox3.Text
        licpno = TextBox4.Text
        inscar = TextBox5.Text
        dayprice = TextBox6.Text
        kmperday = TextBox7.Text
        notes = TextBox8.Text
        cyear = TextBox9.Text
        licno = TextBox11.Text
        licsource = TextBox12.Text

        If TextBox1.Text = "" Then
            query = "exec SP_CarSave @ctype = '" & ctyp & "',@cmodel='" & cmodel & "',@cyear='" & cyear & "',@chassisno='" & chassisno & "',@motorno='" & motorno & "',@carcolor='" & carcolor & "',@ownerid='" & ownerid & "',@licpno='" & licpno & "',@carstatus='" & carstatus & "',@lictype='" & lictype & "',@licsource='" & licsource & "',@licno='" & licno & "',@licdend='" & licdend & "',@inscar='" & inscar & "',@notes='" & notes & "',@dayprice='" & dayprice & "',@kmperday='" & kmperday & "'"
        ElseIf TextBox1.Text <> "" Then
            query = "update carstbl set ctype= '" & ctyp & "', cmodel= '" & cmodel & "', cyear= '" & cyear & "', chassisno= '" & chassisno & "', motorno= '" & motorno & "', carcolor= '" & carcolor & "', ownerid= '" & ownerid & "', licpno= '" & licpno & "', carstatus= '" & carstatus & "', lictype= '" & lictype & "', licsource= '" & licsource & "', licno= '" & licno & "', licdend= '" & licdend & "', inscar= '" & inscar & "', notes= '" & notes & "', dayprice= '" & dayprice & "', kmperday= '" & kmperday & "' where code= '" & carcode & "'"
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
        New_car()


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim carcod As String = "0"
        Try
            carcod = ComboBox1.SelectedValue.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim query2 As String = "select carmodelcode, carmodelname from carmodelstbl where carcode = " & carcod & " and del = '0' order by carmodelname"
        'Dim command2 = New SqlCommand(query2, connection)
        Dim adapter2 = New SqlDataAdapter(query2, connection)
        Dim dt2 As New DataTable
        If ComboBox1.Focused = True Then

            Try
                adapter2.Fill(dt2)
                With ComboBox2
                    .DataSource = dt2
                    .DisplayMember = "carmodelname"
                    .ValueMember = "carmodelcode"
                End With

                connection.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                connection.Close()
            End Try

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pubcod = "40"
        Settings.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        New_car()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Load_Combobox()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FindWhat = 2
        FindFrm.Show()
    End Sub
End Class