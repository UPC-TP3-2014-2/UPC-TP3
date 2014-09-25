<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RegistrarTicketEquipaje.aspx.cs" Inherits="RegistrarTicketEquipaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  
<div class="panel-heading">Registrar Equipaje del Pasajero</div>
<br />
<div class="form-inline">
<div class="form-group">
&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Nro Boleto:"></asp:Label> &nbsp;&nbsp;
<asp:TextBox ID="txtNroBoleto1" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
<br />
<br />
&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Peso" MaxLength="8"></asp:Label> &nbsp;&nbsp;
<asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Tipo Equipaje" MaxLength="8"></asp:Label> &nbsp;&nbsp;
<asp:DropDownList ID="txtTipoEquipaje" runat="server" CssClass="form-control">
<asp:ListItem Value="FRAGIL"></asp:ListItem>
<asp:ListItem Value="NORMAL"></asp:ListItem>
</asp:DropDownList>
&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="Ubicacion"></asp:Label> &nbsp;&nbsp;
<asp:DropDownList ID="txtUbicacion" runat="server">
<asp:ListItem Value="BODEGA"></asp:ListItem>
</asp:DropDownList>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnConfirmarRegistroEquipaje" runat="server" Text="Confirmar Registro de Equipaje" CssClass="btn btn-success" OnClick="Button4_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnActualizarRegistroEquipaje" runat="server" Text="Actualizar Registro de Equipaje" CssClass="btn btn-success" OnClick="btnActualizarRegistroEquipaje_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancelarRegistroEquipaje" runat="server" Text="Cancelar Registro de Equipaje" CssClass="btn btn-success" OnClick="Button6_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--%> <br />
<br />
</div>
</div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>

