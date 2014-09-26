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
    public class BL_Reclamo: IBL_Reclamo 
    {

        public List<BE_Reclamo> f_buscaBoletoPasajero(String nroboleto, string dni)
        {
            List<BE_Reclamo> lst = new List<BE_Reclamo>();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("pNROBOLETO", SqlDbType.VarChar);
            param[0].Value = nroboleto;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("pDNI", SqlDbType.VarChar);
            param[1].Value = dni;
            param[1].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_BOLETOCONSULTARRECLAMO", param);
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //Object of the propery class
                BE_Reclamo objReclamo = new BE_Reclamo();
                //asign values
                objReclamo.NroBoleto = dr["CHR_NUMEROBOLETO"].ToString();
                objReclamo.Pasajero = dr["PASAJERO"].ToString();
                objReclamo.Direccion = dr["VCH_DIRECCION"].ToString();
                objReclamo.Telefono = dr["VCH_TELEFONO"].ToString();
                objReclamo.FechaActual = dr["FECHAACTUAL"].ToString();
                objReclamo.HoraActual = dr["HORAACTUAL"].ToString();
                //add one row to the list
                lst.Add(objReclamo);
            }
            return lst;
        }


        public BE_Reclamo f_registrarReclamo(string nroBoleto, int idTipoSolicitud, int idArea, string motivo)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("NROBOLETO", SqlDbType.VarChar);
            param[0].Value = nroBoleto;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("IDTIPOSOLICITUD", SqlDbType.Int);
            param[1].Value = idTipoSolicitud;
            param[1].Direction = ParameterDirection.Input;
            param[2] = new SqlParameter("IDAREA", SqlDbType.Int);
            param[2].Value = idArea;
            param[2].Direction = ParameterDirection.Input;
            param[3] = new SqlParameter("MOTIVO", SqlDbType.VarChar);
            param[3].Value = motivo;
            param[3].Direction = ParameterDirection.Input;

            SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_RECLAMO_REGISTRAR", param);

            return new BE_Reclamo();
        }


        public List<BE_TipoSolicitud> f_listaTipoSolicitud()
        {
            List<BE_TipoSolicitud> _lista = new List<BE_TipoSolicitud>();

            SqlParameter[] param = new SqlParameter[0];
            
            DataSet ds = SqlHelper.ExecuteDataSet (Conexion.CadenaConexion, System.Data.CommandType.Text, "SELECT INT_TIPOSOLICITUD, VCH_NOMBRE FROM TA_TIPOSOLICITUD", param);
            
            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                BE_TipoSolicitud pTipoSolicitud = new BE_TipoSolicitud();

                pTipoSolicitud.IdTipoSolicitud = Convert.ToInt32(dr["INT_TIPOSOLICITUD"]);
                pTipoSolicitud.Nombre = dr["VCH_NOMBRE"].ToString();

                _lista.Add(pTipoSolicitud);
            }

            return _lista;
        }


        public List<BE_Area> f_listaArea()
        {
            List<BE_Area> _lista = new List<BE_Area>();

            SqlParameter[] param = new SqlParameter[0];

            DataSet ds = SqlHelper.ExecuteDataSet(Conexion.CadenaConexion, System.Data.CommandType.Text, "SELECT INT_AREA, VCH_NOMBRE FROM TA_AREA", param);

            int ColumnCount = ds.Tables.Count;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                BE_Area pArea = new BE_Area();

                pArea.IdArea = Convert.ToInt32(dr["INT_AREA"]);
                pArea.Nombre = dr["VCH_NOMBRE"].ToString();

                _lista.Add(pArea);
            }

            return _lista;
        }

    }
}
