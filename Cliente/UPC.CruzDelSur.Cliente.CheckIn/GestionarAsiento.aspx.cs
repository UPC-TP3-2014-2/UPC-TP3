using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
public partial class GestionarAsiento : System.Web.UI.Page
{
    public string NroBoleto = "";
    public string NroAsientoL = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //btnImprimir.Visible = true;  
            Int32 IdVehiculo = Convert.ToInt32(Request.QueryString["ID"]);
            NroBoleto = Request.QueryString["nroboleta"];
            Session["NroBoleto"] = NroBoleto;
            NroAsientoL = Request.QueryString["nroAsientoL"];
            Session["NroAsientoL"] = NroAsientoL;
            IBL_Boleto carga = new BL_Boleto();
            List<BE_Boleto> ListaBoleto = carga.f_ConsultarAsientosVehiculo(IdVehiculo);
            grvAsientos.DataSource = ListaBoleto;
            grvAsientos.DataBind();
        }
    }

    protected void grvAsientos_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdCambiarAsiento")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvAsientos.Rows[index];
            ListItem item = new ListItem();
            item.Text = Server.HtmlDecode(row.Cells[1].Text);
            IBL_Boleto carga = new BL_Boleto();
            NroBoleto = (string)(Session["NroBoleto"]);
            string NroAsiento = (string)this.grvAsientos.DataKeys[index]["Asiento"];
            NroAsientoL = (string)(Session["NroAsientoL"]);
            BE_Boleto objBoleto = carga.f_ActualizarAsiento(NroBoleto, NroAsiento, NroAsientoL);
            Response.Redirect("~/GestionarAsiento.aspx?ID=1&nroboleta=" + NroBoleto);
        }
    }

    protected void btnRetornar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdministrarCheckin.aspx");
    }
}