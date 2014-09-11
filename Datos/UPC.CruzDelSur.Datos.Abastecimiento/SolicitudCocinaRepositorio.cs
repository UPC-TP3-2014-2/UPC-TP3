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
    public class SolicitudCocinaRepositorio : Repositorio<SolicitudCocinaRepositorio>, ISolicitudCocinaRepositorio
    {

        protected Database Database = DatabaseFactory.CreateDatabase();

        public IQueryable<SolicitudCocina> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public SolicitudCocina ObtenerPorId(int id)
        {
            string Query = "select int_codigo_solicitudcocina, int_codigo_refrigerio, int_codigo_programacion_ruta, int_cantidad, bln_estado from ta_solicitudcocina where int_codigo_solicitudcocina = @id";
            DbCommand DbCommand = Database.GetSqlStringCommand(Query);
            Database.AddInParameter(DbCommand, "@id", DbType.Int32, id);

            using (IDataReader Reader = Database.ExecuteReader(DbCommand))
            {
                if (Reader.Read())
                {
                    return new SolicitudCocina()
                    {
                        Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
                        Refrigerio = new Refrigerio() { Id = (!Reader.IsDBNull(1)) ? Reader.GetInt32(1) : 0, },
                        ProgramacionRuta = new ProgramacionRuta() { Id = (!Reader.IsDBNull(2)) ? Reader.GetInt32(2) : 0, },
                        Cantidad = (!Reader.IsDBNull(3)) ? Reader.GetInt32(3) : 0,
                        Estado = (!Reader.IsDBNull(4) && Reader.GetBoolean(4))
                    };
                }
            }

            return null;
        }

        public void Insertar(SolicitudCocina solicitudCocina)
        {
            string Query = "insert into ta_solicitudcocina(int_codigo_refrigerio, int_codigo_programacion_ruta, int_cantidad, bln_estado) values(@int_codigo_refrigerio, @int_codigo_programacion_ruta, @int_cantidad, @bln_estado) set @id = scope_identity()";
            DbCommand DbCommand = Database.GetSqlStringCommand(Query);
            Database.AddOutParameter(DbCommand, "@id", DbType.Int32, 4);
            Database.AddInParameter(DbCommand, "@int_codigo_refrigerio", DbType.Int32, solicitudCocina.Refrigerio.Id);
            Database.AddInParameter(DbCommand, "@int_codigo_programacion_ruta", DbType.Int32, solicitudCocina.ProgramacionRuta.Id);
            Database.AddInParameter(DbCommand, "@int_cantidad", DbType.Int32, solicitudCocina.Cantidad);
            Database.AddInParameter(DbCommand, "@bln_estado", DbType.Boolean, solicitudCocina.Estado);

            int RowsAffected = Database.ExecuteNonQuery(DbCommand);
        }

        public void Actualizar(SolicitudCocina entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(SolicitudCocina entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
