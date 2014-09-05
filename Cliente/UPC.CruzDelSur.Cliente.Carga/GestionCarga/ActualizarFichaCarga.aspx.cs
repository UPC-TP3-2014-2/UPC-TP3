using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using C.Data.Global;
using UPC.CruzDelSur.Cliente.Carga.Controller.GestionCarga;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class ActualizarFichaCarga : System.Web.UI.Page
    {

        ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{

            if (!String.IsNullOrEmpty(Context.Request.QueryString["idficha"]))
            {
                hffichacarga.Value = Context.Request.QueryString["idficha"].ToString();


                Session["idcarga"] = hffichacarga.Value;



                List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
                ParametroGenerico _BEParametro = new ParametroGenerico();
                _BEParametro.nombre = "MG_ES01_FichaCarga_ID";
                _BEParametro.valor = hffichacarga.Value;
                _ArrayParam.Add(_BEParametro);

                BEMG_ES01_FichaCarga oBEMG_ES01_FichaCarga = _servletGestionCarga.ListarUnoFichas(_ArrayParam);
                txtFicha.Text = oBEMG_ES01_FichaCarga.Ficha;
                //txtImporteTotal .Text = oBEMG_ES01_FichaCarga.ImporteTotal.ToString();
                //txtObservacion.Text = oBEMG_ES01_FichaCarga.Observacion.ToString();
                //txtPesoTotal.Text = oBEMG_ES01_FichaCarga.PesoTotal.ToString();


                Session["idProgramacionRuta"] = oBEMG_ES01_FichaCarga.MK_ProgramacionRuta_ID;
                Session["idRemitente"] = oBEMG_ES01_FichaCarga.MG_ES04_Cliente_ID;
                Session["idDestinatario"] = oBEMG_ES01_FichaCarga.MG_ES04_Cliente_T_MG_ES04_Cliente_ID;




            }


            if (Session["idProgramacionRuta"] != null)
            {
                //CREAMOS LOS PARAMETROS
                List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
                ParametroGenerico _BEParametro = new ParametroGenerico();
                _BEParametro.nombre = "MK_ProgramacionRuta_ID";
                _BEParametro.valor = Session["idProgramacionRuta"].ToString();
                _ArrayParam.Add(_BEParametro);
                BEMK_ProgramacionRuta oBEMK_ProgramacionRuta = _servletGestionCarga.ListarUnoProgramacionRuta(_ArrayParam);
                ddlAgenciaDestino.SelectedValue = oBEMK_ProgramacionRuta.MG_ES10_Agencia_T_MG_ES10_Agencia_ID.ToString();
                txtFechasalida.Text = oBEMK_ProgramacionRuta.FechaHoraOrigen.ToShortDateString();
                txtfechallegada.Text = oBEMK_ProgramacionRuta.FechaHoraDestino.ToShortDateString();
                txtUnidadTransporte.Text = oBEMK_ProgramacionRuta.Descripcion;
                MK_ProgramacionRuta_ID.Value = oBEMK_ProgramacionRuta.MK_ProgramacionRuta_ID.ToString();
            }


            if (Session["clave"] != null)
            {
                lblClave.Text = Session["clave"].ToString();
            }

            if (Session["idRemitente"] != null)
            {


                List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
                ParametroGenerico _BEParametro = new ParametroGenerico();
                _BEParametro.nombre = "MG_ES04_Cliente_ID";
                _BEParametro.valor = Session["idRemitente"].ToString();
                _ArrayParam.Add(_BEParametro);

                BEMG_ES04_Cliente oBEMG_ES04_Cliente = _servletGestionCarga.ListarUnoCliente(_ArrayParam);



                txtRemitente.Text = String.Concat(oBEMG_ES04_Cliente.Nombres, " ", oBEMG_ES04_Cliente.Apellidos);
                txtDniRemitente.Text = oBEMG_ES04_Cliente.Documento;

                HFIdClienteRemi.Value = oBEMG_ES04_Cliente.MG_ES04_Cliente_ID.ToString();


            }
            if (Session["idDestinatario"] != null)
            {

                List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
                ParametroGenerico _BEParametro = new ParametroGenerico();
                _BEParametro.nombre = "MG_ES04_Cliente_ID";
                _BEParametro.valor = Session["idDestinatario"].ToString();
                _ArrayParam.Add(_BEParametro);

                BEMG_ES04_Cliente oBEMG_ES04_Cliente = _servletGestionCarga.ListarUnoCliente(_ArrayParam);



                txtDestinatario.Text = String.Concat(oBEMG_ES04_Cliente.Nombres, " ", oBEMG_ES04_Cliente.Apellidos);
                txtDNIDestinatario.Text = oBEMG_ES04_Cliente.Documento;

                HFIdClienteDest.Value = oBEMG_ES04_Cliente.MG_ES04_Cliente_ID.ToString();

            }



            List<BEMG_ES03_Producto> ListaProducto = new List<BEMG_ES03_Producto>();
            if (Session["ListaProducto"] != null)
            {
                ListaProducto = (List<BEMG_ES03_Producto>)Session["ListaProducto"];
            }
            else
            {
                ListaProducto.Add(new BEMG_ES03_Producto());
            }

            if (Session["idProducto"] != null)
            {
                List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
                ParametroGenerico _BEParametro = new ParametroGenerico();
                _BEParametro.nombre = "MG_ES03_Producto_ID";
                _BEParametro.valor = Session["idProducto"].ToString();
                _ArrayParam.Add(_BEParametro);

                BEMG_ES03_Producto oBEMG_ES03_Producto = _servletGestionCarga.ListarUnoProductos(_ArrayParam);

                ListaProducto.RemoveAll(item => item.MG_ES03_Producto_ID == oBEMG_ES03_Producto.MG_ES03_Producto_ID);
                ListaProducto.Add(oBEMG_ES03_Producto);



                Session["ListaProducto"] = ListaProducto;

            }
            if (Session["clave"] != null)
            {
                lblClave.Text = Session["clave"].ToString();
            }

            gvProductos.DataSource = ListaProducto;
            gvProductos.DataBind();

            //}

        }
        protected void setInfo()
        {
            ViewState["codigoFicha"] = txtFicha.Text;
        }
        protected void GetInfo()
        {
            txtFicha.Text = ViewState["codigoFicha"].ToString();
        }
        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                List<BEMG_ES03_Producto> ListaProducto = new List<BEMG_ES03_Producto>();
                if (Session["ListaProducto"] != null)
                {
                    ListaProducto = (List<BEMG_ES03_Producto>)Session["ListaProducto"];


                    List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
                    ParametroGenerico _BEParametro = new ParametroGenerico();
                    _BEParametro.nombre = "MG_ES03_Producto_ID";
                    _BEParametro.valor = e.CommandArgument.ToString();
                    _ArrayParam.Add(_BEParametro);

                    BEMG_ES03_Producto oBEMG_ES03_Producto = _servletGestionCarga.ListarUnoProductos(_ArrayParam);


                    ListaProducto.RemoveAll(item => item.MG_ES03_Producto_ID == oBEMG_ES03_Producto.MG_ES03_Producto_ID);
                    gvProductos.DataSource = ListaProducto;
                    gvProductos.DataBind();

                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            BEMG_ES01_FichaCarga oBEMG_ES01_FichaCarga = new BEMG_ES01_FichaCarga();

            oBEMG_ES01_FichaCarga.ClaveSeguridad = lblClave.Text;
            oBEMG_ES01_FichaCarga.DestiDni = int.Parse(txtDNIDestinatario.Text);
            oBEMG_ES01_FichaCarga.MG_ES10_Agencia_IDDestino = Convert.ToInt32(ddlAgenciaDestino.SelectedValue);
            oBEMG_ES01_FichaCarga.MG_ES10_Agencia_IDOrigen = Convert.ToInt32(ddlAgenciaOrigen.SelectedValue);
            oBEMG_ES01_FichaCarga.Destinatario = txtDestinatario.Text;
            oBEMG_ES01_FichaCarga.Estado = "Registrado";
            oBEMG_ES01_FichaCarga.EstadoPago = true;
            oBEMG_ES01_FichaCarga.FechaModifica = DateTime.Now.Date;
            oBEMG_ES01_FichaCarga.FechaRegistra = DateTime.Now.Date;
            oBEMG_ES01_FichaCarga.FechaRegistro = DateTime.Now.Date;
            oBEMG_ES01_FichaCarga.Ficha = txtFicha.Text;
            oBEMG_ES01_FichaCarga.MG_ES04_Cliente_T_MG_ES04_Cliente_ID = int.Parse(HFIdClienteDest.Value);
            oBEMG_ES01_FichaCarga.MG_ES04_Cliente_ID = int.Parse(HFIdClienteRemi.Value);
            oBEMG_ES01_FichaCarga.ImporteTotal = double.Parse(txtImporteTotal.Text);
            oBEMG_ES01_FichaCarga.Observacion = txtObservacion.Text;
            oBEMG_ES01_FichaCarga.PesoTotal = double.Parse(txtPesoTotal.Text);
            oBEMG_ES01_FichaCarga.RemiDni = Int32.Parse(txtDniRemitente.Text);
            oBEMG_ES01_FichaCarga.Remitente = txtRemitente.Text;
            oBEMG_ES01_FichaCarga.TipoPago = ddlTipoPago.Text;
            oBEMG_ES01_FichaCarga.UsuarioModifica = "shuaman";
            oBEMG_ES01_FichaCarga.UsuarioRegistra = "shuaman";
            oBEMG_ES01_FichaCarga.MK_ProgramacionRuta_ID = int.Parse(MK_ProgramacionRuta_ID.Value);





            List<BEMG_ES02_DetalleFCarga> oListaDetalleFCargaDTO = new List<BEMG_ES02_DetalleFCarga>();

            foreach (GridViewRow row in gvProductos.Rows)
            {
                BEMG_ES02_DetalleFCarga oDetalleFCargaDTO = new BEMG_ES02_DetalleFCarga();

                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
                TextBox txtPeso = (TextBox)row.FindControl("txtPeso");
                TextBox txtimporte = (TextBox)row.FindControl("txtimporte");

                oDetalleFCargaDTO.Cantidad = Int32.Parse(txtCantidad.Text);
                oDetalleFCargaDTO.Descripcion = row.Cells[2].Text;
                oDetalleFCargaDTO.MG_ES03_Producto_ID = Int32.Parse(row.Cells[0].Text);
                oDetalleFCargaDTO.Importe = Int32.Parse(txtimporte.Text);
                oDetalleFCargaDTO.Peso = Int32.Parse(txtPeso.Text);
                oDetalleFCargaDTO.Producto = row.Cells[1].Text; ;
                oDetalleFCargaDTO.TipoCarga = row.Cells[3].Text; ;
                oDetalleFCargaDTO.MG_ES01_FichaCarga_ID = oBEMG_ES01_FichaCarga.MG_ES01_FichaCarga_ID;
                oListaDetalleFCargaDTO.Add(oDetalleFCargaDTO);
            }


            int reg = _servletGestionCarga.InsertarFichaCarga(oBEMG_ES01_FichaCarga, oListaDetalleFCargaDTO);





            Response.Redirect("ListadoFichaCarga.aspx");
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

                BEMG_ES03_Producto oBEMG_ES03_Producto =(BEMG_ES03_Producto) e.Row .DataItem ;


                TextBox txtCantidad = e.Row.FindControl("txtCantidad") as TextBox;
                TextBox txtimporte = e.Row.FindControl("txtimporte") as TextBox;
                Label lblPrecio = e.Row.FindControl("lblPrecio") as Label;

                TextBox txtPeso = e.Row.FindControl("txtPeso") as TextBox;

                if (lblPrecio != null)
                {
                    
                    lblPrecio.ID = String.Concat("precio-", oBEMG_ES03_Producto.MG_ES03_Producto_ID.ToString());

                }
                
                if (txtCantidad != null)
                { 
                    txtCantidad.ID =String.Concat("producto-", oBEMG_ES03_Producto.MG_ES03_Producto_ID.ToString());

                    txtCantidad.Attributes.Add("onChange", "CalcularImporteProducto('" + txtCantidad.ClientID + "','" + lblPrecio.ClientID + "','" + txtimporte.ClientID + "')");

                }

                if (txtPeso != null)
                {


                    txtPeso.Attributes.Add("onChange", "CalcularPesoTotal()");

                }


            }
        }

    }
}