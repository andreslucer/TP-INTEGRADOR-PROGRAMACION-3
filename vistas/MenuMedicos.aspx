<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuMedicos.aspx.cs" Inherits="vistas.MenuMedicos" %>

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
            <h2>Menu Médicos</h2>

        <div class="field">
            <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
        </div>

        <div class="field">
            <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click" />
        </div>

        <div class="field">
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        </div>

        <div class="field">
            <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
        </div>

        <div class="field">
            <asp:Button ID="btnAtras" runat="server" Text="Atras" PostBackUrl="~/MenuAdministrador.aspx" Font-Bold="True" />
        </div>
    </div>
</form>
</body>
</html>
