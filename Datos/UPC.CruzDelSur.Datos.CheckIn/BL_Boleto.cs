using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Datos.CheckIn;
using System.Data.SqlClient;
using System.Data;
using UPC.CruzDelSur.Datos.CheckIn.Interface;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
namespace UPC.CruzDelSur.Datos.CheckIn
{
    public class BL_Boleto : IBL_Boleto
    {
        public List<BE_Boleto> f_ListadoBoleto(String nroboleto, string dni)
        {
            List<BE_Boleto> lst = new List<BE_Boleto>();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("pNROBOLETO", SqlDbType.VarChar);
            param[0].Value = nroboleto;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("pDNI", SqlDbType.VarChar);
            param[1].Value = dni;
            param[1].Direction = ParameterDirection.Input;
            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_BOLETOCONSULTAR", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                BE_Boleto objBoleto = new BE_Boleto();
                //asign values
               
                objBoleto.NroBoleto = dr["CHR_NUMEROBOLETO"].ToString();
                objBoleto.Pasajero = dr["Pasajero"].ToString();
                objBoleto.Precio = dr["DEC_PRECIOPASAJE"].ToString();
                objBoleto.Placa = dr["VCH_PLACA"].ToString();
                objBoleto.TipoServicio = dr["VCH_NOMBRE"].ToString();
                objBoleto.Origen = dr["VCH_ORIGEN"].ToString();
                objBoleto.Destino = dr["VCH_DESTINO"].ToString();
                objBoleto.FechaSalida = dr["FechaSalida"].ToString();
                objBoleto.HoraSalida = dr["HoraSalida"].ToString();
                objBoleto.Asiento = dr["CHR_ASIENTO"].ToString();
                objBoleto.EstadoAsiento = dr["VCH_DETESTASIENTO"].ToString();
                objBoleto.Ubicacion = dr["VCH_UBICACION"].ToString();
                objBoleto.Chofer = dr["Chofer"].ToString();
                objBoleto.FechaActual = dr["FechaActual"].ToString();
                objBoleto.HoraActual = dr["HoraActual"].ToString();
                objBoleto.CodVehiculo = dr["INT_VEHICULO"].ToString();
                objBoleto.EstadoCheckin = dr["ESTADO_CHECKIN"].ToString();
                objBoleto.EstadoHora = dr["ESTADO_HORA"].ToString();
                //add one row to the list
                lst.Add(objBoleto);
            }
            return lst;
        }
        public List<BE_Boleto> f_CheckIn(String nroboleto)
        {
            List<BE_Boleto> lst = new List<BE_Boleto>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("pNROBOLETO", SqlDbType.VarChar);
            param[0].Value = nroboleto;
            param[0].Direction = ParameterDirection.Input;
            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_BOLETOCHECKIN", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                BE_Boleto objBoleto = new BE_Boleto();
                //asign values
                objBoleto.NroBoleto = dr["CHR_NUMEROBOLETO"].ToString();
                objBoleto.Pasajero = dr["Pasajero"].ToString();
                objBoleto.Precio = dr["DEC_PRECIOPASAJE"].ToString();
                objBoleto.Placa = dr["VCH_PLACA"].ToString();
                objBoleto.TipoServicio = dr["VCH_NOMBRE"].ToString();
                objBoleto.Origen = dr["VCH_ORIGEN"].ToString();
                objBoleto.Destino = dr["VCH_DESTINO"].ToString();
                objBoleto.FechaSalida = dr["FechaSalida"].ToString();
                objBoleto.HoraSalida = dr["HoraSalida"].ToString();
                objBoleto.Asiento = dr["CHR_ASIENTO"].ToString();
                objBoleto.EstadoAsiento = dr["VCH_DETESTASIENTO"].ToString();
                objBoleto.Ubicacion = dr["VCH_UBICACION"].ToString();
                objBoleto.Chofer = dr["Chofer"].ToString();
                objBoleto.FechaActual = dr["FechaActual"].ToString();
                objBoleto.HoraActual = dr["HoraActual"].ToString();
                objBoleto.CodVehiculo = dr["INT_VEHICULO"].ToString();
                objBoleto.EstadoCheckin = dr["ESTADO_CHECKIN"].ToString();
                objBoleto.EstadoHora = dr["ESTADO_HORA"].ToString();
                //add one row to the list
                lst.Add(objBoleto);
            }
            return lst;
        }
        public List<BE_Boleto> f_CancelarCheckIn(String nroboleto)
        {
            List<BE_Boleto> lst = new List<BE_Boleto>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("pNROBOLETO", SqlDbType.VarChar);
            param[0].Value = nroboleto;
            param[0].Direction = ParameterDirection.Input;
            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_BOLETOCANCELARCHECKIN", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                BE_Boleto objBoleto = new BE_Boleto();
                //asign values
                objBoleto.NroBoleto = dr["CHR_NUMEROBOLETO"].ToString();
                objBoleto.Pasajero = dr["Pasajero"].ToString();
                objBoleto.Precio = dr["DEC_PRECIOPASAJE"].ToString();
                objBoleto.Placa = dr["VCH_PLACA"].ToString();
                objBoleto.TipoServicio = dr["VCH_NOMBRE"].ToString();
                objBoleto.Origen = dr["VCH_ORIGEN"].ToString();
                objBoleto.Destino = dr["VCH_DESTINO"].ToString();
                objBoleto.FechaSalida = dr["FechaSalida"].ToString();
                objBoleto.HoraSalida = dr["HoraSalida"].ToString();
                objBoleto.Asiento = dr["CHR_ASIENTO"].ToString();
                objBoleto.EstadoAsiento = dr["VCH_DETESTASIENTO"].ToString();
                objBoleto.Ubicacion = dr["VCH_UBICACION"].ToString();
                objBoleto.Chofer = dr["Chofer"].ToString();
                objBoleto.FechaActual = dr["FechaActual"].ToString();
                objBoleto.HoraActual = dr["HoraActual"].ToString();
                objBoleto.CodVehiculo = dr["INT_VEHICULO"].ToString();
                objBoleto.EstadoCheckin = dr["ESTADO_CHECKIN"].ToString();
                objBoleto.EstadoHora = dr["ESTADO_HORA"].ToString();
                //add one row to the list
                lst.Add(objBoleto);
            }
            return lst;
        }
        public List<BE_Boleto> f_ConsultarAsientosVehiculo(int CodVehiculo)
        {
            List<BE_Boleto> lst = new List<BE_Boleto>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("pCodVehiculo", SqlDbType.Int);
            param[0].Value = CodVehiculo;
            param[0].Direction = ParameterDirection.Input;
            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_ASIENTOSVEHICULO", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                BE_Boleto objBoleto = new BE_Boleto();
                //asign values
                objBoleto.CodVehiculo = dr["INT_VEHICULO"].ToString();
                objBoleto.Placa = dr["VCH_PLACA"].ToString();
                objBoleto.FechaSalida = dr["FechaSalida"].ToString();
                objBoleto.HoraSalida = dr["HoraSalida"].ToString();
                objBoleto.Asiento = dr["CHR_ASIENTO"].ToString();
                objBoleto.EstadoAsiento = dr["VCH_DETESTASIENTO"].ToString();
                //add one row to the list
                lst.Add(objBoleto);
            }
            return lst;
        }
        public BE_Boleto f_ActualizarAsiento(string nroboleto, string nroasiento, string nroasientol)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("CHR_NUMEROBOLETO", SqlDbType.VarChar);
            param[0].Value = nroboleto;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("CHR_ASIENTO", SqlDbType.VarChar);
            param[1].Value = nroasiento;
            param[1].Direction = ParameterDirection.Input;
            param[2] = new SqlParameter("CHR_ASIENTO_L", SqlDbType.VarChar);
            param[2].Value = nroasientol;
            param[2].Direction = ParameterDirection.Input;
            
            SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_BOLETOACTUALIZARASIENTO", param);
            return new BE_Boleto();
        }
    }
}