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
        public IEnumerable<SolicitudCocina> Index()
        {
            return SolicitudCocinaNegocio.ObtenerTodos();
        }


        [HttpGet]
        public SolicitudCocina Index(int id)
        {
            return SolicitudCocinaNegocio.ObtenerPorId(id);
        }

    }
}
