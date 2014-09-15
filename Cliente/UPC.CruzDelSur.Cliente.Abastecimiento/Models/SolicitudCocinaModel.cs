using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Models
{
	public class SolicitudCocinaModel
	{

		public int ProgramacionRutaId { get; set; }
		public int RefrigerioId { get; set; }
		public int Cantidad { get; set; }




		public SolicitudCocina GetEntity()
		{
			return new SolicitudCocina()
			{
				ProgramacionRuta = new ProgramacionRuta() { Id = this.ProgramacionRutaId },
				Refrigerio = new Refrigerio() { Id = this.RefrigerioId }, 
				FechaSolicitud = DateTime.Now, 
				Cantidad = this.Cantidad, 
				Estado = true
			};
		}

	}
}