<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="vistas.AltaTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style2 {
            width: 110px;
        }
    </style>
</head>
<body>
    <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" 
        style="position: absolute; top: 15px; right: 20px; font-weight: 700;"> </asp:Label>
    <div class="contenedor-formulario">
        <form id="form1" runat="server">

            <table style="width:100%;">
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblInformacionDelTurno" runat="server" Text="Informacion del turno" Font-Bold="True" Font-Size="18pt" ForeColor="#0033CC"></asp:Label>
                    </td>
                    <td class="auto-style2" dir="rtl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                            <asp:ListItem Value="0">- Seleccionar -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="ddlEspecialidad" ForeColor="#CC0000" InitialValue="0" ValidationGroup="ddlAltaTurnos"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblMedico" runat="server" Text="Medico"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMedico" runat="server">
                            <asp:ListItem Value="0">- Seleccionar -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="ddlMedico" ForeColor="#CC0000" InitialValue="0" ValidationGroup="ddlAltaTurnos"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblPaciente" runat="server" Text="Paciente"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPaciente" runat="server">
                            <asp:ListItem Value="0">- Seleccionar -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="ddlPaciente" ForeColor="#CC0000" InitialValue="0" ValidationGroup="ddlAltaTurnos"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblDia" runat="server" Text="Dia"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbDiaTurno" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="tbDiaTurno" ForeColor="#CC0000" ValidationGroup="ddlAltaTurnos"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblHorario" runat="server" Text="Horario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbHorarioTurno" runat="server" TextMode="Time"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="tbHorarioTurno" ForeColor="#CC0000" ValidationGroup="ddlAltaTurnos"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblComentario" runat="server" Text="Comentario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbComentarioTurno" runat="server" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
            </table>

            <div style="text-align: center; margin-top: 30px;">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" ValidationGroup="ddlAltaTurnos" OnClick="btnAgregar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                 &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/MenuAdministrador.aspx" Font-Bold="True" />
            
                <br />
                <asp:Label ID="lblConfirmacion" runat="server" Text="lblConfirmacion" Visible="False"></asp:Label>
            
            </div>

        </form>
    </div>
</body>
    
</html>
