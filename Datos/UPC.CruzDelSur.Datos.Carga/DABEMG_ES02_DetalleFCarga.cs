using System;
using System.Data.SqlClient;
using UPC.CruzDelSur.Datos.Carga.Global;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class DABEMG_ES02_DetalleFCarga
    {
        public Conexion _Connection = new Conexion();
        private SQL odaSQL = new SQL();
        private Funciones.Populate oPopulate = new Funciones.Populate();
        //        public int InsertarMG_ES02_DetalleFCarga(Conexion Cn, SqlTransaction Tr, BEBitactora _BEMG_ES02_DetalleFCarga, List<BEDetalleMG_ES02_DetalleFCarga> _loBEDetalleMG_ES02_DetalleFCarga) {

        public int InsertarMG_ES02_DetalleFCarga(SqlConnection Cn, SqlTransaction Tr, BEMG_ES02_DetalleFCarga _BEMG_ES02_DetalleFCarga)
        {
            //return (odaSQL.fMan(Cn, Tr, "Pa_SEG_Permiso_Inserta", oBEPermiso, 1, "IdPermiso"));
            return Convert.ToInt32(odaSQL.InsertaActualizaElimina(Cn, Tr, "USP_MG_ES02_DetalleFCarga_Insertar", _BEMG_ES02_DetalleFCarga, 0, "0", true));
        }
        public int EliminarMG_ES02_DetalleFCarga(SqlConnection Cn, SqlTransaction Tr, BEMG_ES02_DetalleFCarga _BEMG_ES02_DetalleFCarga)
        {
            //return (odaSQL.fMan(Cn, Tr, "Pa_SEG_Permiso_Inserta", oBEPermiso, 1, "IdPermiso"));
            return Convert.ToInt32(odaSQL.InsertaActualizaElimina(Cn, Tr, "USP_MG_ES02_DetalleFCarga_Eliminar", _BEMG_ES02_DetalleFCarga, 0, "0", true));
        }

    }
}
