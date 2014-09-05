<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoFichaCarga.aspx.cs" Inherits="UPC.CruzDelSur.Cliente.Carga.GestionCarga.ListadoFichaCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/OpenModalDialog.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<center> 
   <br /><asp:Label ID="Label1" runat="server" Text="Listados de Fichas de Carga" 
        
           style="font-weight: 700; color: #003399; font-size: medium; text-align: center" 
           ForeColor="#000066"></asp:Label>
       <br />
<br />
<table align="center" style="height: 146px; width: 59%; border-color:Black" border="1" >
        <tr>
            <td>
     
    <table align="center" class="style1">
        <tr>
            <td class="style2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style3"><strong style="color: #003399">Buscar</strong></span>:</td>
            <td class="style4">
                <asp:DropDownList ID="DdlCriterio" runat="server" Width="170px">
                    <asp:ListItem Value="0">----Seleccionar----</asp:ListItem>
                    <asp:ListItem Value="1">Remitente</asp:ListItem>
                    <asp:ListItem Value="2">Destinatario</asp:ListItem>
                    <asp:ListItem Value="3">Dni-Destinatario</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                Dato<span class="style5">:</span></td>
            <td class="style4">
    <asp:TextBox ID="txtdato" runat="server"></asp:TextBox>
            </td>
            <td align="center">
                <asp:Button ID="btnbuscar" runat="server" Text=" Buscar" 
                    onclick="btnbuscar_Click" />
            </td>
        </tr>
    </table>
             </td>
        </tr>
    </table>
    <br />
    
    <br />
    <asp:GridView ID="gvfichacarga" runat="server" Height="159px" Width="716px" 
        AutoGenerateColumns="False" onrowcommand="gvfichacarga_RowCommand" 
        onrowdatabound="gvfichacarga_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Ficha" HeaderText="Ficha" />
            <asp:BoundField DataField="Origen" HeaderText="Origen" />
            <asp:BoundField DataField="Destino" HeaderText="Destino" />
            <asp:BoundField DataField="FechaHoraOrigen" HeaderText="FechaHoraOrigen" />
            <asp:BoundField DataField="FechaHoraDestino" HeaderText="FechaHoraDestino" />
            <asp:BoundField DataField="Remitente" HeaderText="Remitente" />
            <asp:BoundField DataField="Destinatario" HeaderText="Destinatario" />
            <asp:BoundField DataField="DestiDni" HeaderText="DestiDni" />
            <asp:TemplateField HeaderText="Àcciones">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkModificar" runat="server" CommandName="Modificar" CommandArgument='<%# Eval("MG_ES01_FichaCarga_ID")%>' >Modificar</asp:LinkButton>/
                    <asp:LinkButton ID="lnkButtonValidar" runat="server" CommandName="validar" CommandArgument='<%# Eval("MG_ES01_FichaCarga_ID")%>'  >Valida</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server">Anula</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    
    <table class="style6">
        <tr>
            <td class="style7">
                <asp:Button ID="btnnuevo" runat="server" Text="Nuevo" 
                    onclick="btnnuevo_Click" />
            </td>
            <td>
                <asp:Button ID="btncancelar" runat="server" Text="Cancelar" />
            </td>
        </tr>
    </table>
    </center>
    <br />
    <br />
</asp:Content>
