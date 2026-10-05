<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="vistas.Informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Informes</title>
    <link href="EstilosVistas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style7 { width: 138px; }
        .auto-style8 { height: 39px; }
        .contenedor-informes { display:flex; gap:50px; background-color: transparent; box-shadow: none; padding: 0; }
        .seccion-informe { text-align:left; }
        .titulo-seccion { font-size:18pt; font-weight:bold; color:#0033CC; padding-bottom:10px; }
        .botones-centro { text-align:center; margin-top:20px; }
        .info-label { display:block; margin-top:8px; color:#0066CC; font-weight:bold; }
        .grid-estilo { margin-top:10px; width:100%; border-collapse:collapse; }
    </style>
</head>
<body>
    <div class="login-container">
        <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" 
            style="position: absolute; top: 15px; right: 20px; font-weight: 700;">
        </asp:Label>
        <form id="form1" runat="server">

            <div class="contenedor-formulario contenedor-informes">

                <!-- Informe de Asistencia -->
                <div class="seccion-informe">
                    <table class="auto-style1">
                        <tr>
                            <td colspan="2" class="auto-style8">
                                <asp:Label ID="lblTituloAsistencia" runat="server" Text="Informe de Asistencia" CssClass="titulo-seccion"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblFechaDesde" runat="server" Text="Fecha Desde:"></asp:Label></td>
                            <td class="auto-style7">
                                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblFechaHasta" runat="server" Text="Fecha Hasta:"></asp:Label></td>
                            <td class="auto-style7">
                                <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-top:10px;">
                                <asp:Button ID="btnGenerarAsistencia" runat="server" Text="Generar Informe" OnClick="btnGenerarAsistencia_Click"/>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnLimpiarAsistencia" runat="server" Text="Limpiar" OnClick="btnLimpiarAsistencia_Click"/>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="padding-top:12px;">
                                <asp:Label ID="lblTotalTurnos" runat="server" Text="Total de Turnos:" CssClass="info-label"></asp:Label>
                                <asp:Label ID="lbTotalTurnos" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblPresentes" runat="server" Text="Presentes:" CssClass="info-label"></asp:Label>
                                <asp:Label ID="lbPresentes" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblAusentes" runat="server" Text="Ausentes:" CssClass="info-label"></asp:Label>
                                <asp:Label ID="lbAusentes" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="padding-top:12px;">
                                <asp:Label ID="lblPacientes" runat="server" Text="Paciente " Font-Bold="True"></asp:Label>
                    <asp:GridView ID="gvPacientesInforme" runat="server" AutoGenerateColumns="False" CssClass="grid-estilo">
                            <Columns>
                         <asp:TemplateField HeaderText="Pacientes">
                                 <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nombre completo") %>'></asp:Label>
                               </ItemTemplate>
                              </asp:TemplateField>
            
                     <asp:TemplateField HeaderText="Asistencia">
                       <ItemTemplate>
                               <asp:Label ID="lblAsistencia" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     </Columns>
                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>

                <!-- Ranking de Médicos -->
                <div class="seccion-informe">
                    <table class="auto-style1">
                        <tr>
                            <td colspan="2" class="auto-style8">
                                <asp:Label ID="lblTituloRanking" runat="server" Text="Ranking de Médicos" CssClass="titulo-seccion"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblMes" runat="server" Text="Desde:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtdesde" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblAnio" runat="server" Text="Hasta:"></asp:Label></td>
                            <td><asp:TextBox ID="txtHasta" runat="server" TextMode="Date"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-top:10px;">
                                <asp:Button ID="btnGenerarRanking" runat="server" Text="Generar Informe" OnClick="btnGenerarRanking_Click"/>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnLimpiarRanking" runat="server" Text="Limpiar" OnClick="btnLimpiarRanking_Click"/>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="padding-top:12px;">
                                <asp:Label ID="lblMejorMedico" runat="server" Text="Mejor Médico:" CssClass="info-label"></asp:Label>
                                <asp:Label ID="lbMejorMedico" runat="server" Text="-" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblCantidadTurnos" runat="server" Text="Cantidad de Turnos:" CssClass="info-label"></asp:Label>
                                <asp:Label ID="lbCantidadTurnos" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="padding-top:12px;">
                                <asp:Label ID="lblTablaMedicos" runat="server" Text="Médico | Especialidad | Turnos Atendidos" Font-Bold="True"></asp:Label>
                                <asp:GridView ID="gvMedicosRanking" runat="server" AutoGenerateColumns="False" CssClass="grid-estilo">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Medico ">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("NombreCompleto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Especialidad">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Especialidades") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Turnos ">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("TurnosAtendidos") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
            <div class="botones-centro">
                <asp:Button ID="btnLimpiarInformes" runat="server" Text="Limpiar Informes" OnClick="btnLimpiarInformes_Click"/>
                 &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/MenuAdministrador.aspx" Font-Bold="True" />
            
            </div>

        </form>
    </div>
</body>
</html>
