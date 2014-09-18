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
	public class AgenciaRepositorio : Repositorio<AgenciaRepositorio>, IAgenciaRepositorio
	{

		public IQueryable<Agencia> ObtenerTodos()
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_agencia, vch_nombre, vch_direccion, vch_ubigeo_direccion from ta_agencia");
			IList<Agencia> ListadoAgencia = new List<Agencia>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{
					ListadoAgencia.Add(new Agencia() 
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						Nombre = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : String.Empty,
						Direccion = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : String.Empty,
						UbigeoId = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : String.Empty
					});
				}
			}

			return ListadoAgencia.AsQueryable();
		}

		public Agencia ObtenerPorId(int id)
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_agencia, vch_nombre, vch_direccion, vch_ubigeo_direccion from ta_agencia where int_codigo_agencia = @int_codigo_agencia");
			Database.AddInParameter(DbCommand, "@int_codigo_agencia", DbType.Int32, id);

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				if (Reader.Read())
				{
					return new Agencia()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						Nombre = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : String.Empty,
						Direccion = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : String.Empty,
						UbigeoId = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : String.Empty
					};
				}
			}

			return null;
		}

		public void Insertar(Agencia entidad)
		{
			throw new NotImplementedException();
		}

		public void Actualizar(Agencia entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(Agencia entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(int id)
		{
			throw new NotImplementedException();
		}
	}
}
