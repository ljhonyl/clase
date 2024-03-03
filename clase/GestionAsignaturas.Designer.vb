<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionAsignaturas
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(GestionAsignaturas))
        ListViewAsignaturas = New ListView()
        TbId = New TextBox()
        TbAsignatura = New TextBox()
        TbAula = New TextBox()
        TbProfesor = New TextBox()
        LblId = New Label()
        LblAsignatura = New Label()
        LblAula = New Label()
        LblProfesor = New Label()
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
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListViewAsignaturas
        ' 
        ListViewAsignaturas.FullRowSelect = True
        ListViewAsignaturas.Location = New Point(61, 283)
        ListViewAsignaturas.MultiSelect = False
        ListViewAsignaturas.Name = "ListViewAsignaturas"
        ListViewAsignaturas.Size = New Size(594, 510)
        ListViewAsignaturas.TabIndex = 12
        ListViewAsignaturas.UseCompatibleStateImageBehavior = False
        ' 
        ' TbId
        ' 
        TbId.Location = New Point(129, 86)
        TbId.Name = "TbId"
        TbId.Size = New Size(100, 23)
        TbId.TabIndex = 1
        ' 
        ' TbAsignatura
        ' 
        TbAsignatura.Location = New Point(459, 86)
        TbAsignatura.Name = "TbAsignatura"
        TbAsignatura.Size = New Size(196, 23)
        TbAsignatura.TabIndex = 2
        ' 
        ' TbAula
        ' 
        TbAula.Location = New Point(129, 142)
        TbAula.Name = "TbAula"
        TbAula.Size = New Size(153, 23)
        TbAula.TabIndex = 3
        ' 
        ' TbProfesor
        ' 
        TbProfesor.Location = New Point(459, 145)
        TbProfesor.Name = "TbProfesor"
        TbProfesor.Size = New Size(196, 23)
        TbProfesor.TabIndex = 4
        ' 
        ' LblId
        ' 
        LblId.AutoSize = True
        LblId.Location = New Point(106, 89)
        LblId.Name = "LblId"
        LblId.Size = New Size(17, 15)
        LblId.TabIndex = 9
        LblId.Text = "Id"
        ' 
        ' LblAsignatura
        ' 
        LblAsignatura.AutoSize = True
        LblAsignatura.Location = New Point(389, 89)
        LblAsignatura.Name = "LblAsignatura"
        LblAsignatura.Size = New Size(64, 15)
        LblAsignatura.TabIndex = 10
        LblAsignatura.Text = "Asignatura"
        ' 
        ' LblAula
        ' 
        LblAula.AutoSize = True
        LblAula.Location = New Point(92, 145)
        LblAula.Name = "LblAula"
        LblAula.Size = New Size(31, 15)
        LblAula.TabIndex = 11
        LblAula.Text = "Aula"
        ' 
        ' LblProfesor
        ' 
        LblProfesor.AutoSize = True
        LblProfesor.Location = New Point(402, 148)
        LblProfesor.Name = "LblProfesor"
        LblProfesor.Size = New Size(51, 15)
        LblProfesor.TabIndex = 12
        LblProfesor.Text = "Profesor"
        ' 
        ' BtnPrimero
        ' 
        BtnPrimero.Image = My.Resources.Resources.primero
        BtnPrimero.Location = New Point(61, 243)
        BtnPrimero.Name = "BtnPrimero"
        BtnPrimero.Size = New Size(75, 23)
        BtnPrimero.TabIndex = 6
        BtnPrimero.UseVisualStyleBackColor = True
        ' 
        ' BtnAnterior
        ' 
        BtnAnterior.Image = My.Resources.Resources.anterior
        BtnAnterior.Location = New Point(161, 243)
        BtnAnterior.Name = "BtnAnterior"
        BtnAnterior.Size = New Size(75, 23)
        BtnAnterior.TabIndex = 7
        BtnAnterior.UseVisualStyleBackColor = True
        ' 
        ' BtnSiguiente
        ' 
        BtnSiguiente.Image = My.Resources.Resources.siguiente
        BtnSiguiente.Location = New Point(267, 243)
        BtnSiguiente.Name = "BtnSiguiente"
        BtnSiguiente.Size = New Size(75, 23)
        BtnSiguiente.TabIndex = 8
        BtnSiguiente.UseVisualStyleBackColor = True
        ' 
        ' BtnFin
        ' 
        BtnFin.Image = My.Resources.Resources.ultimo
        BtnFin.Location = New Point(367, 243)
        BtnFin.Name = "BtnFin"
        BtnFin.Size = New Size(75, 23)
        BtnFin.TabIndex = 9
        BtnFin.UseVisualStyleBackColor = True
        ' 
        ' BtnAdd
        ' 
        BtnAdd.Location = New Point(580, 195)
        BtnAdd.Name = "BtnAdd"
        BtnAdd.Size = New Size(75, 23)
        BtnAdd.TabIndex = 5
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
        TbBuscarId.Location = New Point(474, 243)
        TbBuscarId.Name = "TbBuscarId"
        TbBuscarId.Size = New Size(100, 23)
        TbBuscarId.TabIndex = 10
        ' 
        ' BtnBuscar
        ' 
        BtnBuscar.Image = My.Resources.Resources.buscar
        BtnBuscar.Location = New Point(580, 243)
        BtnBuscar.Name = "BtnBuscar"
        BtnBuscar.Size = New Size(75, 23)
        BtnBuscar.TabIndex = 11
        BtnBuscar.UseVisualStyleBackColor = True
        ' 
        ' GestionAsignaturas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(734, 819)
        Controls.Add(BtnBuscar)
        Controls.Add(TbBuscarId)
        Controls.Add(Label5)
        Controls.Add(BtnAdd)
        Controls.Add(BtnFin)
        Controls.Add(BtnSiguiente)
        Controls.Add(BtnAnterior)
        Controls.Add(BtnPrimero)
        Controls.Add(LblProfesor)
        Controls.Add(LblAula)
        Controls.Add(LblAsignatura)
        Controls.Add(LblId)
        Controls.Add(TbProfesor)
        Controls.Add(TbAula)
        Controls.Add(TbAsignatura)
        Controls.Add(TbId)
        Controls.Add(ListViewAsignaturas)
        Controls.Add(MenuStrip1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Name = "GestionAsignaturas"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GestionAsignaturas"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListViewAsignaturas As ListView
    Friend WithEvents TbId As TextBox
    Friend WithEvents TbAsignatura As TextBox
    Friend WithEvents TbAula As TextBox
    Friend WithEvents TbProfesor As TextBox
    Friend WithEvents LblId As Label
    Friend WithEvents LblAsignatura As Label
    Friend WithEvents LblAula As Label
    Friend WithEvents LblProfesor As Label
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
End Class
