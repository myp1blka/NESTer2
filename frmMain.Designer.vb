<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtLogBox = New System.Windows.Forms.TextBox()
        Me.cmbReloadList = New System.Windows.Forms.Button()
        Me.ListBoxRoms = New System.Windows.Forms.ListBox()
        Me.ContListMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAddToFavorite = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoveFromFavorite = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRenameRom = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteRom = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbStartEmulator = New System.Windows.Forms.Button()
        Me.ListBoxScreens = New System.Windows.Forms.ListBox()
        Me.txtDescrDendy = New System.Windows.Forms.TextBox()
        Me.cmbStartGame = New System.Windows.Forms.Button()
        Me.cmbPrevScreen = New System.Windows.Forms.Button()
        Me.lblScreensCounter = New System.Windows.Forms.Label()
        Me.cmbNextScreen = New System.Windows.Forms.Button()
        Me.txtDescrSega = New System.Windows.Forms.TextBox()
        Me.txtAuthorEMail = New System.Windows.Forms.TextBox()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TrayIconMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMinimize = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.Toolbar = New System.Windows.Forms.ToolStrip()
        Me.toolbarLabelSearch = New System.Windows.Forms.ToolStripLabel()
        Me.toolbarTxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.toolbarBtnClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolbarBtnNes = New System.Windows.Forms.ToolStripButton()
        Me.toolbarBtnSnes = New System.Windows.Forms.ToolStripButton()
        Me.toolbarBtnSega = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolbarBtnFavorites = New System.Windows.Forms.ToolStripButton()
        Me.toolbarBtnTranslated = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolbarBtnAddToFav = New System.Windows.Forms.ToolStripButton()
        Me.toolbarBtnRemoveFromFav = New System.Windows.Forms.ToolStripButton()
        Me.toolbarLblFavSatus = New System.Windows.Forms.ToolStripLabel()
        Me.toolbarLblFavSatusOff = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolbarBtnShowAbout = New System.Windows.Forms.ToolStripButton()
        Me.toolbarBtnShowLog = New System.Windows.Forms.ToolStripButton()
        Me.toolbarBtnShowSet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.MainMiniPictureBox = New System.Windows.Forms.PictureBox()
        Me.lblCurentPosInList = New System.Windows.Forms.Label()
        Me.txtFileMask = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioNes1 = New System.Windows.Forms.RadioButton()
        Me.RadioNes2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnOtherNesEmu = New System.Windows.Forms.Button()
        Me.txtRadioEmuNes3 = New System.Windows.Forms.TextBox()
        Me.txtRadioEmuNes2 = New System.Windows.Forms.TextBox()
        Me.txtRadioEmuNes1 = New System.Windows.Forms.TextBox()
        Me.RadioNes3 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOtherSmdEmu = New System.Windows.Forms.Button()
        Me.txtRadioEmuSega3 = New System.Windows.Forms.TextBox()
        Me.txtRadioEmuSega2 = New System.Windows.Forms.TextBox()
        Me.RadioSega3 = New System.Windows.Forms.RadioButton()
        Me.txtRadioEmuSega1 = New System.Windows.Forms.TextBox()
        Me.RadioSega2 = New System.Windows.Forms.RadioButton()
        Me.RadioSega1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnOtherSNesEmu = New System.Windows.Forms.Button()
        Me.txtRadioEmuSnes3 = New System.Windows.Forms.TextBox()
        Me.txtRadioEmuSnes2 = New System.Windows.Forms.TextBox()
        Me.txtRadioEmuSnes1 = New System.Windows.Forms.TextBox()
        Me.RadioSnes3 = New System.Windows.Forms.RadioButton()
        Me.RadioSnes1 = New System.Windows.Forms.RadioButton()
        Me.RadioSnes2 = New System.Windows.Forms.RadioButton()
        Me.ContListMenu.SuspendLayout()
        Me.TrayIconMenu.SuspendLayout()
        Me.Toolbar.SuspendLayout()
        CType(Me.MainMiniPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLogBox
        '
        Me.txtLogBox.Location = New System.Drawing.Point(13, 489)
        Me.txtLogBox.Multiline = True
        Me.txtLogBox.Name = "txtLogBox"
        Me.txtLogBox.ReadOnly = True
        Me.txtLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLogBox.Size = New System.Drawing.Size(689, 132)
        Me.txtLogBox.TabIndex = 0
        '
        'cmbReloadList
        '
        Me.cmbReloadList.Location = New System.Drawing.Point(846, 379)
        Me.cmbReloadList.Name = "cmbReloadList"
        Me.cmbReloadList.Size = New System.Drawing.Size(127, 23)
        Me.cmbReloadList.TabIndex = 1
        Me.cmbReloadList.Tag = ""
        Me.cmbReloadList.Text = "Reload List"
        Me.cmbReloadList.UseVisualStyleBackColor = True
        '
        'ListBoxRoms
        '
        Me.ListBoxRoms.ContextMenuStrip = Me.ContListMenu
        Me.ListBoxRoms.FormattingEnabled = True
        Me.ListBoxRoms.Location = New System.Drawing.Point(12, 28)
        Me.ListBoxRoms.Name = "ListBoxRoms"
        Me.ListBoxRoms.Size = New System.Drawing.Size(415, 433)
        Me.ListBoxRoms.TabIndex = 7
        '
        'ContListMenu
        '
        Me.ContListMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddToFavorite, Me.mnuRemoveFromFavorite, Me.mnuRenameRom, Me.mnuDeleteRom})
        Me.ContListMenu.Name = "ContextMenu"
        Me.ContListMenu.Size = New System.Drawing.Size(197, 92)
        '
        'mnuAddToFavorite
        '
        Me.mnuAddToFavorite.Image = Global.NESTer2.My.Resources.Resources.favorits_add1
        Me.mnuAddToFavorite.Name = "mnuAddToFavorite"
        Me.mnuAddToFavorite.Size = New System.Drawing.Size(196, 22)
        Me.mnuAddToFavorite.Text = "Add to Favorites"
        '
        'mnuRemoveFromFavorite
        '
        Me.mnuRemoveFromFavorite.Image = Global.NESTer2.My.Resources.Resources.favorits_remove
        Me.mnuRemoveFromFavorite.Name = "mnuRemoveFromFavorite"
        Me.mnuRemoveFromFavorite.Size = New System.Drawing.Size(196, 22)
        Me.mnuRemoveFromFavorite.Text = "Remove from Favorites"
        '
        'mnuRenameRom
        '
        Me.mnuRenameRom.Image = Global.NESTer2.My.Resources.Resources.app_edit
        Me.mnuRenameRom.Name = "mnuRenameRom"
        Me.mnuRenameRom.Size = New System.Drawing.Size(196, 22)
        Me.mnuRenameRom.Text = "Rename"
        '
        'mnuDeleteRom
        '
        Me.mnuDeleteRom.Image = Global.NESTer2.My.Resources.Resources.trash
        Me.mnuDeleteRom.Name = "mnuDeleteRom"
        Me.mnuDeleteRom.Size = New System.Drawing.Size(196, 22)
        Me.mnuDeleteRom.Text = "Delete"
        '
        'cmbStartEmulator
        '
        Me.cmbStartEmulator.Location = New System.Drawing.Point(850, 28)
        Me.cmbStartEmulator.Name = "cmbStartEmulator"
        Me.cmbStartEmulator.Size = New System.Drawing.Size(127, 23)
        Me.cmbStartEmulator.TabIndex = 8
        Me.cmbStartEmulator.Tag = ""
        Me.cmbStartEmulator.Text = "Start Emulator"
        Me.cmbStartEmulator.UseVisualStyleBackColor = True
        '
        'ListBoxScreens
        '
        Me.ListBoxScreens.FormattingEnabled = True
        Me.ListBoxScreens.Location = New System.Drawing.Point(719, 489)
        Me.ListBoxScreens.Name = "ListBoxScreens"
        Me.ListBoxScreens.Size = New System.Drawing.Size(260, 95)
        Me.ListBoxScreens.TabIndex = 14
        '
        'txtDescrDendy
        '
        Me.txtDescrDendy.Location = New System.Drawing.Point(445, 268)
        Me.txtDescrDendy.Multiline = True
        Me.txtDescrDendy.Name = "txtDescrDendy"
        Me.txtDescrDendy.ReadOnly = True
        Me.txtDescrDendy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescrDendy.Size = New System.Drawing.Size(256, 193)
        Me.txtDescrDendy.TabIndex = 15
        Me.txtDescrDendy.Text = resources.GetString("txtDescrDendy.Text")
        Me.txtDescrDendy.Visible = False
        '
        'cmbStartGame
        '
        Me.cmbStartGame.Location = New System.Drawing.Point(717, 28)
        Me.cmbStartGame.Name = "cmbStartGame"
        Me.cmbStartGame.Size = New System.Drawing.Size(127, 23)
        Me.cmbStartGame.TabIndex = 1
        Me.cmbStartGame.Text = "Start Game"
        Me.cmbStartGame.UseVisualStyleBackColor = True
        Me.cmbStartGame.Visible = False
        '
        'cmbPrevScreen
        '
        Me.cmbPrevScreen.Location = New System.Drawing.Point(445, 239)
        Me.cmbPrevScreen.Name = "cmbPrevScreen"
        Me.cmbPrevScreen.Size = New System.Drawing.Size(84, 23)
        Me.cmbPrevScreen.TabIndex = 18
        Me.cmbPrevScreen.Text = "<< |"
        Me.cmbPrevScreen.UseVisualStyleBackColor = True
        Me.cmbPrevScreen.Visible = False
        '
        'lblScreensCounter
        '
        Me.lblScreensCounter.AutoSize = True
        Me.lblScreensCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblScreensCounter.Location = New System.Drawing.Point(561, 242)
        Me.lblScreensCounter.Name = "lblScreensCounter"
        Me.lblScreensCounter.Size = New System.Drawing.Size(37, 16)
        Me.lblScreensCounter.TabIndex = 19
        Me.lblScreensCounter.Text = "0 (0)"
        Me.lblScreensCounter.Visible = False
        '
        'cmbNextScreen
        '
        Me.cmbNextScreen.Location = New System.Drawing.Point(617, 239)
        Me.cmbNextScreen.Name = "cmbNextScreen"
        Me.cmbNextScreen.Size = New System.Drawing.Size(84, 23)
        Me.cmbNextScreen.TabIndex = 17
        Me.cmbNextScreen.Text = "| >>"
        Me.cmbNextScreen.UseVisualStyleBackColor = True
        Me.cmbNextScreen.Visible = False
        '
        'txtDescrSega
        '
        Me.txtDescrSega.Location = New System.Drawing.Point(445, 268)
        Me.txtDescrSega.Multiline = True
        Me.txtDescrSega.Name = "txtDescrSega"
        Me.txtDescrSega.ReadOnly = True
        Me.txtDescrSega.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescrSega.Size = New System.Drawing.Size(256, 193)
        Me.txtDescrSega.TabIndex = 15
        Me.txtDescrSega.Text = resources.GetString("txtDescrSega.Text")
        Me.txtDescrSega.Visible = False
        '
        'txtAuthorEMail
        '
        Me.txtAuthorEMail.Location = New System.Drawing.Point(850, 601)
        Me.txtAuthorEMail.Name = "txtAuthorEMail"
        Me.txtAuthorEMail.ReadOnly = True
        Me.txtAuthorEMail.Size = New System.Drawing.Size(128, 20)
        Me.txtAuthorEMail.TabIndex = 34
        Me.txtAuthorEMail.Text = "muratovskiy@gmail.com"
        '
        'TrayIcon
        '
        Me.TrayIcon.ContextMenuStrip = Me.TrayIconMenu
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "NESster"
        Me.TrayIcon.Visible = True
        '
        'TrayIconMenu
        '
        Me.TrayIconMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRestore, Me.mnuMinimize, Me.mnuClose})
        Me.TrayIconMenu.Name = "TrayIconMenu"
        Me.TrayIconMenu.Size = New System.Drawing.Size(124, 70)
        '
        'mnuRestore
        '
        Me.mnuRestore.Image = Global.NESTer2.My.Resources.Resources.app
        Me.mnuRestore.Name = "mnuRestore"
        Me.mnuRestore.Size = New System.Drawing.Size(123, 22)
        Me.mnuRestore.Text = "Restore"
        '
        'mnuMinimize
        '
        Me.mnuMinimize.Image = Global.NESTer2.My.Resources.Resources.down
        Me.mnuMinimize.Name = "mnuMinimize"
        Me.mnuMinimize.Size = New System.Drawing.Size(123, 22)
        Me.mnuMinimize.Text = "Minimize"
        '
        'mnuClose
        '
        Me.mnuClose.Image = Global.NESTer2.My.Resources.Resources._private
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(123, 22)
        Me.mnuClose.Text = "Close"
        '
        'Toolbar
        '
        Me.Toolbar.Dock = System.Windows.Forms.DockStyle.None
        Me.Toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolbarLabelSearch, Me.toolbarTxtSearch, Me.toolbarBtnClear, Me.ToolStripSeparator1, Me.ToolStripSeparator3, Me.toolbarBtnNes, Me.toolbarBtnSnes, Me.toolbarBtnSega, Me.ToolStripSeparator2, Me.toolbarBtnFavorites, Me.toolbarBtnTranslated, Me.ToolStripSeparator5, Me.ToolStripSeparator6, Me.toolbarBtnAddToFav, Me.toolbarBtnRemoveFromFav, Me.toolbarLblFavSatus, Me.toolbarLblFavSatusOff, Me.ToolStripSeparator4, Me.toolbarBtnShowAbout, Me.toolbarBtnShowLog, Me.toolbarBtnShowSet, Me.ToolStripTextBox1})
        Me.Toolbar.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar.Name = "Toolbar"
        Me.Toolbar.Size = New System.Drawing.Size(798, 25)
        Me.Toolbar.TabIndex = 35
        Me.Toolbar.Text = "ToolStrip1"
        '
        'toolbarLabelSearch
        '
        Me.toolbarLabelSearch.Image = Global.NESTer2.My.Resources.Resources.search
        Me.toolbarLabelSearch.Name = "toolbarLabelSearch"
        Me.toolbarLabelSearch.Size = New System.Drawing.Size(64, 22)
        Me.toolbarLabelSearch.Text = "Search :"
        '
        'toolbarTxtSearch
        '
        Me.toolbarTxtSearch.AutoSize = False
        Me.toolbarTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toolbarTxtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.toolbarTxtSearch.Name = "toolbarTxtSearch"
        Me.toolbarTxtSearch.Size = New System.Drawing.Size(150, 23)
        Me.toolbarTxtSearch.ToolTipText = "Type game name here"
        '
        'toolbarBtnClear
        '
        Me.toolbarBtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolbarBtnClear.Image = Global.NESTer2.My.Resources.Resources.del
        Me.toolbarBtnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnClear.Name = "toolbarBtnClear"
        Me.toolbarBtnClear.Size = New System.Drawing.Size(23, 22)
        Me.toolbarBtnClear.Text = "Clear text"
        Me.toolbarBtnClear.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolbarBtnNes
        '
        Me.toolbarBtnNes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnNes.Name = "toolbarBtnNes"
        Me.toolbarBtnNes.Size = New System.Drawing.Size(31, 22)
        Me.toolbarBtnNes.Text = "Nes"
        '
        'toolbarBtnSnes
        '
        Me.toolbarBtnSnes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnSnes.Name = "toolbarBtnSnes"
        Me.toolbarBtnSnes.Size = New System.Drawing.Size(37, 22)
        Me.toolbarBtnSnes.Text = "SNes"
        '
        'toolbarBtnSega
        '
        Me.toolbarBtnSega.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnSega.Name = "toolbarBtnSega"
        Me.toolbarBtnSega.Size = New System.Drawing.Size(36, 22)
        Me.toolbarBtnSega.Text = "Sega"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolbarBtnFavorites
        '
        Me.toolbarBtnFavorites.Image = Global.NESTer2.My.Resources.Resources.favorits
        Me.toolbarBtnFavorites.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnFavorites.Name = "toolbarBtnFavorites"
        Me.toolbarBtnFavorites.Size = New System.Drawing.Size(23, 22)
        Me.toolbarBtnFavorites.ToolTipText = "Show Favorites"
        '
        'toolbarBtnTranslated
        '
        Me.toolbarBtnTranslated.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolbarBtnTranslated.Image = Global.NESTer2.My.Resources.Resources.credit_card
        Me.toolbarBtnTranslated.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnTranslated.Name = "toolbarBtnTranslated"
        Me.toolbarBtnTranslated.Size = New System.Drawing.Size(23, 22)
        Me.toolbarBtnTranslated.Text = "ToolStripButton1"
        Me.toolbarBtnTranslated.ToolTipText = "Show Translated"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'toolbarBtnAddToFav
        '
        Me.toolbarBtnAddToFav.Image = Global.NESTer2.My.Resources.Resources.favorits_add1
        Me.toolbarBtnAddToFav.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnAddToFav.Name = "toolbarBtnAddToFav"
        Me.toolbarBtnAddToFav.Size = New System.Drawing.Size(23, 22)
        Me.toolbarBtnAddToFav.ToolTipText = "Add to Favorites"
        Me.toolbarBtnAddToFav.Visible = False
        '
        'toolbarBtnRemoveFromFav
        '
        Me.toolbarBtnRemoveFromFav.Image = Global.NESTer2.My.Resources.Resources.favorits_remove
        Me.toolbarBtnRemoveFromFav.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnRemoveFromFav.Name = "toolbarBtnRemoveFromFav"
        Me.toolbarBtnRemoveFromFav.Size = New System.Drawing.Size(23, 22)
        Me.toolbarBtnRemoveFromFav.ToolTipText = "Remove from Favorites"
        Me.toolbarBtnRemoveFromFav.Visible = False
        '
        'toolbarLblFavSatus
        '
        Me.toolbarLblFavSatus.Image = Global.NESTer2.My.Resources.Resources.star
        Me.toolbarLblFavSatus.Name = "toolbarLblFavSatus"
        Me.toolbarLblFavSatus.Size = New System.Drawing.Size(16, 22)
        Me.toolbarLblFavSatus.Visible = False
        '
        'toolbarLblFavSatusOff
        '
        Me.toolbarLblFavSatusOff.Image = Global.NESTer2.My.Resources.Resources.star_off
        Me.toolbarLblFavSatusOff.Name = "toolbarLblFavSatusOff"
        Me.toolbarLblFavSatusOff.Size = New System.Drawing.Size(16, 22)
        Me.toolbarLblFavSatusOff.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolbarBtnShowAbout
        '
        Me.toolbarBtnShowAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.toolbarBtnShowAbout.Image = Global.NESTer2.My.Resources.Resources.about
        Me.toolbarBtnShowAbout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnShowAbout.Name = "toolbarBtnShowAbout"
        Me.toolbarBtnShowAbout.Size = New System.Drawing.Size(60, 22)
        Me.toolbarBtnShowAbout.Text = "About"
        '
        'toolbarBtnShowLog
        '
        Me.toolbarBtnShowLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.toolbarBtnShowLog.Image = Global.NESTer2.My.Resources.Resources.note
        Me.toolbarBtnShowLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnShowLog.Name = "toolbarBtnShowLog"
        Me.toolbarBtnShowLog.Size = New System.Drawing.Size(47, 22)
        Me.toolbarBtnShowLog.Text = "Log"
        '
        'toolbarBtnShowSet
        '
        Me.toolbarBtnShowSet.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.toolbarBtnShowSet.Image = Global.NESTer2.My.Resources.Resources.applications
        Me.toolbarBtnShowSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarBtnShowSet.Name = "toolbarBtnShowSet"
        Me.toolbarBtnShowSet.Size = New System.Drawing.Size(43, 22)
        Me.toolbarBtnShowSet.Text = "Set"
        Me.toolbarBtnShowSet.ToolTipText = "Settings"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox1.Enabled = False
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 25)
        '
        'MainMiniPictureBox
        '
        Me.MainMiniPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MainMiniPictureBox.Enabled = False
        Me.MainMiniPictureBox.ErrorImage = CType(resources.GetObject("MainMiniPictureBox.ErrorImage"), System.Drawing.Image)
        Me.MainMiniPictureBox.Location = New System.Drawing.Point(445, 28)
        Me.MainMiniPictureBox.Name = "MainMiniPictureBox"
        Me.MainMiniPictureBox.Size = New System.Drawing.Size(256, 205)
        Me.MainMiniPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MainMiniPictureBox.TabIndex = 4
        Me.MainMiniPictureBox.TabStop = False
        '
        'lblCurentPosInList
        '
        Me.lblCurentPosInList.AutoSize = True
        Me.lblCurentPosInList.Location = New System.Drawing.Point(12, 464)
        Me.lblCurentPosInList.Name = "lblCurentPosInList"
        Me.lblCurentPosInList.Size = New System.Drawing.Size(13, 13)
        Me.lblCurentPosInList.TabIndex = 38
        Me.lblCurentPosInList.Text = "0"
        '
        'txtFileMask
        '
        Me.txtFileMask.Location = New System.Drawing.Point(922, 353)
        Me.txtFileMask.Name = "txtFileMask"
        Me.txtFileMask.Size = New System.Drawing.Size(49, 20)
        Me.txtFileMask.TabIndex = 39
        Me.txtFileMask.Text = "*.*"
        Me.txtFileMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(716, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "File mask (*.zip, *.nes, *.smd, or all *.*)"
        '
        'RadioNes1
        '
        Me.RadioNes1.AutoSize = True
        Me.RadioNes1.Enabled = False
        Me.RadioNes1.Location = New System.Drawing.Point(6, 19)
        Me.RadioNes1.Name = "RadioNes1"
        Me.RadioNes1.Size = New System.Drawing.Size(67, 17)
        Me.RadioNes1.TabIndex = 41
        Me.RadioNes1.TabStop = True
        Me.RadioNes1.Text = "Nestopia"
        Me.RadioNes1.UseVisualStyleBackColor = True
        '
        'RadioNes2
        '
        Me.RadioNes2.AutoSize = True
        Me.RadioNes2.Enabled = False
        Me.RadioNes2.Location = New System.Drawing.Point(6, 42)
        Me.RadioNes2.Name = "RadioNes2"
        Me.RadioNes2.Size = New System.Drawing.Size(51, 17)
        Me.RadioNes2.TabIndex = 42
        Me.RadioNes2.TabStop = True
        Me.RadioNes2.Text = "fceux"
        Me.RadioNes2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnOtherNesEmu)
        Me.GroupBox1.Controls.Add(Me.txtRadioEmuNes3)
        Me.GroupBox1.Controls.Add(Me.txtRadioEmuNes2)
        Me.GroupBox1.Controls.Add(Me.txtRadioEmuNes1)
        Me.GroupBox1.Controls.Add(Me.RadioNes3)
        Me.GroupBox1.Controls.Add(Me.RadioNes1)
        Me.GroupBox1.Controls.Add(Me.RadioNes2)
        Me.GroupBox1.Location = New System.Drawing.Point(719, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(258, 93)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Emulator NES"
        '
        'btnOtherNesEmu
        '
        Me.btnOtherNesEmu.Location = New System.Drawing.Point(223, 66)
        Me.btnOtherNesEmu.Name = "btnOtherNesEmu"
        Me.btnOtherNesEmu.Size = New System.Drawing.Size(29, 21)
        Me.btnOtherNesEmu.TabIndex = 47
        Me.btnOtherNesEmu.Text = "..."
        Me.btnOtherNesEmu.UseVisualStyleBackColor = True
        '
        'txtRadioEmuNes3
        '
        Me.txtRadioEmuNes3.Location = New System.Drawing.Point(80, 66)
        Me.txtRadioEmuNes3.Name = "txtRadioEmuNes3"
        Me.txtRadioEmuNes3.Size = New System.Drawing.Size(146, 20)
        Me.txtRadioEmuNes3.TabIndex = 46
        '
        'txtRadioEmuNes2
        '
        Me.txtRadioEmuNes2.Enabled = False
        Me.txtRadioEmuNes2.Location = New System.Drawing.Point(80, 42)
        Me.txtRadioEmuNes2.Name = "txtRadioEmuNes2"
        Me.txtRadioEmuNes2.ReadOnly = True
        Me.txtRadioEmuNes2.Size = New System.Drawing.Size(172, 20)
        Me.txtRadioEmuNes2.TabIndex = 45
        Me.txtRadioEmuNes2.Text = "\fceux.exe"
        '
        'txtRadioEmuNes1
        '
        Me.txtRadioEmuNes1.Enabled = False
        Me.txtRadioEmuNes1.Location = New System.Drawing.Point(80, 20)
        Me.txtRadioEmuNes1.Name = "txtRadioEmuNes1"
        Me.txtRadioEmuNes1.ReadOnly = True
        Me.txtRadioEmuNes1.Size = New System.Drawing.Size(172, 20)
        Me.txtRadioEmuNes1.TabIndex = 44
        Me.txtRadioEmuNes1.Text = "\nestopia.exe"
        '
        'RadioNes3
        '
        Me.RadioNes3.AutoSize = True
        Me.RadioNes3.Location = New System.Drawing.Point(6, 66)
        Me.RadioNes3.Name = "RadioNes3"
        Me.RadioNes3.Size = New System.Drawing.Size(51, 17)
        Me.RadioNes3.TabIndex = 43
        Me.RadioNes3.TabStop = True
        Me.RadioNes3.Text = "Other"
        Me.RadioNes3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOtherSmdEmu)
        Me.GroupBox2.Controls.Add(Me.txtRadioEmuSega3)
        Me.GroupBox2.Controls.Add(Me.txtRadioEmuSega2)
        Me.GroupBox2.Controls.Add(Me.RadioSega3)
        Me.GroupBox2.Controls.Add(Me.txtRadioEmuSega1)
        Me.GroupBox2.Controls.Add(Me.RadioSega2)
        Me.GroupBox2.Controls.Add(Me.RadioSega1)
        Me.GroupBox2.Location = New System.Drawing.Point(719, 254)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 93)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Emulator Sega"
        '
        'btnOtherSmdEmu
        '
        Me.btnOtherSmdEmu.Location = New System.Drawing.Point(225, 64)
        Me.btnOtherSmdEmu.Name = "btnOtherSmdEmu"
        Me.btnOtherSmdEmu.Size = New System.Drawing.Size(29, 21)
        Me.btnOtherSmdEmu.TabIndex = 47
        Me.btnOtherSmdEmu.Text = "..."
        Me.btnOtherSmdEmu.UseVisualStyleBackColor = True
        '
        'txtRadioEmuSega3
        '
        Me.txtRadioEmuSega3.Location = New System.Drawing.Point(82, 64)
        Me.txtRadioEmuSega3.Name = "txtRadioEmuSega3"
        Me.txtRadioEmuSega3.Size = New System.Drawing.Size(146, 20)
        Me.txtRadioEmuSega3.TabIndex = 46
        '
        'txtRadioEmuSega2
        '
        Me.txtRadioEmuSega2.Enabled = False
        Me.txtRadioEmuSega2.Location = New System.Drawing.Point(82, 41)
        Me.txtRadioEmuSega2.Name = "txtRadioEmuSega2"
        Me.txtRadioEmuSega2.ReadOnly = True
        Me.txtRadioEmuSega2.Size = New System.Drawing.Size(172, 20)
        Me.txtRadioEmuSega2.TabIndex = 45
        Me.txtRadioEmuSega2.Text = "\Gens.exe"
        '
        'RadioSega3
        '
        Me.RadioSega3.AutoSize = True
        Me.RadioSega3.Location = New System.Drawing.Point(8, 68)
        Me.RadioSega3.Name = "RadioSega3"
        Me.RadioSega3.Size = New System.Drawing.Size(51, 17)
        Me.RadioSega3.TabIndex = 2
        Me.RadioSega3.TabStop = True
        Me.RadioSega3.Text = "Other"
        Me.RadioSega3.UseVisualStyleBackColor = True
        '
        'txtRadioEmuSega1
        '
        Me.txtRadioEmuSega1.Enabled = False
        Me.txtRadioEmuSega1.Location = New System.Drawing.Point(82, 19)
        Me.txtRadioEmuSega1.Name = "txtRadioEmuSega1"
        Me.txtRadioEmuSega1.ReadOnly = True
        Me.txtRadioEmuSega1.Size = New System.Drawing.Size(172, 20)
        Me.txtRadioEmuSega1.TabIndex = 44
        Me.txtRadioEmuSega1.Text = "\Fusion.exe"
        '
        'RadioSega2
        '
        Me.RadioSega2.AutoSize = True
        Me.RadioSega2.Enabled = False
        Me.RadioSega2.Location = New System.Drawing.Point(8, 44)
        Me.RadioSega2.Name = "RadioSega2"
        Me.RadioSega2.Size = New System.Drawing.Size(50, 17)
        Me.RadioSega2.TabIndex = 1
        Me.RadioSega2.TabStop = True
        Me.RadioSega2.Text = "Gens"
        Me.RadioSega2.UseVisualStyleBackColor = True
        '
        'RadioSega1
        '
        Me.RadioSega1.AutoSize = True
        Me.RadioSega1.Enabled = False
        Me.RadioSega1.Location = New System.Drawing.Point(8, 20)
        Me.RadioSega1.Name = "RadioSega1"
        Me.RadioSega1.Size = New System.Drawing.Size(56, 17)
        Me.RadioSega1.TabIndex = 0
        Me.RadioSega1.TabStop = True
        Me.RadioSega1.Text = "Fusion"
        Me.RadioSega1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnOtherSNesEmu)
        Me.GroupBox3.Controls.Add(Me.txtRadioEmuSnes3)
        Me.GroupBox3.Controls.Add(Me.txtRadioEmuSnes2)
        Me.GroupBox3.Controls.Add(Me.txtRadioEmuSnes1)
        Me.GroupBox3.Controls.Add(Me.RadioSnes3)
        Me.GroupBox3.Controls.Add(Me.RadioSnes1)
        Me.GroupBox3.Controls.Add(Me.RadioSnes2)
        Me.GroupBox3.Location = New System.Drawing.Point(719, 156)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(258, 93)
        Me.GroupBox3.TabIndex = 45
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Emulator SNES"
        '
        'btnOtherSNesEmu
        '
        Me.btnOtherSNesEmu.Location = New System.Drawing.Point(223, 66)
        Me.btnOtherSNesEmu.Name = "btnOtherSNesEmu"
        Me.btnOtherSNesEmu.Size = New System.Drawing.Size(29, 21)
        Me.btnOtherSNesEmu.TabIndex = 47
        Me.btnOtherSNesEmu.Text = "..."
        Me.btnOtherSNesEmu.UseVisualStyleBackColor = True
        '
        'txtRadioEmuSnes3
        '
        Me.txtRadioEmuSnes3.Location = New System.Drawing.Point(80, 66)
        Me.txtRadioEmuSnes3.Name = "txtRadioEmuSnes3"
        Me.txtRadioEmuSnes3.Size = New System.Drawing.Size(146, 20)
        Me.txtRadioEmuSnes3.TabIndex = 46
        '
        'txtRadioEmuSnes2
        '
        Me.txtRadioEmuSnes2.Enabled = False
        Me.txtRadioEmuSnes2.Location = New System.Drawing.Point(80, 42)
        Me.txtRadioEmuSnes2.Name = "txtRadioEmuSnes2"
        Me.txtRadioEmuSnes2.ReadOnly = True
        Me.txtRadioEmuSnes2.Size = New System.Drawing.Size(172, 20)
        Me.txtRadioEmuSnes2.TabIndex = 45
        Me.txtRadioEmuSnes2.Text = "\ares.exe"
        '
        'txtRadioEmuSnes1
        '
        Me.txtRadioEmuSnes1.Enabled = False
        Me.txtRadioEmuSnes1.Location = New System.Drawing.Point(80, 20)
        Me.txtRadioEmuSnes1.Name = "txtRadioEmuSnes1"
        Me.txtRadioEmuSnes1.ReadOnly = True
        Me.txtRadioEmuSnes1.Size = New System.Drawing.Size(172, 20)
        Me.txtRadioEmuSnes1.TabIndex = 44
        Me.txtRadioEmuSnes1.Text = "\snes9x-x64.exe"
        '
        'RadioSnes3
        '
        Me.RadioSnes3.AutoSize = True
        Me.RadioSnes3.Location = New System.Drawing.Point(6, 66)
        Me.RadioSnes3.Name = "RadioSnes3"
        Me.RadioSnes3.Size = New System.Drawing.Size(51, 17)
        Me.RadioSnes3.TabIndex = 43
        Me.RadioSnes3.TabStop = True
        Me.RadioSnes3.Text = "Other"
        Me.RadioSnes3.UseVisualStyleBackColor = True
        '
        'RadioSnes1
        '
        Me.RadioSnes1.AutoSize = True
        Me.RadioSnes1.Enabled = False
        Me.RadioSnes1.Location = New System.Drawing.Point(6, 19)
        Me.RadioSnes1.Name = "RadioSnes1"
        Me.RadioSnes1.Size = New System.Drawing.Size(58, 17)
        Me.RadioSnes1.TabIndex = 41
        Me.RadioSnes1.TabStop = True
        Me.RadioSnes1.Text = "snes9x"
        Me.RadioSnes1.UseVisualStyleBackColor = True
        '
        'RadioSnes2
        '
        Me.RadioSnes2.AutoSize = True
        Me.RadioSnes2.Enabled = False
        Me.RadioSnes2.Location = New System.Drawing.Point(6, 42)
        Me.RadioSnes2.Name = "RadioSnes2"
        Me.RadioSnes2.Size = New System.Drawing.Size(45, 17)
        Me.RadioSnes2.TabIndex = 42
        Me.RadioSnes2.TabStop = True
        Me.RadioSnes2.Text = "ares"
        Me.RadioSnes2.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 627)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFileMask)
        Me.Controls.Add(Me.lblCurentPosInList)
        Me.Controls.Add(Me.Toolbar)
        Me.Controls.Add(Me.txtAuthorEMail)
        Me.Controls.Add(Me.cmbNextScreen)
        Me.Controls.Add(Me.lblScreensCounter)
        Me.Controls.Add(Me.cmbPrevScreen)
        Me.Controls.Add(Me.ListBoxScreens)
        Me.Controls.Add(Me.MainMiniPictureBox)
        Me.Controls.Add(Me.cmbStartEmulator)
        Me.Controls.Add(Me.cmbReloadList)
        Me.Controls.Add(Me.txtLogBox)
        Me.Controls.Add(Me.txtDescrSega)
        Me.Controls.Add(Me.txtDescrDendy)
        Me.Controls.Add(Me.ListBoxRoms)
        Me.Controls.Add(Me.cmbStartGame)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NESTer2"
        Me.ContListMenu.ResumeLayout(False)
        Me.TrayIconMenu.ResumeLayout(False)
        Me.Toolbar.ResumeLayout(False)
        Me.Toolbar.PerformLayout()
        CType(Me.MainMiniPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLogBox As System.Windows.Forms.TextBox
    Friend WithEvents cmbReloadList As System.Windows.Forms.Button
    Friend WithEvents MainMiniPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ListBoxRoms As System.Windows.Forms.ListBox
    Friend WithEvents cmbStartEmulator As System.Windows.Forms.Button
    Friend WithEvents ListBoxScreens As System.Windows.Forms.ListBox
    Friend WithEvents txtDescrDendy As System.Windows.Forms.TextBox
    Friend WithEvents cmbStartGame As System.Windows.Forms.Button
    Friend WithEvents ContListMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDeleteRom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbPrevScreen As System.Windows.Forms.Button
    Friend WithEvents lblScreensCounter As System.Windows.Forms.Label
    Friend WithEvents cmbNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtDescrSega As TextBox
    Friend WithEvents txtAuthorEMail As TextBox
    Friend WithEvents TrayIcon As NotifyIcon
    Friend WithEvents TrayIconMenu As ContextMenuStrip
    Friend WithEvents mnuRestore As ToolStripMenuItem
    Friend WithEvents mnuClose As ToolStripMenuItem
    Friend WithEvents Toolbar As ToolStrip
    Friend WithEvents toolbarLabelSearch As ToolStripLabel
    Friend WithEvents toolbarTxtSearch As ToolStripTextBox
    Friend WithEvents toolbarBtnClear As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents toolbarBtnNes As ToolStripButton
    Friend WithEvents toolbarBtnSega As ToolStripButton
    Friend WithEvents toolbarBtnFavorites As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents toolbarBtnAddToFav As ToolStripButton
    Friend WithEvents toolbarBtnRemoveFromFav As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents toolbarBtnShowLog As ToolStripButton
    Friend WithEvents toolbarBtnShowSet As ToolStripButton
    Friend WithEvents toolbarBtnShowAbout As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents toolbarLblFavSatusOff As ToolStripLabel
    Friend WithEvents toolbarLblFavSatus As ToolStripLabel
    Friend WithEvents toolbarBtnTranslated As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents lblCurentPosInList As Label
    Friend WithEvents mnuMinimize As ToolStripMenuItem
    Friend WithEvents mnuRenameRom As ToolStripMenuItem
    Friend WithEvents txtFileMask As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioNes1 As RadioButton
    Friend WithEvents RadioNes2 As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioNes3 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioSega3 As RadioButton
    Friend WithEvents RadioSega2 As RadioButton
    Friend WithEvents RadioSega1 As RadioButton
    Friend WithEvents txtRadioEmuNes3 As TextBox
    Friend WithEvents txtRadioEmuNes2 As TextBox
    Friend WithEvents txtRadioEmuNes1 As TextBox
    Friend WithEvents txtRadioEmuSega2 As TextBox
    Friend WithEvents txtRadioEmuSega1 As TextBox
    Friend WithEvents btnOtherNesEmu As Button
    Friend WithEvents btnOtherSmdEmu As Button
    Friend WithEvents txtRadioEmuSega3 As TextBox
    Friend WithEvents mnuAddToFavorite As ToolStripMenuItem
    Friend WithEvents mnuRemoveFromFavorite As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents toolbarBtnSnes As ToolStripButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnOtherSNesEmu As Button
    Friend WithEvents txtRadioEmuSnes3 As TextBox
    Friend WithEvents txtRadioEmuSnes2 As TextBox
    Friend WithEvents txtRadioEmuSnes1 As TextBox
    Friend WithEvents RadioSnes3 As RadioButton
    Friend WithEvents RadioSnes1 As RadioButton
    Friend WithEvents RadioSnes2 As RadioButton
End Class
