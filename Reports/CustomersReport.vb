Imports CrystalDecisions.CrystalReports.Engine
Public Class CustomersReport
    Private Sub ReportsCrystal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cryRpt As New ReportDocument
        Dim myDBConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo()
        Dim crtablelogoninfo As New TableLogOnInfo
        Dim crtablelogoninfos As New TableLogOnInfos
        Dim crconnectioninfo As New ConnectionInfo
        Dim crtables As Tables
        Dim ctable As Table

        cryRpt.Load($"{ReportsPath}CustomersDetails.rpt")

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

    Private Sub CustomersReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        MainForm.WindowState = FormWindowState.Normal
    End Sub
End Class