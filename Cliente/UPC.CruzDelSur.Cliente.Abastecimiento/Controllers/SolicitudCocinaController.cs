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
    public class SolicitudCocinaController : ApiController
    {

		SolicitudCocinaNegocio SolicitudCocinaNegocio = new SolicitudCocinaNegocio();

		[HttpGet]
		public IEnumerable<SolicitudCocina> Get()
		{
			return SolicitudCocinaNegocio.ObtenerTodos().OrderBy(item => item.FechaSolicitud);
		}

		[HttpGet]
		public IEnumerable<SolicitudCocina> Get(DateTime fechaInicial, DateTime fechaFinal)
		{
			fechaInicial = fechaInicial.Date + new TimeSpan(0, 0, 0);
			fechaFinal = fechaFinal.Date + new TimeSpan(23, 59, 59);
			
			return SolicitudCocinaNegocio.ObtenerTodos().Where(item => item.FechaSolicitud >= fechaInicial && item.FechaSolicitud <= fechaFinal).OrderBy(item => item.FechaSolicitud);
		}


        [HttpGet]
        public SolicitudCocina Get(int id)
        {
            return SolicitudCocinaNegocio.ObtenerPorId(id);
        }


        [HttpPost]
        public HttpResponseMessage Post(SolicitudCocina solicitudCocina)
        {
            solicitudCocina.FechaSolicitud = DateTime.Now;
            solicitudCocina.Estado = 1;
            SolicitudCocinaNegocio.Insertar(solicitudCocina);
            return Request.CreateResponse(HttpStatusCode.Created, solicitudCocina);
        }


        [HttpPut]
        public SolicitudCocina Put(SolicitudCocina solicitudCocina)
        {
            SolicitudCocinaNegocio.Actualizar(solicitudCocina);
			return solicitudCocina;
        }

		
    }
}
