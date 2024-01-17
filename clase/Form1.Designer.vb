<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Menu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        BtnAlumnos = New Button()
        BtnPruebas = New Button()
        SuspendLayout()
        ' 
        ' BtnAlumnos
        ' 
        BtnAlumnos.Location = New Point(78, 79)
        BtnAlumnos.Name = "BtnAlumnos"
        BtnAlumnos.Size = New Size(99, 23)
        BtnAlumnos.TabIndex = 0
        BtnAlumnos.Text = "Ir a Alumnos"
        BtnAlumnos.UseVisualStyleBackColor = True
        ' 
        ' BtnPruebas
        ' 
        BtnPruebas.Location = New Point(693, 389)
        BtnPruebas.Name = "BtnPruebas"
        BtnPruebas.Size = New Size(75, 23)
        BtnPruebas.TabIndex = 1
        BtnPruebas.Text = "Button1"
        BtnPruebas.UseVisualStyleBackColor = True
        ' 
        ' Menu
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(BtnPruebas)
        Controls.Add(BtnAlumnos)
        Name = "Menu"
        Text = "Menu"
        ResumeLayout(False)
    End Sub

    Friend WithEvents BtnAlumnos As Button
    Friend WithEvents BtnPruebas As Button
End Class
