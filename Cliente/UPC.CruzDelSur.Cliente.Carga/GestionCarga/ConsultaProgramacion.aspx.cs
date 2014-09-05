using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using C.Data.Global;
using UPC.CruzDelSur.Cliente.Carga.Controller.GestionCarga;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class ConsultaProgramacion : System.Web.UI.Page
    {
        ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarRutas();
            }
        }
        protected void gvProgramacionRuta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Session["idProgramacionRuta"] = e.CommandArgument;
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Seleccionado'); CloseFormOK();</script>"));
            }
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarRutas();
        }
        void CargarRutas()
        {
            //CREAMOS LOS PARAMETROS
            List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
            ParametroGenerico _BEParametro = new ParametroGenerico();
            _BEParametro.nombre = "MG_ES10_Agencia_ID";
            _BEParametro.valor = ddlAgencias.SelectedValue ;
            _ArrayParam.Add(_BEParametro);

            //Invocamos al controlador de flota
            _servletGestionCarga.ListarProgramacionRuta(gvProgramacionRuta, _ArrayParam);
        }
    }
}