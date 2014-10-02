<%@ Page Title="" Language="C#" MasterPageFile="~/SitePopup.Master" AutoEventWireup="true" CodeBehind="Validar.aspx.cs" Inherits="CRUZDELSUR.UI.Web.GestionCarga.Validar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlSecreto" runat="server">

        <div>
            Pregunta secreta
        </div>
        <div>
            <asp:TextBox ID="txtPregunta" runat="server" Width="500px"></asp:TextBox>
        </div>
        <div>
            Respuesta secreta
        </div>
        <div>
            <asp:TextBox ID="txtRespuesta" runat="server" Width="500px"></asp:TextBox>
        </div>

    </asp:Panel>




    <div>
        Ingrese Clave
    </div>
    <div>
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
    </div>


    <div>
        Repetir Clave
    </div>
    <div>
        <asp:TextBox ID="txtrepetirclave" runat="server" TextMode="Password"></asp:TextBox>
    </div>
     <asp:CompareValidator ID="CompareValidator" ForeColor="Red" ValidationGroup="Clavetest"  runat="server" ControlToValidate="txtClave" ControlToCompare="txtrepetirclave" ErrorMessage="La clave no es igual">  
                </asp:CompareValidator>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Aceptar" ValidationGroup="Clavetest"
        OnClick="Button1_Click" />

    <asp:Button ID="Button2" runat="server" Text="Cancelar" OnClientClick="javascript:window.close();" />
    <asp:HiddenField ID="hfRespuesta" runat="server" />
</asp:Content>
