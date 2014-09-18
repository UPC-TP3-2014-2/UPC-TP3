using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class Programacion_Ruta
    {
        
        public Int32 CODIGO_PROGRAMACION_RUTA { get; set; }
        public Nullable<Int32> CODIGO_RUTA { get; set; }
        public Nullable<DateTime> FECHA_ORIGEN { get; set; }
        public Nullable<DateTime> FECHA_DESTINO { get; set; }
        public Nullable<DateTime> HORA_SALIDA { get; set; }
        public Nullable<DateTime> HORA_LLEGADA { get; set; }
        public Nullable<Int32> TIPO_SERVICIO { get; set; }
        public Nullable<Int32> CODIGOVEHICULO { get; set; }
        public Nullable<Int32> CODIGOPERSONA { get; set; }
        public Nullable<Boolean> ESTADO { get; set; }
        //Campos que no pertenecen a la tabla
        public String ORIGEN { get; set; }
        public String DESTINO { get; set; }
        public Int32 CODIGO_AGENCIAORIGEN { get; set; }
        public Int32 CODIGO_AGENCIADESTINO { get; set; }

        public String PLACA { get; set; }

    }
}
