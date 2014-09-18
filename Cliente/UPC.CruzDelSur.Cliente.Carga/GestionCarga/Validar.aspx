<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="Validar.aspx.cs" Inherits="CRUZDELSUR.UI.Web.GestionCarga.Validar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
             Ingrese Clave
    </div>
    <div>
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Aceptar" 
        onclick="Button1_Click" />

</asp:Content>
