using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.CruzDelSur.Modelo.Abastecimiento;
using UPC.CruzDelSur.Negocio.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class SolicitudInsumoController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            IQueryable<SolicitudInsumo> ListadoSolicitudesInsumo = new SolicitudInsumoNegocio().ObtenerTodos();
            ViewBag.ListadoSolicitudesInsumo = ListadoSolicitudesInsumo;
            return View();
        }


        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            IQueryable<SolicitudInsumo> ListadoSolicitudesInsumo = new SolicitudInsumoNegocio().ObtenerTodos();
            ViewBag.ListadoSolicitudesInsumo = ListadoSolicitudesInsumo;

            if (String.IsNullOrEmpty(form.Get("solicitud_insumo_id")) && String.IsNullOrEmpty(form.Get("solicitud_insumo_fecha_inicial")) && String.IsNullOrEmpty(form.Get("solicitud_insumo_fecha_final")))
            {
                ViewBag.ErrorParameters = "Ingrese Nro de Solicitud o Rango de Fechas.";
            }
            else if (!String.IsNullOrEmpty(form.Get("solicitud_insumo_id")))
            {
                int SolicitudInsumoId = Convert.ToInt32(form.Get("solicitud_insumo_id"));
                ViewBag.ListadoSolicitudesInsumo = ListadoSolicitudesInsumo.Where(item => item.Id == SolicitudInsumoId);
            }
            else
            {
                DateTime SolicitudInsumoFechaInicial = Convert.ToDateTime(form.Get("solicitud_insumo_fecha_inicial") + " 00:00:00");
                DateTime SolicitudInsumoFechaFinal = Convert.ToDateTime(form.Get("solicitud_insumo_fecha_final") + " 23:59:59");

                ViewBag.ListadoSolicitudesInsumo = ListadoSolicitudesInsumo.Where(item => item.FechaSolicitud >= SolicitudInsumoFechaInicial && item.FechaSolicitud <= SolicitudInsumoFechaFinal);
            }            

            return View();
        }


        
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

    }
}
