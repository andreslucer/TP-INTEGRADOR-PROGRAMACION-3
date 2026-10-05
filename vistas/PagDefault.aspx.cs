using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vistas
{
    public partial class PagDefault : System.Web.UI.Page
    {
        NegClinica NM = new NegClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["usuario"] != null)
                //{
                //    Response.Redirect("PagPrincipal.aspx");
                //}
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarUSUARIO() == 1)
            {
                Session["usuarioNombre"] = txtUsuario.Text;
                Response.Redirect("MenuAdministrador.aspx");
            }
            else if (ValidarMedico() == 1)
            {
                Session["usuarioNombre"] = txtUsuario.Text;
                Response.Redirect("TurnosAsignados.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
                txtUsuario.Text = string.Empty;
                txtContrasena.Text = string.Empty;
            }
        }

        public int ValidarUSUARIO()
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContrasena.Text;

            DataTable dt = NM.ObtenerUSUARIOADMIN(usuario, contraseña);

            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return 0;


        }

        public int ValidarMedico()
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContrasena.Text;

            DataTable dt = NM.obtenerUsuarioMedico(usuario, contraseña);

            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }


    }
}