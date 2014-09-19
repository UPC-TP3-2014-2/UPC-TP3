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

        ISolicitudCocinaRepositorio SolicitudCocinaRepo = SolicitudCocinaRepositorio.ObtenerInstancia();

        protected SolicitudInsumoRepositorio() { }


        public IQueryable<SolicitudInsumo> ObtenerTodos()
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_solicitudinsumo, dte_fecha_solicitud, int_codigo_solicitudcocina, tin_estado from ta_solicitudinsumo");
            IList<SolicitudInsumo> ListadoSolicitudInsumo = new List<SolicitudInsumo>();

            using (IDataReader Reader = Database.ExecuteReader(DbCommand))
            {
                while (Reader.Read())
                {
                    ListadoSolicitudInsumo.Add(
                        new SolicitudInsumo()
                        {
                            Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
                            FechaSolicitud = (!Reader.IsDBNull(1)) ? Reader.GetDateTime(1) : Convert.ToDateTime("01/01/1900"),
                            SolicitudCocina = (!Reader.IsDBNull(2)) ? SolicitudCocinaRepo.ObtenerPorId(Reader.GetInt32(2)) : new SolicitudCocina() { Id = 0 }, 
                            Estado = (!Reader.IsDBNull(3)) ? Reader.GetByte(3) : 0
                        });
                }
            }

            return ListadoSolicitudInsumo.AsQueryable();
        }

        public SolicitudInsumo ObtenerPorId(int id)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_solicitudinsumo, dte_fecha_solicitud, int_codigo_solicitudcocina, tin_estado from ta_solicitudinsumo where int_codigo_solicitudinsumo = @int_codigo_solicitudinsumo");
            Database.AddInParameter(DbCommand, "@int_codigo_solicitudinsumo", DbType.Int32, id);

            using (IDataReader Reader = Database.ExecuteReader(DbCommand))
            {
                if (Reader.Read())
                {
                    return new SolicitudInsumo()
                    {
                        Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
                        FechaSolicitud = (!Reader.IsDBNull(1)) ? Reader.GetDateTime(1) : Convert.ToDateTime("01/01/1900"),
                        SolicitudCocina = (!Reader.IsDBNull(2)) ? SolicitudCocinaRepo.ObtenerPorId(Reader.GetInt32(2)) : new SolicitudCocina() { Id = 0 },
                        Estado = (!Reader.IsDBNull(3)) ? Reader.GetByte(3) : 0
                    };
                }
            }

            return null;
        }

        public void Insertar(SolicitudInsumo solicitudInsumo)
        {
			DbCommand DbCommand = Database.GetSqlStringCommand("insert into ta_solicitudinsumo(dte_fecha_solicitud, int_codigo_solicitudcocina, tin_estado) values(@dte_fecha_solicitud, @int_codigo_solicitudcocina, @tin_estado)");
			Database.AddInParameter(DbCommand, "@dte_fecha_solicitud", DbType.Date, solicitudInsumo.FechaSolicitud);
			Database.AddInParameter(DbCommand, "@int_codigo_solicitudcocina", DbType.Int32, solicitudInsumo.SolicitudCocina.Id);
			Database.AddInParameter(DbCommand, "@tin_estado", DbType.Int16, solicitudInsumo.Estado);
			Database.ExecuteNonQuery(DbCommand);
        }

        public void Actualizar(SolicitudInsumo solicitudInsumo)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("update ta_solicitudinsumo set dte_fecha_solicitud = @dte_fecha_solicitud, int_codigo_solicitudcocina = @int_codigo_solicitudcocina, tin_estado = @tin_estado where int_codigo_solicitudinsumo = @int_codigo_solicitudinsumo");
            Database.AddInParameter(DbCommand, "@int_codigo_solicitudinsumo", DbType.Int16, solicitudInsumo.Id);
            Database.AddInParameter(DbCommand, "@dte_fecha_solicitud", DbType.Date, solicitudInsumo.FechaSolicitud);
			Database.AddInParameter(DbCommand, "@int_codigo_solicitudcocina", DbType.Int32, solicitudInsumo.SolicitudCocina.Id);
			Database.AddInParameter(DbCommand, "@tin_estado", DbType.Int16, solicitudInsumo.Estado);
			Database.ExecuteNonQuery(DbCommand);
        }

        public void Eliminar(SolicitudInsumo solicitudInsumo)
        {
            Eliminar(solicitudInsumo.Id);
        }

        public void Eliminar(int id)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("delete from ta_solicitudinsumo where int_codigo_solicitudinsumo = @int_codigo_solicitudinsumo");
            Database.AddInParameter(DbCommand, "@int_codigo_solicitudinsumo", DbType.Int16, id);
            Database.ExecuteNonQuery(DbCommand);
        }
	}
}
