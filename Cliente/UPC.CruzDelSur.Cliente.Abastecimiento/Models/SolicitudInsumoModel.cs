using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Models
{
	public class SolicitudInsumoModel
	{

		public SolicitudInsumoModel() { }


		public int SolicitudCocinaId { get; set; }



		public IEnumerable<Insumo> Insumos { get; set; }

	}
}