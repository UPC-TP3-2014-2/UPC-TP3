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
    public class DetSolicitudCocinaRepositorio : Repositorio<DetSolicitudCocinaRepositorio>, IDetSolicitudCocinaRepositorio
    {

        protected DetSolicitudCocinaRepositorio() { }

        public IQueryable<DetSolicitudCocina> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public DetSolicitudCocina ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(DetSolicitudCocina detSolicitudCocina)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("insert into ta_det_solicitudcocina(int_codigo_det_solicitudcocina, int_codigo_refrigerio, int_cantidad, bln_estado) values(@int_codigo_det_solicitudcocina, @int_codigo_refrigerio, @int_cantidad, @bln_estado)");
            Database.AddInParameter(DbCommand, "@int_codigo_det_solicitudcocina", DbType.Int32, detSolicitudCocina.SolicitudCocina.Id);
            Database.AddInParameter(DbCommand, "@int_codigo_refrigerio", DbType.Int32, detSolicitudCocina.Refrigerio.Id);
            Database.AddInParameter(DbCommand, "@int_cantidad", DbType.Int32, detSolicitudCocina.Cantidad);
            int RowsAffected = Database.ExecuteNonQuery(DbCommand);
        }

        public void Actualizar(DetSolicitudCocina detSolicitudCocina)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("update ta_det_solicitudcocina set int_codigo_det_solicitudcocina = @int_codigo_det_solicitudcocina, int_codigo_refrigerio = @int_codigo_refrigerio, int_cantidad = @int_cantidad, bln_estado = @bln_estado where int_codigo_det_solicitudcocina = @int_codigo_det_solicitudcocina");
            Database.AddInParameter(DbCommand, "@int_codigo_det_solicitudcocina", DbType.Int32, detSolicitudCocina.Id);
            Database.AddInParameter(DbCommand, "@int_codigo_det_solicitudcocina", DbType.Int32, detSolicitudCocina.SolicitudCocina.Id);
            Database.AddInParameter(DbCommand, "@int_codigo_refrigerio", DbType.Int32, detSolicitudCocina.Refrigerio.Id);
            Database.AddInParameter(DbCommand, "@int_cantidad", DbType.Int32, detSolicitudCocina.Cantidad);
            int RowsAffected = Database.ExecuteNonQuery(DbCommand);
        }

        public void Eliminar(DetSolicitudCocina detSolicitudCocina)
        {
            Eliminar(detSolicitudCocina.Id);
        }

        public void Eliminar(int id)
        {
            DbCommand DbCommand = Database.GetSqlStringCommand("delete from ta_det_solicitudcocina where int_codigo_det_solicitudcocina = @int_codigo_det_solicitudcocina");
            Database.AddInParameter(DbCommand, "@int_codigo_det_solicitudcocina", DbType.Int32, id);
            int RowsAffected = Database.ExecuteNonQuery(DbCommand);
        }
    }
}
