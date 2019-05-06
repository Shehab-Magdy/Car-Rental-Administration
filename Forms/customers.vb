Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class customers
    Dim command As New SqlCommand
    Dim picname As String

    Sub Load_customer_from_btn()
        query = "SELECT cust.code as code, cust.name as custname, cust.address as address, cust.jobtitle as jobtitle, nat.name as nationality, cust.tel1 as tel1, cust.tel2 as tel2, cust.tel3 as tel3, cust.dofbirth as dofbirth, ct.name as custtype, cust.notes, idt.name as idtype, cust.idno, cust.idsource, cust.idvalid,dlt.name as lictype, cust.licno, cust.licsource, cust.licvalid, ft.name as fromtype, cust.fromname, cust.fromphone, cust.ClosePersonName,cust.ClosePersonAddress,cust.ClosePersonPhone,cust.IdImagebase,cust.DriveLicImagebase FROM customerstbl as cust, NatonalityTbl as nat, CustTypeTbl as ct, IdTypeTbl as idt, DriveLicTypeTbl as dlt, HowtoKnowTbl as ft WHERE nat.code = cust.nationality and ct.code=cust.custtype and idt.code = cust.idtype and dlt.code=cust.lictype and ft.code = cust.fromtype and cust.code = '" & custcode & "'"
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
            TextBox15.Text = dtcustomers.Rows(0).Item("ClosePersonPhone").ToString
            TextBox16.Text = dtcustomers.Rows(0).Item("ClosePersonAddress").ToString
            TextBox17.Text = dtcustomers.Rows(0).Item("ClosePersonName").ToString

            DateTimePicker1.Value = dtcustomers.Rows(0).Item("dofbirth").ToString
            DateTimePicker2.Value = dtcustomers.Rows(0).Item("idvalid").ToString
            DateTimePicker3.Value = dtcustomers.Rows(0).Item("licvalid").ToString

            ComboBox1.Text = dtcustomers.Rows(0).Item("nationality").ToString
            ComboBox2.Text = dtcustomers.Rows(0).Item("custtype").ToString
            ComboBox3.Text = dtcustomers.Rows(0).Item("fromtype").ToString
            ComboBox4.Text = dtcustomers.Rows(0).Item("lictype").ToString
            ComboBox5.Text = dtcustomers.Rows(0).Item("idtype").ToString
            PBox1.Image = Base64ToImage(dtcustomers.Rows(0).Item("IdImagebase").ToString)
            PBox2.Image = Base64ToImage(dtcustomers.Rows(0).Item("DriveLicImagebase").ToString)

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
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        PBox1.Image = Nothing
        PBox2.Image = Nothing

        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker3.Text = Today
        Load_Combobox()
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
                .SelectedIndex = -1
            End With

            adapter2.Fill(dt2)
            With ComboBox2
                .DataSource = dt2
                .DisplayMember = "name"
                .ValueMember = "code"
                .SelectedIndex = -1
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

        Dim pbox1decodingstring As String = String.Empty
        Dim pbox2decodingstring As String = String.Empty
        Dim idimagestring As String = DefaultIdImageString
        Dim DrivLicimagestring As String = DefaultDriveLicImageString
        Dim encodeType As ImageFormat = ImageFormat.Jpeg
        Dim encodingtypestring As String = String.Empty

        If PBox1.ImageLocation.ToLower.EndsWith(".JPG") Then
            encodeType = ImageFormat.Jpeg
            encodingtypestring = "data:image/jpeg;base64,"
        ElseIf PBox1.ImageLocation.ToLower.EndsWith(".PNG") Then
            encodeType = ImageFormat.Png
            encodingtypestring = "data:image/png;base64,"
        End If
        pbox1decodingstring = encodingtypestring
        idimagestring = encodingtypestring & ImageToBase64(PBox1.Image, encodeType)

        If PBox2.ImageLocation.ToLower.EndsWith(".JPG") Then
            encodeType = ImageFormat.Jpeg
            encodingtypestring = "data:image/jpeg;base64,"
        ElseIf PBox2.ImageLocation.ToLower.EndsWith(".PNG") Then
            encodeType = ImageFormat.Png
            encodingtypestring = "data:image/png;base64,"
        End If
        pbox2decodingstring = encodingtypestring
        DrivLicimagestring = encodingtypestring & ImageToBase64(PBox2.Image, encodeType)

        If TextBox1.Text = "" Then
            query = "exec sp_CustomerSave @nam = @@nam ,@addr=@@addr,@pho1=@@pho1 ,@pho2=@@pho2 ,@job=@@job ,@nation=@@nation,@pho3=@@pho3 ,@custtype=@@custtype,@notes=@@notes,@idtype=@@idtype,@idno=@@idno,@idsorc=@@idsorc,@drlictype=@@drlictype,@drlicno=@@drlicno,@drlicsorc=@@drlicsorc,@knowtype=@@knowtype,@knownam=@@knownam,@knowphon=@@knowphon,@bofdate=@@bofdate,@idvalid=@@idvalid,@drlicvalid=@@drlicvalid ,@FriendName=@@friendname,@FriendAddress=@@friendaddr ,@FriendPhone=@@friendphone,@IdImagebase=@@IdImagebase,@DriveLicImagebase =@@DriveLicImagebase"
        End If

        If TextBox1.Text <> "" Then
            query = "update customerstbl set name = @@nam, address = @@addr, jobtitle = @@job, nationality = @@nation , tel1 = @@pho1 , tel2 =@@pho2, tel3 = @@pho3, dofbirth = @@bofdate, custtype =@@custtype , notes =@@notes , IdType =@@idtype , idno =@@idno , idsource =@@idsorc , idvalid = @@idvalid , lictype =@@drlictype , licno =@@drlicno , licsource =@@drlicsorc, licvalid = @@drlicvalid , fromtype =@@knowtype , fromname =@@knownam , fromphone  =@@knowphon , ClosePersonName  = @@friendname , ClosePersonAddress  = @@friendaddr , ClosePersonPhone  =@@friendphone, IdImagebase = @@IdImagebase, DriveLicImagebase = @@DriveLicImagebase where code = '" & custcode & "'"
        End If

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            command = New SqlCommand(query, connection)
            command.Parameters.Add("@@nation", SqlDbType.Char).Value = ComboBox1.SelectedValue.ToString
            command.Parameters.Add("@@custtype", SqlDbType.Char).Value = ComboBox2.SelectedValue.ToString
            command.Parameters.Add("@@knowtype", SqlDbType.Char).Value = ComboBox3.SelectedValue.ToString
            command.Parameters.Add("@@drlictype", SqlDbType.Char).Value = ComboBox4.SelectedValue.ToString
            command.Parameters.Add("@@idtype", SqlDbType.Char).Value = ComboBox5.SelectedValue.ToString

            command.Parameters.Add("@@nam", SqlDbType.Char).Value = TextBox2.Text
            command.Parameters.Add("@@addr", SqlDbType.Char).Value = TextBox3.Text
            command.Parameters.Add("@@job", SqlDbType.Char).Value = TextBox4.Text
            command.Parameters.Add("@@pho1", SqlDbType.Char).Value = TextBox5.Text
            command.Parameters.Add("@@pho2", SqlDbType.Char).Value = TextBox6.Text
            command.Parameters.Add("@@pho3", SqlDbType.Char).Value = TextBox7.Text
            command.Parameters.Add("@@notes", SqlDbType.Char).Value = TextBox8.Text
            command.Parameters.Add("@@idno", SqlDbType.Char).Value = TextBox9.Text
            command.Parameters.Add("@@idsorc", SqlDbType.Char).Value = TextBox10.Text
            command.Parameters.Add("@@drlicno", SqlDbType.Char).Value = TextBox11.Text
            command.Parameters.Add("@@drlicsorc", SqlDbType.Char).Value = TextBox12.Text
            command.Parameters.Add("@@knownam", SqlDbType.Char).Value = TextBox13.Text
            command.Parameters.Add("@@knowphon", SqlDbType.Char).Value = TextBox14.Text
            command.Parameters.Add("@@friendphone", SqlDbType.Char).Value = TextBox15.Text
            command.Parameters.Add("@@friendaddr", SqlDbType.Char).Value = TextBox16.Text
            command.Parameters.Add("@@friendname", SqlDbType.Char).Value = TextBox17.Text

            command.Parameters.Add("@@bofdate", SqlDbType.DateTime).Value = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            command.Parameters.Add("@@idvalid", SqlDbType.DateTime).Value = Format(DateTimePicker2.Value, "yyyy-MM-dd")
            command.Parameters.Add("@@drlicvalid", SqlDbType.DateTime).Value = Format(DateTimePicker3.Value, "yyyy-MM-dd")

            command.Parameters.Add("@@IdImagebase", SqlDbType.VarChar).Value = idimagestring
            command.Parameters.Add("@@DriveLicImagebase", SqlDbType.VarChar).Value = DrivLicimagestring

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

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If (TextBox1.Text <> "") Then
            CustomerFrmLoad = TextBox1.Text
            CustomerCard.Show()
            Me.WindowState = FormWindowState.Minimized
        Else
            MsgBox("لم يتم اختيار عميل")
        End If
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox1.Image = Image.FromFile(picname)
            PBox1.ImageLocation = picname
        End If

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox2.Image = Image.FromFile(picname)
            PBox2.ImageLocation = picname
        End If

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
End Class
