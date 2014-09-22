<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RegistrarInfraccion.aspx.cs" Inherits="RegistrarInfraccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 36px;
        }
        .auto-style2 {
            width: 25%;
            height: 36px;
        }
        .auto-style3 {
            height: 13px;
        }
        .auto-style4 {
            width: 15%;
        }
        .auto-style5 {
            height: 13px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div>
      <h2>Registrar infracción </h2>  
      <br />


        <div class="panel panel-default">

  <div class="panel-heading">Información de infracción</div>

          
            <br />

             <div  id="mypane1" runat="server" class="alert alert-success" role="alert"> <asp:Label ID="lblMensaje" runat="server"></asp:Label></div>
             <br />

             <div id="mypane2" runat="server" class="alert alert-danger" role="alert">Se procedió a la anulación del Nro. boleto <asp:Label ID="lblMensaje0" runat="server"></asp:Label> </div>

            <br />

         <table width="50%">
         
         <tr>
         <td class="auto-style1">
             <asp:Label ID="Label1" runat="server" Text="Nro Boleto:"></asp:Label>
             </td>
         <td class="auto-style2"><asp:Label ID="lblCodBoleto" runat="server" ></asp:Label></td>
         </tr>
         <tr>
         <td class="auto-style4">Detalle de infracción: </td>
         <td>
               <asp:TextBox ID="txtDetalleInfraccion" runat="server" Width="285px" CssClass="form-control" Height="247px" TextMode="MultiLine"></asp:TextBox>
                      &nbsp;</td>
         </tr>
         
              <tr>
         <td class="auto-style4"> </td>
         <td>
             
            
          </td>
         </tr>


         <tr>
         <td class="auto-style4">
              <asp:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="Button1_Click" CssClass="btn btn-success" />
         </td>
         <td>
             
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-primary" />
              <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" CssClass="btn btn-primary" />

             
             
            
          </td>
         </tr>


         <tr>
         <td class="auto-style5">
              </td>
         <td class="auto-style3">
             
            
              </td>
         </tr>


         <tr>
         <td class="auto-style5" colspan="2">
             
         </td>
         </tr>
         </table>
     <br />
          <br />

          </div>
             </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>

