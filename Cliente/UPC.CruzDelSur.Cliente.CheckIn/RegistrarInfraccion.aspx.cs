using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistrarInfraccion : System.Web.UI.Page
{

    public string NroBoleto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        NroBoleto = Request.QueryString["nroboleto"];
        lblCodBoleto.Text = NroBoleto.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/VerificarEquipaje.aspx");
    }
}