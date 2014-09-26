using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;

public partial class ProgramarFilmacion : System.Web.UI.Page
{

    public int CodSalBus = 0;
    public string estado = "";
    public string solfilm = "";
    public string iniGrab = "";
    public string finGrab = "";
    public string rutavideo = "";
    public string horaSalida = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {

            for (int i = 1; i < 60; i++)
            {
                if(i<10)

                DropDownList1.Items.Add(new ListItem("0"+i.ToString(), "0"+i.ToString()));
                else
                    DropDownList1.Items.Add(new ListItem(  i.ToString(), i.ToString()));
            }
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)

                    DropDownList2.Items.Add(new ListItem("0" + i.ToString(), "0"+i.ToString()));
                else
                    DropDownList2.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }


                CodSalBus = Convert.ToInt32(Request.QueryString["codSalida"]);
                estado = Convert.ToString(Request.QueryString["estado"]);
                solfilm = Convert.ToString(Request.QueryString["solFilm"]);
                iniGrab = Convert.ToString(Request.QueryString["iniGrab"]);
                finGrab = Convert.ToString(Request.QueryString["finGrab"]);
                rutavideo = Convert.ToString(Request.QueryString["rutaVideo"]);
                ViewState["solFilm"] = Convert.ToString(Request.QueryString["solFilm"]);
                ViewState["estado"] = estado;
                ViewState["horaSalida"]  = Convert.ToString(Request.QueryString["horaSalida"]); 

                if (estado.Equals("P") || estado.Equals("A"))
                {

                    string hora1 = iniGrab.Substring(3,2);
                    string hora2 = finGrab.Substring(3,2);

                    DropDownList1.SelectedValue = hora1;
                    DropDownList2.SelectedValue = hora2;


                    lblCodBus.Text = CodSalBus.ToString();
                    lblRuta.Text = rutavideo;
                    btnActualizar.Visible = true;
                    btnGrabar.Visible = false;
                }
                else if(estado.Equals(""))
                {
                    lblCodBus.Text = CodSalBus.ToString();
                    btnGrabar.Enabled = true;
                    btnActualizar.Visible = false;
                }
               
          
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string codbus = lblCodBus.Text;

        string estado = "P";
        int resultado = 0;
        IBL_Filmacion carga = new BL_Filmacion();



        if (DropDownList1.SelectedValue.Equals("0"))
        {
            string message = "Ingrese una Hora Inicio de Grabacion.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else if (DropDownList2.SelectedValue.Equals("0"))
        {
            string message = "Ingrese un Hora fin de Grabacion.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else if (DropDownList1.SelectedValue.Equals(DropDownList2.SelectedValue))
        {
            string message = "La Hora de inicio y Fin no puede ser la misma.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        
        }
        else if ( int.Parse(DropDownList1.SelectedValue)>int.Parse(DropDownList2.SelectedValue))
        {
            string message = "La hora Inicio no puede ser mayor a la de Fin de Grabación.";
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
            string ruta = "Videos/" + "Bus_" + codbus + "_" + DropDownList1.SelectedValue;
            string hora1 = ViewState["horaSalida"].ToString().Substring(0, 2) + ":" + DropDownList1.SelectedItem.Text + ":00";

            string hora2 = ViewState["horaSalida"].ToString().Substring(0, 2) + ":" + DropDownList2.SelectedItem.Text + ":00";
           // DateTime a= DateTime.Parse(dt1);
            resultado = carga.f_RegistrarFilmacion(codbus, hora1, hora2, ruta, estado);
            if (resultado > 0)
            {
                btnGrabar.Enabled = false;
                lblMensaje.Text = "Registro Exitoso";
                lblRuta.Text = ruta;
            }

        }
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/GestionarFilmacion.aspx");
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
       
        string codbus = lblCodBus.Text;
      
        string estado = Convert.ToString(ViewState["estado"]);
        IBL_Filmacion carga = new BL_Filmacion();
        string film = Convert.ToString(ViewState["solFilm"]);
       
        int resultado = 0;


        if (DropDownList1.SelectedValue.Equals("0"))
        {
            string message = "Ingrese una Hora Inicio de Grabacion.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else if (DropDownList2.SelectedValue.Equals("0"))
        {
            string message = "Ingrese un Hora fin de Grabacion.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else if ( DropDownList1.SelectedValue.Equals(DropDownList2.SelectedValue))
        {
            string message = "La Hora de inicio y Fin no puede ser la misma.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }
        else if (int.Parse(DropDownList1.SelectedValue) > int.Parse(DropDownList2.SelectedValue))
        {
            string message = "La hora Inicio no puede ser mayor a la de Fin de Grabación.";
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
            if (estado.Equals("A"))
            {
                estado = "S";
            }

            string ruta = "Videos/" + "Bus_" + codbus + "_" + DropDownList1.SelectedValue;

            string hora1 = ViewState["horaSalida"].ToString().Substring(0, 2) + ":" + DropDownList1.SelectedItem.Text + ":00";

            string hora2 = ViewState["horaSalida"].ToString().Substring(0, 2) + ":" + DropDownList2.SelectedItem.Text + ":00";

            resultado = carga.f_ActualizarFilmacion(film, hora1, hora2, ruta, estado);

            if (resultado > 0)
            {

                lblRuta.Text = ruta;
                btnActualizar.Enabled = false;
                lblMensaje.Text = "Actualizacion Exitosa";
            }
        }

    }
}