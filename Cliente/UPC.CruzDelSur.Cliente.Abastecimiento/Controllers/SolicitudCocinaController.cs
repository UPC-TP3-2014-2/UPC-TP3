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
        public HttpResponseMessage Put(SolicitudCocina solicitudCocina)
        {
            SolicitudCocinaNegocio.Actualizar(solicitudCocina);
            return Request.CreateResponse(HttpStatusCode.Created, solicitudCocina);
        }

		
    }
}
