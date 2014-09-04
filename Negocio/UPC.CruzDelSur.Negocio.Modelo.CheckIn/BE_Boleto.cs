using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.CruzDelSur.Negocio.Modelo.CheckIn
{
    public class BE_Boleto
    {

        public string NroBoleto { get; set; }
        public string Pasajero { get; set; }
        public string Precio { get; set; }
        public string Placa { get; set; }
        public string TipoServicio { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string FechaSalida { get; set; }
        public string HoraSalida { get; set; }
        public string Asiento { get; set; }
        public string EstadoAsiento { get; set; }
        public string Ubicacion { get; set; }
        public string Chofer { get; set; }
        public string FechaActual { get; set; }
        public string HoraActual { get; set; }

        public string CodVehiculo { get; set; }
    }
}
