<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="ConsultaCliente.aspx.cs" Inherits="UPC.CruzDelSur.Cliente.Carga.GestionCarga.ConsultaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Consulta de Clientes
    </h1>
<div>
        DNI
        <asp:TextBox ID="txtNombres" runat="server" Width="414px"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    </div>
    <br />
    <br />
    <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="False" 
        onrowcommand="gvCliente_RowCommand">
        <Columns>
            <asp:BoundField DataField="MG_ES04_Cliente_ID" HeaderText="ID" />
            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="TipoDocumento" HeaderText="TipoDocumento" />
            <asp:BoundField DataField="Documento" HeaderText="Documento" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSeleccionar" runat="server" CommandName="Seleccionar" CommandArgument='<%# Eval("MG_ES04_Cliente_ID")%>'>Seleccionar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
