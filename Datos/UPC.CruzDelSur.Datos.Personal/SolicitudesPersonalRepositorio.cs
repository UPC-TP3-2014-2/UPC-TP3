using System.Data.Entity;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class SolicitudesPersonalRepositorio : Repositorio<SolicitudPersonal>, ISolicitudesPersonalRepositorio
    {
        public SolicitudesPersonalRepositorio(DbContext context) : base(context)
        {
        }
    }
}