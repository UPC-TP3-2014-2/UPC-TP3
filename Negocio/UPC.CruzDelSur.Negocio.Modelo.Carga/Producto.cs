using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class Producto
    {        
        public Int32 CODIGO_PRODUCTO { get; set; }
        public String NOMBRE { get; set; }
        public String DESCRIPCION { get; set; }
        public Nullable<Double> PRECIO { get; set; }
    }
}
