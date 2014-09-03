using System.Data.Entity;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class SolicitudesCapacitacionRepositorio : Repositorio<SolicitudCapacitacion>, ISolicitudesCapacitacionRepositorio
    {
        public SolicitudesCapacitacionRepositorio(DbContext context) : base(context)
        {
        }
    }
}