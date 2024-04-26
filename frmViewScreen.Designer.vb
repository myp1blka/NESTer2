<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewScreen
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewScreen))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmbNextScreen = New System.Windows.Forms.Button()
        Me.lblScreensCounter = New System.Windows.Forms.Label()
        Me.cmbPrevScreen = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.ErrorImage = CType(resources.GetObject("PictureBox2.ErrorImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(495, 331)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'cmbNextScreen
        '
        Me.cmbNextScreen.Location = New System.Drawing.Point(414, 0)
        Me.cmbNextScreen.Name = "cmbNextScreen"
        Me.cmbNextScreen.Size = New System.Drawing.Size(84, 23)
        Me.cmbNextScreen.TabIndex = 20
        Me.cmbNextScreen.Text = "| >>"
        Me.cmbNextScreen.UseVisualStyleBackColor = True
        '
        'lblScreensCounter
        '
        Me.lblScreensCounter.AutoSize = True
        Me.lblScreensCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblScreensCounter.Location = New System.Drawing.Point(354, 5)
        Me.lblScreensCounter.Name = "lblScreensCounter"
        Me.lblScreensCounter.Size = New System.Drawing.Size(37, 16)
        Me.lblScreensCounter.TabIndex = 22
        Me.lblScreensCounter.Text = "0 (0)"
        '
        'cmbPrevScreen
        '
        Me.cmbPrevScreen.Location = New System.Drawing.Point(242, 0)
        Me.cmbPrevScreen.Name = "cmbPrevScreen"
        Me.cmbPrevScreen.Size = New System.Drawing.Size(84, 23)
        Me.cmbPrevScreen.TabIndex = 21
        Me.cmbPrevScreen.Text = "<< |"
        Me.cmbPrevScreen.UseVisualStyleBackColor = True
        '
        'frmViewScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 392)
        Me.Controls.Add(Me.cmbNextScreen)
        Me.Controls.Add(Me.lblScreensCounter)
        Me.Controls.Add(Me.cmbPrevScreen)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Скриншот"
        Me.TopMost = True
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblScreensCounter As System.Windows.Forms.Label
    Friend WithEvents cmbPrevScreen As System.Windows.Forms.Button
End Class
