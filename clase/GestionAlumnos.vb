Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class GestionAlumnos

    Private Opcion As Integer
    Private Sub GestionAlumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        SetOpcionListado()
        EditarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = False
        BtnAdd.Hide()
        ListViewAlumnos.View = View.Details
        ListViewAlumnos.Columns.Add("ID", 50, HorizontalAlignment.Center)
        ListViewAlumnos.Columns.Add("Nombre", 130, HorizontalAlignment.Center)
        ListViewAlumnos.Columns.Add("Apellidos", 220, HorizontalAlignment.Center)
        ListViewAlumnos.Columns.Add("Dirección", 220, HorizontalAlignment.Center)
        ListViewAlumnos.Columns.Add("Locaidad", 120)
        ListViewAlumnos.Columns.Add("Movil", 100)
        ListViewAlumnos.Columns.Add("Email", 220)
        ListViewAlumnos.Columns.Add("Fecha Nacimiento", 130)
        ListViewAlumnos.Columns.Add("Nacionalidad", 130)
        ClaseBBDD.ActualizarListado(ListViewAlumnos)
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        If ListViewAlumnos.SelectedItems.Count > 0 Then
            Dim indice = ListViewAlumnos.SelectedIndices(0) - 1
            If indice >= 0 Then
                ListViewAlumnos.Items(indice).EnsureVisible()
                ListViewAlumnos.Items(indice).Selected = True
            End If
        End If
    End Sub

    Private Sub ListViewAlumnos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewAlumnos.SelectedIndexChanged
        If ListViewAlumnos.SelectedItems.Count > 0 Then
            'Activamos las opciones editar y eliminar del menú
            EditarToolStripMenuItem.Enabled = True
            EliminarToolStripMenuItem.Enabled = True
            Dim Indice As Integer = ListViewAlumnos.SelectedIndices(0)
            MostrarItemEnTextBox(Indice)
        End If

    End Sub

    Private Sub BtnPrimero_Click(sender As Object, e As EventArgs) Handles BtnPrimero.Click
        ListViewAlumnos.Items(0).EnsureVisible()
        ListViewAlumnos.Items(0).Selected = True
    End Sub

    Private Sub BtnFin_Click(sender As Object, e As EventArgs) Handles BtnFin.Click
        ListViewAlumnos.Items(ListViewAlumnos.Items.Count - 1).EnsureVisible()
        ListViewAlumnos.Items(ListViewAlumnos.Items.Count - 1).Selected = True
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        If ListViewAlumnos.SelectedItems.Count > 0 Then
            Dim indice = ListViewAlumnos.SelectedIndices(0) + 1
            If indice <= ListViewAlumnos.Items.Count - 1 Then
                ListViewAlumnos.Items(indice).EnsureVisible()
                ListViewAlumnos.Items(indice).Selected = True
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        If String.IsNullOrEmpty(TbNombre.Text) Or String.IsNullOrEmpty(TbApellido.Text) Then
            MsgBox("Los campos nombre y apellidos no pueden estar vacíos")
        Else
            Dim Fecha As DateTime
            If DateTime.TryParseExact(TbFechaNacimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, Fecha) Then
                Dim FechaFormateada As String = Fecha.ToString("yyyy-MM-dd")

                Dim Alumno As New ModuloAlumno.Alumno
                Alumno.Nombre = TbNombre.Text
                Alumno.Apellidos = TbApellido.Text
                Alumno.Direccion = TbDireccion.Text
                Alumno.Localidad = TbLocalidad.Text
                Alumno.Movil = TbMovil.Text
                Alumno.Email = TbEmail.Text
                Alumno.FechaNacimiento = FechaFormateada
                Alumno.Nacionalidad = TbNacionalidad.Text

                If Opcion = 1 Then
                    ClaseBBDD.Insertar(Alumno, ListViewAlumnos)
                    For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
                        TextBox.Clear()
                    Next
                    CambiarAListado()
                    ListViewAlumnos.Items(ListViewAlumnos.Items.Count - 1).EnsureVisible()
                    ListViewAlumnos.Items(ListViewAlumnos.Items.Count - 1).Selected = True
                ElseIf Opcion = 2 Then
                    Dim id As Integer = Integer.Parse(TbId.Text)
                    ClaseBBDD.Modificar(id, Alumno, ListViewAlumnos)
                    CambiarAListado()
                ElseIf Opcion = 3 Then
                    Dim Id As Integer = Integer.Parse(TbId.Text)
                    Dim Result As MsgBoxResult = MsgBox("¿Desea eliminar al alumno? Esta accion no se puede deshacer", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Confirmar")

                    If Result = MsgBoxResult.Ok Then
                        ClaseBBDD.Eliminar(Id, ListViewAlumnos)
                        MsgBox("Alumno eliminado correctamente", MsgBoxStyle.OkOnly, "Aviso")
                        CambiarAListado()
                    End If

                End If

            Else
                MsgBox("Ocurrio un error con la fecha intentelo con este formato 01/01/2000")
            End If
        End If
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

    Private Sub CambiarAListado()
        For Each item As ToolStripItem In MenuStrip1.Items
            If item.Text = "Listado" Then
                item.PerformClick()
                Exit For
            End If
        Next
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

    Private Sub SetOpcionListado()
        Opcion = 0
        PintaOpcion()
        ManejarLabel(False)
        LblTitulo.Show()
        ManejarTextBox(True, False, False)
        TbBuscarId.Show()
        TbBuscarId.ReadOnly = False
        MostrarBotones(True)
        BtnAdd.Hide()
        ListViewAlumnos.Show()
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

    Private Sub ManejarLabel(Visible As Boolean)
        For Each Label As Windows.Forms.Label In Me.Controls.OfType(Of Windows.Forms.Label)
            If Visible Then
                Label.Show()
            Else
                Label.Hide()
            End If
        Next
    End Sub

    Private Sub SetOpcionInsertar()
        Opcion = 1
        PintaOpcion()
        ManejarLabel(True)
        LblId.Hide()
        LblImagen1.Image = My.Resources.agregar
        ManejarTextBox(False, True, True)
        TbId.Hide()
        TbBuscarId.Hide()
        MostrarBotones(False)
        BtnAdd.Text = "Añadir"
        BtnAdd.Show()
        EditarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = False
        ListViewAlumnos.Hide()
    End Sub

    Private Sub SetOpcionEditar()
        Opcion = 2
        PintaOpcion()
        ManejarLabel(True)
        LblDatos.Hide()
        LblImagen1.Image = My.Resources.editar
        ManejarTextBox(False, False, True)
        TbId.ReadOnly = True
        MostrarBotones(True)
        BtnAdd.Text = "Guardar"
        ListViewAlumnos.Hide()
    End Sub

    Private Sub SetOpcionEliminar()
        Opcion = 3
        PintaOpcion()
        ManejarLabel(True)
        LblDatos.Hide()
        LblImagen1.Image = My.Resources.eliminar
        ManejarTextBox(True, False, True)
        TbBuscarId.ReadOnly = False
        MostrarBotones(True)
        BtnAdd.Text = "Eliminar"
        ListViewAlumnos.Hide()
    End Sub



    Private Sub MostrarItemEnTextBox(indice As Integer)
        Dim item = ListViewAlumnos.Items(indice)
        TbId.Text = item.SubItems(0).Text
        TbNombre.Text = item.SubItems(1).Text
        TbApellido.Text = item.SubItems(2).Text
        TbDireccion.Text = item.SubItems(3).Text
        TbLocalidad.Text = item.SubItems(4).Text
        TbMovil.Text = item.SubItems(5).Text
        TbEmail.Text = item.SubItems(6).Text
        TbFechaNacimiento.Text = item.SubItems(7).Text
        TbNacionalidad.Text = item.SubItems(8).Text
    End Sub

    Private Sub GestionAlumnos_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        Application.Exit()
    End Sub

    Private Sub ListadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoToolStripMenuItem.Click
        SetOpcionListado()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If Not String.IsNullOrEmpty(TbBuscarId.Text) Then
            Dim IdBuscado = TbBuscarId.Text
            Dim IdEncontrado As Boolean = False
            For i As Integer = 0 To (ListViewAlumnos.Items.Count - 1)
                Dim Item As ListViewItem = ListViewAlumnos.Items(i)
                If IdBuscado.Equals(Item.SubItems(0).Text) Then
                    ListViewAlumnos.Items(i).EnsureVisible()
                    ListViewAlumnos.Items(i).Selected = True
                    MostrarItemEnTextBox(i)
                    i = ListViewAlumnos.Items.Count
                    IdEncontrado = True
                End If
            Next
            If Not IdEncontrado Then
                MessageBox.Show("No se encontro el Id Buscado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Class