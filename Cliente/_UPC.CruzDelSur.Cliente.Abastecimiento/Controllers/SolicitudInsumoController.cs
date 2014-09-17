using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using UPC.CruzDelSur.Cliente.Abastecimiento.Models;
using UPC.CruzDelSur.Modelo.Abastecimiento;
using UPC.CruzDelSur.Negocio.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class SolicitudInsumoController : Controller
    {

		SolicitudInsumoNegocio SolicitudInsumoNegocio = new SolicitudInsumoNegocio();
		DetSolicitudInsumoNegocio DetSolicitudInsumoNegocio = new DetSolicitudInsumoNegocio();
        

		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }



		[HttpGet]
		public ActionResult Register()
		{
			return View(new SolicitudInsumoModel());
		}


		[HttpPost]
		public ActionResult Register(string SolicitudCocinaId, List<String> Insumos)
		{


			SolicitudInsumo SolicitudInsumo = new SolicitudInsumo();
			SolicitudInsumo.FechaSolicitud = DateTime.Now;
			SolicitudInsumo.SolicitudCocina = new SolicitudCocina() { Id = Convert.ToInt32(SolicitudCocinaId) };
			SolicitudInsumo.Estado = true;

			//SolicitudInsumoNegocio.Insertar(SolicitudInsumo);
			//SolicitudInsumo.Id = SolicitudInsumoNegocio.ObtenerUltimoId();

			//foreach (var item in form.Get("Insumos"))
			//{
			//	DetSolicitudInsumo DetSolicitudInsumo = new DetSolicitudInsumo();
			//	DetSolicitudInsumo.SolicitudInsumo = SolicitudInsumo;
			//	//DetSolicitudInsumo.Insumo = new Insumo() { Id = Convert.ToInt32(item.id) };
			//	//DetSolicitudInsumo.Cantidad = Convert.ToInt32(item.cantidad);
			//	//DetSolicitudInsumoNegocio.Insertar(DetSolicitudInsumo);
			//}
			
			return View();
		}

    }
}
