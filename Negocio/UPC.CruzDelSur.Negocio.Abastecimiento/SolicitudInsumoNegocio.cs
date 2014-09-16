using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Datos.Abastecimiento;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Negocio.Abastecimiento
{
	public class SolicitudInsumoNegocio
	{
		
		protected ISolicitudInsumoRepositorio SolicitudInsumoRepositorio = new SolicitudInsumoRepositorio();

		public void Insertar(SolicitudInsumo solicitudInsumo)
		{
			SolicitudInsumoRepositorio.Insertar(solicitudInsumo);
		}

		public int ObtenerUltimoId()
		{
			return SolicitudInsumoRepositorio.ObtenerUltimoId();
		}

	}
}
