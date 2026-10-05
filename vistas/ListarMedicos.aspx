<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMedicos.aspx.cs" Inherits="vistas.ListarMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
    <div class="login-container">
        <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" 
            style="position: absolute; top: 15px; right: 20px; font-weight: 700;">
        </asp:Label>
        <h2>Listar Médicos</h2>
        
        <%-- Filtro de Búsqueda (Pauta 3) --%>
        <div style="margin-bottom: 20px; text-align: left;">
            <asp:Label ID="lblBuscar" runat="server" Text="Filtrar por apellido o activar por legajo" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="txtBuscarApellido" runat="server" Width="200px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
            &nbsp;
            <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar Todos" OnClick="btnMostrarTodos_Click" />
            &nbsp;

            <asp:Button ID="btnActivar" runat="server" OnClick="btnActivar_Click" Text="Activar Medico" Width="135px" />
            &nbsp;
            <asp:Label ID="lblactivo" runat="server"></asp:Label>

        </div>

        <div class="field">
            <asp:GridView ID="gvMedicos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="999px" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvMedicos_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Legajo">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Legajo" runat="server" Text='<%# Eval("Legajo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Dni" runat="server" Text='<%# Eval("DNI") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Eval("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Especialidad">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Especialidad" runat="server" Text='<%# Eval("Especialidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dirección">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Eval("Dirección") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Localidad">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Eval("Localidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mail">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Mail" runat="server" Text='<%# Eval("E-Mail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teléfono">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Telefono" runat="server" Text='<%# Eval("Teléfono") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Días Atención">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_DiaAtencion" runat="server" Text='<%# Eval("Días de Atención") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Activo">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("activo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
        </div>
        <div class="field">
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/MenuMedicos.aspx" Font-Bold="True" />
        </div>
    </div>
</form>
</body>
</html>
