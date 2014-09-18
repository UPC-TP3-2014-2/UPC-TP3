using System.Data.Entity;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class AreasRepositorio : Repositorio<Area>, IAreasRepositorio
    {
        public AreasRepositorio(DbContext context) : base(context)
        {
        }
    }
}