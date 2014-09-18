using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class EducacionConfiguration : EntityTypeConfiguration<Educacion>
    {
        public EducacionConfiguration()
        {
            ToTable("TA_EDUCACIONES");
            Property(e => e.TipoId)
                .HasColumnName("INT_CODIGOEDUCACION");
            Property(e => e.GradoObtenido)
                .HasColumnName("VCH_GRADOOBTENIDO");
        }
    }
}