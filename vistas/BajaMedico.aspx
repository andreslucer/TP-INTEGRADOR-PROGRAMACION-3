<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaMedico.aspx.cs" Inherits="vistas.BajaMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Baja Médico</title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 47px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" 
                style="position: absolute; top: 15px; right: 20px; font-weight: 700;">
            </asp:Label>
            <h2>Dar de Baja un Médico</h2>

            <div class="contenedor-formulario" style="background-color: transparent; box-shadow: none;">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="lblLegajo" runat="server" Text="Legajo:"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="tbLegajo" runat="server" MaxLength="4" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfLegajo" runat="server"
                                ControlToValidate="tbLegajo" ErrorMessage="Ingrese el legajo" ForeColor="Red" Display="Dynamic" />
                        </td>
                        <td class="auto-style1">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="pnlDetalles" runat="server" Visible="false" Style="text-align:left; margin-top:10px;">
                                <table>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td><asp:Label ID="lblNombre" runat="server" Text="-"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td><asp:Label ID="lblApellido" runat="server" Text="-"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding-top:10px;">
                                            <asp:Button ID="btnBaja" runat="server" Text="Dar de Baja" OnClick="btnBaja_Click" CssClass="btn-cerrar-sesion" OnClientClick="return confirm('Estas seguro que desea dar de baja a este medico?');" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CausesValidation="False" />
                                            <asp:GridView ID="gvMedicos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gvMedicos_PageIndexChanging" OnSelectedIndexChanged="gvMedicos_SelectedIndexChanged">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="LEGAJO">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_it_Legajo" runat="server" Text='<%# Eval("Legajo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombre">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_it_nombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Apellido">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Eval("apellido") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Dni">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Eval("Dni") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="padding-top:10px; text-align:center;">
                            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#c00"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <div style="text-align: center; margin-top: 30px;">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False" PostBackUrl="~/MenuMedicos.aspx" Font-Bold="True" />
            </div>
        </div>
    </form>
</body>
</html>
