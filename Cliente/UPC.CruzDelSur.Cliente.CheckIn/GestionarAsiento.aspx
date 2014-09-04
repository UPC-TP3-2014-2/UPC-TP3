<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionarAsiento.aspx.cs" Inherits="GestionarAsiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="css/style.css" rel="stylesheet" type="text/css" />
    <title>.:| Empresa de Transportes Cruz del Sur</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor">
    <h2>GESTIONAR ASIENTO</h2>
    <h3>Asientos Disponibles</h3>
    <br />
        <asp:GridView ID="grvAsientos" runat="server" AutoGenerateColumns="False" AllowPaging="true" 
            DataKeyNames="Asiento" 
            OnRowCommand="grvAsientos_RowCommand" 
            GridLines="None"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt"> 
            <Columns>
        <asp:TemplateField HeaderText="Acción">
            <ItemTemplate>
                <asp:ImageButton ID="ibtnCambiar" runat="server" CausesValidation="false" CommandName="cmdCambiarAsiento" 
                    onClientClick="return confirm('Está seguro de confirmar su asiento?')"
                    ImageUrl="~/img/ok.jpg" ToolTip="Check In" 
                    CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:TemplateField>
        <asp:BoundField HeaderText="Cod.Vehiculo" DataField="CodVehiculo" Visible="False">
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Placa" DataField="Placa">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Fecha Salida" DataField="FechaSalida">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Hora Salida" DataField="HoraSalida">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Asiento" DataField="Asiento">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Est.Asiento" DataField="EstadoAsiento">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        </Columns>      
            <EmptyDataTemplate>
                No se encontraron registros.
            </EmptyDataTemplate>    
        </asp:GridView>
        <br />
        <asp:Button ID="btnRetornar" runat="server" Text="Regresar" 
            onclick="btnRetornar_Click" />

    </div>
    </form>
</body>
</html>
