using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Datos.Abastecimiento
{
    public class SolicitudInsumoRepositorio : Repositorio<SolicitudInsumoRepositorio>,  ISolicitudInsumoRepositorio
    {

        protected Database Database = DatabaseFactory.CreateDatabase();



        public IQueryable<SolicitudInsumo> ObtenerTodos()
        {
            string Query = "select int_codigo_solicitudinsumo, int_codigo_solicitudcocina, int_codigo_insumo, dte_fecha_solicitud, int_cantidad, vch_unidad, bln_estado from ta_solicitudinsumo";
            DbCommand DbCommand = Database.GetSqlStringCommand(Query);
            IList<SolicitudInsumo> Listado = new List<SolicitudInsumo>();

            using (IDataReader Reader = Database.ExecuteReader(DbCommand))
            {
                while (Reader.Read())
                {
                    Listado.Add(
                        new SolicitudInsumo()
                        {
                            Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
                            SolicitudCocina = new SolicitudCocina() { Id = (!Reader.IsDBNull(1)) ? Reader.GetInt32(1) : 0 },
                            Insumo = new Insumo() { Id = (!Reader.IsDBNull(2)) ? Reader.GetInt32(2) : 0, },
                            FechaSolicitud = (!Reader.IsDBNull(3)) ? Reader.GetDateTime(3) : Convert.ToDateTime("01/01/1900"),
                            Cantidad = (!Reader.IsDBNull(4)) ? Reader.GetInt32(4) : 0,
                            Unidad = (!Reader.IsDBNull(5)) ? Reader.GetString(5) : String.Empty,
                            Estado = (!Reader.IsDBNull(0) && Reader.GetBoolean(6))
                        }
                        );
                }
            }

            return Listado.AsQueryable();
        }


        public SolicitudInsumo ObtenerPorId(int id)
        {
            string Query = "select int_codigo_solicitudinsumo, int_codigo_solicitudcocina, int_codigo_insumo, dte_fecha_solicitud, int_cantidad, vch_unidad, bln_estado from ta_solicitudinsumo where int_codigo_solicitudinsumo = @id";
            DbCommand DbCommand = Database.GetSqlStringCommand(Query);
            Database.AddInParameter(DbCommand, "@id", DbType.Int32, id);

            using (IDataReader Reader = Database.ExecuteReader(DbCommand))
            {
                if (Reader.Read())
                {
                    return new SolicitudInsumo()
                    {
                        Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
                        SolicitudCocina = new SolicitudCocina() { Id = (!Reader.IsDBNull(1)) ? Reader.GetInt32(1) : 0 },
                        Insumo = new Insumo() { Id = (!Reader.IsDBNull(2)) ? Reader.GetInt32(2) : 0, },
                        FechaSolicitud = (!Reader.IsDBNull(3)) ? Reader.GetDateTime(3) : Convert.ToDateTime("01/01/1900"),
                        Cantidad = (!Reader.IsDBNull(4)) ? Reader.GetInt32(4) : 0,
                        Unidad = (!Reader.IsDBNull(5)) ? Reader.GetString(5) : String.Empty,
                        Estado = (!Reader.IsDBNull(0) && Reader.GetBoolean(6))
                    };
                }
            }

            return null;



            throw new NotImplementedException();
        }

        public void Insertar(SolicitudInsumo entidad)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(SolicitudInsumo entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(SolicitudInsumo entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
