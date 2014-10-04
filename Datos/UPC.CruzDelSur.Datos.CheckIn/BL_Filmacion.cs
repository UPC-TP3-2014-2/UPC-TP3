using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
namespace UPC.CruzDelSur.Datos.CheckIn
{
    public class BL_Filmacion : IBL_Filmacion
    {


        public List<BE_Filmacion> f_ListadoFilmaciones(DateTime fechaInicio, string estado)
        {

            List<BE_Filmacion> lst = new List<BE_Filmacion>();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("DTM_FECHA_DESDE", SqlDbType.DateTime);
            param[0].Value = fechaInicio;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("ESTADO", SqlDbType.VarChar);
            param[1].Value = estado;
            param[1].Direction = ParameterDirection.Input;


            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_CONSULTARFILMACION", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                BE_Filmacion objBoleto = new BE_Filmacion();
                //asign values
                objBoleto.FechaActual = dr["DTM_FECHA_ORIGEN"].ToString();
                objBoleto.HoraSalida = dr["TIM_HORA_SALIDA"].ToString();
                objBoleto.CodSalida = dr["INT_CODIGO_PROGRAMACION_RUTA"].ToString();
                objBoleto.HoraDestino = dr["TIM_HORA_LLEGADA"].ToString();
                objBoleto.CantPasajeros = dr["CANTIDAD"].ToString();
                objBoleto.estado = dr["ESTADO"].ToString();
                objBoleto.solFilmacion = dr["INT_SOLICITUD"].ToString();
                objBoleto.MinGrab = dr["MINUTOS_GRABACION"].ToString();
                objBoleto.rutaVideo = dr["RUTA_VIDEO"].ToString();
                // objBoleto.estado = dr["estado"].ToString();
                lst.Add(objBoleto);
            }
            return lst;

        }




        public int f_RegistrarFilmacion(string codBus, string MinGrab, string rutaVideo, string estado)
        {


           
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("VCH_COD_SAL_BUS", SqlDbType.VarChar);
            param[0].Value = codBus;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("MIN_GRAB", SqlDbType.VarChar);
            param[1].Value = MinGrab;
            param[1].Direction = ParameterDirection.Input;
            param[2] = new SqlParameter("RUTA_VIDEO", SqlDbType.VarChar);
            param[2].Value = rutaVideo;
            param[2].Direction = ParameterDirection.Input;
            param[3] = new SqlParameter("ESTADO", SqlDbType.VarChar);
            param[3].Value = estado;
            param[3].Direction = ParameterDirection.Input;

            return SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_INSERTARFILMACION", param);


        }


        public int f_ActualizarFilmacion(string SolFilmacion, string MinGrab, string rutaVideo, string estado)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("INT_SOL_FILM", SqlDbType.VarChar);
            param[0].Value = SolFilmacion;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("MIN_GRAB", SqlDbType.VarChar);
            param[1].Value = MinGrab;
            param[1].Direction = ParameterDirection.Input;
            param[2] = new SqlParameter("RUTA_VIDEO", SqlDbType.VarChar);
            param[2].Value = rutaVideo;
            param[2].Direction = ParameterDirection.Input;
            param[3] = new SqlParameter("ESTADO", SqlDbType.VarChar);
            param[3].Value = estado;
            param[3].Direction = ParameterDirection.Input;

            return SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_ACTUALIZARFILMACION", param);

        }


    }
}
