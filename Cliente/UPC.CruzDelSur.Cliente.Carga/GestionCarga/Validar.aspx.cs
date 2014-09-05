using System;
using System.Collections.Generic;
using System.Web.UI;
using C.Data.Global;
using UPC.CruzDelSur.Cliente.Carga.Controller.GestionCarga;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class Validar : System.Web.UI.Page
    {

        ServletGestionCarga _servletGestionCarga = new ServletGestionCarga();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(Context.Request.QueryString["opt"]))
            {
                if (Context.Request.QueryString["opt"] == "1")
                {
                    Session["clave"] = Seguridad.Encriptar(txtClave.Text.ToString());
                    this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Seleccionado'); CloseFormOK();</script>"));
                }
                if (Context.Request.QueryString["opt"] == "2")
                {


                    List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
                    ParametroGenerico _BEParametro = new ParametroGenerico();
                    _BEParametro.nombre = "MG_ES01_FichaCarga_ID";
                    _BEParametro.valor = Session["idcarga"].ToString();
                    _ArrayParam.Add(_BEParametro);

                    BEMG_ES01_FichaCarga oBEMG_ES01_FichaCarga = _servletGestionCarga.ListarUnoFichas(_ArrayParam);

                    if (oBEMG_ES01_FichaCarga.ClaveSeguridad == Seguridad.Encriptar (txtClave.Text).ToString())
                    {
                        this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Clave Validada'); CloseFormOK();</script>"));
                    }
                    else
                        this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Clave ingresada no es validad, no se puede validar la carga'); CloseFormOK();</script>"));  

                }
            }

            









           
        }
    }
}