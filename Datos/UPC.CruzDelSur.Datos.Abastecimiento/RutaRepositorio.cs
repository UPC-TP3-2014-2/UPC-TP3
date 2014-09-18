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
	public class RutaRepositorio : Repositorio<RutaRepositorio>, IRutaRepositorio
	{

		IAgenciaRepositorio AgenciaRepo = AgenciaRepositorio.ObtenerInstancia();

		public IQueryable<Ruta> ObtenerTodos()
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_ruta, int_codigo_agenciaorigen, int_codigo_agenciadestino, bln_estado from ta_ruta");
			IList<Ruta> ListadoRuta = new List<Ruta>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{
					ListadoRuta.Add(new Ruta()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						AgenciaOrigen = (!Reader.IsDBNull(1)) ? AgenciaRepo.ObtenerPorId(Reader.GetInt32(1)) : new Agencia() { Id = 0 },
						AgenciaDestino = (!Reader.IsDBNull(2)) ? AgenciaRepo.ObtenerPorId(Reader.GetInt32(2)) : new Agencia() { Id = 0 },
						Estado = (!Reader.IsDBNull(3) && Reader.GetBoolean(3))
					});
				}
			}

			return ListadoRuta.AsQueryable();
		}

		public Ruta ObtenerPorId(int id)
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_ruta, int_codigo_agenciaorigen, int_codigo_agenciadestino, bln_estado from ta_ruta where int_codigo_ruta = @int_codigo_ruta");
			Database.AddInParameter(DbCommand, "@int_codigo_ruta", DbType.Int32, id);

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				if (Reader.Read())
				{
					return new Ruta()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						AgenciaOrigen = (!Reader.IsDBNull(1)) ? AgenciaRepo.ObtenerPorId(Reader.GetInt32(1)) : new Agencia() { Id = 0 },
						AgenciaDestino = (!Reader.IsDBNull(2)) ? AgenciaRepo.ObtenerPorId(Reader.GetInt32(2)) : new Agencia() { Id = 0 },
						Estado = (!Reader.IsDBNull(3) && Reader.GetBoolean(3))
					};
				}
			}

			return null;
		}

		public void Insertar(Ruta entidad)
		{
			throw new NotImplementedException();
		}

		public void Actualizar(Ruta entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(Ruta entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(int id)
		{
			throw new NotImplementedException();
		}
	}
}
