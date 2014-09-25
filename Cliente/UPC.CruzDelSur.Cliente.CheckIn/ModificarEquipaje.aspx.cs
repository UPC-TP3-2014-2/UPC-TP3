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
            
        }
    }


    protected void btnActualizarRegistroEquipaje_Click(object sender, EventArgs e)
    {

    }
}