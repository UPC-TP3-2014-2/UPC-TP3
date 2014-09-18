using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
    public class ProgramacionRuta
    {
        public int Id { get; set; }
        public Ruta Ruta { get; set; }
        public DateTime FechaOrigen { get; set; }
        public DateTime FechaDestino { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraLlegada { get; set; }
        public int TipoServicio { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public bool Estado { get; set; }
    }
}
