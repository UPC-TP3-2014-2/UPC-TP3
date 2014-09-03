using System.Data.Entity;
using System.Linq;
using UPC.CruzDelSur.Datos.Contratos;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class Repositorio<T> : IRepositorio<T> where T : class 
    {
        public Repositorio(DbContext context)
        {
            Context = context;
        }

        protected DbContext Context { get; private set; }

        protected DbSet<T> Set
        {
            get { return Context.Set<T>(); }
        }

        public IQueryable<T> ObtenerTodos()
        {
            return Set;
        }

        public T ObtenerPorId(int id)
        {
            return Set.Find(id);
        }

        public void Insertar(T entidad)
        {
            Set.Add(entidad);
        }

        public void Actualizar(T entidad)
        {
            throw new System.NotImplementedException();
        }

        public void Eliminar(T entidad)
        {
            throw new System.NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}