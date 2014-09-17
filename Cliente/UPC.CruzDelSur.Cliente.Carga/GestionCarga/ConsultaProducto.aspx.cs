using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;

using UPC.CruzDelSur.Datos.Carga;
using UPC.CruzDelSur.Negocio.Modelo.Carga;

namespace CRUZDELSUR.UI.Web.GestionCarga
{
    public partial class ConsultaProducto : System.Web.UI.Page
    {
        //ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();

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
            //if (e.CommandName == "Seleccionar")
            //{
            //    Session["idProducto"] = e.CommandArgument;
            //    this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Seleccionado'); CloseFormOK();</script>"));
            //}
        }
        void CargarProdutos()
        {
            //CREAMOS LOS PARAMETROS
            UPC.CruzDelSur.Datos.Carga.Producto oBL_Producto = new UPC.CruzDelSur.Datos.Carga.Producto();
            gvProductos.DataSource = oBL_Producto.f_ListadoProducto(txtDescripcion.Text.Trim());
            gvProductos.DataBind();   
        }
        protected void btnSeleccionarProductos_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow  item in gvProductos.Rows)
            {
                CheckBox lnkSeleccionar = (CheckBox)item.FindControl("lnkSeleccionar");
                if (lnkSeleccionar != null)
                {
                    List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga> ListaProducto = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>();
                    if (Session["ListaProducto"] != null)
                    {
                        ListaProducto = (List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>)Session["ListaProducto"];
                    }

                    if (lnkSeleccionar.Checked)
                    {
                        UPC.CruzDelSur.Datos.Carga.Producto oBL_Producto = new UPC.CruzDelSur.Datos.Carga.Producto();
                        UPC.CruzDelSur.Negocio.Modelo.Carga.Producto oBE_Producto = oBL_Producto.f_ListadoUnoProducto(Int32.Parse(lnkSeleccionar.CssClass));


                        ListaProducto.RemoveAll(item2 => item2.CODIGO_PRODUCTO == oBE_Producto.CODIGO_PRODUCTO);
                        ListaProducto.RemoveAll(item2 => item2.CODIGO_PRODUCTO == 0);

                        UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga oBE_DetalleCarga = new UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga();
                        oBE_DetalleCarga.CODIGO_PRODUCTO = oBE_Producto.CODIGO_PRODUCTO;
                        oBE_DetalleCarga.DESCRIPCION = oBE_Producto.DESCRIPCION;
                        oBE_DetalleCarga.PRECIO = oBE_Producto.PRECIO;
                        ListaProducto.Add(oBE_DetalleCarga);

                        Session["ListaProducto"] = ListaProducto;
                    }
                }
                    this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Se Actualizaron los productos'); CloseFormOK();</script>"));
            }
        }
    }
}