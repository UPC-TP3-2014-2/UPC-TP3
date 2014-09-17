<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ActualizarFichaCarga.aspx.cs" Inherits="CRUZDELSUR.UI.Web.GestionCarga.ActualizarFichaCarga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .fila {
            width: 80%;
            padding-left: 17%;
        }

        .izquierda {
            width: 33%;
            display: inline-block;
            vertical-align: top;
        }

        .derecha {
            width: 39%;
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

    <script src="../Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {


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
            var importetoal = 0;

            for (var i = 0; i < textBoxes.length; i++) {
                //pesototal = pesototal + $('#' + textBoxes[i].id).val());

                if ($('#' + textBoxes[i].id).val() == "")
                { }
                else {
                    importetoal = parseFloat(importetoal) + parseFloat($('#' + textBoxes[i].id).val());
                }

                $("#MainContent_txtImporteTotal").val(parseFloat(importetoal).toFixed(2));
                $("#MainContent_txtigv").val(parseFloat(importetoal * 0.18).toFixed(2));
                $("#MainContent_txtTotal").val(parseFloat(importetoal * 1.18).toFixed(2));


            }
        }


        function CalcularImporteProducto(idcantidad, idPrecio, peso, idImporte) {

            $('#' + idImporte).val($('#' + peso).val() * $('#' + idcantidad).val() * $('#' + idPrecio).html());

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
                        ControlToValidate="txtFicha" CssClass="validarCampo" ValidationGroup="validarficha"></asp:RequiredFieldValidator>
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
                        <asp:ListItem Value="1">Lima</asp:ListItem>
                        <asp:ListItem Value="2">Piura</asp:ListItem>
                        <asp:ListItem Value="3">Ica</asp:ListItem>
                        <asp:ListItem Value="4">Arequipa</asp:ListItem>
                        <asp:ListItem Value="5">Tacna</asp:ListItem>
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
                        <asp:ListItem Value="1">Lima</asp:ListItem>
                        <asp:ListItem Value="2">Piura</asp:ListItem>
                        <asp:ListItem Value="3">Ica</asp:ListItem>
                        <asp:ListItem Value="4">Arequipa</asp:ListItem>
                        <asp:ListItem Value="5">Tacna</asp:ListItem>
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

                    <asp:TextBox ID="txtDniRemitente" runat="server" Width="80px"></asp:TextBox>

                    <asp:RegularExpressionValidator id="RegularExpressionValidator1" ValidationGroup="dniRemitente" runat="server" ErrorMessage="Solo Números" ValidationExpression="\d+" CssClass="validarCampo" Display="Dynamic" ControlToValidate="txtDniRemitente"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="dniRemitente" runat="server" ErrorMessage="Debe ingresar su DNI" CssClass="validarCampo" ControlToValidate="txtDniRemitente" Display="Dynamic" ></asp:RequiredFieldValidator>


                    <asp:Button ID="Button2" runat="server"
                        Text="Buscar" OnClick="Button2_Click" ValidationGroup="dniRemitente" />


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
                    <asp:TextBox ID="txtDNIDestinatario" runat="server" Width="80px"></asp:TextBox>
                    <asp:RegularExpressionValidator id="RegularExpressionValidator2" ValidationGroup="dniDestinatario" runat="server" ErrorMessage="Solo Números" ValidationExpression="\d+" CssClass="validarCampo" Display="Dynamic" ControlToValidate="txtDNIDestinatario"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="dniDestinatario" runat="server" ErrorMessage="Debe ingresar su DNI" CssClass="validarCampo" ControlToValidate="txtDNIDestinatario" Display="Dynamic" ></asp:RequiredFieldValidator>

                    <asp:Button ID="Button3" runat="server"  ValidationGroup="dniDestinatario"
                        Text="Buscar" OnClick="Button3_Click" />
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
        OnRowCommand="gvProductos_RowCommand" Width="70%" OnRowDataBound="gvProductos_RowDataBound" EmptyDataText="Debe Seleccionar un producto, haga click en Agregar">
        <Columns>
            <asp:BoundField DataField="CODIGO_PRODUCTO" HeaderText="ID" />
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Producto" />

            <asp:TemplateField HeaderText="Tipo carga">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlTipoCarga" runat="server">
                        <asp:ListItem Value="1">Fragil</asp:ListItem>
                        <asp:ListItem Value="2" Selected="True">Normal</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Precio">
                <ItemTemplate>
                    <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("Precio")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <asp:TextBox ID="txtCantidad" runat="server" Width="40px" Text='<%# Eval("CANTIDAD")%>'></asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Peso">
                <ItemTemplate>
                    <asp:TextBox ID="txtPeso" runat="server" Width="40px" CssClass='csspesoTotal' Text='<%# Eval("DBL_PESO")%>'></asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Importe">
                <ItemTemplate>
                    <asp:TextBox ID="txtimporte" runat="server" Width="40px" CssClass="cssImporteTotal" Text='<%# Eval("DBL_IMPORTE")%>'></asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("CODIGO_PRODUCTO")%>'
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
                <asp:TextBox ID="txtPesoTotal" runat="server" Width="115px" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe Ingresar un numero de ficha"
                    ControlToValidate="txtPesoTotal" CssClass="validarCampo" ValidationGroup="validarficha" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="derecha">
            <div class="campoizquierda">
                <span class="style4"><strong>Importe Total:</strong></span>
            </div>
            <div class="campoderecha">
                <asp:TextBox ID="txtImporteTotal" runat="server" Width="115px" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe Ingresar un numero de ficha"
                    ControlToValidate="txtImporteTotal" CssClass="validarCampo" ValidationGroup="validarficha" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>





    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="style4"><strong>IGV:</strong></span>
            </div>
            <div class="campoderecha">
                <asp:TextBox ID="txtigv" runat="server" Width="115px" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <div class="derecha">
            <div class="campoizquierda">
                <span class="style4"><strong>Total:</strong></span>
            </div>
            <div class="campoderecha">
                <asp:TextBox ID="txtTotal" runat="server" Width="115px" Enabled="False"></asp:TextBox>

            </div>
        </div>
    </div>

    <br />


    <div class="fila">
        <div class="izquierda">
            <div class="campoizquierda">
                <span class="style4"><strong>Tipo Pago:</strong></span>
            </div>
            <div class="campoderecha">
                <asp:DropDownList ID="ddlTipoPago" runat="server" Width="116px">
                    <asp:ListItem Value="Cancelado">Pago Origen</asp:ListItem>
                    <asp:ListItem Value="Por Cancelar">Pago Origen</asp:ListItem>
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
        <div style="width: 16%; display: inline-block; vertical-align: top; border: solid 1px; height: 20px">
            <asp:Label ID="lblClave" runat="server"></asp:Label>
        </div>
        <asp:Button ID="btnIngresarCodigo" runat="server" Text="Ingresar Clave" OnClick="btnIngresarCodigo_Click"
            OnClientClick="javascript:OpenModalDialog('Validar.aspx?opt=1','null','400','800')" />
    </div>
    <br />
    <br />
    <div class="fila">
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" ValidationGroup="validarficha" />
        <asp:Button ID="btnCancelar" runat="server" Text="cancelar" OnClick="btnCancelar_Click" />
    </div>
    <asp:HiddenField ID="HFIdClienteDest" runat="server" />
    <asp:HiddenField ID="HFIdClienteRemi" runat="server" />
    <asp:HiddenField ID="MK_ProgramacionRuta_ID" runat="server" />
    <asp:HiddenField ID="hffichacarga" runat="server" Value="0" />
</asp:Content>
