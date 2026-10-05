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
    public partial class ABML_Medicos : System.Web.UI.Page
    {
        Medicos nuevoMedico = new Medicos();
        NegClinica neg = new NegClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
                cargarEspecialidaes();
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

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        public void limpiar()
        {
            tbLegajo.Text = "";
            tbDNI.Text = "";
            tbNombre.Text = "";
            tbApellido.Text = "";
            tbSexo.Text = "";
            tbNacionalidad.Text = "";
            tbFechaDeNacimientoMedico.Text = "";
            tbDireccion.Text = "";
            tbEmail.Text = "";
            tbTelefono.Text = "";
            tbUsuario.Text = "";
            tbContrasena.Text = "";
            tbRepetirContrasena.Text = "";
            lblCargaExitosa.Text = "";
            lblErrorDias.Text = "";
            ddlProvincia.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;
            cblDias.ClearSelection();
            ddlHorarios.SelectedIndex = 0;
            ddlLocalidad.Items.Clear();
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
        private void CargarLocalidades()
        {
            string seleccionado = ddlProvincia.SelectedValue;
            ddlLocalidad.DataSource = neg.listarLocalidades(seleccionado);
            ddlLocalidad.DataTextField = "Localidad";
            ddlLocalidad.DataValueField = "Id_Localidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }
        private void cargarEspecialidaes()
        {
            ddlEspecialidad.DataSource = neg.listarEspecialidades();
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "Id_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));

        }
        protected void ddlProvincia_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargarLocalidades();
        }
        private bool EsSoloLetras(string texto)
        {
            // Si el campo está vacío, lo damos como inválido
            if (string.IsNullOrWhiteSpace(texto)) return false;

            // Revisa que CADA letra sea una letra del abecedario o un espacio en blanco
            return texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblErrorDias.Text = "";
            lblCargaExitosa.Text = "";
            lblErrorGeneral.Text = "";
            // 1. Capturamos los textos (el Trim() quita espacios accidentales al inicio/fin)
            string nombre = tbNombre.Text.Trim();
            string apellido = tbApellido.Text.Trim();
            string sexo = tbSexo.Text.Trim();
            string nacionalidad = tbNacionalidad.Text.Trim();

            // 2. Validamos usando nuestra función auxiliar
            if (!EsSoloLetras(nombre) || !EsSoloLetras(apellido) || !EsSoloLetras(sexo) || !EsSoloLetras(nacionalidad))
            {
                lblMensaje.Text = "Error: El Nombre, Apellido, Sexo y Nacionalidad solo pueden contener letras.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

                bool faltanCampos = false;
                var textboxes = new TextBox[] {
                tbLegajo, tbDNI, tbNombre, tbApellido, tbSexo, tbNacionalidad,
                tbFechaDeNacimientoMedico, tbDireccion, tbEmail, tbTelefono,
                tbUsuario, tbContrasena, tbRepetirContrasena
            };
                foreach (var tb in textboxes)
                {
                    if (tb == null || string.IsNullOrWhiteSpace(tb.Text))
                        faltanCampos = true;
                }

                if (ddlProvincia.SelectedIndex == 0)
                {
                    faltanCampos = true;
                }
                if (ddlLocalidad.SelectedIndex == 0)
                {
                    faltanCampos = true;
                }
                if (ddlEspecialidad.SelectedIndex == 0)
                {
                    faltanCampos = true;
                }
                if (ddlHorarios.SelectedIndex == 0)
                {
                    faltanCampos = true;
                }

                if (faltanCampos)
                {
                    lblErrorGeneral.Text = "Faltan completar campos";
                    return;
                }

                if (!tbLegajo.Text.All(char.IsDigit))
                {
                    lblErrorGeneral.Text = "El Legajo debe contener únicamente números.";
                    return;
                }

                if (!tbDNI.Text.All(char.IsDigit))
                {
                    lblErrorGeneral.Text = "El DNI debe contener únicamente números.";
                    return;
                }

                if (!tbTelefono.Text.All(char.IsDigit))
                {
                    lblErrorGeneral.Text = "El Teléfono debe contener únicamente números.";
                    return;
                }

                DateTime fecha;
                if (!DateTime.TryParse(tbFechaDeNacimientoMedico.Text, out fecha) || fecha > DateTime.Today)
                {
                    lblErrorGeneral.Text = "Fecha de nacimiento inválida.";
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
                    lblErrorDias.Text = "Seleccione al menos un día de disponibilidad";
                    return;
                }
                diasAtencion = diasAtencion.TrimEnd(',', ' ');



                nuevoMedico.SetLegajo(tbLegajo.Text);
                nuevoMedico.SetDni(tbDNI.Text);
                nuevoMedico.SetNombre(tbNombre.Text);
                nuevoMedico.SetApellido(tbApellido.Text);
                nuevoMedico.SetSexo(tbSexo.Text);
                nuevoMedico.SetNacionalidad(tbNacionalidad.Text);
                nuevoMedico.SetDireccion(tbDireccion.Text);
                nuevoMedico.SetCorreoElectronico(tbEmail.Text);
                nuevoMedico.SetTelefono(tbTelefono.Text);
                nuevoMedico.SetFechaDeNacimiento(Convert.ToDateTime(tbFechaDeNacimientoMedico.Text));
                nuevoMedico.SetId_Localidad(ddlLocalidad.SelectedValue);
                nuevoMedico.SetId_Especialidad(ddlEspecialidad.SelectedValue);
                nuevoMedico.SetActivo(true);
                nuevoMedico.SetDiasDeAtencion(diasAtencion);

                if (neg.ExisteLegajo(tbLegajo.Text))
                {
                    lblErrorGeneral.Text = "El Legajo ingresado ya existe.";
                    return;
                }

                if (neg.ExisteDNI(tbDNI.Text))
                {
                    lblErrorGeneral.Text = "El DNI ingresado ya existe.";
                    return;
                }

                if (neg.ExisteEmail(tbEmail.Text))
                {
                    lblErrorGeneral.Text = "El correo electrónico ya existe.";
                    return;
                }

                if (neg.ExisteUsuario(tbUsuario.Text))
                {
                    lblErrorGeneral.Text = "El nombre de usuario ya está en uso.";
                    return;
                }

                bool exito = neg.agregarMedico(nuevoMedico);

                string usuario = tbUsuario.Text;
                string contraseña = tbContrasena.Text;
                string idCreado = nuevoMedico.GetIdMedico();
                bool est = neg.CrearCuentaMedicos(idCreado, usuario, contraseña);

                if (est == true)
                {
                    limpiar();
                    lblCargaExitosa.Text = "Medicos y cuentas agregados correctamente";
                    string script = "setTimeout(function() { document.getElementById('" + lblCargaExitosa.ClientID + "').style.display = 'none'; }, 2000);";

                    ClientScript.RegisterStartupScript(this.GetType(), "OcultarMensaje", script, true);
                }
                else
                {
                    lblCargaExitosa.Text = "Error no se pudo cargar";
                }
            }
        
    }
}