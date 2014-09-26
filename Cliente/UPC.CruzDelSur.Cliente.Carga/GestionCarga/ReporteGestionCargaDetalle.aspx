<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="ReporteGestionCargaDetalle.aspx.cs" Inherits="UPC.CruzDelSur.Cliente.Carga.GestionCarga.ReporteGestionCargaDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalle de Ficha Carga</h1>
            <asp:GridView ID="gvProductos" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False"
                Width="100%" EmptyDataText="Debe Seleccionar un producto, haga click en Agregar">
                <Columns>
                    <asp:BoundField DataField="CODIGO_PRODUCTO" HeaderText="ID" />
                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Producto" />

                    <asp:TemplateField HeaderText="Tipo carga">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlTipoCarga" runat="server" Enabled="false">
                                <asp:ListItem Value="1">Fragil</asp:ListItem>
                                <asp:ListItem Value="2" Selected="True">Normal</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" />
                    <asp:BoundField DataField="DBL_PESO" HeaderText="Peso" />
                    <asp:BoundField DataField="DBL_IMPORTE" HeaderText="Importe" />
                    
                    
                </Columns>
            </asp:GridView>
</asp:Content>
