Imports System.Data.SQLite

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

    Sub ActualizarListado()
        RellenarDatosConjuntoAlumnos()
        Dim ElementoList As ListViewItem
        GestionAlumnos.ListViewAlumnos.Items.Clear()

        For pos As Integer = 0 To DatosConjuntoAlum.Tables(0).Rows.Count - 1
            ElementoList = GestionAlumnos.ListViewAlumnos.Items.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(0))

            ElementoList.SubItems.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(1))
            ElementoList.SubItems.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(2))
            ElementoList.SubItems.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(3))
            ElementoList.SubItems.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(4))
            ElementoList.SubItems.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(5))
            ElementoList.SubItems.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(6))
            ElementoList.SubItems.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(7))
            ElementoList.SubItems.Add(DatosConjuntoAlum.Tables(0).Rows(pos).Item(8))
        Next
    End Sub

    Sub Insertar(Alumno As Alumno)
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
        fila.Item(0) = Alumno.Nombre
        fila.Item(1) = Alumno.Apellidos
        fila.Item(2) = Alumno.Direccion
        fila.Item(3) = Alumno.Localidad
        fila.Item(4) = Alumno.Movil
        fila.Item(5) = Alumno.Email
        fila.Item(6) = Alumno.FechaNacimiento
        fila.Item(7) = Alumno.Nacionalidad
        DatosConjuntoAlum.Tables(0).Rows.Add(fila)

        Comando.Cancel()

        ActualizarListado()

    End Sub
End Module