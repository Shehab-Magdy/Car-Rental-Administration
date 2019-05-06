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

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        CustomersReport.Show()
        Panel1.Visible = False
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        OwnersReport.Show()
        Panel1.Visible = False
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Visible = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        CarsReport.Show()
        Panel1.Visible = False
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        EmployeeReport.Show()
        Panel1.Visible = False
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        OpenContractsReport.Show()
        Panel1.Visible = False
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        AvailableCarsReport.Show()
        Panel1.Visible = False
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        ExpenseReport.Show()
        Panel1.Visible = False
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        PeriodicMaintenance.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        CashFlowReport.Show()
        Panel1.Visible = False
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        CustomerStatementReport.Show()
        Panel1.Visible = False
        WindowState = FormWindowState.Minimized
    End Sub
End Class