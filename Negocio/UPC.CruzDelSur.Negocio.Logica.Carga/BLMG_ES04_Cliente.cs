using System.Collections.Generic;

namespace UPC.CruzDelSur.Negocio.Logica.Carga
{
    public class BLMG_ES04_Cliente
    {
        public Conexion _Connection = new Conexion();



        public static List<BEMG_ES04_Cliente> ListarMG_ES04_Cliente(List<ParametroGenerico> _ArrayParam)
        {
            DAMG_ES04_Cliente oDAMG_ES04_Cliente = new DAMG_ES04_Cliente();
            return oDAMG_ES04_Cliente.ListarMG_ES04_Cliente(null, _ArrayParam);
        }
        public static BEMG_ES04_Cliente ListarUnoMG_ES04_Cliente(List<ParametroGenerico> _ArrayParam)
        {
            DAMG_ES04_Cliente oDAMG_ES04_Cliente = new DAMG_ES04_Cliente();
            return oDAMG_ES04_Cliente.ListarUnoMG_ES04_Cliente(null, _ArrayParam);
        }
    }
}
