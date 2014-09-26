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
namespace CRUZDELSUR.UI.Web.GestionCarga
{
    public partial class ActualizarFichaCarga : System.Web.UI.Page
    {

        //ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UPC.CruzDelSur.Datos.Carga.Carga CodigoFicha  = new UPC.CruzDelSur.Datos.Carga.Carga();

                UPC.CruzDelSur.Datos.Carga.Agencia blAgencia = new UPC.CruzDelSur.Datos.Carga.Agencia();


                ddlAgenciaOrigen.DataSource = blAgencia.f_ListadoAgencia();
                ddlAgenciaOrigen.DataValueField = "CODIGO_AGENCIA";
                ddlAgenciaOrigen.DataTextField = "NOMBRE";
                ddlAgenciaOrigen.DataBind();


                ddlAgenciaDestino.DataSource = blAgencia.f_ListadoAgencia();
                ddlAgenciaDestino.DataValueField = "CODIGO_AGENCIA";
                ddlAgenciaDestino.DataTextField = "NOMBRE";
                ddlAgenciaDestino.DataBind();




                txtFicha.Text = CodigoFicha.f_GenerarNumero();
                if (!String.IsNullOrEmpty(Context.Request.QueryString["idficha"]))
                {
                    hffichacarga.Value = Context.Request.QueryString["idficha"].ToString();


                    Session["idcarga"] = hffichacarga.Value;


                    UPC.CruzDelSur.Datos.Carga.Carga oBL_Carga = new UPC.CruzDelSur.Datos.Carga.Carga();
                    UPC.CruzDelSur.Negocio.Modelo.Carga.Carga  oBE_Carga = oBL_Carga.f_ListadoUnoCarga(Int32.Parse(hffichacarga.Value));


                    txtFicha.Text = oBE_Carga.FICHA;
                    txtObservacion.Text = oBE_Carga.OBSERVACION;
                    lblClave.Text = oBE_Carga.CLAVE_SEGURIDAD;
                    txtImporteTotal.Text = oBE_Carga.DBL_IMPORTETOTAL.ToString();
                    txtPesoTotal.Text = oBE_Carga.DBL_PESOTOTAL.ToString();
                    ddlTipoPago.SelectedValue = oBE_Carga.TIPO_PAGO.ToString();


                    UPC.CruzDelSur.Datos.Carga.DetalleCarga oBL_DetalleCarga = new UPC.CruzDelSur.Datos.Carga.DetalleCarga();


                    Session["idProgramacionRuta"] = oBE_Carga.CODIGO_PROGRAMACION_RUTA;
                    Session["idRemitente"] = oBE_Carga.CLIENTE_ORIGEN;
                    Session["idDestinatario"] = oBE_Carga.CLIENTE_DESTINO;


                    if (Session["ListaProducto"] == null)
                        Session["ListaProducto"] = oBL_DetalleCarga.f_ListaDetalleCarga(Int32.Parse(hffichacarga.Value));



                    if (Session["idRemitente"] != null)
                    {
                        UPC.CruzDelSur.Datos.Carga.Cliente oBL_Cliente = new UPC.CruzDelSur.Datos.Carga.Cliente();
                        UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente oCliente = oBL_Cliente.f_UnoCliente(Session["idRemitente"].ToString());
                        txtRemitente.Text = String.Concat(oCliente.NOMBRES, " ", oCliente.APELLIDOS);
                        txtDniRemitente.Text = oCliente.DOCUMENTO;
                        HFIdClienteRemi.Value = oCliente.DOCUMENTO;
                    }
                    if (Session["idDestinatario"] != null)
                    {


                        UPC.CruzDelSur.Datos.Carga.Cliente oBL_Cliente = new UPC.CruzDelSur.Datos.Carga.Cliente();
                        UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente oCliente = oBL_Cliente.f_UnoCliente(Session["idDestinatario"].ToString());

                        txtDestinatario.Text = String.Concat(oCliente.NOMBRES, " ", oCliente.APELLIDOS);
                        txtDNIDestinatario.Text = oCliente.DOCUMENTO;

                        HFIdClienteDest.Value = oCliente.DOCUMENTO;

                    }



                    
                }

            }



