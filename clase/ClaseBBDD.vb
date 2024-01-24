Imports System.Data.SQLite
Imports System.Windows

Module ClaseBBDD
    Dim Url As String = "C:Users\diurno\Clase.db"
    Public AdaptadorDatosAlum As SQLiteDataAdapter
    Public DatosConjuntoAlum As DataSet
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
        Dim Conn As New SQLiteConnection("Provider=SQLite;Data Source=Clase.db;Version=3")
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
        DatosConjuntoAlum = New DataSet
        AdaptadorDatosAlum.Fill(DatosConjuntoAlum, "Alumnos")
        Conexion.Close()
    End Sub

    Sub ActualizarListado(ListView As Windows.Forms.ListView)
        RellenarDatosConjuntoAlumnos()
        Dim ElementoList As ListViewItem
        ListView.Items.Clear()

        For pos As Integer = 0 To DatosConjuntoAlum.Tables(0).Rows.Count - 1
            ElementoList = ListView.Items.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(0))
            For i As Integer = 1 To 8
                Dim EsNulo As String = DatosConjuntoAlum.Tables(0).Rows(pos).Item(i).ToString()
                If Not String.IsNullOrEmpty(EsNulo) AndAlso Not String.Equals(EsNulo, "null", StringComparison.OrdinalIgnoreCase) Then
                    ElementoList.SubItems.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(i))
                Else
                    ElementoList.SubItems.Add("")
                End If
            Next
        Next
    End Sub

    Sub Insertar(Alumno As Alumno, ListView As Windows.Forms.ListView)
        Dim CadenaInsertarReg As String = "insert into Alumnos (Nombre, Apellidos, Direccion, Localidad,Movil,Email,FechaNacimiento,Nacionalidad) values (@Nom, @Ape, @Dir, @Loc, @Mov, @Ema, @Fec, @Nac)"
        Dim Comando As New SQLiteCommand(CadenaInsertarReg, ConectarBD())
        AdaptadorDatosAlum.InsertCommand = Comando

        Comando.Parameters.AddWithValue("@Nom", Alumno.Nombre)
        Comando.Parameters.AddWithValue("@Ape", Alumno.Apellidos)
        Comando.Parameters.AddWithValue("@Dir", Alumno.Direccion)
        Comando.Parameters.AddWithValue("@Loc", Alumno.Localidad)
        Comando.Parameters.AddWithValue("@Mov", Alumno.Movil)
        Comando.Parameters.AddWithValue("@Ema", Alumno.Email)
        Comando.Parameters.AddWithValue("@Fec", Alumno.FechaNacimiento)
        Comando.Parameters.AddWithValue("@Nac", Alumno.Nacionalidad)

        fila = DatosConjuntoAlum.Tables(0).NewRow
        fila.Item(1) = Alumno.Nombre
        fila.Item(2) = Alumno.Apellidos
        fila.Item(3) = Alumno.Direccion
        fila.Item(4) = Alumno.Localidad
        fila.Item(5) = Alumno.Movil
        fila.Item(6) = Alumno.Email
        fila.Item(7) = Alumno.FechaNacimiento
        fila.Item(8) = Alumno.Nacionalidad
        DatosConjuntoAlum.Tables(0).Rows.Add(fila)

        Comando.ExecuteNonQuery()

        ActualizarListado(ListView)

    End Sub

    Public Sub Eliminar(Id As Integer, Listview As Windows.Forms.ListView)
        Dim CadenaEliminarReg As String = "delete from Alumnos where id=@id"
        Dim Comando As New SQLiteCommand(CadenaEliminarReg, ConectarBD())
        AdaptadorDatosAlum.DeleteCommand = Comando

        Comando.Parameters.AddWithValue("@id", Id)
        DatosConjuntoAlum.Tables(0).Rows(0).Delete()

        Comando.ExecuteNonQuery()
        ActualizarListado(Listview)
    End Sub
End Module