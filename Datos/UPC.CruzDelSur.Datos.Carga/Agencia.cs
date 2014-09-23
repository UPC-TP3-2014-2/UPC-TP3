using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CruzDelSur.Negocio.Modelo.Carga;

namespace UPC.CruzDelSur.Datos.Carga
{
    public  class Agencia
    {
        public List<UPC.CruzDelSur.Negocio.Modelo.Carga.Agencia> f_ListadoAgencia()
        {
            List<UPC.CruzDelSur.Negocio.Modelo.Carga.Agencia> lst = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.Agencia>();




            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARAGENCIA");
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                UPC.CruzDelSur.Negocio.Modelo.Carga.Agencia objAgencia = new UPC.CruzDelSur.Negocio.Modelo.Carga.Agencia();
                //asign values

                if (DBNull.Value != dr["INT_CODIGO_AGENCIA"])
                    objAgencia.CODIGO_AGENCIA= dr["INT_CODIGO_AGENCIA"].ToString();

                if (DBNull.Value != dr["VCH_NOMBRE"])
                    objAgencia.NOMBRE= dr["VCH_NOMBRE"].ToString();


                lst.Add(objAgencia);
            }
            return lst;
        }
    }
}
