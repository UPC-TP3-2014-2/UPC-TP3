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
                List<UPC.CruzDelSur.Negocio.Modelo.Carga.Almacen> listAgencia = new List<Negocio.Modelo.Carga.Almacen>();
                UPC.CruzDelSur.Datos.Carga.Almacen blAgencia = new Datos.Carga.Almacen();
                listAgencia = blAgencia.f_ListadoAlmacen();

                ddlAgenciaOrigen.DataSource = listAgencia;
                ddlAgenciaOrigen.DataValueField = "CODIGO_ALMACEN";
                ddlAgenciaOrigen.DataTextField = "NOMBRE";
                ddlAgenciaOrigen.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtFechaFin.Text.Trim().Length == 0 || txtFechaInicio.Text.Trim().Length == 0)
            {
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Debe Ingresar las fechas'); </script>"));
                return;
            }



            if (DateTime.Parse(txtFechaFin.Text) > DateTime.Now.Date )
            {
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('La fecha fin no puede ser mayor a la fecha atual'); </script>"));
                return;
            }

            if (DateTime.Parse(txtFechaFin.Text) < DateTime.Parse(txtFechaInicio.Text))
            {
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('La fecha fin no puede ser menor a la fecha de incio'); </script>"));
                return;
            }


            List<UPC.CruzDelSur.Negocio.Modelo.Carga.Carga> oListCarga = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.Carga>();
            UPC.CruzDelSur.Datos.Carga.Carga BL_Carga = new Datos.Carga.Carga();

            oListCarga = BL_Carga.f_Reporte(Int32.Parse(ddlAgenciaOrigen.SelectedValue),Int32.Parse(ddlTipoMovimiento.SelectedValue), DateTime.Parse(txtFechaInicio.Text), DateTime.Parse( txtFechaFin.Text));
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
            this.Controls.Add(new LiteralControl("<script language='JavaScript'>OpenModalDialog('VistaPreliminar.aspx?almacen=" + ddlAgenciaOrigen.SelectedValue + "&tipoMovimiento=" + ddlTipoMovimiento.SelectedValue + "&fechaincio=" + txtFechaInicio.Text + "&fechafin=" + txtFechaFin.Text + "','null','400','1000')</script>"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}