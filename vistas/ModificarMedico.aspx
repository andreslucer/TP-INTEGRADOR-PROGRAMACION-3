<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="vistas.ModificarMedico" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificar Médico</title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style23 {
            width: 203px;
        }
        /* Una línea sutil para separar el buscador del formulario */
        .separador {
            border-top: 1px solid #ccc;
            margin: 20px 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" 
                style="position: absolute; top: 15px; right: 20px; font-weight: 700;">
            </asp:Label>
            
            <h2 style="margin-top: 10px; margin-bottom: 20px; text-align: center;">Modificar un Médico</h2>

            <div style="text-align: center; margin-bottom: 20px;">
                <asp:Label ID="lblBuscarLegajo" runat="server" Text="Ingrese el Legajo:" Font-Bold="True" Font-Size="12pt"></asp:Label>
                &nbsp;
                <asp:TextBox ID="tbBuscarLegajo" runat="server" Width="150px"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CausesValidation="False" OnClick="btnBuscar_Click" />
                <br />
                <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red" style="display:block; margin-top:10px;"></asp:Label>
            </div>

            <asp:Panel ID="pnlFormulario" runat="server" Visible="False">
                
                <div class="separador"></div>

                <div class="contenedor-formulario" style="display: flex; gap: 50px; background-color: transparent; box-shadow: none; padding: 0;">
                    
                    <div style="text-align: left;">
                        <table class="auto-style1">
                            <tr>
                                <td colspan="2" style="padding-bottom: 10px;">
                                    <asp:Label ID="lblDatosPersonales" runat="server" Text="Datos Personales" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblLegajo" runat="server" Text="Legajo:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbLegajo" runat="server" ReadOnly="True" BackColor="#E9ECEF" MaxLength="10"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblDNI" runat="server" Text="DNI:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbDNI" runat="server" ReadOnly="True" BackColor="#E9ECEF" MaxLength="10"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbNombre" runat="server" MaxLength="15"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbNombre" ErrorMessage="* Este campo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbApellido" runat="server" MaxLength="15"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="tbApellido" ErrorMessage="* Este campo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbSexo" runat="server" MaxLength="10"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="tbSexo" ErrorMessage="* Este campo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbNacionalidad" runat="server" MaxLength="15"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvNAcionalidad" runat="server" ControlToValidate="tbNacionalidad" ErrorMessage="* Este campo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbFechaDeNacimiento" runat="server" TextMode="Date"></asp:TextBox></td>
                            </tr>
                            
                            <tr><td colspan="2">&nbsp;</td></tr>

                            <tr>
                                <td colspan="2" style="padding-bottom: 10px;">
                                    <asp:Label ID="lblContactosUbicacion" runat="server" Text="Contactos y Ubicación" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbDireccion" runat="server" MaxLength="15"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="tbDireccion" ErrorMessage="*Este campo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label></td>
                                <td class="auto-style23">
                                    <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="* Seleccione un valor" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label></td>
                                <td class="auto-style23">
                                    <asp:DropDownList ID="ddlLocalidad" runat="server">
                                        <asp:ListItem>- Seleccionar -</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ErrorMessage="* Seleccione un valor" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblMail" runat="server" Text="E-Mail:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbEmail" runat="server" MaxLength="20"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="* Este campo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="* Formato de mail inválido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label></td>
                                <td class="auto-style23"><asp:TextBox ID="tbTelefono" runat="server" MaxLength="15"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="tbTelefono" ErrorMessage="* Este campo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div style="text-align: left;">
                        <table class="auto-style1">
                            <tr>
                                <td colspan="2" style="padding-bottom: 10px; display: flex; justify-content: space-between;">
                                    <asp:Label ID="lblEspecialidadyDisponibilidad" runat="server" Text="Especialidad y Disponibilidad" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;"><asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlEspecialidad" runat="server">
                                        <asp:ListItem>- Seleccionar -</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="* Seleccione un valor" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;"><asp:Label ID="lblDias" runat="server" Text="Días:"></asp:Label></td>
                                <td>
                                    <asp:CheckBoxList ID="cblDias" runat="server">
                                        <asp:ListItem>Domingo</asp:ListItem>
                                        <asp:ListItem>Lunes</asp:ListItem>
                                        <asp:ListItem>Martes</asp:ListItem>
                                        <asp:ListItem>Miércoles</asp:ListItem>
                                        <asp:ListItem>Jueves</asp:ListItem>
                                        <asp:ListItem>Viernes</asp:ListItem>
                                        <asp:ListItem>Sábado</asp:ListItem>
                                    </asp:CheckBoxList>
                                   
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblHorarios" runat="server" Text="Horarios:"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlHorarios" runat="server">
                                        <asp:ListItem Value="0">- Seleccionar Turno -</asp:ListItem>
                                        <asp:ListItem Value="1">Mañana (08:00 a 12:00)</asp:ListItem>
                                        <asp:ListItem Value="2">Tarde (12:00 a 16:00)</asp:ListItem>
                                        <asp:ListItem Value="3">Noche (16:00 a 20:00)</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvHorarios" runat="server" ControlToValidate="ddlHorarios" ErrorMessage="* Seleccione un valor" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr><td colspan="2">&nbsp;</td></tr>

                            <tr>
                                <td colspan="2" style="padding-bottom: 10px;">
                                    <asp:Label ID="lblDatosDeAcceso" runat="server" Text="Datos de Acceso" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblUsuarioAcceso" runat="server" Text="Usuario:"></asp:Label></td>
                                <td><asp:TextBox ID="tbUsuario" runat="server" MaxLength="20"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="tbUsuario" ErrorMessage="* Este campo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label></td>
                                <td><asp:TextBox ID="tbContrasena" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="tbContrasena" ErrorMessage="* Este campo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblRepetirContrasena" runat="server" Text="Repetir Contraseña:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="tbRepetirContrasena" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>

                                    <br />

                                    <asp:CompareValidator ID="cvContraseñas" runat="server" 
                                    ControlToValidate="tbRepetirContrasena" 
                                    ControlToCompare="tbContrasena" 
                                    ErrorMessage="* Las contraseñas no coinciden" 
                                    ForeColor="Red"></asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div style="text-align: center; margin-top: 30px;">
                    <asp:Button ID="btnModificar" runat="server" Text="Guardar Cambios" OnClick="btnModificar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CausesValidation="False" OnClick="btnVolver_Click" />
                </div>
            </asp:Panel>

            <div style="text-align: center; margin-top: 20px;">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/MenuMedicos.aspx" Font-Bold="True" CausesValidation="False" />
            </div>

        </div>
    </form>
</body>
</html>