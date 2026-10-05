using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medicos
    {
        private string Id_Medico;
        private string Id_Especialidad;
        private string Id_Locadidad;
        private string Legajo;
        private string Dni;
        private string Nombre;
        private string Apellido;
        private string Sexo;
        private string Nacionalidad;
        private DateTime FechaDeNacimiento;
        private string Direccion;
        private string CorreoElectronico;
        private string Telefono;
        private string DiasDeAtencion;
        private bool Activo;

        public Medicos()
        {
        }
        ////////////SETTERS/////////////
        public void SetIdMedico(string ID_Medico)
        {
            Id_Medico = ID_Medico;
        }
        public void SetId_Especialidad(string ID_especialidad)
        {
            Id_Especialidad = ID_especialidad;
        }
        public void SetId_Localidad(string ID_Localidad)
        {
            Id_Locadidad = ID_Localidad;
        }
        public void SetLegajo(string LEgajo)
        {
            Legajo = LEgajo;
        }
        public void SetDni(string DNi)
        {
            Dni = DNi;
        }
        public void SetNombre(string NOmbre)
        {
            Nombre = NOmbre;
        }
        public void SetApellido(string APellido)
        {
            Apellido = APellido;
        }
        public void SetSexo(string SExo)
        {
            Sexo = SExo;
        }
        public void SetNacionalidad(string NAcionalidad)
        {
            Nacionalidad = NAcionalidad;
        }
        public void SetFechaDeNacimiento(DateTime FEchaDeNacimiento)
        {
            FechaDeNacimiento = FEchaDeNacimiento;
        }
        public void SetDireccion(string DIreccion)
        {
            Direccion = DIreccion;
        }
        public void SetCorreoElectronico(string COrreoElectronico)
        {
            CorreoElectronico = COrreoElectronico;
        }
        public void SetTelefono(string TElefono)
        {
            Telefono = TElefono;
        }
        public void SetDiasDeAtencion(string DIasDeAtencion)
        {
            DiasDeAtencion = DIasDeAtencion;
        }
        public void SetActivo(bool ACtivo)
        {
            Activo = ACtivo;
        }

        ////////////geters////////////////
        public string GetIdMedico()
        {
            return Id_Medico;
        }
        public string GetIdEspecialidad()
        {
            return Id_Especialidad;
        }
        public string GetIdLocalidad()
        {
            return Id_Locadidad;
        }
        public string GetLegajo()
        {
            return Legajo;
        }
        public string GetDni()
        {
            return Dni;
        }
        public string GetNombre()
        {
            return Nombre;
        }
        public string GetApellido()
        {
            return Apellido;
        }
        public string GetSexo()
        {
            return Sexo;
        }
        public string GetNacionalidad()
        {
            return Nacionalidad;
        }
        public DateTime GetFechaDeNacimiento()
        {
            return FechaDeNacimiento;
        }
        public string GetDireccion()
        {
            return Direccion;
        }
        public string GetCorreoElectronico()
        {
            return CorreoElectronico;
        }
        public string GetTelefono()
        {
            return Telefono;
        }
        public string GetDiasDeAtencion()
        {
            return DiasDeAtencion;
        }
        public bool GetActivo()
        {
            return Activo;
        }

    }
}

