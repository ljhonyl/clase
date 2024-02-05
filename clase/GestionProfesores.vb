Imports System.ComponentModel

Public Class GestionProfesores
    'Atributo que ayudará el moverse por las distintas opciones
    Private Opcion = -1
    ''' <summary>
    ''' Se establecen las propiedades del listView y se carga la información de la base de datos
    ''' para ser mostrada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GestionProfesores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewProfesores.View = View.Details
        ListViewProfesores.Columns.Add("ID", 50, HorizontalAlignment.Center)
        ListViewProfesores.Columns.Add("Nombre", 130, HorizontalAlignment.Center)
        ListViewProfesores.Columns.Add("Aula", 220, HorizontalAlignment.Center)
        ListViewProfesores.Columns.Add("Profesor", 220, HorizontalAlignment.Center)
        SetOpcionListado()

        ProfesorADO.ActualizarListado(ListViewProfesores)
    End Sub

    Private Sub GestionProfesores_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        Application.Exit()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        If e.ClickedItem.Text = "Listado" Then
            SetOpcionListado()
        ElseIf e.ClickedItem.Text = "Insertar" Then
            SetOpcionInsertar()
        ElseIf e.ClickedItem.Text = "Editar" Then
            SetOpcionEditar()
        ElseIf e.ClickedItem.Text = "Eliminar" Then
            SetOpcionEliminar()
        End If
    End Sub

    Private Sub SetOpcionListado()
        Opcion = 0
        PintaOpcion()
        ManejarTextBox(True, False, True)
        ManejarComponentesBuscar(False, True)
        BtnAdd.Hide()
    End Sub
    Private Sub SetOpcionInsertar()
        Opcion = 1
        PintaOpcion()
        ManejarTextBox(False, True, True)
        TbId.ReadOnly = True
        ManejarComponentesBuscar(True, False)
        BtnAdd.Text = "Añadir"
        BtnAdd.Show()
    End Sub

    Private Sub SetOpcionEditar()
        Opcion = 2
        PintaOpcion()
        ManejarTextBox(False, False, True)
        TbId.ReadOnly = True
        ManejarComponentesBuscar(False, True)
        BtnAdd.Text = "Guardar"
        BtnAdd.Show()
    End Sub

    Private Sub SetOpcionEliminar()
        Opcion = 3
        PintaOpcion()
        ManejarTextBox(True, False, True)
        TbBuscarId.ReadOnly = False
        ManejarComponentesBuscar(False, True)
        BtnAdd.Text = "Eliminar"
        BtnAdd.Show()
    End Sub

    Private Sub PintaOpcion()
        For Each item As ToolStripItem In MenuStrip1.Items
            item.BackColor = SystemColors.Control
        Next
        If Opcion = 0 Then
            ListadoToolStripMenuItem.BackColor = SystemColors.MenuHighlight
        ElseIf Opcion = 1 Then
            InsertarToolStripMenuItem.BackColor = SystemColors.MenuHighlight
        ElseIf Opcion = 2 Then
            EditarToolStripMenuItem.BackColor = SystemColors.MenuHighlight
        ElseIf Opcion = 3 Then
            EliminarToolStripMenuItem.BackColor = SystemColors.MenuHighlight
        End If

    End Sub

    Private Sub ManejarTextBox(SoloLectura As Boolean, Limpiable As Boolean, Visible As Boolean)
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            If SoloLectura Then
                TextBox.ReadOnly = True
            Else
                TextBox.ReadOnly = False
            End If
        Next
        If Limpiable Then
            For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
                TextBox.Clear()
            Next
        End If
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            If Visible Then
                TextBox.Show()
            Else
                TextBox.Hide()
            End If
        Next
    End Sub

    Private Sub ManejarComponentesBuscar(SoloLectura As Boolean, Habilitado As Boolean)
        If (SoloLectura) Then
            TbBuscarId.ReadOnly = True
        Else
            TbBuscarId.ReadOnly = False
        End If

        If Habilitado Then
            BtnBuscar.Enabled = True
        Else
            BtnBuscar.Enabled = False
        End If
    End Sub

    Private Sub ListViewProfesores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewProfesores.SelectedIndexChanged
        If ListViewProfesores.SelectedItems.Count > 0 Then
            'Activamos las opciones editar y eliminar del menú
            EditarToolStripMenuItem.Enabled = True
            EliminarToolStripMenuItem.Enabled = True
            Dim Indice As Integer = ListViewProfesores.SelectedIndices(0)
            MostrarItemEnTextBox(Indice)
        End If

    End Sub

    Private Sub MostrarItemEnTextBox(indice As Integer)
        Dim item = ListViewProfesores.Items(indice)
        TbId.Text = item.SubItems(0).Text
        TbNombre.Text = item.SubItems(1).Text
        TbApellidos.Text = item.SubItems(2).Text
        TbDepartamento.Text = item.SubItems(3).Text
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        If ListViewProfesores.SelectedItems.Count > 0 Then
            '''<summary>
            '''Al item que seleccionamos se le resta uno para tener el indice del anterior
            '''</summary>
            Dim indice = ListViewProfesores.SelectedIndices(0) - 1
            If indice >= 0 Then
                ListViewProfesores.Items(indice).EnsureVisible()
                ListViewProfesores.Items(indice).Selected = True
            End If
        End If
    End Sub

    Private Sub BtnPrimero_Click(sender As Object, e As EventArgs) Handles BtnPrimero.Click
        ListViewProfesores.Items(0).EnsureVisible()
        ListViewProfesores.Items(0).Selected = True
    End Sub

    Private Sub BtnFin_Click(sender As Object, e As EventArgs) Handles BtnFin.Click
        ListViewProfesores.Items(ListViewProfesores.Items.Count - 1).EnsureVisible()
        ListViewProfesores.Items(ListViewProfesores.Items.Count - 1).Selected = True
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        If ListViewProfesores.SelectedItems.Count > 0 Then
            Dim indice = ListViewProfesores.SelectedIndices(0) + 1
            If indice <= ListViewProfesores.Items.Count - 1 Then
                ListViewProfesores.Items(indice).EnsureVisible()
                ListViewProfesores.Items(indice).Selected = True
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        If String.IsNullOrEmpty(TbNombre.Text) Or String.IsNullOrEmpty(TbApellidos.Text) Then
            MsgBox("El campo asignatura no puede estar vacío")
        Else
            Dim Profesor = CrearProfesor()
            If Opcion = 1 Then
                Insertar(Profesor)
            ElseIf Opcion = 2 Then
                modificar(Profesor)
            ElseIf Opcion = 3 Then
                Eliminar()
            End If
        End If
    End Sub

    Private Function CrearProfesor() As ModuloProfesor.Profesor
        Dim Profesor As New ModuloProfesor.Profesor
        Profesor.Nombre = TbNombre.Text
        Profesor.Apellidos = TbApellidos.Text
        Profesor.Departamento = TbDepartamento.Text

        Return Profesor
    End Function

    Private Sub Insertar(Profesor As ModuloProfesor.Profesor)
        ProfesorADO.Insertar(Profesor, ListViewProfesores)
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            TextBox.Clear()
        Next
        CambiarAListado()
        ListViewProfesores.Items(ListViewProfesores.Items.Count - 1).EnsureVisible()
        ListViewProfesores.Items(ListViewProfesores.Items.Count - 1).Selected = True
    End Sub

    Private Sub modificar(Profesor As ModuloProfesor.Profesor)
        Dim Indice = ListViewProfesores.SelectedIndices(0)
        Dim Id As Integer = Integer.Parse(TbId.Text)
        ProfesorADO.Modificar(Id, Profesor, ListViewProfesores)
        ListViewProfesores.Items(Indice).EnsureVisible()
        ListViewProfesores.Items(Indice).Selected = True

        MsgBox("Profesor modificado correctamente", MsgBoxStyle.OkOnly, "Aviso")
    End Sub

    Private Sub Eliminar()
        Dim Id As Integer = Integer.Parse(TbId.Text)
        Dim Result As MsgBoxResult = MsgBox("¿Desea eliminar el Profesor? Esta accion no se puede deshacer", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Confirmar")

        If Result = MsgBoxResult.Ok Then
            ProfesorADO.Eliminar(Id, ListViewProfesores)
            MsgBox("Profesor eliminado correctamente", MsgBoxStyle.OkOnly, "Aviso")
            CambiarAListado()
        End If
    End Sub

    Private Sub CambiarAListado()
        For Each item As ToolStripItem In MenuStrip1.Items
            If item.Text = "Listado" Then
                item.PerformClick()
                Exit For
            End If
        Next
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If Not String.IsNullOrEmpty(TbBuscarId.Text) Then
            Dim IdBuscado = TbBuscarId.Text
            Dim IdEncontrado As Boolean = False
            For i As Integer = 0 To (ListViewProfesores.Items.Count - 1)
                Dim Item As ListViewItem = ListViewProfesores.Items(i)
                If IdBuscado.Equals(Item.SubItems(0).Text) Then
                    ListViewProfesores.Items(i).EnsureVisible()
                    ListViewProfesores.Items(i).Selected = True
                    MostrarItemEnTextBox(i)
                    i = ListViewProfesores.Items.Count
                    IdEncontrado = True
                End If
            Next
            If Not IdEncontrado Then
                MessageBox.Show("No se encontro el Id Buscado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Class