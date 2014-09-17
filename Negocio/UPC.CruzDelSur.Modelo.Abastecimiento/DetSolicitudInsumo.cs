using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
	public class DetSolicitudInsumo
	{
		public SolicitudInsumo SolicitudInsumo { get; set; }
		public Insumo Insumo { get; set; }
		public int Cantidad { get; set; }
		public string Unidad { get; set; }
	}
}
