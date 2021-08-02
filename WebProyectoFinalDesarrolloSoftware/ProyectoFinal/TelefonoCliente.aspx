<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelefonoCliente.aspx.cs" Inherits="WebProyectoFinalDesarrolloSoftware.ProyectoFinal.TelefonoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table style="width: 81%">
        <tr>
            <td style="width: 371px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2" style="font-size: x-large"><strong>ADMINISTRACIÓN DE TELEFONOS CLIENTES</strong></td>
        </tr>
        <tr>
            <td style="height: 31px;" colspan="2"></td>
        </tr>
        <tr>
            <td style="font-size: large; width: 371px"><strong>CEDULA DEL CLIENTE:</strong></td>
            <td>
                <asp:Label ID="lblCedula" runat="server" style="font-size: 12pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: large; width: 371px; height: 32px;"><strong>NOMBRE:</strong></td>
            <td style="height: 32px">
                <asp:Label ID="lblNombre" runat="server" style="font-size: 12pt"></asp:Label>
            </td>
        </tr>
        
        
        <tr>
            <td style="width: 371px; font-size: large"><strong>TIPO DE TELÉFONO:</strong></td>
            <td>
                &nbsp;<asp:DropDownList ID="cboTelefono" runat="server" Height="32px" Width="250px" BackColor="#0066FF" ForeColor="White">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 371px; font-size: large; height: 32px;"><strong>NÚMERO DE TELÉFONO:</strong></td>
            <td class="text-left" style="height: 32px">
                &nbsp;<asp:TextBox ID="txtNumeroTelefono" runat="server" Height="25px" Width="250px" BackColor="#0066FF" ForeColor="White"></asp:TextBox>
                &nbsp;
                <asp:TextBox ID="txtCodigoTelefono" runat="server" Height="25px" Width="54px" ReadOnly="True" BackColor="#0066FF" ForeColor="White" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 371px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <strong>
                <asp:Label ID="lblError" runat="server" ForeColor="Aqua" style="font-size: x-large"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="width: 371px; height: 20px;"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td class="text-center" style="width: 371px">
                <strong>
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="INGRESAR" Width="250px" Height="32px" style="font-weight: bold" BackColor="#0066FF" ForeColor="White" />
                </strong>
            </td>
            <td class="text-center">
                <strong>
                <asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" Width="250px" OnClick="btnActualizar_Click" Height="32px" style="font-weight: bold" BackColor="#0066FF" ForeColor="White" />
                </strong>
            </td>
        </tr>
        <tr>
            <td class="text-center" style="width: 371px; height: 6px"></td>
            <td style="height: 6px"></td>
        </tr>
        <tr>
            <td class="text-center" style="width: 371px; height: 26px">
                <strong>
                <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" Width="250px" OnClick="btnEliminar_Click" Height="32px" style="font-weight: bold" BackColor="#0066FF" ForeColor="White" />
                </strong>
            </td>
            <td class="text-center" style="height: 26px">
                <strong>
                <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="REGRESAR" Width="250px" Height="32px" style="font-weight: bold" BackColor="#0066FF" ForeColor="White" />
                </strong>
            </td>
        </tr>
        <tr>
            <td style="width: 371px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: x-large;" class="text-center" colspan="2"><strong>EDITAR UN TELEFONO</strong></td>
        </tr>
        <tr>
            <td style="font-size: x-large;" class="text-center" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="text-center">
                <asp:GridView ID="grdTelefono" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="grdTelefono_SelectedIndexChanged1" style="margin-left: 247px">
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

</asp:Content>
