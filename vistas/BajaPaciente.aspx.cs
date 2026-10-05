using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace vistas
{
    public partial class BajaPaciente : System.Web.UI.Page
    {
        //Capa de negocio
        NegClinica nC = new NegClinica();

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

        public void cargarGrilla()
        {
            //Listado con datos de la base
            DataTable dt = nC.PacientesActivos();
            gvPacientes.DataSource = dt;
            gvPacientes.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = TxtDniBaja.Text;
            lblMensaje.Text = "";
            CargarDatosPaciente(dni);
        }

        private void CargarDatosPaciente(string dni)
        {
            // Buscamos el paciente para mostrar sus datos
            DataTable dt = nC.listarPacientes();
            DataRow[] pacienteEncontrado = dt.Select("DNI = '" + dni + "'");

            if (pacienteEncontrado.Length > 0)
            {
                lblNombre.Text = pacienteEncontrado[0]["nombre"].ToString();
                lblApellido.Text = pacienteEncontrado[0]["apellido"].ToString();
                pnlDetalles.Visible = true;
                lblMensaje.Text = "";
            }
            else
            {
                pnlDetalles.Visible = false;
                lblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                lblMensaje.Text = "No se encontró ningún paciente con ese DNI.";
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            string dni = TxtDniBaja.Text;

            //Baja lógica (Update activo = 0) a través de la capa de Negocio
            bool exito = nC.EstadoPaciente(dni);

            if (exito)
            {
                //Mensaje de confirmación
                lblmensajeee.ForeColor = System.Drawing.Color.DarkGreen;
                lblmensajeee.Text = "Paciente dado de baja correctamente.";
                LimpiarControles();
                cargarGrilla(); // Refrescamos el listado
            }
            else
            {
                lblmensajeee.ForeColor = System.Drawing.Color.DarkRed;
                lblmensajeee.Text = "Error: No se pudo realizar la baja lógica.";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            //Limpieza de controles tras realizar cambios
            TxtDniBaja.Text = "";
            lblNombre.Text = "";    
            lblApellido.Text = "";
        }

            //Manejo del evento de paginación
        protected void gvPacientes_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvPacientes.PageIndex = e.NewPageIndex;
            cargarGrilla();
        }
    }
}