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
    public class Producto : IProductoRepositorio
    {
        public List<UPC.CruzDelSur.Negocio.Modelo.Carga.Producto> f_ListadoProducto(String pVCH_DESCRIPCION)
        {
            List<UPC.CruzDelSur.Negocio.Modelo.Carga.Producto> lst = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.Producto>();


            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@VCH_DESCRIPCION ", SqlDbType.VarChar);
            param[0].Value = pVCH_DESCRIPCION;
            param[0].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARPRODUCTO",param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                UPC.CruzDelSur.Negocio.Modelo.Carga.Producto objProducto = new UPC.CruzDelSur.Negocio.Modelo.Carga.Producto();
                //asign values
                if (DBNull.Value != dr["INT_CODIGO_PRODUCTO"])
                    objProducto.CODIGO_PRODUCTO = Int32.Parse( dr["INT_CODIGO_PRODUCTO"].ToString());
                if (DBNull.Value != dr["VCH_NOMBRE"])
                    objProducto.NOMBRE= dr["VCH_NOMBRE"].ToString();
                if (DBNull.Value != dr["VCH_DESCRIPCION"])
                    objProducto.DESCRIPCION = dr["VCH_DESCRIPCION"].ToString();
                if (DBNull.Value != dr["DBL_PRECIO"])
                    objProducto.PRECIO= Double.Parse(dr["DBL_PRECIO"].ToString());
                //add one row to the list
                lst.Add(objProducto);
            }
            return lst;
        }

        public UPC.CruzDelSur.Negocio.Modelo.Carga.Producto f_ListadoUnoProducto(int pCODIGO_PRODUCTO)
        {
            UPC.CruzDelSur.Negocio.Modelo.Carga.Producto objProducto = new UPC.CruzDelSur.Negocio.Modelo.Carga.Producto();


            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@INT_CODIGO_PRODUCTO ", SqlDbType.Int);
            param[0].Value = pCODIGO_PRODUCTO;
            param[0].Direction = ParameterDirection.Input;
            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARUNOPRODUCTO", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                //asign values
                if (DBNull.Value != dr["INT_CODIGO_PRODUCTO"])
                    objProducto.CODIGO_PRODUCTO = Int32.Parse(dr["INT_CODIGO_PRODUCTO"].ToString());
                if (DBNull.Value != dr["VCH_NOMBRE"])
                    objProducto.NOMBRE = dr["VCH_NOMBRE"].ToString();
                if (DBNull.Value != dr["VCH_DESCRIPCION"])
                    objProducto.DESCRIPCION = dr["VCH_DESCRIPCION"].ToString();
                if (DBNull.Value != dr["DBL_PRECIO"])
                    objProducto.PRECIO = Double.Parse(dr["DBL_PRECIO"].ToString());
                //add one row to the list
                
            }
            return objProducto;
        }

    }
}
