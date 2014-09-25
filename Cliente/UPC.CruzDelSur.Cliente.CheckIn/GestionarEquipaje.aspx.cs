using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
using System.ComponentModel;
public partial class GestionarEquipaje : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnImprimir.Visible =false;
       
        if (!Page.IsPostBack)
        {
            //btnImprimir.Visible = true;            
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        BindData();
        
    }

    private void BindData()
    {
        IBL_Equipaje carga = new BL_Equipaje();
        List<BE_Equipaje> ListaBoleto = carga.f_listarEquipajeBoleto(txtNroBoleto.Text, txtDNI.Text);
        grvDetalle.DataSource = ListaBoleto;
        grvDetalle.DataBind();
        btnImprimir.Visible = true;
        
    }

    protected void grvDetalle_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdConfirmar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            item.Text = Server.HtmlDecode(row.Cells[1].Text);

            IBL_Equipaje carga = new BL_Equipaje();
            List<BE_Equipaje> ListarEquipaje = carga.f_actualizarEstadoEquipaje(item.Text, 2);

            grvDetalle.DataSource = ListarEquipaje;
            grvDetalle.DataBind();
            btnImprimir.Visible = true;
        }

        if (e.CommandName == "cmdCancelar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            item.Text = Server.HtmlDecode(row.Cells[1].Text);

            IBL_Equipaje carga = new BL_Equipaje();
            List<BE_Equipaje> ListarEquipaje = carga.f_actualizarEstadoEquipaje(item.Text, 3);
            grvDetalle.DataSource = ListarEquipaje;
            grvDetalle.DataBind();
            btnImprimir.Visible = false;
        }

        if (e.CommandName == "cmdEditar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            string cod = Convert.ToString(grvDetalle.DataKeys[index].Value);
            string NroBoleto = Server.HtmlDecode(row.Cells[1].Text);
            string NroEquipaje = Server.HtmlDecode(row.Cells[2].Text);
            string NroBarras = Server.HtmlDecode(row.Cells[12].Text);
            string Tamano = Server.HtmlDecode(row.Cells[13].Text);
            string ancho =Tamano.Substring(0,2);
            string alto = Tamano.Substring(2, 2);            
            string peso = Server.HtmlDecode(row.Cells[5].Text);

            Response.Redirect("~/ModificarEquipaje.aspx?ID=" + cod + "&NroBoleto=" + NroBoleto + "&NroEquipaje=" + NroEquipaje + "&NroBarras=" + NroBarras + "&Tamano=" + Tamano + "&ancho=" + ancho + "&alto=" + alto + "&peso=" + peso);
        }

        if (e.CommandName == "cmdImprimir")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            item.Text = Server.HtmlDecode(row.Cells[1].Text);
            Response.Write("<script>window.open('ImprimirEquipaje.aspx?nroboleto=" + item.Text + "','_blank')</script>");

            
        }

    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Inicio.aspx");
    }

       protected void btnRegistrarEquipaje_Click(object sender, EventArgs e)
    {
        
        btnImprimir.Visible = true;
        
    }

}