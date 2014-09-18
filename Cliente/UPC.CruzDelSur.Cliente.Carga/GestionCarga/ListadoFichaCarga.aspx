<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoFichaCarga.aspx.cs" Inherits="CRUZDELSUR.UI.Web.GestionCarga.ListadoFichaCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/OpenModalDialog.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            color: #003399;
        }
    </style>
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
                    <asp:ListItem Value="1">Ficha de Carga</asp:ListItem>
                    <asp:ListItem Value="2">Remitente</asp:ListItem>
                    <asp:ListItem Value="3">Destinatario</asp:ListItem>
                    <asp:ListItem Value="4">DNI Remitente</asp:ListItem>
                    <asp:ListItem Value="5">DNI Destinatario</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <span class="auto-style1"><strong>Dato</strong></span><span class="style5">:</span></td>
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
        AutoGenerateColumns="False" onrowcommand="gvfichacarga_RowCommand" EmptyDataText="No se ah ingresado ni una ficha" 
        onrowdatabound="gvfichacarga_RowDataBound">
        <Columns>
            <asp:BoundField DataField="FICHA" HeaderText="Ficha" />
            <asp:BoundField DataField="ORIGEN" HeaderText="Origen" />
            <asp:BoundField DataField="DESTINO" HeaderText="Destino" />
            <asp:BoundField DataField="FECHA_ORIGEN" HeaderText="FechaHoraOrigen" />
            <asp:BoundField DataField="FECHA_DESTINO" HeaderText="FechaHoraDestino" />
            <asp:BoundField DataField="REMITENTE" HeaderText="Remitente" />
            <asp:BoundField DataField="DESTINATARIO" HeaderText="Destinatario" />
            <asp:BoundField DataField="CLIENTE_ORIGEN" HeaderText="DNI Remitente" />
            <asp:BoundField DataField="CLIENTE_DESTINO" HeaderText="DNI Destino" />
            <asp:BoundField DataField="ESTADOPAGO" HeaderText="Estado Pago" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado Carga" />
            
            <asp:TemplateField HeaderText="Àcciones">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkModificar" runat="server" CommandName="Modificar" CommandArgument='<%# Eval("CODIGO_CARGA")%>' >Modificar</asp:LinkButton>
                    <asp:LinkButton ID="lnkButtonValidar" runat="server" CommandName="validar" CommandArgument='<%# Eval("CODIGO_CARGA")%>'  >Valida</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Anular"  CommandArgument='<%# Eval("CODIGO_CARGA")%>' OnClientClick="javascript:if(confirm('Desea anular la ficha?') == false) return false;">Anula</asp:LinkButton>


                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Imprimir" CommandArgument='<%# Eval("CODIGO_CARGA")%>' >Imprimir</asp:LinkButton>/
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
