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
        ''Set timer and test
        'Dim var As Integer = DateGood(365)
        'Dim str As String = "The Program is outofdate! Please contact vendor for updates. and report this code " & var

        'If var = 3 Then
        '    Me.Show() 'Show if good
        'Else
        '    MsgBox(str, vbExclamation, "Update needed")
        '    Me.Close() 'Hide if not
        'End If

        Label3.Text = "Version Date. " & CallBuildingInfo()
    End Sub
End Class