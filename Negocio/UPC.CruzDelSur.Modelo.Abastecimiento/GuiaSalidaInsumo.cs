using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
	public class GuiaSalidaInsumo
	{
		public int Id { get; set; }
		public SolicitudInsumo SolicitudInsumo { get; set; }
		public DateTime FechaGuia { get; set; }
		public int Estado { get; set; }
	}
}
