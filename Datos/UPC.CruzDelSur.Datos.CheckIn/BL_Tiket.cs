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


        public int f_RegistrarFilmacion(List<BE_Tiket> lista)
        {
            int valor = 0;

            foreach (BE_Tiket objeto in lista)
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("codigoBoleto ", SqlDbType.Int);
                param[0].Value = objeto.CodBoleto;
                param[0].Direction = ParameterDirection.Input;
                param[1] = new SqlParameter("codigoEtiqueta", SqlDbType.Int);
                param[1].Value = int.Parse(objeto.TipoEtiqueta);
                param[1].Direction = ParameterDirection.Input;
                param[2] = new SqlParameter("nroEquipaje", SqlDbType.VarChar);
                param[2].Value = objeto.Numero;
                param[2].Direction = ParameterDirection.Input;
                param[3] = new SqlParameter("peso", SqlDbType.Decimal);
                param[3].Value = objeto.Peso;
                param[3].Direction = ParameterDirection.Input;
                param[4] = new SqlParameter("tamaño", SqlDbType.VarChar);
                param[4].Value = objeto.Tamano;
                param[4].Direction = ParameterDirection.Input;
                param[5] = new SqlParameter("precio", SqlDbType.Decimal);
                param[5].Value = 12;
                param[5].Direction = ParameterDirection.Input;
                param[6] = new SqlParameter("ubicacion", SqlDbType.VarChar);
                param[6].Value = objeto.ubicacion;
                param[6].Direction = ParameterDirection.Input;
                param[7] = new SqlParameter("codigoBarra", SqlDbType.VarChar);
                param[7].Value = objeto.CodBarra;
                param[7].Direction = ParameterDirection.Input;
                param[8] = new SqlParameter("estado", SqlDbType.VarChar);
                param[8].Value = "POR CONFIRMAR";
                param[8].Direction = ParameterDirection.Input;
                param[9] = new SqlParameter("bln_activo", SqlDbType.Bit);
                param[9].Value = 1;
                param[9].Direction = ParameterDirection.Input;

               valor= SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_INSERTARTIKET", param);
            }


            return valor;
        }
    }
}
