<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="vistas.SesionAdministrador" %>

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
        
        <h2>
            <asp:Label ID="lblMenuAdministrador" runat="server" Text="Menu Administrador"></asp:Label>
        </h2>

        <div class="field">
            <asp:Button ID="btnMedicos" runat="server" Text="Medicos" OnClick="btnMedicos_Click" />
        </div>

        <div class="field">
            <asp:Button ID="btnPacientes" runat="server" Text="Pacientes" OnClick="btnPacientes_Click" />
        </div>

        <div class="field">
            <asp:Button ID="btnTurnos" runat="server" Text="Asignacion de Turnos" OnClick="btnTurnos_Click" />
        </div>

        <div class="field">
            <asp:Button ID="btnInformes" runat="server" Text="Informes" OnClick="btnInformes_Click" />
        </div>

        <div class="field">
            <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" PostBackUrl="~/PagDefault.aspx" OnClick="btnCerrarSesion_Click" Font-Bold="True" />
        </div>
    </div>
</form>
</body>
</html>
