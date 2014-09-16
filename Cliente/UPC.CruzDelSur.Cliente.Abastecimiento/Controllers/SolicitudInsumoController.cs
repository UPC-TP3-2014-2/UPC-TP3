using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.CruzDelSur.Cliente.Abastecimiento.Models;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class SolicitudInsumoController : Controller
    {
        

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
		public ActionResult Register(FormCollection form)
		{
			
			return View();
		}

    }
}
