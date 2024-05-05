
' Declaring useful functions
Imports System.IO                       ' working with files and folders
Imports System.Reflection
Imports System.Text.RegularExpressions  ' working with regular expressions
Module modMain
    ' Program information
    Public pName = "NESTer ", pVersion = "2.24 ", pBuild = "240505.2321 beta"
    'pVersion is version of program (2) and year of build (2024)
    'pBuild is full date and time of build
    Public pAuthor = "muratovskyi@gmail.com " ' Vitalii Muratovskyi
    '
    '
    '
    ' declarate function for read n write ini files
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    ' path to the settings file
    Public pLocationSettingFile As String = Application.StartupPath & ".\settings.ini"
    Public pDebugMode = 0 ' by default debyg mode off (0)
    Public pDebugPath = "" ' if debug mode off, debug path from program executable file is empty
    ' Current gaming platform
    Public pCurentGamePlatform As String
    ' Paths to required components
    Public pPatchToEmulatorsFolder As String
    Public mEmuFoldersInDir() As String
    Public mEmuNameFoldersInDir(10, 5) As String
    Public pPatchToEmulator As String
    Public pPatchToRoms As String
    Public pPatchToScreens As String
    Public pPatchToDescriptions As String ' not used yet, it was planned to add text files with a description
    Public pFavSearchStatus As String = ""
    Public pTranslatedStatus As String = ""

    ' For working with file lists
    Public mFilesInDir() As String
    Public mFilesInDirWoExtPath() As String
    Public mFilesInDirWoExtPathTags() As String
    Public mScreensInDir() As String
    Public mScreensInDirWoExtPath() As String
    Public mScreensInDirWoExtPathTags() As String

    Public mFoldersEmulatorsInDir As String
    Public mFilesInEmulatorDir As String


    Public pCurrentSelIndex As Short ' Current index in the list for calling the picture

    ' Start Program
    Sub prLoadProgram() ' let's Start
        ' We draw the version in the header and in the log
        frmMain.Height = 523
        frmMain.Width = 732

        frmMain.Text = pName & pVersion & pBuild
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


            prIniWriteSettings("main", "DebugMode", "0")
            prIniWriteSettings("main", "CurentGamePlatform", "NES")



            prIniWriteSettings("main", "roms_NES", ".\ROM\NES")
            prIniWriteSettings("main", "roms_SNES", ".\ROM\SNES")
            prIniWriteSettings("main", "roms_SMD", ".\ROM\SMD")

            prIniWriteSettings("main", "screens_NES", ".\SCRN\NES")
            prIniWriteSettings("main", "screens_SNES", ".\SCRN\SNES")
            prIniWriteSettings("main", "screens_SMD", ".\SCRN\SMD")

            prIniWriteSettings("main", "CurentPositionNES", "0")
            prIniWriteSettings("main", "CurentPositionSNES", "0")
            prIniWriteSettings("main", "CurentPositionSMD", "0")

            prIniWriteSettings("main", "CurEmuNes", "1")
            prIniWriteSettings("main", "CurEmuSNes", "1")
            prIniWriteSettings("main", "CurEmuSmd", "1")

            prIniWriteSettings("main", "CurentFavOrAll", "All")
            prIniWriteSettings("main", "CurentTranslated", "No") 'Yes or No

            prIniWriteSettings("main", "emulator_NES1", "Nestopia_1.51.1")
            prIniWriteSettings("main", "emulator_NES2", "fceux_2.2.3")
            prIniWriteSettings("main", "emulator_NES3", "")

            prIniWriteSettings("main", "emulator_SNES1", "snes9x_1.62.3")
            prIniWriteSettings("main", "emulator_SNES2", "ares_137")
            prIniWriteSettings("main", "emulator_SNES3", "")

            prIniWriteSettings("main", "emulator_SMD1", "Fusion_3.64")
            prIniWriteSettings("main", "emulator_SMD2", "Gens_GS.r7")
            prIniWriteSettings("main", "emulator_SMD3", "N")


            ' let's load the new settings
            prLoadSettings()
        End If

        frmMain.Activate()
        frmMain.BringToFront()

    End Sub

    ' Loading settings
    Sub prLoadSettings()

        If Strings.Right(My.Computer.FileSystem.CurrentDirectory, 5) = "Debug" Or prIniLoadSettings("main", "DebugMode") = 1 Then pDebugMode = 1
        If pDebugMode = 1 Then
            pDebugPath = "..\."
            pLocationSettingFile = pDebugPath & ".\settings.ini"
        End If
        ' add this "..\." prefix before all path where find all files (example IDE path \NESTer2\bin\Debug transform to ..\..\ root of NESTer2 )







        pPatchToEmulatorsFolder = pDebugPath & prIniLoadSettings("main", "emulators_folder") ' Folder where we stored all our emulators

        frmMain.comboNes1.Items.Clear()
        frmMain.comboNes2.Items.Clear()
        frmMain.comboNes3.Items.Clear()
        frmMain.comboSNes1.Items.Clear()
        frmMain.comboSNes2.Items.Clear()
        frmMain.comboSNes3.Items.Clear()
        frmMain.comboSmd1.Items.Clear()
        frmMain.comboSmd2.Items.Clear()
        frmMain.comboSmd3.Items.Clear()

        If Directory.Exists(pPatchToEmulatorsFolder) Then
            mEmuFoldersInDir = Directory.GetDirectories(pPatchToEmulatorsFolder)
            prMsgToLog(mEmuFoldersInDir.Length & " - emulators folders found")




            ReDim mEmuNameFoldersInDir(mEmuFoldersInDir.Length, 5)
            For i = 0 To mEmuFoldersInDir.Length - 1
                ' path to emulator
                mEmuNameFoldersInDir(i, 0) = mEmuFoldersInDir(i)

                'name folder of the emulator
                Dim mSplitPath() = Split(Path.GetFullPath(mEmuFoldersInDir(i)), "\")
                mEmuNameFoldersInDir(i, 1) = mSplitPath(mSplitPath.Length - 1)

                ' exe file of the emulator
                Dim mExeInFolder() = Directory.GetFiles(Path.GetFullPath(mEmuFoldersInDir(i)), "*.exe")
                'mEmuNameFoldersInDir(i, 2) = mExeInFolder(0) ' Full path to Exe
                Dim mSplitExeInFolder() = Split(Path.GetFullPath(mExeInFolder(0)), "\")
                mEmuNameFoldersInDir(i, 2) = mSplitExeInFolder(mSplitExeInFolder.Length - 1) ' Only Exe file


                'prMsgToLog(mEmuNameFoldersInDir(i, 0) & vbCrLf & mEmuNameFoldersInDir(i, 1) & vbCrLf & mEmuNameFoldersInDir(i, 2))
                'prMsgToLog("   [   " & mEmuNameFoldersInDir(i, 0) & "\" & mEmuNameFoldersInDir(i, 2) & "   ]")
            Next


            For i = 0 To mEmuFoldersInDir.Length - 1

                frmMain.comboNes1.Items.Add(mEmuNameFoldersInDir(i, 1))
                frmMain.comboNes2.Items.Add(mEmuNameFoldersInDir(i, 1))
                frmMain.comboNes3.Items.Add(mEmuNameFoldersInDir(i, 1))

                frmMain.comboSNes1.Items.Add(mEmuNameFoldersInDir(i, 1))
                frmMain.comboSNes2.Items.Add(mEmuNameFoldersInDir(i, 1))
                frmMain.comboSNes3.Items.Add(mEmuNameFoldersInDir(i, 1))

                frmMain.comboSmd1.Items.Add(mEmuNameFoldersInDir(i, 1))
                frmMain.comboSmd2.Items.Add(mEmuNameFoldersInDir(i, 1))
                frmMain.comboSmd3.Items.Add(mEmuNameFoldersInDir(i, 1))

            Next



            Dim pEmulatorNes1 = prIniLoadSettings("main", "emulator_NES1")
            Dim pEmulatorNes2 = prIniLoadSettings("main", "emulator_NES2")
            Dim pEmulatorNes3 = prIniLoadSettings("main", "emulator_NES3")

            Dim pEmulatorSNes1 = prIniLoadSettings("main", "emulator_SNES1")
            Dim pEmulatorSNes2 = prIniLoadSettings("main", "emulator_SNES2")
            Dim pEmulatorSNes3 = prIniLoadSettings("main", "emulator_SNES3")

            Dim pEmulatorSmd1 = prIniLoadSettings("main", "emulator_SMD1")
            Dim pEmulatorSmd2 = prIniLoadSettings("main", "emulator_SMD2")
            Dim pEmulatorSmd3 = prIniLoadSettings("main", "emulator_SMD3")



            frmMain.comboNes1.SelectedIndex = frmMain.comboNes1.FindString(pEmulatorNes1)
            frmMain.comboNes2.SelectedIndex = frmMain.comboNes2.FindString(pEmulatorNes2)
            frmMain.comboNes3.SelectedIndex = frmMain.comboNes3.FindString(pEmulatorNes3)

            frmMain.comboSNes1.SelectedIndex = frmMain.comboSNes1.FindString(pEmulatorSNes1)
            frmMain.comboSNes2.SelectedIndex = frmMain.comboSNes2.FindString(pEmulatorSNes2)
            frmMain.comboSNes3.SelectedIndex = frmMain.comboSNes3.FindString(pEmulatorSNes3)

            frmMain.comboSmd1.SelectedIndex = frmMain.comboSmd1.FindString(pEmulatorSmd1)
            frmMain.comboSmd2.SelectedIndex = frmMain.comboSmd2.FindString(pEmulatorSmd2)
            frmMain.comboSmd3.SelectedIndex = frmMain.comboSmd3.FindString(pEmulatorSmd3)



        Else
            prMsgToLog("Emulators folder NOT found" & vbCrLf & "   !!! [ " & pPatchToEmulatorsFolder & " ] !!!")
        End If




















        Dim CurPosInList As String = ""
        pCurentGamePlatform = prIniLoadSettings("main", "CurentGamePlatform")                                 ' current gaming platform NES or SNES or SMD
        If prIniLoadSettings("main", "CurentFavOrAll") = "Fav" Then                                           ' current list Favorites or All
            pFavSearchStatus = "*[FAV]"
            frmMain.toolbarBtnFavorites.Checked = True
        End If
        If prIniLoadSettings("main", "CurentTranslated") = "Yes" Then                                         ' current list of translated rom yes or not
            pTranslatedStatus = "*[T"
            frmMain.toolbarBtnTranslated.Checked = True
        End If





        Dim pCurentSelectedEmulatorNesIndex As String = 0
        Dim pCurentSelectedEmulatorSNesIndex As String = 0
        Dim pCurentSelectedEmulatorSmdIndex As String = 0

        Dim CurEmuNes As Integer = prIniLoadSettings("main", "CurEmuNes")

        If CurEmuNes = 1 Then
            frmMain.RadioNes1.Checked = True
            pCurentSelectedEmulatorNesIndex = frmMain.comboNes1.SelectedIndex
        ElseIf CurEmuNes = 2 Then
            frmMain.RadioNes2.Checked = True
            pCurentSelectedEmulatorNesIndex = frmMain.comboNes2.SelectedIndex
        ElseIf CurEmuNes = 3 Then
            frmMain.RadioNes3.Checked = True
            pCurentSelectedEmulatorNesIndex = frmMain.comboNes3.SelectedIndex
        End If

        Dim CurEmuSNes As Integer = prIniLoadSettings("main", "CurEmuSNes")

        If CurEmuSNes = 1 Then
            frmMain.RadioSnes1.Checked = True
            pCurentSelectedEmulatorSNesIndex = frmMain.comboSNes1.SelectedIndex
        ElseIf CurEmuSNes = 2 Then
            frmMain.RadioSnes2.Checked = True
            pCurentSelectedEmulatorSNesIndex = frmMain.comboSNes2.SelectedIndex
        ElseIf CurEmuSNes = 3 Then
            frmMain.RadioSnes3.Checked = True
            pCurentSelectedEmulatorSNesIndex = frmMain.comboSNes3.SelectedIndex
        End If

        Dim CurEmuSmd As Integer = prIniLoadSettings("main", "CurEmuSmd")

        If CurEmuSmd = 1 Then
            frmMain.RadioSega1.Checked = True
            pCurentSelectedEmulatorSmdIndex = frmMain.comboSmd1.SelectedIndex
        ElseIf CurEmuSmd = 2 Then
            frmMain.RadioSega2.Checked = True
            pCurentSelectedEmulatorSmdIndex = frmMain.comboSmd2.SelectedIndex
        ElseIf CurEmuSmd = 3 Then
            frmMain.RadioSega3.Checked = True
            pCurentSelectedEmulatorSmdIndex = frmMain.comboSmd3.SelectedIndex
        End If









        'Paths to all required components
        If pCurentGamePlatform = "NES" Then

            pPatchToEmulator = mEmuNameFoldersInDir(pCurentSelectedEmulatorNesIndex, 0) & "\" & mEmuNameFoldersInDir(pCurentSelectedEmulatorNesIndex, 2)
            pPatchToRoms = pDebugPath & prIniLoadSettings("main", "roms_NES")
            pPatchToScreens = pDebugPath & prIniLoadSettings("main", "screens_NES")
            CurPosInList = prIniLoadSettings("main", "CurentPositionNES")
            frmMain.txtDescrSega.Visible = False
            frmMain.txtDescrDendy.Visible = True
            frmMain.toolbarBtnNes.Checked = True
            frmMain.toolbarBtnSnes.Checked = False
            frmMain.toolbarBtnSega.Checked = False

        ElseIf pCurentGamePlatform = "SNES" Then

            'pPatchToEmulator = pDebugPath & prIniLoadSettings("main", "Emulator_SNES")
            pPatchToEmulator = mEmuNameFoldersInDir(pCurentSelectedEmulatorSNesIndex, 0) & "\" & mEmuNameFoldersInDir(pCurentSelectedEmulatorSNesIndex, 2)
            pPatchToRoms = pDebugPath & prIniLoadSettings("main", "roms_SNES")
            pPatchToScreens = pDebugPath & prIniLoadSettings("main", "screens_SNES")
            CurPosInList = prIniLoadSettings("main", "CurentPositionSNES")
            frmMain.txtDescrSega.Visible = False
            frmMain.txtDescrDendy.Visible = True
            frmMain.toolbarBtnNes.Checked = False
            frmMain.toolbarBtnSnes.Checked = True
            frmMain.toolbarBtnSega.Checked = False

        ElseIf pCurentGamePlatform = "SMD" Then

            'pPatchToEmulator = pDebugPath & prIniLoadSettings("main", "Emulator_SMD")
            pPatchToEmulator = mEmuNameFoldersInDir(pCurentSelectedEmulatorSmdIndex, 0) & "\" & mEmuNameFoldersInDir(pCurentSelectedEmulatorSmdIndex, 2)
            pPatchToRoms = pDebugPath & prIniLoadSettings("main", "roms_SMD")
            pPatchToScreens = pDebugPath & prIniLoadSettings("main", "screens_SMD")
            CurPosInList = prIniLoadSettings("main", "CurentPositionSMD")
            frmMain.txtDescrSega.Visible = True
            frmMain.txtDescrDendy.Visible = False
            frmMain.toolbarBtnNes.Checked = False
            frmMain.toolbarBtnSnes.Checked = False
            frmMain.toolbarBtnSega.Checked = True

        End If






        mFilesInDir = Nothing ' clear
        prLoadListOfFiles() ' Immediately get a list of files in the last used directory

        If mFilesInDir IsNot Nothing And CurPosInList <> "" Then ' If the files in the folder exist and the last position in the list is read
            If CurPosInList < mFilesInDir.Length Then ' and the last position is less than the number of files in the folder
                frmMain.ListBoxRoms.SelectedIndex = CurPosInList ' will move to the last used position in the list

            End If
        Else
            frmMain.ListBoxRoms.Items.Add(" Looks Like the games folder Is empty ")
            frmMain.ListBoxRoms.Items.Add(" Check the folder " & pPatchToRoms)
            prMsgToLog("Looks Like the games folder Is empty. Check the folder " & pPatchToRoms)
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

        'Get files from a folder
        If Directory.Exists(pPatchToRoms) Then 'if the folder exists, then look at it
            ' get a list of files in the games folder
            'mFilesInDir = Nothing
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
            prMsgToLog("This folder does Not exist Or Is empty - """ & pPatchToRoms & """")
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
            prMsgToLog(mScreensInDir.Length & " Screenshots files found   [  " & mFilesInDirWoExtPath(pSelIndex) & "   ]  ")
            frmMain.MainMiniPictureBox.Enabled = True
            frmMain.lblScreensCounter.Visible = True
            If frmMain.ListBoxScreens.Items.Count > 0 Then frmMain.cmbNextScreen.Visible = True

        Else
            prMsgToLog("Such a folder With screenshots Is empty Or missing - """ & pPatchToScreens & """")
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
                prMsgToLog("[Renamed]" & vbCrLf & pFileNameOld & vbCrLf & "   to" & vbCrLf & pFilenameRename)
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
            prMsgToLog("Emulator  " & pPatchToEmulator & vbCrLf &
                       "Rom        " & mFilesInDir(pSelIndex))
            prMsgToLog("[ CommandLine with full path ]" & vbCrLf &
                       """" & Path.GetFullPath(pPatchToEmulator) & """ """ & Path.GetFullPath(mFilesInDir(pSelIndex)) & """")


            ProcID = Shell(
                """" & Path.GetFullPath(pPatchToEmulator) & """ """ &
                Path.GetFullPath(mFilesInDir(pSelIndex)) & """", AppWinStyle.NormalFocus) ' Let's set the paths in quotes, in case there are spaces in the resulting path
        Else  ' But what if :)
            prMsgToLog("Incorrect path to the EMULATOR or ROM " & vbCrLf & vbCrLf _
                       & pPatchToEmulator & " " & mFilesInDir(pSelIndex))
            MsgBox("Incorrect path to the EMULATOR or ROM " & vbCrLf & vbCrLf & My.Computer.FileSystem.CurrentDirectory & vbCrLf _
                       & "EMULATOR:   " & pPatchToEmulator & vbCrLf & "ROM:               " & mFilesInDir(pSelIndex))
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
                prMsgToLog("[Deleted]" & vbCrLf & frmMain.ListBoxRoms.Text)
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
                prIniWriteSettings("main", "CurentPositionNES", frmMain.ListBoxRoms.SelectedIndex)
            ElseIf pCurentGamePlatform = "SNES" Then
                prIniWriteSettings("main", "CurentPositionSNES", frmMain.ListBoxRoms.SelectedIndex)
            ElseIf pCurentGamePlatform = "SMD" Then
                prIniWriteSettings("main", "CurentPositionSMD", frmMain.ListBoxRoms.SelectedIndex)
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
        'frmMain.txtLogBox.AppendText(vbCrLf & pMsg & "      [ " & DateTime.Now.ToString("HH:mm:ss") & " ]")

        '  Alternative method
        'frmMain.txtLogBox.Text = frmMain.txtLogBox.Text & pMsg & vbCrLf
        'frmMain.txtLogBox.SelectionStart = frmMain.txtLogBox.TextLength ' place the cursor at the end of the textbox
        'frmMain.txtLogBox.ScrollToCaret() ' scroll the textbox to the cursor position



    End Sub

    ' save the data to an ini file
    Public Function prIniWriteSettings(pSection As String, pParametr As String, pValue As String)
        WritePrivateProfileString(pSection, pParametr, pValue, pLocationSettingFile)
        prMsgToLog("Parameter saved: [ " & pSection & " - " & pParametr & " ] = " & pValue)
        Return "OK"
    End Function

    ' read data from ini file
    Public Function prIniLoadSettings(pSection As String, pParametr As String)
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
