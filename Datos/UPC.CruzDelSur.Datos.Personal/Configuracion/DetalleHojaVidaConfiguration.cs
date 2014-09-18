using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class DetalleHojaVidaConfiguration : EntityTypeConfiguration<DetalleHojaVida>
    {
        public DetalleHojaVidaConfiguration()
        {
            ToTable("TA_DETALLESHOJAVIDA");
            Property(d => d.Id)
                .HasColumnName("INT_CODIGODETALLEHOJAVIDA");
            Property(d => d.Institucion)
                .HasColumnName("VCH_INSTITUCION");
            Property(d => d.Desde)
                .HasColumnName("DTE_DESDE");
            Property(d => d.Hasta)
                .HasColumnName("DTE_HASTA");
            Property(d => d.Observaciones)
                .HasColumnName("VCH_OBSERVACIONES");
            Property(d => d.PersonaId)
                .HasColumnName("INT_CODIGOPERSONA");

            HasRequired(d => d.Persona)
                .WithMany(p => p.DetallesHojaVida)
                .HasForeignKey(d => d.PersonaId)
                .WillCascadeOnDelete(false);
        }
    }
}