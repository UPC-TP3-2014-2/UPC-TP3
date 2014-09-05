using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUZDELSUR.Entities;
using System.Text;
using System.Data;
using C.Data.Global;
using CRUZDELSUR.Controller;

namespace CRUZDELSUR.UI.Web.Flota
{
    public partial class RegistroBitacoraViaje : ServletFlota
    {
        ServletFlota _servletFlota = new ServletFlota();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    //obtenerListaTipoIncidencia();
            //    //deshabilitarFormulario(false);

            //    //cargarTipoIncidencia();
            //}

            //PruebaInsercion();
        }

        //private void PruebaInsercion()
        //{
        //    MC_BitacoraDTO dtoBita = new MC_BitacoraDTO()
        //    {
        //        Fecha = new DateTime(2015, 7, 25),
        //        HoraLlegada = new DateTime(2015, 7, 25),
        //        HoraPartida = new DateTime(2015, 7, 25),
        //        FechaRegistra = new DateTime(2015, 7, 25),
        //        FechaModifica = new DateTime(2015, 7, 25),
        //        Idprogramacion = 1
        //    };
        //    List<MC_DetalleBitacoraDTO> lstItems = new List<MC_DetalleBitacoraDTO>();
        //    MC_DetalleBitacoraDTO item1 = new MC_DetalleBitacoraDTO();
        //    item1.Descripcion = "Mala atención";
        //    item1.IdTipoIncidencia = 1;

        //    MC_DetalleBitacoraDTO item2 = new MC_DetalleBitacoraDTO();
        //    item1.Descripcion = "Se me perdio una maleta";
        //    item1.IdTipoIncidencia = 2;

        //    lstItems.Add(item2);
        //    dtoBita.Items = lstItems;

        //    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "Mala atención", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia=1, Descripcion="" } });
        //    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "Buena atención", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia = 2 ,Descripcion=""} });
        //    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "se malogro a medio camino", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia = 1, Descripcion = "" } });
        //    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "objetos perdidos", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia = 2, Descripcion = "" } });
        //    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "Se malogro la llanta", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia = 1, Descripcion = "" } });

        //    /*Inyección de dependencias*/
        //    IMC_BitacoraRepositorio repositorioBita = new MC_BitacoraRepositorio();
        //    IMC_BitacoraAppService serviceBita = new MC_BitacoraAppService(repositorioBita);
        //    serviceBita = new MC_BitacoraAppService(repositorioBita);
        //    serviceBita.AgregarBitacoraViaje(dtoBita); 
        //}

       protected void btnBuscar_Click(object sender, EventArgs e)
        {

           //CREAMOS LOS PARAMETROS
           List<ParametroGenerico> _ArrayParam = new List<ParametroGenerico>();
           ParametroGenerico _BEParametro = new ParametroGenerico();
           _BEParametro.nombre = "Placa";
           _BEParametro.valor = txtVehiculo.Text.Trim().ToString();
           _ArrayParam.Add(_BEParametro);

           //Invocamos al controlador de flota
           _servletFlota.cargarRutasXVehiculo(ddlRuta,_ArrayParam,ddltipoIncidencia);

       }

