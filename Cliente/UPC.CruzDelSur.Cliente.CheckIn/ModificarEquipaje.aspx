<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ModificarEquipaje.aspx.cs" Inherits="ModificarEquipaje" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <title>.:| Empresa de Transportes Cruz del Sur</title>
</head>
<body class="mainbar" >
    <form id="form1" runat="server">--%>
    <div id="contenedor">
    <h2>GESTIONAR EQUIPAJE</h2>
    <h3>Listado de Tiket Pendientes de Asignar</h3>
    <br />              
    <h2>Boleto Nro: <asp:Label ID="lblNroBoleta" runat="server"></asp:Label></h2>
        
        <asp:GridView ID="grvDetalle" AutoGenerateColumns="False" AllowPaging="true" 
            DataKeyNames="Codigo" runat="server" 
            OnRowCommand="grvDetalle_RowCommand" 
            GridLines="None"
            CssClass="table"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt">  
        <Columns>
        <asp:TemplateField HeaderText="Acción">
            <ItemTemplate>
                <asp:ImageButton ID="ibtnConfirmar" runat="server" CausesValidation="false" CommandName="cmdModificarEquipaje" 
                    onClientClick="return confirm('Está seguro de modificar su Equipaje?')"
                    ImageUrl="~/img/ok.jpg" ToolTip="Asignar Tiket al Boleto" 
                    CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="100px" />
        </asp:TemplateField>
        <asp:BoundField HeaderText="Nro de Tiket" DataField="Numero">
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Peso" DataField="Peso">
        <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Tamaño" DataField="Tamano">
            <ItemStyle HorizontalAlign="Left"  Width="90px" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Código de Barra" DataField="CodBarra">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Estado Equipaje" DataField="EstadoEquipaje">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Tipo Equipaje" DataField="TipoEtiqueta">
            <ItemStyle HorizontalAlign="Left" Width="100px"  />
        </asp:BoundField>
        </Columns>      
            <EmptyDataTemplate>
                No se encontraron registros.
            </EmptyDataTemplate>            
        </asp:GridView>  
        
         <asp:Button ID="btnRegresar" runat="server" CssClass="mybtnstyle" Text="Regresar" onclick="btnRetornar_Click"/>
                      
    </div>
    <%--</form>
</body>
</html>--%>
</asp:Content>