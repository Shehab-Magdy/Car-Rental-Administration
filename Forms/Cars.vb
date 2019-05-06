Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Public Class Cars
    Dim command As New SqlCommand

    Public Sub Load_car_from_btn()
        query = "select car.code as code, ct.name as ctype, cm.carmodelname as cmodel, car.cyear as cyear, car.chassisno as chassisno, car.motorno as motorno, co.name as carcolor,ow.name as ownerid, car.licpno as licpno, st.name as carstatus, clt.name as lictype, car.licsource as licsource, car.licno as licno, car.licdend as licdend, car.inscar as inscar, car.notes as notes , car.dayprice as dayprice, car.kmperday as kmperday, car.CarPrice, car.CurrentKM, car.CarImage from carstbl as car, CarTypeTbl as ct, CarModelsTbl as cm, ColorsTbl as co, ownertbl as ow, CarConditionTbl as st, CarLicTypeTbl as clt where ct.code = car.ctype and cm.carmodelcode=car.cmodel and cm.carcode=car.ctype and co.code = car.carcolor and ow.code = car.ownerid and st.code = car.carstatus and clt.code=car.lictype and car.code ='" & carcode & "'"
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
            TextBox10.Text = dtcars.Rows(0).Item("CarPrice").ToString
            TextBox11.Text = dtcars.Rows(0).Item("CurrentKM").ToString
            TextBox12.Text = dtcars.Rows(0).Item("licsource").ToString

            DateTimePicker3.Value = dtcars.Rows(0).Item("licdend").ToString

            ComboBox1.Text = dtcars.Rows(0).Item("ctype").ToString
            ComboBox2.Text = dtcars.Rows(0).Item("cmodel").ToString
            ComboBox3.Text = dtcars.Rows(0).Item("carcolor").ToString
            ComboBox4.Text = dtcars.Rows(0).Item("lictype").ToString
            ComboBox5.Text = dtcars.Rows(0).Item("carstatus").ToString
            ComboBox6.Text = dtcars.Rows(0).Item("ownerid").ToString
            PBox1.Image = Base64ToImage(dtcars.Rows(0).Item("CarImage").ToString)


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
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox24.Text = ""
        TextBox25.Text = ""
        TextBox26.Text = ""
        TextBox27.Text = ""
        TextBox28.Text = ""

        Load_Combobox()
        DateTimePicker3.Value = Now()
        PBox1.Image = Nothing



    End Sub

    Sub Load_Combobox()
        query = "select code,name from CarTypeTbl where bcode = '30' and del = '0' order by name"
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
                .SelectedIndex = 0
            End With

            adapter3.Fill(dt3)
            With ComboBox3
                .DataSource = dt3
                .DisplayMember = "name"
                .ValueMember = "code"
                .SelectedIndex = -1
            End With

            adapter4.Fill(dt4)
            With ComboBox4
                .DataSource = dt4
                .DisplayMember = "name"
                .ValueMember = "code"
                .SelectedIndex = -1
            End With

            adapter5.Fill(dt5)
            With ComboBox5
                .DataSource = dt5
                .DisplayMember = "name"
                .ValueMember = "code"
                .SelectedIndex = -1
            End With

            adapter6.Fill(dt6)
            With ComboBox6
                .DataSource = dt6
                .DisplayMember = "name"
                .ValueMember = "code"
                .SelectedIndex = -1
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
        Select Case CarsFrmLoad
            Case 0
                Load_Combobox()
            Case 1
                Load_car_from_btn()
            Case Else
                Exit Select
        End Select


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

        Dim pbox1decodingstring As String = String.Empty
        Dim Carimagestring As String = DefaultCarImageString
        Dim encodeType As ImageFormat = ImageFormat.Jpeg
        Dim encodingtypestring As String = String.Empty
        Dim queryx As String
        Dim command2 As New SqlCommand

        If PBox1.ImageLocation.ToLower.EndsWith(".JPG") Then
            encodeType = ImageFormat.Jpeg
            encodingtypestring = "data:image/jpeg;base64,"
        ElseIf PBox1.ImageLocation.ToLower.EndsWith(".PNG") Then
            encodeType = ImageFormat.Png
            encodingtypestring = "data:image/png;base64,"
        End If
        pbox1decodingstring = encodingtypestring
        Carimagestring = encodingtypestring & ImageToBase64(PBox1.Image, encodeType)

        Select Case TextBox1.Text
            Case ""
                query = "exec sp_CarSave @ctype = @@ctyp ,@cmodel=@@cmodel ,@cyear=@@cyear,@chassisno=@@chassisno ,@motorno=@@motorno ,@carcolor=@@carcolor ,@ownerid=@@ownerid,@licpno=@@licpno ,@carstatus=@@carstatus ,@lictype=@@lictype ,@licsource=@@licsource ,@licdend=@@licdend ,@inscar=@@inscar ,@notes=@@notes ,@dayprice=@@dayprice ,@kmperday=@@kmperday,@CarImage=@@CarImage,@CarPrice =@@CarPrice,@CurrentKM=@@CurrentKM,@Usage=@@Usage, @ExtraKMEvery=@@ExtraKMEvery, @BrakeLinings=@@BrakeLinings, @Tires=@@Tires, @AirFilters=@@AirFilters, @ConditionFilters=@@ConditionFilters, @CarWash=@@CarWash, @OilChange=@@OilChange, @GasolineFilters=@@GasolineFilters, @FatOil=@@FatOil, @GroupConduct=@@GroupConduct, @Pugettes=@@Pugettes, @PeriodicMaintenance=@@PeriodicMaintenance"
            Case Is <> ""
                query = "update carstbl set ctype= @@ctyp , cmodel=@@cmodel , cyear= @@cyear , chassisno= @@chassisno , motorno=@@motorno , carcolor= @@carcolor , ownerid=@@ownerid , licpno=@@licpno, carstatus=@@carstatus , lictype= @@lictype , licsource= @@licsource , licdend= @@licdend , inscar=@@inscar , notes=@@notes, dayprice= @@dayprice , kmperday= @@kmperday, CarImage=@@CarImage, CarPrice =@@CarPrice,CurrentKM=@@CurrentKM where code= '" & carcode & "'"
                queryx = "update AlarmsDataTbl set CurrentValue = @@CurrentKM, Usage = @@Usage, ExtraKMEvery=@@ExtraKMEvery, BrakeLinings=@@BrakeLinings, Tires=@@Tires, AirFilters=@@AirFilters, ConditionFilters=@@ConditionFilters, CarWash=@@CarWash, OilChange=@@OilChange, GasolineFilters=@@GasolineFilters, FatOil=@@FatOil, GroupConduct=@@GroupConduct, Pugettes=@@Pugettes, PeriodicMaintenance=@@PeriodicMaintenance where CarCode= '" & carcode & "'"
            Case Else
                Exit Select
        End Select

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Select Case TextBox1.Text
                Case ""
                    command = New SqlCommand(query, connection)
                Case Is <> ""
                    command = New SqlCommand(query, connection)
                    command2 = New SqlCommand(queryx, connection)
                Case Else
                    Exit Select
            End Select

            command.Parameters.Add("@@ctyp", SqlDbType.Char).Value = ComboBox1.SelectedValue.ToString
            command.Parameters.Add("@@cmodel", SqlDbType.Char).Value = ComboBox2.SelectedValue.ToString
            command.Parameters.Add("@@CarColor", SqlDbType.Char).Value = ComboBox3.SelectedValue.ToString
            command.Parameters.Add("@@lictype", SqlDbType.Char).Value = ComboBox4.SelectedValue.ToString
            command.Parameters.Add("@@carstatus", SqlDbType.Char).Value = ComboBox5.SelectedValue.ToString
            command.Parameters.Add("@@ownerid", SqlDbType.Char).Value = ComboBox6.SelectedValue.ToString

            command.Parameters.Add("@@carcode", SqlDbType.Char).Value = TextBox1.Text
            command.Parameters.Add("@@chassisno", SqlDbType.Char).Value = TextBox2.Text
            command.Parameters.Add("@@MotorNo", SqlDbType.Char).Value = TextBox3.Text
            command.Parameters.Add("@@licpno", SqlDbType.Char).Value = TextBox4.Text
            command.Parameters.Add("@@inscar", SqlDbType.Char).Value = TextBox5.Text
            command.Parameters.Add("@@dayprice", SqlDbType.Char).Value = TextBox6.Text
            command.Parameters.Add("@@kmperday", SqlDbType.Char).Value = TextBox7.Text
            command.Parameters.Add("@@notes", SqlDbType.Char).Value = TextBox8.Text
            command.Parameters.Add("@@cyear", SqlDbType.Char).Value = TextBox9.Text
            command.Parameters.Add("@@CurrentKM", SqlDbType.Char).Value = TextBox11.Text
            command.Parameters.Add("@@licsource", SqlDbType.Char).Value = TextBox12.Text
            command.Parameters.Add("@@CarPrice", SqlDbType.Char).Value = TextBox10.Text

            command.Parameters.Add("@@licdend", SqlDbType.DateTime).Value = Format(DateTimePicker3.Value, "yyyy-MM-dd")
            command.Parameters.Add("@@CarImage", SqlDbType.VarChar).Value = Carimagestring

            command.Parameters.Add("@@Usage", SqlDbType.Char).Value = TextBox16.Text
            command.Parameters.Add("@@ExtraKMEvery", SqlDbType.Char).Value = TextBox17.Text
            command.Parameters.Add("@@BrakeLinings", SqlDbType.Char).Value = TextBox18.Text
            command.Parameters.Add("@@Tires", SqlDbType.Char).Value = TextBox19.Text
            command.Parameters.Add("@@AirFilters", SqlDbType.Char).Value = TextBox20.Text
            command.Parameters.Add("@@ConditionFilters", SqlDbType.Char).Value = TextBox21.Text
            command.Parameters.Add("@@CarWash", SqlDbType.Char).Value = TextBox22.Text
            command.Parameters.Add("@@OilChange", SqlDbType.Char).Value = TextBox23.Text
            command.Parameters.Add("@@GasolineFilters", SqlDbType.Char).Value = TextBox24.Text
            command.Parameters.Add("@@FatOil", SqlDbType.Char).Value = TextBox25.Text
            command.Parameters.Add("@@GroupConduct", SqlDbType.Char).Value = TextBox26.Text
            command.Parameters.Add("@@Pugettes", SqlDbType.Char).Value = TextBox27.Text
            command.Parameters.Add("@@PeriodicMaintenance", SqlDbType.Char).Value = TextBox28.Text

            command2.Parameters.Add("@@CurrentKM", SqlDbType.Char).Value = TextBox11.Text
            command2.Parameters.Add("@@Usage", SqlDbType.Char).Value = TextBox16.Text
            command2.Parameters.Add("@@ExtraKMEvery", SqlDbType.Char).Value = TextBox17.Text
            command2.Parameters.Add("@@BrakeLinings", SqlDbType.Char).Value = TextBox18.Text
            command2.Parameters.Add("@@Tires", SqlDbType.Char).Value = TextBox19.Text
            command2.Parameters.Add("@@AirFilters", SqlDbType.Char).Value = TextBox20.Text
            command2.Parameters.Add("@@ConditionFilters", SqlDbType.Char).Value = TextBox21.Text
            command2.Parameters.Add("@@CarWash", SqlDbType.Char).Value = TextBox22.Text
            command2.Parameters.Add("@@OilChange", SqlDbType.Char).Value = TextBox23.Text
            command2.Parameters.Add("@@GasolineFilters", SqlDbType.Char).Value = TextBox24.Text
            command2.Parameters.Add("@@FatOil", SqlDbType.Char).Value = TextBox25.Text
            command2.Parameters.Add("@@GroupConduct", SqlDbType.Char).Value = TextBox26.Text
            command2.Parameters.Add("@@Pugettes", SqlDbType.Char).Value = TextBox27.Text
            command2.Parameters.Add("@@PeriodicMaintenance", SqlDbType.Char).Value = TextBox28.Text
            command2.ExecuteNonQuery()

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
        Dim adapter2 = New SqlDataAdapter(query2, connection)
        Dim dt2 As New DataTable
        If ComboBox1.Focused = True Then

            Try
                adapter2.Fill(dt2)
                With ComboBox2
                    .DataSource = dt2
                    .DisplayMember = "carmodelname"
                    .ValueMember = "carmodelcode"
                    .SelectedIndex = -1
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

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim picname As String

        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox1.Image = Image.FromFile(picname)
            PBox1.ImageLocation = picname
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        PeriodicMaintenance.Show()
    End Sub
    Public Function ImageToBase64(ByVal image As Image, ByVal format As ImageFormat)
        Using ms As New MemoryStream
            image.Save(ms, format)
            Dim imageBytes As Byte() = ms.ToArray()
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End Using
    End Function
    Public Function Base64ToImage(ByVal Base64Code As String)
        Dim imageBytes As Byte() = Convert.FromBase64String(Base64Code)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)
        Dim tmpImage As Image = Image.FromStream(ms, True)
        Return tmpImage
    End Function

    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click

    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click

    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged

    End Sub
End Class