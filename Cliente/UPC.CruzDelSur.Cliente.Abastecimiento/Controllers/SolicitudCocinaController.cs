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



		public IEnumerable<SolicitudCocina> Get()
		{
			return SolicitudCocinaNegocio.ObtenerTodos();
		}
		
		

		//// GET api/solicitudcocina/5
		//public string Get(int id)
		//{
		//	return "value";
		//}

        // POST api/solicitudcocina
		public HttpResponseMessage Post(SolicitudCocina solicitudCocina)
        {
			solicitudCocina.FechaSolicitud = DateTime.Now;
			solicitudCocina.Estado = true;
			SolicitudCocinaNegocio.Insertar(solicitudCocina);
			return new HttpResponseMessage(HttpStatusCode.Created);
        }

		//// PUT api/solicitudcocina/5
		//public void Put(int id, [FromBody]string value)
		//{
		//}

		//// DELETE api/solicitudcocina/5
		//public void Delete(int id)
		//{
		//}
    }
}
