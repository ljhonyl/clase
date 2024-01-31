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
        ListViewAsignaturas = New ListView()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        MenuStrip1 = New MenuStrip()
        ListadoToolStripMenuItem = New ToolStripMenuItem()
        InsertarToolStripMenuItem = New ToolStripMenuItem()
        EditarToolStripMenuItem = New ToolStripMenuItem()
        EliminarToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListViewAsignaturas
        ' 
        ListViewAsignaturas.Location = New Point(26, 283)
        ListViewAsignaturas.Name = "ListViewAsignaturas"
        ListViewAsignaturas.Size = New Size(680, 510)
        ListViewAsignaturas.TabIndex = 0
        ListViewAsignaturas.UseCompatibleStateImageBehavior = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(129, 86)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(100, 23)
        TextBox1.TabIndex = 5
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(459, 86)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(196, 23)
        TextBox2.TabIndex = 6
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(129, 142)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(153, 23)
        TextBox3.TabIndex = 7
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(459, 145)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(196, 23)
        TextBox4.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(106, 89)
        Label1.Name = "Label1"
        Label1.Size = New Size(17, 15)
        Label1.TabIndex = 9
        Label1.Text = "Id"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(389, 89)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 15)
        Label2.TabIndex = 10
        Label2.Text = "Asignatura"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(92, 145)
        Label3.Name = "Label3"
        Label3.Size = New Size(31, 15)
        Label3.TabIndex = 11
        Label3.Text = "Aula"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(402, 148)
        Label4.Name = "Label4"
        Label4.Size = New Size(51, 15)
        Label4.TabIndex = 12
        Label4.Text = "Profesor"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(172, 235)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 13
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(272, 235)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 14
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(378, 235)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 15
        Button3.Text = "Button3"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(478, 235)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 23)
        Button4.TabIndex = 16
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(580, 195)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 23)
        Button5.TabIndex = 17
        Button5.Text = "Button5"
        Button5.UseVisualStyleBackColor = True
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
        ' GestionAsignaturas
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(734, 819)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBox4)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(ListViewAsignaturas)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "GestionAsignaturas"
        Text = "GestionAsignaturas"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListViewAsignaturas As ListView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ListadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InsertarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
End Class
