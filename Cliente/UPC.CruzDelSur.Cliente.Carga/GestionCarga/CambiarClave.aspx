<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="UPC.CruzDelSur.Cliente.Carga.GestionCarga.CambiarClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .fila
        {
            width: 30%;
            padding-left: 5%;
            margin-top: 5px;
            margin-bottom: 15px
        }
        .izquierda
        {
            width: 100%;
            display: inline-block;
            vertical-align: top;
        }
        
        .campoizquierda
        {
            width: 46%;
            display: inline-block;
            vertical-align: top;
        }
        .campo
        {
            color: #003399;
            font-weight: bold;
        }
        .campoderecha
        {
            width: 49%;
            display: inline-block;
            vertical-align: top;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cambiar clave de carga</h1>
    <style>

        .fila
        {
            width: 30%;
            padding-left: 5%;
            margin-top: 5px;
            margin-bottom: 15px
        }
        .izquierda
        {
            width: 100%;
            display: inline-block;
            vertical-align: top;
        }
        
        .campoizquierda
        {
            width: 46%;
            display: inline-block;
            vertical-align: top;
        }
        .campoderecha
        {
            width: 49%;
            display: inline-block;
            vertical-align: top;
        }
        .campo
        {
            color: #003399;
            font-weight: bold;
        }
        .validarCampo
        {
            color: Red;
        }
    </style>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">Numero:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lblNumeroFicha" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">Remitente:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lblRemitente" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">Destinatario:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lblDestinatario" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">Agencia Origen:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lblAgenciaOrigen" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">Agencia Destino:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lblAgenciaDestino" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">Importe Total:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lblImporteTotal" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">IGV:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lbligv" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">Total:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">Estado Pago:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lblEstadoPago" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div class="fila" style="display: inline-block;width:30%;vertical-align:top">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="campo">Clave de Seguridad:</span>
            </div>
            <div class="campoderecha">
                <asp:Label ID="lblClave" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <div style="display: inline-block;width:30%;vertical-align:top">
        <asp:Button ID="btnIngresarCodigo" runat="server" Text="Cambiar Clave" />
    </div>
    <br />
    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
    <asp:HiddenField ID="hffichacarga" runat="server" />
</asp:Content>
