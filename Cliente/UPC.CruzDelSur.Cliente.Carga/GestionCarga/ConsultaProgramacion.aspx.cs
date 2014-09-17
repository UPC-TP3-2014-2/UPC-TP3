using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;

using UPC.CruzDelSur.Datos.Carga;
using UPC.CruzDelSur.Negocio.Modelo.Carga;

namespace CRUZDELSUR.UI.Web.GestionCarga
{
    public partial class ConsultaProgramacion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarRutas();
            }
        }
        protected void gvProgramacionRuta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Session["idProgramacionRuta"] = e.CommandArgument;
                this.Controls.Add(new LiteralControl("<script language='JavaScript'>alert('Seleccionado'); CloseFormOK();</script>"));
            }
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarRutas();
        }
        void CargarRutas()
        {
            //Invocamos al controlador de flota
            UPC.CruzDelSur.Datos.Carga.Programacion_Ruta oBL_Programacion_Ruta = new UPC.CruzDelSur.Datos.Carga.Programacion_Ruta();
            gvProgramacionRuta.DataSource = oBL_Programacion_Ruta.f_Programacion_Ruta(Int32.Parse(ddlAgencias.SelectedValue));
            gvProgramacionRuta.DataBind();
        }
    }
}