using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Datos.Abastecimiento;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Negocio.Abastecimiento
{
	public class RefrigerioNegocio
	{

		protected RefrigerioRepositorio RefrigerioRepo = RefrigerioRepositorio.ObtenerInstancia();

		public IQueryable<Refrigerio> ObtenerTodos()
		{
			return RefrigerioRepo.ObtenerTodos();
		}

		public Refrigerio ObtenerPorId(int id)
		{
			return RefrigerioRepo.ObtenerPorId(id);
		}

	}
}
