using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vistas
{
    public partial class MenuMedicos : System.Web.UI.Page
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

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMLMedicos.aspx");
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            Response.Redirect("BajaMedico.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarMedico.aspx");
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarMedicos.aspx");
        }
    }
}