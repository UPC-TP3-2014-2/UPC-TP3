using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUZDELSUR.UI.Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                lblPerfl.Text = Session["rol"].ToString();
                lbSession.Text = "Cerrar sesion";
            }
            else { lbSession.Text = "Iniciar sesion"; }

            
        }

        protected void lbSession_Click(object sender, EventArgs e)
        {
            Response.Redirect("/GestionCarga/login.aspx");
        }
    }
}
