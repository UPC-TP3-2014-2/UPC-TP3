using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.CheckIn
{
    public class BE_Filmacion
    {
        public string FechaActual { get; set; }
        public string HoraSalida { get; set; }
        public string CodSalida { get; set; }
        public string HoraDestino { get; set; }
        public string CantPasajeros { get; set; }
        public string estado { get; set; }
        public string solFilmacion { get; set; }
        public string MinGrab { get; set; }
        public string rutaVideo { get; set; }
    }
}
