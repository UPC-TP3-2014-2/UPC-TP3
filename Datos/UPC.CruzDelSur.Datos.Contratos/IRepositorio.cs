using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.CruzDelSur.Datos.Contratos
{
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> ObtenerTodos();
        T ObtenerPorId(int id);
        void Insertar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(T entidad);
        void Eliminar(int id);
    }
}