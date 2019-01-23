Imports System.Data
Imports System.Data.SqlClient

Public Class Settings
    Dim fname As String
    Dim command As New SqlCommand
    Sub undo_delete()
        cod = ComboBox1.SelectedValue.ToString
        str = TextBox2.Text

        If pubcod = "40" Then
            query = "update carmodelstbl set del = '0' where carmodelname = '" & str & "' and carcode = '" & cod & "'"
            fname = "carmodelname"

        Else
            Select Case pubcod
                Case "10"
                    query = "update NatonalityTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "20"
                    query = "update CustTypeTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "30"
                    query = "update CarTypeTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "50"
                    query = "update HowtoKnowTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "60"
                    query = "update IdTypeTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "70"
                    query = "update DriveLicTypeTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "80"
                    query = "update CarLicTypeTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "90"
                    query = "update ExpensesTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "100"
                    query = "update BanksTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "110"
                    query = "update JobsTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "120"
                    query = "update ColorsTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "130"
                    query = "update PaymentTypeTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "140"
                    query = "update CarConditionTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "150"
                    query = "update MonyDestinationTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "160"
                    query = "update MiscIncomeTbl set del = '0' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case Else
                    MsgBox("لم يتم ادخال متغير صحيح", MsgBoxStyle.Information, "Sorry")
            End Select
            
            fname = "name"
        End If

        Try
            connection.Open()
            Command = New SqlCommand(query, connection)
            Command.ExecuteNonQuery()
            If Command.ExecuteNonQuery() > 0 Then
                TextBox2.Text = ""
                MsgBox("تم استعادة البيان")
            End If

            connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub delete()
        cod = ComboBox1.SelectedValue.ToString
        str = TextBox2.Text

        If pubcod = "40" Then
            query = "update carmodelstbl set del = '1' where carmodelname = '" & str & "' and carcode = '" & cod & "'"
            fname = "carmodelname"

        Else
            Select Case pubcod
                Case "10"
                    query = "update NatonalityTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "20"
                    query = "update CustTypeTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "30"
                    query = "update CarTypeTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "50"
                    query = "update HowtoKnowTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "60"
                    query = "update IdTypeTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "70"
                    query = "update DriveLicTypeTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "80"
                    query = "update CarLicTypeTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "90"
                    query = "update ExpensesTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "100"
                    query = "update BanksTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "110"
                    query = "update JobsTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "120"
                    query = "update ColorsTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "130"
                    query = "update PaymentTypeTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "140"
                    query = "update CarConditionTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "150"
                    query = "update MonyDestinationTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case "160"
                    query = "update MiscIncomeTbl set del = '1' where name = '" & str & "' and bcode = '" & pubcod & "'"
                Case Else
                    MsgBox("لم يتم ادخال متغير صحيح", MsgBoxStyle.Information, "Sorry")
            End Select
            
            fname = "name"
        End If


        Try
            connection.Open()
            command = New SqlCommand(query, connection)
            command.ExecuteNonQuery()
            If MessageBox.Show("تأكيد", "هل انت متأكد من الحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If command.ExecuteNonQuery() > 0 Then
                    TextBox2.Text = ""
                    MsgBox("تم الحذف")
                End If
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub

    Private Sub retrieve()
        Dim fname As String
        Dim DtListBox As New DataTable

        cod = ComboBox1.SelectedValue.ToString

        If pubcod = "40" Then
            query = "select carmodelcode, carmodelname from carmodelstbl where carcode = '" & cod & "'"
            fname = "carmodelname"

        Else
            Select Case pubcod
                Case "10"
                    query = "select code,name from NatonalityTbl where bcode = '" & pubcod & "' order by name"
                Case "20"
                    query = "select code,name from CustTypeTbl where bcode = '" & pubcod & "' order by name"
                Case "30"
                    query = "select code,name from CarTypeTbl where bcode = '" & pubcod & "' order by name"
                Case "50"
                    query = "select code,name from HowtoKnowTbl where bcode = '" & pubcod & "' order by name"
                Case "60"
                    query = "select code,name from IdTypeTbl where bcode = '" & pubcod & "' order by name"
                Case "70"
                    query = "select code,name from DriveLicTypeTbl where bcode = '" & pubcod & "' order by name"
                Case "80"
                    query = "select code,name from CarLicTypeTbl where bcode = '" & pubcod & "' order by name"
                Case "90"
                    query = "select code,name from ExpensesTbl where bcode = '" & pubcod & "' order by name"
                Case "100"
                    query = "select code,name from BanksTbl where bcode = '" & pubcod & "' order by name"
                Case "110"
                    query = "select code,name from JobsTbl where bcode = '" & pubcod & "' order by name"
                Case "120"
                    query = "select code,name from ColorsTbl where bcode = '" & pubcod & "' order by name"
                Case "130"
                    query = "select code,name from PaymentTypeTbl where bcode = '" & pubcod & "' order by name"
                Case "140"
                    query = "select code,name from CarConditionTbl where bcode = '" & pubcod & "' order by name"
                Case "150"
                    query = "select code,name from MonyDestinationTbl where bcode = '" & pubcod & "' order by name"
                Case "160"
                    query = "select code,name from MiscIncomeTbl where bcode = '" & pubcod & "' order by name"
                Case Else
                    MsgBox("لم يتم ادخال متغير صحيح", MsgBoxStyle.Information, "Sorry")
            End Select
            
            fname = "name"
        End If

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            command = New SqlCommand(query, connection)
            DtListBox.Load(command.ExecuteReader)
            ListBox1.Items.Clear()
            For Each row In DtListBox.Rows
                ListBox1.Items.Add(row(fname))
            Next
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Frm4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt04 As New DataTable

        If pubcod = 40 Then
            query = "select code,name as bdataname from CarTypeTbl where bcode = '30' order by name"
        Else
            query = "select code,bdataname from ClassesTbl where code = '" & pubcod & "'"
        End If

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim command04 As New SqlCommand(query, connection)
            dt04.Load(command04.ExecuteReader)
            ComboBox1.DataSource = dt04
            connection.Close()

            With ComboBox1
                .DisplayMember = "bdataname"
                .ValueMember = "code"
            End With

            ListBox1.Items.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try

        retrieve()



    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        str = TextBox2.Text
        cod = ComboBox1.SelectedValue.ToString
        query = ""
        If pubcod = 40 Then
            query = "exec sp_ModelSave @carcode = '" & cod & "',@nam='" & str & "'"
        Else
            query = "exec sp_ClassesDesc @cod = '" & cod & "',@nam='" & str & "'"
        End If

        If TextBox2.Text <> "" Then
            Try
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If
                command = New SqlCommand(query, connection)
                command.ExecuteNonQuery()
                connection.Close()
                TextBox2.Text = ""
                MsgBox("تم الحفظ")
                TextBox2.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
                connection.Close()
            End Try
        Else
            MsgBox("برجاء ادخال بيانات صحيحة", MsgBoxStyle.Information)
            TextBox2.Focus()
        End If
        retrieve()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        retrieve()
        TextBox2.Focus()
    End Sub

    Private Sub ListBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseClick
        TextBox2.Text = ""
        If ListBox1.SelectedIndex >= 0 Then TextBox2.Text = ListBox1.SelectedItem

    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        delete()
        retrieve()
    End Sub

    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles BtnUndo.Click
        undo_delete()
        retrieve()

    End Sub

End Class