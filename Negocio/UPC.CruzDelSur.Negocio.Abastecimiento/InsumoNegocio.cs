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
		protected IInsumoRepositorio InsumoRepo = InsumoRepositorio.ObtenerInstancia();

		public IQueryable<Insumo> ObtenerTodos()
		{
			return InsumoRepo.ObtenerTodos();
		}

		public Insumo ObtenerPorId(int id)
		{
			return InsumoRepo.ObtenerPorId(id);
		}


	}
}
