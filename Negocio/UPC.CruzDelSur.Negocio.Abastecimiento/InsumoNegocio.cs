using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Datos.Abastecimiento;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Negocio.Abastecimiento
{
	public class InsumoNegocio
	{
		protected IInsumoRepositorio InsumoRepositorio = new InsumoRepositorio();

		public IQueryable<Insumo> ObtenerTodos()
		{
			return InsumoRepositorio.ObtenerTodos();
		}


	}
}
