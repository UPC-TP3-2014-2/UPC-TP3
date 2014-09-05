<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImprimirEquipaje.aspx.cs" Inherits="ImprimirEquipaje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h2>DATOS DE EQUIPAJE</h2>  
     <fieldset style="margin:10px; padding:10px;">
     <legend style="font-size:14px">INFORMACIÓN DE EQUIPAJE</legend>
         <table width="100%">
         <tr>
         <td style="width:250px">NÚMERO DE BOLETO: </td>
         <td><asp:Label ID="lblNroBol" runat="server" ></asp:Label></td>
         </tr>
         <tr>
         <td>APELLIDOS Y NOMBRES DEL PASAJERO: </td>
         <td><asp:Label ID="lblPasajero" runat="server"></asp:Label></td>
         </tr>
         </table>
     </fieldset>

     <fieldset style="margin:10px; padding:10px">

     <legend style="font-size:14px">DATOS DEL ITINERARIO</legend>
          <table width="90%">
         <tr>
         <td>ORIGEN: </td>             
         <td>DESTINO: </td>  
         <td>FECHA SALIDA: </td>             
         <td>HORA SALIDA: </td>            
         </tr>
         <tr>
         <td><asp:Label ID="lblOrigen" runat="server" ></asp:Label></td>
         <td><asp:Label ID="lblDestino" runat="server" ></asp:Label></td>
         <td><asp:Label ID="lblFechaSalida" runat="server" ></asp:Label></td>
         <td><asp:Label ID="lblHoraSalida" runat="server" ></asp:Label></td>
         </tr>
         </table>
     </fieldset>
     <br />
     <fieldset style="margin:10px; padding:10px">
     <legend style="font-size:14px">DETALLE DEL EQUIPAJE</legend>

     <asp:GridView ID="grvDetalle" AutoGenerateColumns="False" runat="server" 
            GridLines="Vertical" Width="90%"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" BackColor="White" BorderColor="#DEDFDE" 
             BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">  
<AlternatingRowStyle CssClass="alt" BackColor="White"></AlternatingRowStyle>
        <Columns>
        <asp:BoundField HeaderText="Nro" DataField="CodBoleto">
            <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Peso" DataField="Peso">
        <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Estado" DataField="EstadoEquipaje">
            <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>        
        <asp:BoundField HeaderText="Tipo de Equipaje" DataField="TipoEquipaje">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Ubicacion" DataField="Ubicacion">
            <ItemStyle HorizontalAlign="Left"   />
        </asp:BoundField>
        </Columns>      
            <EmptyDataTemplate>
                No se encontraron registros.
            </EmptyDataTemplate>            
         <FooterStyle BackColor="#CCCC99" />
         <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />

<PagerStyle CssClass="pgr" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right"></PagerStyle>
         <RowStyle BackColor="#F7F7DE" />
         <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#FBFBF2" />
         <SortedAscendingHeaderStyle BackColor="#848384" />
         <SortedDescendingCellStyle BackColor="#EAEAD3" />
         <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>

     </fieldset>
    </div>
    </form>
</body>
</html>
