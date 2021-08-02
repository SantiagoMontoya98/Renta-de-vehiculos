<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReservarVehiculo.aspx.cs" Inherits="WebProyectoFinalDesarrolloSoftware.ProyectoFinal.ReservarVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p class="text-center">
        <div class="text-center">
            <strong><span style="font-size: x-large">ADMINISTRACION DE RESERVAS</span></strong><br />
            </div>
        <table class="nav-justified">
            <tr>
                <td class="text-center" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" colspan="2"><strong><span style="font-size: large">
            <span style="font-size: x-large">RESERVAR VEHICULO</span><br />
                    ELEGIR VEHICULO</span></strong></td>
            </tr>
            <tr>
                <td class="text-center" colspan="2"><strong>
                    <br />
                    <span style="font-size: large">GAMA MEDIA<br />
                    PRECIO 45 MIL POR DIA</span></strong></td>
            </tr>
            <tr>
                <td class="text-left" colspan="2">
                    <br />
                    <asp:ImageButton ID="ImagenCaptur" runat="server" Height="177px" ImageUrl="~/Imagenes Gama Media/RenaultCaptur.jpg" Width="248px" OnClick="ImagenCaptur_Click" />
&nbsp;
                    <asp:ImageButton ID="ImagenEdge" runat="server" Height="179px" ImageUrl="~/Imagenes Gama Media/FordEdge.jpg" Width="229px" OnClick="ImagenEdge_Click" />
&nbsp;
                    <asp:ImageButton ID="ImagenMazda3" runat="server" Height="178px" ImageUrl="~/Imagenes Gama Media/Mazda3Rojo.jpg" Width="221px" OnClick="ImagenMazda3_Click" />
&nbsp;
                    <asp:ImageButton ID="ImagenMazdaCX5" runat="server" Height="178px" ImageUrl="~/Imagenes Gama Media/MazdaCX5.jpg" Width="222px" OnClick="ImagenMazdaCX5_Click" />
                    <br />
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RENAULT CAPTUR&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FORD EDGE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; MAZDA 3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MAZDA CX-5</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    <br />
                    <strong><span style="font-size: large">GAMA BAJA<br />
                    PRECIO 32 MIL 500 POR DIA</span></strong></td>
            </tr>
            <tr>
                <td class="text-left" colspan="2">
                    <br />
                    <asp:ImageButton ID="ImagenSpark" runat="server" Height="174px" ImageUrl="~/Imagenes Gama Baja/ChevroletSpark.jpg" Width="245px" OnClick="ImagenSpark_Click" />
&nbsp;
                    <asp:ImageButton ID="Imageni10" runat="server" Height="175px" ImageUrl="~/Imagenes Gama Baja/Hyundai-i10.jpg" Width="229px" OnClick="Imageni10_Click" />
&nbsp;
                    <asp:ImageButton ID="ImagenSandero" runat="server" Height="175px" ImageUrl="~/Imagenes Gama Baja/RenaultSandero.jpeg" Width="229px" OnClick="ImagenSandero_Click" />
&nbsp;
                    <asp:ImageButton ID="ImagenTwingo" runat="server" Height="174px" ImageUrl="~/Imagenes Gama Baja/RenaultTwingo.jpg" Width="218px" OnClick="ImagenTwingo_Click" style="margin-top: 0px" />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>C</strong><span style="font-weight: bold">HEVROLET SPARK&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; HYUNDAI i10&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RENAULT SANDERO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RENAULT TWINGO&nbsp;&nbsp;&nbsp; <br />
                    </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td class="text-left" colspan="2">
                    <asp:Label ID="lblPlacaVehiculo" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px"><strong>
                    <asp:Label ID="lblCodigo" runat="server" Visible="False">CODIGO</asp:Label>
                    </strong></td>
                <td class="text-left">
                    <asp:TextBox ID="txtCodigo" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Visible="False" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px"><strong>
                    <asp:Label ID="lblCedulaCliente" runat="server" Visible="False">CEDULA DEL CLIENTE</asp:Label>
                    </strong></td>
                <td class="text-left">
                    <asp:TextBox ID="txtCedulaCliente" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Visible="False" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px">&nbsp;</td>
                <td class="text-left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px"><strong>
                    <asp:Label ID="lblFechaInicial" runat="server" Visible="False">FECHA INICIAL</asp:Label>
                    </strong></td>
                <td class="text-left" style="font-size: large"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblFechaFinal" runat="server" Visible="False">FECHA FINAL</asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px">
                    <asp:Calendar ID="dtpFechaInicial" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" style="font-size: large; margin-left: 0px; margin-right: 0px" Visible="False" Width="330px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>
                </td>
                <td class="text-left">
                    <asp:Calendar ID="dtpFechaFinal" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" style="font-size: large; margin-left: 15px" Visible="False" Width="330px">
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
                <td class="text-left" style="font-size: large; width: 218px">
                    &nbsp;</td>
                <td class="text-left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px"><strong>
                    <asp:Label ID="lblSede" runat="server" Visible="False">SEDE DE RENTA</asp:Label>
                    </strong></td>
                <td class="text-left">
                    <asp:Label ID="lblSedeVehiculo" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblIDSede" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px"><strong>
                    <asp:Label ID="lblPoliza" runat="server" Visible="False">TIPO DE POLIZA</asp:Label>
                    </strong></td>
                <td class="text-left">
                    <asp:DropDownList ID="cboPoliza" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Visible="False" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px"><strong>
                    <asp:Label ID="lblNumDias" runat="server" Visible="False">NUMERO DIAS</asp:Label>
                    </strong></td>
                <td class="text-left">
                    <asp:Label ID="lblNumeroDias" runat="server" style="font-size: medium" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px; height: 25px;"><strong>
                    <asp:Label ID="lblPrecio2" runat="server" Visible="False">PRECIO</asp:Label>
                    </strong></td>
                <td class="text-left" style="height: 25px">
                    <asp:Label ID="lblPrecio" runat="server" style="font-size: medium" Visible="False"></asp:Label>
                    <asp:Label ID="lblPrecioDB" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: large; width: 218px; height: 25px;">&nbsp;</td>
                <td class="text-left" style="height: 25px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    <strong>
                    <asp:Label ID="lblError" runat="server" style="font-size: x-large" Visible="False" ForeColor="Aqua"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnConsultarPrecio" runat="server" BackColor="#0066FF" ForeColor="White" OnClick="btnConsultarPrecio_Click" style="font-size: medium; margin-left: 0" Text="CONSULTAR PRECIO DE LA RESERVA" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="text-left" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 218px">
                    <asp:Button ID="btnReservarVehiculo" runat="server" BackColor="#0066FF" ForeColor="White" OnClick="btnReservarVehiculo_Click" style="font-size: medium" Text="RESERVAR VEHICULO" Visible="False" Width="250px" />
                </td>
                <td class="text-left">
                    <asp:Button ID="btnActualizarReserva" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Text="ACTUALIZAR RESERVA" Visible="False" Width="250px" OnClick="btnActualizarReserva_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 218px">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnEliminarReserva" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Text="ELIMINAR RESERVA" Visible="False" Width="250px" OnClick="btnEliminarReserva_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 218px">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: x-large;" class="text-center" colspan="2">
                    <strong>EDITAR UNA RESERVA</strong></td>
            </tr>
            <tr>
                <td style="font-size: x-large;" class="text-center" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    <asp:GridView ID="grdRegistroReserva" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="grdRegistroReserva_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagen Edit/Imagen_Edit.png" ShowSelectButton="True" />
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
