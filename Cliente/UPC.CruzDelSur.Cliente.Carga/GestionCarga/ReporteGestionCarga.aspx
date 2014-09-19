<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ReporteGestionCarga.aspx.cs" Inherits="UPC.CruzDelSur.Cliente.Carga.GestionCarga.ReporteGestionCarga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .fila {
            width: 100%;
        }

        .izquierda {
            width: 45%;
            display: inline-block;
            vertical-align: top;
        }

        .derecha {
            width: 45%;
            display: inline-block;
            vertical-align: top;
        }

        .campoizquierda {
            width: 46%;
            display: inline-block;
            vertical-align: top;
        }

        .campoderecha {
            width: 49%;
            display: inline-block;
            vertical-align: top;
        }

        .campo {
            color: #003399;
            font-weight: bold;
        }

        .validarCampo {
            color: Red;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/js/jscal2.js"></script>
    <script src="../Scripts/js/lang/es.js"></script>


    <link href="../Styles/css/jscal2.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/css/border-radius.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/css/steel/steel.css" rel="stylesheet" type="text/css" />

    Vista Preliminar:
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1"  >

<img src="../img/descarga.jpg" width="7%" />

    </asp:LinkButton>




    <h5>Ficha de Carga</h5>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                Agencia Origen
            </div>
            <div class="campoderecha">
                <asp:DropDownList ID="ddlAgenciaOrigen" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="derecha">
            <div class="campoizquierda">
                Agencia Destino
            </div>
            <div class="campoderecha">
                <asp:DropDownList ID="dllAgenciaDestino" runat="server">
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                Estado de Carga
            </div>
            <div class="campoderecha">

                <asp:DropDownList ID="ddlEstadocarga" runat="server" Width="116px">
                    <asp:ListItem Value="Entregado">Entregado</asp:ListItem>
                    <asp:ListItem Value="Registrado">Registrado</asp:ListItem>
                    <asp:ListItem Value="Anulado">Anulado</asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>
        <div class="derecha">
            <div class="campoizquierda">
                Estado de Pago
            </div>
            <div class="campoderecha">

                <asp:DropDownList ID="ddEstadoPago" runat="server" Width="116px">
                    <asp:ListItem Value="Cancelado">Cancelado</asp:ListItem>
                    <asp:ListItem Value="Por Cancelar">Por Cancelar</asp:ListItem>
                    
                    
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <h5>Fecha Programada</h5>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                Fecha de Salida
            </div>
            <div class="campoderecha">
                <asp:TextBox ID="txtFechaSalida" runat="server"></asp:TextBox>

                <img src="../img/Calendario.png" id="f_btn1fechasalida" />


            </div>
        </div>
        <div class="derecha">
            <div class="campoizquierda">
                Fecha Llegada
            </div>
            <div class="campoderecha">
                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                <img src="../img/Calendario.png" id="f_btn1fechallegada" />
            </div>
        </div>
    </div>
    <br />
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />


    <asp:GridView ID="gvDetalle" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvDetalle_RowDataBound" EmptyDataText="No Existen Datos..">
        <Columns>
            <asp:BoundField DataField="FICHA" HeaderText="Nro Ficha" />
            <asp:BoundField DataField="REMITENTE" HeaderText="Remitente" />
            <asp:BoundField DataField="DESTINATARIO" HeaderText="Destinatario" />
            <asp:BoundField DataField="ORIGEN" HeaderText="Origen" />
            <asp:BoundField DataField="DESTINO" HeaderText="Destino" />
            <asp:BoundField DataField="FECHA_ORIGEN" HeaderText="Fecha Envio" />
            <asp:BoundField DataField="FECHA_DESTINO" HeaderText="Fecha Llegada" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado carga" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetalle" runat="server" ImageUrl="~/img/Search.ico" AlternateText="Ver Detalle" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <script type="text/javascript">//<![CDATA[
        Calendar.setup({
            inputField: "MainContent_txtFechaSalida",
            trigger: "f_btn1fechasalida",
            onSelect: function () { this.hide() },
            showTime: 12,
            dateFormat: "%d/%m/%Y"
        });

        Calendar.setup({
            inputField: "MainContent_txtFechaFin",
            trigger: "f_btn1fechallegada",
            onSelect: function () { this.hide() },
            showTime: 12,
            dateFormat: "%d/%m/%Y"
        });

        //]]></script>

</asp:Content>
