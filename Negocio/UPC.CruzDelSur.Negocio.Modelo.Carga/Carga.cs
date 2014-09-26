using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class Carga
    {
        public Int32 CODIGO_CARGA { get; set; }
        public String FICHA { get; set; }
        public Nullable<DateTime> FECHA_REGISTRO { get; set; }
        public String REMITENTE { get; set; }
        public String DESTINATARIO { get; set; }
        public Nullable<Double> DBL_PESOTOTAL { get; set; }
        public Nullable<Double> DBL_IMPORTETOTAL { get; set; }
        public Nullable<Double> DBL_IGV { get; set; }
        public Nullable<Double> DBL_TOTAL { get; set; }
        public String OBSERVACION { get; set; }
        public String CLAVE_SEGURIDAD { get; set; }
        public String PREGUNTA_SEGURIDAD { get; set; }
        public String RESPUESTA_SEGURIDAD { get; set; }
        public Nullable<Int32> TIPO_PAGO { get; set; }
        public Nullable<Int32> CODIGO_PROGRAMACION_RUTA { get; set; }
        public String CLIENTE_ORIGEN { get; set; }
        public String ESTADOPAGO { get; set; }
        public Nullable<Int32> CODIGO_GUIA { get; set; }
        public String CLIENTE_DESTINO { get; set; }
        public String ESTADO { get; set; }

        //Campos que no pertenecen a la tabla
        public List<DetalleCarga> oDetalleCarga { get; set; }
        public String ORIGEN { get; set; }
        public String DESTINO { get; set; }
        public Nullable<DateTime> FECHA_ORIGEN { get; set; }
        public Nullable<DateTime> FECHA_DESTINO { get; set; }


    }
}
