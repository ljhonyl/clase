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
    Private Sub RedondearBoton(boton As Button)
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, boton.Width, boton.Height)
        boton.Region = New Region(path)
        boton.FlatStyle = FlatStyle.Flat
        boton.FlatAppearance.BorderSize = 0
        boton.BackColor = Color.FromArgb(173, 216, 230)
        boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(135, 206, 250)
    End Sub
End Class
