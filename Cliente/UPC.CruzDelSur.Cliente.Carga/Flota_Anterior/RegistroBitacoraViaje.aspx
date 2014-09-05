<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroBitacoraViaje.aspx.cs" Inherits="CRUZDELSUR.UI.Web.Flota.RegistroBitacoraViaje" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div>
<table >
    <tr>
    <td style="background-color:#FFE27F; color:#333333;text-align:center;" colspan="6"> 
         MANTENIMIENTO DE INCIDENCIA
    </td>
    </tr>
     <tr>
    <td colspan="6"> 

    </td>
    </tr>
<tr>
    <td>
        Fecha
    </td>

    <td>
        <div style="z-index:10;position:relative;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" >    
            <ContentTemplate>
                <asp:TextBox ID="txtFecha" runat="server" Text="" CssClass="TextBox_Fecha"
                    Width="150px" MaxLength="10"></asp:TextBox>
                                  
                <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtFecha"
                    Format="d">
                </cc1:CalendarExtender>
            </ContentTemplate>          
            </asp:UpdatePanel>
        </div>
    </td>
    <td>
        Hora Partida
    </td>
    <td>
        <asp:TextBox ID="txtHoraPartida" runat="server"></asp:TextBox>
    </td>

    <td>
        Hora LLegada
    </td>
    <td>
        <asp:TextBox ID="txtHoraLLegada" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Vehiculo</td>
    <td colspan="2"><asp:TextBox ID="txtVehiculo" runat="server" Width="250px"></asp:TextBox>
                    
    </td>
    <td><asp:Button ID="btnBuscarRuta" runat="server" Text="Buscar" Width="80px" onclick="btnBuscarRuta_Click" />
     </td>
     <td>Ruta
     </td>
     <td>
         <asp:DropDownList ID="ddlRuta" runat="server" Width="150px">
         </asp:DropDownList>
     </td>
</tr>
<tr>
<td colspan="6">

<asp:Panel ID="pnlIncidencia" GroupingText="Incidencia" runat="server">

    <table style="width:80%;">


    <tr>
        <td>Evento</td>
        <td>
             <asp:DropDownList ID="ddlEvento" runat="server" Width="150px">
             </asp:DropDownList>
         </td>
         <td>
            <asp:Button ID="btnAgregarIncidencia" runat="server" Text="Agregar Incidencia" 
                 Width="121px" onclick="btnAgregarIncidencia_Click" />
         </td>
     </tr>
     <tr>
     
         <td>Descripción</td>
         <td>
         <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="250" Height="50px"></asp:TextBox></td>
     </tr>
     </table>
    
</asp:Panel> 

</td>
</tr>
</table>
 </div>

              <div style="width:100%; text-align:center;">
               <table>
                <tr>
                <td style="width:60%; background-color: #F2F2F2;" valign="top" align="center"  >
                   <table style="width:100%;text-align:center;">
                         <tr>
                             <td valign="top" align="center"  >
                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">    
                                                 <ContentTemplate>
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                                    GridLines="None"
                                                                    PageSize="8"
                                                                    Height="100%" width = "100%" CssClass="tbempleado" 
                                                                    EnableModelValidation="True" EmptyDataText="NO RECORD FOUND" 
                                                                    AllowPaging="True">
                                                                    <Columns>  
                                                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" Visible="true">
                                                                        <HeaderStyle Width="40px" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="vehiculo" HeaderText="Vehiculo" HeaderStyle-BackColor="#0070C0">
                                                                        <HeaderStyle Width="60px" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="evento" HeaderText="Evento" HeaderStyle-BackColor="#0070C0">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ruta" HeaderText="Ruta" HeaderStyle-BackColor="#0070C0" >
                                                                        <HeaderStyle Width="110px" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:BoundField>

                                                                   
                                                                </Columns>
                                                                    <EmptyDataTemplate>
                                                                        Su Búsqueda no produjo ningún resultado.
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle BackColor="#507CD1" ForeColor="White"  height="30px" Font-Size="9"/> 
                                                                    <PagerStyle CssClass="PagerStyle" HorizontalAlign="Center"  /> 
                                                                    <RowStyle CssClass="rowStyle"/>  
                                                                    <AlternatingRowStyle CssClass="alternativeRow" />
                                                                    <EditRowStyle BackColor="#999999" />
                                                                    <FooterStyle BackColor="#C53B1C" Font-Bold="True" ForeColor="White" />  
                                                                    <PagerStyle BackColor="#FFFFFF" CssClass="pagerStyle" HorizontalAlign="Center"/>
                                                                    <SelectedRowStyle BackColor="#FFE27F" Font-Bold="True" ForeColor="#333333" />
                                                                                
                                                                </asp:GridView>
                                                 </ContentTemplate>           
                                                 </asp:UpdatePanel>
                                    </td>      
                                </tr>
                            </table>
                    </td>
                    </tr>
                </table>
        </div>
</asp:Content>
