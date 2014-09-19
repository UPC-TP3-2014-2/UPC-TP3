using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
    public class DetSolicitudCocina
    {
        public int Id { get; set; }
        public SolicitudCocina SolicitudCocina { get; set; }
        public Refrigerio Refrigerio { get; set; }
        public int Cantidad { get; set; }
    }
}
