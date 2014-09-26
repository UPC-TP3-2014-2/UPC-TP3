using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class CargoDesempenadoConfiguration : EntityTypeConfiguration<CargoDesempenado>
    {
        public CargoDesempenadoConfiguration()
        {
            ToTable("TA_CARGOSDESEMPENADOS");
            Property(c => c.Id)
                .HasColumnName("INT_CODIGOCARGODESEMPENADO");
            Property(c => c.PersonaId)
                .HasColumnName("INT_CODIGOPERSONA");
            Property(c => c.AreaId)
                .HasColumnName("INT_CODIGOAREA");
            Property(c => c.CargoId)
                .HasColumnName("INT_CODIGOCARGO");
            Property(c => c.Desde)
                .HasColumnName("DTE_DESDE");
            Property(c => c.Hasta)
                .HasColumnName("DTE_HASTA");

            HasRequired(c => c.Persona)
                .WithMany(p => p.CargosDesempenados)
                .HasForeignKey(c => c.PersonaId)
                .WillCascadeOnDelete(true);

            HasRequired(c => c.Area)
                .WithMany()
                .HasForeignKey(c => c.AreaId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Cargo)
                .WithMany()
                .HasForeignKey(c => c.CargoId)
                .WillCascadeOnDelete(false);
        }
    }
}