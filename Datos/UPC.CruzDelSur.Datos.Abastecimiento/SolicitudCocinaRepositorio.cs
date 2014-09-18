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

		protected IProgramacionRutaRepositorio ProgramacionRutaRepo = ProgramacionRutaRepositorio.ObtenerInstancia();


		protected SolicitudCocinaRepositorio() { }


        public IQueryable<SolicitudCocina> ObtenerTodos()
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_solicitudcocina, int_codigo_programacion_ruta, dte_fecha_solicitud, tin_estado from ta_solicitudcocina");
			IList<SolicitudCocina> ListadoSolicitudCocina = new List<SolicitudCocina>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{
					ListadoSolicitudCocina.Add(new SolicitudCocina()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						ProgramacionRuta = (!Reader.IsDBNull(1)) ? ProgramacionRutaRepo.ObtenerPorId(Reader.GetInt32(1)) : new ProgramacionRuta() { Id = 0 }, 
						FechaSolicitud = (!Reader.IsDBNull(2)) ? Reader.GetDateTime(2) : Convert.ToDateTime("01/01/1900"),
                        Estado = (!Reader.IsDBNull(3)) ? Reader.GetByte(3) : 0
					});
				}
			}

			return ListadoSolicitudCocina.AsQueryable();
        }

        public SolicitudCocina ObtenerPorId(int id)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_solicitudcocina, int_codigo_programacion_ruta, dte_fecha_solicitud, tin_estado from ta_solicitudcocina where int_codigo_solicitudcocina = @int_codigo_solicitudcocina");
			Database.AddInParameter(DbCommand, "@int_codigo_solicitudcocina", DbType.Int32, id);

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				if (Reader.Read())
				{
					return new SolicitudCocina()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						ProgramacionRuta = (!Reader.IsDBNull(1)) ? ProgramacionRutaRepo.ObtenerPorId(Reader.GetInt32(1)) : new ProgramacionRuta() { Id = 0 },
						FechaSolicitud = (!Reader.IsDBNull(2)) ? Reader.GetDateTime(2) : Convert.ToDateTime("01/01/1900"),
						Estado = (!Reader.IsDBNull(3)) ? Reader.GetByte(3) : 0
					};
				}
			}

			return null;
        }

        public void Insertar(SolicitudCocina solicitudCocina)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("insert into ta_solicitudcocina(int_codigo_programacion_ruta, dte_fecha_solicitud, bln_estado) values(@int_codigo_programacion_ruta, @dte_fecha_solicitud, @bln_estado)");
            Database.AddInParameter(DbCommand, "@int_codigo_programacion_ruta", DbType.Int32, solicitudCocina.ProgramacionRuta.Id);
            Database.AddInParameter(DbCommand, "@dte_fecha_solicitud", DbType.Date, solicitudCocina.FechaSolicitud);
            Database.AddInParameter(DbCommand, "@bln_estado", DbType.Boolean, solicitudCocina.Estado);
            int RowsAffected = Database.ExecuteNonQuery(DbCommand);
        }

        public void Actualizar(SolicitudCocina solicitudCocina)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("update ta_solicitudcocina set int_codigo_programacion_ruta = @int_codigo_programacion_ruta, dte_fecha_solicitud = @dte_fecha_solicitud, bln_estado = @bln_estado where int_codigo_solicitudcocina = @int_codigo_solicitudcocina");
            Database.AddInParameter(DbCommand, "@int_codigo_solicitudcocina", DbType.Int32, solicitudCocina.Id);
            Database.AddInParameter(DbCommand, "@int_codigo_programacion_ruta", DbType.Int32, solicitudCocina.ProgramacionRuta.Id);
            Database.AddInParameter(DbCommand, "@dte_fecha_solicitud", DbType.Date, solicitudCocina.FechaSolicitud);
            Database.AddInParameter(DbCommand, "@bln_estado", DbType.Boolean, solicitudCocina.Estado);
            int RowsAffected = Database.ExecuteNonQuery(DbCommand);
        }

        public void Eliminar(SolicitudCocina solicitudCocina)
        {
            Eliminar(solicitudCocina.Id);
        }

        public void Eliminar(int id)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("delete from ta_solicitudcocina where int_codigo_solicitudcocina = @int_codigo_solicitudcocina");
            Database.AddInParameter(DbCommand, "@int_codigo_solicitudcocina", DbType.Int32, id);
            int RowsAffected = Database.ExecuteNonQuery(DbCommand);
        }
    
    }
}
