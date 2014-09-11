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

        protected Database Database = DatabaseFactory.CreateDatabase();

        public IQueryable<SolicitudCocina> ObtenerTodos()
        {
			string Query = "select a.int_codigo_solicitudcocina, a.int_codigo_refrigerio, a.int_codigo_programacion_ruta, a.int_cantidad, a.bln_estado, d.int_vehiculo, d.vch_placa, c.int_codigo_ruta, c.vch_origen, c.vch_destino, a.dte_fecha_solicitud from ta_solicitudcocina a left outer join ta_programacion_ruta b on(a.int_codigo_programacion_ruta = b.int_codigo_programacion_ruta) left outer join ta_ruta c on(b.int_codigo_ruta = c.int_codigo_ruta) left outer join ta_vehiculo d on(b.int_codigovehiculo = d.int_vehiculo) ";
			DbCommand DbCommand = Database.GetSqlStringCommand(Query);
			IList<SolicitudCocina> ListadoSolicitudes = new List<SolicitudCocina>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{
					ProgramacionRuta Programacion = new ProgramacionRuta()
					{
						Id = (!Reader.IsDBNull(2)) ? Reader.GetInt32(2) : 0, 
						Vehiculo = new Vehiculo() { Id = (!Reader.IsDBNull(5)) ? Reader.GetInt32(5) : 0, Placa = (!Reader.IsDBNull(6)) ? Reader.GetString(6) : String.Empty }, 
						Ruta = new Ruta() { 
							Id = (!Reader.IsDBNull(7)) ? Reader.GetInt32(7) : 0, 
							Origen = (!Reader.IsDBNull(8)) ? Reader.GetString(8) : String.Empty, 
							Destino = (!Reader.IsDBNull(9)) ? Reader.GetString(9) : String.Empty 
						}
					};


					ListadoSolicitudes.Add(new SolicitudCocina()
											{
												Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
												Refrigerio = new Refrigerio() { Id = (!Reader.IsDBNull(1)) ? Reader.GetInt32(1) : 0, },
												ProgramacionRuta = Programacion, 
												Cantidad = (!Reader.IsDBNull(3)) ? Reader.GetInt32(3) : 0,
												Estado = (!Reader.IsDBNull(4) && Reader.GetBoolean(4)),
												FechaSolicitud = (!Reader.IsDBNull(10)) ? Reader.GetDateTime(10) : Convert.ToDateTime("01/01/1900")
											}
					);
				}
			}

			return ListadoSolicitudes.AsQueryable();
        }


        public SolicitudCocina ObtenerPorId(int id)
        {
            string Query = "select int_codigo_solicitudcocina, int_codigo_refrigerio, int_codigo_programacion_ruta, int_cantidad, bln_estado from ta_solicitudcocina where int_codigo_solicitudcocina = @id";
            DbCommand DbCommand = Database.GetSqlStringCommand(Query);
            Database.AddInParameter(DbCommand, "@id", DbType.Int32, id);

            using (IDataReader Reader = Database.ExecuteReader(DbCommand))
            {
                if (Reader.Read())
                {
                    return new SolicitudCocina()
                    {
                        Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
                        Refrigerio = new Refrigerio() { Id = (!Reader.IsDBNull(1)) ? Reader.GetInt32(1) : 0, },
                        ProgramacionRuta = new ProgramacionRuta() { Id = (!Reader.IsDBNull(2)) ? Reader.GetInt32(2) : 0, },
                        Cantidad = (!Reader.IsDBNull(3)) ? Reader.GetInt32(3) : 0,
                        Estado = (!Reader.IsDBNull(4) && Reader.GetBoolean(4))
                    };
                }
            }

            return null;
        }

        public void Insertar(SolicitudCocina solicitudCocina)
        {
            string Query = "insert into ta_solicitudcocina(int_codigo_refrigerio, int_codigo_programacion_ruta, int_cantidad, bln_estado) values(@int_codigo_refrigerio, @int_codigo_programacion_ruta, @int_cantidad, @bln_estado) set @id = scope_identity()";
            DbCommand DbCommand = Database.GetSqlStringCommand(Query);
            Database.AddOutParameter(DbCommand, "@id", DbType.Int32, 4);
            Database.AddInParameter(DbCommand, "@int_codigo_refrigerio", DbType.Int32, solicitudCocina.Refrigerio.Id);
            Database.AddInParameter(DbCommand, "@int_codigo_programacion_ruta", DbType.Int32, solicitudCocina.ProgramacionRuta.Id);
            Database.AddInParameter(DbCommand, "@int_cantidad", DbType.Int32, solicitudCocina.Cantidad);
            Database.AddInParameter(DbCommand, "@bln_estado", DbType.Boolean, solicitudCocina.Estado);

            int RowsAffected = Database.ExecuteNonQuery(DbCommand);
        }

        public void Actualizar(SolicitudCocina entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(SolicitudCocina entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

		public void AnularSolicitud(int id)
		{
			DbCommand DbCommand = Database.GetSqlStringCommand("update ta_solicitudcocina set bln_estado = 0 where int_codigo_solicitudcocina = @id");
			Database.AddInParameter(DbCommand, "@id", DbType.Int32, id);
			Database.ExecuteNonQuery(DbCommand);
		}
	}
}
