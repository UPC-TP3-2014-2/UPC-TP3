using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using C.Data.Global;
using UPC.CruzDelSur.Cliente.Carga.Controller.GestionCarga;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class ConsultaProducto : System.Web.UI.Page
    {
        ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarProdutos();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            CargarProdutos();
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Session["idProducto"] = e.CommandArgument;
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Seleccionado'); CloseFormOK();</script>"));
            }
        }
        void CargarProdutos()
        {
            //CREAMOS LOS PARAMETROS
            List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
            ParametroGenerico _BEParametro = new ParametroGenerico();
            _BEParametro.nombre = "Producto";
            _BEParametro.valor = txtDescripcion.Text;
            _ArrayParam.Add(_BEParametro);

            //Invocamos al controlador de flota
            _servletGestionCarga.ListarProductos(gvProductos, _ArrayParam);
        }
    }
}