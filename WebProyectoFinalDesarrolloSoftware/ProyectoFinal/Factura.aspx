<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="WebProyectoFinalDesarrolloSoftware.ProyectoFinal.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p class="text-center">
        <div class="text-center">
            <strong><span style="font-size: xx-large">FACTURA</span></strong></div>
        <table class="nav-justified" style="width: 131%">
            <tr>
                <td class="text-left" style="width: 420px">&nbsp;</td>
                <td style="width: 339px" colspan="2">&nbsp;</td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="width: 420px">&nbsp;</td>
                <td style="width: 339px" colspan="2">&nbsp;</td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" style="font-size: large;" colspan="4"><strong>FECHA&nbsp; </strong>
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="width: 303px; font-size: large;" colspan="2"><strong>NUMERO FACTURA</strong></td>
                <td class="text-left" style="font-size: large;" colspan="2">
                    <asp:Label ID="lblNumeroFactura" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 420px"><strong>CEDULA CLIENTE</strong></td>
                <td class="text-left" style="font-size: large; width: 339px" colspan="2">
                    <asp:Label ID="lblCedulaCliente" runat="server"></asp:Label>
                </td>
                <td class="text-left" style="width: 420px"><span style="font-size: large"><strong>NOMBRE CLIENTE </strong></span>&nbsp;<asp:Label ID="lblNombreCliente" runat="server" style="font-size: large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 420px"><strong>PLACA VEHICULO</strong></td>
                <td class="text-left" style="font-size: large; width: 339px" colspan="2">
                    <asp:Label ID="lblPlacaVehiculo" runat="server"></asp:Label>
                </td>
                <td class="text-left" style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 420px"><strong>KILOMETROS RECORRIDOS</strong></td>
                <td class="text-left" style="font-size: large; width: 339px" colspan="2">
                    <asp:Label ID="lblKilometrosRecorridos" runat="server"></asp:Label>
                </td>
                <td class="text-left" style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 420px"><strong>PRECIO DE RENTA</strong></td>
                <td class="text-left" style="font-size: large; width: 339px" colspan="2">
                    <asp:Label ID="lblPrecioRenta" runat="server"></asp:Label>
                    <asp:Label ID="lblPrecioRentaDB" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="text-left" style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 420px"><strong>PRECIO DE RESERVA</strong></td>
                <td class="text-left" style="font-size: large; width: 339px" colspan="2">
                    <asp:Label ID="lblPrecioReserva" runat="server"></asp:Label>
                    <asp:Label ID="lblPrecioReservaDB" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="text-left" style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 420px"><strong>PRECIO POR LOS KILOMETROS RECORRIDOS</strong></td>
                <td class="text-left" style="font-size: large; width: 339px" colspan="2">
                    <asp:Label ID="lblPrecioKilometros" runat="server"></asp:Label>
                    <asp:Label ID="lblPrecioKilometrosDB" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="text-left" style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 420px; font-size: large;"><strong>EMPLEADO</strong></td>
                <td style="font-size: large; width: 339px" colspan="2">
                    <asp:DropDownList ID="cboEmpleado" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium">
                    </asp:DropDownList>
                </td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 420px; font-size: large;">&nbsp;</td>
                <td style="font-size: large; width: 339px" colspan="2">&nbsp;</td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="width: 420px"><strong><span style="font-size: medium">TOTAL A PAGAR&nbsp; </span><span style="font-size: large">&nbsp;</span></strong>&nbsp;&nbsp;&nbsp; </td>
                <td class="text-left" style="font-size: large; width: 339px" colspan="2">
                    <asp:Label ID="lblTotalPagar" runat="server"></asp:Label>
                    <asp:Label ID="lblTotalPagarDB" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="text-left" style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="width: 420px">&nbsp;</td>
                <td class="text-left" style="font-size: large; width: 339px" colspan="2">
                    &nbsp;</td>
                <td class="text-left" style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" colspan="3"><strong>
                    <asp:Label ID="lblError" runat="server" ForeColor="Aqua" style="font-size: x-large"></asp:Label>
                    </strong> </td>
                <td class="text-left" style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 420px">&nbsp;</td>
                <td style="width: 339px" colspan="2">&nbsp;</td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnTotalPagar" runat="server" BackColor="#0066FF" ForeColor="White" OnClick="btnTotalPagar_Click" style="font-size: medium" Text="CALCULAR TOTAL A PAGAR" Width="259px" />
                </td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 420px">&nbsp;</td>
                <td style="width: 339px" colspan="2">&nbsp;</td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 420px">
                    <asp:Button ID="btnInsertar" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Text="REGISTRAR FACTURA" Width="300px" OnClick="btnInsertar_Click" />
                </td>
                <td style="width: 339px" colspan="2">
                    <asp:Button ID="btnRegresar" runat="server" BackColor="#0066FF" ForeColor="White" OnClick="btnRegresar_Click" style="font-size: medium" Text="REGRESAR" Width="300px" />
                </td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 420px">&nbsp;</td>
                <td style="width: 339px" colspan="2">&nbsp;</td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 420px">
                    <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
                <td style="width: 339px" colspan="2">&nbsp;</td>
                <td style="width: 420px">&nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
