using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.CruzDelSur.Cliente.Abastecimiento.Models;
using UPC.CruzDelSur.Modelo.Abastecimiento;
using UPC.CruzDelSur.Negocio.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class SolicitudCocinaController : Controller
    {

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }


        [HttpPost]
        public ActionResult New(SolicitudCocinaModel solicitudCocina)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SolicitudCocina SolicitudCocina = solicitudCocina.GetSolicitudCocina();
                    new SolicitudCocinaNegocio().Insertar(SolicitudCocina);
                    ViewBag.AlertSuccess = "Se registro correctamente la solicitud de cocina.";
                }
                catch (Exception)
                {
                    ViewBag.AlertDanger = "Ha ocurrido un error al registrar la solicitud de cocina.";
                }
                
            }
            return View(new SolicitudCocinaModel());
        }

        

    }
}
