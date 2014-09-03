using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class ExperienciaLaboralConfiguration : EntityTypeConfiguration<ExperienciaLaboral>
    {
        public ExperienciaLaboralConfiguration()
        {
            ToTable("TA_EXPERIENCIASLABORALES");
            Property(e => e.Cargo)
                .HasColumnName("VCH_CARGO");
        } 
    }
}