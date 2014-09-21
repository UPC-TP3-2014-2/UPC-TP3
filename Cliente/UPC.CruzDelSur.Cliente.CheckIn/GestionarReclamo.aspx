<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.master"  CodeFile="GestionarReclamo.aspx.cs" Inherits="Reclamo_GestionarReclamo" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <!DOCTYPE html>

<html>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
* {
    padding: 0; 
    margin: 0; 
}

.mybtnstyle{
border:1px solid #CCCCCC;-webkit-box-shadow: #FEFFFF 0px 1px 1px;-moz-box-shadow: #FEFFFF 0px 1px 1px; box-shadow: #FEFFFF 0px 1px 1px; -webkit-border-radius: 3px; -moz-border-radius: 3px;border-radius: 3px;font-size:14px;font-family:arial, helvetica, sans-serif; padding: 10px 10px 10px 10px; text-decoration:none; display:inline-block;text-shadow: 0px 1px 0 rgba(255,255,255,1);font-weight:bold; color: #4A4A4A;
 background-color: #f2f5f6; background-image: linear-gradient(to bottom, #f2f5f6, #c8d7dc);
 }

        .auto-style1 {
            width: 181px;
        }
        #Select1 {
            width: 128px;
        }
        #Select2 {
            width: 127px;
        }
        .auto-style2 {
            width: 532px;
            text-align: left;
        }

    </style>
</head>
<body>
 
    <div>
    
        <h2> Gestionar Reclamo</h2>
          <br />
        <div class="panel panel-default">

  <div class="panel-heading">Criterios de búsqueda</div>

          
            <br />

          
  <div class="form-inline">
      <div class="form-group">
       &nbsp;       &nbsp;
            <asp:Label ID="Label1" runat="server" Text="Nro Boleto:"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtNroBoleto" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
           &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="DNI" MaxLength="8"></asp:Label>
           &nbsp;&nbsp;
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success" 
                onclick="btnBuscar_Click" />
               <br />
          <br />

          </div>
             </div>  
       </div>     
        <asp:GridView ID="gv1"
             runat="server" 
            AutoGenerateColumns="False"  
             CellPadding="4" 
                CssClass="table"
                 AllowPaging="true" 
 GridLines="None"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt"
          
            >
            <Columns>
                <asp:BoundField DataField="NroBoleto" HeaderText="Nro Boleto" />
                <asp:BoundField DataField="Pasajero" HeaderText="Pasajero" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="FechaActual" HeaderText="Fecha" />
                <asp:BoundField DataField="HoraActual" HeaderText="Hora" />
            </Columns>
         
        </asp:GridView>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Tipo de Solicitud:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="dlTipoSolicitud" runat="server" Height="18px" Width="152px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Area:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="dlArea" runat="server" Height="16px" Width="151px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Motivo:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtMotivo" runat="server" Height="93px" Width="476px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnRegistrar" runat="server" style="text-align: left" Text="Registrar" Width="112px" OnClick="btnRegistrar_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        </div>
        

</body>
</html>
    </asp:Content>