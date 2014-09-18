using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class AreaConfiguration : EntityTypeConfiguration<Area>
    {
        public AreaConfiguration()
        {
            ToTable("TA_AREAS");
            Property(a => a.Id)
                .HasColumnName("INT_CODIGOAREA");
            Property(a => a.Nombre)
                .HasColumnName("VCH_NOMBRE");
        }
    }
}