        protected void btnAgregarIncidencia_Click(object sender, EventArgs e)
        {
//            List<BitacoraDetalleRegistrar> lDetalleBitacora;

//            if (Session["lDetalleBitacora"] == null)
//            {
//                lDetalleBitacora = new List<BitacoraDetalleRegistrar>();
//                Session["lDetalleBitacora"] = lDetalleBitacora;
//            }
//            else {
//                lDetalleBitacora = (List<BitacoraDetalleRegistrar>) Session["lDetalleBitacora"];
//            }

//            BitacoraDetalleRegistrar _BitacoraDetalleRegistrar = new BitacoraDetalleRegistrar();
//            //LISTADO
//            _BitacoraDetalleRegistrar.fechaPartida = txtFecha.Text;
//            _BitacoraDetalleRegistrar.vehiculo = txtVehiculo.Text;
//            _BitacoraDetalleRegistrar.tipoIncidencia = ddltipoIncidencia.SelectedItem.Text;
//            _BitacoraDetalleRegistrar.ruta = ddlRuta.SelectedItem.Text;

//            //REGISTRO
//            _BitacoraDetalleRegistrar.IdTipoIncidencia = Convert.ToInt32(ddltipoIncidencia.SelectedValue.ToString());
//            _BitacoraDetalleRegistrar.Descripcion = txtDescripcion.Text;

//            lDetalleBitacora.Add(_BitacoraDetalleRegistrar);

//            Session["lDetalleBitacora"] = lDetalleBitacora;


//            /***************************************************************************
//                    CARGAMOS LA GRILLA CON EL DETALLE
//            /****************************************************************************/

//            GridView1.DataSource = lDetalleBitacora;
//            GridView1.DataBind();
        }

//        public void registrarDetalleBitacora(){
//            BitacoraDetalleRegistrar _BitacoraDetalleRegistrar = new BitacoraDetalleRegistrar();
//            _BitacoraDetalleRegistrar.Descripcion = txtDescripcion.Text;
//            _BitacoraDetalleRegistrar.IdTipoIncidencia = Convert.ToInt32(ddltipoIncidencia.SelectedValue.ToString());
//        }

//        public void deshabilitarFormulario(Boolean vAccion) {
//            pnlIncidencia.Enabled = vAccion;
//            pnlGrillaIncidentes.Enabled = vAccion;
//            txtHoraLLegada.Enabled = vAccion;
//            ddlRuta.Enabled = vAccion;
//        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Session["lDetalleBitacora"] = null;
            //Response.Redirect("AdministrarBitacoraViaje.aspx");
        }

        public void cargarTipoIncidencia()
        {
            _servletFlota.cargarTipoIncidencia(ddltipoIncidencia);
        }

//        //INVOCAR A LA CLASE DE SERVICIOS PARA CARGAR RUTAS
//        public List<BitacoraRutaDTO> buscarRutas (string FechaPartida ,string horaPartida, string vehiculo){

//            //////////////////INVOCAR A LA CLASE DE SERVICIOS////////////////////////////////////////
//            BitacoraRutaDTO _BitacoraRutaDTO = new BitacoraRutaDTO();
//            _BitacoraRutaDTO.IdRuta = 1;
//            _BitacoraRutaDTO.Descripcion = "Lima - Ayacucho";
//            List<BitacoraRutaDTO> lBitacoraRutaDTO = new List<BitacoraRutaDTO>();
//            /////////////////////////////////////////////////////////////////////////////////////////

//            BitacoraRutaDTO dto = new BitacoraRutaDTO();
//            IMK_ProgramacionRutaRepositorio repositorio = new MK_ProgramacionRutaRepositorio();
//            IMK_ProgramacionRutaAppService service = new MK_ProgramacionRutaAppService(repositorio);
//            service = new MK_ProgramacionRutaAppService(repositorio);
////            service = new MC_TipoIncidenciaAppService(repositorio);
//             BitacoraRutaDTO _ObjDTO = new BitacoraRutaDTO();
//            _ObjDTO.Placa=vehiculo.ToString().Trim();
//           lBitacoraRutaDTO= service.ListarRutasProgramadasXUnidad(_ObjDTO);
//            //////////////////////////////////////////////////////////////////////////////////////
//            //lBitacoraRutaDTO.Add(_BitacoraRutaDTO);
//            return lBitacoraRutaDTO;
//        }

//        public void FuncionJavascript(string Mensaje, string _NombreFuncion)
//        {
//            StringBuilder sb = new StringBuilder();
//            sb.Append("alert('" + Mensaje + "');");
//            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), _NombreFuncion, Convert.ToString(sb), true);
//        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
//            if (Session["lDetalleBitacora"] == null)
//            {
//                FuncionJavascript("No existen datos para registrar", "error");
//            }
//            else
//            {
//                List<MK_UnidadTransporteDTO> lUnidadTransporteDTO = new List<MK_UnidadTransporteDTO>();
//                MK_UnidadTransporteDTO dto = new MK_UnidadTransporteDTO();
//                IMK_UnidadTransporteRepositorio repositorio = new MK_UnidadTransporteRepositorio();

