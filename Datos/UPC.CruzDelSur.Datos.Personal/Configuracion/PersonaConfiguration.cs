using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class PersonaConfiguration : EntityTypeConfiguration<Persona>
    {
        public PersonaConfiguration()
        {
            ToTable("TA_PERSONAS");
            Property(p => p.Id)
                .HasColumnName("INT_CODIGOPERSONA");
            Property(p => p.TipoDocumentoId)
                .HasColumnName("INT_CODIGOTIPODOCUMENTO");
            Property(p => p.NroDocumento)
                .HasColumnName("VCH_NUMERODOCUMENTO");
            Property(p => p.Nombre)
                .HasColumnName("VCH_NOMBRE");
            Property(p => p.Apellidos)
                .HasColumnName("VCH_APELLIDOS");
            Property(p => p.FechaNacimiento)
                .HasColumnName("DTE_FECHANACIMIENTO");
            Property(p => p.Foto)
                .HasColumnName("VCH_FOTO");
            Property(p => p.Direccion)
                .HasColumnName("VCH_DIRECCION");
            Property(p => p.Telefono)
                .HasColumnName("VCH_TELEFONO");
            Property(p => p.CargoId)
                .HasColumnName("INT_CODIGOCARGO");
            
            HasRequired(p => p.TipoDocumento)
                .WithMany()
                .HasForeignKey(p => p.TipoDocumentoId);

            HasRequired(p => p.Cargo)
                .WithMany()
                .HasForeignKey(p => p.CargoId);

            HasMany(p => p.DetallesHojaVida)
                .WithRequired(d => d.Persona)
                .HasForeignKey(d => d.PersonaId)
                .WillCascadeOnDelete(true);
        }
    }
}