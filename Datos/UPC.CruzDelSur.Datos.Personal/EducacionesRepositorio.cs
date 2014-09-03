using System.Data.Entity;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class EducacionesRepositorio : Repositorio<Educacion>, IEducacionesRepositorio
    {
        public EducacionesRepositorio(DbContext context) : base(context)
        {
        }
    }
}