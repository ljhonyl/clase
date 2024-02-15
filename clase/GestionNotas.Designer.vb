<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionNotas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        ListViewNotas = New ListView()
        TbEv1 = New TextBox()
        TbEv2 = New TextBox()
        LblAsignatura = New Label()
        LblAlumno = New Label()
        LblEv1 = New Label()
        LblEv2 = New Label()
        BtnPrimero = New Button()
        BtnAnterior = New Button()
        BtnSiguiente = New Button()
        BtnFin = New Button()
        BtnAdd = New Button()
        MenuStrip1 = New MenuStrip()
        ListadoToolStripMenuItem = New ToolStripMenuItem()
        InsertarToolStripMenuItem = New ToolStripMenuItem()
        EditarToolStripMenuItem = New ToolStripMenuItem()
        EliminarToolStripMenuItem = New ToolStripMenuItem()
        MenúToolStripMenuItem = New ToolStripMenuItem()
        Label5 = New Label()
        TbBuscarId = New TextBox()
        BtnBuscar = New Button()
        LblEv3 = New Label()
        LblNotaFinal = New Label()
        TbEv3 = New TextBox()
        TbNotaFinal = New TextBox()
        CmbAsignaturas = New ComboBox()
        CmbAlumnos = New ComboBox()
        LblNotaFinalInfo = New Label()
        LblImagen1 = New Label()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListViewNotas
        ' 
        ListViewNotas.FullRowSelect = True
        ListViewNotas.Location = New Point(61, 163)
        ListViewNotas.MultiSelect = False
        ListViewNotas.Name = "ListViewNotas"
        ListViewNotas.Size = New Size(594, 630)
        ListViewNotas.TabIndex = 7
        ListViewNotas.UseCompatibleStateImageBehavior = False
        ' 
        ' TbEv1
        ' 
        TbEv1.Location = New Point(65, 369)
        TbEv1.Name = "TbEv1"
        TbEv1.Size = New Size(100, 23)
        TbEv1.TabIndex = 10
        ' 
        ' TbEv2
        ' 
        TbEv2.Location = New Point(381, 369)
        TbEv2.Name = "TbEv2"
        TbEv2.Size = New Size(100, 23)
        TbEv2.TabIndex = 11
        ' 
        ' LblAsignatura
        ' 
        LblAsignatura.AutoSize = True
        LblAsignatura.Location = New Point(65, 243)
        LblAsignatura.Name = "LblAsignatura"
        LblAsignatura.Size = New Size(64, 15)
        LblAsignatura.TabIndex = 9
        LblAsignatura.Text = "Asignatura"
        ' 
        ' LblAlumno
        ' 
        LblAlumno.AutoSize = True
        LblAlumno.Location = New Point(381, 243)
        LblAlumno.Name = "LblAlumno"
        LblAlumno.Size = New Size(50, 15)
        LblAlumno.TabIndex = 10
        LblAlumno.Text = "Alumno"
        ' 
        ' LblEv1
        ' 
        LblEv1.AutoSize = True
        LblEv1.Location = New Point(65, 338)
        LblEv1.Name = "LblEv1"
        LblEv1.Size = New Size(78, 15)
        LblEv1.TabIndex = 11
        LblEv1.Text = "1ª Evaluación"
        ' 
        ' LblEv2
        ' 
        LblEv2.AutoSize = True
        LblEv2.Location = New Point(381, 338)
        LblEv2.Name = "LblEv2"
        LblEv2.Size = New Size(78, 15)
        LblEv2.TabIndex = 12
        LblEv2.Text = "2ª Evaluación"
        ' 
        ' BtnPrimero
        ' 
        BtnPrimero.Image = My.Resources.Resources.primero
        BtnPrimero.Location = New Point(64, 101)
        BtnPrimero.Name = "BtnPrimero"
        BtnPrimero.Size = New Size(75, 23)
        BtnPrimero.TabIndex = 1
        BtnPrimero.UseVisualStyleBackColor = True
        ' 
        ' BtnAnterior
        ' 
        BtnAnterior.Image = My.Resources.Resources.anterior
        BtnAnterior.Location = New Point(164, 101)
        BtnAnterior.Name = "BtnAnterior"
        BtnAnterior.Size = New Size(75, 23)
        BtnAnterior.TabIndex = 2
        BtnAnterior.UseVisualStyleBackColor = True
        ' 
        ' BtnSiguiente
        ' 
        BtnSiguiente.Image = My.Resources.Resources.siguiente
        BtnSiguiente.Location = New Point(270, 101)
        BtnSiguiente.Name = "BtnSiguiente"
        BtnSiguiente.Size = New Size(75, 23)
        BtnSiguiente.TabIndex = 3
        BtnSiguiente.UseVisualStyleBackColor = True
        ' 
        ' BtnFin
        ' 
        BtnFin.Image = My.Resources.Resources.ultimo
        BtnFin.Location = New Point(370, 101)
        BtnFin.Name = "BtnFin"
        BtnFin.Size = New Size(75, 23)
        BtnFin.TabIndex = 4
        BtnFin.UseVisualStyleBackColor = True
        ' 
        ' BtnAdd
        ' 
        BtnAdd.Location = New Point(145, 575)
        BtnAdd.Name = "BtnAdd"
        BtnAdd.Size = New Size(253, 23)
        BtnAdd.TabIndex = 13
        BtnAdd.Text = "Button5"
        BtnAdd.UseVisualStyleBackColor = True
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {ListadoToolStripMenuItem, InsertarToolStripMenuItem, EditarToolStripMenuItem, EliminarToolStripMenuItem, MenúToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(734, 24)
        MenuStrip1.TabIndex = 18
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ListadoToolStripMenuItem
        ' 
        ListadoToolStripMenuItem.Name = "ListadoToolStripMenuItem"
        ListadoToolStripMenuItem.Size = New Size(57, 20)
        ListadoToolStripMenuItem.Text = "Listado"
        ' 
        ' InsertarToolStripMenuItem
        ' 
        InsertarToolStripMenuItem.Name = "InsertarToolStripMenuItem"
        InsertarToolStripMenuItem.Size = New Size(58, 20)
        InsertarToolStripMenuItem.Text = "Insertar"
        ' 
        ' EditarToolStripMenuItem
        ' 
        EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        EditarToolStripMenuItem.Size = New Size(49, 20)
        EditarToolStripMenuItem.Text = "Editar"
        ' 
        ' EliminarToolStripMenuItem
        ' 
        EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        EliminarToolStripMenuItem.Size = New Size(62, 20)
        EliminarToolStripMenuItem.Text = "Eliminar"
        ' 
        ' MenúToolStripMenuItem
        ' 
        MenúToolStripMenuItem.Name = "MenúToolStripMenuItem"
        MenúToolStripMenuItem.Size = New Size(50, 20)
        MenúToolStripMenuItem.Text = "Menú"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 20F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label5.Location = New Point(272, 24)
        Label5.Name = "Label5"
        Label5.Size = New Size(170, 37)
        Label5.TabIndex = 19
        Label5.Text = "Asignaturas"
        ' 
        ' TbBuscarId
        ' 
        TbBuscarId.Location = New Point(477, 101)
        TbBuscarId.Name = "TbBuscarId"
        TbBuscarId.Size = New Size(100, 23)
        TbBuscarId.TabIndex = 5
        ' 
        ' BtnBuscar
        ' 
        BtnBuscar.Image = My.Resources.Resources.buscar
        BtnBuscar.Location = New Point(583, 101)
        BtnBuscar.Name = "BtnBuscar"
        BtnBuscar.Size = New Size(75, 23)
        BtnBuscar.TabIndex = 6
        BtnBuscar.UseVisualStyleBackColor = True
        ' 
        ' LblEv3
        ' 
        LblEv3.AutoSize = True
        LblEv3.Location = New Point(65, 442)
        LblEv3.Name = "LblEv3"
        LblEv3.Size = New Size(78, 15)
        LblEv3.TabIndex = 20
        LblEv3.Text = "3ª Evaluación"
        ' 
        ' LblNotaFinal
        ' 
        LblNotaFinal.AutoSize = True
        LblNotaFinal.Location = New Point(381, 442)
        LblNotaFinal.Name = "LblNotaFinal"
        LblNotaFinal.Size = New Size(61, 15)
        LblNotaFinal.TabIndex = 21
        LblNotaFinal.Text = "Nota Final"
        ' 
        ' TbEv3
        ' 
        TbEv3.Location = New Point(65, 477)
        TbEv3.Name = "TbEv3"
        TbEv3.Size = New Size(100, 23)
        TbEv3.TabIndex = 12
        ' 
        ' TbNotaFinal
        ' 
        TbNotaFinal.Location = New Point(381, 477)
        TbNotaFinal.Name = "TbNotaFinal"
        TbNotaFinal.Size = New Size(100, 23)
        TbNotaFinal.TabIndex = 0
        TbNotaFinal.TabStop = False
        ' 
        ' CmbAsignaturas
        ' 
        CmbAsignaturas.DropDownStyle = ComboBoxStyle.DropDownList
        CmbAsignaturas.FormattingEnabled = True
        CmbAsignaturas.Location = New Point(65, 272)
        CmbAsignaturas.Name = "CmbAsignaturas"
        CmbAsignaturas.Size = New Size(153, 23)
        CmbAsignaturas.TabIndex = 8
        ' 
        ' CmbAlumnos
        ' 
        CmbAlumnos.DropDownStyle = ComboBoxStyle.DropDownList
        CmbAlumnos.FormattingEnabled = True
        CmbAlumnos.Location = New Point(381, 272)
        CmbAlumnos.Name = "CmbAlumnos"
        CmbAlumnos.Size = New Size(154, 23)
        CmbAlumnos.TabIndex = 9
        ' 
        ' LblNotaFinalInfo
        ' 
        LblNotaFinalInfo.AutoSize = True
        LblNotaFinalInfo.Location = New Point(457, 442)
        LblNotaFinalInfo.Name = "LblNotaFinalInfo"
        LblNotaFinalInfo.Size = New Size(92, 15)
        LblNotaFinalInfo.TabIndex = 26
        LblNotaFinalInfo.Text = "(Autoinsertable)"
        ' 
        ' LblImagen1
        ' 
        LblImagen1.Image = My.Resources.Resources.libros
        LblImagen1.Location = New Point(508, 525)
        LblImagen1.Name = "LblImagen1"
        LblImagen1.Size = New Size(180, 180)
        LblImagen1.TabIndex = 27
        ' 
        ' GestionNotas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(734, 819)
        Controls.Add(LblImagen1)
        Controls.Add(LblNotaFinalInfo)
        Controls.Add(CmbAlumnos)
        Controls.Add(CmbAsignaturas)
        Controls.Add(TbNotaFinal)
        Controls.Add(TbEv3)
        Controls.Add(LblNotaFinal)
        Controls.Add(LblEv3)
        Controls.Add(BtnBuscar)
        Controls.Add(TbBuscarId)
        Controls.Add(Label5)
        Controls.Add(BtnAdd)
        Controls.Add(BtnFin)
        Controls.Add(BtnSiguiente)
        Controls.Add(BtnAnterior)
        Controls.Add(BtnPrimero)
        Controls.Add(LblEv2)
        Controls.Add(LblEv1)
        Controls.Add(LblAlumno)
        Controls.Add(LblAsignatura)
        Controls.Add(TbEv2)
        Controls.Add(TbEv1)
        Controls.Add(MenuStrip1)
        Controls.Add(ListViewNotas)
        MainMenuStrip = MenuStrip1
        Name = "GestionNotas"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GestionAsignaturas"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListViewNotas As ListView
    Friend WithEvents TbEv1 As TextBox
    Friend WithEvents TbEv2 As TextBox
    Friend WithEvents LblAsignatura As Label
    Friend WithEvents LblAlumno As Label
    Friend WithEvents LblEv1 As Label
    Friend WithEvents LblEv2 As Label
    Friend WithEvents BtnPrimero As Button
    Friend WithEvents BtnAnterior As Button
    Friend WithEvents BtnSiguiente As Button
    Friend WithEvents BtnFin As Button
    Friend WithEvents BtnAdd As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ListadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InsertarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label5 As Label
    Friend WithEvents TbBuscarId As TextBox
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents MenúToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LblEv3 As Label
    Friend WithEvents LblNotaFinal As Label
    Friend WithEvents TbEv3 As TextBox
    Friend WithEvents TbNotaFinal As TextBox
    Friend WithEvents CmbAsignaturas As ComboBox
    Friend WithEvents CmbAlumnos As ComboBox
    Friend WithEvents LblNotaFinalInfo As Label
    Friend WithEvents LblImagen1 As Label
End Class
