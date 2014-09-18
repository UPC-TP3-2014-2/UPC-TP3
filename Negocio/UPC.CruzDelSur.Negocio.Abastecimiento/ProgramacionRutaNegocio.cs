using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Datos.Abastecimiento;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Negocio.Abastecimiento
{
	public class ProgramacionRutaNegocio
	{

		protected IProgramacionRutaRepositorio Repositorio = ProgramacionRutaRepositorio.ObtenerInstancia();

		public IQueryable<ProgramacionRuta> ObtenerTodos()
		{
			return Repositorio.ObtenerTodos();
		}

		public ProgramacionRuta ObtenerPorId(int id)
		{
			return Repositorio.ObtenerPorId(id);
		}


	}
}
