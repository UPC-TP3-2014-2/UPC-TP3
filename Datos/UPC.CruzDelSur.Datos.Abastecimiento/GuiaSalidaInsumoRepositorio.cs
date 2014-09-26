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
	public class GuiaSalidaInsumoRepositorio : Repositorio<GuiaSalidaInsumoRepositorio>, IGuiaSalidaInsumoRepositorio
	{

		protected ISolicitudInsumoRepositorio SolicitudInsumoRepo = SolicitudInsumoRepositorio.ObtenerInstancia();


		protected GuiaSalidaInsumoRepositorio() { }


		public IQueryable<GuiaSalidaInsumo> ObtenerTodos()
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_guiasalidainsumo, int_codigo_solicitudinsumo, dte_fecha_guia, tin_estado from ta_guiasalidainsumo");
			IList<GuiaSalidaInsumo> ListadoGuiaSalidaInsumo = new List<GuiaSalidaInsumo>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{
					ListadoGuiaSalidaInsumo.Add(new GuiaSalidaInsumo()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						SolicitudInsumo = (!Reader.IsDBNull(1)) ? SolicitudInsumoRepo.ObtenerPorId(Reader.GetInt32(1)) : new SolicitudInsumo() { Id = 0 }, 
						FechaGuia = (!Reader.IsDBNull(2)) ? Reader.GetDateTime(2) : Convert.ToDateTime("01/01/1900"),
						Estado = (!Reader.IsDBNull(3)) ? Reader.GetByte(3) : 0
					});
				}
			}

			return ListadoGuiaSalidaInsumo.AsQueryable();
		}

		public GuiaSalidaInsumo ObtenerPorId(int id)
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_guiasalidainsumo, int_codigo_solicitudinsumo, dte_fecha_guia, tin_estado from ta_guiasalidainsumo where int_codigo_guiasalidainsumo = @int_codigo_guiasalidainsumo");
			Database.AddInParameter(DbCommand, "@int_codigo_guiasalidainsumo", DbType.Int32, id);

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				if (Reader.Read())
				{
					return new GuiaSalidaInsumo()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						SolicitudInsumo = (!Reader.IsDBNull(1)) ? SolicitudInsumoRepo.ObtenerPorId(Reader.GetInt32(1)) : new SolicitudInsumo() { Id = 0 },
						FechaGuia = (!Reader.IsDBNull(2)) ? Reader.GetDateTime(2) : Convert.ToDateTime("01/01/1900"),
						Estado = (!Reader.IsDBNull(3)) ? Reader.GetByte(3) : 0
					};
				}
			}

			return null;
		}

		public void Insertar(GuiaSalidaInsumo guiaSalidaInsumo)
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("insert into ta_guiasalidainsumo(int_codigo_solicitudinsumo, dte_fecha_guia, tin_estado) values (@int_codigo_solicitudinsumo, @dte_fecha_guia, @tin_estado)");
			Database.AddInParameter(DbCommand, "@int_codigo_solicitudinsumo", DbType.Int32, guiaSalidaInsumo.SolicitudInsumo.Id);
			Database.AddInParameter(DbCommand, "@dte_fecha_guia", DbType.Date, guiaSalidaInsumo.FechaGuia);
			Database.AddInParameter(DbCommand, "@tin_estado", DbType.Byte, guiaSalidaInsumo.Estado);
			Database.ExecuteNonQuery(DbCommand);
		}

		public void Actualizar(GuiaSalidaInsumo guiaSalidaInsumo)
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("update ta_guiasalidainsumo set int_codigo_solicitudinsumo = @int_codigo_solicitudinsumo, dte_fecha_guia = @dte_fecha_guia, tin_estado = @tin_estado where int_codigo_guiasalidainsumo = @int_codigo_guiasalidainsumo");
			Database.AddInParameter(DbCommand, "@int_codigo_guiasalidainsumo", DbType.Int32, guiaSalidaInsumo.Id);
			Database.AddInParameter(DbCommand, "@int_codigo_solicitudinsumo", DbType.Int32, guiaSalidaInsumo.SolicitudInsumo.Id);
			Database.AddInParameter(DbCommand, "@dte_fecha_guia", DbType.Date, guiaSalidaInsumo.FechaGuia);
			Database.AddInParameter(DbCommand, "@tin_estado", DbType.Byte, guiaSalidaInsumo.Estado);
			Database.ExecuteNonQuery(DbCommand);
		}

		public void Eliminar(GuiaSalidaInsumo entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(int id)
		{
			throw new NotImplementedException();
		}
	}
}
