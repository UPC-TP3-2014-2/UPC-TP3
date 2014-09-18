using System.Data.Entity.ModelConfiguration;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.Configuracion
{
    public class TipoEducacionConfiguration : EntityTypeConfiguration<TipoEducacion>
    {
        public TipoEducacionConfiguration()
        {
            ToTable("TA_TIPOSEDUCACION");
            Property(t => t.Id)
                .HasColumnName("INT_CODIGOTIPOEDUCACION");
            Property(t => t.Nombre)
                .HasColumnName("VCH_NOMBRE");
        }
    }
}