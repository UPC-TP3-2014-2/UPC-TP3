using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class SolicitudConfiguration : EntityTypeConfiguration<Solicitud>
    {
        public SolicitudConfiguration()
        {
            ToTable("TA_SOLICITUDES");
            Property(s => s.Id)
                .HasColumnName("INT_CODIGOSOLICITUD");
            Property(s => s.Archivada)
                .HasColumnName("BLN_ARCHIVADA");
            Property(s => s.FechaRegistro)
                .HasColumnName("DTE_FECHAREGISTRO");
            Property(s => s.FechaResolucion)
                .HasColumnName("DTE_FECHARESOLUCION");
            Property(s => s.Estado)
                .HasColumnName("VCH_ESTADO");
            Property(s => s.Observaciones)
                .HasColumnName("VCH_OBSERVACIONES");
            Property(s => s.DetallesResolucion)
                .HasColumnName("VCH_DETALLESRESOLUCION");
        } 
    }
}