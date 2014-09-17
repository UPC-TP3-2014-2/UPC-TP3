using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;

using UPC.CruzDelSur.Negocio.Modelo.Carga;
using UPC.CruzDelSur.Datos.Carga;


namespace CRUZDELSUR.UI.Web.GestionCarga
{
    public partial class ListadoFichaCarga : System.Web.UI.Page
    {
        //ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            Session.Remove("idcarga");
            Session.Remove("idProgramacionRuta");
            Session.Remove("idRemitente");
            Session.Remove("idDestinatario");
            Session.Remove("ListaProducto");
            Session.Remove("idProducto");
            Session.Remove("idcarga");
            Session.Remove("clave");
            Response.Redirect("ActualizarFichaCarga.aspx");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarFichas();
            }
        }
        void CargarFichas()
        {

            UPC.CruzDelSur.Datos.Carga.Carga oBL_Carga = new UPC.CruzDelSur.Datos.Carga.Carga();
            gvfichacarga.DataSource = oBL_Carga.f_ListadoCarga(DdlCriterio.SelectedValue.ToString(),txtdato.Text.Trim().ToString());
            gvfichacarga.DataBind();
            
        }

        protected void gvfichacarga_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Modificar")
            {
                Session.Remove("idProgramacionRuta");
                Session.Remove("idRemitente");
                Session.Remove("idDestinatario");
                Session.Remove("ListaProducto");
                Session.Remove("idProducto");
                Session.Remove("idcarga");
                Response.Redirect(String.Concat("ActualizarFichaCarga.aspx?idficha=", e.CommandArgument));
            }
            if (e.CommandName == "Anular")
            {
                Session.Remove("idProducto");
                Session.Remove("idProgramacionRuta");
                Session.Remove("idRemitente");
                Session.Remove("idDestinatario");
                Session.Remove("ListaProducto");
                Session.Remove("idcarga");

                UPC.CruzDelSur.Datos.Carga.Carga oBL_Carga = new UPC.CruzDelSur.Datos.Carga.Carga();
                int o = oBL_Carga.f_ActualizarEstadoCarga("Anulado", e.CommandArgument.ToString());
                CargarFichas();



            }

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            CargarFichas();
        }

        protected void gvfichacarga_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                UPC.CruzDelSur.Negocio.Modelo.Carga.Carga oBEMG_ES01_FichaCarga = (UPC.CruzDelSur.Negocio.Modelo.Carga.Carga)e.Row.DataItem;


                LinkButton lnkButtonValidar = (LinkButton)e.Row.FindControl("lnkButtonValidar");
                LinkButton lnkModificar = (LinkButton)e.Row.FindControl("lnkModificar");
                LinkButton LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");


                


                if (oBEMG_ES01_FichaCarga.ESTADO == "Anulado" || oBEMG_ES01_FichaCarga.ESTADO == "Entregado")
                {
                    lnkButtonValidar.Visible = false;
                    lnkModificar.Visible = false;
                    LinkButton2.Visible = false;
                }


                lnkButtonValidar.Attributes.Add("href", "ValidarFichaCarga.aspx?idficha=" + oBEMG_ES01_FichaCarga.CODIGO_CARGA);


                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton1.Attributes.Add("onClick", "javascript:OpenModalDialog('ImprimirFichaCarga.aspx?idficha=" + oBEMG_ES01_FichaCarga.CODIGO_CARGA + "','null','500','900')");

                if (Session["rol"].ToString() == "Recepcionista")
                {
                    lnkButtonValidar.Visible = true;
                    lnkModificar.Visible = false;
                    LinkButton2.Visible = false;
                    LinkButton1.Visible = false;
                }
                else
                {
                    lnkButtonValidar.Visible = false;
                    lnkModificar.Visible = true;
                    LinkButton2.Visible = true;
                    LinkButton1.Visible = true;
                }



            }
        }

    }
}