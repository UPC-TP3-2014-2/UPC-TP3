using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
    public class Ruta
    {

        public int Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public bool Estado { get; set; }

    }
}
