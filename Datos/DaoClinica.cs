using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoClinica
    {
        AcessoDatos ds = new AcessoDatos();
        private SqlConnection conexion;

        //////////////////////////// DATOS PRE CARGADOS/////////////////////////////////////////////////////////////
        public DataTable ObtenerEspecialidades()
        {
            string consulta = "Select * from Especialidades";
            return ds.ObtenerTabla("Especialidades", consulta);
        }
        public DataTable ObtenerLocalidad(String Sele)
        {
            string consulta = @"SELECT
                                    L.Id_Localidad, 
                                    L.Localidad
                                    FROM Localidades AS L
                                    INNER JOIN Provincias AS P ON L.Id_Lo_Provincia = P.Id_Provincia
                                    WHERE P.Id_Provincia = '" + Sele + "'";
            return ds.ObtenerTabla("Localidades", consulta);
        }

        public DataTable ObtenerProvincias()
        {
            string consulta = "select * from Provincias";
            return ds.ObtenerTabla("Provincias", consulta);
        }


        ///////////////////////////////// MEDICOOOOS///////////////////////////////////////////////////////////////
        public bool agregarMedico(Medicos objMedico)
        {
            int idMaximo = ds.ObtenerMaximo("SELECT ISNULL(MAX(CAST(Id_Medico AS INT)), 0) FROM Medicos");
            int nuevoId = idMaximo + 1;
            string idEnFormato4d = nuevoId.ToString("D4");
            objMedico.SetIdMedico(idEnFormato4d);
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@Id_Medico", idEnFormato4d);

            cmd.Parameters.AddWithValue("@Legajo", objMedico.GetLegajo());
            cmd.Parameters.AddWithValue("@Dni", objMedico.GetDni());
            cmd.Parameters.AddWithValue("@Nombre", objMedico.GetNombre());
            cmd.Parameters.AddWithValue("@Apellido", objMedico.GetApellido());
            cmd.Parameters.AddWithValue("@Sexo", objMedico.GetSexo());
            cmd.Parameters.AddWithValue("@Nacionalidad", objMedico.GetNacionalidad());
            cmd.Parameters.AddWithValue("@FechaDeNacimiento", objMedico.GetFechaDeNacimiento());
            cmd.Parameters.AddWithValue("@Direccion", objMedico.GetDireccion());
            cmd.Parameters.AddWithValue("@CorreoElectronico", objMedico.GetCorreoElectronico());
            cmd.Parameters.AddWithValue("@Telefono", objMedico.GetTelefono());
            cmd.Parameters.AddWithValue("@Id_Localidad", objMedico.GetIdLocalidad());
            cmd.Parameters.AddWithValue("@Id_Especialidad", objMedico.GetIdEspecialidad());
            cmd.Parameters.AddWithValue("@DiasDeAtencion", objMedico.GetDiasDeAtencion());
            cmd.Parameters.AddWithValue("@Activo", objMedico.GetActivo());

            string consulta = "INSERT INTO Medicos (Id_Medico, Legajo, Dni, nombre, apellido, sexo, nacionalidad, fecha_de_nacimiento, direccion, correo_electronico, telefono, Id_M_Localidad, Id_M_Especialidad, DiasDeAtencion, activo) " +
                              "VALUES (@Id_Medico, @Legajo, @Dni, @Nombre, @Apellido, @Sexo, @Nacionalidad, @FechaDeNacimiento, @Direccion, @CorreoElectronico, @Telefono, @Id_Localidad, @Id_Especialidad, @DiasDeAtencion, @Activo)";

        cmd.CommandText = consulta;
            int filasAfectadas = ds.EjercutarConsulta(cmd);

            return filasAfectadas == 1;
        }
        public DataTable MostrarMedicos(string apellidoBusqueda = "")
        {
            // Construimos la consulta renombrando con AS (Pauta 14)
            string consulta = @"SELECT 
                        M.Legajo AS [Legajo], 
                        M.Dni AS [DNI], 
                        M.nombre AS [Nombre], 
                        M.apellido AS [Apellido], 
                        M.direccion AS [Dirección], 
                        M.correo_electronico AS [E-Mail], 
                        M.telefono AS [Teléfono], 
                        M.DiasDeAtencion AS [Días de Atención],
                        E.NombreEspecialidad AS [Especialidad],
                        L.Localidad AS [Localidad],
                        M.activo
                        FROM Medicos M
                        INNER JOIN Especialidades E ON M.Id_M_Especialidad = E.Id_Especialidad
                        INNER JOIN Localidades L ON M.Id_M_Localidad = L.Id_Localidad ";

            // Si ingresan texto, concatenamos el filtro LIKE (Pauta 3)
            if (!string.IsNullOrWhiteSpace(apellidoBusqueda))
            {
                consulta += " AND M.apellido LIKE '%" + apellidoBusqueda.Trim() + "%'";
            }

            consulta += "ORDER BY M.activo DESC;";
            return ds.ObtenerTabla("Medicos", consulta);
        }

        public DataTable MostrarMedicosActivos()
        {
            string consulta = "SELECT * FROM Medicos WHERE activo = 1;";
            return ds.ObtenerTabla("Medicos",consulta);
        }

        public DataTable ObtenerNombresMedicos(string idEspecialidad)
        {
            string consulta = "SELECT Id_Medico, nombre + ' ' + apellido AS NombreCompleto FROM Medicos" +
                              " WHERE Id_M_Especialidad = '" + idEspecialidad + "' AND activo = 1";
            return ds.ObtenerTabla("Medicos", consulta);
        }

        public DataTable ObtenerMedicosXlegajo(string legajo)
        {
            string consulta = "SELECT M.*, L.Id_Lo_Provincia " +
                              "FROM Medicos M " +
                              "INNER JOIN Localidades L ON M.Id_M_Localidad = L.Id_Localidad " +
                              "WHERE M.Legajo = '" + legajo + "' AND M.activo = 1";
            return ds.ObtenerTabla("Medicos", consulta);
        }
        public bool EliminarMedico( string lega)
        {
            Medicos med = new Medicos();
            med.SetActivo(false);

            SqlCommand cmd = new SqlCommand();
            string consulta = "UPDATE Medicos SET activo = @Activo WHERE Legajo = @Legajo";
            cmd.CommandText = consulta;

            cmd.Parameters.AddWithValue("@Activo", med.GetActivo());

            cmd.Parameters.AddWithValue("@Legajo", lega);

            int filasAfectadas = ds.EjercutarConsulta(cmd);

            return filasAfectadas == 1;
        }

        public bool activarMedico(string legajo)
        {
            Medicos med = new Medicos();
            med.SetActivo(true);

            SqlCommand cmd = new SqlCommand();
            string consulta = "UPDATE Medicos SET activo = @Activo WHERE Legajo = @Legajo";
            cmd.CommandText = consulta;

            cmd.Parameters.AddWithValue("@Activo", med.GetActivo());

            cmd.Parameters.AddWithValue("@Legajo", legajo);

            int filasAfectadas = ds.EjercutarConsulta(cmd);

            return filasAfectadas == 1;
        }

        public bool modificarMedico(Medicos objNuevo, Medicos objOriginal)
        {
            SqlCommand cmd = new SqlCommand();
            string Campos = "";

            if (objNuevo.GetDni() != objOriginal.GetDni())
            {
                Campos += "Dni = @Dni, ";
                cmd.Parameters.AddWithValue("@Dni", objNuevo.GetDni());
            }

            if (objNuevo.GetNombre() != objOriginal.GetNombre())
            {
                Campos += "nombre = @Nombre, ";
                cmd.Parameters.AddWithValue("@Nombre", objNuevo.GetNombre());
            }

            if (objNuevo.GetApellido() != objOriginal.GetApellido())
            {
                Campos += "apellido = @Apellido, ";
                cmd.Parameters.AddWithValue("@Apellido", objNuevo.GetApellido());
            }

            if (objNuevo.GetSexo() != objOriginal.GetSexo())
            {
                Campos += "sexo = @Sexo, ";
                cmd.Parameters.AddWithValue("@Sexo", objNuevo.GetSexo());
            }

            if (objNuevo.GetNacionalidad() != objOriginal.GetNacionalidad())
            {
                Campos += "nacionalidad = @Nacionalidad, ";
                cmd.Parameters.AddWithValue("@Nacionalidad", objNuevo.GetNacionalidad());
            }

            if (objNuevo.GetFechaDeNacimiento() != objOriginal.GetFechaDeNacimiento())
            {
                Campos += "fecha_de_nacimiento = @FechaDeNacimiento, ";
                cmd.Parameters.AddWithValue("@FechaDeNacimiento", objNuevo.GetFechaDeNacimiento());
            }

            if (objNuevo.GetDireccion() != objOriginal.GetDireccion())
            {
                Campos += "direccion = @Direccion, ";
                cmd.Parameters.AddWithValue("@Direccion", objNuevo.GetDireccion());
            }

            if (objNuevo.GetCorreoElectronico() != objOriginal.GetCorreoElectronico())
            {
                Campos += "correo_electronico = @CorreoElectronico, ";
                cmd.Parameters.AddWithValue("@CorreoElectronico", objNuevo.GetCorreoElectronico());
            }

            if (objNuevo.GetTelefono() != objOriginal.GetTelefono())
            {
                Campos += "telefono = @Telefono, ";
                cmd.Parameters.AddWithValue("@Telefono", objNuevo.GetTelefono());
            }

            if (objNuevo.GetIdLocalidad() != objOriginal.GetIdLocalidad())
            {
                Campos += "Id_M_Localidad = @Id_Localidad, ";
                cmd.Parameters.AddWithValue("@Id_Localidad", objNuevo.GetIdLocalidad());
            }

            if (objNuevo.GetIdEspecialidad() != objOriginal.GetIdEspecialidad())
            {
                Campos += "Id_M_Especialidad = @Id_Especialidad, ";
                cmd.Parameters.AddWithValue("@Id_Especialidad", objNuevo.GetIdEspecialidad());
            }

            if (objNuevo.GetDiasDeAtencion() != objOriginal.GetDiasDeAtencion())
            {
                Campos += "DiasDeAtencion = @DiasDeAtencion, ";
                cmd.Parameters.AddWithValue("@DiasDeAtencion", objNuevo.GetDiasDeAtencion());
            }

            if (string.IsNullOrEmpty(Campos))
                return true;

            Campos = Campos.TrimEnd(',', ' ');
            string consulta = "UPDATE Medicos SET " + Campos + " WHERE Legajo = @Legajo";
            cmd.Parameters.AddWithValue("@Legajo", objNuevo.GetLegajo());
            cmd.CommandText = consulta;

            return ds.EjercutarConsulta(cmd) == 1;
        }
        


        public bool ExisteLegajo(string legajo)
        {
            string consulta = "SELECT COUNT(*) FROM Medicos WHERE Legajo = '" + legajo + "'";
            int count = ds.ObtenerMaximo(consulta);
            return count > 0;
        }

        public bool ExisteDNI(string dni)
        {
            string consulta = "SELECT COUNT(*) FROM Medicos WHERE Dni = '" + dni + "'";
            int count = ds.ObtenerMaximo(consulta);
            return count > 0;
        }

        public bool ExisteEmail(string email)
        {
            string consulta = "SELECT COUNT(*) FROM Medicos WHERE correo_electronico = '" + email + "'";
            int count = ds.ObtenerMaximo(consulta);
            return count > 0;
        }

        public bool ExisteUsuario(string usuario)
        {
            string consulta = "SELECT COUNT(*) FROM MedicosCuentas WHERE Usuario = '" + usuario + "'";
            int count = ds.ObtenerMaximo(consulta);
            return count > 0;
        }



        /////////////////////////////////// PACIENTESSSSSSSSS ///////////////////////////////////
        public DataTable PacientesActivos()
        {
            string consulta = "SELECT * FROM Pacientes WHERE activo = 1;";
            return ds.ObtenerTabla("Pacientes", consulta);
        }
        public DataTable ObtenerPacientes(string apellidoBusqueda = "")
        {
            // Construimos la consulta base renombrando los encabezados con AS (Pauta 14)
            string consulta = @"SELECT 
                        P.DNI AS [DNI], 
                        P.nombre AS [Nombre], 
                        P.apellido AS [Apellido], 
                        P.sexo AS [Sexo], 
                        P.nacionalidad AS [Nacionalidad], 
                        P.fecha_de_nacimiento AS [Fecha de Nacimiento], 
                        P.direccion AS [Dirección], 
                        P.correo_electronico AS [E-Mail], 
                        P.telefono AS [Teléfono],
                        PR.Provincia AS [Provincia],
                        P.activo AS [activo],
                        L.Localidad AS [Localidad]
                        FROM Pacientes P
                        INNER JOIN Localidades L ON P.Id_P_Localidad = L.Id_Localidad
                        INNER JOIN Provincias PR ON L.Id_Lo_Provincia = PR.Id_Provincia ";

            // Si el usuario ingresó un texto en el buscador, concatenamos el filtro LIKE (Pauta 3)
            if (!string.IsNullOrWhiteSpace(apellidoBusqueda))
            {
                consulta += " AND P.apellido LIKE '%" + apellidoBusqueda.Trim() + "%'";
            }

            consulta += "ORDER BY P.activo DESC;";
            return ds.ObtenerTabla("Pacientes", consulta);
        }

        public DataTable ObtenerNombresPacientes()
        {
            string consulta = "SELECT Id_Pacientes, nombre + ' ' + apellido AS NombreCompleto FROM Pacientes WHERE activo = 1";
            return ds.ObtenerTabla("Pacientes", consulta);
        }

        public DataTable ObtenerPacientesXDni(string dni)
        {
            string consulta = "SELECT Dni, nombre, apellido FROM Pacientes WHERE Dni = '" + dni + "' AND Activo = 1";
            return ds.ObtenerTabla("PacientesXDni", consulta);
        }

        public bool agregarPaciente(Pacientes obj)
        {
            int idMaximo = ds.ObtenerMaximo("SELECT ISNULL(MAX(CAST(Id_Pacientes AS INT)), 0) FROM Pacientes");
            int nuevoId = idMaximo + 1;
            string idEnFormato4d = nuevoId.ToString("D4");

            SqlCommand cmd = new SqlCommand();
            string consulta = "INSERT INTO Pacientes (Id_Pacientes, Id_P_Localidad, Dni, Nombre, Apellido, " +
                "Sexo, Nacionalidad, Fecha_de_nacimiento, Direccion, Correo_electronico, Telefono, Activo) " +
                  "VALUES (@Id_Pacientes, @Id_P_Localidad, @Dni, @Nombre, @Apellido, " +
                  "@Sexo, @Nacionalidad, @Fecha_de_nacimiento, @Direccion, @Correo_electronico, @Telefono, @Activo)";
            
            cmd.Parameters.AddWithValue("@Id_Pacientes", idEnFormato4d);
            cmd.Parameters.AddWithValue("@Id_P_Localidad", obj.GetId_P_Localidad());
            cmd.Parameters.AddWithValue("@Dni", obj.GetDni());
            cmd.Parameters.AddWithValue("@Nombre", obj.GetNombre());
            cmd.Parameters.AddWithValue("@Apellido", obj.GetApellido());
            cmd.Parameters.AddWithValue("@Sexo", obj.GetSexo());
            cmd.Parameters.AddWithValue("@Nacionalidad", obj.GetNacionalidad());
            cmd.Parameters.AddWithValue("@Fecha_de_nacimiento", obj.GetFecha_de_nacimiento());
            cmd.Parameters.AddWithValue("@Direccion", obj.GetDireccion());
            cmd.Parameters.AddWithValue("@Correo_electronico", obj.GetCorreo_electronico());
            cmd.Parameters.AddWithValue("@Telefono", obj.GetTelefono());
            cmd.Parameters.AddWithValue("@Activo", obj.GetActivo());

            cmd.CommandText = consulta;

            return ds.EjercutarConsulta(cmd) == 1;
        }
       
        public bool eliminarPaciente(string dni)
        {
            Pacientes pac = new Pacientes();
            pac.SetActivo(false); //empieza en 0
            
            SqlCommand cmd = new SqlCommand();
            string consulta = "UPDATE Pacientes SET Activo = @Activo WHERE Dni = @Dni";
            cmd.CommandText = consulta;

            cmd.Parameters.AddWithValue("@Activo", pac.GetActivo());
            cmd.Parameters.AddWithValue("@Dni", dni);

            return ds.EjercutarConsulta(cmd) == 1;
        }

        public bool activarPaciente(string dni)
        {
            Pacientes pac = new Pacientes();
            pac.SetActivo(true);
            SqlCommand cmd = new SqlCommand();
            string consulta = "UPDATE Pacientes SET Activo = @Activo WHERE Dni = @Dni";
            cmd.CommandText = consulta;
            cmd.Parameters.AddWithValue("@Activo", pac.GetActivo());
            cmd.Parameters.AddWithValue("@Dni", dni);

            return ds.EjercutarConsulta(cmd) == 1;

        }

        public bool ExisteEmailPaciente(string email)
        {
            string consulta = "SELECT COUNT(*) FROM Pacientes WHERE correo_electronico = '" + email + "'";
            int count = ds.ObtenerMaximo(consulta);
            return count > 0;
        }

        public bool ExisteDNIPaciente(string dni)
        {
            string consulta = "SELECT COUNT(*) FROM Pacientes WHERE Dni = '" + dni + "'";
            int count = ds.ObtenerMaximo(consulta);
            return count > 0;
        }

        public DataTable ObtenerPacienteCompletoPorDni(string dni)
        {
            // Armamos la consulta SQL para obtener los datos completos del paciente, incluyendo la localidad y provincia
            string consulta = "SELECT Pacientes.DNI, Pacientes.nombre, Pacientes.apellido, Pacientes.sexo, Pacientes.nacionalidad, Pacientes.fecha_de_nacimiento, Pacientes.direccion, Pacientes.correo_electronico, Pacientes.telefono, Pacientes.Id_P_Localidad, Localidades.Id_Lo_Provincia, Localidades.Localidad, Provincias.Provincia " +
                              "FROM Pacientes " +
                              "INNER JOIN Localidades ON Pacientes.Id_P_Localidad = Localidades.Id_Localidad " +
                              "INNER JOIN Provincias ON Localidades.Id_Lo_Provincia = Provincias.Id_Provincia " +
                              "WHERE Pacientes.DNI = '" + dni + "' AND Pacientes.activo = 1;";

            return ds.ObtenerTabla("PacienteCompleto", consulta);
        }

        public bool ModificarPaciente(Pacientes obj)
        {
            // Armamos la consulta SQL para actualizar los datos del paciente
            SqlCommand cmd = new SqlCommand();
            string consulta = "UPDATE Pacientes SET Id_P_Localidad = @Id_P_Localidad, nombre = @Nombre, apellido = @Apellido, " +
                "sexo = @Sexo, nacionalidad = @Nacionalidad, fecha_de_nacimiento = @Fecha_de_nacimiento, direccion = @Direccion, " +
                "correo_electronico = @Correo_electronico, telefono = @Telefono WHERE DNI = @Dni";

            cmd.CommandText = consulta;
            cmd.Parameters.AddWithValue("@Dni", obj.GetDni());
            cmd.Parameters.AddWithValue("@Id_P_Localidad", obj.GetId_P_Localidad());
            cmd.Parameters.AddWithValue("@Nombre", obj.GetNombre());
            cmd.Parameters.AddWithValue("@Apellido", obj.GetApellido());
            cmd.Parameters.AddWithValue("@Sexo", obj.GetSexo());
            cmd.Parameters.AddWithValue("@Nacionalidad", obj.GetNacionalidad());
            cmd.Parameters.AddWithValue("@Fecha_de_nacimiento", obj.GetFecha_de_nacimiento());
            cmd.Parameters.AddWithValue("@Direccion", obj.GetDireccion());
            cmd.Parameters.AddWithValue("@Correo_electronico", obj.GetCorreo_electronico());
            cmd.Parameters.AddWithValue("@Telefono", obj.GetTelefono());

            return ds.EjercutarConsulta(cmd) == 1;
        }

        public DataTable PacientesAusentes()
        {
            string consulta = @"
            SELECT 
            P.nombre + ' ' + P.apellido AS [Nombre completo], 
            CASE 
                WHEN T.asistencia = 1 THEN 'Presente' 
                ELSE 'Ausente' 
            END AS [Estado]
            FROM Pacientes P
            INNER JOIN Turnos T ON P.Id_Pacientes = T.Id_T_Id_Pacientes;";
            return ds.ObtenerTabla("Pacientes", consulta);
        }

        //////////////////////////////////////////////////////////////////////// usuarios /////////////////////////////////////////////////////////////////////////////
        public DataTable ObtenerUsuarios(string user, string pass)
        {
            string consulta = "SELECT * FROM USUARIOADMIN WHERE usuario = '" + user + "' AND contraseña = '" + pass + " '";
            return ds.ObtenerTabla("USUARIOSADMIN", consulta);
        }

        public DataTable ObtenerUsariosMedicos(string user, string pass)
        {
            string consulta = "select * from MedicosCuentas WHERE Usuario = '" + user + "' AND Contraseña = '" + pass + "'";
            return ds.ObtenerTabla("UsuariosMedicos", consulta);
        }


        public bool AgregarCuentaMedico(string idMedicoGenerado, string user, string pass)
        {
            int idMaximo = ds.ObtenerMaximo("SELECT ISNULL(MAX(CAST(Id_MedicosCuentas AS INT)), 0) FROM MedicosCuentas");
            string nuevoId = (idMaximo + 1).ToString();

            SqlCommand cmd = new SqlCommand();

            // Usamos VALUES y evitamos repetir columnas
            string consulta = "INSERT INTO MedicosCuentas (Id_MedicosCuentas, Id_MC_Medico, Usuario, Contraseña) " +
                              "VALUES (@Id_MedicosCuentas, @Id_MC_Medico, @Usuario, @Contrasena)";

            cmd.CommandText = consulta;

            // Pasamos todos los datos de forma segura
            cmd.Parameters.AddWithValue("@Id_MedicosCuentas", nuevoId);
            cmd.Parameters.AddWithValue("@Id_MC_Medico", idMedicoGenerado); // <-- El ID que conectará ambas tablas
            cmd.Parameters.AddWithValue("@Usuario", user);
            cmd.Parameters.AddWithValue("@Contrasena", pass);

            return ds.EjercutarConsulta(cmd) == 1;
        }

        /////////// TURNOSSSSSS////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool agregarTurno(Turnos objTurno)
        {            
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@Id_Especialidad", objTurno.GetId_T_Especialidad());
            cmd.Parameters.AddWithValue("@Id_Pacientes", objTurno.GetId_T_Id_Pacientes());
            cmd.Parameters.AddWithValue("@Id_Medico", objTurno.GetId_T_Medico());
            cmd.Parameters.AddWithValue("@Dia", objTurno.GetDia());
            cmd.Parameters.AddWithValue("@Horario", objTurno.GetHorario());
            cmd.Parameters.AddWithValue("@Comentarios", objTurno.GetComentarios());
            cmd.Parameters.AddWithValue("@Asistencia", objTurno.GetAsistencia());

            string consulta = "INSERT INTO Turnos (Id_T_Especialidad, Id_T_Id_Pacientes, Id_T_Medico, Dia, horario, comentarios, asistencia) " +
                               "VALUES (@Id_Especialidad, @Id_Pacientes, @Id_Medico, @Dia, @Horario, @Comentarios, @Asistencia)";

            cmd.CommandText = consulta;
            int filasAfectadas = ds.EjercutarConsulta(cmd);

            return filasAfectadas == 1;
        }

        public DataTable ObtenerTurnos(string nombre )
        {
            string consulta = $@"SELECT 
            t.Id_Turnos AS [Numero de Turno],
            e.NombreEspecialidad AS [Especialidad],
            p.nombre + ' ' + p.apellido + ' DNI: ' + p.DNI AS [Nombre Apellido Y DNI],
            t.Dia AS [Dia],
            t.comentarios AS [Comentarios],
            t.asistencia AS [Asistencia],
            t.horario AS [Horario]
            FROM Turnos t
            INNER JOIN Pacientes p ON t.Id_T_Id_Pacientes = p.Id_Pacientes
            INNER JOIN Medicos m ON t.Id_T_Medico = m.Id_Medico
            INNER JOIN Especialidades e ON t.Id_T_Especialidad = e.Id_Especialidad
            INNER JOIN MedicosCuentas mc ON t.Id_T_Medico = mc.Id_MC_Medico 
            WHERE mc.Usuario = '{nombre}';";
            return ds.ObtenerTabla("ObtenerTurnos", consulta);
        }

        public bool ExisteTurno(string idMedico, DateTime dia, TimeSpan horario)
        {
            string consulta = "SELECT COUNT(*) FROM Turnos WHERE Id_T_Medico = '" + idMedico +
                  "' AND Dia = '" + dia.ToString("yyyy-MM-dd") +
                  "' AND ('" + horario.ToString(@"hh\:mm\:ss") + "' >= horario" +
                  " AND '" + horario.ToString(@"hh\:mm\:ss") + "' < CAST(DATEADD(hour, 1, horario) AS time)" +
                  " OR horario >= '" + horario.ToString(@"hh\:mm\:ss") +
                  "' AND horario < CAST(DATEADD(hour, 1, '" + horario.ToString(@"hh\:mm\:ss") + "') AS time))";
            return ds.ObtenerMaximo(consulta) > 0;
        }
        ////////////////////////////////////// INFORMES /////////////////////////////////////////////////////////////
        public int ContarTurnosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {


            // Armamos la consulta con parámetros
            string consulta = "SELECT COUNT(*) FROM Turnos WHERE Dia BETWEEN @fecha1 AND @fecha2 ";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@fecha1", fechaInicio);
            comando.Parameters.AddWithValue("@fecha2", fechaFin);

            // Llamamos a tu nuevo método
            return ds.ObtenerEscalar(comando);
        }

        public int PresentesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            string consulta  = $"SELECT COUNT(*) FROM Turnos WHERE Dia BETWEEN @fecha1 AND @fecha2 AND asistencia = 1";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@fecha1", fechaInicio);
            comando.Parameters.AddWithValue("@fecha2", fechaFin);

            // Llamamos a tu nuevo método
            return ds.ObtenerEscalar(comando);
        }
        public int AusenserPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            string consulta = $"SELECT COUNT(*) FROM Turnos WHERE Dia BETWEEN @fecha1 AND @fecha2 AND asistencia = 0";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@fecha1", fechaInicio);
            comando.Parameters.AddWithValue("@fecha2", fechaFin);

            // Llamamos a tu nuevo método
            return ds.ObtenerEscalar(comando);
        }

        public DataTable MejorMedico(DateTime fechaInicio, DateTime fechaFin)
        {
            // Formateamos las fechas al estándar ISO 8601 que SQL Server jamás malinterpreta.
            // Esto evita el error de sintaxis '00' causado por los espacios o los dos puntos de la hora.
            string strInicio = fechaInicio.ToString("yyyy-MM-ddTHH:mm:ss");
            string strFin = fechaFin.ToString("yyyy-MM-ddTHH:mm:ss");

            // Armamos la consulta. FÍJATE BIEN en las comillas simples (') alrededor de las fechas.
            string consulta = $@"
        SELECT TOP 1   
            M.nombre + ' ' + M.apellido AS [NombreCompleto], 
            E.NombreEspecialidad AS [Especialidades], 
            COUNT(T.Id_Turnos) AS [TurnosAtendidos] 
        FROM Turnos T 
        INNER JOIN Medicos M ON T.Id_T_Medico = M.Id_Medico  
        INNER JOIN Especialidades E ON M.Id_M_Especialidad = E.Id_Especialidad 
        WHERE T.Dia BETWEEN '{strInicio}' AND '{strFin}' 
        GROUP BY M.nombre, M.apellido, E.NombreEspecialidad 
        ORDER BY COUNT(T.Id_Turnos) DESC;";

            return ds.ObtenerTabla("MejorMedico", consulta);
        }

        public int contarTurnos(DateTime fechaInicio,DateTime fechaFin)
        {
            // Armamos la consulta con parámetros
            string consulta = $"SELECT TOP 1 COUNT(Id_Turnos) FROM Turnos WHERE Dia BETWEEN @fecha1 AND @fecha2  GROUP BY Id_T_Medico  ORDER BY COUNT(Id_Turnos) DESC;";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@fecha1", fechaInicio);
            comando.Parameters.AddWithValue("@fecha2", fechaFin);

            // Llamamos a tu nuevo método
            return ds.ObtenerEscalar(comando);
        }

        public bool RegistrarAsistenciaTurno(int idTurno, bool asistencia, string observacion)
        {
            SqlCommand cmd = new SqlCommand();
            string consulta = "UPDATE Turnos SET asistencia = @Asistencia, comentarios = @Observacion WHERE Id_Turnos = @IdTurno";

            cmd.CommandText = consulta;
            cmd.Parameters.AddWithValue("@IdTurno", idTurno);
            cmd.Parameters.AddWithValue("@Asistencia", asistencia);
            cmd.Parameters.AddWithValue("@Observacion", string.IsNullOrWhiteSpace(observacion) ? (object)DBNull.Value : observacion);

            return ds.EjercutarConsulta(cmd) == 1;
        }
    }

 }



