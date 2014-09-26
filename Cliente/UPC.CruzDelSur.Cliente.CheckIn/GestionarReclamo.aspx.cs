using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Text;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;

public partial class Reclamo_GestionarReclamo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LlenarTipoSolicitud();
            LlenarArea();
            lblInfo.Text = "";

            lblInfo.Text = "";
            lblTipoSolicitud.Visible = false;
            lblArea.Visible = false;
            lblMotivo.Visible = false;
            dlTipoSolicitud.Visible = false;
            dlArea.Visible = false;
            txtMotivo.Visible = false;
            btnRegistrar.Visible = false;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        BindData();
    }

    private void BindData()
    {
        IBL_Reclamo carga = new BL_Reclamo();
        List<BE_Reclamo> ListaBoleto = carga.f_buscaBoletoPasajero(txtNroBoleto.Text, txtDNI.Text);
        gv1.DataSource = ListaBoleto;
        gv1.DataBind();
        //btnImprimir.Visible = true;

        int i = gv1.Rows.Count;
        if (i.Equals(0))
        {
            lblInfo.Text = "No existe el numero de boleto ingresado.";
            //lblInfo.ForeColor = ConsoleColor.Red;
        }
        else
        {
            lblInfo.Text = "";
            lblTipoSolicitud.Visible = true;
            lblArea.Visible = true;
            lblMotivo.Visible = true;
            dlTipoSolicitud.Visible = true;
            dlArea.Visible = true;
            txtMotivo.Visible = true;
            btnRegistrar.Visible = true;
            gv1.Visible = true;
        }
    }

    private void LlenarTipoSolicitud()
    {
        IBL_Reclamo carga = new BL_Reclamo();
        List<BE_TipoSolicitud> listTipoSolicitud = carga.f_listaTipoSolicitud();

        dlTipoSolicitud.DataSource = listTipoSolicitud;
        dlTipoSolicitud.DataTextField = "Nombre";
        dlTipoSolicitud.DataValueField = "IdTipoSolicitud";
        dlTipoSolicitud.DataBind();
        //dlTipoSolicitud.SelectedItem.Text = "";
    }


    private void LlenarArea()
    {
        IBL_Reclamo carga = new BL_Reclamo();
        List<BE_Area> listArea = carga.f_listaArea();

        dlArea.DataSource = listArea;
        dlArea.DataTextField = "Nombre";
        dlArea.DataValueField = "IdArea";
        dlArea.DataBind();
        //dlArea.SelectedItem.Text = "";
    }

    private void RegistrarReclamo()
    {
        IBL_Reclamo carga = new BL_Reclamo();
        BE_Reclamo objReclamo = carga.f_registrarReclamo(txtNroBoleto.Text, Convert.ToInt32(dlTipoSolicitud.SelectedValue), Convert.ToInt32(dlArea.SelectedValue), txtMotivo.Text);

        lblInfo.Text = "Se ha registrado correctamente su reclamo, en breve se estará enviando a su correo personal la solicitud del reclamo. Gracias por confiar en Cruz del Sur";

        lblTipoSolicitud.Visible = false;
        lblArea.Visible = false;
        lblMotivo.Visible = false;
        dlTipoSolicitud.Visible = false;
        dlArea.Visible = false;
        txtMotivo.Visible = false;
        btnRegistrar.Visible = false;
        gv1.Visible = false;
        txtNroBoleto.Text = "";
        txtDNI.Text = "";
        txtMotivo.Text = "";
        LlenarTipoSolicitud();
        LlenarArea();

        //string message = "Se ha registrado correctamente su reclamo, en breve se estara enviado a su correo personal la solicitud del reclamo.";
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //sb.Append("<script type = 'text/javascript'>");
        //sb.Append("window.onload=function(){");
        //sb.Append("alert('");
        //sb.Append(message);
        //sb.Append("')};");
        //sb.Append("</script>");
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {

        int i = gv1.Rows.Count;
        if (i.Equals(0))
        {
            string message = "No se ha consultado el numero de boleto.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            return;
        }


        string nombreSolicitud = dlTipoSolicitud.SelectedItem.Text;
        if (nombreSolicitud.Equals("Seleccione"))
        {
            string message = "Seleccione el tipo de solicitud.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            return;
        }

        string nombreArea = dlArea.SelectedItem.Text;
        if (nombreArea.Equals("Seleccione"))
        {
            string message = "Seleccione el area.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            return;
        }

        string motivo = txtMotivo.Text;
        if (motivo.Equals(""))
        {
            string message = "Ingrese el motivo.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            return;
        }

        RegistrarReclamo();

        //Response.Redirect("~/Default.aspx");

    }
    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Inicio.aspx");
    }
}