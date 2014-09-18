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
	public class VehiculoRepositorio : Repositorio<VehiculoRepositorio>, IVehiculoRepositorio
	{
		protected VehiculoRepositorio() { }

		public IQueryable<Vehiculo> ObtenerTodos()
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_vehiculo, vch_placa, vch_marca, vch_modelo, vch_color, int_tipo_transporte from ta_vehiculo");
			IList<Vehiculo> ListadoVehiculo = new List<Vehiculo>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{
					ListadoVehiculo.Add(new Vehiculo()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						Placa = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : String.Empty,
						Marca = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : String.Empty,
						Modelo = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : String.Empty,
						Color = (!Reader.IsDBNull(4)) ? Reader.GetString(4) : String.Empty,
						TipoTransporte = (!Reader.IsDBNull(5)) ? Reader.GetInt32(5) : 0
					});
				}
			}

			return ListadoVehiculo.AsQueryable();
		}

		public Vehiculo ObtenerPorId(int id)
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_vehiculo, vch_placa, vch_marca, vch_modelo, vch_color, int_tipo_transporte from ta_vehiculo where int_vehiculo = @int_vehiculo");
			Database.AddInParameter(DbCommand, "@int_vehiculo", DbType.Int32, id);

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				if (Reader.Read())
				{
					return new Vehiculo()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						Placa = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : String.Empty,
						Marca = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : String.Empty,
						Modelo = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : String.Empty,
						Color = (!Reader.IsDBNull(4)) ? Reader.GetString(4) : String.Empty,
						TipoTransporte = (!Reader.IsDBNull(5)) ? Reader.GetInt32(5) : 0
					};
				}
			}

			return null;
		}

		public void Insertar(Vehiculo entidad)
		{
			throw new NotImplementedException();
		}

		public void Actualizar(Vehiculo entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(Vehiculo entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(int id)
		{
			throw new NotImplementedException();
		}
	}
}
