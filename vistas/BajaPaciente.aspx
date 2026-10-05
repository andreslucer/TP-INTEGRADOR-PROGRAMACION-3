<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaPaciente.aspx.cs" Inherits="vistas.BajaPaciente" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baja de Pacientes</title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <asp:Label ID="lblUsuario" runat="server" style="position:absolute; top:15px; right:20px; font-weight:700;"></asp:Label>
            
            <h2>Dar de Baja un Paciente</h2>
            
            <div class="contenedor-formulario" style="background-color:transparent; box-shadow:none;">
                <table>
                    <tr>
                        <td><asp:Label ID="lblDni" runat="server" Text="DNI del Paciente:" /></td>
                        <td>
                            <asp:TextBox ID="TxtDniBaja" runat="server" MaxLength="10" />
                            <asp:RequiredFieldValidator ID="rfDNI" runat="server" ControlToValidate="TxtDniBaja" 
                                ErrorMessage="* Ingrese el DNI" ForeColor="Red" Display="Dynamic" />
                        </td>
                        <td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="pnlDetalles" runat="server" Visible="false" Style="margin-top:10px;">
                                <table>
                                    <tr>
                                        <td>Nombre:</td>
                                        <td><asp:Label ID="lblNombre" runat="server" Text="-" /></td>
                                    </tr>
                                    <tr>
                                        <td>Apellido:</td>
                                        <td><asp:Label ID="lblApellido" runat="server" Text="-" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding-top:10px;">
                                            <asp:Button ID="btnBaja" runat="server" Text="Confirmar Baja" CssClass="btn-cerrar-sesion" OnClick="btnBaja_Click" OnClientClick="return confirm('¿Está seguro de que desea dar de baja a este paciente?');" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CausesValidation="False" />
                                            <asp:Label ID="lblmensajeee" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
                                PageSize="5" OnPageIndexChanging="gvPacientes_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("apellido") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DNI">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("DNI") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align:center; padding-top:10px;">
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="text-align:center; margin-top:20px;">
                <asp:Button ID="btnCancelar" runat="server" Text="Volver" PostBackUrl="~/MenuPacientes.aspx" CausesValidation="False" />
            </div>
        </div>
    </form>
</body>
</html>