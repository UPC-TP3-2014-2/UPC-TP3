using System;
using System.Collections.Generic;
using C.Data.Global;
using UPC.CruzDelSur.Cliente.Carga.Controller.GestionCarga;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class ValidarFichaCarga : System.Web.UI.Page
    {
        ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                if (!String.IsNullOrEmpty(Context.Request.QueryString["idficha"]))
                {
                    hffichacarga.Value = Context.Request.QueryString["idficha"].ToString();






                    List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
                    ParametroGenerico _BEParametro = new ParametroGenerico();
                    _BEParametro.nombre = "MG_ES01_FichaCarga_ID";
                    _BEParametro.valor = hffichacarga.Value;
                    _ArrayParam.Add(_BEParametro);

                    BEMG_ES01_FichaCarga oBEMG_ES01_FichaCarga = _servletGestionCarga.ListarUnoFichas(_ArrayParam);


                    lblNumeroFicha.Text = oBEMG_ES01_FichaCarga.Ficha;
                    lblImporteTotal.Text = oBEMG_ES01_FichaCarga.ImporteTotal.ToString();







                    _ArrayParam = new List<ParametroGenerico>();
                    _BEParametro = new ParametroGenerico();
                    _BEParametro.nombre = "MK_ProgramacionRuta_ID";
                    _BEParametro.valor = oBEMG_ES01_FichaCarga.MK_ProgramacionRuta_ID;
                    _ArrayParam.Add(_BEParametro);
                    BEMK_ProgramacionRuta oBEMK_ProgramacionRuta = _servletGestionCarga.ListarUnoProgramacionRuta(_ArrayParam);
                    lblAgenciaOrigen.Text = oBEMK_ProgramacionRuta.Origen;
                    lblAgenciaDestino.Text = oBEMK_ProgramacionRuta.Destino;






                    _ArrayParam = new List<ParametroGenerico>();
                    _BEParametro = new ParametroGenerico();
                    _BEParametro.nombre = "MG_ES04_Cliente_ID";
                    _BEParametro.valor = oBEMG_ES01_FichaCarga.MG_ES04_Cliente_ID;
                    _ArrayParam.Add(_BEParametro);

                    BEMG_ES04_Cliente oBEMG_ES04_Cliente = _servletGestionCarga.ListarUnoCliente(_ArrayParam);

                    lblRemitente.Text = String.Concat(oBEMG_ES04_Cliente.Nombres, " ", oBEMG_ES04_Cliente.Apellidos);


                    _ArrayParam = new List<ParametroGenerico>();
                    _BEParametro = new ParametroGenerico();
                    _BEParametro.nombre = "MG_ES04_Cliente_ID";
                    _BEParametro.valor = oBEMG_ES01_FichaCarga.MG_ES04_Cliente_T_MG_ES04_Cliente_ID;
                    _ArrayParam.Add(_BEParametro);

                    oBEMG_ES04_Cliente = _servletGestionCarga.ListarUnoCliente(_ArrayParam);

                    lblDestinatario.Text = String.Concat(oBEMG_ES04_Cliente.Nombres, " ", oBEMG_ES04_Cliente.Apellidos);





                }

        }
    }
}