Imports System.Data
Imports System.Data.SqlClient

Public Class CarOwners
    Dim command As New SqlCommand
    Sub new_owner()

        TextBox6.Focus()

        TextBox6.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Sub Load_combobox()
        query = "select code,name from PaymentTypeTbl where bcode =  '130' and del = '0' order by name"
        Dim adapter = New SqlDataAdapter(query, connection)

        Dim query2 As String = "select code,name from BanksTbl where bcode = '100' and del = '0' order by name"
        Dim adapter2 = New SqlDataAdapter(query2, connection)
        Dim dt2 As New DataTable

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

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub Frm10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_combobox()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Hide()
        MainForm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pubcod = "100"
        Settings.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pubcod = "130"
        Settings.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim nam, addr, phon1, phon2, bank, bankno, banktype As String

        bank = ComboBox2.SelectedValue.ToString
        banktype = ComboBox1.SelectedValue.ToString

        nam = TextBox6.Text
        addr = TextBox1.Text
        phon1 = TextBox2.Text
        phon2 = TextBox3.Text
        bankno = TextBox4.Text
        ownercode = TextBox5.Text

        If TextBox5.Text = "" Then
            query = "exec sp_OwnerSave @nam = '" & nam & "',@addr='" & addr & "',@phon1='" & phon1 & "',@phon2='" & phon2 & "',@banktype='" & banktype & "',@bank='" & bank & "',@bankno='" & bankno & "'"
        End If

        If TextBox5.Text <> "" Then
            query = "update ownertbl set name = '" & nam & "', address= '" & addr & "',phone1= '" & phon1 & "',phone2 = '" & phon2 & "', cashtype= '" & banktype & "', bankcode = '" & bank & "', accountno = '" & bankno & "' where code = '" & ownercode & "'"
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
        new_owner()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        new_owner()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Load_combobox()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FindWhat = 10
        FindFrm.Show()

    End Sub
End Class