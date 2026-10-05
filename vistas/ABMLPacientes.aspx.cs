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
    public partial class ABML_Pacientes : System.Web.UI.Page
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
                cargarProvincias();
            }
        }

        private bool EsSoloLetras(string texto)
        {
            // Si el campo está vacío, lo damos como inválido
            if (string.IsNullOrWhiteSpace(texto)) return false;

            // Revisa que CADA letra sea una letra del abecedario o un espacio en blanco
            return texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            lblErrorAgregar.Text = "";
            lblAgregarPaciente.Text = "";
            string nombre = TxtBoxNombrePaciente.Text.Trim();
            string apellido = TxtBoxApellidoPaciente.Text.Trim();
            string sexo = TxtBoxSexoPaciente.Text.Trim();
            string nacionalidad = TxtBoxNacionalidadPaciente.Text.Trim();
            if (!EsSoloLetras(nombre) || !EsSoloLetras(apellido) || !EsSoloLetras(sexo) || !EsSoloLetras(nacionalidad))
            {
                lblmensaje.Text = "Error: El Nombre, Apellido, Sexo y Nacionalidad solo pueden contener letras.";
                lblmensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 1. Validamos que los selectores de Provincia y Localidad no estén en la opción por defecto (Pauta 7)
            if (DropDownProvinciaPaciente.SelectedValue == "0" || DropDownLocalidadPaciente.SelectedValue == "0")
            {
                lblErrorAgregar.Text = "Debe seleccionar una Provincia y una Localidad válidas.";
                return;
            }

            // 2. Validamos que los campos de texto obligatorios no estén vacíos o con espacios (Pauta 7)
            if (string.IsNullOrWhiteSpace(TxtBoxDniPaciente.Text) ||
                string.IsNullOrWhiteSpace(TxtBoxNombrePaciente.Text) ||
                string.IsNullOrWhiteSpace(TxtBoxApellidoPaciente.Text) ||
                string.IsNullOrWhiteSpace(TxtBoxDireccionPaciente.Text) ||
                string.IsNullOrWhiteSpace(TxtBoxMailPaciente.Text) ||
                string.IsNullOrWhiteSpace(TxtBoxTelefonoPaciente.Text))
            {
                lblErrorAgregar.Text = "Todos los campos de texto son obligatorios para el alta del paciente.";
                return;
            }

            // 3. Control de duplicados por DNI (Pauta 10)
            if (neg.ExisteDNIPaciente(TxtBoxDniPaciente.Text.Trim()))
            {
                lblErrorAgregar.Text = "El DNI ingresado ya corresponde a un paciente registrado.";
                return;
            }

            // 4. Control de duplicados por Email (Pauta 10)
            if (neg.ExisteEmailPaciente(TxtBoxMailPaciente.Text.Trim()))
            {
                lblErrorAgregar.Text = "El correo electrónico ingresado ya está siendo utilizado.";
                return;
            }

            // Procedemos al mapeo si pasó todas las validaciones previas
            Pacientes pac = new Pacientes();
            pac.SetDni(TxtBoxDniPaciente.Text.Trim());
            pac.SetNombre(TxtBoxNombrePaciente.Text.Trim());
            pac.SetApellido(TxtBoxApellidoPaciente.Text.Trim());
            pac.SetSexo(TxtBoxSexoPaciente.Text.Trim());
            pac.SetNacionalidad(TxtBoxNacionalidadPaciente.Text.Trim());
            pac.SetFecha_de_nacimiento(Convert.ToDateTime(TxtBoxFechaNacimientoPaciente.Text));
            pac.SetDireccion(TxtBoxDireccionPaciente.Text.Trim());
            pac.SetId_P_Localidad(DropDownLocalidadPaciente.SelectedValue);
            pac.SetCorreo_electronico(TxtBoxMailPaciente.Text.Trim());
            pac.SetTelefono(TxtBoxTelefonoPaciente.Text.Trim());
            pac.SetActivo(true);

            if (neg.agregarPaciente(pac))
            {
                lblAgregarPaciente.Text = "El paciente se ha agregado con éxito en la base de datos."; // Pauta 4
                LimpiarCampos(); // Pauta 11
            }
            else
            {
                lblErrorAgregar.Text = "Ocurrió un error inesperado al intentar dar de alta al paciente.";
            }
        }

        private void LimpiarCampos()
        {
            TxtBoxDniPaciente.Text = "";
            TxtBoxNombrePaciente.Text = "";
            TxtBoxApellidoPaciente.Text = "";
            TxtBoxSexoPaciente.Text = "";
            TxtBoxNacionalidadPaciente.Text = "";
            TxtBoxFechaNacimientoPaciente.Text = "";
            TxtBoxDireccionPaciente.Text = "";
            TxtBoxMailPaciente.Text = "";
            TxtBoxTelefonoPaciente.Text = "";

            DropDownProvinciaPaciente.SelectedIndex = 0;
            DropDownLocalidadPaciente.SelectedIndex = 0;

        }
        public void cargarProvincias()
        {
            DropDownProvinciaPaciente.DataSource = neg.listarProvincias();
            DropDownProvinciaPaciente.DataTextField = "Provincia";
            DropDownProvinciaPaciente.DataValueField = "Id_Provincia";
            DropDownProvinciaPaciente.DataBind();
            DropDownProvinciaPaciente.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }

        private void CargarLocalidades()
        {
            string seleccionado = DropDownProvinciaPaciente.SelectedValue;
            DropDownLocalidadPaciente.DataSource = neg.listarLocalidades(seleccionado);
            DropDownLocalidadPaciente.DataTextField = "Localidad";
            DropDownLocalidadPaciente.DataValueField = "Id_Localidad";
            DropDownLocalidadPaciente.DataBind();
            DropDownLocalidadPaciente.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }


        protected void btnLimpiarPaciente_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownProvinciaPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades();
        }
    }
}