using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnImprimir.Visible = false;
        if (!Page.IsPostBack)
        {
            //btnImprimir.Visible = true;            
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtNroBoleto.Text.Trim().Equals("")  || txtDNI.Text.Trim().Equals("") )
        {
           if( txtNroBoleto.Text.Trim().Equals("") )
           {

            string message = "Ingrese un número de Boleto.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
           }



           else if (txtNroBoleto.Text.IndexOf('-') != 3)
             {
            string message = "Ingrese un formato de boleto correcto.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
             }
            

          
        }
       
        else 
            BindData();
       
        }

    private void BindData()
    {
        //IBL_Boleto carga = new BL_Boleto();
        IBL_Boleto carga = new BL_Boleto();
        List<BE_Boleto> ListaBoleto = carga.f_ListadoBoleto(txtNroBoleto.Text, txtDNI.Text);
        grvDetalle.DataSource = ListaBoleto;
        grvDetalle.DataBind();
        btnImprimir.Visible = true;
    }

    protected void grvDetalle_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdCheckIn")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            item.Text = Server.HtmlDecode(row.Cells[1].Text);

            IBL_Boleto carga = new BL_Boleto();
            List<BE_Boleto> ListaBoleto = carga.f_CheckIn(item.Text);
            grvDetalle.DataSource = ListaBoleto;
            grvDetalle.DataBind();
            btnImprimir.Visible = true;
        }

        if (e.CommandName == "cmdCancelar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            item.Text = Server.HtmlDecode(row.Cells[1].Text);

            IBL_Boleto carga = new BL_Boleto();
            List<BE_Boleto> ListaBoleto = carga.f_CancelarCheckIn(item.Text);
            grvDetalle.DataSource = ListaBoleto;
            grvDetalle.DataBind();
            btnImprimir.Visible = false;
        }

        if (e.CommandName == "cmdEditar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            item.Text = Server.HtmlDecode(row.Cells[1].Text); //Boleto
            ListItem itemVehiculo = new ListItem();
            itemVehiculo.Text = Server.HtmlDecode(row.Cells[4].Text); //Vehiculo
            ListItem itemLiberarAsiento = new ListItem();
            itemLiberarAsiento.Text = Server.HtmlDecode(row.Cells[11].Text); //Asiento actual
            Response.Redirect("~/GestionarAsiento.aspx?ID=" + itemVehiculo.Text + "&nroboleta=" + item.Text + "&nroAsientoL=" + itemLiberarAsiento.Text);
        }

        if (e.CommandName == "cmdImprimir")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            item.Text = Server.HtmlDecode(row.Cells[1].Text);
            Response.Write("<script>window.open('ImprimirBoleto.aspx?nroboleto=" + item.Text + "','_blank')</script>");
        }

    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Inicio.aspx");
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {

    }
}