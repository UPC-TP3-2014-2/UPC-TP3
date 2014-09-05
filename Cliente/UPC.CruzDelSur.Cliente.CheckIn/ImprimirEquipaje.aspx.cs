using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
public partial class ImprimirEquipaje : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string NumBoleto = Convert.ToString(Request.QueryString["nroboleto"]);
            IBL_Equipaje carga = new BL_Equipaje();
            List<BE_Equipaje> ListaBoleto = carga.f_listarEquipajeBoleto(NumBoleto, "");

            lblNroBol.Text = ListaBoleto[0].NroBoleto;
            lblPasajero.Text = ListaBoleto[0].Pasajero;
            lblOrigen.Text = ListaBoleto[0].Origen;
            lblDestino.Text = ListaBoleto[0].Destino;
            lblFechaSalida.Text = ListaBoleto[0].FechaSalida;
            lblHoraSalida.Text = ListaBoleto[0].HoraSalida;

            grvDetalle.DataSource = ListaBoleto;
            grvDetalle.DataBind();
        }
    }
}