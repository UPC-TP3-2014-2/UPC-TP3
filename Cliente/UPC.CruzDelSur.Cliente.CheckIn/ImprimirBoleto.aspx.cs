using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn;
using UPC.CruzDelSur.Datos.CheckIn.Interface;

public partial class ImprimirBoleto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string NumBoleto = Convert.ToString(Request.QueryString["nroboleto"]);
            IBL_Boleto carga = new BL_Boleto();
            List<BE_Boleto> ListaBoleto = carga.f_ListadoBoleto(NumBoleto, "");

            lblNroBol.Text = ListaBoleto[0].NroBoleto;
            lblPasajero.Text = ListaBoleto[0].Pasajero;
            lblOrigen.Text = ListaBoleto[0].Origen;
            lblDestino.Text = ListaBoleto[0].Destino;
            lblFechaSalida.Text = ListaBoleto[0].FechaSalida;
            lblHoraSalida.Text = ListaBoleto[0].HoraSalida;

            lblChofer.Text = ListaBoleto[0].Chofer;
            lblPlaza.Text = ListaBoleto[0].Placa;

            grvDetalle.DataSource = ListaBoleto;
            grvDetalle.DataBind();
        }
    }
}