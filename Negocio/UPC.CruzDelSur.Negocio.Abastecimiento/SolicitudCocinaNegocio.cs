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

        protected ISolicitudCocinaRepositorio Repositorio = SolicitudCocinaRepositorio.ObtenerInstancia();


		public IQueryable<SolicitudCocina> ObtenerTodos()
		{
			return Repositorio.ObtenerTodos().Where(item => item.Estado == true);
		}

        public void Insertar(SolicitudCocina solicitudCocina)
        {
            Repositorio.Insertar(solicitudCocina);
        }

		public void AnularSolicitud(int id)
		{
			Repositorio.AnularSolicitud(id);
		}

    }
}
