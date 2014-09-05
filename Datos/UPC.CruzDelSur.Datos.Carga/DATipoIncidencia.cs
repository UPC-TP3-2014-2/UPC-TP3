using System.Collections.Generic;
using System.Data.SqlClient;
using UPC.CruzDelSur.Datos.Carga.Global;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class DATipoIncidencia
    {
        public Conexion _Connection = new Conexion();
        private SQL odaSQL = new SQL();
        private Funciones.Populate oPopulate = new Funciones.Populate();

        public List<BETipoIncidencia> ListarTipoIncidencia(SqlTransaction Tr)
        {
            SqlConnection Cn = new SqlConnection();
            Cn = _Connection.ConexionCruzDelSur();

            List<BETipoIncidencia> loBETipoIncidencia = new List<BETipoIncidencia>();
            using (Cn)
            {
                Cn.Open();

                //ObtenerVariosRegistrosDataReader (conexion, transaccion, storedprocedure,objetoconparametros,ponerfalse)
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReader(Cn, Tr, "SP_LISTARTIPOINCIDENCIA", null,false));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        while (drd.Read())
                        {
                            loBETipoIncidencia.Add(oPopulate.setBETipoIncidencia(drd));
                        }
                    }
                }
                return (loBETipoIncidencia);
            }
        }

    }
}
