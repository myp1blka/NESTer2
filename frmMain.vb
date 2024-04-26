
Imports System.ComponentModel

Public Class frmMain
    Public pMeHeight As Integer
    Public pMeWidth As Integer

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prLoadProgram()

        pMeHeight = Me.Height
        pMeWidth = Me.Width
        'Me.TopMost = False

        If pDebugMode = 1 Then
            If Me.Width <= pMeWidth Then Me.Width = pMeWidth + 280 Else Me.Width = Me.Width - 280 ' open / close setting panel
            If Me.Height <= pMeHeight Then Me.Height = pMeHeight + 150 Else Me.Height = Me.Height - 150 ' open / close logfile panel
        End If

    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        prExitApplication()
    End Sub

    Private Sub cmbReloadList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReloadList.Click
        prLoadListOfFiles()
    End Sub

    Private Sub cmbStartEmulator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartEmulator.Click
        prExecEmulator()
    End Sub

    Private Sub MainMiniPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMiniPictureBox.Click
        frmViewScreen.Show()
    End Sub

    ' Right Mouse Clict is activate context menu
    ' Selected Item Change
    Private Sub ListBoxRoms_MouseDown(sender As Object, e As MouseEventArgs) Handles ListBoxRoms.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If ListBoxRoms.IndexFromPoint(e.X, e.Y) >= 0 Then
                ListBoxRoms.SelectedIndex = ListBoxRoms.IndexFromPoint(e.X, e.Y)
            End If
            prSelectedIndexChanged()
        End If
    End Sub

    Private Sub ListBoxRoms_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBoxRoms.MouseDoubleClick
        If ListBoxRoms.SelectedIndex <> -1 Then prLoadRom(ListBoxRoms.SelectedIndex)
    End Sub

    Private Sub ListBoxRoms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxRoms.SelectedIndexChanged
        prSelectedIndexChanged()
    End Sub

    Private Sub ListBoxScreens_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBoxScreens.MouseClick
        If ListBoxScreens.SelectedIndex <> -1 Then prLoadImage(ListBoxScreens.SelectedIndex)
    End Sub

    Private Sub cmbNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNextScreen.Click
        prNextScreen()
    End Sub

    Private Sub cmbPrevScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrevScreen.Click
        prPrevScreen()
    End Sub

    ' Start The Game
    Private Sub cmbStartGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartGame.Click
        If ListBoxRoms.SelectedIndex <> -1 Then prLoadRom(ListBoxRoms.SelectedIndex)
    End Sub

    Private Sub mnuDeleteRom_Click(sender As Object, e As EventArgs) Handles mnuDeleteRom.Click
        prDeleteRom()
    End Sub

    Private Sub ListBoxRoms_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBoxRoms.KeyDown
        ' prMsgToLog("ListBoxRoms_KeyDown - " & e.KeyCode)


        ' What key pressing user ?
        Dim IsLetter As Boolean = (e.KeyCode >= 65 AndAlso e.KeyCode <= 90) OrElse (e.KeyCode >= 97 AndAlso e.KeyCode <= 122)
        Dim IsNumber As Boolean = (e.KeyCode >= 48 AndAlso e.KeyCode <= 57)
        Dim IsWhiteSpace As Boolean = (e.KeyCode = 9) OrElse (e.KeyCode = 13) OrElse (e.KeyCode = 32)
        ' Delete Rom by pressing Delete on keyboard
        If e.KeyCode = Keys.Delete And ListBoxRoms.SelectedIndex <> -1 Then
            prDeleteRom()
            ' Start Rom by pressing Enter on keyboard
        ElseIf e.KeyCode = Keys.Enter And ListBoxRoms.SelectedIndex <> -1 Then
            prLoadRom(ListBoxRoms.SelectedIndex)
            ' Get About Window by pressing F1 on keyboard
        ElseIf e.KeyCode = Keys.F1 Then
            frmStartup.Show()
            ' Rename Rom by pressing F2 on keyboard
        ElseIf e.KeyCode = Keys.F2 And ListBoxRoms.SelectedIndex <> -1 Then
            prRenameGame(ListBoxRoms.SelectedIndex)
            ' Focused on Searchbox by pressing F3 on keyboard
        ElseIf e.KeyCode = Keys.F3 Then
            toolbarTxtSearch.Focus()
            ' Reload list of Rom's by pressing F5 on keyboard
        ElseIf e.KeyCode = Keys.F5 Then
            prLoadListOfFiles()
            ' Jump to Searchbox by pressing Letter or Number or WhiteSpace on keyboard
        ElseIf IsLetter OrElse IsWhiteSpace OrElse IsNumber Then
            toolbarTxtSearch.Focus()
            toolbarTxtSearch.Text += ChrW(e.KeyCode)
            toolbarTxtSearch.SelectionStart = 1
            'prMsgToLog("IsLetter = " & IsLetter & "   IsWhiteSpace = " & IsWhiteSpace & "   IsNumber = " & IsNumber)
        End If

    End Sub

    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub TrayIconMenu_Opening(sender As Object, e As CancelEventArgs) Handles TrayIconMenu.Opening
        If Me.WindowState = FormWindowState.Minimized Then
            mnuRestore.Visible = True
            mnuMinimize.Visible = False
        ElseIf Me.WindowState = FormWindowState.Normal Then
            mnuRestore.Visible = False
            mnuMinimize.Visible = True
        End If
    End Sub

    Private Sub mnuRestore_Click(sender As Object, e As EventArgs) Handles mnuRestore.Click
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub mnuMinimize_Click(sender As Object, e As EventArgs) Handles mnuMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        Close()
    End Sub

    Private Sub toolbarTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles toolbarTxtSearch.TextChanged
        prLoadListOfFiles()
    End Sub

    Private Sub toolbarBtnClear_Click(sender As Object, e As EventArgs) Handles toolbarBtnClear.Click
        toolbarTxtSearch.Text = ""
    End Sub

    Private Sub toolbarBtnDendy_Click(sender As Object, e As EventArgs) Handles toolbarBtnNes.Click
        prWriteCurentGamePosition()
        prWriteSettings("main", "CurentGamePlatform", "NES")
        prLoadSettings()
    End Sub

    Private Sub toolbarBtnSnes_Click(sender As Object, e As EventArgs) Handles toolbarBtnSnes.Click
        prWriteCurentGamePosition()
        prWriteSettings("main", "CurentGamePlatform", "SNES")
        prLoadSettings()
    End Sub

    Private Sub toolbarBtnSega_Click(sender As Object, e As EventArgs) Handles toolbarBtnSega.Click
        prWriteCurentGamePosition()
        prWriteSettings("main", "CurentGamePlatform", "SMD")
        prLoadSettings()
    End Sub

    Private Sub toolbarBtnFavorites_Click(sender As Object, e As EventArgs) Handles toolbarBtnFavorites.Click
        If toolbarBtnFavorites.Checked = False Then
            toolbarBtnFavorites.Checked = True
            pFavSearchStatus = "*[FAV]"
            prWriteSettings("main", "CurentFavOrAll", "Fav")
        Else
            toolbarBtnFavorites.Checked = False
            pFavSearchStatus = ""
            prWriteSettings("main", "CurentFavOrAll", "All")
        End If
        prLoadListOfFiles()
    End Sub

    Private Sub toolbarBtnAddToFav_Click(sender As Object, e As EventArgs) Handles toolbarBtnAddToFav.Click
        If ListBoxRoms.SelectedIndex <> -1 Then prAddToFavorite(ListBoxRoms.SelectedIndex)
        prCheckFavorite(ListBoxRoms.SelectedIndex)
    End Sub

    Private Sub toolbarBtnRemoveFromFav_Click(sender As Object, e As EventArgs) Handles toolbarBtnRemoveFromFav.Click
        If ListBoxRoms.SelectedIndex <> -1 Then prRemoveFromFavorite(ListBoxRoms.SelectedIndex)
        prCheckFavorite(ListBoxRoms.SelectedIndex)
    End Sub

    Private Sub toolbarBtnShowSet_Click(sender As Object, e As EventArgs) Handles toolbarBtnShowSet.Click
        If Me.Width <= pMeWidth Then Me.Width = pMeWidth + 280 Else Me.Width = Me.Width - 280 ' open / close setting panel
    End Sub

    Private Sub toolbarBtnShowLog_Click(sender As Object, e As EventArgs) Handles toolbarBtnShowLog.Click
        If Me.Height <= pMeHeight Then Me.Height = pMeHeight + 150 Else Me.Height = Me.Height - 150 ' open / close logfile panel
    End Sub

    Private Sub toolbarBtnShowAbout_Click(sender As Object, e As EventArgs) Handles toolbarBtnShowAbout.Click
        frmStartup.Show()
    End Sub


    Private Sub toolbarBtnTranslated_Click(sender As Object, e As EventArgs) Handles toolbarBtnTranslated.Click
        If toolbarBtnTranslated.Checked = True Then
            pTranslatedStatus = ""
            toolbarBtnTranslated.Checked = False
            prWriteSettings("main", "CurentTranslated", "N") 'No
        Else
            pTranslatedStatus = "*[T"
            toolbarBtnTranslated.Checked = True
            prWriteSettings("main", "CurentTranslated", "Y") 'Yes
        End If
        prLoadListOfFiles()
    End Sub

    Private Sub mnuRenameRom_Click(sender As Object, e As EventArgs) Handles mnuRenameRom.Click
        ' Rename rom file
        prRenameGame(ListBoxRoms.SelectedIndex)
    End Sub

    '// Select Emulator For NES
    Private Sub RadioNes1_Click(sender As Object, e As EventArgs) Handles RadioNes1.Click
        prWriteSettings("main", "CurEmuNes", "1")
        prWriteSettings("main", "Emulator_NES", txtRadioEmuNes1.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioNes2_Click(sender As Object, e As EventArgs) Handles RadioNes2.Click
        prWriteSettings("main", "CurEmuNes", "2")
        prWriteSettings("main", "Emulator_NES", txtRadioEmuNes2.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioNes3_Click(sender As Object, e As EventArgs) Handles RadioNes3.Click
        prWriteSettings("main", "CurEmuNes", "3")
        prWriteSettings("main", "Emulator_NES", txtRadioEmuNes3.Text)
        prLoadSettings()
    End Sub

    '// Select Emulator For SNES
    Private Sub RadioSNes1_Click(sender As Object, e As EventArgs) Handles RadioSnes1.Click
        prWriteSettings("main", "CurEmuSNes", "1")
        prWriteSettings("main", "Emulator_SNES", txtRadioEmuSnes1.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioSNes2_Click(sender As Object, e As EventArgs) Handles RadioSnes2.Click
        prWriteSettings("main", "CurEmuSNes", "2")
        prWriteSettings("main", "Emulator_SNES", txtRadioEmuSnes2.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioSNes3_Click(sender As Object, e As EventArgs) Handles RadioSnes3.Click
        prWriteSettings("main", "CurEmuSNes", "3")
        prWriteSettings("main", "Emulator_SNES", txtRadioEmuSnes3.Text)
        prLoadSettings()
    End Sub

    '// Select Emulator For SEGA
    Private Sub RadioSega1_Click(sender As Object, e As EventArgs) Handles RadioSega1.Click
        prWriteSettings("main", "CurEmuSmd", "1")
        prWriteSettings("main", "Emulator_SMD", txtRadioEmuSega1.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioSega2_Click(sender As Object, e As EventArgs) Handles RadioSega2.Click
        prWriteSettings("main", "CurEmuSmd", "2")
        prWriteSettings("main", "Emulator_SMD", txtRadioEmuSega2.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioSega3_Click(sender As Object, e As EventArgs) Handles RadioSega3.Click
        prWriteSettings("main", "CurEmuSmd", "3")
        prWriteSettings("main", "Emulator_SMD", txtRadioEmuSega3.Text)
        prLoadSettings()
    End Sub

    Private Sub btnOtherNesEmu_Click(sender As Object, e As EventArgs) Handles btnOtherNesEmu.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.Filter = "Emulator NES (*.exe)|*.exe|All files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            txtRadioEmuNes3.Text = OpenFileDialog.FileName
            prWriteSettings("main", "CurEmuNes", "3")
            prWriteSettings("main", "Emulator_NES", txtRadioEmuNes3.Text)
            prLoadSettings()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnOtherSNesEmu_Click(sender As Object, e As EventArgs) Handles btnOtherSNesEmu.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.Filter = "Emulator SNES (*.exe)|*.exe|All files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            txtRadioEmuSnes3.Text = OpenFileDialog.FileName
            prWriteSettings("main", "CurEmuSNes", "3")
            prWriteSettings("main", "Emulator_SNES", txtRadioEmuSnes3.Text)
            prLoadSettings()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnOtherSmdEmu_Click(sender As Object, e As EventArgs) Handles btnOtherSmdEmu.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.Filter = "Emulator SEGA (*.exe)|*.exe|All files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            txtRadioEmuSega3.Text = OpenFileDialog.FileName
            prWriteSettings("main", "CurEmuSmd", "3")
            prWriteSettings("main", "Emulator_SMD", txtRadioEmuSega3.Text)
            prLoadSettings()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mnuAddToFavorite_Click(sender As Object, e As EventArgs) Handles mnuAddToFavorite.Click
        prAddToFavorite(ListBoxRoms.SelectedIndex)
        'prCheckFavorite(ListBoxRoms.SelectedIndex)
    End Sub

    Private Sub mnuRemoveFromFavorite_Click(sender As Object, e As EventArgs) Handles mnuRemoveFromFavorite.Click
        prRemoveFromFavorite(ListBoxRoms.SelectedIndex)
        'prCheckFavorite(ListBoxRoms.SelectedIndex)
    End Sub

    Private Sub Toolbar_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles Toolbar.ItemClicked

    End Sub
End Class