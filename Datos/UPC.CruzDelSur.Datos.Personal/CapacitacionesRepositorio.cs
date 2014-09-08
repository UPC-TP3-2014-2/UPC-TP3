using System.Data.Entity;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class CapacitacionesRepositorio : Repositorio<Capacitacion>, ICapacitacionesRepositorio
    {
        public CapacitacionesRepositorio(DbContext context) : base(context)
        {
        }
    }
}