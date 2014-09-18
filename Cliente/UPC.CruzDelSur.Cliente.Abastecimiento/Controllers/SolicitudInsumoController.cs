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
    public class SolicitudInsumoController : ApiController
    {
		protected SolicitudInsumoNegocio SolicitudInsumoNegocio = new SolicitudInsumoNegocio();
		protected SolicitudCocinaNegocio SolicitudCocinaNegocio = new SolicitudCocinaNegocio();

		[HttpGet]
		public IEnumerable<SolicitudInsumo> Get()
		{
			return SolicitudInsumoNegocio.ObtenerTodos().OrderBy(item => item.FechaSolicitud);
		}


		[HttpGet]
		public IEnumerable<SolicitudInsumo> Get(DateTime fechaInicial, DateTime fechaFinal)
		{
			fechaInicial = fechaInicial.Date + new TimeSpan(0, 0, 0);
			fechaFinal = fechaFinal.Date + new TimeSpan(23, 59, 59);

			return SolicitudInsumoNegocio.ObtenerTodos().Where(item => item.FechaSolicitud >= fechaInicial && item.FechaSolicitud <= fechaFinal).OrderBy(item => item.FechaSolicitud);
		}


        [HttpGet]
        public SolicitudInsumo Get(int id)
        {
            return SolicitudInsumoNegocio.ObtenerPorId(id);
        }


        [HttpPost]
        public SolicitudInsumo Post(SolicitudInsumo solicitudInsumo)
        {
			solicitudInsumo.FechaSolicitud = DateTime.Now;
			solicitudInsumo.Estado = 1;
			SolicitudInsumoNegocio.Insertar(solicitudInsumo);

			SolicitudCocina SolicitudCocina = SolicitudCocinaNegocio.ObtenerPorId(solicitudInsumo.SolicitudCocina.Id);
			SolicitudCocina.Estado = 2;
			SolicitudCocinaNegocio.Actualizar(SolicitudCocina);
            
            return solicitudInsumo;
        }


        [HttpPut]
        public SolicitudInsumo Put(SolicitudInsumo solicitudInsumo)
        {

			SolicitudCocina SolicitudCocinaAnterior = SolicitudInsumoNegocio.ObtenerPorId(solicitudInsumo.Id).SolicitudCocina;
			SolicitudCocinaAnterior.Estado = 1;

			SolicitudCocina SolicitudCocinaActual = SolicitudCocinaNegocio.ObtenerPorId(solicitudInsumo.SolicitudCocina.Id);
			SolicitudCocinaActual.Estado = 2;

			SolicitudInsumoNegocio.Actualizar(solicitudInsumo);
			SolicitudCocinaNegocio.Actualizar(SolicitudCocinaAnterior);
			SolicitudCocinaNegocio.Actualizar(SolicitudCocinaActual);

            return solicitudInsumo;
        }



    }
}
