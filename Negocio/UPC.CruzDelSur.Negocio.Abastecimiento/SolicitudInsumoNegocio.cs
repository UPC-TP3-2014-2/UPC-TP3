using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Datos.Abastecimiento;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Negocio.Abastecimiento
{
	public class SolicitudInsumoNegocio
	{

        protected ISolicitudInsumoRepositorio SolicitudInsumoRepo = SolicitudInsumoRepositorio.ObtenerInstancia();

        public IQueryable<SolicitudInsumo> ObtenerTodos()
        {
            return SolicitudInsumoRepo.ObtenerTodos();
        }

        public SolicitudInsumo ObtenerPorId(int id)
        {
            return SolicitudInsumoRepo.ObtenerPorId(id);
        }

        public void Insertar(SolicitudInsumo solicitudInsumo)
        {
            SolicitudInsumoRepo.Insertar(solicitudInsumo);
        }

        public void Actualizar(SolicitudInsumo solicitudInsumo)
        {
            SolicitudInsumoRepo.Actualizar(solicitudInsumo);
        }


	}
}
