using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGestionarChekin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
        
    }

    protected void btnGestionarEquipaje_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/GestionarEquipaje.aspx");
    }
}