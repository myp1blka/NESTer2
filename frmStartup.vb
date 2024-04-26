Public Class frmStartup

    Private Sub frmStartup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = pName & pVersion & pBuild & vbCrLf & vbCrLf & pAuthor
    End Sub

    Private Sub frmStartup_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Me.Close()
    End Sub
End Class