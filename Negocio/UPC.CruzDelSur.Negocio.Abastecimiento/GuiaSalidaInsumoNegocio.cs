using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CruzDelSur.Datos.Abastecimiento;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Negocio.Abastecimiento
{
	public class GuiaSalidaInsumoNegocio
	{

		IGuiaSalidaInsumoRepositorio GuiaSalidaInsumoRepo = GuiaSalidaInsumoRepositorio.ObtenerInstancia();

		public IQueryable<GuiaSalidaInsumo> ObtenerTodos()
		{
			return GuiaSalidaInsumoRepo.ObtenerTodos();
		}

		public GuiaSalidaInsumo ObtenerPorId(int id)
		{
			return GuiaSalidaInsumoRepo.ObtenerPorId(id);
		}

		public void Insertar(GuiaSalidaInsumo guiaSalidaInsumo)
		{
			GuiaSalidaInsumoRepo.Insertar(guiaSalidaInsumo);
		}

		public void Actualizar(GuiaSalidaInsumo guiaSalidaInsumo)
		{
			GuiaSalidaInsumoRepo.Actualizar(guiaSalidaInsumo);
		}

	}
}
