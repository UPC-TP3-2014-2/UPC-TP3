<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GestionarAsiento.aspx.cs" Inherits="GestionarAsiento" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <style type="text/css">

        .grilla_oculta{
            display:none;
        }

        .auto-style1 {
            width: 22px;
            height: 22px;
            text-align: center;
        }

        .auto-style2 {
            width: 135px;
        }
        .auto-style3 {
            text-align: center;
            width: 105px;
        }

    </style>

    <script type="text/javascript">

        $(document).ready(function () {

            seleccionarAsientos();

        });

        function seleccionarAsientos() {

            $("#<%=grvAsientos.ClientID %> tr").each(function () {
                var item = $(this);

                var id = item.find("td:eq(4)").text();

                seleccionarUnAsiento(id);
            });
        }

        function seleccionarUnAsiento(id) {
            var prefijo = "p1a";
            var asientoID = prefijo + id;

            $('#' + asientoID).removeClass("ocupado");
            $('#' + asientoID).addClass("asiento");
        }

        function AsignarAsientoNuevo(numAsiento) {
            
            var strBoleto = $('#<%=hidNumBoleto.ClientID%>').val();
            var strAsientoL = $('#<%=hidAsientoL.ClientID%>').val();

            var strUrl = "GestionarAsiento.aspx/AsignarAsiento";
            var strData = "{asientoNuevo : '" + numAsiento + "', boleto: '" + strBoleto + "', asientoL: '" + strAsientoL + " '}";
            
            $.ajax({
                type: "POST",
                url: strUrl,
                data: strData,
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                error: function (data) {
                    alert('Error en el Servidor' + data.responseText);
                },
                success: function (data) {
                    if (data.d != null) {
                        alert('Se realizo el cambio de asiento de ' + strAsientoL + ' al asiento ' + numAsiento);

                        window.location.assign("<%=ResolveClientUrl("~/GestionarAsiento.aspx")%>" + "?" + data.d) ;
                    }
                }
            });

        }

</script>


 <div id="contenedor">
    <h2>GESTIONAR ASIENTO</h2>
    
     <br />
     <table  width="170px">
         <tr>
             <td >Asientos Disponibles:</td>
             <td class="text-center">
         <img alt="Asiento disponible" class="auto-style1" src="Images/asiento.gif" /></td>
         </tr>
         <tr>
             <td class="auto-style2">Asientos Ocupados:</td>
             <td class="auto-style3">
         <img alt="Asiento ocupado" class="auto-style1" src="Images/asiento_ocupado.gif" /></td>
         </tr>
     </table>
     <br />
    <br />
        <asp:GridView ID="grvAsientos" runat="server" AutoGenerateColumns="False" AllowPaging="true" 
            DataKeyNames="Asiento" 
            OnRowCommand="grvAsientos_RowCommand" 
            GridLines="None"
            CssClass="table grilla_oculta"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt"> 
            <Columns>
        <asp:TemplateField HeaderText="Acción">
            <ItemTemplate>
                <asp:ImageButton ID="ibtnCambiar" runat="server" CausesValidation="false" CommandName="cmdCambiarAsiento" 
                    onClientClick="return confirm('Está seguro de confirmar su asiento?')"
                    ImageUrl="~/img/ok.jpg" ToolTip="Check In" 
                    CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:TemplateField>
        <asp:BoundField HeaderText="Cod.Vehiculo" DataField="CodVehiculo" Visible="False">
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Placa" DataField="Placa">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Fecha Salida" DataField="FechaSalida">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Hora Salida" DataField="HoraSalida">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Asiento" DataField="Asiento">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        <asp:BoundField HeaderText="Est.Asiento" DataField="EstadoAsiento">
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        </Columns>      
            <EmptyDataTemplate>
                No se encontraron registros.
            </EmptyDataTemplate>    
        </asp:GridView>
        <br />

    </div>


