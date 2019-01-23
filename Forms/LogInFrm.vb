Imports System.Data
Imports System.Data.SqlClient

Public Class LogInFrm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lognam = TextBox1.Text
        logpass = TextBox2.Text
        Dim command As New SqlCommand
        Dim dtable As New Data.DataTable
        query = "select empname, code from userstbl where hasaccess = '1' and logname = '" & lognam & "' and logpass = '" & logpass & "'"

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            dtable.Load(command.ExecuteReader)
            If dtable.Rows.Count > 0 Then
                usernam = dtable.Rows(0).Item("empname").ToString
                usercod = dtable.Rows(0).Item("code").ToString
                MainForm.Show()
                Me.Hide()
            Else
                MsgBox("اسم المستخدم او كلمة السر خاطئ", MsgBoxStyle.Information)
            End If
            connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Close()

    End Sub


    Private Sub LogInFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class