using System.Collections.Generic;

namespace UPC.CruzDelSur.Negocio.Logica.Carga
{
    public class BLTipoIncidencia
    {
        public Conexion _Connection= new Conexion();

        DATipoIncidencia oDATipoIncidencia = new DATipoIncidencia();
         
        public List<BETipoIncidencia>ListarTipoIncidencia() {
            return oDATipoIncidencia.ListarTipoIncidencia(null);
        }

        
    }
}
