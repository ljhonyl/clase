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
        SuspendLayout()
        ' 
        ' ListViewAsignaturas
        ' 
        ListViewAsignaturas.Location = New Point(64, 291)
        ListViewAsignaturas.Name = "ListViewAsignaturas"
        ListViewAsignaturas.Size = New Size(596, 310)
        ListViewAsignaturas.TabIndex = 0
        ListViewAsignaturas.UseCompatibleStateImageBehavior = False
        ' 
        ' GestionAsignaturas
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(734, 819)
        Controls.Add(ListViewAsignaturas)
        Name = "GestionAsignaturas"
        Text = "GestionAsignaturas"
        ResumeLayout(False)
    End Sub

    Friend WithEvents ListViewAsignaturas As ListView
End Class
