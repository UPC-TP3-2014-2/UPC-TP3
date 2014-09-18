using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;


using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UPC.CruzDelSur.Datos.Carga;
using UPC.CruzDelSur.Negocio.Modelo.Carga;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class ImprimirFichaCarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Context.Request.QueryString["idficha"]))
            {
                hffichacarga.Value = Context.Request.QueryString["idficha"].ToString();


                Session["idcarga2"] = hffichacarga.Value;


                UPC.CruzDelSur.Datos.Carga.Carga oBL_Carga = new UPC.CruzDelSur.Datos.Carga.Carga();
                UPC.CruzDelSur.Negocio.Modelo.Carga.Carga oBE_Carga = oBL_Carga.f_ListadoUnoCarga(Int32.Parse(hffichacarga.Value));


                txtFicha.Text = oBE_Carga.FICHA;
                txtObservacion.Text = oBE_Carga.OBSERVACION;
                lblClave.Text = oBE_Carga.CLAVE_SEGURIDAD;
                txtImporteTotal.Text = oBE_Carga.DBL_IMPORTETOTAL.ToString();

                txtigv.Text = oBE_Carga.DBL_IGV.ToString();
                txtTotal.Text = oBE_Carga.DBL_TOTAL.ToString();

                txtPesoTotal.Text = oBE_Carga.DBL_PESOTOTAL.ToString();
                ddlTipoPago.SelectedValue = oBE_Carga.TIPO_PAGO.ToString();


                UPC.CruzDelSur.Datos.Carga.DetalleCarga oBL_DetalleCarga = new UPC.CruzDelSur.Datos.Carga.DetalleCarga();


                if (Session["ListaProducto2"] == null)
                    Session["ListaProducto2"] = oBL_DetalleCarga.f_ListaDetalleCarga(Int32.Parse(hffichacarga.Value));



                Session["idProgramacionRuta2"] = oBE_Carga.CODIGO_PROGRAMACION_RUTA;
                Session["idRemitente2"] = oBE_Carga.CLIENTE_ORIGEN;
                Session["idDestinatario2"] = oBE_Carga.CLIENTE_DESTINO;
            }


            if (Session["idProgramacionRuta2"] != null)
            {
                //CREAMOS LOS PARAMETROS

                UPC.CruzDelSur.Datos.Carga.Programacion_Ruta oBL_Programacion_Ruta = new UPC.CruzDelSur.Datos.Carga.Programacion_Ruta();

                UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta oBE_Programacion_Ruta = oBL_Programacion_Ruta.f_UnoProgramacion_Ruta(Int32.Parse(Session["idProgramacionRuta2"].ToString()));


                ddlAgenciaDestino.SelectedValue = oBE_Programacion_Ruta.CODIGO_AGENCIADESTINO.ToString();
                txtFechasalida.Text = oBE_Programacion_Ruta.FECHA_ORIGEN.Value.ToShortDateString();
                txtfechallegada.Text = oBE_Programacion_Ruta.FECHA_DESTINO.Value.ToShortDateString();
                MK_ProgramacionRuta_ID.Value = oBE_Programacion_Ruta.CODIGO_PROGRAMACION_RUTA.ToString();
                txtUnidadTransporte.Text = oBE_Programacion_Ruta.PLACA.ToString();
            }


            //    if (Session["clave"] != null)
            //    {
            //        lblClave.Text = Session["clave"].ToString();
            //    }

            if (Session["idRemitente2"] != null)
            {
                UPC.CruzDelSur.Datos.Carga.Cliente oBL_Cliente = new UPC.CruzDelSur.Datos.Carga.Cliente();
                UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente oCliente = oBL_Cliente.f_UnoCliente(Session["idRemitente2"].ToString());
                txtRemitente.Text = String.Concat(oCliente.NOMBRES, " ", oCliente.APELLIDOS);
                txtDniRemitente.Text = oCliente.DOCUMENTO;
                HFIdClienteRemi.Value = oCliente.DOCUMENTO;
            }
            if (Session["idDestinatario2"] != null)
            {


                UPC.CruzDelSur.Datos.Carga.Cliente oBL_Cliente = new UPC.CruzDelSur.Datos.Carga.Cliente();
                UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente oCliente = oBL_Cliente.f_UnoCliente(Session["idDestinatario2"].ToString());

                txtDestinatario.Text = String.Concat(oCliente.NOMBRES, " ", oCliente.APELLIDOS);
                txtDNIDestinatario.Text = oCliente.DOCUMENTO;

                HFIdClienteDest.Value = oCliente.DOCUMENTO;

            }



            List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga> ListaProducto = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>();
            if (Session["ListaProducto2"] != null)
            {
                ListaProducto = (List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>)Session["ListaProducto2"];
            }
            else
            {
                gvProductos.DataSource = null;
                gvProductos.DataBind();
            }
            if (Session["idProducto2"] != null)
            {
                UPC.CruzDelSur.Datos.Carga.Producto oBL_Producto = new UPC.CruzDelSur.Datos.Carga.Producto();
                UPC.CruzDelSur.Negocio.Modelo.Carga.Producto oBE_Producto = oBL_Producto.f_ListadoUnoProducto(Int32.Parse(Session["idProducto2"].ToString()));


                ListaProducto.RemoveAll(item2 => item2.CODIGO_PRODUCTO == oBE_Producto.CODIGO_PRODUCTO);
                ListaProducto.RemoveAll(item2 => item2.CODIGO_PRODUCTO == 0);

                UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga oBE_DetalleCarga = new UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga();
                oBE_DetalleCarga.CODIGO_PRODUCTO = oBE_Producto.CODIGO_PRODUCTO;
                oBE_DetalleCarga.DESCRIPCION = oBE_Producto.DESCRIPCION;
                oBE_DetalleCarga.PRECIO = oBE_Producto.PRECIO;
                ListaProducto.Add(oBE_DetalleCarga);

                Session["ListaProducto2"] = ListaProducto;
            }
            if (Session["clave2"] != null)
            {
                lblClave.Text = Session["clave2"].ToString();
            }


            
                gvProductos.DataSource = ListaProducto;
                gvProductos.DataBind();
            





            //    //}

            //}
            //protected void setInfo()
            //{
            //    ViewState["codigoFicha"] = txtFicha.Text;
            //}
            //protected void GetInfo()
            //{
            //    txtFicha.Text = ViewState["codigoFicha"].ToString();
            this.Controls.Add(new LiteralControl("<script language='JavaScript'> window.print(); </script>"));
            
        }
    }
}