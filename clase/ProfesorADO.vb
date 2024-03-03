Imports System.Data.SQLite

Module ProfesorADO
    Private Url As String = "C:Users\diurno\Clase.db"
    Private AdaptadorDatos As SQLiteDataAdapter
    Private DatosConjunto As DataSet
    Private Fila As DataRow

    public Function ConectarBD() As SQLiteConnection
        Dim Conn As New SQLiteConnection("Provider=SQLite;Data Source=Clase.db;Version=3")
        Try
            Conn.Open()
        Catch ex As Exception
            MsgBox("No se ha podido establecer la conexion con la base de datos")
        End Try
        Return Conn
    End Function

    Public Sub RellenarDatosConjunto()
        Dim Query As String = "Select * From Profesores"
        Dim Conexion = ConectarBD()
        AdaptadorDatos = New SQLiteDataAdapter(Query, Conexion)
        DatosConjunto = New DataSet
        AdaptadorDatos.Fill(DatosConjunto, "Profesores")
        Conexion.Close()
    End Sub

    Sub ActualizarListado(ListView As Windows.Forms.ListView)
        ' Limpiar los elementos existentes en el ListView
        ListView.Items.Clear()

        ' Recorrer las filas del DataSet y agregarlas al ListView
        For Each fila As DataRow In DatosConjunto.Tables(0).Rows
            ' Verificar si la fila está marcada como eliminada
            If fila.RowState <> DataRowState.Deleted Then
                Dim ElementoList As New ListViewItem(fila.Item(0).ToString()) ' Agregar el primer elemento de la fila (supongo que es el ID)

                ' Agregar los subelementos a la fila del ListView


                For i As Integer = 1 To 3
                    Dim valor As String = fila.Item(i).ToString()
                    If Not String.IsNullOrEmpty(valor) AndAlso Not String.Equals(valor, "null", StringComparison.OrdinalIgnoreCase) Then
                        ElementoList.SubItems.Add(valor)
                    Else
                        ElementoList.SubItems.Add("")
                    End If
                Next

                ' Agregar la fila al ListView
                ListView.Items.Add(ElementoList)
            End If
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
        ActualizarBD()
        ActualizarListado(ListView)
    End Sub

    Public Sub Eliminar(Id As Integer, Listview As Windows.Forms.ListView)
        Dim Query As String = "DELETE FROM Profesores WHERE Id=@Id;"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.DeleteCommand = Comando
        Comando.Parameters.AddWithValue("@Id", Id)

        For Each fila As DataRow In DatosConjunto.Tables("Profesores").Rows
            If fila.RowState <> DataRowState.Deleted Then
                If fila("Id").ToString() = Id Then
                    fila.Delete() ' Eliminar la fila del DataSet
                    Exit For ' Salir del bucle una vez que se ha eliminado la fila
                End If
            End If
        Next
        ActualizarBD()
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

        For Each fila As DataRow In DatosConjunto.Tables("Profesores").Rows
            If fila.RowState <> DataRowState.Deleted Then
                If fila("Id").ToString() = Id Then
                    fila("Nombre") = Profesor.Nombre
                    fila("Apellidos") = Profesor.Apellidos
                    fila("Departamento") = Profesor.Departamento
                    Exit For
                End If
            End If
        Next
        ActualizarBD()
        ActualizarListado(ListView)
    End Sub

    Public Sub ActualizarBD()
        Try
            If DatosConjunto.HasChanges() Then
                Dim DatosCambios As DataSet = DatosConjunto.GetChanges()
                If DatosConjunto.HasErrors() Then
                    DatosConjunto.RejectChanges()
                Else
                    AdaptadorDatos.Update(DatosCambios, "Profesores")
                    DatosConjunto.AcceptChanges()
                    RellenarDatosConjunto()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR FATAL, CAMBIOS NO GUARDADOS")
        End Try
    End Sub
End Module
