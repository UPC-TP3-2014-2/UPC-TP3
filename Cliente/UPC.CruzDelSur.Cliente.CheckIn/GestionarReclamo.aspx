<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionarReclamo.aspx.cs" Inherits="Reclamo_GestionarReclamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <form id="form1" runat="server">
    <div>
    
        GESTIONAR RECLAMO<br />
        <fieldset>
        <legend style="font-size:14px">Búsqueda:</legend>
            <asp:Label ID="Label1" runat="server" Text="Nro Boleto:"></asp:Label>
            <asp:TextBox ID="txtNroBoleto" runat="server" MaxLength="10"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="DNI" MaxLength="8"></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="mybtnstyle" 
                onclick="btnBuscar_Click" />
                <br /><br />
       </fieldset><br />
        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" style="text-align: left">
            <Columns>
                <asp:BoundField DataField="NroBoleto" HeaderText="Nro Boleto" />
                <asp:BoundField DataField="Pasajero" HeaderText="Pasajero" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="FechaActual" HeaderText="Fecha" />
                <asp:BoundField DataField="HoraActual" HeaderText="Hora" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
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
        
    </form>
</body>
</html>
