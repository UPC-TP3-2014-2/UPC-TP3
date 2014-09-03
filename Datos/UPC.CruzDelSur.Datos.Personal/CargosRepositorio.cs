using System.Data.Entity;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class CargosRepositorio : Repositorio<Cargo>, ICargosRepositorio
    {
        public CargosRepositorio(DbContext context) : base(context)
        {
        }
    }
}