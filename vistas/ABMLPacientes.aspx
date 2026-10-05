<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLPacientes.aspx.cs" Inherits="vistas.ABML_Pacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style7 {
            width: 138px;
        }
        .auto-style8 {
            height: 39px;
        }
    </style>
</head>
<body>
    <div class="login-container">
        <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" 
            style="position: absolute; top: 15px; right: 20px; font-weight: 700;">
        </asp:Label>
        <form id="form1" runat="server">
            
            <div class="contenedor-formulario" style="display: flex; gap: 50px; background-color: transparent; box-shadow: none; padding: 0;">
                
                <div style="text-align: left;">
                    <table class="auto-style1">
                        <tr>
                            <td colspan="2" style="padding-bottom: 10px;" class="auto-style8">
                                <asp:Label ID="lblDatosPersonalesPacientes0" runat="server" Text="Datos Personales" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblDniPaciente" runat="server" Text="DNI:"></asp:Label></td>
                            <td class="auto-style7"><asp:TextBox ID="TxtBoxDniPaciente" runat="server" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblNombrePaciente0" runat="server" Text="Nombre:"></asp:Label></td>
                            <td class="auto-style7"><asp:TextBox ID="TxtBoxNombrePaciente" runat="server" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblApellidoPaciente0" runat="server" Text="Apellido:"></asp:Label></td>
                            <td class="auto-style7"><asp:TextBox ID="TxtBoxApellidoPaciente" runat="server" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblSexoPaciente0" runat="server" Text="Sexo:"></asp:Label></td>
                            <td class="auto-style7"><asp:TextBox ID="TxtBoxSexoPaciente" runat="server" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblNacionalidadPaciente0" runat="server" Text="Nacionalidad:"></asp:Label></td>
                            <td class="auto-style7"><asp:TextBox ID="TxtBoxNacionalidadPaciente" runat="server" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblFechaNacimientoPaciente0" runat="server" Text="Fecha de Nac.:"></asp:Label></td>
                            <td class="auto-style7"><asp:TextBox ID="TxtBoxFechaNacimientoPaciente" runat="server" TextMode="Date"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>

                <div style="text-align: left;">
                    <table class="auto-style1">
                        <tr>
                            <td colspan="2" style="padding-bottom: 10px; display: flex; justify-content: space-between;">
                                <asp:Label ID="lblContactosUbicacionPacientes0" runat="server" Text="Contactos y Ubicación" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="DireccionPacientes0" runat="server" Text="Dirección:"></asp:Label></td>
                            <td><asp:TextBox ID="TxtBoxDireccionPaciente" runat="server" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblProvinciaPacientes0" runat="server" Text="Provincia:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DropDownProvinciaPaciente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownProvinciaPaciente_SelectedIndexChanged" Height="20px" Width="147px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblLocalidadPacientes0" runat="server" Text="Localidad:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DropDownLocalidadPaciente" runat="server" Width="147px" Height="20px">
                                    <asp:ListItem>- Seleccionar -</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblMailPacientes0" runat="server" Text="E-Mail:"></asp:Label></td>
                            <td><asp:TextBox ID="TxtBoxMailPaciente" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="TxtBoxMailPaciente" ErrorMessage="* Formato de mail inválido" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblTelefonoPacientes0" runat="server" Text="Teléfono:"></asp:Label></td>
                            <td><asp:TextBox ID="TxtBoxTelefonoPaciente" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>

            </div>

            <div style="text-align: center; margin-top: 30px; height: 106px;">
                <asp:Button ID="btnAgregarPaciente" runat="server" Text="Agregar" OnClick="btnAgregarPaciente_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLimpiarPaciente" runat="server" Text="Limpiar" OnClick="btnLimpiarPaciente_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/MenuPacientes.aspx" Font-Bold="True" OnClick="btnCancelar_Click" />
                <br />
                <asp:Label ID="lblAgregarPaciente" runat="server" ForeColor="#00CC00"></asp:Label>
                <asp:Label ID="lblmensaje" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblErrorAgregar" runat="server" ForeColor="#CC0000"></asp:Label>
                <br />
            </div>

        </form>
    </div>
    </div>
</body>
</html>
