<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLMedicos.aspx.cs" Inherits="vistas.ABML_Medicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style23 {
            width: 203px;
        }
        .auto-style24 {
            height: 35px;
        }
        .auto-style25 {
            height: 47px;
        }
        .auto-style26 {
            height: 43px;
        }
        .auto-style27 {
            width: 203px;
            height: 43px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" 
                style="position: absolute; top: 15px; right: 20px; font-weight: 700;"></asp:Label>
            <div class="contenedor-formulario" style="display: flex; gap: 50px; background-color: transparent; box-shadow: none; padding: 0;">
                
                <div style="text-align: left;">
                    <table class="auto-style1">
                        <tr>
                            <td colspan="2" style="padding-bottom: 10px;">
                                <asp:Label ID="lblDatosPersonalesPacientes0" runat="server" Text="Datos Personales" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style26"><asp:Label ID="lblLegajo" runat="server" Text="Legajo:"></asp:Label></td>
                            <td class="auto-style27"><asp:TextBox ID="tbLegajo" runat="server" MaxLength="4"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblDNI" runat="server" Text="DNI:"></asp:Label></td>
                            <td class="auto-style23"><asp:TextBox ID="tbDNI" runat="server" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
                            <td class="auto-style23"><asp:TextBox ID="tbNombre" runat="server" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label></td>
                            <td class="auto-style23"><asp:TextBox ID="tbApellido" runat="server" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label></td>
                            <td class="auto-style23"><asp:TextBox ID="tbSexo" runat="server" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:"></asp:Label></td>
                            <td class="auto-style23"><asp:TextBox ID="tbNacionalidad" runat="server" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento:"></asp:Label></td>
                            <td class="auto-style23"><asp:TextBox ID="tbFechaDeNacimientoMedico" runat="server" TextMode="Date"></asp:TextBox></td>
                        </tr>
                        
                        <tr><td colspan="2">&nbsp;</td></tr>

                        <tr>
                            <td colspan="2" style="padding-bottom: 10px;">
                                <asp:Label ID="lblContactosUbicacion" runat="server" Text="Contactos y Ubicación" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style26"><asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label></td>
                            <td class="auto-style27"><asp:TextBox ID="tbDireccion" runat="server" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label></td>
                            <td class="auto-style23">
                                <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged1">
                                    <asp:ListItem>- Seleccionar -</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label></td>
                            <td class="auto-style23">
                                <asp:DropDownList ID="ddlLocalidad" runat="server" >
                                    <asp:ListItem>- Seleccionar -</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblMail" runat="server" Text="E-Mail:"></asp:Label></td>
                            <td class="auto-style23"><asp:TextBox ID="tbEmail" runat="server" Height="50px" MaxLength="50"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="* Formato de mail inválido" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label></td>
                            <td class="auto-style23"><asp:TextBox ID="tbTelefono" runat="server" MaxLength="15"></asp:TextBox></td>
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
                                <asp:Label ID="lblErrorDias" runat="server" ForeColor="#CC0000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblHorarios" runat="server" Text="Horarios:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlHorarios" runat="server">
                                    <asp:ListItem>- Seleccionar Turno -</asp:ListItem>
                                    <asp:ListItem>Mañana (08:00 a 12:00)</asp:ListItem>
                                    <asp:ListItem>Tarde (12:00 a 16:00)</asp:ListItem>
                                    <asp:ListItem>Noche (16:00 a 20:00)</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr><td colspan="2">&nbsp;</td></tr>

                        <tr>
                            <td colspan="2" style="padding-bottom: 10px;">
                                <asp:Label ID="lblDatosDeAcceso" runat="server" Text="Datos de Acceso" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style25"><asp:Label ID="lblUsuarioAcceso" runat="server" Text="Usuario:"></asp:Label></td>
                            <td class="auto-style25"><asp:TextBox ID="tbUsuario" runat="server" MaxLength="20"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style25"><asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label></td>
                            <td class="auto-style25"><asp:TextBox ID="tbContrasena" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblRepetirContrasena" runat="server" Text="Repetir Contraseña:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="tbRepetirContrasena" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>

                                <asp:CompareValidator ID="cvContrasenas" runat="server" 
                                ControlToValidate="tbRepetirContrasena" 
                                ControlToCompare="tbContrasena" 
                                ErrorMessage="* Las contraseñas no coinciden" 
                                ForeColor="#CC0000"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style24"></td>
                            <td class="auto-style24">
                                <asp:Label ID="lblCargaExitosa" runat="server" ForeColor="#33CC33"></asp:Label>
                                                                <asp:Label ID="lblErrorGeneral" runat="server" ForeColor="#CC0000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </div>

            </div>

            <div style="text-align: center; margin-top: 30px;">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/MenuMedicos.aspx" Font-Bold="True"/>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
