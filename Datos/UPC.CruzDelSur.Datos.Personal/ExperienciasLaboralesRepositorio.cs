using System.Data.Entity;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class ExperienciasLaboralesRepositorio : Repositorio<ExperienciaLaboral>, IExperienciasLaboralesRepositorio
    {
        public ExperienciasLaboralesRepositorio(DbContext context) : base(context)
        {
        }
    }
}