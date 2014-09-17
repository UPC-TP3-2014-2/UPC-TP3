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
    public class ProgramacionRutaController : ApiController
    {

		ProgramacionRutaNegocio ProgramacionRutaNegocio = new ProgramacionRutaNegocio();

		[HttpGet]
		public IEnumerable<ProgramacionRuta> Index()
		{
			return ProgramacionRutaNegocio.ObtenerTodos();
		}


		[HttpGet]
		public ProgramacionRuta Index(int id)
		{
			return ProgramacionRutaNegocio.ObtenerPorId(id);
		}

    }
}
