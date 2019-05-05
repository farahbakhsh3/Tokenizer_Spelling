Public Class frmStartup

    Private Sub btnTokenizer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTokenizer.Click

        frmTokenize.ShowDialog()
    End Sub

    Private Sub btnSpelling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpelling.Click

        frmSpelling.ShowDialog()
    End Sub
End Class