<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GestionarEquipaje.aspx.cs" Inherits="GestionarEquipaje" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>

    <
    <script type="text/javascript">
        function mostrar() {
            document.getElementById('oculto').style.display = 'block';
            
        }
        </script>
       
    
 
    <div id="contenedor">
    <h2>Gestionar Equipaje</h2>
    <br />
         <div class="panel panel-default">

  <div class="panel-heading">Criterios de búsqueda</div>

          
            <br />

          
  <div class="form-inline">
      <div class="form-group">
       &nbsp;       &nbsp;
            <asp:Label ID="Label1" runat="server" Text="Nro Boleto:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtNroBoleto" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="DNI" MaxLength="8"></asp:Label>

             &nbsp;&nbsp;
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Pasajero" CssClass="btn btn-success" 
                onclick="btnBuscar_Click" />
               <br />
          <br />

          </div>
             </div>  
       </div>     
       
        

        <asp:GridView ID="grvDetalle" AutoGenerateColumns="False" AllowPaging="True" 
            DataKeyNames="CodBoleto" runat="server" 
            OnRowCommand="grvDetalle_RowCommand" 
            GridLines="None"
            CssClass="table"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt">  
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns>
        <asp:TemplateField HeaderText="Acción" Visible="False">
            <ItemTemplate>
                <asp:ImageButton ID="ibtnConfirmar" runat="server" CausesValidation="false" CommandName="cmdConfirmar" 
                    onClientClick="return confirm('¿Está seguro de verificar el Equipaje?')"
                    ImageUrl="~/img/ok.jpg" ToolTip="Confirmar Equipaje" 
                    CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
                    &nbsp;
               <asp:ImageButton ID="ibtnCancelar" runat="server" CausesValidation="false" CommandName="cmdCancelar"
                    onClientClick="return confirm('Está seguro de Cancelar su Equipaje?')"
                    ImageUrl="~/img/cancela.jpg" ToolTip="Cancelar Equipaje" 
                    CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
                    &nbsp;
               <asp:ImageButton ID="ibtnEditar" runat="server" CausesValidation="false" CommandName="cmdEditar"
                    onClientClick="return confirm('Está seguro de Modificar información de su Equipaje?')"
                    ImageUrl="~/img/edit.png" ToolTip="Modificar Equipaje" 
                    CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
                <asp:ImageButton ID="ibtnImprimir" runat="server" CausesValidation="false" CommandName="cmdImprimir"
                    ImageUrl="~/img/print.jpg" ToolTip="Imprimir Equipaje" 
                    CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="140px" />
        </asp:TemplateField>
        <asp:BoundField HeaderText="Nro de Boleto" DataField="NroBoleto">
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Estado" DataField="EstadoEquipaje">
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:BoundField>
         <asp:BoundField HeaderText="Apellidos y Nombres del Pasajero" DataField="Pasajero">
            <ItemStyle HorizontalAlign="Left"  Width="175px" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Peso" DataField="Peso">
        <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Origen" DataField="Origen">
            <ItemStyle HorizontalAlign="Left"  Width="90px" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Destino" DataField="Destino">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Fecha Salida" DataField="FechaSalida">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Hora Salida" DataField="HoraSalida">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Tipo de Equipaje" DataField="TipoEquipaje">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Ubicación" DataField="Ubicacion">
            <ItemStyle HorizontalAlign="Left" Width="100px"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Fecha Actual" DataField="FechaActual">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Hora Actual" DataField="HoraActual">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>

            
        </Columns>      
            <EmptyDataTemplate>
                No se encontraron registros.
            </EmptyDataTemplate>            

            

             
