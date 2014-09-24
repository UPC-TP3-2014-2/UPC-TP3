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
        //btnRegistrarEquipaje.Visible = false;
        //btnGenerarTickets.Visible = false;

        
        if (!Page.IsPostBack)
        {
            btnImprimir.Visible = true;            
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        BindData();
        txtNroBoleto1.Text = txtNroBoleto.Text;
        txtPeso.Text = "60";
      if (txtDNI.Text == "58524558")
        {
            txtNroBoleto1.Text = "001-000001";
          
        }

      if (txtNroBoleto.Text == "001-000001")
      {
          txtNroBoleto1.Text = "001-000001";

      }
    }

    private void BindData()
    {
        IBL_Equipaje carga = new BL_Equipaje();
        List<BE_Equipaje> ListaBoleto = carga.f_listarEquipajeBoleto(txtNroBoleto.Text, txtDNI.Text);
        grvDetalle.DataSource = ListaBoleto;
        grvDetalle.DataBind();
        btnImprimir.Visible = true;
        //btnRegistrarEquipaje.Visible = true;
        //btnGenerarTickets.Visible = true;
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
            item.Text = Server.HtmlDecode(row.Cells[1].Text);
            Response.Redirect("~/ModificarEquipaje.aspx?ID=" + cod + "&nroboleto=" + item.Text);
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

    protected void Button6_Click(object sender, EventArgs e)
    {
        txtPeso.Text = "";
       
        txtTipoEquipaje.Text = "";
        txtUbicacion.Text = "";
        
    }
    protected void btnRegistrarEquipaje_Click(object sender, EventArgs e)
    {
        
        
        txtNroBoleto1.Text = txtNroBoleto.Text;
        //btnRegistrarEquipaje.Visible = true;
        //btnGenerarTickets.Visible = true;
        btnImprimir.Visible = true;
        
    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        btnImprimir.Visible = true;
        //btnActualizarRegistroEquipaje.Enabled = false;
        
        
        
    }
    protected void btnActualizarRegistroEquipaje_Click(object sender, EventArgs e)
    {
        btnImprimir.Visible = true;
        //btnConfirmarRegistroEquipaje.Enabled = true;
    }



   
}