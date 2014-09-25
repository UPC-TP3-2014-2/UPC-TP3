<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RegistrarTicketEquipaje.aspx.cs" Inherits="RegistrarTicketEquipaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    


     <h2 class="h2">Registrar Equipaje del Pasajero</h2>
    
    <br />


        <div class="panel panel-default">

  <div class="panel-heading">Información de equipaje</div>

          
            <br />

          
  <div class="form-inline">
   
        <div class="form-group">
            &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Nro Boleto:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtNroBoleto1" runat="server" MaxLength="10" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Codigo Barra:"></asp:Label>
            <asp:TextBox ID="txtCodigoBarra" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
            
            <br />
            <br />
            &nbsp;&nbsp;

            <asp:Label ID="Label2" runat="server" Text="Ancho:"></asp:Label>
            <asp:TextBox ID="txtAncho" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Alto:"></asp:Label>
            <asp:TextBox ID="txtAlto" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Peso" MaxLength="8"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
            &nbsp;&nbsp;
            <%--<asp:Label ID="Label6" runat="server" Text="Tamaño" MaxLength="8"></asp:Label>
            <asp:TextBox ID="txtTamano" runat="server" CssClass="form-control"></asp:TextBox>
            &nbsp;&nbsp;--%>
            <asp:Label ID="Label8" runat="server" Text="Tipo Equipaje" MaxLength="8"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="txtTipoEquipaje" runat="server" CssClass="form-control">
                <asp:ListItem Value="0">--Seleccione--</asp:ListItem>
                <asp:ListItem Value="1">Pesado</asp:ListItem>
                <asp:ListItem Value="2">Ligero</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="Ubicacion"></asp:Label>
            &nbsp;&nbsp;
            
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                <asp:ListItem Value="1">Bodega</asp:ListItem>
                <asp:ListItem Value="2">Local</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;
             <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
            <br />
            <br />

              </div>
        </div>
            </div>
            <asp:GridView ID="GridView1" runat="server" GridLines="None"
                CssClass="table" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False">
                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                <Columns>
                    <asp:BoundField DataField="CodBoleto" HeaderText="NroBoleto" />
                    <asp:BoundField DataField="CodBarra" HeaderText="NroBarras" />
                    <asp:BoundField DataField="tamano" HeaderText="Tamaño" />
                    <asp:BoundField DataField="Peso" HeaderText="Peso" />
                    <asp:BoundField DataField="TipoEtiqueta" HeaderText="Tipo" />
                    <asp:BoundField DataField="ubicacion" HeaderText="Ubicacion" />
                </Columns>
            </asp:GridView>

            <br />
            <br />
            <asp:Button ID="btnConfirmarRegistroEquipaje" runat="server" Text="Confirmar Registro de Equipaje" CssClass="btn btn-success" OnClick="btnConfirmarRegistroEquipaje_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        
  
          
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="Server">
</asp:Content>

