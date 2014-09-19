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
	public class ProgramacionRutaRepositorio : Repositorio<ProgramacionRutaRepositorio>, IProgramacionRutaRepositorio
	{

		protected IRutaRepositorio RutaRepo = RutaRepositorio.ObtenerInstancia();
		protected IVehiculoRepositorio VehiculoRepo = VehiculoRepositorio.ObtenerInstancia();

		protected ProgramacionRutaRepositorio() { }

		public IQueryable<ProgramacionRuta> ObtenerTodos()
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_programacion_ruta, int_codigo_ruta, dtm_fecha_origen, dtm_fecha_destino, tim_hora_salida, tim_hora_llegada, int_tipo_servicio, int_codigovehiculo, int_codigopersona, bln_estado from ta_programacion_ruta");
			IList<ProgramacionRuta> ListadoProgramacionRuta = new List<ProgramacionRuta>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{
					ListadoProgramacionRuta.Add(new ProgramacionRuta()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						Ruta = (!Reader.IsDBNull(1)) ? RutaRepo.ObtenerPorId(Reader.GetInt32(1)) : new Ruta() { Id = 0 },
						FechaOrigen = (!Reader.IsDBNull(2)) ? Reader.GetDateTime(2) : Convert.ToDateTime("01/01/1900"), 
						FechaDestino = (!Reader.IsDBNull(3)) ? Reader.GetDateTime(3) : Convert.ToDateTime("01/01/1900"),
						Vehiculo = (!Reader.IsDBNull(7)) ? VehiculoRepo.ObtenerPorId(Reader.GetInt32(7)) : new Vehiculo() { Id = 0 },
						Estado = (!Reader.IsDBNull(9) && Reader.GetBoolean(9))
					});
				}
			}

			return ListadoProgramacionRuta.AsQueryable();
		}

		public ProgramacionRuta ObtenerPorId(int id)
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select int_codigo_programacion_ruta, int_codigo_ruta, dtm_fecha_origen, dtm_fecha_destino, tim_hora_salida, tim_hora_llegada, int_tipo_servicio, int_codigovehiculo, int_codigopersona, bln_estado from ta_programacion_ruta where int_codigo_programacion_ruta = @int_codigo_programacion_ruta");
			Database.AddInParameter(DbCommand, "@int_codigo_programacion_ruta", DbType.Int32, id);

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				if (Reader.Read())
				{
					return new ProgramacionRuta()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						Ruta = (!Reader.IsDBNull(1)) ? RutaRepo.ObtenerPorId(Reader.GetInt32(1)) : new Ruta() { Id = 0 },
						FechaOrigen = (!Reader.IsDBNull(2)) ? Reader.GetDateTime(2) : Convert.ToDateTime("01/01/1900"),
						FechaDestino = (!Reader.IsDBNull(3)) ? Reader.GetDateTime(3) : Convert.ToDateTime("01/01/1900"),
						Vehiculo = (!Reader.IsDBNull(7)) ? VehiculoRepo.ObtenerPorId(Reader.GetInt32(7)) : new Vehiculo() { Id = 0 },
						Estado = (!Reader.IsDBNull(9) && Reader.GetBoolean(9))
					};
				}
			}

			return null;
		}

		public void Insertar(ProgramacionRuta entidad)
		{
			throw new NotImplementedException();
		}

		public void Actualizar(ProgramacionRuta entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(ProgramacionRuta entidad)
		{
			throw new NotImplementedException();
		}

		public void Eliminar(int id)
		{
			throw new NotImplementedException();
		}
	}
}
