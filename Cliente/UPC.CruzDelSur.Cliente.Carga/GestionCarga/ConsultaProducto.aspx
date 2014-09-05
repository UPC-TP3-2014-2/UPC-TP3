<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="ConsultaProducto.aspx.cs" Inherits="UPC.CruzDelSur.Cliente.Carga.GestionCarga.ConsultaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Descripcion
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Buscar" />
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" 
        onrowcommand="gvProductos_RowCommand" Width="100%">
        <Columns>
            <asp:BoundField DataField="MG_ES03_Producto_ID" HeaderText="ID" />
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="TipoCarga" HeaderText="Tipo Carga" />
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSeleccionar" runat="server" 
                        CommandArgument='<%# Eval("MG_ES03_Producto_ID")%>' CommandName="Seleccionar">Seleccionar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
