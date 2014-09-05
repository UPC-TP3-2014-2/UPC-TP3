using System.Collections.Generic;
using System.Data.SqlClient;
using UPC.CruzDelSur.Datos.Carga.Global;

namespace UPC.CruzDelSur.Datos.Carga
{


    public class DAProgramacionRuta
    {

        public Conexion _Connection = new Conexion();
        private SQL odaSQL = new SQL();
        private Funciones.Populate oPopulate = new Funciones.Populate();

        public List<BERuta> ListarRutasXVehiculo(SqlTransaction Tr, List<ParametroGenerico> _ArrayParam)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();
            List<BERuta> loBERuta = new List<BERuta>();
            using (Cn)
            {
                Cn.Open();
                //SqlDataReader drd = (odaSQL.fSelParametrosXArray(Cn, Tr, "Pa_SEG_Permiso_Lista_x_IdOpcion_x_Anulado_Paginado", _ArrayParam));
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReaderArrayParametros(Cn, Tr, "SP_LISTAR_RUTA_X_VEHICULO", _ArrayParam));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                loBERuta.Add(oPopulate.setBERuta(drd));
                            }
                        }
                    }
                }
                return (loBERuta);
            }
        } 

    }
}
