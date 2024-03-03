Imports System.Data.SQLite

Module NotaADO
    'Private Url As String = "C:Users\diurno\Clase.db"
    Private AdaptadorDatos As SQLiteDataAdapter
    Private DatosConjunto As DataSet
    Private fila As DataRow
    Private Asignaturas As List(Of String) = New List(Of String)
    Private Alumnos As List(Of String) = New List(Of String)


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
        Dim Query As String = "Select * From Cursa"
        Dim Conexion = ConectarBD()
        AdaptadorDatos = New SQLiteDataAdapter(Query, Conexion)
        DatosConjunto = New DataSet
        AdaptadorDatos.Fill(DatosConjunto, "Cursa")
        Conexion.Close()
    End Sub

    Private Sub CargarAsignaturas()
        Dim Query As String = "Select Id From Asignaturas"
        Dim Conexion = ConectarBD()
        Dim AdaptadorDatosAux As SQLiteDataAdapter = New SQLiteDataAdapter(Query, Conexion)
        Dim DatosConjuntoAux As DataSet = New DataSet
        AdaptadorDatosAux.Fill(DatosConjuntoAux, "Asignaturas")
        For Each fila As DataRow In DatosConjuntoAux.Tables(0).Rows
            Asignaturas.Add(fila("Id").ToString())
        Next
        Conexion.Close()
    End Sub

    Private Sub CargarAlumnos()
        Dim Query As String = "Select Id From Alumnos"
        Dim Conexion = ConectarBD()
        Dim AdaptadorDatosAux = New SQLiteDataAdapter(Query, Conexion)
        Dim DatosConjuntoAux = New DataSet
        AdaptadorDatosAux.Fill(DatosConjuntoAux, "Alumnos")
        For Each fila As DataRow In DatosConjuntoAux.Tables(0).Rows
            Alumnos.Add(fila("Id").ToString())
        Next
            Conexion.Close()
    End Sub

    Public Sub CargarComboBox(ComboBox As Windows.Forms.ComboBox, Lista As String)
        If Lista.Equals("Asignaturas") Then
            CargarAsignaturas()
            For Each Asignatura In Asignaturas
                ComboBox.Items.Add(Asignatura)
            Next
        ElseIf Lista.Equals("Alumnos") Then
            CargarAlumnos()
            For Each Alumno In Alumnos
                ComboBox.Items.Add(Alumno)
            Next
        End If

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
                For i As Integer = 1 To 5
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

    Sub Insertar(Nota As ModuloNota.Nota, ListView As Windows.Forms.ListView)
        Dim Query As String = "INSERT INTO Cursa (Asignatura, Alumno, Nota1, Nota2, Nota3, NotaFinal) VALUES (@Asig, @Alu, @Ev1, @Ev2, @Ev3, @Fin);"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.InsertCommand = Comando
        ' Agregar parámetros al comando
        Comando.Parameters.AddWithValue("@Asig", Nota.Asignatura)
        Comando.Parameters.AddWithValue("@Alu", Nota.Alumno)
        Comando.Parameters.AddWithValue("@Ev1", If(Nota.Evaluacion1 < 0, DBNull.Value, Nota.Evaluacion1))
        Comando.Parameters.AddWithValue("@Ev2", If(Nota.Evaluacion2 < 0, DBNull.Value, Nota.Evaluacion2))
        Comando.Parameters.AddWithValue("@Ev3", If(Nota.Evaluacion3 < 0, DBNull.Value, Nota.Evaluacion3))
        Comando.Parameters.AddWithValue("@Fin", If(Nota.NotaFinal < 0, DBNull.Value, Nota.NotaFinal))

        fila = DatosConjunto.Tables(0).NewRow
        fila.Item(0) = Nota.Asignatura
        fila.Item(1) = Nota.Alumno
        fila.Item(2) = If(Nota.Evaluacion1 < 0, DBNull.Value, Nota.Evaluacion1)
        fila.Item(3) = If(Nota.Evaluacion2 < 0, DBNull.Value, Nota.Evaluacion2)
        fila.Item(4) = If(Nota.Evaluacion3 < 0, DBNull.Value, Nota.Evaluacion3)
        fila.Item(5) = If(Nota.NotaFinal < 0, DBNull.Value, Nota.NotaFinal)
        DatosConjunto.Tables(0).Rows.Add(fila)

        ActualizarBD()
        ActualizarListado(ListView)

    End Sub

    Public Sub Eliminar(Asignatura As Integer, Alumno As Integer, Listview As Windows.Forms.ListView)
        Dim Query As String = "DELETE FROM Cursa WHERE Asignatura=@Asi AND Alumno=@Alum;"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.DeleteCommand = Comando
        Comando.Parameters.AddWithValue("@Asi", Asignatura)
        Comando.Parameters.AddWithValue("@Alum", Alumno)

        For Each fila As DataRow In DatosConjunto.Tables(0).Rows
            If fila.RowState <> DataRowState.Deleted Then
                If fila("Asignatura").ToString() = Asignatura.ToString() AndAlso fila("Alumno").ToString() = Alumno.ToString() Then
                    fila.Delete() ' Eliminar la fila
                    Exit For ' Salir del bucle una vez que se ha eliminado la fila
                End If
            End If
        Next
        ActualizarBD()
        ActualizarListado(Listview)
    End Sub

    Sub Modificar(Nota As ModuloNota.Nota, ListView As Windows.Forms.ListView)
        Dim Query As String = "UPDATE Cursa SET Nota1=@Ev1, Nota2=@Ev2, Nota3=@Ev3, NotaFinal=@Fin WHERE Asignatura=@Asig AND Alumno=@Alu;"
        Dim Comando = New SQLiteCommand(Query, ConectarBD)
        AdaptadorDatos.UpdateCommand = Comando

        ' Agregar parámetros al comando
        Comando.Parameters.AddWithValue("@Ev1", If(Nota.Evaluacion1 < 0, DBNull.Value, Nota.Evaluacion1))
        Comando.Parameters.AddWithValue("@Ev2", If(Nota.Evaluacion2 < 0, DBNull.Value, Nota.Evaluacion2))
        Comando.Parameters.AddWithValue("@Ev3", If(Nota.Evaluacion3 < 0, DBNull.Value, Nota.Evaluacion3))
        Comando.Parameters.AddWithValue("@Fin", If(Nota.NotaFinal < 0, DBNull.Value, Nota.NotaFinal))
        Comando.Parameters.AddWithValue("@Asig", Nota.Asignatura)
        Comando.Parameters.AddWithValue("@Alu", Nota.Alumno)

        ' Actualizar el DataSet
        For Each fila As DataRow In DatosConjunto.Tables(0).Rows
            If fila("Asignatura").ToString() = Nota.Asignatura.ToString() AndAlso fila("Alumno").ToString() = Nota.Alumno.ToString() Then
                fila.BeginEdit()
                fila("Nota1") = If(Nota.Evaluacion1 < 0, DBNull.Value, Nota.Evaluacion1)
                fila("Nota2") = If(Nota.Evaluacion2 < 0, DBNull.Value, Nota.Evaluacion2)
                fila("Nota3") = If(Nota.Evaluacion3 < 0, DBNull.Value, Nota.Evaluacion3)
                fila("NotaFinal") = If(Nota.NotaFinal < 0, DBNull.Value, Nota.NotaFinal)
                fila.EndEdit()
                Exit For
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
                    AdaptadorDatos.Update(DatosCambios, "Cursa")
                    DatosConjunto.AcceptChanges()
                    RellenarDatosConjunto()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR FATAL, CAMBIOS NO GUARDADOS")
        End Try
    End Sub
End Module