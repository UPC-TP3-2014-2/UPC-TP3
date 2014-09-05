using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using C.Data.Global;
using UPC.CruzDelSur.Cliente.Carga.Controller.GestionCarga;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class ConsultaCliente : System.Web.UI.Page
    {
        ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();
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
            //CREAMOS LOS PARAMETROS
            List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
            ParametroGenerico _BEParametro = new ParametroGenerico();
            _BEParametro.nombre = "Documento";
            _BEParametro.valor = txtNombres.Text;
            _ArrayParam.Add(_BEParametro);

            //Invocamos al controlador de flota
            _servletGestionCarga.ListarClientes (gvCliente , _ArrayParam);
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