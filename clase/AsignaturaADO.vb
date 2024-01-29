Imports System.Data.SQLite

Module AsignaturaADO
    Private Url As String = "C:Users\diurno\Clase.db"
    Private AdaptadorDatos As SQLiteDataAdapter
    Private DatosConjunto As DataSet
    Private fila As DataRow

    Private Function ConectarBD() As SQLiteConnection
        Dim Conn As New SQLiteConnection("Provider=SQLite;Data Source=Clase.db;Version=3")
        Try
            Conn.Open()
        Catch ex As Exception
            MsgBox("No se ha podido establecer la conexion con la base de datos")
        End Try
        Return Conn
    End Function

    Private Sub RellenarDatosConjunto()
        Dim Query As String = "Select * From Asignaturas"
        Dim Conexion = ConectarBD()
        AdaptadorDatos = New SQLiteDataAdapter(Query, Conexion)
        DatosConjunto = New DataSet
        AdaptadorDatos.Fill(DatosConjunto, "Asignaturas")
        Conexion.Close()
    End Sub

    Sub ActualizarListado(ListView As Windows.Forms.ListView)
        RellenarDatosConjunto()
        Dim ElementoList As ListViewItem
        ListView.Items.Clear()

        For pos As Integer = 0 To DatosConjunto.Tables(0).Rows.Count - 1
            ElementoList = ListView.Items.Add(DatosConjunto.Tables(0).Rows(pos).Item(0))
            For i As Integer = 1 To 3
                Dim EsNulo As String = DatosConjunto.Tables(0).Rows(pos).Item(i).ToString()
                If Not String.IsNullOrEmpty(EsNulo) AndAlso Not String.Equals(EsNulo, "null", StringComparison.OrdinalIgnoreCase) Then
                    ElementoList.SubItems.Add(DatosConjunto.Tables(0).Rows(pos).Item(i))
                Else
                    ElementoList.SubItems.Add("")
                End If
            Next
        Next
    End Sub

    Sub Insertar(Asignatura As Asignatura, ListView As Windows.Forms.ListView)
        Dim Query As String = "INSERT INTO Asignaturas (Nombre, Aula, Profesor) values (@Nom, @Aul, @Pro);"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.InsertCommand = Comando

        Comando.Parameters.AddWithValue("@Nom", Asignatura.Nombre)
        Comando.Parameters.AddWithValue("@Aul", Asignatura.Aula)
        Comando.Parameters.AddWithValue("@Pro", Asignatura.Profesor)

        fila = DatosConjunto.Tables(0).NewRow
        fila.Item(1) = Asignatura.Nombre
        fila.Item(2) = Asignatura.Aula
        fila.Item(3) = Asignatura.Profesor
        DatosConjunto.Tables(0).Rows.Add(fila)

        Comando.ExecuteNonQuery()

        ActualizarListado(ListView)

    End Sub

    Public Sub Eliminar(Id As Integer, Listview As Windows.Forms.ListView)
        Dim Query As String = "DELETE FROM Asignaturas WHERE Id=@Id;"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.DeleteCommand = Comando

        Comando.Parameters.AddWithValue("@Id", Id)
        DatosConjunto.Tables(0).Rows(0).Delete()

        Comando.ExecuteNonQuery()
        ActualizarListado(Listview)
    End Sub

    Sub Modificar(Id As Integer, Asignatura As ModuloAsignatura.Asignatura, ListView As Windows.Forms.ListView)
        Dim Query As String = "UPDATE Alumnos SET Nombre=@Nom, Aula=@Aul, Profesor=@Pro) WHERE Id=@Id;"
        Dim Comando = New SQLiteCommand(Query, ConectarBD)
        AdaptadorDatos.UpdateCommand = Comando


        Comando.Parameters.AddWithValue("@Nom", Asignatura.Nombre)
        Comando.Parameters.AddWithValue("@Aul", Asignatura.Aula)
        Comando.Parameters.AddWithValue("@Pro", Asignatura.Profesor)
        Comando.Parameters.AddWithValue("@Id", Id)
        DatosConjunto.Tables(0).Rows(0).BeginEdit()
        DatosConjunto.Tables(0).Rows(0).Item(1) = Asignatura.Nombre
        DatosConjunto.Tables(0).Rows(0).Item(2) = Asignatura.Aula
        DatosConjunto.Tables(0).Rows(0).Item(3) = Asignatura.Profesor
        DatosConjunto.Tables(0).Rows(0).EndEdit()

        Comando.ExecuteNonQuery()

        ActualizarListado(ListView)
    End Sub
End Module
