using System.Data.SqlClient;

namespace UPC.CruzDelSur.Datos.Carga.Global
{
    public class Conexion
    {

        ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;

        public SqlConnection ConexionCruzDelSur()
        {
            SqlConnection cn = new SqlConnection(connectionStrings["cnTransporte"].ConnectionString);
            return cn;
        }


    }
}
