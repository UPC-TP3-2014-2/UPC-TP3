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

		protected SolicitudCocinaNegocio Negocio = new SolicitudCocinaNegocio();

        
		[HttpGet]
        public ActionResult Index()
        {
			ViewBag.ListadoSolicitudCocina = Negocio.ObtenerTodos();
            return View();
		}


		[HttpPost]
		public ActionResult Index(FormCollection form)
		{
			IQueryable<SolicitudCocina> ListadoSolicitudesCocina = Negocio.ObtenerTodos();
			ViewBag.ListadoSolicitudCocina = ListadoSolicitudesCocina;
			
			if (String.IsNullOrEmpty(form.Get("solicitud_cocina_id")) && String.IsNullOrEmpty(form.Get("solicitud_cocina_fecha_inicial")) && String.IsNullOrEmpty(form.Get("solicitud_cocina_fecha_final")))
			{
				ViewBag.ErrorParameters = "Ingrese Nro de Solicitud o Rango de Fechas.";
			}
			else if (!String.IsNullOrEmpty(form.Get("solicitud_cocina_id")))
			{
				int SolicitudCocinaId = Convert.ToInt32(form.Get("solicitud_cocina_id"));
				ViewBag.ListadoSolicitudCocina = ListadoSolicitudesCocina.Where(item => item.Id == SolicitudCocinaId);
			}
			else
			{
				DateTime SolicitudCocinaFechaInicial = Convert.ToDateTime(form.Get("solicitud_cocina_fecha_inicial") + " 00:00:00");
				DateTime SolicitudCocinaFechaFinal = Convert.ToDateTime(form.Get("solicitud_cocina_fecha_final") + " 23:59:59");

				if (SolicitudCocinaFechaInicial > SolicitudCocinaFechaFinal)
				{
					ViewBag.ErrorParameters = "La fecha inicial no puede ser mayor a la fecha final.";
				}
				else
				{
					ViewBag.ListadoSolicitudCocina = ListadoSolicitudesCocina.Where(item => item.FechaSolicitud >= SolicitudCocinaFechaInicial && item.FechaSolicitud <= SolicitudCocinaFechaFinal);
				}
			}

			return View();
		}



		[HttpGet]
		public ActionResult Cancel(int id)
		{
			try
			{
				Negocio.AnularSolicitud(id);
				ViewBag.SolicitudCocinaId = id;
			}
			catch (Exception)
			{
				ViewBag.Error = "Ha ocurrido un error al anular la solicitud de cocina.";
			}
			
			return View();
		}

    }
}
