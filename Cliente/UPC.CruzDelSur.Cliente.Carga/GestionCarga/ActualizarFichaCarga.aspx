<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ActualizarFichaCarga.aspx.cs" Inherits="UPC.CruzDelSur.Cliente.Carga.GestionCarga.ActualizarFichaCarga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .fila
        {
            width: 80%;
            padding-left: 17%;
        }
        .izquierda
        {
            width: 33%;
            display: inline-block;
            vertical-align: top;
        }
        .derecha
        {
            width: 39%;
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
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('.lightbox').lightbox();


        });
        function CalcularPesoTotal() {
            var textBoxes = document.getElementsByClassName("csspesoTotal");
            pesototal = 0;
            for (var i = 0; i < textBoxes.length; i++) {
                //pesototal = pesototal + $('#' + textBoxes[i].id).val());

                if ($('#' + textBoxes[i].id).val() == "")
                { }
                else {
                    pesototal = pesototal + parseInt($('#' + textBoxes[i].id).val());
                }

                $("#MainContent_txtPesoTotal").val(pesototal);
            }
        }


        function CalcularImporteTotal() {
            var textBoxes = document.getElementsByClassName("cssImporteTotal");
            importetoal = 0;
            for (var i = 0; i < textBoxes.length; i++) {
                //pesototal = pesototal + $('#' + textBoxes[i].id).val());

                if ($('#' + textBoxes[i].id).val() == "")
                { }
                else {
                    importetoal = importetoal + parseInt($('#' + textBoxes[i].id).val());
                }

                $("#MainContent_txtImporteTotal").val(importetoal);
            }
        }


        function CalcularImporteProducto(idcantidad, idPrecio, idImporte) {
            $('#' + idImporte).val($('#' + idcantidad).val() * $('#' + idPrecio).html());
            CalcularImporteTotal();
        }

    </script>
    <p>
        <br />
        <br />
        <div class="fila">
            <div class="izquierda">
                <div class="campoizquierda">
                    <span class="campo">Ficha:</span>
                </div>
                <div class="campoderecha">
                    <asp:TextBox ID="txtFicha" runat="server" Width="121px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe Ingresar un numero de ficha"
                        ControlToValidate="txtFicha" CssClass="validarCampo"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="derecha">
            </div>
        </div>
        <div class="fila">
            <div class="izquierda">
                <div class="campoizquierda">
                    <span class="campo">Agencia Origen:</span>
                </div>
                <div class="campoderecha">
                    <asp:DropDownList ID="ddlAgenciaOrigen" runat="server" Enabled="false">
                        <asp:ListItem Value="2">Lima</asp:ListItem>
                        <asp:ListItem Value="5">Piura</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="derecha">
            </div>
        </div>
        <br />
        <div class="fila">
            <strong>Datos Programacion Ruta</strong>
        </div>
        <br />
        <div class="fila">
            <div class="izquierda">
                <div class="campoizquierda">
                    <span class="campo">Agencia Destino:</span>
                </div>
                <div class="campoderecha">
                    <asp:DropDownList ID="ddlAgenciaDestino" runat="server" Enabled="False">
                        <asp:ListItem Value="2">Lima</asp:ListItem>
                        <asp:ListItem Value="5">Piura</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="derecha">
                <asp:Button ID="btnConsultaProgramacion" runat="server" OnClientClick="javascript:OpenModalDialog('ConsultaProgramacion.aspx','null','400','800')"
                    Text="Consultar Programacion" Width="184px" />
            </div>
        </div>
        <div class="fila">
            <div class="izquierda">
                <div class="campoizquierda">
                    <span class="campo">FechaHoraSalida:</span>
                </div>
                <div class="campoderecha">
                    <asp:TextBox ID="txtFechasalida" runat="server" Enabled="False" Width="121px"></asp:TextBox>
                </div>
            </div>
            <div class="derecha">
                <div class="campoizquierda">
                    <span class="campo">FechaHoraLlegada:</span>
                </div>
                <div class="campoderecha">
                    <asp:TextBox ID="txtfechallegada" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="fila">
            <div class="izquierda">
                <div class="campoizquierda">
                    <span class="campo">Unid. Transporte:</span>
                </div>
                <div class="campoderecha">
                    <asp:TextBox ID="txtUnidadTransporte" runat="server" Enabled="False" Width="121px"></asp:TextBox>
                </div>
            </div>
            <div class="derecha">
                <div class="campoizquierda">
                </div>
                <div class="campoderecha">
                </div>
            </div>
        </div>
        <br />
        <div class="fila">
            <strong>Datos Carga</strong>
        </div>
        <br />
        <div class="fila">
            <div class="izquierda">
                <div class="campoizquierda">
                    <span class="campo">Remitente:</span>
                </div>
                <div class="campoderecha">
                    <asp:TextBox ID="txtRemitente" runat="server" Enabled="False" Width="121px"></asp:TextBox>
                </div>
            </div>
            <div class="derecha">
                <div class="campoizquierda">
                    <span class="campo">DNI Remitente:</span>
                </div>
                <div class="campoderecha">
                    <asp:TextBox ID="txtDniRemitente" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" OnClientClick="javascript:OpenModalDialog('ConsultaCliente.aspx?opt=1','null','400','800')"
                        Text="Buscar" />
                </div>
            </div>
        </div>
        <div class="fila">
            <div class="izquierda">
                <div class="campoizquierda">
                    <span class="campo">Destinatario:</span>
                </div>
                <div class="campoderecha">
                    <asp:TextBox ID="txtDestinatario" runat="server" Enabled="False" Width="121px"></asp:TextBox>
                </div>
            </div>
            <div class="derecha">
                <div class="campoizquierda">
                    <span class="campo">DNI Destinatario:</span>
                </div>
                <div class="campoderecha">
                    <asp:TextBox ID="txtDNIDestinatario" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" OnClientClick="javascript:OpenModalDialog('ConsultaCliente.aspx?opt=2','null','400','800')"
                        Text="Buscar" />
                </div>
            </div>
        </div>
        <br />
    </p>
    <div style="text-align: right; padding-right: 15%;">
        <asp:Button ID="btnAgregarProducto" runat="server" OnClientClick="javascript:OpenModalDialog('ConsultaProducto.aspx','null','400','800')"
            Text="Agregar" />
    </div>
    <br />
    <asp:GridView ID="gvProductos" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False"
        OnRowCommand="gvProductos_RowCommand" Width="70%" OnRowDataBound="gvProductos_RowDataBound">
        <Columns>
            <asp:BoundField DataField="MG_ES03_Producto_ID" HeaderText="ID" />
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion	" />
            <asp:TemplateField HeaderText="Precio">
                <ItemTemplate>
                    <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("Precio")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="TipoCarga" HeaderText="Tipo Carga" />
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <asp:TextBox ID="txtCantidad" runat="server" Width="40px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Peso">
                <ItemTemplate>
                    <asp:TextBox ID="txtPeso" runat="server" Width="40px" CssClass='csspesoTotal'></asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Importe">
                <ItemTemplate>
                    <asp:TextBox ID="txtimporte" runat="server" Width="40px" CssClass="cssImporteTotal"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("MG_ES03_Producto_ID")%>'
                        CommandName="Eliminar">Eliminar</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </p>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="style4"><strong>Peso Total:</strong></span>
            </div>
            <div class="campoderecha">
                <asp:TextBox ID="txtPesoTotal" runat="server" Width="115px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe Ingresar un numero de ficha"
                    ControlToValidate="txtPesoTotal" CssClass="validarCampo"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="derecha">
            <div class="campoizquierda">
                <span class="style4"><strong>Importe Total:</strong></span>
            </div>
            <div class="campoderecha">
                <asp:TextBox ID="txtImporteTotal" runat="server" Width="115px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe Ingresar un numero de ficha"
                    ControlToValidate="txtImporteTotal" CssClass="validarCampo"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="style4"><strong>Tipo Pago:</strong></span>
            </div>
            <div class="campoderecha">
                <asp:DropDownList ID="ddlTipoPago" runat="server" Width="116px">
                    <asp:ListItem Value="Cancelado">Contado</asp:ListItem>
                    <asp:ListItem Value="Por Cancelar">Contra Entrega</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="derecha">
        </div>
    </div>
    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="style4"><strong>Observacion:</strong></span>
            </div>
            <div class="campoderecha">
                <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="115px"></asp:TextBox>
            </div>
        </div>
        <div class="derecha">
        </div>
    </div>
    <br />
    <div class="fila" style="display: inline-block; vertical-align: top">
        <div style="width: 15%; display: inline-block; vertical-align: top">
            <span class="style4"><strong>Codigo Seguridad:</strong></span>
        </div>
        <div style="width: 16%; display: inline-block; vertical-align: top; border: solid 1px;
            height: 20px">
            <asp:Label ID="lblClave" runat="server"></asp:Label>
        </div>
        <asp:Button ID="btnIngresarCodigo" runat="server" Text="Ingresar Clave" OnClick="btnIngresarCodigo_Click"
            OnClientClick="javascript:OpenModalDialog('Validar.aspx?opt=1','null','400','800')" />
        <asp:Button ID="Button1" runat="server" Text="Validar Clave" OnClick="btnIngresarCodigo_Click"
            OnClientClick="javascript:OpenModalDialog('Validar.aspx?opt=2','null','400','800')" />
    </div>
    <br />
    <br />
    <div class="fila">
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
        <asp:Button ID="btnCancelar" runat="server" Text="cancelar" OnClick="btnCancelar_Click" />
    </div>
    <asp:HiddenField ID="HFIdClienteDest" runat="server" />
    <asp:HiddenField ID="HFIdClienteRemi" runat="server" />
    <asp:HiddenField ID="MK_ProgramacionRuta_ID" runat="server" />
    <asp:HiddenField ID="hffichacarga" runat="server" />
</asp:Content>
