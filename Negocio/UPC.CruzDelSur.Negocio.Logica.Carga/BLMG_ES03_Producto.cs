using System.Collections.Generic;

namespace UPC.CruzDelSur.Negocio.Logica.Carga
{
    public class BLMG_ES03_Producto
    {
        public Conexion _Connection = new Conexion();

        public static List<BEMG_ES03_Producto> ListarMG_ES03_Producto(List<ParametroGenerico> _ArrayParam)
        {
            DAMG_ES03_Producto oDAMG_ES03_Producto = new DAMG_ES03_Producto();
            return oDAMG_ES03_Producto.ListarMG_ES03_Producto(null, _ArrayParam);
        }

        public static BEMG_ES03_Producto ListarUnoMG_ES03_Producto(List<ParametroGenerico> _ArrayParam)
        {
            DAMG_ES03_Producto oDAMG_ES03_Producto = new DAMG_ES03_Producto();
            return oDAMG_ES03_Producto.ListarUnoMG_ES03_Producto(null, _ArrayParam);
        }

    }
}
