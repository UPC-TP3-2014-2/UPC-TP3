using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
    public class SolicitudInsumo
    {
        public int Id { get; set; }
        public SolicitudCocina SolicitudCocina { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public bool Estado { get; set; }
    }
}
