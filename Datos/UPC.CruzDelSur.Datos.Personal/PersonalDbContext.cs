using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UPC.CruzDelSur.Datos.Personal.Configuracion;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CargoConfiguration());
            modelBuilder.Configurations.Add(new TipoDocumentoConfiguration());
            modelBuilder.Configurations.Add(new PersonaConfiguration());
            modelBuilder.Configurations.Add(new DetalleHojaVidaConfiguration());
            modelBuilder.Configurations.Add(new EducacionConfiguration());
            modelBuilder.Configurations.Add(new ExperienciaLaboralConfiguration());
            modelBuilder.Configurations.Add(new SolicitudConfiguration());
            modelBuilder.Configurations.Add(new SolicitudCapacitacionConfiguration());
            modelBuilder.Configurations.Add(new SolicitudPersonalConfiguration());
            modelBuilder.Configurations.Add(new EvaluacionDesempenoConfiguration());
            
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
    }
}