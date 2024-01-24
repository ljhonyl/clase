Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class GestionAlumnos

    Private Opcion As Integer
    Private Sub GestionAlumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            TextBox.ReadOnly = True
        Next
        EditarToolStripMenuItem.Enabled = False
        BtnAdd.Hide()
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
        ClaseBBDD.ActualizarListado(ListViewAlumnos)
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
        Dim i As Integer = 0
        If ListViewAlumnos.SelectedItems.Count > 0 Then

            EditarToolStripMenuItem.Enabled = True

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
                ElseIf Opcion = 2 Then
                    MsgBox("Editaste el alumno")
                    CambiarAListado()
                ElseIf Opcion = 3 Then
                    Dim id As Integer = TbId.Text
                    ClaseBBDD.Eliminar(id, ListViewAlumnos)
                End If

            Else
                MsgBox("Ocurrio un error con la fecha intentelo con este formato yyyy-mm-dd")
            End If
        End If
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        If e.ClickedItem.Text = "Listado" Then
            Opcion = 0
            For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
                TextBox.ReadOnly = True
            Next
            For Each Button As Windows.Forms.Button In Me.Controls.OfType(Of Windows.Forms.Button)
                Button.Show()
            Next
            BtnAdd.Hide()
            ListViewAlumnos.Enabled = True
        ElseIf e.ClickedItem.Text = "Insertar" Then
            Opcion = 1
            For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
                TextBox.Clear()
                TextBox.ReadOnly = False
            Next
            TbId.ReadOnly = True

            For Each Button As Windows.Forms.Button In Me.Controls.OfType(Of Windows.Forms.Button)
                Button.Hide()
            Next
            BtnAdd.Text = "Añadir alumno"
            BtnAdd.Show()
            ListViewAlumnos.Enabled = False
        ElseIf e.ClickedItem.Text = "Editar" Then
            Opcion = 2
            For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
                TextBox.ReadOnly = False
            Next
            TbId.ReadOnly = True
            For Each Button As Windows.Forms.Button In Me.Controls.OfType(Of Windows.Forms.Button)
                Button.Hide()
            Next
            BtnAdd.Text = "Guardar"
            BtnAdd.Show()
            ListViewAlumnos.Enabled = False
        ElseIf e.ClickedItem.Text = "Eliminar" Then
            Opcion = 3
            For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
                TextBox.ReadOnly = True
            Next
            For Each Button As Windows.Forms.Button In Me.Controls.OfType(Of Windows.Forms.Button)
                Button.Hide()
            Next
            BtnAdd.Text = "Eliminar alumno"
            BtnAdd.Show()
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

    Private Sub GestionAlumnos_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        Application.Exit()
    End Sub

End Class