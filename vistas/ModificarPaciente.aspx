<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="vistas.ModificarPaciente" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificar Paciente</title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .separador { border-top: 1px solid #ccc; margin: 20px 0; }
        .auto-style23 { width: 203px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" style="position: absolute; top: 15px; right: 20px; font-weight: 700;"></asp:Label>
            
            <h2>Modificar un Paciente</h2>
            
            <div style="text-align: center; margin-bottom: 20px;">
                <asp:Label ID="lblBuscarDni" runat="server" Text="Ingrese DNI del Paciente:" Font-Bold="True"></asp:Label>
                &nbsp;
                <asp:TextBox ID="tbBuscarDni" runat="server" Width="150px" MaxLength="10"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                <br />
                <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red" style="display:block; margin-top:10px;"></asp:Label>
            </div>

            <asp:Panel ID="pnlFormulario" runat="server" Visible="False">
                <div class="separador"></div>
                <div class="contenedor-formulario" style="display: flex; gap: 50px; background-color: transparent; box-shadow: none; padding: 0;">
                    <div style="text-align: left;">
                        <table class="auto-style1">
                            <tr>
                                <td colspan="2"><asp:Label ID="lblSub" runat="server" Text="Datos del Paciente" Font-Bold="True" Font-Size="16pt" ForeColor="#0033CC"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>DNI:</td>
                                <td class="auto-style23"><asp:TextBox ID="tbDni" runat="server" ReadOnly="True" BackColor="#E9ECEF" MaxLength="10"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Nombre:</td>
                                <td class="auto-style23"><asp:TextBox ID="tbNombre" runat="server" MaxLength="15"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Apellido:</td>
                                <td class="auto-style23"><asp:TextBox ID="tbApellido" runat="server" MaxLength="15"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Sexo:</td>
                                <td class="auto-style23"><asp:TextBox ID="tbSexo" runat="server" MaxLength="10"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Nacionalidad:</td>
                                <td class="auto-style23"><asp:TextBox ID="tbNacionalidad" runat="server" MaxLength="15"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Fecha de Nac.:</td>
                                <td class="auto-style23"><asp:TextBox ID="tbFechaNac" runat="server" TextMode="Date"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    <div style="text-align: left;">
                        <table class="auto-style1">
                            <tr>
                                <td colspan="2"><asp:Label ID="lblSub2" runat="server" Text="Contacto y Ubicación" Font-Bold="True" Font-Size="16pt" ForeColor="#0033CC"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Dirección:</td>
                                <td><asp:TextBox ID="tbDireccion" runat="server" MaxLength="15"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Provincia:</td>
                                <td>
                                    <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                                        <asp:ListItem>- Seleccionar -</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Localidad:</td>
                                <td>
                                    <asp:DropDownList ID="ddlLocalidad" runat="server">
                                        <asp:ListItem>- Seleccionar -</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>E-Mail:</td>
                                <td><asp:TextBox ID="tbEmail" runat="server" MaxLength="20"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Teléfono:</td>
                                <td><asp:TextBox ID="tbTelefono" runat="server" MaxLength="15"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="text-align: center; margin-top: 30px;">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" />
                </div>
            </asp:Panel>
            
            <div style="text-align: center; margin-top: 20px;">
                <asp:Button ID="btnCancelar" runat="server" Text="Volver al Menú" PostBackUrl="~/MenuPacientes.aspx" Font-Bold="True" />
            </div>
        </div>
    </form>
</body>
</html>