            if (Session["idProgramacionRuta"] != null)
            {
                //CREAMOS LOS PARAMETROS

                UPC.CruzDelSur.Datos.Carga.Programacion_Ruta oBL_Programacion_Ruta = new UPC.CruzDelSur.Datos.Carga.Programacion_Ruta();

                UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta oBE_Programacion_Ruta = oBL_Programacion_Ruta.f_UnoProgramacion_Ruta(Int32.Parse(Session["idProgramacionRuta"].ToString()));


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





            List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga> ListaProducto = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>();
            if (Session["ListaProducto"] != null)
            {
                ListaProducto = (List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>)Session["ListaProducto"];
            }
            else
            {
                gvProductos.DataSource = null;
                gvProductos.DataBind();
            }
            if (Session["idProducto"] != null)
            {
                UPC.CruzDelSur.Datos.Carga.Producto oBL_Producto = new UPC.CruzDelSur.Datos.Carga.Producto();
                UPC.CruzDelSur.Negocio.Modelo.Carga.Producto oBE_Producto = oBL_Producto.f_ListadoUnoProducto(Int32.Parse(Session["idProducto"].ToString()));


                ListaProducto.RemoveAll(item => item.CODIGO_PRODUCTO == oBE_Producto.CODIGO_PRODUCTO);
                ListaProducto.RemoveAll(item => item.CODIGO_PRODUCTO == 0);

                UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga oBE_DetalleCarga = new UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga();
                oBE_DetalleCarga.CODIGO_PRODUCTO = oBE_Producto.CODIGO_PRODUCTO;
                oBE_DetalleCarga.DESCRIPCION = oBE_Producto.DESCRIPCION;
                oBE_DetalleCarga.PRECIO = oBE_Producto.PRECIO;
                ListaProducto.Add(oBE_DetalleCarga);

                Session["ListaProducto"] = ListaProducto;
            }
            if (Session["clave"] != null)
            {
                lblClave.Text = "******";
                HFPregunta.Value = Session["pregunta"].ToString();
                HFRespuesta.Value = Session["respuesta"].ToString();
            }


            if (gvProductos.Rows.Count != ListaProducto.Count())
            {
                gvProductos.DataSource = ListaProducto;
                gvProductos.DataBind();
            }



            CalculaPesoTotalImporteTotal();

            //    //}

            //}
            //protected void setInfo()
            //{
            //    ViewState["codigoFicha"] = txtFicha.Text;
            //}
            //protected void GetInfo()
            //{
            //    txtFicha.Text = ViewState["codigoFicha"].ToString();
        }
        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga> ListaProducto = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>();
                if (Session["ListaProducto"] != null)
                {
                    ListaProducto = (List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>)Session["ListaProducto"];
                    UPC.CruzDelSur.Datos.Carga.Producto oBL_Producto = new UPC.CruzDelSur.Datos.Carga.Producto();
                    UPC.CruzDelSur.Negocio.Modelo.Carga.Producto oBE_Producto = oBL_Producto.f_ListadoUnoProducto(Int32.Parse(e.CommandArgument.ToString()));

                    ListaProducto.RemoveAll(item => item.CODIGO_PRODUCTO == oBE_Producto.CODIGO_PRODUCTO);

                    Session["ListaProducto"] = ListaProducto;
                    gvProductos.DataSource = ListaProducto;
                    gvProductos.DataBind();

                    CalculaPesoTotalImporteTotal();

                }
            }
        }

        void CalculaPesoTotalImporteTotal()
        {
            Double importetotal = 0;
            Double pesototal = 0;
            foreach (GridViewRow row in gvProductos.Rows)
            {
                TextBox txtPeso = (TextBox)row.FindControl("txtPeso");

                TextBox txtimporte = (TextBox)row.FindControl("txtimporte");
                DropDownList ddlTipoCarga = (DropDownList)row.FindControl("ddlTipoCarga");

                if (txtimporte.Text != "")
                {
                    if (txtimporte.Text.Trim().ToString() == "")
                        importetotal += 0;
                    else
                        importetotal += double.Parse(txtimporte.Text);
                }
                if (txtPeso.Text != "")
                    if (txtPeso.Text.Trim().ToString() == "")
                        pesototal += 0;
                    else
                        pesototal += double.Parse(txtPeso.Text);

            }
            txtImporteTotal.Text = importetotal.ToString();
            txtPesoTotal.Text = pesototal.ToString();
            txtigv.Text = (importetotal * 0.18).ToString();
            txtTotal.Text = (importetotal * 1.18).ToString();

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (gvProductos.Rows.Count == 0)
            {
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Debe Seleccionar Productos'); </script>"));
                return;
            }

            if (lblClave.Text.Trim().ToString().Length == 0)
            {
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Debe Ingresar la clave de seguridad'); </script>"));
                return;
            }




            UPC.CruzDelSur.Negocio.Modelo.Carga.Carga oBE_Carga = new UPC.CruzDelSur.Negocio.Modelo.Carga.Carga();
            oBE_Carga.CODIGO_CARGA = Int32.Parse(hffichacarga.Value);

            List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga> oListaDetalleFCargaDTO = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>();
            Double importetotal = 0;
            Double pesototal = 0;
            foreach (GridViewRow row in gvProductos.Rows)
            {
                UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga oDetalleFCargaDTO = new UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga();


                UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga oBEMG_ES03_Producto = (UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga)row.DataItem;


                TextBox txtCantidad = row.FindControl("txtCantidad") as TextBox;
                TextBox txtPeso = (TextBox)row.FindControl("txtPeso");

                TextBox txtimporte = (TextBox)row.FindControl("txtimporte");
                DropDownList ddlTipoCarga = (DropDownList)row.FindControl("ddlTipoCarga");

                importetotal += double.Parse(txtimporte.Text);
                pesototal += double.Parse(txtPeso.Text);



                oDetalleFCargaDTO.CANTIDAD = Int32.Parse(txtCantidad.Text);
                oDetalleFCargaDTO.DESCRIPCION = row.Cells[1].Text;
                oDetalleFCargaDTO.CODIGO_PRODUCTO = Int32.Parse(row.Cells[0].Text);
                oDetalleFCargaDTO.DBL_IMPORTE = double.Parse(txtimporte.Text);
                oDetalleFCargaDTO.DBL_PESO = double.Parse(txtPeso.Text);

                oDetalleFCargaDTO.TIPO_CARGA = Int32.Parse(ddlTipoCarga.SelectedValue);

                oDetalleFCargaDTO.CODIGO_CARGA = oBE_Carga.CODIGO_CARGA;
                oListaDetalleFCargaDTO.Add(oDetalleFCargaDTO);
            }
            oBE_Carga.CLAVE_SEGURIDAD = Session["clave"].ToString(); ;
            oBE_Carga.PREGUNTA_SEGURIDAD = HFPregunta.Value ;
            oBE_Carga.RESPUESTA_SEGURIDAD = HFRespuesta.Value;
            oBE_Carga.DESTINATARIO = txtDestinatario.Text;
            oBE_Carga.CLIENTE_DESTINO = HFIdClienteDest.Value;
            oBE_Carga.DESTINATARIO = txtDestinatario.Text;
            oBE_Carga.ESTADO = "Registrado";
            oBE_Carga.CODIGO_GUIA = null;
            oBE_Carga.ESTADOPAGO = ddlTipoPago.SelectedValue;
            oBE_Carga.FECHA_REGISTRO = DateTime.Now.Date;
            oBE_Carga.FICHA = txtFicha.Text;
            oBE_Carga.CLIENTE_ORIGEN = HFIdClienteRemi.Value;
            oBE_Carga.REMITENTE = txtRemitente.Text;
            oBE_Carga.DBL_IMPORTETOTAL = importetotal;
            oBE_Carga.OBSERVACION = txtObservacion.Text;
            oBE_Carga.DBL_PESOTOTAL = pesototal;


            txtigv.Text = (importetotal * 0.18).ToString();
            txtTotal.Text = (importetotal * 1.18).ToString();


            oBE_Carga .DBL_IGV = (importetotal * 0.18);
            oBE_Carga.DBL_TOTAL  = (importetotal * 1.18);

            oBE_Carga.CODIGO_PROGRAMACION_RUTA = int.Parse(MK_ProgramacionRuta_ID.Value);
            oBE_Carga.oDetalleCarga = oListaDetalleFCargaDTO;

            UPC.CruzDelSur.Datos.Carga.Carga oBL_Carga = new UPC.CruzDelSur.Datos.Carga.Carga();





            int resultado = oBL_Carga.f_AgregarCarga(oBE_Carga);




            this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('El Registro se realizo con exito'); window.location = 'ListadoFichaCarga.aspx'; </script>"));
            //Response.Redirect("ListadoFichaCarga.aspx");
        }

        protected void btnIngresarCodigo_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoFichaCarga.aspx");
        }

        protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga oBEMG_ES03_Producto = (UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga)e.Row.DataItem;


                TextBox txtCantidad = e.Row.FindControl("txtCantidad") as TextBox;
                TextBox txtimporte = e.Row.FindControl("txtimporte") as TextBox;
                Label lblPrecio = e.Row.FindControl("lblPrecio") as Label;

                TextBox txtPeso = e.Row.FindControl("txtPeso") as TextBox;

                if (lblPrecio != null)
                {

                    //lblPrecio.ID = String.Concat("precio-", oBEMG_ES03_Producto.CODIGO_PRODUCTO.ToString());

                }

                if (txtCantidad != null)
                {
                    //txtCantidad.ID = String.Concat("producto-", oBEMG_ES03_Producto.CODIGO_PRODUCTO.ToString());

                    txtCantidad.Attributes.Add("onChange", "CalcularImporteProducto('" + txtCantidad.ClientID + "','" + lblPrecio.ClientID + "','" + txtPeso.ClientID + "','" + txtimporte.ClientID + "')");



                }

                if (txtPeso != null)
                {

                    txtPeso.Attributes.Add("onChange", "CalcularImporteProducto('" + txtCantidad.ClientID + "','" + lblPrecio.ClientID + "','" + txtPeso.ClientID + "','" + txtimporte.ClientID + "');CalcularPesoTotal()");
                    //txtPeso.Attributes.Add("onChange", "");

                }


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UPC.CruzDelSur.Datos.Carga.Cliente oBL_Cliente = new UPC.CruzDelSur.Datos.Carga.Cliente();
            UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente oCliente = oBL_Cliente.f_UnoCliente(txtDniRemitente.Text.Trim());

            if (oCliente != null && oCliente.NOMBRES != null)
            {
                txtRemitente.Text = String.Concat(oCliente.NOMBRES, " ", oCliente.APELLIDOS);
                txtDniRemitente.Text = oCliente.DOCUMENTO;
                HFIdClienteRemi.Value = oCliente.DOCUMENTO;
                Session["idRemitente"] = txtDniRemitente.Text;
            }
            else
            {
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('El Cliente no existe'); CloseFormOK();</script>"));
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            UPC.CruzDelSur.Datos.Carga.Cliente oBL_Cliente = new UPC.CruzDelSur.Datos.Carga.Cliente();
            UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente oCliente = oBL_Cliente.f_UnoCliente(txtDNIDestinatario.Text.Trim());

            if (oCliente != null && oCliente.NOMBRES  != null)
            {
                txtDestinatario.Text = String.Concat(oCliente.NOMBRES, " ", oCliente.APELLIDOS);
                txtDNIDestinatario.Text = oCliente.DOCUMENTO;

                HFIdClienteDest.Value = oCliente.DOCUMENTO;
                Session["idDestinatario"] = txtDNIDestinatario.Text;
            }
            else
            {
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('El Cliente no existe'); CloseFormOK();</script>"));
            }


        }

    }
}