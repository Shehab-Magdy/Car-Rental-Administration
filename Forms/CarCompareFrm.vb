Public Class CarCompareFrm

    
    Private Sub CarCompareFrm_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        PBox1.Width = (Me.Width / 2) - 45
        PBox2.Width = (Me.Width / 2) - 45

    End Sub
End Class