<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Label1 = New Label()
        Label2 = New Label()
        txtPrefijo = New TextBox()
        btnSeleccionar = New Button()
        dlgCarpeta = New FolderBrowserDialog()
        btnIniciar = New Button()
        Label3 = New Label()
        txtRutaCarpeta = New TextBox()
        btnFicha = New Button()
        Label4 = New Label()
        RBEsp = New RadioButton()
        RBEng = New RadioButton()
        Label6 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Control
        Label1.Cursor = Cursors.No
        Label1.ImageAlign = ContentAlignment.MiddleRight
        Label1.Location = New Point(72, 67)
        Label1.Name = "Label1"
        Label1.Size = New Size(162, 20)
        Label1.TabIndex = 0
        Label1.Text = "Selecciona una carpeta"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(147, 164)
        Label2.Name = "Label2"
        Label2.Size = New Size(122, 20)
        Label2.TabIndex = 1
        Label2.Text = "Escriba su prefijo"
        ' 
        ' txtPrefijo
        ' 
        txtPrefijo.AccessibleName = ""
        txtPrefijo.Location = New Point(275, 161)
        txtPrefijo.Name = "txtPrefijo"
        txtPrefijo.Size = New Size(209, 27)
        txtPrefijo.TabIndex = 2
        ' 
        ' btnSeleccionar
        ' 
        btnSeleccionar.AccessibleName = "btnSeleccionar"
        btnSeleccionar.BackColor = SystemColors.Control
        btnSeleccionar.Image = CType(resources.GetObject("btnSeleccionar.Image"), Image)
        btnSeleccionar.Location = New Point(230, 60)
        btnSeleccionar.Name = "btnSeleccionar"
        btnSeleccionar.Size = New Size(39, 34)
        btnSeleccionar.TabIndex = 3
        btnSeleccionar.UseVisualStyleBackColor = False
        ' 
        ' btnIniciar
        ' 
        btnIniciar.BackColor = SystemColors.Control
        btnIniciar.Image = CType(resources.GetObject("btnIniciar.Image"), Image)
        btnIniciar.Location = New Point(173, 236)
        btnIniciar.Name = "btnIniciar"
        btnIniciar.Size = New Size(51, 57)
        btnIniciar.TabIndex = 4
        btnIniciar.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(59, 254)
        Label3.Name = "Label3"
        Label3.Size = New Size(108, 20)
        Label3.TabIndex = 5
        Label3.Text = "Renombrar RIS"
        ' 
        ' txtRutaCarpeta
        ' 
        txtRutaCarpeta.Location = New Point(275, 64)
        txtRutaCarpeta.Name = "txtRutaCarpeta"
        txtRutaCarpeta.Size = New Size(234, 27)
        txtRutaCarpeta.TabIndex = 6
        ' 
        ' btnFicha
        ' 
        btnFicha.BackColor = SystemColors.Control
        btnFicha.Image = CType(resources.GetObject("btnFicha.Image"), Image)
        btnFicha.Location = New Point(522, 238)
        btnFicha.Name = "btnFicha"
        btnFicha.Size = New Size(51, 57)
        btnFicha.TabIndex = 7
        btnFicha.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(331, 223)
        Label4.Name = "Label4"
        Label4.Size = New Size(174, 20)
        Label4.TabIndex = 8
        Label4.Text = "Renombrar Ficha Técnica"
        ' 
        ' RBEsp
        ' 
        RBEsp.AutoSize = True
        RBEsp.Location = New Point(377, 246)
        RBEsp.Name = "RBEsp"
        RBEsp.Size = New Size(82, 24)
        RBEsp.TabIndex = 9
        RBEsp.TabStop = True
        RBEsp.Text = "Español"
        RBEsp.UseVisualStyleBackColor = True
        ' 
        ' RBEng
        ' 
        RBEng.AutoSize = True
        RBEng.Location = New Point(377, 276)
        RBEng.Name = "RBEng"
        RBEng.Size = New Size(69, 24)
        RBEng.TabIndex = 10
        RBEng.TabStop = True
        RBEng.Text = "Inglés"
        RBEng.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(423, 343)
        Label6.Name = "Label6"
        Label6.Size = New Size(178, 40)
        Label6.TabIndex = 12
        Label6.Text = "Hecho por: Miguel Castro" & vbCrLf & "Practicante I+D 2024-2"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(613, 392)
        Controls.Add(Label6)
        Controls.Add(RBEng)
        Controls.Add(RBEsp)
        Controls.Add(Label4)
        Controls.Add(btnFicha)
        Controls.Add(txtRutaCarpeta)
        Controls.Add(Label3)
        Controls.Add(btnIniciar)
        Controls.Add(btnSeleccionar)
        Controls.Add(txtPrefijo)
        Controls.Add(Label2)
        Controls.Add(Label1)
        ForeColor = SystemColors.ControlText
        Name = "Form1"
        Text = "Renombrar RIS"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPrefijo As TextBox
    Friend WithEvents btnSeleccionar As Button
    Friend WithEvents dlgCarpeta As FolderBrowserDialog
    Friend WithEvents btnIniciar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRutaCarpeta As TextBox
    Friend WithEvents btnFicha As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents RBEsp As RadioButton
    Friend WithEvents RBEng As RadioButton
    Friend WithEvents Label6 As Label

End Class
