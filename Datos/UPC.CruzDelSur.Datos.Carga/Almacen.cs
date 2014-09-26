using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CruzDelSur.Negocio.Modelo.Carga;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class Almacen
    {
        public List<UPC.CruzDelSur.Negocio.Modelo.Carga.Almacen> f_ListadoAlmacen()
        {
            List<UPC.CruzDelSur.Negocio.Modelo.Carga.Almacen> lst = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.Almacen>();




            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARALMACEN");
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                UPC.CruzDelSur.Negocio.Modelo.Carga.Almacen objAlmacen = new UPC.CruzDelSur.Negocio.Modelo.Carga.Almacen();
                //asign values

                if (DBNull.Value != dr["INT_CODIGO_ALMACEN"])
                    objAlmacen.CODIGO_ALMACEN = dr["INT_CODIGO_ALMACEN"].ToString();

                if (DBNull.Value != dr["VCH_NOMBRE"])
                    objAlmacen.NOMBRE = dr["VCH_NOMBRE"].ToString();


                lst.Add(objAlmacen);
            }
            return lst;
        }
    }
}
