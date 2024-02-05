Imports System.Drawing.Drawing2D

Public Class Menu
    Private Sub BtnAlumnos_Click(sender As Object, e As EventArgs) Handles BtnAlumnos.Click
        Me.Hide()
        GestionAlumnos.Show()
    End Sub

    Private Sub BtnPruebas_Click(sender As Object, e As EventArgs) Handles BtnPruebas.Click
        Me.Hide()
        GestionAsignaturas.Show()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Application.Exit()
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Button As Windows.Forms.Button In Me.Controls.OfType(Of Windows.Forms.Button)
            RedondearBoton(Button)
        Next
    End Sub

    ''' <summary>
    ''' Método que crea una elipse de acuerdo a las dimensiones del botón
    ''' </summary>
    ''' <param name="Boton">Botón que establece el tamaño de la elipse</param>
    Private Sub RedondearBoton(Boton As Button)
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, Boton.Width, Boton.Height)
        Boton.Region = New Region(path)
        Boton.FlatStyle = FlatStyle.Flat
        Boton.FlatAppearance.BorderSize = 0
        Boton.BackColor = Color.FromArgb(173, 216, 230) ' Color de fondo normal (azul claro)
        Boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(135, 206, 250)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        GestionProfesores.Show()
    End Sub
End Class
