using System.Data.Entity;
using System.Linq;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class PersonasRepositorio : Repositorio<Persona>, IPersonasRepositorio
    {
        public PersonasRepositorio(DbContext context) : base(context)
        {
        }

        public Persona ObtenerPorDNI(string dni)
        {
            return Set.SingleOrDefault(p => p.NroDocumento == dni);
        }
    }
}