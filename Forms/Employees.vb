Imports System.Data
Imports System.Data.SqlClient

Public Class Employees
    Sub New_user()
        TextBox2.Focus()

        TextBox6.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

        CheckBox1.Checked = False
        CheckBox2.Checked = False

    End Sub

    Sub Load_Combobox()
        query = "select code,name from JobsTbl where bcode = '110' and del = '0' order by name"
        Dim adapter = New SqlDataAdapter(query, connection)

        Try
            Dim dtable As New Data.DataTable
            dtable.Clear()
            adapter.Fill(dtable)
            With ComboBox4
                .DataSource = dtable
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

    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Combobox()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pubcod = "110"
        Settings.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim job, nam, login, pass1, pass2, phon As String
        job = ComboBox4.SelectedValue.ToString
        nam = TextBox2.Text
        login = TextBox3.Text
        pass1 = TextBox4.Text
        pass2 = TextBox5.Text
        phon = TextBox6.Text
        usercode = TextBox1.Text
        Dim command As New SqlCommand

        Dim hasaccess As Integer
        If CheckBox1.Checked = True Then
            hasaccess = 1
        Else
            hasaccess = 0
        End If

        Dim isdriver As Integer
        If CheckBox2.Checked = True Then
            isdriver = 1
        Else
            isdriver = 0
        End If


        If TextBox1.Text = "" Then
            query = "exec sp_UserSave @nam = '" & nam & "',@phon='" & phon & "',@lognam='" & login & "',@logpass='" & pass1 & "',@job='" & job & "',@hasaccess='" & hasaccess & "',@isdriver='" & isdriver & "'"

        ElseIf TextBox1.Text <> "" Then
            query = "update userstbl set empname = '" & nam & "',phone = '" & phon & "',logname = '" & login & "',logpass = '" & pass1 & "',empjob = '" & job & "',hasaccess  = '" & hasaccess & "',isdriver='" & isdriver & "' where code = '" & usercode & "'"
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

        New_user()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        New_user()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Load_Combobox()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FindWhat = 9
        FindFrm.Show()

    End Sub
End Class