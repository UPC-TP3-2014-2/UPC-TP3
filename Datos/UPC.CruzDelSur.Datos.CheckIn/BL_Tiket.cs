using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;

namespace UPC.CruzDelSur.Datos.CheckIn
{
    public class BL_Tiket: IBL_Tiket
    {
        public List<BE_Tiket> f_listarTiket()
        {
            List<BE_Tiket> lst = new List<BE_Tiket>();
            SqlParameter[] param = new SqlParameter[0];

            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_TIKETCONSULTAR");
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                BE_Tiket objTiket = new BE_Tiket();
                //asign values
                objTiket.Codigo = dr["INT_CODEQUIPAJE"].ToString();
                objTiket.Numero = dr["CHR_NUMEROEQUIPAJE"].ToString();
                objTiket.Peso = dr["DEC_PESO"].ToString();
                objTiket.Tamano = dr["CHR_TAMANO"].ToString();
                objTiket.CodBarra = dr["CHR_CODIGOBARRAS"].ToString();
                objTiket.EstadoEquipaje = dr["VCH_ESTADOEQUIPAJE"].ToString();
                objTiket.TipoEtiqueta = dr["VCH_NOMBREETIQUETA"].ToString();
                //add one row to the list
                lst.Add(objTiket);
            }
            return lst;
        }
    }
}
