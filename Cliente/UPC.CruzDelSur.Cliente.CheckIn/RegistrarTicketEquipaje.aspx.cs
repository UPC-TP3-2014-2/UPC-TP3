using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;


public partial class RegistrarTicketEquipaje : System.Web.UI.Page
{

    List<BE_Tiket> listaEquipaje
    {
        get { return (List<BE_Tiket>)Session["listTiket"]; }
        set { Session["listTiket"] = value; }
    }


    public int ID = 0;
    public string nroboleto = "";
    


    protected void Page_Load(object sender, EventArgs e)
    {

       
        nroboleto = Convert.ToString(Request.QueryString["nroboleto"]);
        txtNroBoleto1.Text = nroboleto;
        
        if (listaEquipaje == null)

            listaEquipaje = new List<BE_Tiket>();
    }
   
    protected void btnActualizarRegistroEquipaje_Click(object sender, EventArgs e)
    {

    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        ID = Convert.ToInt32(Request.QueryString["ID"]);

       

         if ( txtCodigoBarra.Text == String.Empty)
         {

            string message = "El código de barra es obligatorio";
             System.Text.StringBuilder sb = new System.Text.StringBuilder();
             sb.Append("<script type = 'text/javascript'>");
             sb.Append("window.onload=function(){");
             sb.Append("alert('");
             sb.Append(message);
             sb.Append("')};");
             sb.Append("</script>");
             ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
         }
         else if (txtAncho.Text == String.Empty)
         {

             string message = "El ancho del equipaje es obligatorio";
             System.Text.StringBuilder sb = new System.Text.StringBuilder();
             sb.Append("<script type = 'text/javascript'>");
             sb.Append("window.onload=function(){");
             sb.Append("alert('");
             sb.Append(message);
             sb.Append("')};");
             sb.Append("</script>");
             ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

         }
         else if (txtAlto.Text == String.Empty)
         {

             string message = "El alto del equipaje es obligatorio";
             System.Text.StringBuilder sb = new System.Text.StringBuilder();
             sb.Append("<script type = 'text/javascript'>");
             sb.Append("window.onload=function(){");
             sb.Append("alert('");
             sb.Append(message);
             sb.Append("')};");
             sb.Append("</script>");
             ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

         }

         else if (txtPeso.Text == String.Empty)
         {

             string message = "El peso del equipaje es obligatorio";
             System.Text.StringBuilder sb = new System.Text.StringBuilder();
             sb.Append("<script type = 'text/javascript'>");
             sb.Append("window.onload=function(){");
             sb.Append("alert('");
             sb.Append(message);
             sb.Append("')};");
             sb.Append("</script>");
             ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

         }

         else if ( txtTipoEquipaje.SelectedValue == "0")
         {

             string message = "El tipo de equipaje es obligatorio";
             System.Text.StringBuilder sb = new System.Text.StringBuilder();
             sb.Append("<script type = 'text/javascript'>");
             sb.Append("window.onload=function(){");
             sb.Append("alert('");
             sb.Append(message);
             sb.Append("')};");
             sb.Append("</script>");
             ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

         }

         else if (DropDownList1.SelectedValue == "0")
         {

             string message = "La ubicación es obligatoria";
             System.Text.StringBuilder sb = new System.Text.StringBuilder();
             sb.Append("<script type = 'text/javascript'>");
             sb.Append("window.onload=function(){");
             sb.Append("alert('");
             sb.Append(message);
             sb.Append("')};");
             sb.Append("</script>");
             ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

         }

         else {


             int Ancho = Convert.ToInt32(txtAncho.Text);
             int Alto = Convert.ToInt32(txtAlto.Text);



             if (Ancho > 30 || Alto > 80)
             {


                 string message = "El tamaño permitido de las maletas ha sido superado, es 80X30. El equipaje se trasladará por cargo.";
                 System.Text.StringBuilder sb = new System.Text.StringBuilder();
                 sb.Append("<script type = 'text/javascript'>");
                 sb.Append("window.onload=function(){");
                 sb.Append("alert('");
                 sb.Append(message);
                 sb.Append("')};");
                 sb.Append("</script>");
                 ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());


             }



        BE_Tiket objTiket = new BE_Tiket();
        objTiket.CodBoleto = ID;
        objTiket.CodBarra = txtCodigoBarra.Text;
        objTiket.Tamano = txtAncho.Text + "X" + txtAlto.Text;
        objTiket.Peso = txtPeso.Text;
        objTiket.TipoEtiqueta = txtTipoEquipaje.SelectedItem.Text;
        objTiket.ubicacion = DropDownList1.SelectedItem.Text;
        objTiket.Numero=objTiket.CodBoleto+"-"+objTiket.CodBarra;
        objTiket.codigoEtiqueta = int.Parse(txtTipoEquipaje.SelectedValue);
        listaEquipaje.Add(objTiket);

        GridView1.DataSource = listaEquipaje;
        GridView1.DataBind();
        limpiarTexto();
             
         
         }

    }

        protected void btnConfirmarRegistroEquipaje_Click(object sender, EventArgs e)
    {
        IBL_Tiket tiket = new BL_Tiket();
        int resultado = tiket.f_RegistrarTicket(listaEquipaje);
        if (resultado > 0)
        {
            Session["listTiket"] = null; 
            
            //lblResultado.Text = "Registro Exitoso";
            Response.Redirect("~/VerificarEquipaje.aspx");

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

    public void limpiarTexto(){
        
        
        txtCodigoBarra.Text = null;
        txtAncho.Text = null;
        txtAlto.Text = null;
        txtPeso.Text = null;
        txtTipoEquipaje.SelectedValue = "0";
        DropDownList1.SelectedValue = "0";
       

    }
}