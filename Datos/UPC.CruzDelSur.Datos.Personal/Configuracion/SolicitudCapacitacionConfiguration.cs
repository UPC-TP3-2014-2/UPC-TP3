using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class SolicitudCapacitacionConfiguration : EntityTypeConfiguration<SolicitudCapacitacion>
    {
        public SolicitudCapacitacionConfiguration()
        {
            ToTable("TA_SOLICITUDESCAPACITACION");
            Property(s => s.FechaPlanificada)
                .HasColumnName("DTE_FECHAPLANIFICADA");
            Property(s => s.CapacitacionId)
                .HasColumnName("INT_CODIGOCAPACITACION");
            Property(s => s.TrabajadorId)
                .HasColumnName("INT_CODIGOPERSONA");

            HasRequired(s => s.Trabajador)
                .WithMany()
                .HasForeignKey(s => s.TrabajadorId);

            HasRequired(s => s.Capacitacion)
                .WithMany()
                .HasForeignKey(s => s.CapacitacionId);
        }
    }
}