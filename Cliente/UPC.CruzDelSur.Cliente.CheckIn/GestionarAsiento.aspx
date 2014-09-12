<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GestionarAsiento.aspx.cs" Inherits="GestionarAsiento" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="contenedor">
    <h2>GESTIONAR ASIENTO</h2>
    <h3>Asientos Disponibles</h3>
    <br />
        <asp:GridView ID="grvAsientos" runat="server" AutoGenerateColumns="False" AllowPaging="true" 
            DataKeyNames="Asiento" 
            OnRowCommand="grvAsientos_RowCommand" 
            GridLines="None"
            CssClass="mGrid"
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
        <asp:Button ID="btnRetornar" runat="server" Text="Regresar" 
            onclick="btnRetornar_Click" />

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
      <div class="asiento" id="p1a02" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 88px;"><a class="asientoenlace" href="#">02</a></div>
      <div class="asiento" id="p1a03" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 88px;"><a class="asientoenlace" href="#">03</a></div>
      <div class="asiento" id="p1a01" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 88px;"><a class="asientoenlace" href="#">01</a> </div>
      <div class="asiento" id="p1a05" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 116px;"><a class="asientoenlace" href="#">05</a></div>
      <div class="asiento" id="p1a06" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 116px;"><a class="asientoenlace" href="#">06</a></div>
      <div style="position: absolute; width: 22px; height: 22px; left: 122px; top: 116px;" class="asiento" id="p1a04"><a class="asientoenlace" href="#">04</a> </div>
      <div class="asiento" id="p1a08" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 143px;"><a class="asientoenlace" href="#">08</a></div>
      <div class="asiento" id="p1a09" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 143px;"><a class="asientoenlace" href="#">09</a></div>
      <div class="asiento" id="p1a07" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 143px;"><a class="asientoenlace" href="#">07</a> </div>
      <div class="asiento" id="p1a11" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 170px;"><a class="asientoenlace" href="#">11</a></div>
      <div class="asiento" id="p1a12" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 170px;"><a class="asientoenlace" href="#">12</a></div>
      <div class="asiento" id="p1a10" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 170px;"><a class="asientoenlace" href="#">10</a> </div>
    </div>
  </div>
  <div id="segundopiso">
    <div id="cabecerapiso">Segundo piso</div>
    <div id="cuerposegundopiso">
      <div class="asiento" id="p2a01" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 10px;"><a class="asientoenlace" href="#">01</a></div>
      <div class="asiento" id="p2a02" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 10px;"><a class="asientoenlace" href="#">02</a></div>
      <div class="asiento" id="p2a03" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 10px;"><a class="asientoenlace" href="#">03</a> </div>
      <div class="asiento" id="p2a04" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 10px;"><a class="asientoenlace" href="#">04</a> </div>
      <div class="asiento" id="p2a05" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 37px;"><a class="asientoenlace" href="#">05</a></div>
      <div class="asiento" id="p2a06" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 37px;"><a class="asientoenlace" href="#">06</a></div>
      <div class="asiento" id="p2a07" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 37px;"><a class="asientoenlace" href="#">07</a> </div>
      <div class="asiento" id="p2a08" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 37px;"><a class="asientoenlace" href="#">08</a> </div>
      <div id="escalera2"> </div>
      <div class="asiento" id="p2a09" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 64px;"><a class="asientoenlace" href="#">09</a></div>
      <div class="asiento" id="p2a10" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 64px;"><a class="asientoenlace" href="#">10</a></div>
      <div class="asiento" id="p2a13" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 91px;"><a class="asientoenlace" href="#">13</a></div>
      <div class="asiento" id="p2a14" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 91px;"><a class="asientoenlace" href="#">14</a></div>
      <div class="asiento" id="p2a21" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 145px;"><a class="asientoenlace" href="#">21</a></div>
      <div class="asiento" id="p2a22" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 145px;"><a class="asientoenlace" href="#">22</a></div>
      <div class="asiento" id="p2a15" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 145px;"><a class="asientoenlace" href="#">15</a> </div>
      <div class="asiento" id="p2a16" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 145px;"><a class="asientoenlace" href="#">16</a> </div>
      <div class="asiento" id="p2a25" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 172px;"><a class="asientoenlace" href="#">25</a></div>
      <div class="asiento" id="p2a26" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 172px;"><a class="asientoenlace" href="#">26</a></div>
      <div class="asiento" id="p2a19" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 172px;"><a class="asientoenlace" href="#">19</a> </div>
      <div class="asiento" id="p2a20" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 172px;"><a class="asientoenlace" href="#">20</a> </div>
      <div class="asiento" id="p2a37" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 253px;"><a class="asientoenlace" href="#">37</a></div>
      <div class="asiento" id="p2a38" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 253px;"><a class="asientoenlace" href="#">38</a></div>
      <div class="asiento" id="p2a31" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 253px;"><a class="asientoenlace" href="#">31</a> </div>
      <div class="asiento" id="p2a32" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 253px;"><a class="asientoenlace" href="#">32</a> </div>
      <div class="asiento" id="p2a39" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 280px;"><a class="asientoenlace" href="#">39</a></div>
      <div class="asiento" id="p2a40" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 280px;"><a class="asientoenlace" href="#">40</a></div>
      <div class="asiento" id="p2a35" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 280px;"><a class="asientoenlace" href="#">35</a> </div>
      <div class="asiento" id="p2a36" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 280px;"><a class="asientoenlace" href="#">36</a> </div>
      <div class="asiento" id="p2a17" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 119px;"><a class="asientoenlace" href="#">17</a></div>
      <div class="asiento" id="p2a18" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 118px;"><a class="asientoenlace" href="#">18</a></div>
      <div class="asiento" id="p2a11" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 118px;"><a class="asientoenlace" href="#">11</a> </div>
      <div class="asiento" id="p2a12" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 118px;"><a class="asientoenlace" href="#">12</a> </div>
      <div class="asiento" id="p2a29" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 199px;"><a class="asientoenlace" href="#">29</a></div>
      <div class="asiento" id="p2a30" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 199px;"><a class="asientoenlace" href="#">30</a></div>
      <div class="asiento" id="p2a23" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 199px;"><a class="asientoenlace" href="#">23</a> </div>
      <div class="asiento" id="p2a24" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 199px;"><a class="asientoenlace" href="#">24</a> </div>
      <div class="asiento" id="p2a33" style="position: absolute; width: 22px; height: 22px; left: 6px; top: 226px;"><a class="asientoenlace" href="#">33</a></div>
      <div class="asiento" id="p2a34" style="position: absolute; width: 22px; height: 22px; left: 40px; top: 226px;"><a class="asientoenlace" href="#">34</a></div>
      <div class="asiento" id="p2a27" style="position: absolute; width: 22px; height: 22px; left: 90px; top: 226px;"><a class="asientoenlace" href="#">27</a> </div>
      <div class="asiento" id="p2a28" style="position: absolute; width: 22px; height: 22px; left: 122px; top: 226px;"><a class="asientoenlace" href="#">28</a> </div>
    </div>
  </div>
  <div id="atras"> </div>
</div>
</td>
</tr>
</table>

</asp:Content>
