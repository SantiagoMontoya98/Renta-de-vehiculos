<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehiculo.aspx.cs" Inherits="WebProyectoFinalDesarrolloSoftware.ProyectoFinal.Vehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td colspan="2" style="font-size: x-large; font-family: Arial; font-weight: bold;" class="text-center">ADMINISTRACION DE VEHICULOS</td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: x-large; font-family: Arial; font-weight: bold;" class="text-center">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">PLACA</td>
                <td>
                    <asp:TextBox ID="txtPlaca" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">VEHICULO</td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" BackColor="#0066FF" Width="250px" ForeColor="White"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">KILOMETRAJE INICIAL</td>
                <td>
                    <asp:TextBox ID="txtKilometrajeInicial" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">KILOMETRAJE FINAL</td>
                <td>
                    <asp:TextBox ID="txtKilometrajeFinal" runat="server" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">MARCA</td>
                <td>
                    <asp:DropDownList ID="cboMarca" runat="server" BackColor="#0066FF" ForeColor="White" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">GAMA</td>
                <td>
                    <asp:DropDownList ID="cboGama" runat="server" BackColor="#0066FF" ForeColor="White" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; height: 22px; font-size: large;">COLOR</td>
                <td style="height: 22px">
                    <asp:DropDownList ID="cboColor" runat="server" BackColor="#0066FF" ForeColor="White" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">TIPO DE VEHICULO</td>
                <td>
                    <asp:DropDownList ID="cboTipoVehiculo" runat="server" BackColor="#0066FF" ForeColor="White" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">PRECIO POR 1 DIA DE RENTA</td>
                <td>
                    <asp:TextBox ID="txtPrecio" runat="server" BackColor="#0066FF" Width="250px" ForeColor="White"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">SEDE</td>
                <td>
                    <asp:Label ID="lblSedeVehiculo" runat="server"></asp:Label>
                    <asp:Label ID="lblIDSede" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; width: 444px; font-size: large;">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 444px">
                    <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Width="250px" />
                </td>
                <td>
                    <asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" OnClick="btnActualizar_Click" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Width="250px" />
                </td>
            </tr>
            <tr>
                <td style="width: 444px">
                    <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" OnClick="btnEliminar_Click" BackColor="#0066FF" ForeColor="White" style="font-size: medium" Width="250px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 444px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    <strong>
                    <asp:Label ID="lblError" runat="server" ForeColor="Aqua" style="font-size: x-large"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" style="font-size: x-large;" colspan="2">
                    <strong>EDITAR UN VEHICULO</strong></td>
            </tr>
            <tr>
                <td class="text-left" style="width: 444px; height: 20px;">
                    </td>
                <td class="text-left" style="height: 20px"></td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    <asp:GridView ID="grdVehiculo" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" Width="406px" OnSelectedIndexChanged="grdSoftware_SelectedIndexChanged" CellSpacing="2" ForeColor="Black" style="margin-left: 220px; margin-right: 0px">
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
                &nbsp;</td>
            </tr>
        </table>
    </p>

</asp:Content>
