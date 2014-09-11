using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
    public class SolicitudCocina
    {
        public int Id { get; set; }
        public Refrigerio Refrigerio { get; set; }
        public ProgramacionRuta ProgramacionRuta { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }
    }
}
