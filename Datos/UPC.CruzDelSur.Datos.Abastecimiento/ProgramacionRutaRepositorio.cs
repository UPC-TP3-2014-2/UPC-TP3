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

		protected Database Database = DatabaseFactory.CreateDatabase();


		public IQueryable<ProgramacionRuta> ObtenerTodos()
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("select a.int_codigo_programacion_ruta, a.int_codigo_ruta, a.dtm_fecha_origen, a.dtm_fecha_destino, a.tim_hora_salida, a.tim_hora_llegada, a.int_tipo_servicio, a.int_codigovehiculo, a.int_codigopersona, a.bln_estado, b.vch_placa, c.vch_origen, c.vch_destino from ta_programacion_ruta a left outer join ta_vehiculo b on(a.int_codigovehiculo = b.int_vehiculo) left outer join ta_ruta c on(a.int_codigo_ruta = c.int_codigo_ruta)");
			IList<ProgramacionRuta> ListadoProgramacionRuta = new List<ProgramacionRuta>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{

					ProgramacionRuta ProgramacionRuta = new ProgramacionRuta()
					{
						Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
						Ruta = new Ruta()
						{
							Id = (!Reader.IsDBNull(1)) ? Reader.GetInt32(1) : 0,
							Origen = (!Reader.IsDBNull(11)) ? Reader.GetString(11) : String.Empty,
							Destino = (!Reader.IsDBNull(12)) ? Reader.GetString(12) : String.Empty
						},
						FechaOrigen = (!Reader.IsDBNull(2)) ? Reader.GetDateTime(2) : Convert.ToDateTime("01/01/1900"),
						FechaDestino = (!Reader.IsDBNull(3)) ? Reader.GetDateTime(3) : Convert.ToDateTime("01/01/1900"),
						Vehiculo = new Vehiculo()
						{
							Id = (!Reader.IsDBNull(7)) ? Reader.GetInt32(7) : 0,
							Placa = (!Reader.IsDBNull(10)) ? Reader.GetString(10) : String.Empty
						}
					};

					ListadoProgramacionRuta.Add(ProgramacionRuta);
				}
			}

			return ListadoProgramacionRuta.AsQueryable();
		}

		public ProgramacionRuta ObtenerPorId(int id)
		{
			throw new NotImplementedException();
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
