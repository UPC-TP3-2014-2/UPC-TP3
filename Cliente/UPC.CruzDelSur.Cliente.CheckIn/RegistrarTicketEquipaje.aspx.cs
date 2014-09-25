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


    protected void Page_Load(object sender, EventArgs e)
    {
        if (listaEquipaje == null)

            listaEquipaje = new List<BE_Tiket>();
    }
   
    protected void btnActualizarRegistroEquipaje_Click(object sender, EventArgs e)
    {

    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        BE_Tiket objTiket = new BE_Tiket();
        objTiket.CodBoleto = int.Parse(txtNroBoleto1.Text);
        objTiket.CodBarra = txtCodigoBarra.Text;
        objTiket.Tamano = txtTamano.Text;
        objTiket.Peso = txtPeso.Text;
        objTiket.TipoEtiqueta = txtTipoEquipaje.SelectedItem.Value;
        objTiket.ubicacion = DropDownList1.SelectedItem.Value;
        objTiket.Numero=objTiket.CodBoleto+"-"+objTiket.CodBarra;
        listaEquipaje.Add(objTiket);

        GridView1.DataSource = listaEquipaje;
        GridView1.DataBind();


    }


    protected void btnConfirmarRegistroEquipaje_Click(object sender, EventArgs e)
    {
        IBL_Tiket tiket = new BL_Tiket();
        int resultado = tiket.f_RegistrarFilmacion(listaEquipaje);
        if (resultado > 0)
            lblResultado.Text = "Registro Exitoso";
    }
}