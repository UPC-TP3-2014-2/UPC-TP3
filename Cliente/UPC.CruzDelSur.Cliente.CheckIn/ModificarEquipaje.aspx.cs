using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
public partial class ModificarEquipaje : System.Web.UI.Page
{
    public int CodBoleto = 0;
    public string NumBoleto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //btnImprimir.Visible = true;  
            CodBoleto = Convert.ToInt32(Request.QueryString["ID"]);
            NumBoleto = Convert.ToString(Request.QueryString["nroboleto"]);
            Session["CodBoleto"] = CodBoleto;
            Session["NumBoleto"] = NumBoleto;
            lblNroBoleta.Text = NumBoleto.ToString();

            IBL_Tiket carga = new BL_Tiket();
            List<BE_Tiket> ListaTiket = carga.f_listarTiket();
            grvDetalle.DataSource = ListaTiket;
            grvDetalle.DataBind();
        }
    }

    protected void grvDetalle_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdModificarEquipaje")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            IBL_Equipaje carga = new BL_Equipaje();
            CodBoleto = (int)(Session["CodBoleto"]);
            int cod = Convert.ToInt32(grvDetalle.DataKeys[index].Value);
           BE_Tiket objBoleto = carga.f_modificarEquipaje(cod, CodBoleto);
            Response.Redirect("~/ModificarEquipaje.aspx?ID=" + CodBoleto + "&nroboleto=" + Session["NumBoleto"]);
        }
    }

    protected void btnRetornar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/GestionarEquipaje.aspx");
    }
}