using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vistas
{
    public partial class AltaTurno : System.Web.UI.Page
    {
        NegClinica neg = new NegClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarEspecialidades();
                cargarPacientes();
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
        
        private void cargarEspecialidades()
        {
            ddlEspecialidad.DataSource = neg.listarEspecialidades();
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "Id_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarMedicos(ddlEspecialidad.SelectedValue);
        }

        private void cargarMedicos(string idEspecialidad)
        {
            ddlMedico.Items.Clear();
            ddlMedico.DataSource = neg.listarNombresMedicos(idEspecialidad);
            ddlMedico.DataTextField = "NombreCompleto";
            ddlMedico.DataValueField = "Id_Medico";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }

        private void cargarPacientes()
        {
            ddlPaciente.DataSource = neg.listarNombresPacientes();
            ddlPaciente.DataTextField = "NombreCompleto";
            ddlPaciente.DataValueField = "Id_Pacientes";
            ddlPaciente.DataBind();
            ddlPaciente.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }

        public void Limpiar()
        {
            ddlEspecialidad.SelectedIndex = 0;

            ddlMedico.Items.Clear();
            ddlMedico.Items.Add(new ListItem("--Seleccionar--", "0"));

            ddlPaciente.SelectedIndex = 0;

            tbDiaTurno.Text = "";
            tbHorarioTurno.Text = "";
            tbComentarioTurno.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblConfirmacion.Visible = false;
            lblConfirmacion.ForeColor = System.Drawing.Color.Red; // Color de alerta por defecto

            Turnos nuevoTurno = new Turnos();
            nuevoTurno.SetId_T_Especialidad(ddlEspecialidad.SelectedValue);
            nuevoTurno.SetId_T_Medico(ddlMedico.SelectedValue);
            nuevoTurno.SetId_T_Id_Pacientes(ddlPaciente.SelectedValue);
            nuevoTurno.SetDia(Convert.ToDateTime(tbDiaTurno.Text));
            nuevoTurno.SetHorario(TimeSpan.Parse(tbHorarioTurno.Text));
            nuevoTurno.SetComentarios(tbComentarioTurno.Text);
            nuevoTurno.SetAsistencia(false);

            // Validación de fecha posterior (Regla de negocio)
            if (nuevoTurno.GetDia().Date < DateTime.Now.Date.AddDays(1))
            {
                lblConfirmacion.Text = "Ingrese una fecha válida (a partir de mañana).";
                lblConfirmacion.Visible = true;
                return;
            }

            // Validación de rango horario de la clínica
            TimeSpan inicio = new TimeSpan(8, 0, 0);
            TimeSpan cierre = new TimeSpan(20, 0, 0);
            if (nuevoTurno.GetHorario() < inicio || nuevoTurno.GetHorario() > cierre)
            {
                lblConfirmacion.Text = "El horario debe estar entre las 08:00 y las 20:00 hs.";
                lblConfirmacion.Visible = true;
                return;
            }

            // Intentamos agregar el turno a través de la capa de negocio
            bool exito = neg.agregarTurno(nuevoTurno);

            if (exito)
            {
                Limpiar(); // Limpieza total de controles (Pauta 11)
                lblConfirmacion.ForeColor = System.Drawing.Color.DarkGreen;
                lblConfirmacion.Text = "¡Turno asignado con éxito en la base de datos!"; // Pauta 4
                lblConfirmacion.Visible = true;
            }
            else
            {
                // Mensaje aclaratorio específico para duplicados (Pauta 4 y Pauta 10)
                lblConfirmacion.Text = "El médico seleccionado ya posee un turno asignado para ese día y horario.";
                lblConfirmacion.Visible = true;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}