using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
public partial class GestionarFilmacion : System.Web.UI.Page
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
        BindData();
    }

    private void BindData()
    {



        IBL_Filmacion carga = new BL_Filmacion();
        string dt = Request.Form[txtDate.UniqueID];

        if (dt.Equals(""))
        {
            string message = "Ingrese una fecha de busqueda.";
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
            List<BE_Filmacion> ListaFilmacion = carga.f_ListadoFilmaciones(DateTime.Parse(dt));
            grvDetalle.DataSource = ListaFilmacion;
            grvDetalle.DataBind();
     
        }

        


        
    }

    protected void grvDetalle_RowCommand(Object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "cmdProgramar")
        {
        

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            string cod = Convert.ToString(grvDetalle.DataKeys[index].Value);
            string estado = Convert.ToString(grvDetalle.DataKeys[index].Value);
            string solFilmacion = Convert.ToString(grvDetalle.DataKeys[index].Value);
            string iniGrab = Convert.ToString(grvDetalle.DataKeys[index].Values[3].ToString());
            string finGrab = Convert.ToString(grvDetalle.DataKeys[index].Values[4].ToString());
            string rutaVideo = Convert.ToString(grvDetalle.DataKeys[index].Values[5].ToString());
            Response.Redirect("~/ProgramarFilmacion.aspx?ID=" + cod + "&codSalida=" + cod + "&estado=" + estado + "&solFilm=" + solFilmacion + "&iniGrab=" + iniGrab + "&finGrab=" + finGrab + "&rutaVideo=" + rutaVideo);

        }

        if (e.CommandName == "cmdModificar")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDetalle.Rows[index];
            ListItem item = new ListItem();
            string cod = Convert.ToString(grvDetalle.DataKeys[index].Values[0].ToString());
            string estado = Convert.ToString(grvDetalle.DataKeys[index].Values[1].ToString());
            string solFilmacion = Convert.ToString(grvDetalle.DataKeys[index].Values[2].ToString());
            string iniGrab = Convert.ToString(grvDetalle.DataKeys[index].Values[3].ToString());
            string finGrab = Convert.ToString(grvDetalle.DataKeys[index].Values[4].ToString());
            string rutaVideo = Convert.ToString(grvDetalle.DataKeys[index].Values[5].ToString());
            Response.Redirect("~/ProgramarFilmacion.aspx?ID=" + cod + "&codSalida=" + cod + "&estado=" + estado + "&solFilm=" + solFilmacion + "&iniGrab=" + iniGrab + "&finGrab=" + finGrab + "&rutaVideo=" + rutaVideo);

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
}