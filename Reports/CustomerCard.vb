Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Data.SqlClient

Public Class CustomerCard
    Dim command As New SqlCommand
    Private Sub CustomerCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        query = "exec sp_CustomerCardReport @custCode = '" & CustomerFrmLoad & "'"

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

        cryRpt.Load($"{ReportsPath}CustomerCard.rpt")
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

    Private Sub CustomerCard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        customers.WindowState = FormWindowState.Normal

    End Sub
End Class