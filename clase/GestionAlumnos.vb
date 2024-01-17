Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class GestionAlumnos
    Private Sub GestionAlumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            TextBox.ReadOnly = True
        Next
        ListViewAlumnos.View = View.Details
        ListViewAlumnos.Columns.Add("ID", 50)
        ListViewAlumnos.Columns.Add("Nombre", 120)
        ListViewAlumnos.Columns.Add("Apellidos", 120)
        ListViewAlumnos.Columns.Add("Dirección", 120)
        ListViewAlumnos.Columns.Add("Locaidad", 120)
        ListViewAlumnos.Columns.Add("Movil", 100)
        ListViewAlumnos.Columns.Add("Email", 80)
        ListViewAlumnos.Columns.Add("Fecha Nacimiento", 120)
        ListViewAlumnos.Columns.Add("Nacionalidad", 120)
        ClaseBBDD.ActualizarListado()
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        Dim indice = Integer.Parse(TbId.Text) - 2
        If indice >= 0 Then
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
        End If
    End Sub

    Private Sub ListViewAlumnos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewAlumnos.SelectedIndexChanged
        If ListViewAlumnos.SelectedItems.Count > 0 Then
            ' Se obtiene el índice de la película seleccionada
            Dim indiceSeleccionado As Integer = ListViewAlumnos.SelectedIndices(0)
            Dim itemSeleccionado = ListViewAlumnos.Items.Item(indiceSeleccionado)
            TbId.Text = itemSeleccionado.SubItems(0).Text
            TbNombre.Text = itemSeleccionado.SubItems(1).Text
            TbApellido.Text = itemSeleccionado.SubItems(2).Text
            TbDireccion.Text = itemSeleccionado.SubItems(3).Text
            TbLocalidad.Text = itemSeleccionado.SubItems(4).Text
            TbMovil.Text = itemSeleccionado.SubItems(5).Text
            TbEmail.Text = itemSeleccionado.SubItems(6).Text
            TbFechaNacimiento.Text = itemSeleccionado.SubItems(7).Text
            TbNacionalidad.Text = itemSeleccionado.SubItems(8).Text
        End If

    End Sub

    Private Sub BtnPrimero_Click(sender As Object, e As EventArgs) Handles BtnPrimero.Click
        Dim item = ListViewAlumnos.Items(0)
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

    Private Sub BtnFin_Click(sender As Object, e As EventArgs) Handles BtnFin.Click
        Dim item = ListViewAlumnos.Items(ListViewAlumnos.Items.Count - 1)
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

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        Dim indice = Integer.Parse(TbId.Text)
        If indice <= ListViewAlumnos.Items.Count - 1 Then
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
        End If
    End Sub

    Private Sub InsertarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertarToolStripMenuItem.Click
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            TextBox.Clear()
            TextBox.ReadOnly = False
        Next
        TbId.ReadOnly = True
    End Sub
End Class