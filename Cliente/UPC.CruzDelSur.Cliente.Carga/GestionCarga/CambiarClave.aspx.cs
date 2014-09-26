using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class CambiarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                if (!String.IsNullOrEmpty(Context.Request.QueryString["idficha"]))
                {
                    hffichacarga.Value = Context.Request.QueryString["idficha"].ToString();
                    btnIngresarCodigo.OnClientClick = "javascript:OpenModalDialog('Validar.aspx?opt=1&idcarga=" + hffichacarga.Value + " ','null','400','800')";
                    UPC.CruzDelSur.Datos.Carga.Carga oBL_Carga = new UPC.CruzDelSur.Datos.Carga.Carga();
                    UPC.CruzDelSur.Negocio.Modelo.Carga.Carga oBEMG_ES01_FichaCarga = oBL_Carga.f_ListadoUnoCarga(Int32.Parse(hffichacarga.Value));
                    lblEstadoPago.Text = oBEMG_ES01_FichaCarga.ESTADOPAGO;
                    lblClave.Text = "*****";
                    lbligv.Text = String.Concat("S/.", oBEMG_ES01_FichaCarga.DBL_IGV.Value.ToString("##0.00"));
                    lblTotal.Text = String.Concat("S/.", oBEMG_ES01_FichaCarga.DBL_TOTAL.Value.ToString("##0.00"));
                    lblNumeroFicha.Text = oBEMG_ES01_FichaCarga.FICHA;
                    lblImporteTotal.Text = String.Concat("S/.", oBEMG_ES01_FichaCarga.DBL_IMPORTETOTAL.Value.ToString("##0.00"));
                    UPC.CruzDelSur.Datos.Carga.Programacion_Ruta oBL_Programacion_Ruta = new UPC.CruzDelSur.Datos.Carga.Programacion_Ruta();
                    UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta oBE_Programacion_Ruta = oBL_Programacion_Ruta.f_UnoProgramacion_Ruta(Int32.Parse(oBEMG_ES01_FichaCarga.CODIGO_PROGRAMACION_RUTA.ToString()));
                    lblAgenciaOrigen.Text = oBE_Programacion_Ruta.ORIGEN;
                    lblAgenciaDestino.Text = oBE_Programacion_Ruta.DESTINO;
                    UPC.CruzDelSur.Datos.Carga.Cliente oBL_Cliente = new UPC.CruzDelSur.Datos.Carga.Cliente();
                    UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente oBE_Cliente = oBL_Cliente.f_UnoCliente(oBEMG_ES01_FichaCarga.CLIENTE_ORIGEN);
                    lblRemitente.Text = String.Concat(oBE_Cliente.NOMBRES, " ", oBE_Cliente.APELLIDOS);
                    UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente oBE_Cliente2 = oBL_Cliente.f_UnoCliente(oBEMG_ES01_FichaCarga.CLIENTE_DESTINO);
                    lblDestinatario.Text = String.Concat(oBE_Cliente2.NOMBRES, " ", oBE_Cliente2.APELLIDOS);
                }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoFichaCarga.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Session["clave"] != null)
            {
                UPC.CruzDelSur.Datos.Carga.Carga beCarga = new UPC.CruzDelSur.Datos.Carga.Carga();

                beCarga.f_ActualizarClave(Session["clave"].ToString(), hffichacarga.Value);
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('La Clave se cambio Exito'); window.location = 'ListadoFichaCarga.aspx'; </script>"));

            }
        }
    }
}