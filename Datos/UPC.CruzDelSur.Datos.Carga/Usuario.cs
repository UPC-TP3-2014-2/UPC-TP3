using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CruzDelSur.Negocio.Modelo.Carga;

namespace UPC.CruzDelSur.Datos.Carga
{
    public class Usuario
    {
        public String f_ValidaUsuario(String  pUsuario, String pclave)
        {
            UPC.CruzDelSur.Negocio.Modelo.Carga.Producto objProducto = new UPC.CruzDelSur.Negocio.Modelo.Carga.Producto();
            SqlParameter[] param = new SqlParameter[2];
            
            param[0] = new SqlParameter("@VCH_USUARIO", SqlDbType.VarChar);
            param[0].Value = pUsuario;
            param[0].Direction = ParameterDirection.Input;


            param[1] = new SqlParameter("@VCH_CLAVE", SqlDbType.VarChar);
            param[1].Value = pclave;
            param[1].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_VALIDAUSUARIO", param);

            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];

            String ROL = "";

            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                //asign values
                if (DBNull.Value != dr["ROL"])
                    ROL = dr["ROL"].ToString();
            }
            return ROL;
        }
    }
}
