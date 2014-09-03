using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class CargoConfiguration : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguration()
        {
            ToTable("TA_CARGOS");
            Property(c => c.Id)
                .HasColumnName("INT_CODIGOCARGO");
            Property(c => c.Nombre)
                .HasColumnName("VCH_NOMBRE");
        }
    }
}