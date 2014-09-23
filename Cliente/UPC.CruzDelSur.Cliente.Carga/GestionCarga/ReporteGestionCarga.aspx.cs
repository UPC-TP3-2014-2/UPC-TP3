using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UPC.CruzDelSur.Datos.Carga;
using UPC.CruzDelSur.Negocio.Modelo.Carga;

namespace UPC.CruzDelSur.Cliente.Carga.GestionCarga
{
    public partial class ReporteGestionCarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<UPC.CruzDelSur.Negocio.Modelo.Carga.Agencia> listAgencia = new List<Negocio.Modelo.Carga.Agencia>();
                UPC.CruzDelSur.Datos.Carga.Agencia blAgencia = new Datos.Carga.Agencia();
                listAgencia = blAgencia.f_ListadoAgencia();

                ddlAgenciaOrigen.DataSource = listAgencia;
                ddlAgenciaOrigen.DataValueField = "CODIGO_AGENCIA";
                ddlAgenciaOrigen.DataTextField = "NOMBRE";
                ddlAgenciaOrigen.DataBind();


                dllAgenciaDestino.DataSource = listAgencia;
                dllAgenciaDestino.DataValueField = "CODIGO_AGENCIA";
                dllAgenciaDestino.DataTextField = "NOMBRE";
                dllAgenciaDestino.DataBind();



            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            List<UPC.CruzDelSur.Negocio.Modelo.Carga.Carga> oListCarga = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.Carga>();
            UPC.CruzDelSur.Datos.Carga.Carga BL_Carga = new Datos.Carga.Carga();

            oListCarga = BL_Carga.f_Reporte(Int32.Parse(ddlAgenciaOrigen.SelectedValue), Int32.Parse(dllAgenciaDestino.SelectedValue), ddEstadoPago.SelectedValue, ddlEstadocarga.SelectedValue,DateTime.Parse(txtFechaSalida.Text),DateTime.Parse(txtFechaFin.Text));
            gvDetalle.DataSource = oListCarga;
            gvDetalle.DataBind();


        }

        protected void gvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton oimgbtnDetalle = (ImageButton)e.Row.FindControl("imgbtnDetalle");
                UPC.CruzDelSur.Negocio.Modelo.Carga.Carga oBEMG_ES03_Producto = (UPC.CruzDelSur.Negocio.Modelo.Carga.Carga)e.Row.DataItem;
                oimgbtnDetalle.Attributes.Add("onclick", "javascript:OpenModalDialog('ReporteGestionCargaDetalle.aspx?idficha=" + oBEMG_ES03_Producto.CODIGO_CARGA.ToString() + "','null','400','800')");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Vithal" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvDetalle.GridLines = GridLines.Both;
            gvDetalle.HeaderStyle.Font.Bold = true;
            gvDetalle.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();   


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            this.Controls.Add(new LiteralControl("<script language='JavaScript'>OpenModalDialog('VistaPreliminar.aspx?agenciaSalida=" + dllAgenciaDestino.SelectedValue + "&agenciaOrigen=" + ddlAgenciaOrigen.SelectedValue + "&estadoPago=" + ddEstadoPago.SelectedValue + "&estado=" + ddlEstadocarga.SelectedValue + "&fechaOrigen=" + txtFechaSalida.Text + "&fechaDestino=" + txtFechaFin.Text  + "','null','400','1000')</script>"));
        }
    }
}