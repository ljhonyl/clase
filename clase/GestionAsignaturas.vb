Imports System.ComponentModel

Public Class GestionAsignaturas
    Private Sub GestionAsignaturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewAsignaturas.View = View.Details
        ListViewAsignaturas.Columns.Add("ID", 50, HorizontalAlignment.Center)
        ListViewAsignaturas.Columns.Add("Nombre", 130, HorizontalAlignment.Center)
        ListViewAsignaturas.Columns.Add("Aula", 220, HorizontalAlignment.Center)
        ListViewAsignaturas.Columns.Add("Profesor", 220, HorizontalAlignment.Center)

        AsignaturaADO.ActualizarListado(ListViewAsignaturas)
    End Sub

    Private Sub GestionAsignaturas_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        Application.Exit()
    End Sub
End Class