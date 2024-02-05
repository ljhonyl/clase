Imports System.Data.SQLite

Module ProfesorADO
    Private Url As String = "C:Users\diurno\Clase.db"
    Private AdaptadorDatos As SQLiteDataAdapter
    Private DatosConjunto As DataSet
    Private Fila As DataRow

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
        Dim Query As String = "Select * From Profesores"
        Dim Conexion = ConectarBD()
        AdaptadorDatos = New SQLiteDataAdapter(Query, Conexion)
        DatosConjunto = New DataSet
        AdaptadorDatos.Fill(DatosConjunto, "Profesores")
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

    Sub Insertar(Profesor As Profesor, ListView As Windows.Forms.ListView)
        Dim Query As String = "INSERT INTO Profesores (Nombre, Apellidos, Departamento) VALUES (@Nom, @Ape, @Dep);"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.InsertCommand = Comando

        Comando.Parameters.AddWithValue("@Nom", Profesor.Nombre)
        Comando.Parameters.AddWithValue("@Ape", Profesor.Apellidos)
        Comando.Parameters.AddWithValue("@Dep", Profesor.Departamento)

        Fila = DatosConjunto.Tables(0).NewRow
        Fila.Item(1) = Profesor.Nombre
        Fila.Item(2) = Profesor.Apellidos
        Fila.Item(3) = Profesor.Departamento
        DatosConjunto.Tables(0).Rows.Add(Fila)

        Comando.ExecuteNonQuery()

        ActualizarListado(ListView)

    End Sub

    Public Sub Eliminar(Id As Integer, Listview As Windows.Forms.ListView)
        Dim Query As String = "DELETE FROM Profesores WHERE Id=@Id;"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.DeleteCommand = Comando

        Comando.Parameters.AddWithValue("@Id", Id)
        DatosConjunto.Tables(0).Rows(0).Delete()

        Comando.ExecuteNonQuery()
        ActualizarListado(Listview)
    End Sub

    Sub Modificar(Id As Integer, Profesor As ModuloProfesor.Profesor, ListView As Windows.Forms.ListView)
        Dim Query As String = "UPDATE Profesores SET Nombre=@Nom, Apellidos=@Ape, Departamento=@Dep WHERE Id=@Id;"
        Dim Comando = New SQLiteCommand(Query, ConectarBD)
        AdaptadorDatos.UpdateCommand = Comando


        Comando.Parameters.AddWithValue("@Nom", Profesor.Nombre)
        Comando.Parameters.AddWithValue("@Ape", Profesor.Apellidos)
        Comando.Parameters.AddWithValue("@Dep", Profesor.Departamento)
        Comando.Parameters.AddWithValue("@Id", Id)
        DatosConjunto.Tables(0).Rows(0).BeginEdit()
        DatosConjunto.Tables(0).Rows(0).Item(1) = Profesor.Nombre
        DatosConjunto.Tables(0).Rows(0).Item(2) = Profesor.Apellidos
        DatosConjunto.Tables(0).Rows(0).Item(3) = Profesor.Departamento
        DatosConjunto.Tables(0).Rows(0).EndEdit()

        Comando.ExecuteNonQuery()

        ActualizarListado(ListView)
    End Sub
End Module
