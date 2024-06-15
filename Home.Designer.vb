<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_home = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_cadp = New System.Windows.Forms.Button()
        Me.btn_agenda = New System.Windows.Forms.Button()
        Me.btn_perfil = New System.Windows.Forms.Button()
        Me.btn_logout = New System.Windows.Forms.Button()
        Me.lbl_usuLogado = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_home, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Controls.Add(Me.dgv_home)
        Me.GroupBox1.Location = New System.Drawing.Point(243, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1013, 695)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Próximas Consultas"
        '
        'dgv_home
        '
        Me.dgv_home.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_home.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgv_home.Location = New System.Drawing.Point(6, 19)
        Me.dgv_home.Name = "dgv_home"
        Me.dgv_home.Size = New System.Drawing.Size(1001, 663)
        Me.dgv_home.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Paciente"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Data"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Horario"
        Me.Column3.Name = "Column3"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(39, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(163, 163)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'btn_cadp
        '
        Me.btn_cadp.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_cadp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cadp.Image = CType(resources.GetObject("btn_cadp.Image"), System.Drawing.Image)
        Me.btn_cadp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cadp.Location = New System.Drawing.Point(39, 266)
        Me.btn_cadp.Name = "btn_cadp"
        Me.btn_cadp.Padding = New System.Windows.Forms.Padding(0, 15, 0, 15)
        Me.btn_cadp.Size = New System.Drawing.Size(163, 83)
        Me.btn_cadp.TabIndex = 2
        Me.btn_cadp.Text = "Cadastrar Paciente"
        Me.btn_cadp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cadp.UseVisualStyleBackColor = False
        '
        'btn_agenda
        '
        Me.btn_agenda.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_agenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agenda.Image = CType(resources.GetObject("btn_agenda.Image"), System.Drawing.Image)
        Me.btn_agenda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agenda.Location = New System.Drawing.Point(39, 390)
        Me.btn_agenda.Name = "btn_agenda"
        Me.btn_agenda.Padding = New System.Windows.Forms.Padding(0, 15, 0, 15)
        Me.btn_agenda.Size = New System.Drawing.Size(163, 83)
        Me.btn_agenda.TabIndex = 3
        Me.btn_agenda.Text = "Agenda Completa"
        Me.btn_agenda.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agenda.UseVisualStyleBackColor = False
        '
        'btn_perfil
        '
        Me.btn_perfil.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_perfil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_perfil.Image = CType(resources.GetObject("btn_perfil.Image"), System.Drawing.Image)
        Me.btn_perfil.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_perfil.Location = New System.Drawing.Point(39, 516)
        Me.btn_perfil.Name = "btn_perfil"
        Me.btn_perfil.Padding = New System.Windows.Forms.Padding(0, 15, 0, 15)
        Me.btn_perfil.Size = New System.Drawing.Size(163, 83)
        Me.btn_perfil.TabIndex = 4
        Me.btn_perfil.Text = "Perfil de Paciente"
        Me.btn_perfil.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_perfil.UseVisualStyleBackColor = False
        '
        'btn_logout
        '
        Me.btn_logout.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_logout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_logout.Image = CType(resources.GetObject("btn_logout.Image"), System.Drawing.Image)
        Me.btn_logout.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_logout.Location = New System.Drawing.Point(39, 629)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Padding = New System.Windows.Forms.Padding(0, 15, 0, 15)
        Me.btn_logout.Size = New System.Drawing.Size(163, 83)
        Me.btn_logout.TabIndex = 6
        Me.btn_logout.Text = "Sair do Sistema"
        Me.btn_logout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_logout.UseVisualStyleBackColor = False
        '
        'lbl_usuLogado
        '
        Me.lbl_usuLogado.AutoSize = True
        Me.lbl_usuLogado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_usuLogado.Location = New System.Drawing.Point(39, 200)
        Me.lbl_usuLogado.Name = "lbl_usuLogado"
        Me.lbl_usuLogado.Size = New System.Drawing.Size(69, 16)
        Me.lbl_usuLogado.TabIndex = 7
        Me.lbl_usuLogado.Text = "Usuário: "
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1293, 757)
        Me.Controls.Add(Me.lbl_usuLogado)
        Me.Controls.Add(Me.btn_logout)
        Me.Controls.Add(Me.btn_perfil)
        Me.Controls.Add(Me.btn_agenda)
        Me.Controls.Add(Me.btn_cadp)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pãgina Inicial"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_home, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_cadp As Button
    Friend WithEvents btn_agenda As Button
    Friend WithEvents btn_perfil As Button
    Friend WithEvents btn_logout As Button
    Friend WithEvents dgv_home As DataGridView
    Friend WithEvents lbl_usuLogado As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
