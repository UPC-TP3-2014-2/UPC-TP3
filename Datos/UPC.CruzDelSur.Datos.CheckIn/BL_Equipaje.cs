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
   public class BL_Equipaje: IBL_Equipaje
    {

       public List<BE_Equipaje> f_listarEquipajeBoleto(String nroboleto, string dni)
       {
           List<BE_Equipaje> lst = new List<BE_Equipaje>();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("pNROBOLETO", SqlDbType.VarChar);
           param[0].Value = nroboleto;
           param[0].Direction = ParameterDirection.Input;
           param[1] = new SqlParameter("pDNI", SqlDbType.VarChar);
           param[1].Value = dni;
           param[1].Direction = ParameterDirection.Input;

           DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_EQUIPAJECONSULTAR", param);
           int ColumnCount = ds.Tables.Count;
           DataTable dt = ds.Tables[0];
           foreach (DataRow dr in dt.Rows)
           {
               //Object of the propery class
               BE_Equipaje objEquipaje = new BE_Equipaje();
               //asign values
               objEquipaje.NroBoleto = dr["CHR_NUMEROBOLETO"].ToString();
               objEquipaje.Pasajero = dr["Pasajero"].ToString();
               objEquipaje.Peso = dr["DEC_PESO"].ToString();
               objEquipaje.Origen = dr["VCH_ORIGEN"].ToString();
               objEquipaje.Destino = dr["VCH_DESTINO"].ToString();
               objEquipaje.FechaSalida = dr["FechaSalida"].ToString();
               objEquipaje.HoraSalida = dr["HoraSalida"].ToString();
               objEquipaje.TipoEquipaje = dr["VCH_NOMBREETIQUETA"].ToString();
               objEquipaje.Ubicacion = dr["VCH_UBICACION"].ToString();
               objEquipaje.FechaActual = dr["FechaActual"].ToString();
               objEquipaje.HoraActual = dr["HoraActual"].ToString();
               objEquipaje.EstadoEquipaje = dr["VCH_ESTADOEQUIPAJE"].ToString();
               objEquipaje.CodBoleto = Convert.ToInt32(dr["INT_CODIGOBOLETO"]);
               
               //add one row to the list
               lst.Add(objEquipaje);
           }
           return lst;
       }



       public List<BE_Equipaje> f_verificarEquipajeBoleto(String nroboleto, string dni)
       {
           List<BE_Equipaje> lst = new List<BE_Equipaje>();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("pNROBOLETO", SqlDbType.VarChar);
           param[0].Value = nroboleto;
           param[0].Direction = ParameterDirection.Input;
           param[1] = new SqlParameter("pDNI", SqlDbType.VarChar);
           param[1].Value = dni;
           param[1].Direction = ParameterDirection.Input;

           DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_EQUIPAJEVERIFICAR", param);
           int ColumnCount = ds.Tables.Count;
           DataTable dt = ds.Tables[0];
           foreach (DataRow dr in dt.Rows)
           {
               //Object of the propery class
               BE_Equipaje objEquipaje = new BE_Equipaje();
               //asign values
               objEquipaje.NroBoleto = dr["CHR_NUMEROBOLETO"].ToString();
               objEquipaje.Pasajero = dr["Pasajero"].ToString();
               objEquipaje.Peso = dr["DEC_PESO"].ToString();
               objEquipaje.Origen = dr["VCH_ORIGEN"].ToString();
               objEquipaje.Destino = dr["VCH_DESTINO"].ToString();
               objEquipaje.FechaSalida = dr["FechaSalida"].ToString();
               objEquipaje.HoraSalida = dr["HoraSalida"].ToString();
               objEquipaje.TipoEquipaje = dr["VCH_NOMBREETIQUETA"].ToString();
               objEquipaje.Ubicacion = dr["VCH_UBICACION"].ToString();
               objEquipaje.FechaActual = dr["FechaActual"].ToString();
               objEquipaje.HoraActual = dr["HoraActual"].ToString();
               objEquipaje.EstadoEquipaje = dr["VCH_ESTADOEQUIPAJE"].ToString();
               objEquipaje.CodBoleto = Convert.ToInt32(dr["INT_CODIGOBOLETO"]);
               objEquipaje.EstadoVerificacion = dr["ESTADO_VERIFICACION"].ToString();
               
               //add one row to the list
               lst.Add(objEquipaje);
           }
           return lst;
       }

       public List<BE_Equipaje> f_actualizarEstadoEquipaje(String nroboleto, int accion)
       {
           List<BE_Equipaje> lst = new List<BE_Equipaje>();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("pNROBOLETO", SqlDbType.VarChar);
           param[0].Value = nroboleto;
           param[0].Direction = ParameterDirection.Input;
           param[1] = new SqlParameter("pAccion", SqlDbType.Int);
           param[1].Value = accion;
           param[1].Direction = ParameterDirection.Input;

           DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_EQUIPAJEACTUALIZARESTADO", param);
           int ColumnCount = ds.Tables.Count;
           DataTable dt = ds.Tables[0];
           foreach (DataRow dr in dt.Rows)
           {
               //Object of the propery class
               BE_Equipaje objEquipaje = new BE_Equipaje();
               //asign values
               objEquipaje.NroBoleto = dr["CHR_NUMEROBOLETO"].ToString();
               objEquipaje.Pasajero = dr["Pasajero"].ToString();
               objEquipaje.Peso = dr["DEC_PESO"].ToString();
               objEquipaje.Origen = dr["VCH_ORIGEN"].ToString();
               objEquipaje.Destino = dr["VCH_DESTINO"].ToString();
               objEquipaje.FechaSalida = dr["FechaSalida"].ToString();
               objEquipaje.HoraSalida = dr["HoraSalida"].ToString();
               objEquipaje.TipoEquipaje = dr["VCH_NOMBREETIQUETA"].ToString();
               objEquipaje.Ubicacion = dr["VCH_UBICACION"].ToString();
               objEquipaje.FechaActual = dr["FechaActual"].ToString();
               objEquipaje.HoraActual = dr["HoraActual"].ToString();
               objEquipaje.EstadoEquipaje = dr["VCH_ESTADOEQUIPAJE"].ToString();
               //add one row to the list
               lst.Add(objEquipaje);
           }
           return lst;
       }



       public List<BE_Equipaje> f_verificarEstadoEquipaje(String nroboleto)
       {
           List<BE_Equipaje> lst = new List<BE_Equipaje>();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("pNROBOLETO", SqlDbType.VarChar);
           param[0].Value = nroboleto;
           param[0].Direction = ParameterDirection.Input;
           

           DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_EQUIPAJEVERIFICARESTADO", param);
           int ColumnCount = ds.Tables.Count;
           DataTable dt = ds.Tables[0];
           foreach (DataRow dr in dt.Rows)
           {
               //Object of the propery class
               BE_Equipaje objEquipaje = new BE_Equipaje();
               //asign values
               objEquipaje.NroBoleto = dr["CHR_NUMEROBOLETO"].ToString();
               objEquipaje.Pasajero = dr["Pasajero"].ToString();
               objEquipaje.Peso = dr["DEC_PESO"].ToString();
               objEquipaje.Origen = dr["VCH_ORIGEN"].ToString();
               objEquipaje.Destino = dr["VCH_DESTINO"].ToString();
               objEquipaje.FechaSalida = dr["FechaSalida"].ToString();
               objEquipaje.HoraSalida = dr["HoraSalida"].ToString();
               objEquipaje.TipoEquipaje = dr["VCH_NOMBREETIQUETA"].ToString();
               objEquipaje.Ubicacion = dr["VCH_UBICACION"].ToString();
               objEquipaje.FechaActual = dr["FechaActual"].ToString();
               objEquipaje.HoraActual = dr["HoraActual"].ToString();
               objEquipaje.EstadoEquipaje = dr["VCH_ESTADOEQUIPAJE"].ToString();
               objEquipaje.EstadoVerificacion = dr["ESTADO_VERIFICACION"].ToString();
               //add one row to the list
               lst.Add(objEquipaje);
           }
           return lst;
       }

       public BE_Tiket f_modificarEquipaje(int codequipaje, int codboleto)
       {
           SqlParameter[] param = new SqlParameter[14];
           param[0] = new SqlParameter("INT_CODEQUIPAJE", SqlDbType.VarChar);
           param[0].Value = codequipaje;
           param[0].Direction = ParameterDirection.Input;
           param[1] = new SqlParameter("INT_CODIGOBOLETO", SqlDbType.VarChar);
           param[1].Value = codboleto;
           param[1].Direction = ParameterDirection.Input;

           SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_EQUIPAJEACTUALIZAR", param);

           return new BE_Tiket();
       }
       
    }
}
