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
		protected SolicitudCocinaNegocio SolicitudCocinaNegocio = new SolicitudCocinaNegocio();

		[HttpGet]
		public HttpResponseMessage Get()
		{
            IEnumerable<SolicitudCocina> ListadoSolicitudesCocina = SolicitudCocinaNegocio.ObtenerTodos().OrderBy(item => item.FechaSolicitud);

            if (ListadoSolicitudesCocina.Count()<= 0)
	        {
                return Request.CreateResponse(HttpStatusCode.NoContent);
	        }

            return Request.CreateResponse(HttpStatusCode.OK, ListadoSolicitudesCocina);
		}

        [HttpGet]
        public HttpResponseMessage Get(DateTime fechaInicial, DateTime fechaFinal)
        {
            fechaInicial = fechaInicial.Date + new TimeSpan(0, 0, 0);
            fechaFinal = fechaFinal.Date + new TimeSpan(23, 59, 59);

            IEnumerable<SolicitudCocina> ListadoSolicitudesCocina = SolicitudCocinaNegocio.ObtenerTodos().Where(item => item.FechaSolicitud >= fechaInicial && item.FechaSolicitud <= fechaFinal).OrderBy(item => item.FechaSolicitud);

            if (ListadoSolicitudesCocina.Count() <= 0)
	        {
		        return Request.CreateResponse(HttpStatusCode.NoContent);
	        }

            return Request.CreateResponse(HttpStatusCode.OK, ListadoSolicitudesCocina);
        }


        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            SolicitudCocina SolicitudCocina = SolicitudCocinaNegocio.ObtenerPorId(id);

            if (SolicitudCocina == null)
	        {
                return Request.CreateResponse(HttpStatusCode.NoContent);
	        }

            return Request.CreateResponse(HttpStatusCode.OK, SolicitudCocina);
        }


        [HttpPost]
        public SolicitudCocina Post(SolicitudCocina solicitudCocina)
        {
            solicitudCocina.FechaSolicitud = DateTime.Now;
            solicitudCocina.Estado = 1;
            SolicitudCocinaNegocio.Insertar(solicitudCocina);
			return solicitudCocina;
        }


        [HttpPut]
        public HttpResponseMessage Put(SolicitudCocina solicitudCocina) 
        {
            SolicitudCocinaNegocio.Actualizar(solicitudCocina);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

		
    }
}
