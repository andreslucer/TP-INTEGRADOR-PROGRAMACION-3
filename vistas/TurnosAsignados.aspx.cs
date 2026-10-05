using Entidades;
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
    public partial class TurnosAsignados : System.Web.UI.Page
    {
        NegClinica nC = new NegClinica();
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
                cargarGrilla(nombre);
            }
        }

        protected void gvInformes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void cargarGrilla(string medico)
        {

            DataTable dt = nC.ObteUsu(medico);
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();

        }

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensajeAtencion.Text = string.Empty;
            // Obtenemos el ID del turno de la fila seleccionada usando DataKeys
            string idTurno = gvTurnos.SelectedValue.ToString();
            lblNroTurnoSeleccionado.Text = idTurno;

            pnlGestionarTurno.Visible = true;
            tbObservacion.Text = string.Empty;
            ddlAsistencia.SelectedIndex = 0;
        }

        protected void btnGuardarAtencion_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(lblNroTurnoSeleccionado.Text);
            bool vinoPaciente = ddlAsistencia.SelectedValue == "1";
            string observacion = tbObservacion.Text.Trim();

            bool exito = nC.RegistrarAsistenciaTurno(idTurno, vinoPaciente, observacion);

            if (exito)
            {
                pnlGestionarTurno.Visible = false;
                lblMensajeAtencion.Text = "Atención registrada de forma exitosa.";

                // Recargamos la grilla para reflejar los cambios
                string nombre = Session["usuarioNombre"] as string;
                cargarGrilla(nombre);
            }
            else
            {
                lblMensajeAtencion.ForeColor = System.Drawing.Color.Red;
                lblMensajeAtencion.Text = "Error al intentar guardar los datos.";
            }
        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            // 1. Ocultamos el panel de gestión
            pnlGestionarTurno.Visible = false;

            // 2. Limpiamos cualquier mensaje de error o éxito anterior
            lblMensajeAtencion.Text = string.Empty;

            tbObservacion.Text = string.Empty;
            ddlAsistencia.SelectedIndex = 0;
        }
    }
}