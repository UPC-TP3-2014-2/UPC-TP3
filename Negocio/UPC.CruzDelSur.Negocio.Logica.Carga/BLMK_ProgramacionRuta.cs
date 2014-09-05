using System.Collections.Generic;

namespace UPC.CruzDelSur.Negocio.Logica.Carga
{
    public class BLMK_ProgramacionRuta
    {
        public Conexion _Connection = new Conexion();



        public static List<BEMK_ProgramacionRuta> ListarMK_ProgramacionRuta(List<ParametroGenerico> _ArrayParam)
        {
            DAMK_ProgramacionRuta oDAMK_ProgramacionRuta = new DAMK_ProgramacionRuta();
            
            return oDAMK_ProgramacionRuta.ListarMK_ProgramacionRuta(null, _ArrayParam);
        }
        public static BEMK_ProgramacionRuta ListarUnoMK_ProgramacionRuta(List<ParametroGenerico> _ArrayParam)
        {
            DAMK_ProgramacionRuta oDAMK_ProgramacionRuta = new DAMK_ProgramacionRuta();
            return oDAMK_ProgramacionRuta.ListarUnoMK_ProgramacionRuta(null, _ArrayParam);
        }
    }
}
