using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using CRUZDELSUR.Aplicacion.Servicios.ControlServicios;
//using CRUZDELSUR.Aplicacion.DTO.ControlServicios;
//using CRUZDELSUR.Infraestructura.Datos.Repositorios.ControlServicios;
//using CRUZDELSUR.Dominio.Entidades.ControlServicios;

namespace CRUZDELSUR.UI.Web.Flota
{
    public partial class AdministrarBitacoraViaje1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<ListadoprincipalDTO> Lst = new List<ListadoprincipalDTO>();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
        //    BuscarBitacorasDTO _BuscarBitacorasDTO = new BuscarBitacorasDTO();

        //    _BuscarBitacorasDTO.FechaInicial = Convert.ToDateTime(txtFechaInicio.Text);
        //    _BuscarBitacorasDTO.FechaFinal = Convert.ToDateTime(txtFechaFin.Text);

        //    IBitacoraRepositorio _IBitacoraRepositorio = new BitacoraRepositorio();
        //    IBitacoraAppService _BitacoraAppService = new BitacoraAppService(_IBitacoraRepositorio);

        //    GridView1.DataSource = _BitacoraAppService.ListarBitacorasViaje(_BuscarBitacorasDTO);
        //    GridView1.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroBitacoraViaje.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {

        }

        public void cargarBitacora()
        {


        }





    }
}