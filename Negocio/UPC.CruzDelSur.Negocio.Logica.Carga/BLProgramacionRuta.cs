using System.Collections.Generic;

namespace UPC.CruzDelSur.Negocio.Logica.Carga
{
    public class BLProgramacionRuta
    {

        public Conexion _Connection = new Conexion();

        

        public static  List<BERuta> ListarRutasXVehiculo(List<ParametroGenerico> _ArrayParam)
        {
            DAProgramacionRuta oDAProgramacionRuta = new DAProgramacionRuta();
            return oDAProgramacionRuta.ListarRutasXVehiculo(null,_ArrayParam);
        }

    }
}
