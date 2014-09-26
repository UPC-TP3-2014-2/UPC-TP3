using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
	public class DetGuiaSalidaInsumo
	{
		public int Id { get; set; }
		public GuiaSalidaInsumo GuiaSalidaInsumo { get; set; }
		public Insumo Insumo { get; set; }
		public int Cantidad { get; set; }
		public string Unidad { get; set; }
	}
}
