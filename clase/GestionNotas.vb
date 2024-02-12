Imports System.ComponentModel

Public Class GestionNotas
    'Atributo que ayudará el moverse por las distintas opciones
    Private Opcion = -1
    Private Sub GestionNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewNotas.View = View.Details
        ListViewNotas.Columns.Add("ID Asignatura", 50, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("ID Alumno", 190, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("1ª Evaluación", 220, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("2ª Evaluación", 215, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("3ª Evaluación", 215, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("Nota Final", 215, HorizontalAlignment.Center)
        SetOpcionListado()

        NotaADO.ActualizarListado(ListViewNotas)
        NotaADO.CargarComboBox(CmbAsignaturas, "Asignaturas")
        NotaADO.CargarComboBox(CmbAlumnos, "Alumnos")

    End Sub

    Private Sub GestionNotas_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
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
        ListViewNotas.Show()
        ManejarLabel(False)
        ManejarTextBox(False, False, False)
        TbBuscarId.Show()
        MostrarBotones(True)
        ManejarComponentesBuscar(False, True)
        BtnAdd.Hide()
    End Sub
    Private Sub SetOpcionInsertar()
        Opcion = 1
        PintaOpcion()
        ListViewNotas.Hide()
        ManejarLabel(True)
        ManejarTextBox(False, True, True)
        ManejarComponentesBuscar(True, False)
        BtnAdd.Text = "Añadir"
        BtnAdd.Show()
    End Sub

    Private Sub SetOpcionEditar()
        Opcion = 2
        PintaOpcion()
        ListViewNotas.Hide()
        ManejarTextBox(False, False, True)
        ManejarComponentesBuscar(False, True)
        BtnAdd.Text = "Guardar"
        BtnAdd.Show()
    End Sub

    Private Sub SetOpcionEliminar()
        Opcion = 3
        PintaOpcion()
        ListViewNotas.Hide()
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
                CmbAsignaturas.Enabled = False
                CmbAlumnos.Enabled = False
            Else
                TextBox.ReadOnly = False
                CmbAsignaturas.Enabled = True
                CmbAlumnos.Enabled = True
            End If
        Next
        If Limpiable Then
            For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
                TextBox.Clear()
                CmbAsignaturas.SelectedIndex = -1
                CmbAlumnos.SelectedIndex = -1
            Next
        End If
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            If Visible Then
                TextBox.Show()
                CmbAsignaturas.Show()
                CmbAlumnos.Show()
            Else
                TextBox.Hide()
                CmbAsignaturas.Hide()
                CmbAlumnos.Hide()
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
    Private Sub MostrarBotones(Mostrable As Boolean)
        For Each Button As Windows.Forms.Button In Me.Controls.OfType(Of Windows.Forms.Button)
            If (Mostrable) Then
                Button.Show()
            Else
                Button.Hide()
            End If
        Next
    End Sub

    Private Sub ManejarLabel(Visible As Boolean)
        For Each Label As Windows.Forms.Label In Me.Controls.OfType(Of Windows.Forms.Label)
            If Visible Then
                Label.Show()
            Else
                Label.Hide()
            End If
        Next
    End Sub

    Private Sub ListViewNotas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewNotas.SelectedIndexChanged
        If ListViewNotas.SelectedItems.Count > 0 Then
            'Activamos las opciones editar y eliminar del menú
            EditarToolStripMenuItem.Enabled = True
            EliminarToolStripMenuItem.Enabled = True
            Dim Indice As Integer = ListViewNotas.SelectedIndices(0)
            MostrarItemEnTextBox(Indice)
        End If

    End Sub

    Private Sub MostrarItemEnTextBox(indice As Integer)
        Dim item = ListViewNotas.Items(indice)
        CmbAsignaturas.Text = item.SubItems(0).Text
        CmbAlumnos.Text = item.SubItems(1).Text
        TbEv1.Text = item.SubItems(2).Text
        TbEv2.Text = item.SubItems(3).Text
        TbEv3.Text = item.SubItems(4).Text
        TbNotaFinal.Text = item.SubItems(5).Text
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        If ListViewNotas.SelectedItems.Count > 0 Then
            '''<summary>
            '''Al item que seleccionamos se le resta uno para tener el indice del anterior
            '''</summary>
            Dim indice = ListViewNotas.SelectedIndices(0) - 1
            If indice >= 0 Then
                ListViewNotas.Items(indice).EnsureVisible()
                ListViewNotas.Items(indice).Selected = True
            End If
        End If
    End Sub

    Private Sub BtnPrimero_Click(sender As Object, e As EventArgs) Handles BtnPrimero.Click
        ListViewNotas.Items(0).EnsureVisible()
        ListViewNotas.Items(0).Selected = True
    End Sub

    Private Sub BtnFin_Click(sender As Object, e As EventArgs) Handles BtnFin.Click
        ListViewNotas.Items(ListViewNotas.Items.Count - 1).EnsureVisible()
        ListViewNotas.Items(ListViewNotas.Items.Count - 1).Selected = True
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        If ListViewNotas.SelectedItems.Count > 0 Then
            Dim indice = ListViewNotas.SelectedIndices(0) + 1
            If indice <= ListViewNotas.Items.Count - 1 Then
                ListViewNotas.Items(indice).EnsureVisible()
                ListViewNotas.Items(indice).Selected = True
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        If CmbAsignaturas.SelectedIndex < 0 Or CmbAlumnos.SelectedIndex < 0 Then
            MsgBox("El campo asignatura no puede estar vacío")
        Else
            Dim Nota = CrearNota()
            If Opcion = 1 Then
                Insertar(Nota)
            ElseIf Opcion = 2 Then
                modificar(Nota)
            ElseIf Opcion = 3 Then
                Eliminar(Nota)
            End If
        End If
    End Sub

    Private Function CrearNota() As ModuloNota.Nota
        Dim Nota As New ModuloNota.Nota
        Nota.Asignatura = Integer.Parse(CmbAsignaturas.Text)
        Nota.Alumno = Integer.Parse(CmbAlumnos.Text)
        Nota.Evaluacion1 = Double.Parse(TbEv1.Text)
        Nota.Evaluacion2 = Double.Parse(TbEv2.Text)
        Nota.Evaluacion3 = Double.Parse(TbEv3.Text)
        Nota.NotaFinal = Double.Parse(TbNotaFinal.Text)

        Return Nota
    End Function

    Private Sub Insertar(Nota As ModuloNota.Nota)
        NotaADO.Insertar(Nota, ListViewNotas)
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            TextBox.Clear()
        Next
        CambiarAListado()
        ListViewNotas.Items(ListViewNotas.Items.Count - 1).EnsureVisible()
        ListViewNotas.Items(ListViewNotas.Items.Count - 1).Selected = True
    End Sub

    Private Sub modificar(Nota As ModuloNota.Nota)
        Dim Indice = ListViewNotas.SelectedIndices(0)
        NotaADO.Modificar(Nota, ListViewNotas)
        ListViewNotas.Items(Indice).EnsureVisible()
        ListViewNotas.Items(Indice).Selected = True

        MsgBox("Nota modificado correctamente", MsgBoxStyle.OkOnly, "Aviso")
    End Sub

    Private Sub Eliminar(Nota As ModuloNota.Nota)
        Dim Result As MsgBoxResult = MsgBox("¿Desea eliminar la nota? Esta accion no se puede deshacer", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Confirmar")

        If Result = MsgBoxResult.Ok Then
            NotaADO.Eliminar(Nota, ListViewNotas)
            MsgBox("Nota eliminada correctamente", MsgBoxStyle.OkOnly, "Aviso")
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
            For i As Integer = 0 To (ListViewNotas.Items.Count - 1)
                Dim Item As ListViewItem = ListViewNotas.Items(i)
                If IdBuscado.Equals(Item.SubItems(0).Text) Then
                    ListViewNotas.Items(i).EnsureVisible()
                    ListViewNotas.Items(i).Selected = True
                    MostrarItemEnTextBox(i)
                    i = ListViewNotas.Items.Count
                    IdEncontrado = True
                End If
            Next
            If Not IdEncontrado Then
                MessageBox.Show("No se encontro el Id Buscado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub MenúToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenúToolStripMenuItem.Click
        Dim Result As MsgBoxResult = MsgBox("¿Desea volver al menú principal?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Confirmar")

        If Result = MsgBoxResult.Ok Then
            Me.Hide()
            Menu.Show()
        End If
    End Sub

    Private Function CalcularMedia() As Double
        Dim Media = (Integer.Parse(TbEv1.Text) + Integer.Parse(TbEv2.Text) + Integer.Parse(TbEv3.Text)) / 3
        Return Media
    End Function

    Private Function ComprobarTextBoxVacio(TextBox As Windows.Forms.TextBox) As Boolean
        Dim Vacio As Boolean = True
        If Not String.IsNullOrEmpty(TextBox.Text) Then
            Vacio = False
        End If
        Return Vacio
    End Function
End Class