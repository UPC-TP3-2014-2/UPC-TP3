using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class TipoDocumentoConfiguration : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoConfiguration()
        {
            ToTable("TA_TIPOSDOCUMENTO");
            Property(t => t.Id)
                .HasColumnName("INT_CODIGOTIPODOCUMENTO");
            Property(t => t.Nombre)
                .HasColumnName("VCH_NOMBRE");
        }
    }
}