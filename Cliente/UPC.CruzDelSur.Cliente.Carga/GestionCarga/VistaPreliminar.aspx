<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaPreliminar.aspx.cs" Inherits="UPC.CruzDelSur.Cliente.Carga.GestionCarga.VistaPreliminar" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="600px">
    <LocalReport ReportPath="GestionCarga\Report1.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="dsReporte" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.;Initial Catalog=CSUR;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SP_GENERARREPORTEDETALLE" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="3" Name="INT_CODIGO_ALMACEN" QueryStringField="almacen" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="3" Name="INT_TIPO_MOVIMIENTO" QueryStringField="tipoMovimiento" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="15/09/2015" Name="DTM_FECHAHORAINICIO" Type="DateTime" QueryStringField="fechaincio"/>
            <asp:QueryStringParameter DefaultValue="15/09/2015" Name="DTM_FECHAHORAFIN" QueryStringField="fechafin" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
