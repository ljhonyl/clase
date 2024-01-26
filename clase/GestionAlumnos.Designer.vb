<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GestionAlumnos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(GestionAlumnos))
        LblId = New Label()
        LblNombre = New Label()
        LblApellidos = New Label()
        LblFechaNacimiento = New Label()
        LblDireccion = New Label()
        LblLocalidad = New Label()
        LblMovil = New Label()
        LblEmail = New Label()
        LblNacionalidad = New Label()
        BtnPrimero = New Button()
        BtnAnterior = New Button()
        BtnSiguiente = New Button()
        BtnFin = New Button()
        ListViewAlumnos = New ListView()
        MenuStrip1 = New MenuStrip()
        ListadoToolStripMenuItem = New ToolStripMenuItem()
        InsertarToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        EditarToolStripMenuItem = New ToolStripMenuItem()
        EliminarToolStripMenuItem = New ToolStripMenuItem()
        TbId = New TextBox()
        TbNombre = New TextBox()
        TbApellido = New TextBox()
        TbDireccion = New TextBox()
        TbLocalidad = New TextBox()
        TbMovil = New TextBox()
        TbEmail = New TextBox()
        TbNacionalidad = New TextBox()
        TbFechaNacimiento = New TextBox()
        BtnAdd = New Button()
        TbBuscarId = New TextBox()
        BtnBuscar = New Button()
        LblTitulo = New Label()
        LblDatos = New Label()
        ImageList1 = New ImageList(components)
        Label1 = New Label()
        Label2 = New Label()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' LblId
        ' 
        LblId.AutoSize = True
        LblId.Location = New Point(72, 185)
        LblId.Name = "LblId"
        LblId.Size = New Size(17, 15)
        LblId.TabIndex = 0
        LblId.Text = "Id"
        ' 
        ' LblNombre
        ' 
        LblNombre.AutoSize = True
        LblNombre.Location = New Point(72, 252)
        LblNombre.Name = "LblNombre"
        LblNombre.Size = New Size(51, 15)
        LblNombre.TabIndex = 1
        LblNombre.Text = "Nombre"
        ' 
        ' LblApellidos
        ' 
        LblApellidos.AutoSize = True
        LblApellidos.Location = New Point(73, 330)
        LblApellidos.Name = "LblApellidos"
        LblApellidos.Size = New Size(56, 15)
        LblApellidos.TabIndex = 2
        LblApellidos.Text = "Apellidos"
        ' 
        ' LblFechaNacimiento
        ' 
        LblFechaNacimiento.AutoSize = True
        LblFechaNacimiento.Location = New Point(73, 636)
        LblFechaNacimiento.Name = "LblFechaNacimiento"
        LblFechaNacimiento.Size = New Size(117, 15)
        LblFechaNacimiento.TabIndex = 3
        LblFechaNacimiento.Text = "Fecha de nacimiento"
        ' 
        ' LblDireccion
        ' 
        LblDireccion.AutoSize = True
        LblDireccion.Location = New Point(74, 469)
        LblDireccion.Name = "LblDireccion"
        LblDireccion.Size = New Size(57, 15)
        LblDireccion.TabIndex = 4
        LblDireccion.Text = "Dirección"
        ' 
        ' LblLocalidad
        ' 
        LblLocalidad.AutoSize = True
        LblLocalidad.Location = New Point(73, 555)
        LblLocalidad.Name = "LblLocalidad"
        LblLocalidad.Size = New Size(58, 15)
        LblLocalidad.TabIndex = 5
        LblLocalidad.Text = "Localidad"
        ' 
        ' LblMovil
        ' 
        LblMovil.AutoSize = True
        LblMovil.Location = New Point(291, 555)
        LblMovil.Name = "LblMovil"
        LblMovil.Size = New Size(37, 15)
        LblMovil.TabIndex = 6
        LblMovil.Text = "Móvil"
        ' 
        ' LblEmail
        ' 
        LblEmail.AutoSize = True
        LblEmail.Location = New Point(72, 393)
        LblEmail.Name = "LblEmail"
        LblEmail.Size = New Size(36, 15)
        LblEmail.TabIndex = 7
        LblEmail.Text = "Email"
        ' 
        ' LblNacionalidad
        ' 
        LblNacionalidad.AutoSize = True
        LblNacionalidad.Location = New Point(292, 636)
        LblNacionalidad.Name = "LblNacionalidad"
        LblNacionalidad.Size = New Size(77, 15)
        LblNacionalidad.TabIndex = 8
        LblNacionalidad.Text = "Nacionalidad"
        ' 
        ' BtnPrimero
        ' 
        BtnPrimero.Location = New Point(74, 143)
        BtnPrimero.Name = "BtnPrimero"
        BtnPrimero.Size = New Size(75, 23)
        BtnPrimero.TabIndex = 9
        BtnPrimero.Text = "Ir al inicio"
        BtnPrimero.UseVisualStyleBackColor = True
        ' 
        ' BtnAnterior
        ' 
        BtnAnterior.Location = New Point(169, 143)
        BtnAnterior.Name = "BtnAnterior"
        BtnAnterior.Size = New Size(75, 23)
        BtnAnterior.TabIndex = 10
        BtnAnterior.Text = "Anterior"
        BtnAnterior.UseVisualStyleBackColor = True
        ' 
        ' BtnSiguiente
        ' 
        BtnSiguiente.Location = New Point(273, 143)
        BtnSiguiente.Name = "BtnSiguiente"
        BtnSiguiente.Size = New Size(75, 23)
        BtnSiguiente.TabIndex = 11
        BtnSiguiente.Text = "Siguiente"
        BtnSiguiente.UseVisualStyleBackColor = True
        ' 
        ' BtnFin
        ' 
        BtnFin.Location = New Point(372, 143)
        BtnFin.Name = "BtnFin"
        BtnFin.Size = New Size(75, 23)
        BtnFin.TabIndex = 12
        BtnFin.Text = "Ir al final"
        BtnFin.UseVisualStyleBackColor = True
        ' 
        ' ListViewAlumnos
        ' 
        ListViewAlumnos.FullRowSelect = True
        ListViewAlumnos.Location = New Point(22, 198)
        ListViewAlumnos.MultiSelect = False
        ListViewAlumnos.Name = "ListViewAlumnos"
        ListViewAlumnos.Size = New Size(686, 601)
        ListViewAlumnos.TabIndex = 13
        ListViewAlumnos.UseCompatibleStateImageBehavior = False
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {ListadoToolStripMenuItem, InsertarToolStripMenuItem, ToolStripMenuItem1, EditarToolStripMenuItem, EliminarToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(734, 24)
        MenuStrip1.TabIndex = 14
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
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(12, 20)
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
        ' TbId
        ' 
        TbId.Location = New Point(72, 203)
        TbId.Name = "TbId"
        TbId.ReadOnly = True
        TbId.Size = New Size(100, 23)
        TbId.TabIndex = 15
        ' 
        ' TbNombre
        ' 
        TbNombre.Location = New Point(72, 270)
        TbNombre.Name = "TbNombre"
        TbNombre.Size = New Size(222, 23)
        TbNombre.TabIndex = 16
        ' 
        ' TbApellido
        ' 
        TbApellido.Location = New Point(73, 348)
        TbApellido.Name = "TbApellido"
        TbApellido.Size = New Size(318, 23)
        TbApellido.TabIndex = 17
        ' 
        ' TbDireccion
        ' 
        TbDireccion.Location = New Point(74, 487)
        TbDireccion.Name = "TbDireccion"
        TbDireccion.Size = New Size(319, 23)
        TbDireccion.TabIndex = 18
        ' 
        ' TbLocalidad
        ' 
        TbLocalidad.Location = New Point(73, 573)
        TbLocalidad.Name = "TbLocalidad"
        TbLocalidad.Size = New Size(100, 23)
        TbLocalidad.TabIndex = 19
        ' 
        ' TbMovil
        ' 
        TbMovil.Location = New Point(293, 573)
        TbMovil.Name = "TbMovil"
        TbMovil.Size = New Size(100, 23)
        TbMovil.TabIndex = 20
        ' 
        ' TbEmail
        ' 
        TbEmail.Location = New Point(72, 411)
        TbEmail.Name = "TbEmail"
        TbEmail.Size = New Size(319, 23)
        TbEmail.TabIndex = 21
        ' 
        ' TbNacionalidad
        ' 
        TbNacionalidad.Location = New Point(293, 654)
        TbNacionalidad.Name = "TbNacionalidad"
        TbNacionalidad.Size = New Size(100, 23)
        TbNacionalidad.TabIndex = 23
        ' 
        ' TbFechaNacimiento
        ' 
        TbFechaNacimiento.Location = New Point(73, 656)
        TbFechaNacimiento.Name = "TbFechaNacimiento"
        TbFechaNacimiento.PlaceholderText = "DD/MM/YYYY"
        TbFechaNacimiento.Size = New Size(100, 23)
        TbFechaNacimiento.TabIndex = 22
        ' 
        ' BtnAdd
        ' 
        BtnAdd.Location = New Point(72, 748)
        BtnAdd.Name = "BtnAdd"
        BtnAdd.Size = New Size(321, 23)
        BtnAdd.TabIndex = 24
        BtnAdd.Text = "Añadir Alumno"
        BtnAdd.UseVisualStyleBackColor = True
        ' 
        ' TbBuscarId
        ' 
        TbBuscarId.Location = New Point(510, 143)
        TbBuscarId.Name = "TbBuscarId"
        TbBuscarId.PlaceholderText = "ID"
        TbBuscarId.Size = New Size(100, 23)
        TbBuscarId.TabIndex = 25
        ' 
        ' BtnBuscar
        ' 
        BtnBuscar.Location = New Point(633, 143)
        BtnBuscar.Name = "BtnBuscar"
        BtnBuscar.Size = New Size(75, 23)
        BtnBuscar.TabIndex = 26
        BtnBuscar.Text = "Buscar"
        BtnBuscar.UseVisualStyleBackColor = True
        ' 
        ' LblTitulo
        ' 
        LblTitulo.Font = New Font("Segoe UI", 20F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        LblTitulo.Location = New Point(273, 47)
        LblTitulo.Name = "LblTitulo"
        LblTitulo.Size = New Size(175, 49)
        LblTitulo.TabIndex = 27
        LblTitulo.Text = "ALUMNOS"
        ' 
        ' LblDatos
        ' 
        LblDatos.AutoSize = True
        LblDatos.BackColor = SystemColors.ScrollBar
        LblDatos.Font = New Font("Segoe UI", 13F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        LblDatos.Location = New Point(72, 175)
        LblDatos.Name = "LblDatos"
        LblDatos.Size = New Size(157, 25)
        LblDatos.TabIndex = 28
        LblDatos.Text = "Datos Personales"
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth8Bit
        ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        ImageList1.TransparentColor = Color.Transparent
        ImageList1.Images.SetKeyName(0, "IMG_20240126_195016-removebg-preview.png")
        ImageList1.Images.SetKeyName(1, "editar2.png")
        ImageList1.Images.SetKeyName(2, "eliminar.jpg")
        ImageList1.Images.SetKeyName(3, "add.png")
        ' 
        ' Label1
        ' 
        Label1.ImageIndex = 3
        Label1.ImageList = ImageList1
        Label1.Location = New Point(476, 300)
        Label1.Name = "Label1"
        Label1.Size = New Size(180, 156)
        Label1.TabIndex = 29
        ' 
        ' Label2
        ' 
        Label2.Image = CType(resources.GetObject("Label2.Image"), Image)
        Label2.Location = New Point(476, 523)
        Label2.Name = "Label2"
        Label2.Size = New Size(180, 156)
        Label2.TabIndex = 30
        ' 
        ' GestionAlumnos
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(734, 819)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(LblDatos)
        Controls.Add(LblTitulo)
        Controls.Add(BtnBuscar)
        Controls.Add(TbBuscarId)
        Controls.Add(BtnAdd)
        Controls.Add(TbFechaNacimiento)
        Controls.Add(TbNacionalidad)
        Controls.Add(TbEmail)
        Controls.Add(TbMovil)
        Controls.Add(TbLocalidad)
        Controls.Add(TbDireccion)
        Controls.Add(TbApellido)
        Controls.Add(TbNombre)
        Controls.Add(TbId)
        Controls.Add(BtnFin)
        Controls.Add(BtnSiguiente)
        Controls.Add(BtnAnterior)
        Controls.Add(LblNacionalidad)
        Controls.Add(LblEmail)
        Controls.Add(LblMovil)
        Controls.Add(LblLocalidad)
        Controls.Add(LblDireccion)
        Controls.Add(LblFechaNacimiento)
        Controls.Add(LblApellidos)
        Controls.Add(LblNombre)
        Controls.Add(LblId)
        Controls.Add(MenuStrip1)
        Controls.Add(ListViewAlumnos)
        Controls.Add(BtnPrimero)
        MainMenuStrip = MenuStrip1
        Name = "GestionAlumnos"
        Text = "VistaAlumnos"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblId As Label
    Friend WithEvents LblNombre As Label
    Friend WithEvents LblApellidos As Label
    Friend WithEvents LblFechaNacimiento As Label
    Friend WithEvents LblDireccion As Label
    Friend WithEvents LblLocalidad As Label
    Friend WithEvents LblMovil As Label
    Friend WithEvents LblEmail As Label
    Friend WithEvents LblNacionalidad As Label
    Friend WithEvents BtnPrimero As Button
    Friend WithEvents BtnAnterior As Button
    Friend WithEvents BtnSiguiente As Button
    Friend WithEvents BtnFin As Button
    Friend WithEvents ListViewAlumnos As ListView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ListadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InsertarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TbId As TextBox
    Friend WithEvents TbNombre As TextBox
    Friend WithEvents TbApellido As TextBox
    Friend WithEvents TbDireccion As TextBox
    Friend WithEvents TbLocalidad As TextBox
    Friend WithEvents TbMovil As TextBox
    Friend WithEvents TbEmail As TextBox
    Friend WithEvents TbNacionalidad As TextBox
    Friend WithEvents TbFechaNacimiento As TextBox
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnAdd As Button
    Friend WithEvents TbBuscarId As TextBox
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents LblTitulo As Label
    Friend WithEvents LblDatos As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class