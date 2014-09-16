using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
    public class Insumo
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string TipoUnidad { get; set; }
        public DateTime FechaVencimiento { get; set; }

    }
}
