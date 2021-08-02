<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ciudad.aspx.cs" Inherits="WebProyectoFinalDesarrolloSoftware.ProyectoFinal.Ciudad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td colspan="2" style="font-size: 20pt" class="text-center"><strong>ADMINISTRACIÓN DE CIUDADES</strong></td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; height: 29px;"></td>
                <td style="height: 29px">
                    </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: 16pt;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CÓDIGO CIUDAD</strong></td>
                <td>
                    <asp:TextBox ID="txtCodigo" runat="server" Height="25px" Width="250px" BackColor="#0066FF" ForeColor="White"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="height: 22px; font-size: 16pt;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NOMBRE</strong></td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtNombre" runat="server" Height="25px" Width="250px" BackColor="#0066FF" ForeColor="White"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-size: 16pt;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ACTIVO</strong></td>
                <td>
                    <asp:CheckBox ID="chkActivo" runat="server" BackColor="White" />
                </td>
            </tr>
            <tr>
                <td class="text-left" style="height: 22px; font-size: 16pt;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DEPARTAMENTO</strong></td>
                <td style="height: 22px">
                    <asp:DropDownList ID="cboDepartamento" runat="server" Height="30px" Width="250px" BackColor="#0066FF" ForeColor="White" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" style="height: 18px">
                    <strong>&nbsp;<asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" Width="250px" style="font-weight: bold" BackColor="#0066FF" ForeColor="White" />
                    </strong>
                </td>
                <td style="height: 18px">
                    <strong>
                    <asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" OnClick="btnActualizar_Click" Width="250px" style="font-weight: bold" BackColor="#0066FF" ForeColor="White" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <strong>&nbsp;<asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" OnClick="btnEliminar_Click" Width="250px" style="font-weight: bold" BackColor="#0066FF" ForeColor="White" />
                    </strong>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" colspan="2" style="height: 39px">
                    </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2" style="height: 27px">
                    <strong>
                    <asp:Label ID="lblError" runat="server" ForeColor="Aqua" style="font-size: x-large"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2" style="height: 40px">
                    </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2" style="height: 40px; font-size: x-large;">
                    <strong>EDITAR UNA CIUDAD</strong></td>
            </tr>
            <tr>
                <td class="text-center" colspan="2" style="height: 40px; font-size: medium;">
                    </td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    <asp:GridView ID="grdCiudad" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="grdCiudad_SelectedIndexChanged1" style="margin-left: 322px">
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
