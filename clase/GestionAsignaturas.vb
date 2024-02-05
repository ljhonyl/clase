Imports System.ComponentModel

Public Class GestionAsignaturas

    Private Opcion = -1
    ''' <summary>
    ''' Se establecen las propiedades del listView y se carga la información de la base de datos
    ''' para ser mostrada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GestionAsignaturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewAsignaturas.View = View.Details
        ListViewAsignaturas.Columns.Add("ID", 50, HorizontalAlignment.Center)
        ListViewAsignaturas.Columns.Add("Nombre", 130, HorizontalAlignment.Center)
        ListViewAsignaturas.Columns.Add("Aula", 220, HorizontalAlignment.Center)
        ListViewAsignaturas.Columns.Add("Profesor", 220, HorizontalAlignment.Center)
        SetOpcionListado()

        AsignaturaADO.ActualizarListado(ListViewAsignaturas)
    End Sub

    Private Sub GestionAsignaturas_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
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

    Private Sub ListViewAsignaturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewAsignaturas.SelectedIndexChanged
        If ListViewAsignaturas.SelectedItems.Count > 0 Then
            'Activamos las opciones editar y eliminar del menú
            EditarToolStripMenuItem.Enabled = True
            EliminarToolStripMenuItem.Enabled = True
            Dim Indice As Integer = ListViewAsignaturas.SelectedIndices(0)
            MostrarItemEnTextBox(Indice)
        End If

    End Sub

    Private Sub MostrarItemEnTextBox(indice As Integer)
        Dim item = ListViewAsignaturas.Items(indice)
        TbId.Text = item.SubItems(0).Text
        TbAsignatura.Text = item.SubItems(1).Text
        TbAula.Text = item.SubItems(2).Text
        TbProfesor.Text = item.SubItems(3).Text
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        If ListViewAsignaturas.SelectedItems.Count > 0 Then
            '''<summary>
            '''Al item que seleccionamos se le resta uno para tener el indice del anterior
            '''</summary>
            Dim indice = ListViewAsignaturas.SelectedIndices(0) - 1
            If indice >= 0 Then
                ListViewAsignaturas.Items(indice).EnsureVisible()
                ListViewAsignaturas.Items(indice).Selected = True
            End If
        End If
    End Sub

    Private Sub BtnPrimero_Click(sender As Object, e As EventArgs) Handles BtnPrimero.Click
        ListViewAsignaturas.Items(0).EnsureVisible()
        ListViewAsignaturas.Items(0).Selected = True
    End Sub

    Private Sub BtnFin_Click(sender As Object, e As EventArgs) Handles BtnFin.Click
        ListViewAsignaturas.Items(ListViewAsignaturas.Items.Count - 1).EnsureVisible()
        ListViewAsignaturas.Items(ListViewAsignaturas.Items.Count - 1).Selected = True
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        If ListViewAsignaturas.SelectedItems.Count > 0 Then
            Dim indice = ListViewAsignaturas.SelectedIndices(0) + 1
            If indice <= ListViewAsignaturas.Items.Count - 1 Then
                ListViewAsignaturas.Items(indice).EnsureVisible()
                ListViewAsignaturas.Items(indice).Selected = True
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        If String.IsNullOrEmpty(TbAsignatura.Text) Then
            MsgBox("El campo asignatura no puede estar vacío")
        Else
            Dim Asignatura = CrearAsignatura()

            If Opcion = 1 Then
                Insertar(Asignatura)
            ElseIf Opcion = 2 Then
                Modificar(Asignatura)
            ElseIf Opcion = 3 Then
                Eliminar()
            End If
        End If
    End Sub

    Private Function CrearAsignatura() As ModuloAsignatura.Asignatura
        Dim Asignatura As New ModuloAsignatura.Asignatura
        Asignatura.Nombre = TbAsignatura.Text
        Asignatura.Aula = TbAula.Text
        Asignatura.Profesor = TbProfesor.Text

        Return Asignatura
    End Function

    Private Sub Insertar(Asignatura As ModuloAsignatura.Asignatura)
        AsignaturaADO.Insertar(Asignatura, ListViewAsignaturas)
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            TextBox.Clear()
        Next
        CambiarAListado()
        ListViewAsignaturas.Items(ListViewAsignaturas.Items.Count - 1).EnsureVisible()
        ListViewAsignaturas.Items(ListViewAsignaturas.Items.Count - 1).Selected = True
    End Sub

    Private Sub modificar(Asignatura As ModuloAsignatura.Asignatura)
        Dim Indice = ListViewAsignaturas.SelectedIndices(0)
        Dim Id As Integer = Integer.Parse(TbId.Text)
        AsignaturaADO.Modificar(Id, Asignatura, ListViewAsignaturas)
        ListViewAsignaturas.Items(Indice).EnsureVisible()
        ListViewAsignaturas.Items(Indice).Selected = True

        MsgBox("Asignatura modificada correctamente", MsgBoxStyle.OkOnly, "Aviso")
    End Sub

    Private Sub Eliminar()
        Dim Id As Integer = Integer.Parse(TbId.Text)
        Dim Result As MsgBoxResult = MsgBox("¿Desea eliminar la asignatura? Esta accion no se puede deshacer", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Confirmar")

        If Result = MsgBoxResult.Ok Then
            AsignaturaADO.Eliminar(Id, ListViewAsignaturas)
            MsgBox("Asignatura eliminada correctamente", MsgBoxStyle.OkOnly, "Aviso")
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
            For i As Integer = 0 To (ListViewAsignaturas.Items.Count - 1)
                Dim Item As ListViewItem = ListViewAsignaturas.Items(i)
                If IdBuscado.Equals(Item.SubItems(0).Text) Then
                    ListViewAsignaturas.Items(i).EnsureVisible()
                    ListViewAsignaturas.Items(i).Selected = True
                    MostrarItemEnTextBox(i)
                    i = ListViewAsignaturas.Items.Count
                    IdEncontrado = True
                End If
            Next
            If Not IdEncontrado Then
                MessageBox.Show("No se encontro el Id Buscado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Class