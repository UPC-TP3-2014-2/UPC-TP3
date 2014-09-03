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
            Property(s => s.Especialidad)
                .HasColumnName("VCH_ESPECIALIDAD");
            Property(s => s.PersonaId)
                .HasColumnName("INT_CODIGOPERSONA");

            HasRequired(s => s.Persona)
                .WithMany()
                .HasForeignKey(s => s.PersonaId);
        }
    }

    public class EvaluacionDesempenoConfiguration : EntityTypeConfiguration<EvaluacionDesempeno>
    {
        public EvaluacionDesempenoConfiguration()
        {
            ToTable("TA_EVALUACIONESDESEMPENO");
            Property(e => e.Id)
                .HasColumnName("INT_CODIGOEVALUACIONDESEMPENO");
            Property(e => e.Fecha)
                .HasColumnName("DTE_FECHA");
            Property(e => e.Nota)
                .HasColumnName("DEC_NOTA");
            Property(e => e.Observaciones)
                .HasColumnName("VCH_OBSERVACIONES");
            Property(e => e.EvaluadorId)
                .HasColumnName("INT_CODIGOEVALUADOR");
            Property(e => e.EvaluadoId)
                .HasColumnName("INT_CODIGOEVALUADO");

            HasRequired(e => e.Evaluador)
                .WithMany()
                .HasForeignKey(e => e.EvaluadorId)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Evaluado)
                .WithMany()
                .HasForeignKey(e => e.EvaluadoId)
                .WillCascadeOnDelete(false);
        } 
    }
}