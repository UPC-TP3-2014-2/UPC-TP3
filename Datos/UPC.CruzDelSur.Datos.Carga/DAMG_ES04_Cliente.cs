using System.Collections.Generic;
using System.Data.SqlClient;
using UPC.CruzDelSur.Datos.Carga.Global;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class DAMG_ES04_Cliente
    {
        public Conexion _Connection = new Conexion();
        private SQL odaSQL = new SQL();
        private Funciones.Populate oPopulate = new Funciones.Populate();



        public List<BEMG_ES04_Cliente> ListarMG_ES04_Cliente(SqlTransaction Tr, List<ParametroGenerico> _ArrayParam)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();
            List<BEMG_ES04_Cliente> loMG_ES04_Cliente = new List<BEMG_ES04_Cliente>();
            using (Cn)
            {
                Cn.Open();
                //SqlDataReader drd = (odaSQL.fSelParametrosXArray(Cn, Tr, "Pa_SEG_Permiso_Lista_x_IdOpcion_x_Anulado_Paginado", _ArrayParam));
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReaderArrayParametros(Cn, Tr, "USP_MG_ES04_Cliente_ListarPorDNI", _ArrayParam));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                loMG_ES04_Cliente.Add(oPopulate.SetMG_ES04_Cliente(drd));
                            }
                        }
                    }
                }
                return (loMG_ES04_Cliente);
            }
        }

        public BEMG_ES04_Cliente ListarUnoMG_ES04_Cliente(SqlTransaction Tr, List<ParametroGenerico> _ArrayParam)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();
            BEMG_ES04_Cliente loMG_ES04_Cliente = new BEMG_ES04_Cliente();
            using (Cn)
            {
                Cn.Open();
                //SqlDataReader drd = (odaSQL.fSelParametrosXArray(Cn, Tr, "Pa_SEG_Permiso_Lista_x_IdOpcion_x_Anulado_Paginado", _ArrayParam));
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReaderArrayParametros(Cn, Tr, "USP_MG_ES04_Cliente_ListarUno", _ArrayParam));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        if (drd.HasRows)
                        {
                            if (drd.Read())
                            {
                                loMG_ES04_Cliente=oPopulate.SetMG_ES04_Cliente(drd);
                            }
                        }
                    }
                }
                return (loMG_ES04_Cliente);
            }
        } 

    }
}
