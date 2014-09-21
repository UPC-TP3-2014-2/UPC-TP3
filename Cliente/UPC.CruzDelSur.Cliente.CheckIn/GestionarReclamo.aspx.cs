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
        LlenarTipoSolicitud();
        LlenarArea();
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
    }

    private void LlenarTipoSolicitud()
    {
        IBL_Reclamo carga = new BL_Reclamo();
        List<BE_TipoSolicitud> listTipoSolicitud = carga.f_listaTipoSolicitud();

        dlTipoSolicitud.DataSource = listTipoSolicitud;
        dlTipoSolicitud.DataTextField = "Nombre";
        dlTipoSolicitud.DataValueField = "IdTipoSolicitud";
        dlTipoSolicitud.DataBind();
    }


    private void LlenarArea()
    {
        IBL_Reclamo carga = new BL_Reclamo();
        List<BE_Area> listArea = carga.f_listaArea();

        dlArea.DataSource = listArea;
        dlArea.DataTextField = "Nombre";
        dlArea.DataValueField = "IdArea";
        dlArea.DataBind();
    }

    private void RegistrarReclamo()
    {
        IBL_Reclamo carga = new BL_Reclamo();
        BE_Reclamo objReclamo = carga.f_registrarReclamo(txtNroBoleto.Text, Convert.ToInt32(dlTipoSolicitud.SelectedValue), Convert.ToInt32(dlArea.SelectedValue), txtMotivo.Text);

        //MessageBox.Show("The calculations are complete", "My Application",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk);
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        RegistrarReclamo();
    }
}