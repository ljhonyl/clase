Imports System.Data.SQLite

Module ClaseBBDD
    Dim Url As String = "C:Users\diurno\Clase.db"
    Public AdaptadorDatosAlum As SQLiteDataAdapter
    Public DatosConjuntosAlum As DataSet
    Public fila As DataRow

    'Sub devolver1()
    'Dim Query As String = "Select Nombre from Alumnos where Id=1"
    'Conn.Open()
    'Dim comando As New SQLiteCommand(Query, Conn)
    'Dim lector As SQLiteDataReader = comando.ExecuteReader
    'MsgBox(lector("Nombre").ToString)
    'Conn.Close()
    'End Sub

    Private Function ConectarBD() As SQLiteConnection
        Dim Conn As New SQLiteConnection("Data Source=Clase.db;Version=3")
        Try
            Conn.Open()
            MsgBox("Conectado")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Conn
    End Function

    Private Sub RellenarDatosConjuntoAlumnos()
        Dim Query As String = "Select * From Alumnos"
        Dim Conexion = ConectarBD()
        AdaptadorDatosAlum = New SQLiteDataAdapter(Query, Conexion)
        DatosConjuntosAlum = New DataSet
        AdaptadorDatosAlum.Fill(DatosConjuntosAlum, "Alumnos")
        Conexion.Close()
    End Sub

    Sub ActualizarListado()
        RellenarDatosConjuntoAlumnos()
        Dim ElementoList As ListViewItem
        GestionAlumnos.ListViewAlumnos.Items.Clear()

        For pos As Integer = 0 To DatosConjuntosAlum.Tables(0).Rows.Count - 1
            ElementoList = GestionAlumnos.ListViewAlumnos.Items.Add(DatosConjuntosAlum.Tables(0).Rows(pos).Item(0))

            ElementoList.SubItems.Add(DatosConjuntosAlum.Tables(0).Rows(pos).Item(1))
            ElementoList.SubItems.Add(DatosConjuntosAlum.Tables(0).Rows(pos).Item(2))
            ElementoList.SubItems.Add(DatosConjuntosAlum.Tables(0).Rows(pos).Item(3))
            ElementoList.SubItems.Add(DatosConjuntosAlum.Tables(0).Rows(pos).Item(4))
            ElementoList.SubItems.Add(DatosConjuntosAlum.Tables(0).Rows(pos).Item(5))
            ElementoList.SubItems.Add(DatosConjuntosAlum.Tables(0).Rows(pos).Item(6))
            ElementoList.SubItems.Add(DatosConjuntosAlum.Tables(0).Rows(pos).Item(7))
            ElementoList.SubItems.Add(DatosConjuntosAlum.Tables(0).Rows(pos).Item(8))
        Next
    End Sub

    Sub Insertar(Alumno As Alumno)

    End Sub
End Module