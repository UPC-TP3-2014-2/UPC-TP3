using System.Linq;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class PersonasRepositorio : IPersonasRepositorio
    {
        private readonly PersonalDbContext _contexto;

        public PersonasRepositorio(PersonalDbContext contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<Persona> ObtenerTodos()
        {
            return _contexto.Personas;
        }

        public Persona ObtenerPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(Persona entidad)
        {
            throw new System.NotImplementedException();
        }

        public void Actualizar(Persona entidad)
        {
            throw new System.NotImplementedException();
        }

        public void Eliminar(Persona entidad)
        {
            throw new System.NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public Persona ObtenerPorDNI(string dni)
        {
            throw new System.NotImplementedException();
        }
    }
}