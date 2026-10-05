using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

    public class NegClinica
    {
        DaoClinica dao = new DaoClinica();

        /////////////// PRECARGADOS ////////////////////////////////////////////////////
        public DataTable listarProvincias()
        {
            return dao.ObtenerProvincias();
        }

        public DataTable listarLocalidades(string loca)
        {

            return dao.ObtenerLocalidad(loca);
        }
        public DataTable listarEspecialidades()
        {

            return dao.ObtenerEspecialidades();
        }
        ////////////////////// MEDICOS //////////////////////////////////////////////
        public bool agregarMedico(Medicos objMedico)
        {
            DaoClinica dao = new DaoClinica();

            return dao.agregarMedico(objMedico);
        }
        public DataTable MostrarActivos()
        {
            return dao.MostrarMedicosActivos();
        }
        public DataTable listarMedicos(string apellidoBusqueda = "")
        {
            return dao.MostrarMedicos(apellidoBusqueda);
        }
        public bool activarMedico(string legajo)
        {
            return dao.activarMedico(legajo);
        }

        public DataTable listarNombresMedicos(string idEspecialidad)
        {
            return dao.ObtenerNombresMedicos(idEspecialidad);
        }

        public bool EstadoMedico( string leg)
        {
            return dao.EliminarMedico(leg);
        }

        public DataTable ListarPorLegajo(string leg)
        {
            return dao.ObtenerMedicosXlegajo(leg);
        }

        public bool modificarMedico(Medicos objNuevo, Medicos objOriginal)
        {
            return dao.modificarMedico(objNuevo, objOriginal);
        }

        public bool ExisteLegajo(string legajo)
        {
            return dao.ExisteLegajo(legajo);
        }
        public bool ExisteDNI(string dni)
        {
            return dao.ExisteDNI(dni);
        }

        public bool ExisteEmail(string email)
        {
            return dao.ExisteEmail(email);
        }

        public bool ExisteUsuario(string usuario)
        {
            return dao.ExisteUsuario(usuario);
        }


        /////////////////////////USUARIOS///////////////////////////////////////////////////////////////////// 
        public DataTable ObtenerUSUARIOADMIN(string user, string pass)
        {
            return dao.ObtenerUsuarios(user, pass);
        }

        public DataTable obtenerUsuarioMedico(string user, string pass)
        {
            return dao.ObtenerUsariosMedicos(user, pass);

        }

        public bool CrearCuentaMedicos(string idCreado, string user, string pass)
        {
            return dao.AgregarCuentaMedico(idCreado, user, pass);
        }
        //////////////////////// PACIENTES ///////////////////////////////////////////

        public DataTable PacientesActivos()
        {
            return dao.PacientesActivos();
        }

        public DataTable listarPacientes(string apellidoBusqueda = "")
        {
            return dao.ObtenerPacientes(apellidoBusqueda);
        }

        public DataTable listarNombresPacientes()
        {
            return dao.ObtenerNombresPacientes();
        }

        public bool agregarPaciente(Pacientes obj)
        {
            return dao.agregarPaciente(obj);
        }

        public bool actPaciente(string DNI)
        {
           return dao.activarPaciente(DNI);
        }

        public bool bajarPaciente(string dni)
        {
            return dao.eliminarPaciente(dni);
        }

        public bool EstadoPaciente(string dni)
        {
            return dao.eliminarPaciente(dni);
        }

        public bool ExisteDNIPaciente(string dni)
        {
            return dao.ExisteDNIPaciente(dni);
        }

        public bool ExisteEmailPaciente(string email)
        {
            return dao.ExisteEmailPaciente(email);
        }

        public DataTable ListarPorDni(string dni)
        {
            return dao.ObtenerPacientesXDni(dni);
        }

        public DataTable buscarPacientesPorDni(string dni)
        {
            return dao.ObtenerPacienteCompletoPorDni(dni);
        }

        public bool modificarPaciente(Pacientes obj)
        {
            return dao.ModificarPaciente(obj);
        }

        public DataTable PacientesAusentes()
        {
            return dao.PacientesAusentes();
        }

        ////////////////////// TURNOS ////////////////////////////////////////////////
        public bool agregarTurno(Turnos objTurno)
        {
            if (dao.ExisteTurno(objTurno.GetId_T_Medico(), objTurno.GetDia(), objTurno.GetHorario()))
            {
                return false;
            }
                
            return dao.agregarTurno(objTurno);
        }

        public DataTable ObteUsu(string nombre)
        {
            return dao.ObtenerTurnos(nombre);
        }
        ////////////// informes /////////////////////////////////////////////////////////
        public int PresentesXfecha(DateTime Fecha1, DateTime Fecha2)
        {
            return dao.PresentesPorFecha(Fecha1, Fecha2);
        }
        public int ContarxFecha (DateTime Fecha1, DateTime Fecha2)
        {
            return dao.ContarTurnosPorFecha(Fecha1, Fecha2);
        }
        public int Ausexfecha(DateTime Fecha1, DateTime Fecha2)
        {
            return dao.AusenserPorFecha(Fecha1, Fecha2);
        }
        public DataTable MejMedico(DateTime Fecha1, DateTime Fecha2)
        {
            return dao.MejorMedico(Fecha1, Fecha2);
        }
        public int ContarMe(DateTime Fecha1, DateTime Fecha2)
        {
            return dao.contarTurnos(Fecha1, Fecha2);
        }

        public bool RegistrarAsistenciaTurno(int idTurno, bool asistencia, string observacion)
        {
            return dao.RegistrarAsistenciaTurno(idTurno, asistencia, observacion);
        }
    }
}   
