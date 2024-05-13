Public Class frmViewScreen

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        prNextScreen()
    End Sub

    Private Sub PictureBox2_Resize(sender As Object, e As EventArgs) Handles PictureBox2.Resize
        'prMsgToLog("Me.Width-" & Me.Width)
        'prMsgToLog("PictureBox2.Width-" & PictureBox2.Width)
        Me.Width = PictureBox2.Width + 25 ' +25  height toolstrip
        Me.Height = PictureBox2.Height + 25
    End Sub

    Private Sub frmViewScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox2.Image = Image.FromFile(mScreensInDir(pCurrentSelIndex))
        lblScreensCounter.Text = pCurrentSelIndex.ToString + 1 & "(" & mScreensInDir.Length & ")"
    End Sub

    Private Sub cmbNextScreen_Click_1(sender As Object, e As EventArgs) Handles cmbNextScreen.Click
        prNextScreen()
    End Sub

    Private Sub cmbPrevScreen_Click_1(sender As Object, e As EventArgs) Handles cmbPrevScreen.Click
        prPrevScreen()
    End Sub
End Class