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
        public ProgramacionRuta ProgramacionRuta { get; set; }
		public DateTime FechaSolicitud { get; set; }
        public int Estado { get; set; }
    }
}
