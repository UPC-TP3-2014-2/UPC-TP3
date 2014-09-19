using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UPC.CruzDelSur.Modelo.Abastecimiento;
using UPC.CruzDelSur.Negocio.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class RefrigerioController : ApiController
    {

		RefrigerioNegocio RefrigerioNegocio = new RefrigerioNegocio();

		[HttpGet]
		public IEnumerable<Refrigerio> Index()
		{
			return RefrigerioNegocio.ObtenerTodos();
		}


		[HttpGet]
		public Refrigerio Index(int id)
		{
			return RefrigerioNegocio.ObtenerPorId(id);
		}

    }
}
