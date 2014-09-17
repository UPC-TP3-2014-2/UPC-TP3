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

    protected void Page_Load(object sender, EventArgs e)
    {
        txtIniGrab.Text = Request.Form[txtIniGrab.UniqueID];
        txtFinGrab.Text = Request.Form[txtFinGrab.UniqueID];
        if (!Page.IsPostBack)
        {
                CodSalBus = Convert.ToInt32(Request.QueryString["codSalida"]);
                estado = Convert.ToString(Request.QueryString["estado"]);
                solfilm = Convert.ToString(Request.QueryString["solFilm"]);
                iniGrab = Convert.ToString(Request.QueryString["iniGrab"]);
                finGrab = Convert.ToString(Request.QueryString["finGrab"]);
                rutavideo = Convert.ToString(Request.QueryString["rutaVideo"]);
                ViewState["solFilm"] = solfilm = Convert.ToString(Request.QueryString["solFilm"]);

                if (estado.Equals("P"))
                {
                    lblCodBus.Text = CodSalBus.ToString();
                    txtIniGrab.Text = iniGrab;
                    txtFinGrab.Text = finGrab;
                    lblRuta.Text = rutavideo;
                    btnActualizar.Visible = true;
                    btnGrabar.Visible = false;
                }
                else
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
        string dt1 = Request.Form[txtIniGrab.UniqueID];
        string dt2 = Request.Form[txtFinGrab.UniqueID];
      
        //int nHoraInicial = Convert.ToInt32( .ToString("HHmm"));
        
        string estado = "P";
        int resultado = 0;
        IBL_Filmacion carga = new BL_Filmacion();



        if (dt1.Equals(""))
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
        else if (dt2.Equals(""))
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
        else if (dt1.Equals(dt2))
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
        else if (DateTime.Parse(dt1) > DateTime.Parse(dt2))
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
            string ruta = "Videos/" + "Bus_" + codbus + "_" + dt2;
            
           // DateTime a= DateTime.Parse(dt1);
            resultado = carga.f_RegistrarFilmacion(codbus, dt1, dt2, ruta, estado);
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
        /*string codbus = lblCodBus.Text;
        string dt1 = Request.Form[txtIniGrab.UniqueID];
        string dt2 = Request.Form[txtFinGrab.UniqueID];
        string ruta = "Videos/" + "Bus_" + codbus + "_" + DateTime.Now.ToString();
        string estado = "P";
        lblRuta.Text = ruta;*/
        string codbus = lblCodBus.Text;
        string dt1 = Request.Form[txtIniGrab.UniqueID];
        string dt2 = Request.Form[txtFinGrab.UniqueID];
        IBL_Filmacion carga = new BL_Filmacion();
        string film = Convert.ToString(ViewState["solFilm"]);
       
        int resultado = 0;


        if (dt1.Equals(""))
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
        else if (dt2.Equals(""))
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
        else if (dt1.Equals(dt2))
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
        else if (DateTime.Parse(dt1) > DateTime.Parse(dt2))
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


            string ruta = "Videos/" + "Bus_" + codbus + "_" + dt2;


            resultado = carga.f_ActualizarFilmacion(film, dt1, dt2, ruta);

            if (resultado > 0)
            {

                lblRuta.Text = ruta;
                btnActualizar.Enabled = false;
                lblMensaje.Text = "Actualizacion Exitosa";
            }
        }

    }
}