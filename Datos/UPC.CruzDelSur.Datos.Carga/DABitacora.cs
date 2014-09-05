using System;
using System.Data.SqlClient;
using UPC.CruzDelSur.Datos.Carga.Global;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class DABitacora
    {
        public Conexion _Connection = new Conexion();
        private SQL odaSQL = new SQL();
        private Funciones.Populate oPopulate = new Funciones.Populate();
        //        public int InsertarBitacora(Conexion Cn, SqlTransaction Tr, BEBitactora _BEBitacora, List<BEDetalleBitacora> _loBEDetalleBitacora) {

        public int InsertarBitacora(SqlConnection Cn, SqlTransaction Tr, BEBitacora _BEBitacora)
        {
            //return (odaSQL.fMan(Cn, Tr, "Pa_SEG_Permiso_Inserta", oBEPermiso, 1, "IdPermiso"));
            return Convert.ToInt32(odaSQL.InsertaActualizaElimina(Cn, Tr, "SP_INSERTAR_BITACORA", _BEBitacora, 0, "0", true));
        }
    }
}
