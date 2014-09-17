using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class CapacitacionConfiguration : EntityTypeConfiguration<Capacitacion>
    {
        public CapacitacionConfiguration()
        {
            ToTable("TA_CAPACITACIONES");
            Property(c => c.Id)
                .HasColumnName("INT_CODIGOCAPACITACION");
            Property(c => c.Nombre)
                .HasColumnName("VCH_NOMBRE");
            Property(c => c.Duracion)
                .HasColumnName("INT_DURACION");
        }
    }
}