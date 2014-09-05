using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UPC.CruzDelSur.Datos.Carga.Global;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class DAMG_ES01_FichaCarga
    {
        public Conexion _Connection = new Conexion();
        private SQL odaSQL = new SQL();
        private Funciones.Populate oPopulate = new Funciones.Populate();


        public int InsertarMG_ES01_FichaCarga(SqlConnection Cn, SqlTransaction Tr, BEMG_ES01_FichaCarga _BEMG_ES01_FichaCarga)
        {
            //return (odaSQL.fMan(Cn, Tr, "Pa_SEG_Permiso_Inserta", oBEPermiso, 1, "IdPermiso"));
            return Convert.ToInt32(odaSQL.InsertaActualizaElimina2(Cn, Tr, "USP_MG_ES01_FichaCarga_Insertar", _BEMG_ES01_FichaCarga, 0, "0", true));
        }
        public List<BEMG_ES01_FichaCarga> ListarMG_ES01_FichaCarga(SqlTransaction Tr, List<ParametroGenerico> _ArrayParam)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();
            List<BEMG_ES01_FichaCarga> loMG_ES03_Producto = new List<BEMG_ES01_FichaCarga>();
            using (Cn)
            {
                Cn.Open();
                //SqlDataReader drd = (odaSQL.fSelParametrosXArray(Cn, Tr, "Pa_SEG_Permiso_Lista_x_IdOpcion_x_Anulado_Paginado", _ArrayParam));
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReaderArrayParametros(Cn, Tr, "USP_MG_ES01_FichaCarga_Listar", _ArrayParam));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                loMG_ES03_Producto.Add(oPopulate.SetBEMG_ES01_FichaCarga(drd));
                            }
                        }
                    }
                }
                return (loMG_ES03_Producto);
            }
        }
        public BEMG_ES01_FichaCarga ListarUnoMG_ES01_FichaCarga(SqlTransaction Tr, List<ParametroGenerico> _ArrayParam)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();
            BEMG_ES01_FichaCarga loMG_ES03_Producto = new BEMG_ES01_FichaCarga();
            using (Cn)
            {
                Cn.Open();
                //SqlDataReader drd = (odaSQL.fSelParametrosXArray(Cn, Tr, "Pa_SEG_Permiso_Lista_x_IdOpcion_x_Anulado_Paginado", _ArrayParam));
                SqlDataReader drd = (odaSQL.ObtenerVariosRegistrosDataReaderArrayParametros(Cn, Tr, "USP_MG_ES01_FichaCarga_ListarUno", _ArrayParam));
                if (drd != null)
                {
                    if (drd.HasRows)
                    {
                        if (drd.HasRows)
                        {
                            if (drd.Read())
                            {
                                loMG_ES03_Producto = oPopulate.SetBEMG_ES01_FichaCarga(drd);
                            }
                        }
                    }
                }
                return (loMG_ES03_Producto);
            }
        }

    }
}
