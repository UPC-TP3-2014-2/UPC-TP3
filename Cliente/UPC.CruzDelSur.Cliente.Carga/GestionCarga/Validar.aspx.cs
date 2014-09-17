using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;

using UPC.CruzDelSur.Cliente.Carga;
using UPC.CruzDelSur.Datos.Carga;
using UPC.CruzDelSur.Negocio.Modelo.Carga;


namespace CRUZDELSUR.UI.Web.GestionCarga
{
    public partial class Validar : System.Web.UI.Page
    {

        

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

                    UPC.CruzDelSur.Datos.Carga.Carga oBL_Carga = new UPC.CruzDelSur.Datos.Carga.Carga();
                    UPC.CruzDelSur.Negocio.Modelo.Carga.Carga oBE_Carga = oBL_Carga.f_ListadoUnoCarga(Int32.Parse(Context.Request.QueryString["idcarga"]));


                    

                    if (oBE_Carga.CLAVE_SEGURIDAD == Seguridad.Encriptar(txtClave.Text).ToString())
                    {
                        this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('El codigo Ingresado es correcto'); CloseFormOK();</script>"));
                        int o = oBL_Carga.f_ActualizarEstadoCarga("Entregado", Context.Request.QueryString["idcarga"] );

                    }
                    else
                        this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Clave ingresada no es validad, no se puede validar la carga'); CloseFormOK();</script>"));  

                }
            }

            









           
        }
    }
}