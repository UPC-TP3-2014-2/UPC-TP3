using System;
using System.Web.UI.WebControls;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Response.Redirect("ListadoFichaCarga.aspx");
        }
    }
}