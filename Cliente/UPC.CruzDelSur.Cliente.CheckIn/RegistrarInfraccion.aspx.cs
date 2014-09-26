using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;

public partial class RegistrarInfraccion : System.Web.UI.Page
{

    public string NroBoleto = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
        NroBoleto = Request.QueryString["nroboleto"];
        lblCodBoleto.Text = NroBoleto.ToString();

        this.mypane1.Visible = false;
        this.mypane2.Visible = false;
        btnRegresar.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
               
        string dt1 = Request.Form[txtDetalleInfraccion.UniqueID];
        
        int resultado = 0;
        IBL_Boleto boleto = new BL_Boleto();
        IBL_Equipaje carga = new BL_Equipaje();
        
        

        if (dt1.Equals(""))
        {
            string message = "Ingrese el detalle de la infracción.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        else
        {
            //string ruta = "Videos/" + "Bus_" + codbus + "_" + dt2;

            // DateTime a= DateTime.Parse(dt1);
            //resultado = carga.f_RegistrarFilmacion(codbus, dt1, dt2, ruta,estado);
            //if (resultado > 0)
            //{
            //  btnGrabar.Enabled = false;

            resultado = carga.f_RegistrarInfraccion(NroBoleto, dt1);
            List<BE_Boleto> ListaBoleto = boleto.f_CancelarCheckIn(NroBoleto);

            this.mypane1.Visible = true;
            this.mypane2.Visible = true;
            lblMensaje.Text = "Registro Exitoso";

            lblMensaje0.Text = lblCodBoleto.Text;
            txtDetalleInfraccion.ReadOnly = true ;
            btnGrabar.Visible = false;
            btnCancelar.Visible= false;
            btnRegresar.Visible = true;
           
            //lblRuta.Text = ruta;
            //}


        }
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/VerificarEquipaje.aspx");
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/VerificarEquipaje.aspx");
    }
}