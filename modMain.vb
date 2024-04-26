
' Declaring useful functions
Imports System.IO                       ' working with files and folders
Imports System.Text.RegularExpressions  ' working with regular expressions
Module modMain
    ' Program information
    Public pName = "NESTer ", pVersion = "2.24 ", pBuild = "240426.1740"
    'pVersion is version of program (2) and year of build (2024)
    'pBuild is full date of build
    Public pAuthor = "muratovskyi@gmail.com " ' Vitalii Muratovskyi
    '
    Public pDebugMode = 0
    '
    ' декларирование функций для записи и чтения ini-файлов
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    ' path to the settings file
    Public pLocationSettingFile As String = Application.StartupPath & ".\settings.ini"
    ' Current gaming platform
    Public pCurentGamePlatform As String
    ' Paths to required components
    Public pPatchToEmulator As String
    Public pPatchToRoms As String
    Public pPatchToScreens As String
    Public pPatchToDescriptions As String
    Public pFavSearchStatus As String = ""
    Public pTranslatedStatus As String = ""

    ' For working with file lists
    Public mFilesInDir() As String
    Public mFilesInDirWoExtPath() As String
    Public mFilesInDirWoExtPathTags() As String
    Public mScreensInDir() As String
    Public mScreensInDirWoExtPath() As String
    Public mScreensInDirWoExtPathTags() As String
    Public pCurrentSelIndex As Short ' Current index in the list for calling the picture

    ' Start Program
    Sub prLoadProgram() ' let's Start
        ' We draw the version in the header and in the log
        frmMain.Height = 523
        frmMain.Width = 732

        frmMain.Text = pName & pVersion ' & pBuild
        frmMain.txtAuthorEMail.Text = "muratovskyi@gmail.com"
        prMsgToLog(pName & pVersion & pBuild & vbCrLf)

        frmMain.MainMiniPictureBox.Image = frmMain.MainMiniPictureBox.ErrorImage
        ' get the path where the program is running from
        prMsgToLog("[ FileSystem.CurrentDirectory ] = " & My.Computer.FileSystem.CurrentDirectory)
        prMsgToLog("[ Application.ExecutablePath ] = " & Application.ExecutablePath)

        ' Let's check if the settings file is in place
        If File.Exists(pLocationSettingFile) Then
            prLoadSettings() ' Loading all settings
        Else
            prMsgToLog("Settings file not found." & vbCrLf & "The program load with default parameters" & vbCrLf & "The settings file has been recreated in the application folder")
            ' recreate the settings file in the application folder
            pLocationSettingFile = Application.StartupPath & ".\settings.ini"

            prWriteSettings("main", "DebugMode", "0")
            prWriteSettings("main", "CurentGamePlatform", "NES")

            prWriteSettings("main", "emulator_NES", ".\EMU\Nestopia\nestopia.exe")
            prWriteSettings("main", "emulator_SNES", ".\EMU\ares\ares.exe")
            prWriteSettings("main", "emulator_SMD", ".\EMU\Gens\gens.exe")

            prWriteSettings("main", "roms_NES", ".\ROM\NES")
            prWriteSettings("main", "roms_SNES", ".\ROM\SNES")
            prWriteSettings("main", "roms_SMD", ".\ROM\SMD")

            prWriteSettings("main", "screens_NES", ".\SCRN\NES")
            prWriteSettings("main", "screens_SNES", ".\SCRN\SNES")
            prWriteSettings("main", "screens_SMD", ".\SCRN\SMD")

            prWriteSettings("main", "CurentPositionNES", "0")
            prWriteSettings("main", "CurentPositionSNES", "0")
            prWriteSettings("main", "CurentPositionSMD", "0")

            prWriteSettings("main", "CurEmuNes", "1")
            prWriteSettings("main", "CurEmuSNes", "1")
            prWriteSettings("main", "CurEmuSmd", "1")

            prWriteSettings("main", "CurentFavOrAll", "All")
            prWriteSettings("main", "CurentTranslated", "N") 'Yes or No

            prWriteSettings("emulators", "nestopia", ".\EMU\Nestopia\nestopia.exe")
            prWriteSettings("emulators", "fceux", ".\EMU\fceux\fceux.exe")
            prWriteSettings("emulators", "fusion", ".\EMU\Fusion\Fusion.exe")
            prWriteSettings("emulators", "gens", ".\EMU\Gens\gens.exe")
            prWriteSettings("emulators", "snes9x", ".\EMU\snes9x\snes9x-x64.exe")
            prWriteSettings("emulators", "ares", ".\EMU\ares\ares.exe")

            ' let's load the new settings
            prLoadSettings()
        End If

        frmMain.Activate()
        frmMain.BringToFront()

    End Sub

    ' Loading settings
    Sub prLoadSettings()

        pDebugMode = prLoadSettings("main", "DebugMode")

        Dim CurPosInList As String = ""
        pCurentGamePlatform = prLoadSettings("main", "CurentGamePlatform")                                 ' current gaming platform NES or SMD
        If prLoadSettings("main", "CurentFavOrAll") = "Fav" Then                                           ' current list Favorites or All
            pFavSearchStatus = "*[FAV]"
            frmMain.toolbarBtnFavorites.Checked = True
        End If
        If prLoadSettings("main", "CurentTranslated") = "Y" Then                                         ' current list of translated rom or not
            pTranslatedStatus = "*[T"
            frmMain.toolbarBtnTranslated.Checked = True
        End If

        ' Checking bundled emulators
        Dim nestopia = prLoadSettings("emulators", "nestopia")
        Dim fceux = prLoadSettings("emulators", "fceux")
        Dim fusion = prLoadSettings("emulators", "fusion")
        Dim gens = prLoadSettings("emulators", "gens")
        Dim snes9x = prLoadSettings("emulators", "snes9x")
        Dim ares = prLoadSettings("emulators", "ares")


        ' Checking NES
        If File.Exists(nestopia) Then
            frmMain.RadioNes1.Enabled = True
            frmMain.txtRadioEmuNes1.Enabled = True
            frmMain.txtRadioEmuNes1.Text = nestopia
        End If
        If File.Exists(fceux) Then
            frmMain.RadioNes2.Enabled = True
            frmMain.txtRadioEmuNes2.Enabled = True
            frmMain.txtRadioEmuNes2.Text = fceux
        End If
        ' Checking SNES
        If File.Exists(snes9x) Then
            frmMain.RadioSnes1.Enabled = True
            frmMain.txtRadioEmuSnes1.Enabled = True
            frmMain.txtRadioEmuSnes1.Text = snes9x
        End If
        If File.Exists(ares) Then
            frmMain.RadioSnes2.Enabled = True
            frmMain.txtRadioEmuSnes2.Enabled = True
            frmMain.txtRadioEmuSnes2.Text = ares
        End If
        ' Checking SEGA
        If File.Exists(fusion) Then
            frmMain.RadioSega1.Enabled = True
            frmMain.txtRadioEmuSega1.Enabled = True
            frmMain.txtRadioEmuSega1.Text = fusion
        End If
        If File.Exists(gens) Then
            frmMain.RadioSega2.Enabled = True
            frmMain.txtRadioEmuSega2.Enabled = True
            frmMain.txtRadioEmuSega2.Text = gens
        End If

        frmMain.txtRadioEmuNes3.Text = prLoadSettings("main", "Emulator_NES")
        frmMain.txtRadioEmuSnes3.Text = prLoadSettings("main", "Emulator_SNES")
        frmMain.txtRadioEmuSega3.Text = prLoadSettings("main", "Emulator_SMD")

        Dim CurEmuNes As Integer = prLoadSettings("main", "CurEmuNes")
        If CurEmuNes = 1 Then
            frmMain.RadioNes1.Checked = True
        ElseIf CurEmuNes = 2 Then
            frmMain.RadioNes2.Checked = True
        ElseIf CurEmuNes = 3 Then
            frmMain.RadioNes3.Checked = True
        End If

        Dim CurEmuSNes As Integer = prLoadSettings("main", "CurEmuSNes")
        If CurEmuSNes = 1 Then
            frmMain.RadioSnes1.Checked = True
        ElseIf CurEmuSNes = 2 Then
            frmMain.RadioSnes2.Checked = True
        ElseIf CurEmuSNes = 3 Then
            frmMain.RadioSnes3.Checked = True
        End If

        Dim CurEmuSmd As Integer = prLoadSettings("main", "CurEmuSmd")
        If CurEmuSmd = 1 Then
            frmMain.RadioSega1.Checked = True
        ElseIf CurEmuSmd = 2 Then
            frmMain.RadioSega2.Checked = True
        ElseIf CurEmuSmd = 3 Then
            frmMain.RadioSega3.Checked = True
        End If

        'Paths to all required components
        If pCurentGamePlatform = "NES" Then
            pPatchToEmulator = prLoadSettings("main", "Emulator_NES")
            pPatchToRoms = prLoadSettings("main", "roms_NES")
            pPatchToScreens = prLoadSettings("main", "screens_NES")
            CurPosInList = prLoadSettings("main", "CurentPositionNES")
            frmMain.txtDescrSega.Visible = False
            frmMain.txtDescrDendy.Visible = True
            frmMain.toolbarBtnNes.Checked = True
            frmMain.toolbarBtnSnes.Checked = False
            frmMain.toolbarBtnSega.Checked = False

        ElseIf pCurentGamePlatform = "SNES" Then
            pPatchToEmulator = prLoadSettings("main", "Emulator_SNES")
            pPatchToRoms = prLoadSettings("main", "roms_SNES")
            pPatchToScreens = prLoadSettings("main", "screens_SNES")
            CurPosInList = prLoadSettings("main", "CurentPositionSNES")
            frmMain.txtDescrSega.Visible = False
            frmMain.txtDescrDendy.Visible = True
            frmMain.toolbarBtnNes.Checked = False
            frmMain.toolbarBtnSnes.Checked = True
            frmMain.toolbarBtnSega.Checked = False

        ElseIf pCurentGamePlatform = "SMD" Then
            pPatchToEmulator = prLoadSettings("main", "Emulator_SMD")
            pPatchToRoms = prLoadSettings("main", "roms_SMD")
            pPatchToScreens = prLoadSettings("main", "screens_SMD")
            CurPosInList = prLoadSettings("main", "CurentPositionSMD")
            frmMain.txtDescrSega.Visible = True
            frmMain.txtDescrDendy.Visible = False
            frmMain.toolbarBtnNes.Checked = False
            frmMain.toolbarBtnSnes.Checked = False
            frmMain.toolbarBtnSega.Checked = True

        End If

        prLoadListOfFiles() ' Immediately get a list of files in the last used directory

        If mFilesInDir IsNot Nothing And CurPosInList <> "" Then ' If the files in the folder exist and the last position in the list is read
            If CurPosInList < mFilesInDir.Length Then ' and the last position is less than the number of files in the folder
                frmMain.ListBoxRoms.SelectedIndex = CurPosInList ' will move to the last used position in the list

            End If
        Else
            frmMain.ListBoxRoms.Items.Add(" Looks like the games folder is empty ")
            frmMain.ListBoxRoms.Items.Add(" Check the folder " & pPatchToRoms)
            prMsgToLog("Looks like the games folder is empty. Check the folder " & pPatchToRoms)
        End If
    End Sub

    Sub prLoadListOfFiles() ' Building a list of rom files
        Dim pFileNameWOext As String
        Dim rgexp_Splitter As New Regex("\[")
        Dim rgexp_Splitter2 As New Regex("\(")
        Dim s() As String
        Dim q() As String

        ' if the search input field is empty, hide the button for clearing this field
        If frmMain.toolbarTxtSearch.Text <> "" Then
            frmMain.toolbarBtnClear.Visible = True
            frmMain.toolbarTxtSearch.Width = 127
        Else
            frmMain.toolbarBtnClear.Visible = False
            frmMain.toolbarTxtSearch.Width = 150
        End If

        frmMain.ListBoxRoms.Items.Clear()
        'frmMain.txtLogBox.Clear()
        'pFavSearchStatus = "*[FAV]"
        'Get files from a folder
        If Directory.Exists(pPatchToRoms) Then 'if the folder exists, then look at it
            ' get a list of files in the games folder
            mFilesInDir = Directory.GetFiles(pPatchToRoms, "*" & frmMain.toolbarTxtSearch.Text & pTranslatedStatus & pFavSearchStatus & frmMain.txtFileMask.Text)

            ReDim mFilesInDirWoExtPath(mFilesInDir.Length - 1)
            ReDim mFilesInDirWoExtPathTags(mFilesInDir.Length - 1)

            For i = 0 To mFilesInDir.Length - 1
                'frmMain.lblCountOfItems.Text = i
                pFileNameWOext = Path.GetFileNameWithoutExtension(mFilesInDir(i))
                mFilesInDirWoExtPath(i) = pFileNameWOext

                'Let's separate the name from the tags,
                's(0) - will be the file name,
                's(1) - will be the tags that we will parse further
                s = rgexp_Splitter.Split(pFileNameWOext)
                q = rgexp_Splitter2.Split(s(0))

                'Remove the space if there is one after clearing the tags
                If Right(q(0), 1) = " " Then
                    q(0) = q(0).Remove(Len(q(0)) - 1, 1)
                End If
                'prMsgToLog("|" & q(0) & "|")
                mFilesInDirWoExtPathTags(i) = q(0)
            Next

            frmMain.ListBoxRoms.Items.AddRange(mFilesInDirWoExtPath)
            prMsgToLog(mFilesInDir.Length & " game files found")
            frmMain.cmbStartGame.Visible = True
            prSelectedIndexChanged()


        Else
            prMsgToLog("This folder does not exist or is empty - """ & pPatchToRoms & """")
        End If
    End Sub

    Sub prLoadListOfScreens(ByVal pSelIndex As Short) ' Building a list of image files
        Dim rgexp_Splitter As New Regex("\[")
        Dim rgexp_Splitter2 As New Regex("\(")
        Dim s() As String
        Dim q() As String

        If Directory.Exists(pPatchToScreens) Then 'if the folder exists, then look at it
            frmMain.cmbPrevScreen.Visible = False
            frmMain.cmbNextScreen.Visible = False
            mScreensInDir = Directory.GetFiles(pPatchToScreens, "*" & mFilesInDirWoExtPathTags(pSelIndex) & "*.png") ' we get a list of files in the folder with roms
            ReDim mScreensInDirWoExtPath(mScreensInDir.Length - 1)
            ReDim mScreensInDirWoExtPathTags(mScreensInDir.Length - 1)

            For i = 0 To mScreensInDir.Length - 1
                'frmMain.lblCountOfItems.Text = i
                mScreensInDirWoExtPath(i) = Path.GetFileNameWithoutExtension(mScreensInDir(i))
                'Let's separate the name from the tags,
                's(0) - will be the file name,
                's(1) - will be the tags that we will parse further
                s = rgexp_Splitter.Split(mScreensInDirWoExtPath(i))
                q = rgexp_Splitter2.Split(s(0))
                'Remove the space if there is one after clearing the tags
                If Right(q(0), 1) = " " Then
                    q(0) = q(0).Remove(Len(q(0)) - 1, 1)
                End If
                'prMsgToLog("|" & q(0) & "|")
                mScreensInDirWoExtPathTags(i) = q(0)
            Next

            frmMain.ListBoxScreens.Items.Clear()
            frmMain.ListBoxScreens.Items.AddRange(mScreensInDirWoExtPath)
            prMsgToLog(mScreensInDir.Length & " Screenshots files found " & mFilesInDirWoExtPathTags(pSelIndex))
            frmMain.MainMiniPictureBox.Enabled = True
            frmMain.lblScreensCounter.Visible = True
            If frmMain.ListBoxScreens.Items.Count > 0 Then frmMain.cmbNextScreen.Visible = True

        Else
            prMsgToLog("Such a folder with screenshots is empty or missing - """ & pPatchToScreens & """")
        End If
    End Sub

    ' Just start the emulator
    Sub prExecEmulator()
        Dim ProcID As Short
        'prMsgToLog("pPatchToEmulator " & pPatchToEmulator)
        If File.Exists(pPatchToEmulator) Then
            ProcID = Shell("""" & pPatchToEmulator & """", AppWinStyle.NormalFocus)
        Else
            prMsgToLog("Can't find the emulator :(" & pPatchToEmulator)
            MsgBox("Can't find the emulator :(")
        End If
    End Sub

    ' Rename Rom file
    Sub prRenameGame(ByVal pSelIndex As Short)
        If frmMain.ListBoxRoms.SelectedIndex <> -1 Then
            Dim a As Integer = frmMain.ListBoxRoms.SelectedIndex
            Dim pFileNameOld As String = Path.GetFileName(mFilesInDir(pSelIndex))
            Dim pFilenameRename As String = InputBox(Path.GetFileName(mFilesInDir(pSelIndex)), "Rename ROM file", pFileNameOld)
            If pFilenameRename <> "" And pFilenameRename <> pFileNameOld Then
                Rename(mFilesInDir(pSelIndex), Path.GetDirectoryName(mFilesInDir(pSelIndex)) & "\" & pFilenameRename)
                prLoadListOfFiles()
                frmMain.ListBoxRoms.SelectedIndex = a
            End If
        End If
    End Sub

    ' Add to favorites (in fact, rename, add your tag to the file name)
    Sub prAddToFavorite(ByVal pSelIndex As Short)
        Dim a As Integer = frmMain.ListBoxRoms.SelectedIndex
        Rename(mFilesInDir(pSelIndex),
               Path.GetDirectoryName(mFilesInDir(pSelIndex)) & "\" &
               Path.GetFileNameWithoutExtension(mFilesInDir(pSelIndex)) & "[FAV]" &
               Path.GetExtension(mFilesInDir(pSelIndex)))
        prMsgToLog("Added to Favorites - " & mFilesInDirWoExtPath(pSelIndex))
        prLoadListOfFiles()
        frmMain.ListBoxRoms.SelectedIndex = a
    End Sub

    ' Remove from favorites (rename in fact, delete your tag)
    Sub prRemoveFromFavorite(ByVal pSelIndex As Short)
        Dim a As Integer = frmMain.ListBoxRoms.SelectedIndex
        Rename(mFilesInDir(pSelIndex),
               Path.GetDirectoryName(mFilesInDir(pSelIndex)) &
               "\" & Path.GetFileNameWithoutExtension(mFilesInDir(pSelIndex)).Remove(Len(Path.GetFileNameWithoutExtension(mFilesInDir(pSelIndex))) - 5, 5) &
               Path.GetExtension(mFilesInDir(pSelIndex)))
        prMsgToLog("Removed from Favorites - " & mFilesInDirWoExtPath(pSelIndex))
        prLoadListOfFiles()
        frmMain.ListBoxRoms.SelectedIndex = a
    End Sub

    ' Check if there is a Favorites mark on the game file
    Sub prCheckFavorite(ByVal pSelIndex As Short)
        If frmMain.ListBoxRoms.SelectedIndex > -1 Then
            If Strings.Right(Path.GetFileNameWithoutExtension(mFilesInDir(pSelIndex)), 5) = "[FAV]" Then
                'Toolbar
                frmMain.toolbarLblFavSatus.Visible = True
                frmMain.toolbarLblFavSatusOff.Visible = False
                frmMain.toolbarBtnAddToFav.Visible = False
                frmMain.toolbarBtnRemoveFromFav.Visible = True
                frmMain.mnuAddToFavorite.Visible = False
                frmMain.mnuRemoveFromFavorite.Visible = True
                'prMsgToLog("Check Favorite - True")
            Else
                frmMain.toolbarLblFavSatus.Visible = False
                frmMain.toolbarLblFavSatusOff.Visible = True
                frmMain.toolbarBtnAddToFav.Visible = True
                frmMain.toolbarBtnRemoveFromFav.Visible = False
                frmMain.mnuAddToFavorite.Visible = True
                frmMain.mnuRemoveFromFavorite.Visible = False
                'prMsgToLog("Check Favorite - False")
            End If
        End If
    End Sub



    ' Running ROM on an emulator
    Sub prLoadRom(ByVal pSelIndex As Short) ' Running ROM on an emulator
        Dim ProcID As Short
        If File.Exists(pPatchToEmulator) And File.Exists(mFilesInDir(pSelIndex)) Then ' If the paths are correct and the files exist
            prMsgToLog("Emulator " & pPatchToEmulator)
            prMsgToLog("Rom " & mFilesInDir(pSelIndex))


            prMsgToLog("[ Commandline with full path ] : " & vbCrLf & """" & Path.GetFullPath(pPatchToEmulator) & """ """ & Path.GetFullPath(mFilesInDir(pSelIndex)) & """")


            ProcID = Shell(
                """" & Path.GetFullPath(pPatchToEmulator) & """ """ &
                Path.GetFullPath(mFilesInDir(pSelIndex)) & """", AppWinStyle.NormalFocus) ' Let's set the paths in quotes, in case there are spaces in the resulting path
        Else  ' But what if :)
            prMsgToLog("Incorrect path to the EMULATOR or ROM " & vbCrLf & vbCrLf _
                       & pPatchToEmulator & " " & mFilesInDir(pSelIndex))
            MsgBox("Incorrect path to the EMULATOR or ROM " & vbCrLf & vbCrLf & My.Computer.FileSystem.CurrentDirectory & vbCrLf _
                       & "EMULATOR: " & pPatchToEmulator & vbCrLf & "ROM: " & mFilesInDir(pSelIndex))
        End If
    End Sub

    ' Next screenshot
    Sub prNextScreen()
        If mScreensInDir.Length <> 0 And pCurrentSelIndex <> mScreensInDir.Length - 1 Then
            pCurrentSelIndex = pCurrentSelIndex + 1
            frmMain.cmbPrevScreen.Visible = True : frmViewScreen.cmbPrevScreen.Visible = True
            frmMain.MainMiniPictureBox.Image = Image.FromFile(mScreensInDir(pCurrentSelIndex))
            frmViewScreen.PictureBox2.Image = Image.FromFile(mScreensInDir(pCurrentSelIndex))
            frmMain.lblScreensCounter.Text = pCurrentSelIndex.ToString + 1 & "(" & mScreensInDir.Length & ")"
            frmViewScreen.lblScreensCounter.Text = pCurrentSelIndex.ToString + 1 & "(" & mScreensInDir.Length & ")"
            If pCurrentSelIndex = mScreensInDir.Length - 1 Then frmMain.cmbNextScreen.Visible = False
            If pCurrentSelIndex = mScreensInDir.Length - 1 Then frmViewScreen.cmbNextScreen.Visible = False
        End If
    End Sub

    ' Previous screenshot
    Sub prPrevScreen()
        If mScreensInDir.Length <> 0 And pCurrentSelIndex <> 0 Then
            pCurrentSelIndex = pCurrentSelIndex - 1
            frmMain.cmbNextScreen.Visible = True
            frmViewScreen.cmbNextScreen.Visible = True
            frmMain.MainMiniPictureBox.Image = Image.FromFile(mScreensInDir(pCurrentSelIndex))
            frmViewScreen.PictureBox2.Image = Image.FromFile(mScreensInDir(pCurrentSelIndex))
            frmMain.lblScreensCounter.Text = pCurrentSelIndex.ToString + 1 & "(" & mScreensInDir.Length & ")"
            frmViewScreen.lblScreensCounter.Text = pCurrentSelIndex.ToString + 1 & "(" & mScreensInDir.Length & ")"
            If pCurrentSelIndex = 0 Then frmMain.cmbPrevScreen.Visible = False
            If pCurrentSelIndex = 0 Then frmViewScreen.cmbPrevScreen.Visible = False
        End If
    End Sub

    ' Changing the index in the list
    Public Sub prSelectedIndexChanged()
        If frmMain.ListBoxRoms.SelectedIndex <> -1 Then
            prCheckFavorite(frmMain.ListBoxRoms.SelectedIndex)
            prLoadListOfScreens(frmMain.ListBoxRoms.SelectedIndex)
            prLoadImage(0)
            frmMain.lblCurentPosInList.Text = "[ " & frmMain.ListBoxRoms.SelectedIndex + 1 & " / " & mFilesInDir.Length & " ]"
        ElseIf mFilesInDir.Length >= 0 Then
            On Error Resume Next
            'prMsgToLog("[ " & frmMain.ListBoxRoms.SelectedIndex + 1 & " / " & mFilesInDir.Length & " ]")
            frmMain.lblCurentPosInList.Text = "[ " & frmMain.ListBoxRoms.SelectedIndex + 1 & " / " & mFilesInDir.Length & " ]"
        End If
    End Sub

    ' Remove rom file  (screenshots will remain) !!!!!!!!!!!!!!!!!!!!!!!! *plans to fix it
    Sub prDeleteRom()
        Dim a As Integer
        'MsgBox("frmMain.ListBoxRoms.SelectedIndex '" & frmMain.ListBoxRoms.SelectedIndex & "'")
        a = frmMain.ListBoxRoms.SelectedIndex
        If frmMain.ListBoxRoms.SelectedIndex <> -1 Then
            If MsgBox("Delete ?" & vbCrLf & vbCrLf & "   " & frmMain.ListBoxRoms.Text & "   ", 36) = MsgBoxResult.Yes Then
                File.Delete(mFilesInDir(frmMain.ListBoxRoms.SelectedIndex))
                prLoadListOfFiles()
                frmMain.ListBoxRoms.SelectedIndex = a - 1
            End If
        End If
    End Sub

    ' Picture display
    Sub prLoadImage(ByVal pSelIndex As Short) ' Picture display
        pCurrentSelIndex = pSelIndex

        If frmMain.ListBoxScreens.Items.Count > 0 Then
            ' Let's check if it's a picture or not.,
            ' if yes, you can display it, if not, show a standard placeholder image
            If Path.GetExtension(mScreensInDir(pSelIndex)) = ".png" Then
                'Or Path.GetExtension(mScreensInDir(pSelIndex)) = ".jpg" Or Path.GetExtension(mScreensInDir(pSelIndex)) = ".tga" 
                frmMain.MainMiniPictureBox.Enabled = True
                frmMain.MainMiniPictureBox.Image = Image.FromFile(mScreensInDir(pSelIndex))
                frmViewScreen.PictureBox2.Image = Image.FromFile(mScreensInDir(pSelIndex))
                frmMain.lblScreensCounter.Text = pSelIndex.ToString + 1 & "(" & mScreensInDir.Length & ")"
                frmViewScreen.lblScreensCounter.Text = pSelIndex.ToString + 1 & "(" & mScreensInDir.Length & ")"
            Else
                GoTo mtkPrintErrorImage
            End If
        Else
            GoTo mtkPrintErrorImage
        End If
        Exit Sub

mtkPrintErrorImage:
        frmMain.MainMiniPictureBox.Enabled = False
        frmMain.MainMiniPictureBox.Image = frmMain.MainMiniPictureBox.ErrorImage
        frmViewScreen.PictureBox2.Image = frmMain.MainMiniPictureBox.ErrorImage
        frmMain.lblScreensCounter.Text = "0(0)"
        frmViewScreen.lblScreensCounter.Text = "0(0)"
    End Sub

    ' Save the current position in the list 
    Public Sub prWriteCurentGamePosition()
        If frmMain.ListBoxRoms.SelectedIndex <> -1 Then
            If pCurentGamePlatform = "NES" Then
                prWriteSettings("main", "CurentPositionNES", frmMain.ListBoxRoms.SelectedIndex)
            Else
                prWriteSettings("main", "CurentPositionSMD", frmMain.ListBoxRoms.SelectedIndex)
            End If
        End If
    End Sub

    ' Exit the application
    Public Sub prExitApplication()
        prWriteCurentGamePosition()
        frmMain.TrayIcon.Visible = False
        frmMain.TrayIcon.Dispose()
    End Sub

    ' Write data into a log text field
    Sub prMsgToLog(ByVal pMsg As String)
        frmMain.txtLogBox.AppendText(vbCrLf & pMsg)

        '  Alternative method
        'frmMain.txtLogBox.Text = frmMain.txtLogBox.Text & pMsg & vbCrLf
        'frmMain.txtLogBox.SelectionStart = frmMain.txtLogBox.TextLength ' place the cursor at the end of the textbox
        'frmMain.txtLogBox.ScrollToCaret() ' scroll the textbox to the cursor position



    End Sub

    ' save the data to an ini file
    Public Function prWriteSettings(pSection As String, pParametr As String, pValue As String)
        WritePrivateProfileString(pSection, pParametr, pValue, pLocationSettingFile)
        prMsgToLog("Parameter saved: [ " & pSection & " - " & pParametr & " ] = " & pValue)
        Return "OK"
    End Function

    ' read data from ini file
    Public Function prLoadSettings(pSection As String, pParametr As String)
        Dim rc As String = Strings.StrDup(255, vbNullChar)
        Dim x As Integer
        x = GetPrivateProfileString(pSection, pParametr, "", rc, 255, pLocationSettingFile)
        If x <> 0 And x <> 255 Then
            rc = Strings.Left(rc, x)
            prMsgToLog("Parameter read: [ " & pSection & " - " & pParametr & " ] =  " & rc)
            Return rc
        Else
            rc = "" : Return rc
        End If
    End Function

End Module
