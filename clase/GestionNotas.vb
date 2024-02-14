Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class GestionNotas
    'Atributo que ayudará el moverse por las distintas opciones
    Private Opcion = -1
    Private Sub GestionNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewNotas.View = View.Details
        ListViewNotas.Columns.Add("ID Asignatura", 90, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("ID Alumno", 90, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("1ª Evaluación", 95, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("2ª Evaluación", 95, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("3ª Evaluación", 95, HorizontalAlignment.Center)
        ListViewNotas.Columns.Add("Nota Final", 95, HorizontalAlignment.Center)
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
        TbNotaFinal.Enabled = False
        ManejarComponentesBuscar(True, False)
        BtnAdd.Text = "Añadir"
        BtnAdd.Show()
    End Sub

    Private Sub SetOpcionEditar()
        Opcion = 2
        PintaOpcion()
        ListViewNotas.Hide()
        ManejarLabel(True)
        LblNotaFinalInfo.Hide()
        ManejarTextBox(False, False, True)
        TbNotaFinal.Enabled = False
        ManejarComponentesBuscar(False, True)
        BtnAdd.Text = "Guardar"
        BtnAdd.Show()
    End Sub

    Private Sub SetOpcionEliminar()
        Opcion = 3
        PintaOpcion()
        ListViewNotas.Hide()
        ManejarLabel(True)
        LblNotaFinalInfo.Hide()
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
            Try
                Dim Nota = CrearNota()
                If Opcion = 1 Then
                    Insertar(Nota)
                ElseIf Opcion = 2 Then
                    modificar(Nota)
                ElseIf Opcion = 3 Then
                    Eliminar(Nota)
                End If
            Catch ex As Exception
                MsgBox("Formato de notas incorrecto")
            End Try
        End If
    End Sub

    Private Function CrearNota() As ModuloNota.Nota
        Dim Nota As New ModuloNota.Nota
        Nota.Asignatura = Integer.Parse(CmbAsignaturas.Text)
        Nota.Alumno = Integer.Parse(CmbAlumnos.Text)
        Nota.Evaluacion1 = -1
        Nota.Evaluacion2 = -1
        Nota.Evaluacion3 = -1
        Nota.NotaFinal = -1
        If Not ComprobarTextBoxVacio(TbEv1) Then
            Dim valorEv1 As Double
            If Double.TryParse(TbEv1.Text.Replace(",", ".").Replace(".", ","), valorEv1) Then
                Nota.Evaluacion1 = valorEv1
            Else
                MessageBox.Show("Por favor, introduzca un valor válido para la Evaluación 1.")
                Return Nota
            End If
        End If
        If Not ComprobarTextBoxVacio(TbEv2) Then
            Dim valorEv2 As Double
            If Double.TryParse(TbEv2.Text.Replace(",", ".").Replace(".", ","), valorEv2) Then
                Nota.Evaluacion2 = valorEv2
            Else
                MessageBox.Show("Por favor, introduzca un valor válido para la Evaluación 2.")
                Return Nota
            End If
        End If
        If Not ComprobarTextBoxVacio(TbEv3) Then
            Dim valorEv3 As Double
            If Double.TryParse(TbEv3.Text.Replace(",", ".").Replace(".", ","), valorEv3) Then
                Nota.Evaluacion3 = valorEv3
            Else
                MessageBox.Show("Por favor, introduzca un valor válido para la Evaluación 3.")
                Return Nota
            End If
        End If
        If Nota.Evaluacion1 <> -1 And Nota.Evaluacion2 <> -1 And Nota.Evaluacion3 <> -1 Then
            Nota.NotaFinal = CalcularMedia(Nota)
        End If

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
            ManejarTextBox(True, True, True)
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
                If IdBuscado.Equals(Item.SubItems(1).Text) Then
                    ListViewNotas.Items(i).EnsureVisible()
                    ListViewNotas.Items(i).Selected = True
                    MostrarItemEnTextBox(i)
                    i = ListViewNotas.Items.Count
                    IdEncontrado = True
                End If
            Next
            If Not IdEncontrado Then
                MessageBox.Show("No se encontro el Alumno Buscado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Function CalcularMedia(Nota As ModuloNota.Nota) As Double
        Dim Media As Double = -1
        Media = (Nota.Evaluacion1 + Nota.Evaluacion2 + Nota.Evaluacion3) / 3.0
        Return Math.Round(Media, 2)
    End Function

    Private Function ComprobarTextBoxVacio(TextBox As Windows.Forms.TextBox) As Boolean
        Dim Vacio As Boolean = True
        If Not String.IsNullOrEmpty(TextBox.Text) Then
            Vacio = False
        End If
        Return Vacio
    End Function
    Private Sub CmbAsignaturas_TextChanged(sender As Object, e As EventArgs) Handles CmbAsignaturas.TextChanged
        Dim textoBuscado As String = CmbAsignaturas.Text

        ' Buscar la coincidencia en los elementos del ComboBox
        Dim indiceCoincidencia As Integer = CmbAsignaturas.FindStringExact(textoBuscado)

        ' Si se encontró una coincidencia, seleccionar ese elemento
        If indiceCoincidencia <> -1 Then
            CmbAsignaturas.SelectedIndex = indiceCoincidencia
        End If
    End Sub
    Private Sub CmbAlumnos_TextChanged(sender As Object, e As EventArgs) Handles CmbAlumnos.TextChanged
        Dim textoBuscado As String = CmbAlumnos.Text

        ' Buscar la coincidencia en los elementos del ComboBox
        Dim indiceCoincidencia As Integer = CmbAlumnos.FindStringExact(textoBuscado)

        ' Si se encontró una coincidencia, seleccionar ese elemento
        If indiceCoincidencia <> -1 Then
            CmbAlumnos.SelectedIndex = indiceCoincidencia
        End If
    End Sub
End Class