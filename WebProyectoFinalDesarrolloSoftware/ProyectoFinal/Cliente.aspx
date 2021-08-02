<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="WebProyectoFinalDesarrolloSoftware.ProyectoFinal.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="nav-justified">
        <tr>
            <td colspan="2" style="height: 31px"></td>
        </tr>
        <tr>
            <td class="text-center" colspan="2" style="font-size: 20pt"><strong>ADMINISTRACIÓN DE CLIENTES</strong></td>
        </tr>
        <tr>
            <td class="text-center" colspan="2" style="height: 39px"></td>
        </tr>
        <tr>
            <td style="font-size: 15pt; width: 572px"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CÉDULA</strong></td>
            <td style="width: 524px">
                <asp:TextBox ID="txtCedula" runat="server" Width="250px" Height="25px" BackColor="#0066FF" ForeColor="White"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: 15pt; width: 572px"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NOMBRES</strong></td>
            <td style="width: 524px">
                <asp:TextBox ID="txtNombres" runat="server" Width="250px" Height="25px" BackColor="#0066FF" ForeColor="White"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: 15pt; width: 572px; height: 35px;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; APELLIDOS</strong></td>
            <td style="width: 524px; height: 35px;">
                <asp:TextBox ID="txtApellidos" runat="server" Width="250px" Height="25px" BackColor="#0066FF" ForeColor="White"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: 15pt; width: 572px; height: 28px;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EDAD</strong></td>
            <td style="width: 524px; height: 28px;">
                <asp:TextBox ID="txtEdad" runat="server" Width="250px" Height="25px" BackColor="#0066FF" ForeColor="White"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: 15pt; width: 572px; height: 28px;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NÚMERO DE LICENCIA</strong></td>
            <td style="width: 524px; height: 28px;">
                <asp:TextBox ID="txtNumeroPase" runat="server" Width="250px" Height="25px" BackColor="#0066FF" ForeColor="White"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="width: 572px; font-size: 15pt;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CATEGORIA LICENCIA</strong></td>
            <td style="width: 524px">
                &nbsp;<asp:DropDownList ID="cboCategoriaPase" runat="server" Height="35px" Width="100px" BackColor="#0066FF" ForeColor="White" style="font-size: medium">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td style="width: 572px">&nbsp;</td>
            <td style="width: 524px">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" style="width: 572px"><strong>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" style="font-weight: bold" Text="INSERTAR" Height="33px" Width="250px" BackColor="#0066FF" ForeColor="White" />
                </strong></td>
            <td style="width: 524px"><strong>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnActualizar" runat="server" style="font-weight: bold" Text="ACTUALIZAR" OnClick="btnActualizar_Click" Height="31px" Width="250px" BackColor="#0066FF" ForeColor="White" />
                </strong></td>
        </tr>
        <tr>
            <td class="text-center" style="width: 572px">&nbsp;</td>
            <td style="width: 524px">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" style="width: 572px"><strong>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar" runat="server" style="font-weight: bold" Text="ELIMINAR" Width="250px" OnClick="btnEliminar_Click" Height="32px" BackColor="#0066FF" ForeColor="White" />
                </strong></td>
            <td style="width: 524px"><strong>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCosultar" runat="server" style="font-weight: bold" Text="CONSULTAR" OnClick="btnCosultar_Click" Height="32px" Width="250px" BackColor="#0066FF" ForeColor="White" />
                </strong></td>
        </tr>
        <tr>
            <td style="width: 572px; height: 20px;"></td>
            <td style="width: 524px; height: 20px;"></td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <strong>
                <asp:Label ID="lblError" runat="server" ForeColor="Aqua" style="font-size: x-large"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <asp:Button ID="btnLimpiarCajas" runat="server" Text="LIMPIAR CAJAS DE TEXTO" OnClick="btnLimpiarCajas_Click" BackColor="#0066FF" ForeColor="White" Width="250px" />
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2" style="font-size: x-large"><strong>AGREGAR O EDITAR TELEFONOS</strong></td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="text-center">
                <asp:GridView ID="grdCliente" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="grdCliente_SelectedIndexChanged1" style="margin-left: 267px">
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
