using Negocio;
using System;
using Entidades;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vistas
{
    public partial class ModificarMedico : Page
    {
        NegClinica neg = new NegClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
                // Asegurar que el CompareValidator compare strings
                if (cvContraseñas != null)
                {
                    cvContraseñas.Operator = ValidationCompareOperator.Equal;
                    cvContraseñas.Type = ValidationDataType.String;
                }
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

        private void CargarLocalidades()
        {
            string seleccionado = ddlProvincia.SelectedValue;
            ddlLocalidad.DataSource = neg.listarLocalidades(seleccionado);
            ddlLocalidad.DataTextField = "Localidad";
            ddlLocalidad.DataValueField = "Id_Localidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }
        private void CargarProvincias()
        {
            ddlProvincia.DataSource = neg.listarProvincias();
            ddlProvincia.DataTextField = "Provincia";
            ddlProvincia.DataValueField = "Id_Provincia";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }
        private void cargarEspecialidaes()
        {
            ddlEspecialidad.DataSource = neg.listarEspecialidades();
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "Id_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));

        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades();
            if (Session["medicoOriginal"] != null)
            {
                pnlFormulario.Visible = true;
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = string.Empty;
            var legajo = tbBuscarLegajo.Text?.Trim();
            if (string.IsNullOrEmpty(legajo))
            {
                lblMensajeError.Text = "Ingrese un legajo.";
                pnlFormulario.Visible = false;
                return;
            }

            System.Data.DataTable dtMedico = neg.ListarPorLegajo(legajo);
            if (dtMedico.Rows.Count == 0)
            {
                lblMensajeError.Text = "Legajo no encontrado.";
                pnlFormulario.Visible = false;
                return;
            }

            pnlFormulario.Visible = true;

            System.Data.DataRow fila = dtMedico.Rows[0];
         
            tbLegajo.Text = fila["Legajo"].ToString();
            tbDNI.Text = fila["Dni"].ToString();
            tbNombre.Text = fila["nombre"].ToString();
            tbApellido.Text = fila["apellido"].ToString();
            tbSexo.Text = fila["sexo"].ToString();
            tbNacionalidad.Text = fila["nacionalidad"].ToString();
            tbDireccion.Text = fila["direccion"].ToString();
            tbEmail.Text = fila["correo_electronico"].ToString();
            tbTelefono.Text = fila["telefono"].ToString();
            if (fila["Fecha_de_nacimiento"] != DBNull.Value)
            {
                DateTime fecha = Convert.ToDateTime(fila["Fecha_de_nacimiento"]);
                tbFechaDeNacimiento.Text = fecha.ToString("yyyy-MM-dd");
            }
            
            string idProvincia = fila["Id_Lo_Provincia"].ToString();
            if (ddlProvincia.Items.FindByValue(idProvincia) != null)
            {
                ddlProvincia.SelectedValue = idProvincia;
            }

            CargarLocalidades();
            string idLocalidad = fila["Id_M_Localidad"].ToString();
            if (ddlLocalidad.Items.FindByValue(idLocalidad) != null)
            {
                ddlLocalidad.SelectedValue = idLocalidad;
            }
            cargarEspecialidaes();
            string idEspecialidad = fila["Id_M_Especialidad"].ToString();
            if (ddlEspecialidad.Items.FindByValue(idEspecialidad) != null)
            {
                ddlEspecialidad.SelectedValue = idEspecialidad;
            }

            cblDias.ClearSelection();
            string diasGuardados = fila["DiasDeAtencion"].ToString();
            foreach (ListItem item in cblDias.Items)
            {
                if (diasGuardados.Contains(item.Text))
                {
                    item.Selected = true;
                }
            }
              Medicos medicoOriginal = new Medicos();
    medicoOriginal.SetLegajo(fila["Legajo"].ToString());
    medicoOriginal.SetDni(fila["Dni"].ToString());
    medicoOriginal.SetNombre(fila["nombre"].ToString());
    medicoOriginal.SetApellido(fila["apellido"].ToString());
    medicoOriginal.SetSexo(fila["sexo"].ToString());
    medicoOriginal.SetNacionalidad(fila["nacionalidad"].ToString());
    medicoOriginal.SetDireccion(fila["direccion"].ToString());
    medicoOriginal.SetCorreoElectronico(fila["correo_electronico"].ToString());
    medicoOriginal.SetTelefono(fila["telefono"].ToString());
    medicoOriginal.SetFechaDeNacimiento(Convert.ToDateTime(fila["Fecha_de_nacimiento"]));
    medicoOriginal.SetId_Localidad(fila["Id_M_Localidad"].ToString());
    medicoOriginal.SetId_Especialidad(fila["Id_M_Especialidad"].ToString());
    medicoOriginal.SetDiasDeAtencion(fila["DiasDeAtencion"].ToString());

    Session["medicoOriginal"] = medicoOriginal;
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = string.Empty;
            if (!Page.IsValid)
            {
                lblMensajeError.Text = "Corrija los errores del formulario.";
                return;
            }

            if (tbContrasena.Text != tbRepetirContrasena.Text)
            {
                lblMensajeError.Text = "Las contraseñas no coinciden.";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tbTelefono.Text, @"^\d+$"))
            {
                lblMensajeError.Text = "Teléfono inválido.";
                return;
            }

            bool DiaSeleccionado = false;
            string diasAtencion = "";

            foreach (ListItem dia in cblDias.Items)
            {
                if (dia.Selected)
                {
                    DiaSeleccionado = true;
                    diasAtencion += dia.Text + ", ";
                }
            }
            if (!DiaSeleccionado)
            {
                lblMensajeError.Text = "Seleccione al menos un día de disponibilidad";
                return;
            }
            diasAtencion = diasAtencion.TrimEnd(',', ' ');

            Entidades.Medicos medicoModificado = new Entidades.Medicos();

            medicoModificado.SetLegajo(tbLegajo.Text);
            medicoModificado.SetDni(tbDNI.Text);
            medicoModificado.SetNombre(tbNombre.Text);
            medicoModificado.SetApellido(tbApellido.Text);
            medicoModificado.SetSexo(tbSexo.Text);
            medicoModificado.SetNacionalidad(tbNacionalidad.Text);
            medicoModificado.SetDireccion(tbDireccion.Text);
            medicoModificado.SetCorreoElectronico(tbEmail.Text);
            medicoModificado.SetTelefono(tbTelefono.Text);
            medicoModificado.SetFechaDeNacimiento(Convert.ToDateTime(tbFechaDeNacimiento.Text));
            medicoModificado.SetId_Localidad(ddlLocalidad.SelectedValue);
            medicoModificado.SetId_Especialidad(ddlEspecialidad.SelectedValue);
            medicoModificado.SetDiasDeAtencion(diasAtencion);

            Medicos medicoOriginal = Session["medicoOriginal"] as Medicos;

            if (medicoOriginal == null)
            {
                lblMensajeError.Text = "Error: no se encontró el médico original. Busque nuevamente.";
                return;
            }

            bool ok = neg.modificarMedico(medicoModificado, medicoOriginal);

            if (ok)
            {
                lblMensajeError.ForeColor = Color.DarkGreen;
                lblMensajeError.Text = "Cambios guardados correctamente.";
                Session["medicoOriginal"] = null;
            }
            else
            {
                lblMensajeError.ForeColor = Color.Red;
                lblMensajeError.Text = "Error al guardar los cambios.";
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            tbBuscarLegajo.Text = string.Empty;
            pnlFormulario.Visible = false;
            lblMensajeError.Text = string.Empty;
        }
    }
}