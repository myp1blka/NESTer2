﻿
Imports System.ComponentModel
Imports System.IO
Imports SharpDX


Imports SharpDX.DirectInput




Public Class frmMain
    Public pMeHeight As Integer
    Public pMeWidth As Integer

    Dim WithEvents directInput As DirectInput
    Dim joystick As Joystick
    Dim joystickState As JoystickState
    Dim timer As Timer



    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prLoadProgram()

        pMeHeight = Me.Height
        pMeWidth = Me.Width
        'Me.TopMost = False

        If pDebugMode = 1 Then
            toolbarBtnShowAbout.Image = NESTer2.My.Resources.Resources.info
            If Me.Width <= pMeWidth Then Me.Width = pMeWidth + 280 Else Me.Width = Me.Width - 280 ' open / close setting panel
            If Me.Height <= pMeHeight Then Me.Height = pMeHeight + 150 Else Me.Height = Me.Height - 150 ' open / close logfile panel
        End If



        directInput = New DirectInput()
        CheckForJoystick()
        ' We start the timer to constantly check the state of the joystick
        timer = New Timer()
        timer.Interval = 100 ' Time in milliseconds between updates
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()



    End Sub

    Private Sub CheckForJoystick()
        ' We release the resources associated with the previous joystick
        If joystick IsNot Nothing Then
            joystick.Unacquire()
            joystick.Dispose()
            joystick = Nothing
        End If

        ' Перевіряємо наявність джойстика
        Dim foundJoystick As Boolean = False
        For Each deviceInstance As DeviceInstance In directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly)
            joystick = New Joystick(directInput, deviceInstance.InstanceGuid)
            joystick.Acquire()
            foundJoystick = True
            Exit For ' We process only the first available joystick
        Next

        If Not foundJoystick Then
            'prMsgToLog("No joystick found.")
        End If
    End Sub



    Private Sub Timer_Tick(sender As Object, e As EventArgs)

        Try
            ' We update the state of the joystick
            If joystick IsNot Nothing Then
                joystickState = joystick.GetCurrentState()



                'If joystickState.Buttons(8) Then ' Button Select
                '    If ProcID <> 0 Then
                '        ' Get a process instance by its ID
                '        Dim processId As Integer = ProcID 
                '        Dim processToClose As Process = Process.GetProcessById(processId)
                '        ' Перевірка, чи процес існує
                '        If processToClose IsNot Nothing Then
                '            If Not processToClose.HasExited Then ' We check whether the process has not been completed
                '                processToClose.CloseMainWindow() ' Closing the application through the main window
                '                ' processToClose.Kill() ' If closing through the main window does not work, use the Kill method
                '                ProcID = 0
                '            End If
                '        Else
                '            ProcID = 0
                '            prMsgToLog("Process with given ID = " & ProcID & " not found.")
                '        End If
                '    End If
                'End If

                If joystickState.Buttons(7) Then ' Button Start
                    If ProcID = 0 Then
                        prLoadRom(ListBoxRoms.SelectedIndex)
                    Else
                        ' Obtaining a process instance by its ID
                        Dim processId2 As Integer = ProcID ' Replace 12345 with the actual process ID
                        Dim processToClose2 As Process = Process.GetProcessById(processId2)
                        ' Checking if a process exists
                        If processToClose2 Is Nothing Or processToClose2.HasExited Then ' We check whether the process has not been completed
                            ProcID = 0
                            prLoadRom(ListBoxRoms.SelectedIndex)
                            prMsgToLog("Process with given ID = " & ProcID & " not found.")
                        End If
                    End If
                End If

                ' We check the button presses
                For i As Integer = 0 To joystickState.Buttons.Length - 1
                    If joystickState.Buttons(i) Then
                        prMsgToLog($"The {i} button has been pressed.")

                    End If
                Next



                ' We check the position of the cross
                If joystickState.PointOfViewControllers(0) = 0 Then
                    ListBoxRoms.Focus()
                    SendKeys.Send("{UP}")
                    prMsgToLog("The cross is pressed up.")
                ElseIf joystickState.PointOfViewControllers(0) = 9000 Then
                    prNextScreen()
                    prMsgToLog("The cross on the right is pressed.")
                ElseIf joystickState.PointOfViewControllers(0) = 18000 Then
                    ListBoxRoms.Focus()
                    SendKeys.Send("{DOWN}")
                    prMsgToLog("The cross at the bottom is pressed.")
                ElseIf joystickState.PointOfViewControllers(0) = 27000 Then
                    prPrevScreen()
                    prMsgToLog("The cross on the left is pressed.")
                End If


            End If

        Catch ex As Exception
            prMsgToLog(ex.Message)
            ProcID = 0
        End Try
    End Sub


    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing


        ' Stop the timer and disable the joystick before closing the form
        timer.Stop()
        If joystick IsNot Nothing Then
            joystick.Unacquire()
            joystick.Dispose()
        End If



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
        prWriteCurentGamePosition()
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
            ' Add or Remove from Favorites by pressing F4 on keyboard
        ElseIf e.KeyCode = Keys.F4 And ListBoxRoms.SelectedIndex <> -1 Then
            If Strings.Right(Path.GetFileNameWithoutExtension(mFilesInDir(ListBoxRoms.SelectedIndex)), 5) = "[FAV]" Then
                prRemoveFromFavorite(ListBoxRoms.SelectedIndex)
            Else prAddToFavorite(ListBoxRoms.SelectedIndex)
            End If
            prCheckFavorite(ListBoxRoms.SelectedIndex)
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
        toolbarTxtSearch.Focus()
    End Sub

    Private Sub toolbarBtnDendy_Click(sender As Object, e As EventArgs) Handles toolbarBtnNes.Click
        prWriteCurentGamePosition()
        prIniWriteSettings("main", "CurentGamePlatform", "NES")
        prLoadSettings()
    End Sub

    Private Sub toolbarBtnSnes_Click(sender As Object, e As EventArgs) Handles toolbarBtnSnes.Click
        prWriteCurentGamePosition()
        prIniWriteSettings("main", "CurentGamePlatform", "SNES")
        prLoadSettings()
    End Sub

    Private Sub toolbarBtnSega_Click(sender As Object, e As EventArgs) Handles toolbarBtnSega.Click
        prWriteCurentGamePosition()
        prIniWriteSettings("main", "CurentGamePlatform", "SMD")
        prLoadSettings()
    End Sub

    Private Sub toolbarBtnFavorites_Click(sender As Object, e As EventArgs) Handles toolbarBtnFavorites.Click
        If toolbarBtnFavorites.Checked = False Then
            toolbarBtnFavorites.Checked = True
            pFavSearchStatus = "*[FAV]"
            prIniWriteSettings("main", "CurentFavOrAll", "Fav")
        Else
            toolbarBtnFavorites.Checked = False
            pFavSearchStatus = ""
            prIniWriteSettings("main", "CurentFavOrAll", "All")
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
            prIniWriteSettings("main", "CurentTranslated", "No") ' No
        Else
            pTranslatedStatus = "*[T"
            toolbarBtnTranslated.Checked= True
            prIniWriteSettings("main", "CurentTranslated", "Yes") 'Yes
        End If
        prLoadListOfFiles()
    End Sub

    Private Sub mnuRenameRom_Click(sender As Object, e As EventArgs) Handles mnuRenameRom.Click
        ' Rename rom file
        prRenameGame(ListBoxRoms.SelectedIndex)
    End Sub

    '// Select Emulator For NES
    Private Sub RadioNes1_Click(sender As Object, e As EventArgs) Handles RadioNes1.Click
        prIniWriteSettings("main", "CurEmuNes", "1")
        prIniWriteSettings("main", "emulator_NES1", comboNes1.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioNes2_Click(sender As Object, e As EventArgs) Handles RadioNes2.Click
        prIniWriteSettings("main", "CurEmuNes", "2")
        prIniWriteSettings("main", "emulator_NES2", comboNes2.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioNes3_Click(sender As Object, e As EventArgs) Handles RadioNes3.Click
        prIniWriteSettings("main", "CurEmuNes", "3")
        prIniWriteSettings("main", "emulator_NES3", comboNes3.Text)
        prLoadSettings()
    End Sub

    '// Select Emulator For SNES
    Private Sub RadioSNes1_Click(sender As Object, e As EventArgs) Handles RadioSnes1.Click
        prIniWriteSettings("main", "CurEmuSNes", "1")
        prIniWriteSettings("main", "Emulator_SNES1", comboSNes1.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioSNes2_Click(sender As Object, e As EventArgs) Handles RadioSnes2.Click
        prIniWriteSettings("main", "CurEmuSNes", "2")
        prIniWriteSettings("main", "Emulator_SNES2", comboSNes2.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioSNes3_Click(sender As Object, e As EventArgs) Handles RadioSnes3.Click
        prIniWriteSettings("main", "CurEmuSNes", "3")
        prIniWriteSettings("main", "Emulator_SNES3", comboSNes3.Text)
        prLoadSettings()
    End Sub

    '// Select Emulator For SEGA
    Private Sub RadioSega1_Click(sender As Object, e As EventArgs) Handles RadioSega1.Click
        prIniWriteSettings("main", "CurEmuSmd", "1")
        prIniWriteSettings("main", "Emulator_SMD1", comboSmd1.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioSega2_Click(sender As Object, e As EventArgs) Handles RadioSega2.Click
        prIniWriteSettings("main", "CurEmuSmd", "2")
        prIniWriteSettings("main", "Emulator_SMD2", comboSmd2.Text)
        prLoadSettings()
    End Sub

    Private Sub RadioSega3_Click(sender As Object, e As EventArgs) Handles RadioSega3.Click
        prIniWriteSettings("main", "CurEmuSmd", "3")
        prIniWriteSettings("main", "Emulator_SMD3", comboSmd3.Text)
        prLoadSettings()
    End Sub

    Private Sub mnuAddToFavorite_Click(sender As Object, e As EventArgs) Handles mnuAddToFavorite.Click
        prAddToFavorite(ListBoxRoms.SelectedIndex)
        'prCheckFavorite(ListBoxRoms.SelectedIndex)
    End Sub

    Private Sub mnuRemoveFromFavorite_Click(sender As Object, e As EventArgs) Handles mnuRemoveFromFavorite.Click
        prRemoveFromFavorite(ListBoxRoms.SelectedIndex)
        'prCheckFavorite(ListBoxRoms.SelectedIndex)
    End Sub

    Private Sub cmbOpenSelfFolder_Click(sender As Object, e As EventArgs) Handles cmbOpenSelfFolder.Click
        Process.Start(My.Computer.FileSystem.CurrentDirectory)
    End Sub



    Private Sub comboNes1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboNes1.SelectedIndexChanged
        prIniWriteSettings("main", "emulator_NES1", comboNes1.Text)
    End Sub

    Private Sub comboNes2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboNes2.SelectedIndexChanged
        prIniWriteSettings("main", "emulator_NES2", comboNes2.Text)
    End Sub

    Private Sub comboNes3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboNes3.SelectedIndexChanged
        prIniWriteSettings("main", "emulator_NES3", comboNes3.Text)
    End Sub




    Private Sub comboSNes1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSNes1.SelectedIndexChanged
        prIniWriteSettings("main", "emulator_SNES1", comboSNes1.Text)
    End Sub

    Private Sub comboSNes2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSNes2.SelectedIndexChanged
        prIniWriteSettings("main", "emulator_SNES2", comboSNes2.Text)
    End Sub

    Private Sub comboSNes3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSNes3.SelectedIndexChanged
        prIniWriteSettings("main", "emulator_SNES3", comboSNes3.Text)
    End Sub





    Private Sub comboSmd1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSmd1.SelectedIndexChanged
        prIniWriteSettings("main", "emulator_SMD1", comboSmd1.Text)
    End Sub

    Private Sub comboSmd2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSmd2.SelectedIndexChanged
        prIniWriteSettings("main", "emulator_SMD2", comboSmd2.Text)
    End Sub

    Private Sub comboSmd3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSmd3.SelectedIndexChanged
        prIniWriteSettings("main", "emulator_SMD3", comboSmd3.Text)
    End Sub

    Private Sub RadioSnes2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioSnes2.CheckedChanged

    End Sub
End Class