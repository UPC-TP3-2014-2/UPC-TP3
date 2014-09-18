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
            Property(s => s.AreaId)
                .HasColumnName("INT_CODIGOAREA");
            Property(s => s.CargoId)
                .HasColumnName("INT_CODIGOCARGO");
            Property(s => s.Salario)
                .HasColumnName("DEC_SALARIO");
            Property(s => s.Inicio)
                .HasColumnName("VCH_INICIO");
            Property(s => s.Contrato)
                .HasColumnName("VCH_CONTRATO");
            Property(s => s.TipoEducacionId)
                .HasColumnName("INT_CODIGOTIPOEDUCACION");
            Property(s => s.EducacionDescripcion)
                .HasColumnName("VCH_EDUCACIONDESCRIPCION");
            Property(s => s.ExperienciaLaboral)
                .HasColumnName("VCH_EXPERIENCIALABORAL");
            Property(s => s.Funciones)
                .HasColumnName("VCH_FUNCIONES");
            Property(s => s.Requisitos)
                .HasColumnName("VCH_REQUISITOS");
        }
    }
}