using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class SolicitudCocinaController : Controller
    {
       
		[HttpPost]
        public JsonResult Search()
        {
			
			var movies = new List<object>();

			movies.Add(new { FechaIngreso = "01/01/1900", NroSolicitud = 1, UnidadTransporte = "KJ123", RutaProgramada = "Lima - Chiclayo" });
			movies.Add(new { FechaIngreso = "01/01/1900", NroSolicitud = 2, UnidadTransporte = "KJ123", RutaProgramada = "Lima - Chiclayo" });
			movies.Add(new { FechaIngreso = "01/01/1900", NroSolicitud = 3, UnidadTransporte = "KJ123", RutaProgramada = "Lima - Chiclayo" });

			return Json(movies, JsonRequestBehavior.AllowGet);
        }

    }
}
