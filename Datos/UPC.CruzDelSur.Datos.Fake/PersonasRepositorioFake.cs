using System.Collections.Generic;
using System.Linq;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo;

namespace UPC.CruzDelSur.Datos.Fake
{
    public class PersonasRepositorioFake : IPersonasRepositorio
    {
        public IQueryable<Persona> ObtenerTodos()
        {
            return new List<Persona>
            {
                new Persona {Id = 1, Nombre = "Mario Vargas Llosa"},
                new Persona {Id = 2, Nombre = "Alfredo Bryce Echenique"}
            }.AsQueryable();
        }

        public Persona ObtenerPorId(int id)
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

        public void Eliminar(Persona entidad)
        {
            throw new System.NotImplementedException();
        }

        public void Actualizar(Persona entidad)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(Persona entidad)
        {
            throw new System.NotImplementedException();
        }
    }
}