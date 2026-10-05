<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosAsignados.aspx.cs" Inherits="vistas.TurnosAsignados" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />

    <style>
        body {
            background-image: url('imagenesVista/PagTurnos.JPG') !important; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" style="position: absolute; top: 15px; right: 20px; font-weight: 700;"></asp:Label>
            <h2>Turnos Asignados</h2>
            
            <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged" DataKeyNames="Numero de Turno" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="Numero de Turno" HeaderText="N° Turno" />
                    <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Nombre Apellido Y DNI" HeaderText="Paciente" />
                    <asp:BoundField DataField="Dia" HeaderText="Día" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Horario" HeaderText="Horario" />
                    <asp:BoundField DataField="Comentarios" HeaderText="Nota Solicitud" />
                    <asp:CheckBoxField DataField="Asistencia" HeaderText="Asistencia (Presente)" />
                    <asp:CommandField ButtonType="Button" SelectText="Gestionar" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <RowStyle BackColor="#EFF3FB" />
            </asp:GridView>

            <%-- Formulario dinámico para registrar atención (Pauta Enunciado) --%>
            <asp:Panel ID="pnlGestionarTurno" runat="server" Visible="false" Style="margin-top:20px; text-align:left; border-top:1px solid #ccc; padding-top:15px;">
                <h3>Gestionar Turno N° <asp:Label ID="lblNroTurnoSeleccionado" runat="server"></asp:Label></h3>
                
                <label>Asistencia del Paciente:</label>
                <asp:DropDownList ID="ddlAsistencia" runat="server">
                    <asp:ListItem Value="1">Presente</asp:ListItem>
                    <asp:ListItem Value="0">Ausente</asp:ListItem>
                </asp:DropDownList>
                <br /><br />
                
                <label>Observaciones de la Consulta:</label><br />
                <asp:TextBox ID="tbObservacion" runat="server" TextMode="MultiLine" Rows="4" Width="100%" MaxLength="200"></asp:TextBox>
                <br /><br />
                
                <asp:Button ID="btnGuardarAtencion" runat="server" Text="Guardar Atención" OnClick="btnGuardarAtencion_Click" />
                &nbsp;
                <asp:Button ID="btnVolverAtras" runat="server" Text="Volver Atras" OnClick="btnVolverAtras_Click" CausesValidation="False" />
                <br /><br />
                <asp:Label ID="lblMensajeAtencion" runat="server" ForeColor="Green"></asp:Label>
            </asp:Panel>
            
            <div style="text-align: center; margin-top: 30px;">
                <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" PostBackUrl="~/PagDefault.aspx" Font-Bold="True"/>
            </div>
        </div>
    </form>
</body>
</html>