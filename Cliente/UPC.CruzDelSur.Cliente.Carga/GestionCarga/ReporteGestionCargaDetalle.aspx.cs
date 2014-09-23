using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class ReporteGestionCargaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Context.Request.QueryString["idficha"]))
                {
                    UPC.CruzDelSur.Datos.Carga.DetalleCarga oBL_DetalleCarga = new UPC.CruzDelSur.Datos.Carga.DetalleCarga();
                     gvProductos.DataSource =  oBL_DetalleCarga.f_ListaDetalleCarga(Int32.Parse(Context.Request.QueryString["idficha"]));
                     gvProductos.DataBind();
                }
            }
        }
    }
}