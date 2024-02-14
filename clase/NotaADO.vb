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

    Private Sub RellenarDatosConjunto()
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
        RellenarDatosConjunto()
        Dim ElementoList As ListViewItem
        ListView.Items.Clear()

        For pos As Integer = 0 To DatosConjunto.Tables(0).Rows.Count - 1
            ElementoList = ListView.Items.Add(DatosConjunto.Tables(0).Rows(pos).Item(0))
            For i As Integer = 1 To 5
                Dim EsNulo As String = DatosConjunto.Tables(0).Rows(pos).Item(i).ToString()
                If Not String.IsNullOrEmpty(EsNulo) AndAlso Not String.Equals(EsNulo, "null", StringComparison.OrdinalIgnoreCase) Then
                    ElementoList.SubItems.Add(DatosConjunto.Tables(0).Rows(pos).Item(i))
                Else
                    ElementoList.SubItems.Add("")
                End If
            Next
        Next
    End Sub

    Sub Insertar(Nota As ModuloNota.Nota, ListView As Windows.Forms.ListView)
        Dim Query As String = "INSERT INTO Cursa (Asignatura, Alumno, Nota1, Nota2, Nota3, NotaFinal) VALUES (@Asig, @Alu, @Ev1, @Ev2, @Ev3, @Fin);"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.InsertCommand = Comando

        Comando.Parameters.AddWithValue("@Asig", Nota.Asignatura)
        Comando.Parameters.AddWithValue("@Alu", Nota.Alumno)
        If (Nota.Evaluacion1 < 0) Then
            Comando.Parameters.AddWithValue("@Ev1", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@Ev1", Nota.Evaluacion1)
        End If
        If (Nota.Evaluacion2 < 0) Then
            Comando.Parameters.AddWithValue("@Ev2", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@Ev2", Nota.Evaluacion2)
        End If
        If (Nota.Evaluacion3 < 0) Then
            Comando.Parameters.AddWithValue("@Ev3", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@Ev3", Nota.Evaluacion3)
        End If
        If (Nota.NotaFinal < 0) Then
            Comando.Parameters.AddWithValue("@Fin", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@Fin", Nota.NotaFinal)
        End If

        fila = DatosConjunto.Tables(0).NewRow
        fila.Item(0) = Nota.Asignatura
        fila.Item(1) = Nota.Alumno
        fila.Item(2) = Nota.Evaluacion1
        fila.Item(3) = Nota.Evaluacion2
        fila.Item(4) = Nota.Evaluacion3
        fila.Item(5) = Nota.NotaFinal
        DatosConjunto.Tables(0).Rows.Add(fila)

        Comando.ExecuteNonQuery()

        ActualizarListado(ListView)

    End Sub

    Public Sub Eliminar(Nota As ModuloNota.Nota, Listview As Windows.Forms.ListView)
        Dim Query As String = "DELETE FROM Cursa WHERE Asignatura=@Asi AND Alumno=@Alum;"
        Dim Comando As New SQLiteCommand(Query, ConectarBD())
        AdaptadorDatos.DeleteCommand = Comando

        Comando.Parameters.AddWithValue("@Asi", Nota.Asignatura)
        Comando.Parameters.AddWithValue("@Alum", Nota.Alumno)
        DatosConjunto.Tables(0).Rows(0).Delete()

        Comando.ExecuteNonQuery()
        ActualizarListado(Listview)
    End Sub

    Sub Modificar(Nota As ModuloNota.Nota, ListView As Windows.Forms.ListView)
        Dim Query As String = "UPDATE Cursa SET Nota1=@Ev1, Nota2=@Ev2, Nota3=@Ev3, NotaFinal=@Fin WHERE Asignatura=@Asig AND Alumno=@Alu;"
        Dim Comando = New SQLiteCommand(Query, ConectarBD)
        AdaptadorDatos.UpdateCommand = Comando

        If (Nota.Evaluacion1 < 0) Then
            Comando.Parameters.AddWithValue("@Ev1", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@Ev1", Nota.Evaluacion1)
        End If
        If (Nota.Evaluacion2 < 0) Then
            Comando.Parameters.AddWithValue("@Ev2", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@Ev2", Nota.Evaluacion2)
        End If
        If (Nota.Evaluacion3 < 0) Then
            Comando.Parameters.AddWithValue("@Ev3", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@Ev3", Nota.Evaluacion3)
        End If
        If (Nota.NotaFinal < 0) Then
            Comando.Parameters.AddWithValue("@Fin", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@Fin", Nota.NotaFinal)
        End If
        Comando.Parameters.AddWithValue("@Asig", Nota.Asignatura)
        Comando.Parameters.AddWithValue("@Alu", Nota.Alumno)
        DatosConjunto.Tables(0).Rows(0).BeginEdit()
        DatosConjunto.Tables(0).Rows(0).Item(1) = Nota.Evaluacion1
        DatosConjunto.Tables(0).Rows(0).Item(2) = Nota.Evaluacion2
        DatosConjunto.Tables(0).Rows(0).Item(3) = Nota.Evaluacion3
        DatosConjunto.Tables(0).Rows(0).Item(4) = Nota.NotaFinal
        DatosConjunto.Tables(0).Rows(0).EndEdit()

        Comando.ExecuteNonQuery()

        ActualizarListado(ListView)
    End Sub

End Module