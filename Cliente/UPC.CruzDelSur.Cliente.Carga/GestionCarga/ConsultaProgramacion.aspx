<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="ConsultaProgramacion.aspx.cs" Inherits="UPC.CruzDelSur.Cliente.Carga.GestionCarga.ConsultaProgramacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Consultar Programacion Ruta
    </h1>
    <script src="../Scripts/OpenModalDialog.js" type="text/javascript"></script>
    Agencia Destino
    <asp:DropDownList ID="ddlAgencias" runat="server">
        <asp:ListItem Value="2">Lima</asp:ListItem>
        <asp:ListItem Value="5">Piura</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" 
        onclick="btnConsultar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    <br />
    <br />

    <asp:GridView ID="gvProgramacionRuta" runat="server" Width="100%" 
        AutoGenerateColumns="False" onrowcommand="gvProgramacionRuta_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdAgenciaOrigen" HeaderText="IdAgenciaOrigen" 
                Visible="False" />
            <asp:BoundField DataField="Origen" HeaderText="AgenciaOrigen" />
            <asp:BoundField DataField="IdAgenciaDestino" Visible="False" />
            <asp:BoundField DataField="Destino" HeaderText="AgenciaDestino" />
            
            <asp:BoundField DataField="FechaHoraOrigen" HeaderText="FechaHoraOrigen" />
            <asp:BoundField DataField="FechaHoraDestino" HeaderText="FechaHoraDestino" />
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSeleccionar" runat="server" CommandName="Seleccionar" CommandArgument='<%# Eval("MK_ProgramacionRuta_ID")%>' >Seleccionar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
