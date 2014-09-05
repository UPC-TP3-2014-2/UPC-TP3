using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using C.Data.Global;
using UPC.CruzDelSur.Cliente.Carga.Controller.GestionCarga;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class ListadoFichaCarga : System.Web.UI.Page
    {
        ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            Session.Remove("idProgramacionRuta") ;
            Session.Remove ("idRemitente");
            Session.Remove("idDestinatario");

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
            //CREAMOS LOS PARAMETROS
            List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
            ParametroGenerico _BEParametro = new ParametroGenerico();
            _BEParametro.nombre = "OPT";
            _BEParametro.valor = DdlCriterio.SelectedValue;

            _ArrayParam.Add(_BEParametro);


            _BEParametro = new ParametroGenerico();
            _BEParametro.nombre = "DESCRIPCION";
            _BEParametro.valor = txtdato.Text ;

            _ArrayParam.Add(_BEParametro);

            //Invocamos al controlador de flota
            _servletGestionCarga.ListarFichas(gvfichacarga, _ArrayParam);
        }

        protected void gvfichacarga_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "Modificar")
            {
                Response.Redirect(String.Concat("ActualizarFichaCarga.aspx?idficha=", e.CommandArgument));
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

                BEMG_ES01_FichaCarga oBEMG_ES01_FichaCarga = (BEMG_ES01_FichaCarga)e.Row.DataItem;

                LinkButton lnkButtonValidar = (LinkButton)e.Row.FindControl("lnkButtonValidar");
                lnkButtonValidar.Attributes.Add("onClick", "javascript:OpenModalDialog('ValidarFichaCarga.aspx?idficha=" + oBEMG_ES01_FichaCarga.MG_ES01_FichaCarga_ID  + "','null','400','400')");


            }
        }

    }
}