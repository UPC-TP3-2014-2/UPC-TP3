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
    public class GuiaSalidaInsumoController : ApiController
    {
		protected GuiaSalidaInsumoNegocio GuiaSalidaInsumoNegocio = new GuiaSalidaInsumoNegocio();
		protected SolicitudInsumoNegocio SolicitudInsumoNegocio = new SolicitudInsumoNegocio();

		[HttpGet]
		public IEnumerable<GuiaSalidaInsumo> Get()
		{
			return GuiaSalidaInsumoNegocio.ObtenerTodos().OrderBy(item => item.FechaGuia);
		}


		[HttpGet]
		public IEnumerable<GuiaSalidaInsumo> Get(DateTime fechaInicial, DateTime fechaFinal)
		{
			fechaInicial = fechaInicial.Date + new TimeSpan(0, 0, 0);
			fechaFinal = fechaFinal.Date + new TimeSpan(23, 59, 59);

			return GuiaSalidaInsumoNegocio.ObtenerTodos().Where(item => item.FechaGuia >= fechaInicial && item.FechaGuia <= fechaFinal).OrderBy(item => item.FechaGuia);
		}


		[HttpGet]
		public GuiaSalidaInsumo Get(int id)
		{
			return GuiaSalidaInsumoNegocio.ObtenerPorId(id);
		}


		[HttpPost]
		public GuiaSalidaInsumo Post(GuiaSalidaInsumo guiaSalidaInsumo)
		{
			guiaSalidaInsumo.FechaGuia = DateTime.Now;
			guiaSalidaInsumo.Estado = 1;
			GuiaSalidaInsumoNegocio.Insertar(guiaSalidaInsumo);

			SolicitudInsumo SolicitudInsumo = SolicitudInsumoNegocio.ObtenerPorId(guiaSalidaInsumo.SolicitudInsumo.Id);
			SolicitudInsumo.Estado = 2;
			SolicitudInsumoNegocio.Actualizar(SolicitudInsumo);

			return guiaSalidaInsumo;
		}


		[HttpPut]
		public GuiaSalidaInsumo Put(GuiaSalidaInsumo guiaSalidaInsumo)
		{

			if (guiaSalidaInsumo.Estado == 0) // Anular
			{
				SolicitudInsumo SolicitudInsumo = GuiaSalidaInsumoNegocio.ObtenerPorId(guiaSalidaInsumo.Id).SolicitudInsumo;
				SolicitudInsumo.Estado = 1;
				SolicitudInsumoNegocio.Actualizar(SolicitudInsumo);
			}
			
			GuiaSalidaInsumoNegocio.Actualizar(guiaSalidaInsumo);

			return guiaSalidaInsumo;
		}


    }
}
