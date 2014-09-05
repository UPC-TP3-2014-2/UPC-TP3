using System.Collections.Generic;
using System.Data.SqlClient;
using UPC.CruzDelSur.Datos.Carga.Global;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class DAMK_ProgramacionRuta
    {
        public Conexion _Connection = new Conexion();
        private SQL odaSQL = new SQL();
        private Funciones.Populate oPopulate = new Funciones.Populate();



        public List<BEMK_ProgramacionRuta> ListarMK_ProgramacionRuta(SqlTransaction Tr, List<ParametroGenerico> _ArrayParam)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();
            List<BEMK_ProgramacionRuta> loMK_ProgramacionRuta = new List<BEMK_ProgramacionRuta>();
            using (Cn)
            {
                Cn.Open();
                //SqlDataReader drd = (odaSQL.fSelParametrosXArray(Cn, Tr, "Pa_SEG_Permiso_Lista_x_IdOpcion_x_Anulado_Paginado", _ArrayParam));
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReaderArrayParametros(Cn, Tr, "USP_MK_ProgramacionRuta_ListarPorAgencia", _ArrayParam));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                loMK_ProgramacionRuta.Add(oPopulate.SetMK_ProgramacionRuta(drd));
                            }
                        }
                    }
                }
                return (loMK_ProgramacionRuta);
            }
        }
        public BEMK_ProgramacionRuta ListarUnoMK_ProgramacionRuta(SqlTransaction Tr, List<ParametroGenerico> _ArrayParam)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();
            BEMK_ProgramacionRuta loMK_ProgramacionRuta = new BEMK_ProgramacionRuta();
            using (Cn)
            {
                Cn.Open();
                //SqlDataReader drd = (odaSQL.fSelParametrosXArray(Cn, Tr, "Pa_SEG_Permiso_Lista_x_IdOpcion_x_Anulado_Paginado", _ArrayParam));
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReaderArrayParametros(Cn, Tr, "USP_MK_ProgramacionRuta_ListarUno", _ArrayParam));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        if (drd.HasRows)
                        {
                            if (drd.Read())
                            {
                                loMK_ProgramacionRuta = oPopulate.SetMK_ProgramacionRuta(drd);
                            }
                        }
                    }
                }
                return (loMK_ProgramacionRuta);
            }
        } 
    }
}
