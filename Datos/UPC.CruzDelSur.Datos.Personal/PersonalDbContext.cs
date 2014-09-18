using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using UPC.CruzDelSur.Datos.Personal.DataDeEjemplo;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class PersonalDbContext : DbContext
    {
        public PersonalDbContext() : base("CSUR")
        {
        }

        static PersonalDbContext()
        {
            Database.SetInitializer(new PersonalDbInitializer());
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<DetalleHojaVida> DetallesHojaVida { get; set; }
        public DbSet<ExperienciaLaboral> ExperienciasLaborales { get; set; }
        public DbSet<Educacion> Educaciones { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<SolicitudCapacitacion> SolicitudesCapacitacion { get; set; }
        public DbSet<AuditEntry> AuditEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
    }
}