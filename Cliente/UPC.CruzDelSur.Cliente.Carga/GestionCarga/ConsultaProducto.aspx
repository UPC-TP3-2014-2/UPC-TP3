<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="ConsultaProducto.aspx.cs" Inherits="CRUZDELSUR.UI.Web.GestionCarga.ConsultaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Descripcion
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Buscar" />
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" 
        onrowcommand="gvProductos_RowCommand" Width="100%">
        <Columns>
            <asp:BoundField DataField="CODIGO_PRODUCTO" HeaderText="ID" />
            <asp:BoundField DataField="NOMBRE" HeaderText="Producto" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="lnkSeleccionar" runat="server"  CssClass='<%# Eval("CODIGO_PRODUCTO")%>' />
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnSeleccionarProductos" runat="server" Text="Seleccionar Productos" OnClick="btnSeleccionarProductos_Click"  />

</asp:Content>