//                IMK_UnidadTransporteAppService service = new MK_UnidadTransporteAppService(repositorio);
//                service = new MK_UnidadTransporteAppService(repositorio); 
               
//                MK_UnidadTransporteDTO _ObjDTO = new MK_UnidadTransporteDTO();
//                _ObjDTO.Placa = txtVehiculo.Text.ToString();
//                lUnidadTransporteDTO = service.VerificarUnidadEnMantenimiento(_ObjDTO);
//                if (lUnidadTransporteDTO.Count() > 0)
//                {
//                    FuncionJavascript("La unidad esta en mantenimiento", "error");
//                }
//                else
//                {
//                    List<BitacoraDetalleRegistrar> lDetalleBitacora;
//                    lDetalleBitacora = (List<BitacoraDetalleRegistrar>)Session["lDetalleBitacora"];
//                    //INVONCAR A LA CAPA DE SERVICIOS LA ENTIDAD YA TIENE LOS DATOS  PARA REGISTRARLO EN LA BD
//                    // falta cabecera de la bitacora!!!!!!!

                     //Grabar la bitacora completa.
//                    //por favor completar esta parte como debe ser.                     
            BEBitacora _BEBitacora = new BEBitacora();

            _BEBitacora.Fecha = Convert.ToDateTime(txtFecha.Text.ToString());
            _BEBitacora.HoraLlegada = Convert.ToDateTime(txtFecha.Text.ToString());
            _BEBitacora.HoraPartida = Convert.ToDateTime(txtFecha.Text.ToString());
                        _BEBitacora.FechaRegistra = Convert.ToDateTime(txtFecha.Text.ToString());
                        _BEBitacora.IdProgramacionRuta.IdProgramacionRuta = Convert.ToInt32(ddlRuta.SelectedValue.ToString());

                        _servletFlota.InsertarBitacora(_BEBitacora);

//                    List<MC_DetalleBitacoraDTO> lstItems = new List<MC_DetalleBitacoraDTO>();

//                    foreach (BitacoraDetalleRegistrar obj in lDetalleBitacora) {

//                        MC_DetalleBitacoraDTO item1 = new MC_DetalleBitacoraDTO();
//                        item1.Descripcion = obj.Descripcion;
//                        item1.IdTipoIncidencia =  obj.IdTipoIncidencia;

//                        lstItems.Add(item1);
//                    };

//                    //MC_DetalleBitacoraDTO item1 = new MC_DetalleBitacoraDTO();
//                    //item1.Descripcion = "Mala atención";
//                    //item1.IdTipoIncidencia = 1;

//                    //MC_DetalleBitacoraDTO item2 = new MC_DetalleBitacoraDTO();
//                    //item1.Descripcion = "Se me perdio una maleta";
//                    //item1.IdTipoIncidencia = 2;
//                    //lstItems.Add(item2);

//                    dtoBita.Items = lstItems;

//                    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "Mala atención", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia=1, Descripcion="" } });
//                    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "Buena atención", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia = 2 ,Descripcion=""} });
//                    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "se malogro a medio camino", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia = 1, Descripcion = "" } });
//                    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "objetos perdidos", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia = 2, Descripcion = "" } });
//                    //dtoBita.Items.Add(new MC_DetalleBitacoraDTO() { Descripcion = "Se malogro la llanta", TipoIncidencia = new MC_TipoIncidenciaDTO() { IdTipoIncidencia = 1, Descripcion = "" } });

//                    /*Inyección de dependencias*/
//                    IMC_BitacoraRepositorio repositorioBita = new MC_BitacoraRepositorio();
//                    IMC_BitacoraAppService serviceBita = new MC_BitacoraAppService(repositorioBita);
//                    serviceBita = new MC_BitacoraAppService(repositorioBita);
//                    serviceBita.AgregarBitacoraViaje(dtoBita);                                      

//                    Session["lDetalleBitacora"] = null;
//                    FuncionJavascript("Bitacora Registrada Exitosamenter", "exito");
//                    Response.Redirect("AdministrarBitacoraViaje.aspx");
//                }
//            }
        }

    }
}