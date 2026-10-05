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
    public class NegocioClinica
    {
        DaoClinica dao = new DaoClinica();
        /// CARGAR DDL/////
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
    }
}
