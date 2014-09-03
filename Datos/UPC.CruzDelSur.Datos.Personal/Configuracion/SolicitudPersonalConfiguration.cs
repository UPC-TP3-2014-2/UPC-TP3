using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class SolicitudPersonalConfiguration : EntityTypeConfiguration<SolicitudPersonal>
    {
        public SolicitudPersonalConfiguration()
        {
            ToTable("TA_SOLICITUDESPERSONAL");
            Property(s => s.FechaVencimiento)
                .HasColumnName("DTE_FECHAVENCIMIENTO");
            Property(s => s.Asunto)
                .HasColumnName("VCH_ASUNTO");
            Property(s => s.Descripcion)
                .HasColumnName("VCH_DESCRIPCION");
        }
    }
}