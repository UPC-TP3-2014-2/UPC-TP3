using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Negocio.Modelo.Carga;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class DetalleCarga : IDetalleCargaRepositorio
    {
        public List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga> f_ListaDetalleCarga(Int32 pCODIGO_CARGA)
        {
            List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga> list = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga>();

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@INT_CODIGO_CARGA", SqlDbType.Int);
            param[0].Value = pCODIGO_CARGA;
            param[0].Direction = ParameterDirection.Input;



            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTADETALLECARGA", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga objDetalleCarga = new UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga();
                //asign values
                if (DBNull.Value != dr["INT_CODIGO_CARGA"])
                    objDetalleCarga.CODIGO_CARGA = Int32.Parse(dr["INT_CODIGO_CARGA"].ToString());

                if (DBNull.Value != dr["INT_CODIGO_PRODUCTO"])
                    objDetalleCarga.CODIGO_PRODUCTO = Int32.Parse( dr["INT_CODIGO_PRODUCTO"].ToString());

                if (DBNull.Value != dr["VCH_DESCRIPCION"])
                    objDetalleCarga.DESCRIPCION  = dr["VCH_DESCRIPCION"].ToString();

                if (DBNull.Value != dr["INT_TIPO_CARGA"])
                    objDetalleCarga.TIPO_CARGA= Int32.Parse( dr["INT_TIPO_CARGA"].ToString());

                if (DBNull.Value != dr["INT_CANTIDAD"])
                    objDetalleCarga.CANTIDAD= Int32.Parse(dr["INT_CANTIDAD"].ToString());

                if (DBNull.Value != dr["DBL_PESO"])
                    objDetalleCarga.DBL_PESO = Double .Parse(dr["DBL_PESO"].ToString());

                if (DBNull.Value != dr["DBL_IMPORTE"])
                    objDetalleCarga.DBL_IMPORTE  = Double.Parse( dr["DBL_IMPORTE"].ToString());



                if (DBNull.Value != dr["DBL_PRECIO"])
                    objDetalleCarga.PRECIO = Double.Parse(dr["DBL_PRECIO"].ToString());



                list.Add(objDetalleCarga);


            }
            return list;
        }
    }
}
