using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vistas
{
    public partial class SesionAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var nombre = Session["usuarioNombre"] as string;
                if (!string.IsNullOrEmpty(nombre))
                {
                    lblUsuario.Text = "Usuario: " + nombre;
                }
                else
                {
                    lblUsuario.Text = "Usuario: Sin Loguear";
                }
            }
        }

        protected void btnMedicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuMedicos.aspx");
        }

        protected void btnPacientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPacientes.aspx");
        }

        protected void btnTurnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaTurno.aspx");
        }

        protected void btnInformes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Informes.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {

        }
    }
}