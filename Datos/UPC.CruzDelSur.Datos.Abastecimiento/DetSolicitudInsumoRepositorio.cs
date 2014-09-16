using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Datos.Abastecimiento
{
	public class DetSolicitudInsumoRepositorio : IDetSolicitudInsumoRepositorio
	{

		protected Database Database = DatabaseFactory.CreateDatabase();

		public IQueryable<DetSolicitudInsumo> ObtenerTodos()
		{
			throw new NotImplementedException();
		}

		public DetSolicitudInsumo ObtenerPorId(int id)
		{
			throw new NotImplementedException();
		}

		public void Insertar(DetSolicitudInsumo detSolicitudInsumo)
		{
			string Query = "insert into ta_det_solicitudinsumo(int_codigo_solicitudinsumo, int_codigo_insumo, int_cantidad, vch_unidad) values(@int_codigo_solicitudinsumo, @int_codigo_insumo, @int_cantidad, @vch_unidad)";
			DbCommand DbCommand = Database.GetSqlStringCommand(Query);
			Database.AddInParameter(DbCommand, "@int_codigo_solicitudinsumo", DbType.Int32, detSolicitudInsumo.SolicitudInsumo.Id);
			Database.AddInParameter(DbCommand, "@int_codigo_insumo", DbType.Int32, detSolicitudInsumo.Insumo.Id);
			Database.AddInParameter(DbCommand, "@int_cantidad", DbType.Int32, detSolicitudInsumo.Cantidad);
			Database.AddInParameter(DbCommand, "@vch_unidad", DbType.String, detSolicitudInsumo.Unidad);
			Database.ExecuteNonQuery(DbCommand);
		}

		public void Actualizar(DetSolicitudInsumo entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(DetSolicitudInsumo entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(int id)
		{
			throw new NotImplementedException();
		}
	}
}
