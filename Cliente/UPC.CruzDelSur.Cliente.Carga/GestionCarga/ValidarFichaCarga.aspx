<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true"
    CodeBehind="ValidarFichaCarga.aspx.cs" Inherits="CRUZDELSUR.UI.Web.GestionCarga.ValidarFichaCarga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Validar Entregar de carga
    </h1>
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
        

        <asp:Button ID="btnIngresarCodigo" runat="server" Text="Ingresar Clave" 
            />
    </div>
    <br />
    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    <asp:HiddenField ID="hffichacarga" runat="server" />
</asp:Content>
