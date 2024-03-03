Imports System.Data.SQLite

Module AlumnoADO
    Dim Url As String = "C:Users\diurno\Clase.db"
    Public AdaptadorDatos As SQLiteDataAdapter
    Public DatosConjunto As DataSet
    Public fila As DataRow

    Private Function ConectarBD() As SQLiteConnection
        Dim Conn As New SQLiteConnection("Provider=SQLite;Data Source=Clase.db;Version=3")
        Try
            Conn.Open()
        Catch ex As Exception
            MsgBox("No se ha podido establecer la conexion con la base de datos")
        End Try
        Return Conn
    End Function

    Public Sub RellenarDatosConjunto()
        Dim Query As String = "Select * From Alumnos"
        Dim Conexion = ConectarBD()
        AdaptadorDatos = New SQLiteDataAdapter(Query, Conexion)
        DatosConjunto = New DataSet
        AdaptadorDatos.Fill(DatosConjunto, "Alumnos")
        'ConfigurarAdaptador()
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


                For i As Integer = 1 To 8
                    Dim valor As String = fila.Item(i).ToString()
                    If IsDate(valor) Then
                        Dim fecha As Date = Convert.ToDateTime(valor)
                        valor = fecha.ToString("dd/MM/yyyy")
                    End If
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

    Sub Insertar(Alumno As Alumno, ListView As Windows.Forms.ListView)
        Dim Query As String = "insert into Alumnos (Nombre, Apellidos, Direccion, Localidad,Movil,Email,FechaNacimiento,Nacionalidad) values (@Nom, @Ape, @Dir, @Loc, @Mov, @Ema, @Fec, @Nac);"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.InsertCommand = Comando
        Comando.Parameters.AddWithValue("@Nom", Alumno.Nombre)
        Comando.Parameters.AddWithValue("@Ape", Alumno.Apellidos)
        Comando.Parameters.AddWithValue("@Dir", Alumno.Direccion)
        Comando.Parameters.AddWithValue("@Loc", Alumno.Localidad)
        Comando.Parameters.AddWithValue("@Mov", Alumno.Movil)
        Comando.Parameters.AddWithValue("@Ema", Alumno.Email)
        Comando.Parameters.AddWithValue("@Fec", Alumno.FechaNacimiento)
        Comando.Parameters.AddWithValue("@Nac", Alumno.Nacionalidad)

        fila = DatosConjunto.Tables(0).NewRow
        fila.Item(1) = Alumno.Nombre
        fila.Item(2) = Alumno.Apellidos
        fila.Item(3) = Alumno.Direccion
        fila.Item(4) = Alumno.Localidad
        fila.Item(5) = Alumno.Movil
        fila.Item(6) = Alumno.Email
        fila.Item(7) = Alumno.FechaNacimiento
        fila.Item(8) = Alumno.Nacionalidad
        DatosConjunto.Tables(0).Rows.Add(fila)

        ActualizarBD()
        ActualizarListado(ListView)
    End Sub

    Public Sub Eliminar(Id As Integer, Listview As Windows.Forms.ListView)
        Dim Query As String = "delete from Alumnos where id=@id;"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.DeleteCommand = Comando
        Comando.Parameters.AddWithValue("@id", Id)

        For Each fila As DataRow In DatosConjunto.Tables("Alumnos").Rows
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

    Sub Modificar(Id As Integer, Alumno As ModuloAlumno.Alumno, ListView As Windows.Forms.ListView)
        Dim Query As String = "update Alumnos set Nombre=@Nom, Apellidos=@Ape, Direccion=@Dir,  Localidad=@Loc, Movil=@Mov, Email=@Ema, FechaNacimiento=@Fec, Nacionalidad=@Nac where Id=@Id;"
        Dim Comando = New SQLiteCommand(Query, ConectarBD)
        AdaptadorDatos.UpdateCommand = Comando
        Comando.Parameters.AddWithValue("@Nom", Alumno.Nombre)
        Comando.Parameters.AddWithValue("@Ape", Alumno.Apellidos)
        Comando.Parameters.AddWithValue("@Dir", Alumno.Direccion)
        Comando.Parameters.AddWithValue("@Loc", Alumno.Localidad)
        Comando.Parameters.AddWithValue("@Mov", Alumno.Movil)
        Comando.Parameters.AddWithValue("@Ema", Alumno.Email)
        Comando.Parameters.AddWithValue("@Fec", Alumno.FechaNacimiento)
        Comando.Parameters.AddWithValue("@Nac", Alumno.Nacionalidad)
        Comando.Parameters.AddWithValue("@Id", Id)

        For Each fila As DataRow In DatosConjunto.Tables("Alumnos").Rows
            ' Verificar si la fila no está marcada como eliminada y si coincide con el Id del alumno que deseas editar
            If fila.RowState <> DataRowState.Deleted Then
                If fila("Id").ToString() = Id Then
                    ' Actualizar los valores de la fila con los nuevos datos del alumno
                    fila("Nombre") = Alumno.Nombre
                    fila("Apellidos") = Alumno.Apellidos
                    fila("Direccion") = Alumno.Direccion
                    fila("Localidad") = Alumno.Localidad
                    fila("Movil") = Alumno.Movil
                    fila("Email") = Alumno.Email
                    fila("FechaNacimiento") = Alumno.FechaNacimiento
                    fila("Nacionalidad") = Alumno.Nacionalidad

                    ' Salir del bucle una vez que se ha encontrado y editado la fila
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
                    AdaptadorDatos.Update(DatosCambios, "Alumnos")
                    DatosConjunto.AcceptChanges()
                    RellenarDatosConjunto()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR FATAL, CAMBIOS NO GUARDADOS")
        End Try
    End Sub

End Module