using System.Data.Entity;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class TiposEducacionRepositorio : Repositorio<TipoEducacion>, ITiposEducacionRepositorio
    {
        public TiposEducacionRepositorio(DbContext context) : base(context)
        {
        }
    }
}