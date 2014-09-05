<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarBitacoraViaje.aspx.cs" Inherits="CRUZDELSUR.UI.Web.Flota.AdministrarBitacoraViaje" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


        
        

                    <table style="width:100%; ">
                    <tr>
     
                    <td>Fecha Inicio</td>
                    <td>
                        <div style="z-index:10;position:relative;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" >    
                            <ContentTemplate>
                                <asp:TextBox ID="txtFechaInicio" runat="server" Text="" CssClass="TextBox_Fecha"
                                    Width="150px" MaxLength="10"></asp:TextBox>
                                  
                                <cc1:CalendarExtender runat="server" ID="CalendTxtFechaInicio_CalendarExtender" TargetControlID="txtFechaInicio"
                                    Format="d">
                                </cc1:CalendarExtender>
                            </ContentTemplate>          
                            </asp:UpdatePanel>
                        </div>

                    </td>
                    <td>Fecha Final</td>
                    <td>
                        <div style="z-index:10;position:relative;">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" >    
                            <ContentTemplate>
                                <asp:TextBox ID="txtFechaFin" runat="server" Text="" CssClass="TextBox_Fecha"
                                    Width="150px" MaxLength="10"></asp:TextBox>
                                  
                                <cc1:CalendarExtender runat="server" ID="CalendTxtFechaFin_CalendarExtender" TargetControlID="txtFechaFin"
                                    Format="d">
                                </cc1:CalendarExtender>
                            </ContentTemplate>          
                            </asp:UpdatePanel>
                        </div>
          
                    </td>
                    
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="80px" onclick="btnBuscar_Click" />
                    </td>

                    <td>
                         <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Width="80px" onclick="btnNuevo_Click" />
                    </td>

                    <td>  
                         <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="80px" onclick="btnModificar_Click" />                         
                    </td>

                    <td>  
                         <asp:Button ID="btnAnular" runat="server" Text="Anular" Width="80px" onclick="btnAnular_Click" />                         
                    </td>


                    </tr>
            </table >

      
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
                                                                        <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="vehiculo" HeaderText="Vehiculo" HeaderStyle-BackColor="#0070C0">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ruta" HeaderText="Ruta" HeaderStyle-BackColor="#0070C0" >
                                                                        <HeaderStyle Width="200px" HorizontalAlign="Center" />
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
                                                        <asp:HyperLink ID="HyperLink1" runat="server" 
                                                            NavigateUrl="~/Flota/RegistroBitacoraViaje.aspx">HyperLink</asp:HyperLink>
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
