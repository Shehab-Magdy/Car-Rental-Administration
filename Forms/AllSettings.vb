Imports System.Data
Imports System.Data.SqlClient

Public Class AllSettings
    Dim command As New SqlCommand
    Sub new_Branch()
        TextBox6.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox7.Text = ""
        CheckBox1.Checked = False
        TextBox6.Focus()

    End Sub

    Sub Load_Combobox()
        query = "select code,empname from userstbl order by empname"
        Dim adapter = New SqlDataAdapter(query, connection)

        Try
            Dim dtable As New Data.DataTable
            dtable.Clear()
            adapter.Fill(dtable)
            With ComboBox1
                .DataSource = dtable
                .DisplayMember = "empname"
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

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        pubcod = "30"
        Settings.Show()
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        CarOwners.Show()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        pubcod = "10"
        Settings.Show()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        pubcod = "20"
        Settings.Show()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        pubcod = "70"
        Settings.Show()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        pubcod = "90"
        Settings.Show()
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        pubcod = "100"
        Settings.Show()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        pubcod = "40"
        Settings.Show()
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        pubcod = "60"
        Settings.Show()
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        pubcod = "50"
        Settings.Show()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        pubcod = "80"
        Settings.Show()
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        pubcod = "110"
        Settings.Show()
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        pubcod = "120"
        Settings.Show()
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        pubcod = "130"
        Settings.Show()
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        pubcod = "140"
        Settings.Show()
    End Sub

    Private Sub Frm5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Combobox()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Employees.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim res, nam, addr, pho1, pho2, fax, ipadd As String
        res = ComboBox1.SelectedValue.ToString
        nam = TextBox6.Text
        addr = TextBox1.Text
        pho1 = TextBox2.Text
        pho2 = TextBox3.Text
        fax = TextBox4.Text
        ipadd = TextBox7.Text

        Dim local As Integer
        If CheckBox1.Checked = True Then
            local = 1
        Else
            local = 0
        End If

        If TextBox5.Text = "" Then
            query = "exec SP_BranchSave @nam = '" & nam & "',@addr='" & addr & "',@pho1='" & pho1 & "',@pho2='" & pho2 & "',@fax='" & fax & "',@ipadd='" & ipadd & "',@loca='" & local & "',@res='" & res & "'"

        ElseIf TextBox5.Text <> "" Then
            query = "update branchestbl set name = '" & nam & "', address = '" & addr & "',phone1 = '" & pho1 & "',phone2 = '" & pho2 & "',faxno = '" & fax & "',ipaddress = '" & ipadd & "',curbranch  = '" & local & "',responsable='" & res & "' where code = '" & branchcode & "'"

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

        new_Branch()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        new_Branch()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Load_Combobox()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FindWhat = 5
        FindFrm.Show()

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        pubcod = "150"
        Settings.Show()
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        pubcod = "160"
        Settings.Show()
    End Sub
End Class