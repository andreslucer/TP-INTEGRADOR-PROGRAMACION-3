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
    public partial class BajaMedico : System.Web.UI.Page
    {
        NegClinica nC  = new NegClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrilla();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Aquí debería ir la lógica para buscar el médico por legajo.
            // Por ahora se muestra un ejemplo simulado.
            pnlDetalles.Visible = true;
            lblMensaje.Text = "";
            // Simular datos encontrados
            cargarGrillaLegajo();


        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            string leg = tbLegajo.Text;
            bool eliminar = nC.EstadoMedico( leg);
            if(eliminar == true)
            {
                pnlDetalles.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.DarkGreen;
                lblMensaje.Text = "Médico dado de baja correctamente.";
                cargarGrilla();
            }
            else
            {

                pnlDetalles.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                lblMensaje.Text = "No se pudo dar de baja!.";
                cargarGrilla();
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbLegajo.Text = string.Empty; //string.Empty; Es un campo de solo lectura que ya viene incorporado en el lenguaje C#
            pnlDetalles.Visible = false;
            lblMensaje.Text = string.Empty;
            cargarGrilla();
        }

        public void cargarGrilla()
        {
            pnlDetalles.Visible = true;
            DataTable dt = nC.MostrarActivos();
            gvMedicos.DataSource = dt;
            gvMedicos.DataBind();
            lblNombre.Visible = false;
            lblApellido.Visible = false;
        }

        public void cargarGrillaLegajo()
        {
            string legajo = tbLegajo.Text;
            pnlDetalles.Visible = true;
            DataTable dt = nC.ListarPorLegajo(legajo);
            gvMedicos.DataSource = dt;
            gvMedicos.DataBind();


        }

        protected void gvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedicos.PageIndex = e.NewPageIndex;
            cargarGrilla();
        }
    }
}