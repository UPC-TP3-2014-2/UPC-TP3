using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
public partial class ModificarEquipaje : System.Web.UI.Page
{
    
    

    public int CodBoleto = 0;
    public string NumBoleto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //btnImprimir.Visible = true;  
            string NroBoleto = Convert.ToString(Request.QueryString["NroBoleto"]);
            string NroEquipaje = Convert.ToString(Request.QueryString["NroEquipaje"]);
            string NroBarras = Convert.ToString(Request.QueryString["NroBarras"]);
            string ancho = Convert.ToString(Request.QueryString["ancho"]);
            string alto = Convert.ToString(Request.QueryString["alto"]);
            string largo = Convert.ToString(Request.QueryString["largo"]);
            string peso = Convert.ToString(Request.QueryString["peso"]);


            txtNroBoleto1.Text = NroBoleto;
            txtNroEquipaje.Text = NroEquipaje;
            txtCodigoBarra.Text = NroBarras;
            txtAncho.Text = ancho;
            txtAlto.Text = alto;
            txtPeso.Text = peso;
            txtLargo.Text = largo;
            txtTipoEquipaje.SelectedValue = "1";
            DropDownList1.SelectedValue = "1";
                       
        }
    }


    protected void btnActualizarRegistroEquipaje_Click(object sender, EventArgs e)
    {

        IBL_Tiket tiket = new BL_Tiket();
        BE_Tiket objTiket = new BE_Tiket();
        //objTiket.CodBoleto = ID;
        List<BE_Tiket> ActEquipaje = new List<BE_Tiket>();
        objTiket.CodBarra = txtCodigoBarra.Text;
        objTiket.Tamano = txtAncho.Text.Trim() + "X" + txtAlto.Text.Trim() + "X" + txtLargo.Text.Trim();
        objTiket.Peso = txtPeso.Text.Trim();
        objTiket.TipoEtiqueta = txtTipoEquipaje.SelectedItem.Value;
        objTiket.ubicacion = DropDownList1.SelectedItem.Value;
        objTiket.Numero = txtNroEquipaje.Text.Trim();
        ActEquipaje.Add(objTiket);
        int resultado = tiket.f_ActualizarTicket(ActEquipaje);
        if (resultado > 0)
        {
            Session["listTiket"] = null;

            //lblResultado.Text = "Registro Exitoso";
            Response.Redirect("~/GestionarEquipaje.aspx");

            string message = "Registro Exitoso.";
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
}