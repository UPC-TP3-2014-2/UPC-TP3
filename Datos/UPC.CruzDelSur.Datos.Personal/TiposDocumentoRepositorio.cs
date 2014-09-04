using System.Data.Entity;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class TiposDocumentoRepositorio : Repositorio<TipoDocumento>, ITiposDocumentoRepositorio
    {
        public TiposDocumentoRepositorio(DbContext context) : base(context)
        {
        }
    }
}