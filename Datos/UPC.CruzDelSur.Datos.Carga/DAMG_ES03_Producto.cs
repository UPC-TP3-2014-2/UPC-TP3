using System.Collections.Generic;
using System.Data.SqlClient;
using UPC.CruzDelSur.Datos.Carga.Global;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class DAMG_ES03_Producto
    {

        public Conexion _Connection = new Conexion();
        private SQL odaSQL = new SQL();
        private Funciones.Populate oPopulate = new Funciones.Populate();

        public List< BEMG_ES03_Producto> ListarMG_ES03_Producto(SqlTransaction Tr, List<ParametroGenerico> _ArrayParam)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();
            List<BEMG_ES03_Producto> loMG_ES03_Producto = new List<BEMG_ES03_Producto>();
            using (Cn)
            {
                Cn.Open();
                //SqlDataReader drd = (odaSQL.fSelParametrosXArray(Cn, Tr, "Pa_SEG_Permiso_Lista_x_IdOpcion_x_Anulado_Paginado", _ArrayParam));
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReaderArrayParametros(Cn, Tr, "USP_MG_ES03_Producto_Listar", _ArrayParam));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                loMG_ES03_Producto.Add(oPopulate.SetMG_ES03_Producto(drd));
                            }
                        }
                    }
                }
                return (loMG_ES03_Producto);
            }
        }
        public BEMG_ES03_Producto ListarUnoMG_ES03_Producto(SqlTransaction Tr, List<ParametroGenerico> _ArrayParam)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();
            BEMG_ES03_Producto loMG_ES03_Producto = new BEMG_ES03_Producto();
            using (Cn)
            {
                Cn.Open();
                //SqlDataReader drd = (odaSQL.fSelParametrosXArray(Cn, Tr, "Pa_SEG_Permiso_Lista_x_IdOpcion_x_Anulado_Paginado", _ArrayParam));
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReaderArrayParametros(Cn, Tr, "USP_MG_ES03_Producto_ListarUno", _ArrayParam));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        if (drd.HasRows)
                        {
                            if (drd.Read())
                            {
                                loMG_ES03_Producto= oPopulate.SetMG_ES03_Producto(drd);
                            }
                        }
                    }
                }
                return (loMG_ES03_Producto);
            }
        } 

    }
}
