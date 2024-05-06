Public Class frmStartup

    Private Sub frmStartup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = pName & pVersion & pBuild & vbCrLf & vbCrLf & pAuthor

        LinkLabel1.Text = "Click here to visit GitHub page"
        LinkLabel1.Links.Add(0, 31, "https://github.com/vitaliimur/NESTer2")

    End Sub

    Private Sub frmStartup_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
        Me.Close()
    End Sub

End Class