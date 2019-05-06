Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Data.SqlClient
Public Class CustomerStatementReport
    Dim command As New SqlCommand
    Public Sub Load_combobox()
        query = "select code, name  from customerstbl order by name"

        Try
            Dim dtable As New DataTable
            dtable.Clear()

            Call New SqlDataAdapter(query, connection).Fill(dtable)
            With ComboBox1
                .DataSource = dtable
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
    Private Sub CustomerStatementReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_combobox()
    End Sub

    Private Sub CustomerStatementReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        MainForm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim expcode As Integer = ComboBox1.SelectedValue
        Dim startdate As Date = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        Dim enddate As Date = Format(DateAdd(DateInterval.Day, 1, DateTimePicker2.Value), "yyyy-MM-dd")

        query = "exec sp_CashFlowReport @cashbenefittype = 1 , @cashbenefit = '" & expcode & "', @datfrom = '" & startdate & "', @datto = '" & enddate & "'"
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            command = New SqlCommand(query, connection)
            command.ExecuteNonQuery()
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

            connection.Close()
        End Try


        Dim cryRpt As New ReportDocument
        Dim myDBConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo()
        Dim crtablelogoninfo As New TableLogOnInfo
        Dim crtablelogoninfos As New TableLogOnInfos
        Dim crconnectioninfo As New ConnectionInfo
        Dim crtables As Tables
        Dim ctable As Table


        cryRpt.Load($"{ReportsPath}CashFlowReport.rpt")

        With crconnectioninfo
            .ServerName = SName
            .DatabaseName = DbName
            .UserID = UName
            .Password = PName
        End With

        crtables = cryRpt.Database.Tables
        For Each ctable In crtables
            crtablelogoninfo = ctable.LogOnInfo
            crtablelogoninfo.ConnectionInfo = crconnectioninfo
            ctable.ApplyLogOnInfo(crtablelogoninfo)
        Next

        With CrystalReportViewer1
            .ReportSource = cryRpt
            .Zoom(120)
            .Refresh()
        End With

    End Sub
End Class