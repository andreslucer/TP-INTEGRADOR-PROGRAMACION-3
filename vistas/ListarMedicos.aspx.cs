using Negocio;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vistas
{
    public partial class ListarMedicos : System.Web.UI.Page
    {
        NegClinica neg = new NegClinica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Mantenemos tu asignación de nombre de usuario de la sesión
                var nombre = Session["usuarioNombre"] as string;
                lblUsuario.Text = !string.IsNullOrEmpty(nombre) ? "Usuario: " + nombre : "Usuario: Sin Loguear";
                
                ViewState["FiltroMedico"] = "";
                cargarGrilla();
            }
        }

        private void cargarGrilla()
        {
            string filtro = ViewState["FiltroMedico"].ToString();
            gvMedicos.DataSource = neg.listarMedicos(filtro);
            gvMedicos.DataBind();
        }

        protected void gvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedicos.PageIndex = e.NewPageIndex;
            cargarGrilla();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string apellidoIngresado = txtBuscarApellido.Text.Trim();

            // 2. Si está vacío, limpiamos el filtro y cargamos todos
            if (string.IsNullOrEmpty(apellidoIngresado))
            {
                ViewState["FiltroMedico"] = "";
                gvMedicos.PageIndex = 0;
                lblactivo.Text = "";
                cargarGrilla();
                return; 
            }

            // 3. Validamos que TODOS los caracteres sean letras o espacios en blanco
            // char.IsLetter acepta automáticamente letras con tildes (á, é) y la ñ.
            bool esSoloLetras = apellidoIngresado.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));

            if (esSoloLetras)
            {
                ViewState["FiltroMedico"] = apellidoIngresado;
                gvMedicos.PageIndex = 0;
                lblactivo.Text = "";
                cargarGrilla();
            }
            else
            {
                lblactivo.Text = "Error: El apellido solo debe contener letras.";
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscarApellido.Text = string.Empty;
            ViewState["FiltroMedico"] = "";
            gvMedicos.PageIndex = 0;
            lblactivo.Text = "";
            cargarGrilla();
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            string legajo = txtBuscarApellido.Text.Trim();
            int validacionDesechable;
            if (int.TryParse(legajo, out validacionDesechable))
            {
                bool activo = neg.activarMedico(legajo);

                if (activo)
                {
                    lblactivo.Text = "ACTIVADO CORRECTAMENTE";
                }
                else
                {
                    lblactivo.Text = "No se encontró el médico o ya estaba activo.";
                }
            }
            else
            {
                // Si ingresó letras (ej: "A123") o lo dejó vacío, entra aquí:
                lblactivo.Text = "Error: Para activar debe ingresar solo el número de legajo.";
            }



        }
    }
}