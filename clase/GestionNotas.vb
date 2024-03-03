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

        NotaADO.RellenarDatosConjunto()
        NotaADO.ActualizarListado(ListViewNotas)
        NotaADO.CargarComboBox(CmbAsignaturas, "Asignaturas")
        NotaADO.CargarComboBox(CmbAlumnos, "Alumnos")

    End Sub

    Private Sub GestionNotas_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        NotaADO.ActualizarBD()
        Application.Exit()
    End Sub

    ''' <summary>
    ''' Manejo de menú
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    '----------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Comportamiento de las distintas opciones de menú
    ''' </summary>
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
    '----------------------------------------------------------------------------------------------

    ''' <summary>
    ''' Colorea la opción de menú en la que nos encontramos
    ''' </summary>
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

    ''' <summary>
    ''' Manejo de los textBox de acuerdo a las necesiades de cada opción de menú
    ''' </summary>
    ''' <param name="SoloLectura">Establece si los textBox son de solo lectura</param>
    ''' <param name="Limpiable">Establece si se vacia el texto de los textBox</param>
    ''' <param name="Visible">Establece si los textBox son visibles</param>
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

    ''' <summary>
    ''' Maneja los componentes que prmiten la busqueda
    ''' </summary>
    ''' <param name="SoloLectura"></param>
    ''' <param name="Habilitado"></param>
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

    ''' <summary>
    ''' Maneja los botones de acuerdo a las necesidades del menú
    ''' </summary>
    ''' <param name="Mostrable">Establece si los botones se muestran o no</param>
    Private Sub MostrarBotones(Mostrable As Boolean)
        For Each Button As Windows.Forms.Button In Me.Controls.OfType(Of Windows.Forms.Button)
            If (Mostrable) Then
                Button.Show()
            Else
                Button.Hide()
            End If
        Next
    End Sub

    ''' <summary>
    ''' Maneja los laabel de acuerdo a las necesidades de la opción de menú
    ''' </summary>
    ''' <param name="Visible">Controla si los label se ven o no</param>
    Private Sub ManejarLabel(Visible As Boolean)
        For Each Label As Windows.Forms.Label In Me.Controls.OfType(Of Windows.Forms.Label)
            If Visible Then
                Label.Show()
            Else
                Label.Hide()
            End If
        Next
    End Sub

    ''' <summary>
    ''' Controla la selección de los item del listView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ListViewNotas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewNotas.SelectedIndexChanged
        If ListViewNotas.SelectedItems.Count > 0 Then
            'Activamos las opciones editar y eliminar del menú
            EditarToolStripMenuItem.Enabled = True
            EliminarToolStripMenuItem.Enabled = True
            Dim Indice As Integer = ListViewNotas.SelectedIndices(0)
            MostrarItemEnTextBox(Indice)
        End If

    End Sub

    ''' <summary>
    ''' Coje el item seleccionado y lo muestra en los textBox 
    ''' </summary>
    ''' <param name="indice"></param>
    Private Sub MostrarItemEnTextBox(indice As Integer)
        Dim item = ListViewNotas.Items(indice)
        CmbAsignaturas.Text = item.SubItems(0).Text
        CmbAlumnos.Text = item.SubItems(1).Text
        TbEv1.Text = item.SubItems(2).Text
        TbEv2.Text = item.SubItems(3).Text
        TbEv3.Text = item.SubItems(4).Text
        TbNotaFinal.Text = item.SubItems(5).Text
    End Sub
    '----------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Navegación en el listView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
    '----------------------------------------------------------------------------------------------

    ''' <summary>
    ''' Controla si se inserta, modifica y elimina
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        If CmbAsignaturas.SelectedIndex < 0 Or CmbAlumnos.SelectedIndex < 0 Then
            MsgBox("El campo asignatura no puede estar vacío")
        Else
            Try
                If Opcion = 3 Then
                    Eliminar(CmbAsignaturas.Text.ToString, CmbAlumnos.Text.ToString)
                Else
                    Dim Nota = CrearNota()
                    If Opcion = 1 Then
                        Insertar(Nota)
                    ElseIf Opcion = 2 Then
                        modificar(Nota)
                    End If
                End If
            Catch ex As Exception
                MsgBox("Formato de notas incorrecto")
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Crea nuestro modelo de negocio
    ''' </summary>
    ''' <returns>Devuelve la nota necesaria para los métodos de editar, insertar y eliminar</returns>
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

    ''' <summary>
    ''' Llama a la base de datos para insertar
    ''' </summary>
    ''' <param name="Nota"></param>
    Private Sub Insertar(Nota As ModuloNota.Nota)
        NotaADO.Insertar(Nota, ListViewNotas)
        For Each TextBox As Windows.Forms.TextBox In Me.Controls.OfType(Of Windows.Forms.TextBox)
            TextBox.Clear()
        Next
        CambiarAListado()
        ListViewNotas.Items(ListViewNotas.Items.Count - 1).EnsureVisible()
        ListViewNotas.Items(ListViewNotas.Items.Count - 1).Selected = True
    End Sub

    ''' <summary>
    ''' Llama a la base de datos para modificar
    ''' </summary>
    ''' <param name="Nota"></param>
    Private Sub modificar(Nota As ModuloNota.Nota)
        Dim Indice = ListViewNotas.SelectedIndices(0)
        NotaADO.Modificar(Nota, ListViewNotas)
        ListViewNotas.Items(Indice).EnsureVisible()
        ListViewNotas.Items(Indice).Selected = True

        MsgBox("Nota modificado correctamente", MsgBoxStyle.OkOnly, "Aviso")
    End Sub

    ''' <summary>
    ''' Llama a la base de datos para eliminar
    ''' </summary>
    ''' <param name="Nota"></param>
    Private Sub Eliminar(Asignatura As Integer, Alumno As Integer)
        Dim Result As MsgBoxResult = MsgBox("¿Desea eliminar la nota? Esta accion no se puede deshacer", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Confirmar")

        If Result = MsgBoxResult.Ok Then
            NotaADO.Eliminar(Asignatura, Alumno, ListViewNotas)
            MsgBox("Nota eliminada correctamente", MsgBoxStyle.OkOnly, "Aviso")
            ManejarTextBox(True, True, True)
        End If
    End Sub

    ''' <summary>
    ''' Simula el clickar en la opción de menú listado
    ''' </summary>
    Private Sub CambiarAListado()
        For Each item As ToolStripItem In MenuStrip1.Items
            If item.Text = "Listado" Then
                item.PerformClick()
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' Botón que maneja la busqueda por alumno
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' Vuelta al menú principal si aceptamos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenúToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenúToolStripMenuItem.Click
        Dim Result As MsgBoxResult = MsgBox("¿Desea volver al menú principal?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Confirmar")

        If Result = MsgBoxResult.Ok Then
            NotaADO.ActualizarBD()
            Me.Hide()
            Menu.Show()
        End If
    End Sub

    ''' <summary>
    ''' Calcula la media
    ''' </summary>
    ''' <param name="Nota">Nota de la que se sacan las tres notas para calcular la media</param>
    ''' <returns>devuelve la media de las tres notas</returns>
    Private Function CalcularMedia(Nota As ModuloNota.Nota) As Double
        Dim Media As Double = -1
        Media = (Nota.Evaluacion1 + Nota.Evaluacion2 + Nota.Evaluacion3) / 3.0
        Return Math.Round(Media, 2)
    End Function

    ''' <summary>
    ''' Comprueba si el textBox está vacío
    ''' </summary>
    ''' <param name="TextBox">Componente a comprobar</param>
    ''' <returns>devuelve true si esta vacío false si no</returns>
    Private Function ComprobarTextBoxVacio(TextBox As Windows.Forms.TextBox) As Boolean
        Dim Vacio As Boolean = True
        If Not String.IsNullOrEmpty(TextBox.Text) Then
            Vacio = False
        End If
        Return Vacio
    End Function
End Class