<table>
<tr>
<td>
<div id="bus">
<div id="frente"> </div>
<div id="primerpiso">
<div id="cabecerapiso">Primer piso</div>
<div id="cuerpoprimerpiso">
<div id="escalera1"> </div>
<div id="servicio1"> </div>
<div class="ocupado" id="p1a02" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 88px;"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('02');">02</a></div>
<div class="ocupado" id="p1a03" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 88px;"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('03');">03</a></div>
<div class="ocupado" id="p1a01" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 88px;"><a class="asientoenlace" href="#"  onclick="AsignarAsientoNuevo('01');">01</a> </div>
<div class="ocupado" id="p1a05" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 116px;"><a class="asientoenlace" href="#"  onclick="AsignarAsientoNuevo('05');">05</a></div>
<div class="ocupado" id="p1a06" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 116px;"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('06');">06</a></div>
<div style="position: absolute; width: 22px; height: 22px; left: 122px; top: 116px;" class="ocupado" id="p1a04"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('04');">04</a> </div>
<div class="ocupado" id="p1a08" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 143px;"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('08');">08</a></div>
<div class="ocupado" id="p1a09" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 143px;"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('09');">09</a></div>
<div class="ocupado" id="p1a07" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 143px;"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('07');">07</a> </div>
<div class="ocupado" id="p1a11" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 170px;"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('11');">11</a></div>
<div class="ocupado" id="p1a12" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 170px;"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('12');">12</a></div>
<div class="ocupado" id="p1a10" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 170px;"><a class="asientoenlace" href="#" onclick="AsignarAsientoNuevo('10');">10</a> </div>
</div>
</div>
<div id="segundopiso">
<div id="cabecerapiso">Segundo piso</div>
<div id="cuerposegundopiso">
<div class="ocupado" id="p2a01" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 10px;"><a class="asientoenlace" href="#">01</a></div>
<div class="ocupado" id="p2a02" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 10px;"><a class="asientoenlace" href="#">02</a></div>
<div class="ocupado" id="p2a03" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 10px;"><a class="asientoenlace" href="#">03</a> </div>
<div class="ocupado" id="p2a04" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 10px;"><a class="asientoenlace" href="#">04</a> </div>
<div class="ocupado" id="p2a05" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 37px;"><a class="asientoenlace" href="#">05</a></div>
<div class="ocupado" id="p2a06" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 37px;"><a class="asientoenlace" href="#">06</a></div>
<div class="ocupado" id="p2a07" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 37px;"><a class="asientoenlace" href="#">07</a> </div>
<div class="ocupado" id="p2a08" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 37px;"><a class="asientoenlace" href="#">08</a> </div>
<div id="escalera2"> </div>
<div class="ocupado" id="p2a09" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 64px;"><a class="asientoenlace" href="#">09</a></div>
<div class="ocupado" id="p2a10" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 64px;"><a class="asientoenlace" href="#">10</a></div>
<div class="ocupado" id="p2a13" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 91px;"><a class="asientoenlace" href="#">13</a></div>
<div class="ocupado" id="p2a14" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 91px;"><a class="asientoenlace" href="#">14</a></div>
<div class="ocupado" id="p2a21" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 145px;"><a class="asientoenlace" href="#">21</a></div>
<div class="ocupado" id="p2a22" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 145px;"><a class="asientoenlace" href="#">22</a></div>
<div class="ocupado" id="p2a15" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 145px;"><a class="asientoenlace" href="#">15</a> </div>
<div class="ocupado" id="p2a16" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 145px;"><a class="asientoenlace" href="#">16</a> </div>
<div class="ocupado" id="p2a25" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 172px;"><a class="asientoenlace" href="#">25</a></div>
<div class="ocupado" id="p2a26" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 172px;"><a class="asientoenlace" href="#">26</a></div>
<div class="ocupado" id="p2a19" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 172px;"><a class="asientoenlace" href="#">19</a> </div>
<div class="ocupado" id="p2a20" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 172px;"><a class="asientoenlace" href="#">20</a> </div>
<div class="ocupado" id="p2a37" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 253px;"><a class="asientoenlace" href="#">37</a></div>
<div class="ocupado" id="p2a38" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 253px;"><a class="asientoenlace" href="#">38</a></div>
<div class="ocupado" id="p2a31" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 253px;"><a class="asientoenlace" href="#">31</a> </div>
<div class="ocupado" id="p2a32" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 253px;"><a class="asientoenlace" href="#">32</a> </div>
<div class="ocupado" id="p2a39" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 280px;"><a class="asientoenlace" href="#">39</a></div>
<div class="ocupado" id="p2a40" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 280px;"><a class="asientoenlace" href="#">40</a></div>
<div class="ocupado" id="p2a35" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 280px;"><a class="asientoenlace" href="#">35</a> </div>
<div class="ocupado" id="p2a36" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 280px;"><a class="asientoenlace" href="#">36</a> </div>
<div class="ocupado" id="p2a17" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 119px;"><a class="asientoenlace" href="#">17</a></div>
<div class="ocupado" id="p2a18" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 118px;"><a class="asientoenlace" href="#">18</a></div>
<div class="ocupado" id="p2a11" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 118px;"><a class="asientoenlace" href="#">11</a> </div>
<div class="ocupado" id="p2a12" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 118px;"><a class="asientoenlace" href="#">12</a> </div>
<div class="ocupado" id="p2a29" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 199px;"><a class="asientoenlace" href="#">29</a></div>
<div class="ocupado" id="p2a30" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 199px;"><a class="asientoenlace" href="#">30</a></div>
<div class="ocupado" id="p2a23" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 199px;"><a class="asientoenlace" href="#">23</a> </div>
<div class="ocupado" id="p2a24" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 199px;"><a class="asientoenlace" href="#">24</a> </div>
<div class="ocupado" id="p2a33" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 226px;"><a class="asientoenlace" href="#">33</a></div>
<div class="ocupado" id="p2a34" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 226px;"><a class="asientoenlace" href="#">34</a></div>
<div class="ocupado" id="p2a27" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 226px;"><a class="asientoenlace" href="#">27</a> </div>
<div class="ocupado" id="p2a28" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 226px;"><a class="asientoenlace" href="#">28</a> </div>
</div>
</div>
<div id="atras"> </div>
</div>
</td>
</tr>
    <tr>
        <td>
            <input type="hidden" id="hidNumBoleto" runat="server"/>
            <input type="hidden" id="hidAsientoL" runat="server"/>
        </td>
    </tr>
</table>
            <asp:Button ID="btnRetornar" runat="server" Text="Regresar" 
            onclick="btnRetornar_Click" CssClass="btn btn-primary" />

    
    </asp:Content>