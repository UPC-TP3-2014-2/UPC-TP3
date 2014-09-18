using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUZDELSUR.UI.Web.GestionCarga
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            UPC.CruzDelSur.Datos.Carga.Usuario BL_Usuario = new UPC.CruzDelSur.Datos.Carga.Usuario();
            String Rol = BL_Usuario.f_ValidaUsuario(Login1.UserName, Login1.Password);

            if (Rol != "")
            {
                Session["rol"] = Rol;
                Response.Redirect("ListadoFichaCarga");
            }
            else
            {
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('El Usuario no Existe'); </script>"));
            }

        }
    }
}