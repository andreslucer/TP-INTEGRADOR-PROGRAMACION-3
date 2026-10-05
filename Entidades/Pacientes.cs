using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pacientes
    {
        private string id_Pacientes;
        private string id_P_Localidad;
        private string id_P_Provincia;
        private string dni;
        private string nombre;
        private string apellido;
        private string sexo;
        private string nacionalidad;
        private DateTime fecha_de_nacimiento;
        private string direccion;
        private string correo_electronico;
        private string telefono;
        private bool activo;

        public Pacientes()
        {
        }

        // ------ GETTERS
        public string GetId_Pacientes()
        {
            return id_Pacientes;
        }
        public string GetId_P_Localidad()
        {
            return id_P_Localidad;
        }

        public string GetId_P_Provincia()
        {
            return id_P_Provincia;
        }
        public string GetDni()
        {
            return dni;
        }
        public string GetNombre()
        {
            return nombre;
        }
        public string GetApellido()
        {
            return apellido;
        }
        public string GetSexo()
        {
            return sexo;
        }
        public string GetNacionalidad()
        {
            return nacionalidad;
        }
        public DateTime GetFecha_de_nacimiento()
        {
            return fecha_de_nacimiento;
        }
        public string GetDireccion()
        {
            return direccion;
        }
        public string GetCorreo_electronico()
        {
            return correo_electronico;
        }
        public string GetTelefono()
        {
            return telefono;
        }
        public bool GetActivo()
        {
            return activo;
        }

        // ----- SETTERS
        public void SetId_Pacientes(string _id_Pacientes)
        {
            id_Pacientes = _id_Pacientes;
        }
        public void SetId_P_Localidad(string _id_P_Localidad)
        {
            id_P_Localidad = _id_P_Localidad;
        }
        public void SetId_P_Provincia(string _id_P_Provincia)
        {
            id_P_Provincia = _id_P_Provincia;
        }
        public void SetDni(string _dni)
        {
            dni = _dni;
        }
        public void SetNombre(string _nombre)
        {
            nombre = _nombre;
        }
        public void SetApellido(string _apellido)
        {
            apellido = _apellido;
        }
        public void SetSexo(string _sexo)
        {
            sexo = _sexo;
        }
        public void SetNacionalidad(string _nacionalidad)
        {
            nacionalidad = _nacionalidad;
        }
        public void SetFecha_de_nacimiento(DateTime _fecha_de_nacimiento)
        {
            fecha_de_nacimiento = _fecha_de_nacimiento;
        }
        public void SetDireccion(string _direccion)
        {
            direccion = _direccion;
        }
        public void SetCorreo_electronico(string _correo_electronico)
        {
            correo_electronico = _correo_electronico;
        }
        public void SetTelefono(string _telefono)
        {
            telefono = _telefono;
        }
        public void SetActivo(bool _activo)
        {
            activo = _activo;
        }
    }
}
