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
    public partial class Informes : System.Web.UI.Page
    {
        NegClinica neg = new NegClinica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Mantenemos tu asignación de nombre de usuario original (Pauta 2)
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

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnGenerarAsistencia_Click(object sender, EventArgs e)
        {
            // Validamos que se hayan ingresado ambas fechas antes de operar (Pauta 7)
            if (string.IsNullOrWhiteSpace(txtFechaDesde.Text) || string.IsNullOrWhiteSpace(txtFechaHasta.Text))
            {
                return;
            }

            DateTime fechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(txtFechaHasta.Text);

            // 1. Recuperamos cantidades absolutas de la base de datos
            int totalTurnos = neg.ContarxFecha(fechaDesde, fechaHasta);
            int cantidadPresentes = neg.PresentesXfecha(fechaDesde, fechaHasta);
            int cantidadAusentes = neg.Ausexfecha(fechaDesde, fechaHasta);

            // 2. Procesamos la información para calcular estadísticas y porcentajes (Pauta 12)
            if (totalTurnos > 0)
            {
                double porcPresentes = ((double)cantidadPresentes / totalTurnos) * 100;
                double porcAusentes = ((double)cantidadAusentes / totalTurnos) * 100;

                lbTotalTurnos.Text = totalTurnos.ToString();
                lbPresentes.Text = string.Format("{0} ({1:F1}%)", cantidadPresentes, porcPresentes);
                lbAusentes.Text = string.Format("{0} ({1:F1}%)", cantidadAusentes, porcAusentes);
            }
            else
            {
                lbTotalTurnos.Text = "0";
                lbPresentes.Text = "0 (0%)";
                lbAusentes.Text = "0 (0%)";
            }

            // Cargamos el listado de pacientes con ausencias
            cargarGrilla();
        }

        public void cargarGrilla()
        {
            DataTable dt = neg.PacientesAusentes();
            gvPacientesInforme.DataSource = dt; 
            gvPacientesInforme.DataBind(); 
        }

        protected void btnGenerarRanking_Click(object sender, EventArgs e)
        {
            // Validamos fechas del segundo reporte (Pauta 7)
            if (string.IsNullOrWhiteSpace(txtdesde.Text) || string.IsNullOrWhiteSpace(txtHasta.Text))
            {
                return;
            }

            CargarGrillaMedico();
            cantidadDeTurnos();
        }

        public void cantidadDeTurnos()
        {
            int Cant = neg.ContarMe(Convert.ToDateTime(txtdesde.Text), Convert.ToDateTime(txtHasta.Text)); 
            lbCantidadTurnos.Text = Cant.ToString();
        }

        public void CargarGrillaMedico()
        {
            DataTable dt = neg.MejMedico(Convert.ToDateTime(txtdesde.Text), Convert.ToDateTime(txtHasta.Text)); 
            
            if (dt != null && dt.Rows.Count > 0)
            {
                gvMedicosRanking.DataSource = dt; 
                gvMedicosRanking.DataBind();
                lbMejorMedico.Text = dt.Rows[0]["NombreCompleto"].ToString();
            }
            else
            {
                gvMedicosRanking.DataSource = null;
                gvMedicosRanking.DataBind();
                lbMejorMedico.Text = "-";
            }
        }

        protected void btnLimpiarAsistencia_Click(object sender, EventArgs e)
        {
            // CORRECCIÓN: Las fechas se limpian con string vacío, no con "0" que rompe el control de HTML5
            txtFechaDesde.Text = string.Empty;
            txtFechaHasta.Text = string.Empty;
            lbTotalTurnos.Text = "0"; 
            lbAusentes.Text = "0"; 
            lbPresentes.Text = "0"; 
            gvPacientesInforme.DataSource = null;
            gvPacientesInforme.DataBind();
        }

        protected void btnLimpiarInformes_Click(object sender, EventArgs e)
        {
            // Limpieza integral de todos los controles de la pantalla (Pauta 11)
            txtFechaDesde.Text = string.Empty;
            txtFechaHasta.Text = string.Empty;
            lbTotalTurnos.Text = "0"; 
            lbAusentes.Text = "0"; 
            lbPresentes.Text = "0"; 
            txtdesde.Text = string.Empty;
            txtHasta.Text = string.Empty;
            lbCantidadTurnos.Text = "0"; 
            lbMejorMedico.Text = "-";
            gvPacientesInforme.DataSource = null;
            gvPacientesInforme.DataBind();
            gvMedicosRanking.DataSource = null;
            gvMedicosRanking.DataBind(); 
        }

        protected void btnLimpiarRanking_Click(object sender, EventArgs e)
        {
            txtdesde.Text = "";
            txtHasta.Text = "";
        }
    }
}