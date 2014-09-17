using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using UPC.CruzDelSur.Datos.Carga;



namespace CRUZDELSUR.UI.Web.GestionCarga
{
    public partial class ConsultaCliente : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarClientes();
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }
        void CargarClientes()
        {
            
            Cliente oBL_Cliente = new Cliente();
            gvCliente.DataSource = oBL_Cliente.f_ListadoCliente(txtNombres.Text.Trim());
            gvCliente.DataBind();
        }
        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {

                if (Context.Request.QueryString["opt"] == "1")
                {
                    Session["idRemitente"] = e.CommandArgument;
                }
                else
                {
                    Session["idDestinatario"] = e.CommandArgument;
                }

                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Seleccionado'); CloseFormOK();</script>"));
            }
        }
    }
}