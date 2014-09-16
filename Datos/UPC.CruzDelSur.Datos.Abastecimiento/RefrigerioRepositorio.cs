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
	public class RefrigerioRepositorio : Repositorio<RefrigerioRepositorio>, IRefrigerioRepositorio
	{

		protected Database Database = DatabaseFactory.CreateDatabase();


		public IQueryable<Refrigerio> ObtenerTodos()
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_refrigerio, vch_descripcion, vch_tipo_unidad from ta_refrigerio");
			IList<Refrigerio> ListadoRefrigerios = new List<Refrigerio>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{
					ListadoRefrigerios.Add(new Refrigerio() 
					{ 
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						Descripcion = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : String.Empty,
						TipoUnidad = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : String.Empty
					});
				}
			}

			return ListadoRefrigerios.AsQueryable();
		}

		public Refrigerio ObtenerPorId(int id)
		{
			throw new NotImplementedException();
		}

		public void Insertar(Refrigerio entidad)
		{
			throw new NotImplementedException();
		}

		public void Actualizar(Refrigerio entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(Refrigerio entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(int id)
		{
			throw new NotImplementedException();
		}
	}
}