<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>  
        
        <input id="btnRegistrarEquipaje" type="Button" value="          Registrar Equipaje          " onclick="mostrar()" style="font-family: Arial, Helvetica, sans-serif; font-size: large; background-color: #339933; color: #FFFFFF" />
        <input id="btnModificarEquipaje" type="Button" value="          Modificar Equipaje          " onclick="mostrar()" style="font-family: Arial, Helvetica, sans-serif; font-size: large; background-color: #339933; color: #FFFFFF" />
        <input id="btnGenerarTickets" type="Button" value="          Generar Ticket     "  style="font-family: Arial, Helvetica, sans-serif; font-size: large; background-color: #339933; color: #FFFFFF" height="44px" />&nbsp;

        <asp:Button ID="btnImprimir" runat="server" CssClass="btn btn-primary" Text="Recomendaciones para Equipajes" OnClientClick = "return PrintPanel();" BackColor="#339933" Font-Bold="True" ForeColor="White" Height="48px" />
        
        
           <div id='oculto' class="panel panel-default" style='display:none;'  >
        <div class="panel-heading">Registrar Equipaje del Pasajero</div>
            <br />
                    <div class="form-inline">
                    <div class="form-group">
                        &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Nro Boleto:"></asp:Label>   &nbsp;&nbsp;
                        <asp:TextBox ID="txtNroBoleto1" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                        <br />
                        <br />
                        &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Peso" MaxLength="8"></asp:Label>  &nbsp;&nbsp;
                        <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
                       
                        &nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Tipo Equipaje" MaxLength="8"></asp:Label>  &nbsp;&nbsp;
                        <asp:DropDownList ID="txtTipoEquipaje" runat="server" CssClass="form-control">
                            <asp:ListItem Value="FRAGIL"></asp:ListItem>
                            <asp:ListItem Value="NORMAL"></asp:ListItem>
                        </asp:DropDownList>
                       
                        
                        &nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="Ubicacion"></asp:Label>   &nbsp;&nbsp;
                        <asp:DropDownList ID="txtUbicacion" runat="server">
                            <asp:ListItem Value="BODEGA"></asp:ListItem>
                        </asp:DropDownList>
                        
                                                   
                
                            <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnConfirmarRegistroEquipaje" runat="server" Text="Confirmar Registro de Equipaje" CssClass="btn btn-success" OnClick="Button4_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnActualizarRegistroEquipaje" runat="server" Text="Actualizar Registro de Equipaje" CssClass="btn btn-success" OnClick="btnActualizarRegistroEquipaje_Click"  /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancelarRegistroEquipaje" runat="server" Text="Cancelar Registro de Equipaje" CssClass="btn btn-success" OnClick="Button6_Click"  /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 --%>   <br />
                <br /> 
                    </div>
                </div>

        </div>






            
        <asp:Panel ID="pnlContents" runat="server">
         <div id="impresion">        
        <h3>Información de Equipaje</h3>
        <hr />
        <span style="font-size: 10pt; font-family:Arial Narrow">Estimado(a) Pasajero(a) <asp:Label
            ID="lblPasajero" runat="server" ></asp:Label>
            <br /><br />
            <span style="color: #18B5F0">Formalidad de viaje </span><br />
Necesitará un pasaporte válido para al menos los 6 meses próximos. Deberá rellenar un formulario de aduana en la entrada y salida del país. Los visados no son necesarios para los ciudadanos europeos. La estancia no puede superar 3 meses. Para los coches, la tarjeta verde es válida en Marruecos. Si su seguro no cubre el país, deberá contratar un seguro con cobertura adicional. No hace falta ninguna vacuna especial para los viajeros procedentes de Europa.
<br />
Cambio de horario
Marruecos está a hora GMT. No hay cambio de hora en verano.
<br /><br />
<span style="color: #18B5F0">Modo de pago y propinas </span><br />
El dirham es una moneda no convertible fuera del país. Puede consultar el equivalente de la moneda en: www.lecenomiste.com. Los cajeros automáticos con pegatinas VISA o MAESTRO aceptan sus tarjetas bancarias. Se encuentran en todas las grandes ciudades. Los bancos y grandes hoteles tienen oficina de cambio. En Tánger, es posible cambiar los euros en las tiendas de comestibles, estancos y otras tiendas. La mayoría de las tarjetas bancarias se aceptan en los hoteles, restaurantes y tiendas de lujo. Las propinas son una norma general en Marruecos. Están consideradas como un extra sobre el salario.
<br /><br />
<span style="color: #18B5F0">Telecomunicación y electricidad </span><br />
Los móviles funcionan en Marruecos. Consulte con su operador si su contrato cubre los países del maghreb. Para el acceso a Internet, no dude en entrar en un cybercafe. Hay muchos en Marruecos, la mayoría están equipados con ADSL y cuesta alrededor de 10dhs (+- 1) por 1 hora. La corriente eléctrica es de 220 voltios, y los enchufes son de tipo europeos.
<br /><br />
<span style="color: #18B5F0">Estar en Marruecos </span><br />
Tierra de acogimiento y de tolerancia, Marruecos no deja de ser un país apegado a sus tradiciones. Puede esperar una comunicación fácil y agradable con los marroquíes. Aún así, actitud y ropa respetuosa son elementales en tierra islámica.</span>
        </div>
        </asp:Panel>
       
             
    </div>

   
</asp:Content>

 <%-- Detalle de Boleto - Pasajero --%>

        

     