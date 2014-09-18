using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class DetalleCarga
    {
        public Int32 CODIGO_CARGA { get; set; }
        public Int32 CODIGO_PRODUCTO { get; set; }
        public String DESCRIPCION { get; set; }
        public Nullable<Int32> TIPO_CARGA { get; set; }
        public Nullable<Int32> CANTIDAD { get; set; }
        public Nullable<Double> DBL_PESO { get; set; }
        public Nullable<Double> DBL_IMPORTE { get; set; }
        public Nullable<Double> PRECIO { get; set; }
    }
}
