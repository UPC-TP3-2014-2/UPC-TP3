using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class SolicitudInsumoController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
