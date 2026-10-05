using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace vistas
{
    public partial class ListarPacientes : System.Web.UI.Page
    {
        NegClinica neg = new NegClinica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Conservamos tu validación de usuario (Pauta 2)
                var nombre = Session["usuarioNombre"] as string;
                lblUsuario.Text = !string.IsNullOrEmpty(nombre) ? "Usuario: " + nombre : "Usuario: Sin Loguear";
                
                // Guardamos un filtro vacío inicial
                ViewState["FiltroApellido"] = "";
                cargarGrilla();
            }
        }

        private void cargarGrilla()
        {
            // Recuperamos el estado del filtro guardado en la vista
            string filtro = ViewState["FiltroApellido"].ToString();

            // Pasamos el filtro a la capa de negocio (Pauta 3)
            gvInformes.DataSource = neg.listarPacientes(filtro);
            gvInformes.DataBind();
        }

        protected void gvInformes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Asignamos el nuevo índice de página (Pauta 3)
            gvInformes.PageIndex = e.NewPageIndex;
            cargarGrilla();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Al hacer clic en Filtrar, guardamos el texto de la caja en el ViewState
            string busqueda = txtBuscarApellido.Text.Trim();
            ViewState["FiltroApellido"] = busqueda;

            // Reiniciamos el índice de la grilla a la primera página por seguridad
            gvInformes.PageIndex = 0;
            cargarGrilla();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            // Limpiamos el cuadro de texto y el filtro del ViewState
            txtBuscarApellido.Text = string.Empty;
            ViewState["FiltroApellido"] = "";

            gvInformes.PageIndex = 0;
            cargarGrilla();
        }
        protected void btnActivar_Click(object sender, EventArgs e)
        {
            string dni = txtBuscarApellido.Text.Trim();
            int validacionDesechable;
            if (int.TryParse(dni, out validacionDesechable))
            {
                bool activo = neg.actPaciente(dni);

                if (activo)
                {
                    lblMensaje.Text = "ACTIVADO CORRECTAMENTE";
                    txtBuscarApellido.Text = "";
                    gvInformes.PageIndex = 0;
                    cargarGrilla();
                }
                else
                {
                    lblMensaje.Text = "No se encontró el médico o ya estaba activo.";
                    gvInformes.PageIndex = 0;
                    cargarGrilla();
                }
            }
            else
            {
                // Si ingresó letras (ej: "A123") o lo dejó vacío, entra aquí:
                lblMensaje.Text = "Error: Para activar debe ingresar solo el número de legajo.";
            }

        }
    }
}