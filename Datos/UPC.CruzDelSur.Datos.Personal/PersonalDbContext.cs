using System.Data.Entity;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class PersonalDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<DetalleHojaVida> DetallesHojaVida { get; set; }
        public DbSet<ExperienciaLaboral> ExperienciasLaborales { get; set; }
        public DbSet<Educacion> Educaciones { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<SolicitudCapacitacion> SolicitudesCapacitacion { get; set; }
    }
}