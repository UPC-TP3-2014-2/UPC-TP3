using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.CruzDelSur.Modelo.Abastecimiento;
using UPC.CruzDelSur.Negocio.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class SolicitudCocinaController : Controller
    {

		SolicitudCocinaNegocio Negocio = new SolicitudCocinaNegocio();
       
		[HttpPost]
        public JsonResult Search()
        {

			var Listado = new List<object>();

			foreach (SolicitudCocina SolicitudCocina in Negocio.ObtenerTodos())
			{
				Listado.Add(
					new 
					{ 
						FechaIngreso = SolicitudCocina.FechaSolicitud.ToShortDateString(),
						NroSolicitud = SolicitudCocina.Id,
						UnidadTransporte = SolicitudCocina.ProgramacionRuta.Vehiculo.Placa,
						RutaProgramada = SolicitudCocina.ProgramacionRuta.Ruta.AgenciaOrigen.Nombre + " - " + SolicitudCocina.ProgramacionRuta.Ruta.AgenciaDestino.Nombre
					}
				);
			}

			return Json(Listado, JsonRequestBehavior.AllowGet);
        }

    }
}
