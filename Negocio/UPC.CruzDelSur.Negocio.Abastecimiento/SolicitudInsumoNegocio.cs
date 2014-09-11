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
    public class SolicitudInsumoNegocio
    {
        protected ISolicitudInsumoRepositorio Repositorio = SolicitudInsumoRepositorio.ObtenerInstancia();


        public SolicitudInsumo ObtenerPorId(int id)
        {
            return Repositorio.ObtenerPorId(id);
        }

        public IQueryable<SolicitudInsumo> ObtenerTodos()
        {
            return Repositorio.ObtenerTodos();
        }


      


    }
}
