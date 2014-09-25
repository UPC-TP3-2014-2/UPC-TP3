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
        public HttpResponseMessage Index()
        {
            IEnumerable<ProgramacionRuta> ListadoProgramacionRuta = ProgramacionRutaNegocio.ObtenerTodos().OrderBy(item => item.FechaOrigen);

            if (ListadoProgramacionRuta.Count() <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListadoProgramacionRuta);
        }


        [HttpGet]
        public HttpResponseMessage Index(DateTime fechaInicial, DateTime fechaFinal)
        {
            fechaInicial = fechaInicial.Date + new TimeSpan(0, 0, 0);
            fechaFinal = fechaFinal.Date + new TimeSpan(23, 59, 59);

            IEnumerable<ProgramacionRuta> ListadoProgramacionRuta = ProgramacionRutaNegocio.ObtenerTodos().Where(item => item.FechaOrigen >= fechaInicial && item.FechaOrigen <= fechaFinal).OrderBy(item => item.FechaOrigen);

            if (ListadoProgramacionRuta.Count() <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListadoProgramacionRuta);
        }


		[HttpGet]
		public HttpResponseMessage Index(int id)
		{
			ProgramacionRuta ProgramacionRuta = ProgramacionRutaNegocio.ObtenerPorId(id);

            if (ProgramacionRuta == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
	        }

            return Request.CreateResponse(HttpStatusCode.OK, ProgramacionRuta);

		}

    }
}
