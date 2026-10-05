<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagDefault.aspx.cs" Inherits="vistas.PagDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Mi Página</title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            
            <h2>
                <asp:Label ID="lbl1" runat="server" Text="Iniciar sesión" ForeColor="#0033CC"></asp:Label>
            </h2>
            <p style="margin-bottom: 20px; font-size: 16px;">
                <asp:Label ID="lbl2" runat="server" Font-Size="12pt" Text="Para comenzar ingresá tu usuario y contraseña"></asp:Label>
            </p>

            <div class="field">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </div>

            <div class="field">
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <div class="field">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
