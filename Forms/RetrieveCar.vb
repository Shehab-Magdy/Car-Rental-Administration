Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class RetrieveCar
    Dim tot_befor_tax, taxp, tot_after_tax, tax As Double
    Dim picname As String
    Dim command As New SqlCommand
    Dim custcode As String
    Dim expectedtotal As Decimal
    Dim daykm As Integer = 0

    Sub calc_total()
        tot_befor_tax = Val(TextBox20.Text)
        taxp = Val(TextBox21.Text) / 100
        tax = tot_befor_tax * taxp
        tot_after_tax = tot_befor_tax + tax

        Label25.Text = tot_after_tax + Val(Label36.Text)
    End Sub
    Public Function CalcExtraKM()
        Dim days As Integer = 0, currentkm As Integer = 0, firstkm As Integer = 0, extrakm As Integer = 0
        days = TextBox9.Text
        currentkm = TextBox7.Text
        firstkm = TextBox6.Text
        extrakm = (currentkm - firstkm) - (days * daykm)
        Return extrakm
    End Function

    Sub new_close()
        Label25.Text = ""
        Label36.Text = "0.0"

        DateTimePicker1.Value = Now
        DateTimePicker1.Value = Now

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
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""

        TextBox1.Focus()

        PBox1.Image = Nothing
        PBox2.Image = Nothing
        PBox3.Image = Nothing
        PBox4.Image = Nothing
        PBox11.Image = Nothing
        PBox22.Image = Nothing
        PBox33.Image = Nothing
        PBox44.Image = Nothing

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        MainForm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        contractcode = Val(TextBox1.Text)
        Dim dtcontractv As New DataTable
        Dim dtcustbal As New DataTable
        Dim query2 As String

        query = "SELECT co.code as contractcode, co.contdate as contractdate, co.custcode as custcode, co.carcode as carcode, co.carlicpno as carlicpno, co.dayprice as dayprice, co.daykm as daykm, co.fromdate as startdate, co.todate as enddate, co.kmout as kmout, co.tankout as tankout, co.expectedtotal as expectedtotal, co.extrakmprice as extrakmprice, b.name as  brname, cu.name as custname, vc.cartype as cartype, vc.carmodel as carmodel FROM dbo.ContractTbl AS co INNER JOIN dbo.BranchesTbl AS b ON co.branchcode = b.code INNER JOIN dbo.customerstbl AS cu ON co.custcode = cu.code INNER JOIN dbo.V_Cars AS vc ON co.carcode = vc.code WHERE co.contractstatus =0 and co.code = '" & contractcode & "'"

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            dtcontractv.Clear()
            dtcontractv.Load(command.ExecuteReader)
            If dtcontractv.Rows.Count > 0 Then
                TextBox2.Text = dtcontractv.Rows(0).Item("custname").ToString
                custcode = dtcontractv.Rows(0).Item("custcode").ToString
                TextBox3.Text = dtcontractv.Rows(0).Item("cartype").ToString
                TextBox4.Text = dtcontractv.Rows(0).Item("carmodel").ToString
                TextBox5.Text = dtcontractv.Rows(0).Item("carlicpno").ToString
                TextBox6.Text = dtcontractv.Rows(0).Item("kmout").ToString
                TextBox10.Text = dtcontractv.Rows(0).Item("tankout").ToString
                TextBox22.Text = dtcontractv.Rows(0).Item("dayprice").ToString
                TextBox23.Text = dtcontractv.Rows(0).Item("extrakmprice").ToString
                DateTimePicker2.Value = dtcontractv.Rows(0).Item("startdate").ToString
                expectedtotal = dtcontractv.Rows(0).Item("expectedtotal")
                daykm = dtcontractv.Rows(0).Item("daykm")

                query2 = "select balance from customerstbl where code = '" & custcode & "'"
                Try
                    command = New SqlCommand(query2, connection)
                    dtcustbal.Clear()
                    dtcustbal.Load(command.ExecuteReader)
                    connection.Close()
                    Label36.Text = dtcustbal.Rows(0).Item("balance").ToString
                    Label36.Text = Val(Label36.Text) - expectedtotal

                Catch ex As Exception
                    MsgBox(ex.Message)
                    connection.Close()
                End Try
            Else
                MsgBox("لقد ادخلت رقم عقد مغلق ", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
        DateTimePicker1.Focus()

    End Sub

    Private Sub TextBox13_Enter(sender As Object, e As EventArgs) Handles TextBox13.Enter
        If Val(TextBox7.Text) > Val(TextBox6.Text) Then
            TextBox8.Text = Val(TextBox7.Text) - Val(TextBox6.Text)
            TextBox7.BackColor = Color.White
        Else
            'MsgBox("لقد ادخلت قيمة كيلو مترات غير صحيحة")
            TextBox7.Focus()
            TextBox7.BackColor = Color.Red
        End If
        TextBox12.Text = Val(TextBox11.Text) - Val(TextBox10.Text)
        TextBox9.Text = DateDiff(DateInterval.Day, DateTimePicker2.Value, DateTimePicker1.Value)

    End Sub

    Private Sub TextBox19_Enter(sender As Object, e As EventArgs) Handles TextBox19.Enter
        TextBox18.Text = Val(TextBox14.Text) + Val(TextBox15.Text) + Val(TextBox16.Text) + Val(TextBox17.Text)
    End Sub

    Private Sub TextBox21_Enter(sender As Object, e As EventArgs) Handles TextBox21.Enter
        TextBox20.Text = Val(TextBox18.Text) - Val(TextBox19.Text)
        calc_total()
    End Sub

    Private Sub TextBox21_Leave(sender As Object, e As EventArgs) Handles TextBox21.Leave
        calc_total()
    End Sub

    Private Sub TextBox15_Enter(sender As Object, e As EventArgs) Handles TextBox15.Enter
        Dim a, b As Integer
        Dim c, d As Double

        a = Val(TextBox9.Text)
        b = Val(TextBox13.Text)
        c = Val(TextBox23.Text)
        d = Val(TextBox22.Text)

        TextBox14.Text = (a * d) + (c * b)
        TextBox15.SelectAll()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        contractcode = TextBox1.Text
        Dim kmreceived As Integer = TextBox7.Text
        Dim tankreceived As Decimal = TextBox11.Text
        Dim kmusage As Decimal = TextBox8.Text
        Dim tankusage As Decimal = TextBox12.Text
        Dim kmextra As Decimal = TextBox13.Text
        Dim value As Decimal = TextBox14.Text
        Dim tankcost As Decimal = TextBox15.Text
        Dim damagecost As Decimal = TextBox16.Text
        Dim extracost As Decimal = TextBox17.Text
        Dim disc As Decimal = TextBox19.Text
        Dim taxper As Decimal = TextBox21.Text
        Dim totalvalue As Decimal = Val(Label25.Text) - Val(Label36.Text)

        Dim ms1 As New MemoryStream()
        Dim ms2 As New MemoryStream()
        Dim ms3 As New MemoryStream()
        Dim ms4 As New MemoryStream()
        Dim ms5 As New MemoryStream()
        Dim ms6 As New MemoryStream()
        Dim ms7 As New MemoryStream()
        Dim ms8 As New MemoryStream()

        Dim dtimage As New DataTable
        Try
            PBox1.Image.Save(ms1, PBox1.Image.RawFormat)
            PBox2.Image.Save(ms2, PBox2.Image.RawFormat)
            PBox3.Image.Save(ms3, PBox3.Image.RawFormat)
            PBox4.Image.Save(ms4, PBox4.Image.RawFormat)

            PBox11.Image.Save(ms5, PBox11.Image.RawFormat)
            PBox22.Image.Save(ms6, PBox22.Image.RawFormat)
            PBox33.Image.Save(ms7, PBox33.Image.RawFormat)
            PBox44.Image.Save(ms8, PBox44.Image.RawFormat)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "update contracttbl set kmreceived= '" & kmreceived & "', tankreceived= '" & tankreceived & "', kmusage= '" & kmusage & "', tankusage= '" & tankusage & "', kmextra= '" & kmextra & "', value= '" & value & "', tankcost= '" & tankcost & "', damagecost= '" & damagecost & "', extracost= '" & extracost & "', disc= '" & disc & "', tax= '" & tax & "', taxp= '" & taxper & "', totalvalue= '" & totalvalue & "', closedby= '" & usercod & "', closeddate = '" & Now & "', contractstatus = 1 where code = '" & contractcode & "'"

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            command.ExecuteNonQuery()

            query = "update contractimagestbl set lrimage = @image1, llimage = @image2, lfimage = @image3, lbimage = @image4, lrimage2 = @image5, llimage2 = @image6, lfimage2 = @image7, lbimage2 = @image8 where contractcode = '" & contractcode & "'"
            command = New SqlCommand(query, connection)
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

            query = "update customerstbl set balance = '" & totalvalue & "' where code = '" & custcode & "'"
            command = New SqlCommand(query, connection)
            command.ExecuteNonQuery()

            connection.Close()
            MsgBox("تم اغلاق العقد")
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CashManagement.Show()
        Me.Close()

    End Sub

    Private Sub Frm6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If returncarFrmLoad = 1 Then
            TextBox1.Text = contractcode
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CarCompareFrm.Show()
        CarCompareFrm.PBox2.Image = Me.PBox1.Image
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            query = "select frimage from contractimagestbl where contractcode = '" & TextBox1.Text & "'"
            command = New SqlCommand(query, connection)
            Dim dtimage As New DataTable
            dtimage.Load(command.ExecuteReader)
            Dim img As Byte()
            img = dtimage.Rows(0)(0)
            Dim ms As New MemoryStream(img)
            CarCompareFrm.PBox1.Image = Image.FromStream(ms)

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Label31_Click(sender As Object, e As EventArgs) Handles Label31.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox1.Image = Image.FromFile(picname)
        End If
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox2.Image = Image.FromFile(picname)
        End If
    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox3.Image = Image.FromFile(picname)
        End If
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox4.Image = Image.FromFile(picname)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        FindWhat = 6
        FindFrm.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CarCompareFrm.Show()
        CarCompareFrm.PBox2.Image = Me.PBox2.Image
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            query = "select flimage from contractimagestbl where contractcode = '" & TextBox1.Text & "'"
            command = New SqlCommand(query, connection)
            Dim dtimage As New DataTable
            dtimage.Load(command.ExecuteReader)
            Dim img As Byte()
            img = dtimage.Rows(0)(0)
            Dim ms As New MemoryStream(img)
            CarCompareFrm.PBox1.Image = Image.FromStream(ms)

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CarCompareFrm.Show()
        CarCompareFrm.PBox2.Image = Me.PBox3.Image
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            query = "select ffimage from contractimagestbl where contractcode = '" & TextBox1.Text & "'"
            command = New SqlCommand(query, connection)
            Dim dtimage As New DataTable
            dtimage.Load(command.ExecuteReader)
            Dim img As Byte()
            img = dtimage.Rows(0)(0)
            Dim ms As New MemoryStream(img)
            CarCompareFrm.PBox1.Image = Image.FromStream(ms)

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        CarCompareFrm.Show()
        CarCompareFrm.PBox2.Image = Me.PBox4.Image
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            query = "select fbimage from contractimagestbl where contractcode = '" & TextBox1.Text & "'"
            command = New SqlCommand(query, connection)
            Dim dtimage As New DataTable
            dtimage.Load(command.ExecuteReader)
            Dim img As Byte()
            img = dtimage.Rows(0)(0)
            Dim ms As New MemoryStream(img)
            CarCompareFrm.PBox1.Image = Image.FromStream(ms)

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox11.Image = Image.FromFile(picname)
        End If
    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox22.Image = Image.FromFile(picname)
        End If
    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox33.Image = Image.FromFile(picname)
        End If
    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click
        OpenFileD1.Filter = "chosse Image (*.JPG, *.PNG) | *.jpg; *.png"
        If OpenFileD1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MsgBox("لم يتم اختيار صورة")
        Else
            picname = OpenFileD1.FileName
            PBox44.Image = Image.FromFile(picname)
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CarCompareFrm.Show()
        CarCompareFrm.PBox2.Image = Me.PBox11.Image
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            query = "select frimage2 from contractimagestbl where contractcode = '" & TextBox1.Text & "'"
            command = New SqlCommand(query, connection)
            Dim dtimage As New DataTable
            dtimage.Load(command.ExecuteReader)
            Dim img As Byte()
            img = dtimage.Rows(0)(0)
            Dim ms As New MemoryStream(img)
            CarCompareFrm.PBox1.Image = Image.FromStream(ms)

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        CarCompareFrm.Show()
        CarCompareFrm.PBox2.Image = Me.PBox22.Image
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            query = "select flimage2 from contractimagestbl where contractcode = '" & TextBox1.Text & "'"
            command = New SqlCommand(query, connection)
            Dim dtimage As New DataTable
            dtimage.Load(command.ExecuteReader)
            Dim img As Byte()
            img = dtimage.Rows(0)(0)
            Dim ms As New MemoryStream(img)
            CarCompareFrm.PBox1.Image = Image.FromStream(ms)

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        CarCompareFrm.Show()
        CarCompareFrm.PBox2.Image = Me.PBox33.Image
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            query = "select ffimage2 from contractimagestbl where contractcode = '" & TextBox1.Text & "'"
            command = New SqlCommand(query, connection)
            Dim dtimage As New DataTable
            dtimage.Load(command.ExecuteReader)
            Dim img As Byte()
            img = dtimage.Rows(0)(0)
            Dim ms As New MemoryStream(img)
            CarCompareFrm.PBox1.Image = Image.FromStream(ms)

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub


    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        CarCompareFrm.Show()
        CarCompareFrm.PBox2.Image = Me.PBox44.Image
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            query = "select fbimage2 from contractimagestbl where contractcode = '" & TextBox1.Text & "'"
            command = New SqlCommand(query, connection)
            Dim dtimage As New DataTable
            dtimage.Load(command.ExecuteReader)
            Dim img As Byte()
            img = dtimage.Rows(0)(0)
            Dim ms As New MemoryStream(img)
            CarCompareFrm.PBox1.Image = Image.FromStream(ms)

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        new_close()
    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        calc_total()
    End Sub

    Private Sub TextBox13_GotFocus(sender As Object, e As EventArgs) Handles TextBox13.GotFocus
        TextBox13.Text = If(CalcExtraKM() <= 0, 0, CalcExtraKM())
    End Sub
End Class