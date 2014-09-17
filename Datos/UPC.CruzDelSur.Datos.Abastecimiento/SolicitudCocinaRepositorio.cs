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

        public IQueryable<SolicitudCocina> ObtenerTodos()
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("select a.int_codigo_solicitudcocina, a.int_codigo_programacion_ruta, a.dte_fecha_solicitud, a.bln_estado, d.int_vehiculo, d.vch_placa, c.int_codigo_ruta, e.int_codigo_agencia, e.vch_nombre, f.int_codigo_agencia, f.vch_nombre from ta_solicitudcocina a left outer join ta_programacion_ruta b on(a.int_codigo_programacion_ruta = b.int_codigo_programacion_ruta) left outer join ta_ruta c on(b.int_codigo_ruta = c.int_codigo_ruta) left outer join ta_vehiculo d on(b.int_codigovehiculo = d.int_vehiculo) left outer join ta_agencia e on(c.int_codigo_agenciaorigen = e.int_codigo_agencia) left outer join ta_agencia f on(c.int_codigo_agenciadestino = f.int_codigo_agencia)");
			IList<SolicitudCocina> ListadoSolicitudCocina = new List<SolicitudCocina>();

			using (IDataReader Reader = Database.ExecuteReader(DbCommand))
			{
				while (Reader.Read())
				{
                    SolicitudCocina SolicitudCocina = new SolicitudCocina()
                    {
                        Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
                        ProgramacionRuta = new ProgramacionRuta()
                        {
                            Id = (!Reader.IsDBNull(1)) ? Reader.GetInt32(1) : 0,
                            Vehiculo = new Vehiculo()
                            {
                                Id = (!Reader.IsDBNull(4)) ? Reader.GetInt32(4) : 0,
                                Placa = (!Reader.IsDBNull(5)) ? Reader.GetString(5) : String.Empty,
                            },
                            Ruta = new Ruta()
                            {
                                Id = (!Reader.IsDBNull(6)) ? Reader.GetInt32(6) : 0,
                                AgenciaOrigen = new Agencia()
                                {
                                    Id = (!Reader.IsDBNull(7)) ? Reader.GetInt32(7) : 0,
                                    Nombre = (!Reader.IsDBNull(8)) ? Reader.GetString(8) : String.Empty,
                                },
                                AgenciaDestino = new Agencia()
                                {
                                    Id = (!Reader.IsDBNull(9)) ? Reader.GetInt32(9) : 0,
                                    Nombre = (!Reader.IsDBNull(10)) ? Reader.GetString(10) : String.Empty,
                                }
                            }
                        },
                        FechaSolicitud = (!Reader.IsDBNull(2)) ? Reader.GetDateTime(2) : Convert.ToDateTime("01/01/1900"),
                        Estado = (!Reader.IsDBNull(3) && Reader.GetBoolean(3))
                    };

                    ListadoSolicitudCocina.Add(SolicitudCocina);
				}
			}

			return ListadoSolicitudCocina.AsQueryable();
        }

        public SolicitudCocina ObtenerPorId(int id)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("select a.int_codigo_solicitudcocina, a.int_codigo_programacion_ruta, a.dte_fecha_solicitud, a.bln_estado, d.int_vehiculo, d.vch_placa, c.int_codigo_ruta, e.int_codigo_agencia, e.vch_nombre, f.int_codigo_agencia, f.vch_nombre from ta_solicitudcocina a left outer join ta_programacion_ruta b on(a.int_codigo_programacion_ruta = b.int_codigo_programacion_ruta) left outer join ta_ruta c on(b.int_codigo_ruta = c.int_codigo_ruta) left outer join ta_vehiculo d on(b.int_codigovehiculo = d.int_vehiculo) left outer join ta_agencia e on(c.int_codigo_agenciaorigen = e.int_codigo_agencia) left outer join ta_agencia f on(c.int_codigo_agenciadestino = f.int_codigo_agencia) where a.int_codigo_solicitudcocina = @int_codigo_solicitudcocina");
            Database.AddInParameter(DbCommand, "@int_codigo_solicitudcocina", DbType.Int32, id);

            using (IDataReader Reader = Database.ExecuteReader(DbCommand))
            {
                if (Reader.Read())
                {
                    return new SolicitudCocina()
                    {
                        Id = (!Reader.IsDBNull(0)) ? Reader.GetInt32(0) : 0,
                        ProgramacionRuta = new ProgramacionRuta()
                        {
                            Id = (!Reader.IsDBNull(1)) ? Reader.GetInt32(1) : 0,
                            Vehiculo = new Vehiculo()
                            {
                                Id = (!Reader.IsDBNull(4)) ? Reader.GetInt32(4) : 0,
                                Placa = (!Reader.IsDBNull(5)) ? Reader.GetString(5) : String.Empty,
                            },
                            Ruta = new Ruta()
                            {
                                Id = (!Reader.IsDBNull(6)) ? Reader.GetInt32(6) : 0,
                                AgenciaOrigen = new Agencia()
                                {
                                    Id = (!Reader.IsDBNull(7)) ? Reader.GetInt32(7) : 0,
                                    Nombre = (!Reader.IsDBNull(8)) ? Reader.GetString(8) : String.Empty,
                                },
                                AgenciaDestino = new Agencia()
                                {
                                    Id = (!Reader.IsDBNull(9)) ? Reader.GetInt32(9) : 0,
                                    Nombre = (!Reader.IsDBNull(10)) ? Reader.GetString(10) : String.Empty,
                                }
                            }
                        },
                        FechaSolicitud = (!Reader.IsDBNull(2)) ? Reader.GetDateTime(2) : Convert.ToDateTime("01/01/1900"),
                        Estado = (!Reader.IsDBNull(3) && Reader.GetBoolean(3))
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
