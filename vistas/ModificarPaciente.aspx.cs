using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace vistas
{
    public partial class ModificarPaciente : System.Web.UI.Page
    {
        NegClinica neg = new NegClinica();
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

                CargarProvincias();
            }
        }

        private void CargarProvincias()
        {
            ddlProvincia.DataSource = neg.listarProvincias();
            ddlProvincia.DataTextField = "Provincia";
            ddlProvincia.DataValueField = "Id_Provincia";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione Provincia--", ""));
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string provSeleccionada = ddlProvincia.SelectedValue;
            ddlLocalidad.DataSource = neg.listarLocalidades(provSeleccionada);
            ddlLocalidad.DataTextField = "Localidad";
            ddlLocalidad.DataValueField = "Id_localidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione Localidad--", ""));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Limpiamos mensajes previos y ocultamos el formulario por seguridad
            lblMensajeError.Text = string.Empty;
            lblMensajeError.ForeColor = System.Drawing.Color.Red;
            pnlFormulario.Visible = false;

            string dni = tbBuscarDni.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                lblMensajeError.Text = "Por favor, ingrese un DNI.";
                return;
            }

            try
            {
                // Llamamos a la capa de negocio para hacer la consulta SQL
                DataTable dt = neg.buscarPacientesPorDni(dni);

                // Validamos la tabla no sea nula y contenga al menos un registro
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];

                    // si encontramos un paciente activo, mostramos el formulario para modificarlo
                    pnlFormulario.Visible = true;

                    // cargamos los datos del paciente en los controles de la página
                    tbDni.Text = fila["DNI"].ToString();
                    tbNombre.Text = fila["nombre"].ToString();
                    tbApellido.Text = fila["apellido"].ToString();
                    tbSexo.Text = fila["sexo"].ToString();
                    tbNacionalidad.Text = fila["nacionalidad"].ToString();

                    // Formateo de la fecha de nacimiento para que sea compatible con el control de fecha
                    if (fila["fecha_de_nacimiento"] != DBNull.Value)
                    {
                        DateTime fechaNac = Convert.ToDateTime(fila["fecha_de_nacimiento"]);
                        tbFechaNac.Text = fechaNac.ToString("yyyy-MM-dd");
                    }

                    tbDireccion.Text = fila["direccion"].ToString();
                    tbEmail.Text = fila["correo_electronico"].ToString();
                    tbTelefono.Text = fila["telefono"].ToString();

                    // Preselección de la Provincia y Localidad 
                    string idProvincia = fila["Id_Lo_Provincia"].ToString();
                    string idLocalidad = fila["Id_P_Localidad"].ToString();

                    if (ddlProvincia.Items.FindByValue(idProvincia) != null)
                    {
                        ddlProvincia.SelectedValue = idProvincia;

                        // cargamos las localidades correspondientes a la provincia seleccionada
                        ddlLocalidad.DataSource = neg.listarLocalidades(idProvincia);
                        ddlLocalidad.DataTextField = "Localidad";
                        ddlLocalidad.DataValueField = "Id_Localidad";
                        ddlLocalidad.DataBind();

                        if (ddlLocalidad.Items.FindByValue(idLocalidad) != null)
                        {
                            ddlLocalidad.SelectedValue = idLocalidad;
                        }
                    }
                }
                else
                {
                    // Si rows es 0, mostramos el error en pantalla sin romper la página
                    lblMensajeError.Text = "No se encontró ningún paciente activo con el DNI ingresado.";
                }
            }
            catch (Exception ex)
            {
                // En caso de cualquier error imprevisto con la BD, lo capturamos acá
                lblMensajeError.Text = "Ocurrió un error al procesar la búsqueda. Verifique el formato del DNI.";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = string.Empty;

            if (ddlLocalidad.SelectedValue == "0" || ddlProvincia.SelectedValue == "0")
            {
                lblMensajeError.Text = "Por favor, seleccione una provincia y localidad.";
                return;
            }

            // Validar que los campos obligatorios no estén vacíos
            Pacientes pac = new Pacientes();
            pac.SetDni(tbDni.Text);
            pac.SetNombre(tbNombre.Text);
            pac.SetApellido(tbApellido.Text);
            pac.SetSexo(tbSexo.Text);
            pac.SetNacionalidad(tbNacionalidad.Text);
            pac.SetFecha_de_nacimiento(Convert.ToDateTime(tbFechaNac.Text));
            pac.SetDireccion(tbDireccion.Text);
            pac.SetId_P_Localidad(ddlLocalidad.SelectedValue);
            pac.SetCorreo_electronico(tbEmail.Text);
            pac.SetTelefono(tbTelefono.Text);

            bool exito = neg.modificarPaciente(pac);
            if (exito)
            {
                // Mostrar mensaje de éxito y limpiar campos
                pnlFormulario.Visible = false;
                tbBuscarDni.Text = string.Empty;
                lblMensajeError.ForeColor = System.Drawing.Color.Green;
                lblMensajeError.Text = "Paciente modificado exitosamente.";
            }
            else
            {
                lblMensajeError.ForeColor = System.Drawing.Color.Red;
                lblMensajeError.Text = "Error al modificar el paciente. Por favor, intente nuevamente.";
            }
        }
    }
}