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
    public class Carga : ICargaRepositorio
    {

        public int f_ActualizarEstadoCarga(String pVCH_ESTADO,String pINT_CODIGO_CARGA)
        {
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@VCH_ESTADO", SqlDbType.VarChar);
            param[0].Value = pVCH_ESTADO;
            param[0].Direction = ParameterDirection.Input;


            param[1] = new SqlParameter("@INT_CODIGO_CARGA", SqlDbType.Int);
            param[1].Value = pINT_CODIGO_CARGA;
            param[1].Direction = ParameterDirection.Input;




            int CodigoCarga = SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_ACTUALIZARESTADOCARGA", param);
            return 0;
        }

        public int f_AgregarCarga(UPC.CruzDelSur.Negocio.Modelo.Carga.Carga oBE_Carga)
        {
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@VCH_FICHA", SqlDbType.VarChar);
            param[0].Value = oBE_Carga.FICHA;
            param[0].Direction = ParameterDirection.Input;


            param[1] = new SqlParameter("@DTM_FECHA_REGISTRO", SqlDbType.DateTime);
            param[1].Value = oBE_Carga.FECHA_REGISTRO;
            param[1].Direction = ParameterDirection.Input;


            param[2] = new SqlParameter("@VCH_REMITENTE", SqlDbType.VarChar);
            param[2].Value = oBE_Carga.REMITENTE;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new SqlParameter("@VCH_DESTINATARIO", SqlDbType.VarChar);
            param[3].Value = oBE_Carga.DESTINATARIO;
            param[3].Direction = ParameterDirection.Input;


            param[4] = new SqlParameter("@DBL_PESOTOTAL", SqlDbType.Decimal);
            param[4].Value = oBE_Carga.DBL_PESOTOTAL;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new SqlParameter("@DBL_IMPORTETOTAL", SqlDbType.Decimal);
            param[5].Value = oBE_Carga.DBL_IMPORTETOTAL;
            param[5].Direction = ParameterDirection.Input;


            


            param[6] = new SqlParameter("@VCH_OBSERVACION", SqlDbType.VarChar);
            param[6].Value = oBE_Carga.OBSERVACION;
            param[6].Direction = ParameterDirection.Input;



            param[7] = new SqlParameter("@VCH_CLAVE_SEGURIDAD", SqlDbType.VarChar);
            param[7].Value = oBE_Carga.CLAVE_SEGURIDAD;
            param[7].Direction = ParameterDirection.Input;




            param[8] = new SqlParameter("@INT_TIPO_PAGO", SqlDbType.Int);
            param[8].Value = oBE_Carga.TIPO_PAGO;
            param[8].Direction = ParameterDirection.Input;




            param[9] = new SqlParameter("@INT_CODIGO_PROGRAMACION_RUTA", SqlDbType.Int);
            param[9].Value = oBE_Carga.CODIGO_PROGRAMACION_RUTA;
            param[9].Direction = ParameterDirection.Input;



            param[10] = new SqlParameter("@VCH_CLIENTE_ORIGEN", SqlDbType.VarChar);
            param[10].Value = oBE_Carga.CLIENTE_ORIGEN;
            param[10].Direction = ParameterDirection.Input;


            param[11] = new SqlParameter("@VCH_ESTADOPAGO", SqlDbType.VarChar);
            param[11].Value = oBE_Carga.ESTADOPAGO;
            param[11].Direction = ParameterDirection.Input;


            //param[12] = new SqlParameter("@INT_CODIGO_GUIA", SqlDbType.Int);
            //param[12].Value = oBE_Carga.CODIGO_GUIA;
            //param[12].Direction = ParameterDirection.Input;


            param[13] = new SqlParameter("@VCH_CLIENTE_DESTINO", SqlDbType.VarChar);
            param[13].Value = oBE_Carga.CLIENTE_DESTINO;
            param[13].Direction = ParameterDirection.Input;


            param[14] = new SqlParameter("@VCH_ESTADO", SqlDbType.VarChar);
            param[14].Value = oBE_Carga.ESTADO;
            param[14].Direction = ParameterDirection.Input;


            param[15] = new SqlParameter("@INT_CODIGO_CARGA", SqlDbType.Int);
            param[15].Value = oBE_Carga.CODIGO_CARGA;
            param[15].Direction = ParameterDirection.Input;


            param[16] = new SqlParameter("@DBL_TOTAL", SqlDbType.Decimal);
            param[16].Value = oBE_Carga.DBL_TOTAL;
            param[16].Direction = ParameterDirection.Input;


            param[17] = new SqlParameter("@DBL_IGV", SqlDbType.Decimal);
            param[17].Value = oBE_Carga.DBL_IGV;
            param[17].Direction = ParameterDirection.Input;

            String CodigoCarga = SqlHelper.ExecuteScalar(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_INSERTARCARGA", param);


            foreach (UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga oBE_DetalleCarga in oBE_Carga.oDetalleCarga)
            {
                SqlParameter[] paramDetalle = new SqlParameter[7];
                paramDetalle[0] = new SqlParameter("@INT_CODIGO_CARGA", SqlDbType.Int);
                paramDetalle[0].Value = CodigoCarga;
                paramDetalle[0].Direction = ParameterDirection.Input;

                paramDetalle[1] = new SqlParameter("@INT_CODIGO_PRODUCTO", SqlDbType.Int);
                paramDetalle[1].Value = oBE_DetalleCarga.CODIGO_PRODUCTO;
                paramDetalle[1].Direction = ParameterDirection.Input;


                paramDetalle[2] = new SqlParameter("@VCH_DESCRIPCION", SqlDbType.VarChar);
                paramDetalle[2].Value = oBE_DetalleCarga.DESCRIPCION;
                paramDetalle[2].Direction = ParameterDirection.Input;


                paramDetalle[3] = new SqlParameter("@INT_TIPO_CARGA", SqlDbType.Int);
                paramDetalle[3].Value = oBE_DetalleCarga.TIPO_CARGA;
                paramDetalle[3].Direction = ParameterDirection.Input;


                paramDetalle[4] = new SqlParameter("@INT_CANTIDAD", SqlDbType.Int);
                paramDetalle[4].Value = oBE_DetalleCarga.CANTIDAD;
                paramDetalle[4].Direction = ParameterDirection.Input;


                paramDetalle[5] = new SqlParameter("@DBL_PESO", SqlDbType.Decimal);
                paramDetalle[5].Value = oBE_DetalleCarga.DBL_PESO;
                paramDetalle[5].Direction = ParameterDirection.Input;


                paramDetalle[6] = new SqlParameter("@DBL_IMPORTE", SqlDbType.Decimal,2);
                paramDetalle[6].Value = oBE_DetalleCarga.DBL_IMPORTE;
                paramDetalle[6].Direction = ParameterDirection.Input;


                int result = SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_INSERTARDETALLECARGA", paramDetalle);

            }







            return 0;
        }


        public List<UPC.CruzDelSur.Negocio.Modelo.Carga.Carga> f_ListadoCarga(String pOPT, String pNroDocumento)
        {
            List<UPC.CruzDelSur.Negocio.Modelo.Carga.Carga> lst = new List<UPC.CruzDelSur.Negocio.Modelo.Carga.Carga>();

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@OPT", SqlDbType.VarChar);
            param[0].Value = pOPT;
            param[0].Direction = ParameterDirection.Input;



            param[1] = new SqlParameter("@BUSQUEDA", SqlDbType.VarChar);
            param[1].Value = pNroDocumento;
            param[1].Direction = ParameterDirection.Input;


            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARCARGA", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                UPC.CruzDelSur.Negocio.Modelo.Carga.Carga objCarga = new UPC.CruzDelSur.Negocio.Modelo.Carga.Carga();
                //asign values
                if (DBNull.Value != dr["INT_CODIGO_CARGA"])
                    objCarga.CODIGO_CARGA = Int32.Parse(dr["INT_CODIGO_CARGA"].ToString());

                if (DBNull.Value != dr["VCH_FICHA"])
                    objCarga.FICHA= dr["VCH_FICHA"].ToString();

                if (DBNull.Value != dr["VCH_ORIGEN"])
                    objCarga.ORIGEN= dr["VCH_ORIGEN"].ToString();

                if (DBNull.Value != dr["VCH_DESTINO"])
                    objCarga.DESTINO= dr["VCH_DESTINO"].ToString();

                if (DBNull.Value != dr["DTM_FECHA_ORIGEN"])
                    objCarga.FECHA_ORIGEN = DateTime.Parse( dr["DTM_FECHA_ORIGEN"].ToString());

                if (DBNull.Value != dr["DTM_FECHA_DESTINO"])
                    objCarga.FECHA_DESTINO  =DateTime.Parse( dr["DTM_FECHA_DESTINO"].ToString());

                if (DBNull.Value != dr["VCH_REMITENTE"])
                    objCarga.REMITENTE= dr["VCH_REMITENTE"].ToString();


                if (DBNull.Value != dr["VCH_DESTINATARIO"])
                    objCarga.DESTINATARIO  = dr["VCH_DESTINATARIO"].ToString();



                if (DBNull.Value != dr["VCH_CLIENTE_ORIGEN"])
                    objCarga.CLIENTE_ORIGEN = dr["VCH_CLIENTE_ORIGEN"].ToString();


                if (DBNull.Value != dr["VCH_CLIENTE_DESTINO"])
                    objCarga.CLIENTE_DESTINO  = dr["VCH_CLIENTE_DESTINO"].ToString();


                if (DBNull.Value != dr["VCH_ESTADOPAGO"])
                    objCarga.ESTADOPAGO = dr["VCH_ESTADOPAGO"].ToString();

                if (DBNull.Value != dr["VCH_ESTADO"])
                    objCarga.ESTADO  = dr["VCH_ESTADO"].ToString();


                //add one row to the list
                lst.Add(objCarga);
            }
            return lst;
        }

        public String f_GenerarNumero()
        {
            String CodigoFicha = "";
            UPC.CruzDelSur.Negocio.Modelo.Carga.Carga objCarga = new UPC.CruzDelSur.Negocio.Modelo.Carga.Carga();
            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_GENERARCODIGOCARGA");
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (DBNull.Value != dr["FICHA"])
                    CodigoFicha = dr["FICHA"].ToString();
            }
            return CodigoFicha;
        }
        public UPC.CruzDelSur.Negocio.Modelo.Carga.Carga f_ListadoUnoCarga(Int32 pCODIGO_CARGA)
        {
            UPC.CruzDelSur.Negocio.Modelo.Carga.Carga objCarga = new UPC.CruzDelSur.Negocio.Modelo.Carga.Carga();

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@INT_CODIGO_CARGA", SqlDbType.Int);
            param[0].Value = pCODIGO_CARGA;
            param[0].Direction = ParameterDirection.Input;



            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARUNOCARGA", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
            
                //asign values
                if (DBNull.Value != dr["INT_CODIGO_CARGA"])
                    objCarga.CODIGO_CARGA = Int32.Parse(dr["INT_CODIGO_CARGA"].ToString());

                if (DBNull.Value != dr["VCH_FICHA"])
                    objCarga.FICHA = dr["VCH_FICHA"].ToString();

                if (DBNull.Value != dr["VCH_ORIGEN"])
                    objCarga.ORIGEN = dr["VCH_ORIGEN"].ToString();

                if (DBNull.Value != dr["VCH_DESTINO"])
                    objCarga.DESTINO = dr["VCH_DESTINO"].ToString();

                if (DBNull.Value != dr["DTM_FECHA_ORIGEN"])
                    objCarga.FECHA_ORIGEN = DateTime.Parse(dr["DTM_FECHA_ORIGEN"].ToString());

                if (DBNull.Value != dr["DTM_FECHA_DESTINO"])
                    objCarga.FECHA_DESTINO = DateTime.Parse(dr["DTM_FECHA_DESTINO"].ToString());

                if (DBNull.Value != dr["VCH_REMITENTE"])
                    objCarga.REMITENTE = dr["VCH_REMITENTE"].ToString();


                if (DBNull.Value != dr["VCH_DESTINATARIO"])
                    objCarga.DESTINATARIO = dr["VCH_DESTINATARIO"].ToString();



                if (DBNull.Value != dr["VCH_CLIENTE_ORIGEN"])
                    objCarga.CLIENTE_ORIGEN = dr["VCH_CLIENTE_ORIGEN"].ToString();


                if (DBNull.Value != dr["VCH_CLIENTE_DESTINO"])
                    objCarga.CLIENTE_DESTINO = dr["VCH_CLIENTE_DESTINO"].ToString();


                if (DBNull.Value != dr["VCH_ESTADOPAGO"])
                    objCarga.ESTADOPAGO = dr["VCH_ESTADOPAGO"].ToString();

                if (DBNull.Value != dr["VCH_ESTADO"])
                    objCarga.ESTADO = dr["VCH_ESTADO"].ToString();

                if (DBNull.Value != dr["INT_CODIGO_PROGRAMACION_RUTA"])
                    objCarga.CODIGO_PROGRAMACION_RUTA = Int32.Parse( dr["INT_CODIGO_PROGRAMACION_RUTA"].ToString());



                if (DBNull.Value != dr["VCH_CLAVE_SEGURIDAD"])
                    objCarga.CLAVE_SEGURIDAD= dr["VCH_CLAVE_SEGURIDAD"].ToString();



                if (DBNull.Value != dr["VCH_OBSERVACION"])
                    objCarga.OBSERVACION = dr["VCH_OBSERVACION"].ToString();


                if (DBNull.Value != dr["DBL_IMPORTETOTAL"])
                    objCarga.DBL_IMPORTETOTAL = double.Parse(  dr["DBL_IMPORTETOTAL"].ToString());


                if (DBNull.Value != dr["DBL_PESOTOTAL"])
                    objCarga.DBL_PESOTOTAL = double.Parse(dr["DBL_PESOTOTAL"].ToString());


                if (DBNull.Value != dr["DBL_IGV"])
                    objCarga.DBL_IGV = double.Parse(dr["DBL_IGV"].ToString());

                if (DBNull.Value != dr["DBL_TOTAL"])
                    objCarga.DBL_TOTAL= double.Parse(dr["DBL_TOTAL"].ToString());

                
            }
            return objCarga;
        }




        
    }
}
