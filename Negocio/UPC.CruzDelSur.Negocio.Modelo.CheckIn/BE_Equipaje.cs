using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.CruzDelSur.Negocio.Modelo.CheckIn
{
    public class BE_Equipaje
    {


        public int NroEquipaje { get; set; }
        public string NroBoleto { get; set; }
        public string Pasajero { get; set; }
        public string Peso { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string FechaSalida { get; set; }
        public string HoraSalida { get; set; }
        public string TipoEquipaje { get; set; }
        public string Ubicacion { get; set; }
        public string FechaActual { get; set; }
        public string HoraActual { get; set; }
        public string EstadoEquipaje { get; set; }
        public int CodBoleto { get; set; }
        public string EstadoVerificacion { get; set; }
        public string FechaVerificacion { get; set; }
        
    }
}
