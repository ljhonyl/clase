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
        Button1 = New Button()
        Button2 = New Button()
        BtnSalir = New Button()
        LblImagen = New Label()
        SuspendLayout()
        ' 
        ' BtnAlumnos
        ' 
        BtnAlumnos.AutoSize = True
        BtnAlumnos.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        BtnAlumnos.Location = New Point(553, 75)
        BtnAlumnos.Name = "BtnAlumnos"
        BtnAlumnos.Size = New Size(235, 31)
        BtnAlumnos.TabIndex = 0
        BtnAlumnos.Text = "Gestión Alumnos"
        BtnAlumnos.UseVisualStyleBackColor = True
        ' 
        ' BtnPruebas
        ' 
        BtnPruebas.AutoSize = True
        BtnPruebas.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        BtnPruebas.Location = New Point(553, 147)
        BtnPruebas.Name = "BtnPruebas"
        BtnPruebas.Size = New Size(235, 31)
        BtnPruebas.TabIndex = 1
        BtnPruebas.Text = "Gestión Asignaturas"
        BtnPruebas.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.AutoSize = True
        Button1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.Location = New Point(553, 215)
        Button1.Name = "Button1"
        Button1.Size = New Size(235, 31)
        Button1.TabIndex = 2
        Button1.Text = "Gestión Cursa"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.AutoSize = True
        Button2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Button2.Location = New Point(553, 283)
        Button2.Name = "Button2"
        Button2.Size = New Size(235, 31)
        Button2.TabIndex = 3
        Button2.Text = "Gestión Profesores"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' BtnSalir
        ' 
        BtnSalir.Location = New Point(630, 352)
        BtnSalir.Name = "BtnSalir"
        BtnSalir.Size = New Size(75, 23)
        BtnSalir.TabIndex = 4
        BtnSalir.Text = "Salir"
        BtnSalir.UseVisualStyleBackColor = True
        ' 
        ' LblImagen
        ' 
        LblImagen.Image = My.Resources.Resources.tiernogalvan
        LblImagen.Location = New Point(23, 36)
        LblImagen.Name = "LblImagen"
        LblImagen.Size = New Size(502, 382)
        LblImagen.TabIndex = 5
        ' 
        ' Menu
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(LblImagen)
        Controls.Add(BtnSalir)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(BtnPruebas)
        Controls.Add(BtnAlumnos)
        Name = "Menu"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Menu"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnAlumnos As Button
    Friend WithEvents BtnPruebas As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents LblImagen As Label
End Class
