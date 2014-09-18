<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="ConsultaCliente.aspx.cs" Inherits="CRUZDELSUR.UI.Web.GestionCarga.ConsultaCliente" %>
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
            <asp:BoundField DataField="DOCUMENTO" HeaderText="DNI" />
            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
           
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSeleccionar" runat="server" CommandName="Seleccionar" CommandArgument='<%# Eval("DOCUMENTO")%>'>Seleccionar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
