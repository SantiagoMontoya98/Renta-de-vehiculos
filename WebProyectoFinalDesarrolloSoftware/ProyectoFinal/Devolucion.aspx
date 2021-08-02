<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Devolucion.aspx.cs" Inherits="WebProyectoFinalDesarrolloSoftware.ProyectoFinal.Devolucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td colspan="2" style="font-size: x-large; font-family: Arial; font-weight: bold;" class="text-center">ADMINISTRACION DEVOLUCION DE VEHICULO</td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: x-large; font-family: Arial; font-weight: bold;" class="text-center">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">CODIGO</td>
                <td>
                    <asp:TextBox ID="txtCodigo" runat="server" BackColor="#0066FF" ForeColor="White" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">CEDULA DEL CLIENTE </td>
                <td>
                    <asp:TextBox ID="txtCedulaCliente" runat="server" BackColor="#0066FF" ForeColor="White" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">PLACA DEL VEHICULO </td>
                <td>
                    <asp:TextBox ID="txtPlacaVehiculo" runat="server" BackColor="#0066FF" ForeColor="White" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">&nbsp;EMPLEADO</td>
                <td>
                    <asp:DropDownList ID="cboCargoEmpleado" runat="server" BackColor="#0066FF" ForeColor="White" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">SEDE</td>
                <td>
                    <asp:Label ID="lblSede" runat="server" Text="Aeropuerto Jose Maria Cordoba Local 228"></asp:Label>
                    <asp:Label ID="lblIDSede" runat="server" Text="1" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; height: 22px; font-size: large;">FECHA DE DEVOLUCIÓN</td>
                <td style="height: 22px">
                    <asp:Calendar ID="dtpFechaEntrega" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px" style="font-size: medium">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; height: 22px; font-size: large;">&nbsp;</td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">KILOMETRAJE DEL VEHICULO</td>
                <td>
                    <asp:TextBox ID="txtKilometrajeFinalVehiculo" runat="server" BackColor="#0066FF" ForeColor="White" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">KILOMETROS RECORRIDOS POR EL CLIENTE</td>
                <td>
                    <asp:Label ID="lblKilometrosRecorridos" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 512px; font-size: large;">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 512px">
                    <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" BackColor="#0066FF" ForeColor="White" Width="250px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" OnClick="btnActualizar_Click" BackColor="#0066FF" ForeColor="White" Width="250px" />
                </td>
            </tr>
            <tr>
                <td style="width: 512px; height: 20px;">
                    <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" OnClick="btnEliminar_Click" BackColor="#0066FF" ForeColor="White" Width="250px" />
                    </td>
                <td style="height: 20px">
                    <asp:Button ID="btnFactura" runat="server" BackColor="#0066FF" ForeColor="White" OnClick="btnFactura_Click" Text="REALIZAR FACTURA" Width="250px" />
                    </td>
            </tr>
            <tr>
                <td style="width: 512px; height: 20px;">
                    &nbsp;</td>
                <td style="height: 20px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" style="height: 20px;" colspan="2">
                    <strong>
                    <asp:Label ID="lblError" runat="server" style="font-size: x-large" ForeColor="Aqua"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="width: 512px; height: 20px;">
                    &nbsp;</td>
                <td class="text-left" style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" style="height: 20px; font-size: x-large;" colspan="2">
                    <strong>EDITAR UNA DEVOLUCION</strong></td>
            </tr>
            <tr>
                <td class="text-left" style="width: 512px; height: 20px;">
                    &nbsp;</td>
                <td class="text-left" style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    <asp:GridView ID="grdDevolucion" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" Width="406px" OnSelectedIndexChanged="grdDevolucion_SelectedIndexChanged" CellSpacing="2" ForeColor="Black">
                        <Columns>
                            <asp:CommandField SelectText="Editar" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Imagen Edit/Imagen_Edit.png" />
                        </Columns>
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
            </tr>
        </table>
    </p>

</asp:Content>
