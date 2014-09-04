<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <title>.:| Empresa de Transportes Cruz del Sur</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>    <br /><br /><br />
    <h2>Opciones</h2>
        <asp:Button ID="btnGestionarChekin" CssClass="mybtnstyle" runat="server" Text=" Ir a Gestionar Check In " 
            onclick="btnGestionarChekin_Click" /><br />
        <asp:Button ID="btnGestionarEquipaje" CssClass="mybtnstyle" runat="server" Text=" Ir a Gestionar Equipaje " 
            onclick="btnGestionarEquipaje_Click" />
    </center>    
    </div>
    </form>
</body>
</html>
