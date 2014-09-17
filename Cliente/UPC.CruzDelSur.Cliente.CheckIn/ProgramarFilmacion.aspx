<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProgramarFilmacion.aspx.cs" Inherits="ProgramarFilmacion" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtIniGrab.ClientID %>").dynDateTime({
               showsTime: true,
               ifFormat: "%d/%m/%Y %H:%M:%S",
               daFormat: "%l;%M %p, %e %m, %Y",
               align: "BR",
               electric: false,
               singleClick: false,
               displayArea: ".siblings('.dtcDisplayArea')",
               button: ".next()"
           });
       });
       
        $(document).ready(function () {
            $("#<%=txtFinGrab.ClientID %>").dynDateTime({
                  showsTime: true,
                  ifFormat: "%d/%m/%Y %H:%M:%S",
                  daFormat: "%l;%M %p, %e %m, %Y",
                  align: "BR",
                  electric: false,
                  singleClick: false,
                  displayArea: ".siblings('.dtcDisplayArea')",
                  button: ".next()"
              });
          });



</script>



    <div>
      <h2>Programar Filmacion</h2>  
      <br />


        <div class="panel panel-default">

  <div class="panel-heading">Información de filmacion</div>

          
            <br />

         <table width="50%">
         <tr>
         <td style="width:15%">Codigo Salida Bus: </td>
         <td style="width:25%"><asp:Label ID="lblCodBus" runat="server" ></asp:Label></td>
         </tr>
         <tr>
         <td>Inicio Grabacion: </td>
         <td>
               <asp:TextBox ID="txtIniGrab" runat="server" ReadOnly="true" Width="150px" CssClass="form-control"></asp:TextBox>
                      <img src="/img/calendar.jpg" />

         </td>
         </tr>
         <tr>
         <td>Fin Grabacion: </td>
         <td>
             <asp:TextBox ID="txtFinGrab" runat="server" ReadOnly="true" Width="150px" CssClass="form-control"></asp:TextBox>
                      <img src="/img/calendar.jpg" />

         </td>
         </tr>
         <tr>
         <td>Ruta: </td>
         <td><asp:Label ID="lblRuta" runat="server"></asp:Label></td>
         </tr>
         
              <tr>
         <td> </td>
         <td>
             
            
          </td>
         </tr>


         <tr>
         <td>
              <asp:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="Button1_Click" CssClass="btn btn-success" />
             <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn btn-success" />
         </td>
         <td>
             
            
              <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" CssClass="btn btn-primary" />

             
             
            
          </td>
         </tr>


         <tr>
         <td>
              &nbsp;</td>
         <td>
             
            
              &nbsp;</td>
         </tr>


         <tr>
         <td>
              <asp:Label ID="lblMensaje" runat="server"></asp:Label>
         </td>
         <td>
             
            
              &nbsp;</td>
         </tr>
         </table>
     <br />
          <br />

          </div>
             </div>  
</asp:Content>

