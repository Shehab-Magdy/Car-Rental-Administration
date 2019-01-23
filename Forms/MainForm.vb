Public Class MainForm

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        customers.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RentCar.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CashManagement.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ReportsCrystal.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cars.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RetrieveCar.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        AllSettings.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        End
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Employees.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CarOwners.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class