<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="ConsultaProgramacion.aspx.cs" Inherits="CRUZDELSUR.UI.Web.GestionCarga.ConsultaProgramacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Consultar Programacion Ruta
    </h1>
    <script src="../Scripts/OpenModalDialog.js" type="text/javascript"></script>
    Departamento Destino
    <asp:DropDownList ID="ddlAgencias" runat="server">
        <asp:ListItem Value="04">Arequipa</asp:ListItem>
        <asp:ListItem Value="11">Ica</asp:ListItem>
        <asp:ListItem Value="15">Lima</asp:ListItem>
        <asp:ListItem Value="20">Piura</asp:ListItem>
        <asp:ListItem Value="23">Tacna</asp:ListItem>
        
    </asp:DropDownList>
    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" 
        onclick="btnConsultar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    <br />
    <br />

    <asp:GridView ID="gvProgramacionRuta" runat="server" Width="100%" 
        AutoGenerateColumns="False" onrowcommand="gvProgramacionRuta_RowCommand">
        <Columns>
            <asp:BoundField DataField="CODIGO_AGENCIAORIGEN" HeaderText="IdAgenciaOrigen" 
                Visible="False" />
            <asp:BoundField DataField="Origen" HeaderText="AgenciaOrigen" />
            <asp:BoundField DataField="CODIGO_AGENCIADESTINO" Visible="False" />
            <asp:BoundField DataField="Destino" HeaderText="AgenciaDestino" />
            <asp:BoundField DataField="FECHA_ORIGEN" HeaderText="FechaHoraOrigen" />
            <asp:BoundField DataField="FECHA_DESTINO" HeaderText="FechaHoraDestino" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSeleccionar" runat="server" CommandName="Seleccionar" CommandArgument='<%# Eval("CODIGO_PROGRAMACION_RUTA")%>' >Seleccionar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
