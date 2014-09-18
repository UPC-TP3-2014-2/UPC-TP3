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
    public class Programacion_Ruta : IProgramacion_Ruta
    {
        public List<UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta> f_Programacion_Ruta(Int32 pAgenciaDestino)
        {
            List<UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta> objProgramacion_Ruta = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta>();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@INT_CODIGO_AGENCIADESTINO", SqlDbType.Int);
            param[0].Value = pAgenciaDestino;
            param[0].Direction = ParameterDirection.Input;


            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARPROGRAMACION", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta oBE_Programacion_Ruta = new UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta();
                //asign values
                if (DBNull.Value != dr["INT_CODIGO_PROGRAMACION_RUTA"])
                    oBE_Programacion_Ruta.CODIGO_PROGRAMACION_RUTA = Int32.Parse( dr["INT_CODIGO_PROGRAMACION_RUTA"].ToString());

                if (DBNull.Value != dr["INT_CODIGO_RUTA"])
                    oBE_Programacion_Ruta.CODIGO_RUTA  = Int32.Parse( dr["INT_CODIGO_RUTA"].ToString());

                if (DBNull.Value != dr["DTM_FECHA_ORIGEN"])
                    oBE_Programacion_Ruta.FECHA_ORIGEN   = DateTime.Parse( dr["DTM_FECHA_ORIGEN"].ToString());

                if (DBNull.Value != dr["DTM_FECHA_DESTINO"])
                    oBE_Programacion_Ruta.FECHA_DESTINO = DateTime.Parse( dr["DTM_FECHA_DESTINO"].ToString());

                if (DBNull.Value != dr["TIM_HORA_SALIDA"])
                    oBE_Programacion_Ruta.HORA_SALIDA = DateTime.Parse( dr["TIM_HORA_SALIDA"].ToString());

                if (DBNull.Value != dr["TIM_HORA_LLEGADA"])
                    oBE_Programacion_Ruta.HORA_LLEGADA = DateTime.Parse(dr["TIM_HORA_LLEGADA"].ToString());
                if (DBNull.Value != dr["INT_TIPO_SERVICIO"])
                    oBE_Programacion_Ruta.TIPO_SERVICIO  = int.Parse(dr["INT_TIPO_SERVICIO"].ToString());
                if (DBNull.Value != dr["INT_CODIGOVEHICULO"])
                    oBE_Programacion_Ruta.CODIGOVEHICULO = int.Parse(dr["INT_CODIGOVEHICULO"].ToString());
                if (DBNull.Value != dr["INT_CODIGOPERSONA"])
                    oBE_Programacion_Ruta.CODIGOPERSONA = int.Parse(dr["INT_CODIGOPERSONA"].ToString());
                if (DBNull.Value != dr["BLN_ESTADO"])
                    oBE_Programacion_Ruta.ESTADO  = bool.Parse(dr["BLN_ESTADO"].ToString());
                if (DBNull.Value != dr["VCH_ORIGEN"])
                    oBE_Programacion_Ruta.ORIGEN  = dr["VCH_ORIGEN"].ToString();
                if (DBNull.Value != dr["VCH_DESTINO"])
                    oBE_Programacion_Ruta.DESTINO  = dr["VCH_DESTINO"].ToString();
                if (DBNull.Value != dr["INT_CODIGO_AGENCIAORIGEN"])
                    oBE_Programacion_Ruta.CODIGO_AGENCIAORIGEN  = int.Parse(dr["INT_CODIGO_AGENCIAORIGEN"].ToString());
                if (DBNull.Value != dr["INT_CODIGO_AGENCIADESTINO"])
                    oBE_Programacion_Ruta.CODIGO_AGENCIADESTINO  = int.Parse(dr["INT_CODIGO_AGENCIADESTINO"].ToString());
                //add one row to the list
                objProgramacion_Ruta.Add(oBE_Programacion_Ruta ) ;
            }
            return objProgramacion_Ruta;
        }
        public UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta f_UnoProgramacion_Ruta(Int32 pAgenciaDestino)
        {
            UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta objProgramacion_Ruta = new UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@INT_CODIGO_PROGRAMACION_RUTA", SqlDbType.Int);
            param[0].Value = pAgenciaDestino;
            param[0].Direction = ParameterDirection.Input;


            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARUNOPROGRAMACION", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class

                //asign values
                if (DBNull.Value != dr["INT_CODIGO_PROGRAMACION_RUTA"])
                    objProgramacion_Ruta.CODIGO_PROGRAMACION_RUTA = Int32.Parse(dr["INT_CODIGO_PROGRAMACION_RUTA"].ToString());

                if (DBNull.Value != dr["INT_CODIGO_RUTA"])
                    objProgramacion_Ruta.CODIGO_RUTA = Int32.Parse(dr["INT_CODIGO_RUTA"].ToString());

                if (DBNull.Value != dr["DTM_FECHA_ORIGEN"])
                    objProgramacion_Ruta.FECHA_ORIGEN = DateTime.Parse(dr["DTM_FECHA_ORIGEN"].ToString());

                if (DBNull.Value != dr["DTM_FECHA_DESTINO"])
                    objProgramacion_Ruta.FECHA_DESTINO = DateTime.Parse(dr["DTM_FECHA_DESTINO"].ToString());

                if (DBNull.Value != dr["TIM_HORA_SALIDA"])
                    objProgramacion_Ruta.HORA_SALIDA = DateTime.Parse(dr["TIM_HORA_SALIDA"].ToString());

                if (DBNull.Value != dr["TIM_HORA_LLEGADA"])
                    objProgramacion_Ruta.HORA_LLEGADA = DateTime.Parse(dr["TIM_HORA_LLEGADA"].ToString());

                if (DBNull.Value != dr["INT_TIPO_SERVICIO"])
                    objProgramacion_Ruta.TIPO_SERVICIO = int.Parse(dr["INT_TIPO_SERVICIO"].ToString());




                if (DBNull.Value != dr["INT_CODIGOVEHICULO"])
                    objProgramacion_Ruta.CODIGOVEHICULO = int.Parse(dr["INT_CODIGOVEHICULO"].ToString());



                if (DBNull.Value != dr["INT_CODIGOPERSONA"])
                    objProgramacion_Ruta.CODIGOPERSONA = int.Parse(dr["INT_CODIGOPERSONA"].ToString());



                if (DBNull.Value != dr["BLN_ESTADO"])
                    objProgramacion_Ruta.ESTADO = bool.Parse(dr["BLN_ESTADO"].ToString());


                if (DBNull.Value != dr["VCH_ORIGEN"])
                    objProgramacion_Ruta.ORIGEN = dr["VCH_ORIGEN"].ToString();

                if (DBNull.Value != dr["VCH_DESTINO"])
                    objProgramacion_Ruta.DESTINO = dr["VCH_DESTINO"].ToString();



                if (DBNull.Value != dr["INT_CODIGO_AGENCIAORIGEN"])
                    objProgramacion_Ruta.CODIGO_AGENCIAORIGEN = int.Parse(dr["INT_CODIGO_AGENCIAORIGEN"].ToString());


                if (DBNull.Value != dr["INT_CODIGO_AGENCIADESTINO"])
                    objProgramacion_Ruta.CODIGO_AGENCIADESTINO = int.Parse(dr["INT_CODIGO_AGENCIADESTINO"].ToString());


                if (DBNull.Value != dr["VCH_PLACA"])
                    objProgramacion_Ruta.PLACA= dr["VCH_PLACA"].ToString();


                //add one row to the list

            }
            return objProgramacion_Ruta;
        }

    }
}
