<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionProfesores
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        ListViewProfesores = New ListView()
        TbId = New TextBox()
        TbNombre = New TextBox()
        TbApellidos = New TextBox()
        TbDepartamento = New TextBox()
        LblId = New Label()
        LblNombre = New Label()
        LblApellidos = New Label()
        LblDepartamento = New Label()
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
        LblTitulo = New Label()
        TbBuscarId = New TextBox()
        BtnBuscar = New Button()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListViewProfesores
        ' 
        ListViewProfesores.FullRowSelect = True
        ListViewProfesores.Location = New Point(26, 283)
        ListViewProfesores.MultiSelect = False
        ListViewProfesores.Name = "ListViewProfesores"
        ListViewProfesores.Size = New Size(680, 510)
        ListViewProfesores.TabIndex = 12
        ListViewProfesores.UseCompatibleStateImageBehavior = False
        ' 
        ' TbId
        ' 
        TbId.Location = New Point(129, 86)
        TbId.Name = "TbId"
        TbId.Size = New Size(100, 23)
        TbId.TabIndex = 1
        ' 
        ' TbNombre
        ' 
        TbNombre.Location = New Point(459, 86)
        TbNombre.Name = "TbNombre"
        TbNombre.Size = New Size(196, 23)
        TbNombre.TabIndex = 2
        ' 
        ' TbApellidos
        ' 
        TbApellidos.Location = New Point(129, 142)
        TbApellidos.Name = "TbApellidos"
        TbApellidos.Size = New Size(220, 23)
        TbApellidos.TabIndex = 3
        ' 
        ' TbDepartamento
        ' 
        TbDepartamento.Location = New Point(459, 145)
        TbDepartamento.Name = "TbDepartamento"
        TbDepartamento.Size = New Size(196, 23)
        TbDepartamento.TabIndex = 4
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
        ' LblNombre
        ' 
        LblNombre.AutoSize = True
        LblNombre.Location = New Point(402, 89)
        LblNombre.Name = "LblNombre"
        LblNombre.Size = New Size(51, 15)
        LblNombre.TabIndex = 10
        LblNombre.Text = "Nombre"
        ' 
        ' LblApellidos
        ' 
        LblApellidos.AutoSize = True
        LblApellidos.Location = New Point(67, 148)
        LblApellidos.Name = "LblApellidos"
        LblApellidos.Size = New Size(56, 15)
        LblApellidos.TabIndex = 11
        LblApellidos.Text = "Apellidos"
        ' 
        ' LblDepartamento
        ' 
        LblDepartamento.AutoSize = True
        LblDepartamento.Location = New Point(370, 148)
        LblDepartamento.Name = "LblDepartamento"
        LblDepartamento.Size = New Size(83, 15)
        LblDepartamento.TabIndex = 12
        LblDepartamento.Text = "Departamento"
        ' 
        ' BtnPrimero
        ' 
        BtnPrimero.Image = My.Resources.Resources.primero
        BtnPrimero.Location = New Point(29, 241)
        BtnPrimero.Name = "BtnPrimero"
        BtnPrimero.Size = New Size(75, 23)
        BtnPrimero.TabIndex = 6
        BtnPrimero.UseVisualStyleBackColor = True
        ' 
        ' BtnAnterior
        ' 
        BtnAnterior.Image = My.Resources.Resources.anterior
        BtnAnterior.Location = New Point(129, 241)
        BtnAnterior.Name = "BtnAnterior"
        BtnAnterior.Size = New Size(75, 23)
        BtnAnterior.TabIndex = 7
        BtnAnterior.UseVisualStyleBackColor = True
        ' 
        ' BtnSiguiente
        ' 
        BtnSiguiente.Image = My.Resources.Resources.siguiente
        BtnSiguiente.Location = New Point(235, 241)
        BtnSiguiente.Name = "BtnSiguiente"
        BtnSiguiente.Size = New Size(75, 23)
        BtnSiguiente.TabIndex = 8
        BtnSiguiente.UseVisualStyleBackColor = True
        ' 
        ' BtnFin
        ' 
        BtnFin.Image = My.Resources.Resources.ultimo
        BtnFin.Location = New Point(335, 241)
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
        MenuStrip1.Items.AddRange(New ToolStripItem() {ListadoToolStripMenuItem, InsertarToolStripMenuItem, EditarToolStripMenuItem, EliminarToolStripMenuItem})
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
        ' LblTitulo
        ' 
        LblTitulo.AutoSize = True
        LblTitulo.Font = New Font("Segoe UI", 20F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        LblTitulo.Location = New Point(272, 24)
        LblTitulo.Name = "LblTitulo"
        LblTitulo.Size = New Size(150, 37)
        LblTitulo.TabIndex = 19
        LblTitulo.Text = "Profesores"
        ' 
        ' TbBuscarId
        ' 
        TbBuscarId.Location = New Point(475, 243)
        TbBuscarId.Name = "TbBuscarId"
        TbBuscarId.Size = New Size(100, 23)
        TbBuscarId.TabIndex = 10
        ' 
        ' BtnBuscar
        ' 
        BtnBuscar.Image = My.Resources.Resources.buscar
        BtnBuscar.Location = New Point(581, 243)
        BtnBuscar.Name = "BtnBuscar"
        BtnBuscar.Size = New Size(75, 23)
        BtnBuscar.TabIndex = 11
        BtnBuscar.UseVisualStyleBackColor = True
        ' 
        ' GestionProfesores
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(734, 819)
        Controls.Add(BtnBuscar)
        Controls.Add(TbBuscarId)
        Controls.Add(LblTitulo)
        Controls.Add(BtnAdd)
        Controls.Add(BtnFin)
        Controls.Add(BtnSiguiente)
        Controls.Add(BtnAnterior)
        Controls.Add(BtnPrimero)
        Controls.Add(LblDepartamento)
        Controls.Add(LblApellidos)
        Controls.Add(LblNombre)
        Controls.Add(LblId)
        Controls.Add(TbDepartamento)
        Controls.Add(TbApellidos)
        Controls.Add(TbNombre)
        Controls.Add(TbId)
        Controls.Add(ListViewProfesores)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "GestionProfesores"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GestionProfesores"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListViewProfesores As ListView
    Friend WithEvents TbId As TextBox
    Friend WithEvents TbNombre As TextBox
    Friend WithEvents TbApellidos As TextBox
    Friend WithEvents TbDepartamento As TextBox
    Friend WithEvents LblId As Label
    Friend WithEvents LblNombre As Label
    Friend WithEvents LblApellidos As Label
    Friend WithEvents LblDepartamento As Label
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
    Friend WithEvents LblTitulo As Label
    Friend WithEvents TbBuscarId As TextBox
    Friend WithEvents BtnBuscar As Button
End Class
