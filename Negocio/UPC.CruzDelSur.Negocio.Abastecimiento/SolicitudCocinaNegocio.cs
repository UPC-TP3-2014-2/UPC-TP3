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
    public class SolicitudCocinaNegocio
    {

        protected ISolicitudCocinaRepositorio SolicitudCocinaRepo = SolicitudCocinaRepositorio.ObtenerInstancia();


		public IQueryable<SolicitudCocina> ObtenerTodos()
		{
			return SolicitudCocinaRepo.ObtenerTodos();
		}

        public IQueryable<SolicitudCocina> ObtenerTodosActivos()
        {
            return SolicitudCocinaRepo.ObtenerTodos().Where(item => item.Estado == 1);
        }

        public SolicitudCocina ObtenerPorId(int id)
        {
            return SolicitudCocinaRepo.ObtenerPorId(id);
        }

        public void Insertar(SolicitudCocina solicitudCocina)
        {
            SolicitudCocinaRepo.Insertar(solicitudCocina);
        }

        public void Actualizar(SolicitudCocina solicitudCocina)
        {
            SolicitudCocinaRepo.Actualizar(solicitudCocina);
        }

        public void Eliminar(SolicitudCocina solicitudCocina)
        {
            SolicitudCocinaRepo.Eliminar(solicitudCocina);
        }

        public void Eliminar(int id)
        {
            SolicitudCocinaRepo.Eliminar(id);
        }

    }
}
