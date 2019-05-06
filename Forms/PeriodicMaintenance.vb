Imports System.Data
Imports System.Data.SqlClient
Public Class PeriodicMaintenance
    Dim command As New SqlCommand

    Private Sub PeriodicMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        query = "SELECT code,carname FROM v_Cars order by carname"
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim dtable As New Data.DataTable
            Command = New SqlCommand(query, connection)
            dtable.Clear()
            dtable.Load(Command.ExecuteReader)
            With CbBox1
                .DataSource = dtable
                .DisplayMember = "carname"
                .ValueMember = "code"
            End With
            connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Close()
    End Sub




End Class