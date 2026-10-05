using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turnos
    {
        private int id_Turnos;
        private string id_T_Especialidad;
        private string id_T_Id_Pacientes;
        private string id_T_Medico;
        private DateTime dia;
        private TimeSpan horario;
        private string comentarios;
        private bool asistencia;

        public Turnos()
        {
        }

        // GETTERS
        public int GetId_Turnos() 
        { 
            return id_Turnos; 
        }
        public string GetId_T_Especialidad() 
        { 
            return id_T_Especialidad; 
        }
        public string GetId_T_Id_Pacientes() 
        {
            return id_T_Id_Pacientes; 
        }
        public string GetId_T_Medico() 
        {
            return id_T_Medico; 
        }
        public DateTime GetDia() 
        { 
            return dia; 
        }
        public TimeSpan GetHorario() 
        { 
            return horario; 
        }
        public string GetComentarios() 
        { 
            return comentarios; 
        }
        public bool GetAsistencia() 
        { 
            return asistencia; 
        }

        // SETTERS
        public void SetId_Turnos(int _id_turnos) 
        { 
            id_Turnos = _id_turnos; }
        public void SetId_T_Especialidad(string _id_T_Especialidad) 
        { 
            id_T_Especialidad = _id_T_Especialidad; 
        }
        public void SetId_T_Id_Pacientes(string _id_T_Id_Pacientes) 
        { 
            id_T_Id_Pacientes = _id_T_Id_Pacientes; 
        }
        public void SetId_T_Medico(string _id_T_Medico) 
        { 
            id_T_Medico = _id_T_Medico; 
        }
        public void SetDia(DateTime _dia)
        { 
            dia = _dia; 
        }
        public void SetHorario(TimeSpan _horario) 
        { 
            horario = _horario; 
        }
        public void SetComentarios(string _comentarios) 
        { 
            comentarios = _comentarios; 
        }
        public void SetAsistencia(bool _asistencia) 
        { 
            asistencia = _asistencia; 
        }
    }
}
