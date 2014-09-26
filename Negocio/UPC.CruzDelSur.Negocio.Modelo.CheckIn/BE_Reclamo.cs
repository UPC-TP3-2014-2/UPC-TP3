using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.CheckIn
{
    public class BE_Reclamo
    {
        public string NroBoleto { get; set; }
        public string Pasajero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string FechaActual { get; set; }
        public string HoraActual { get; set; }
        public string EstadoReclamo { get; set; }
    }


    public class BE_TipoSolicitud
    {
        public int IdTipoSolicitud { get; set; }
        public string Nombre { get; set; }
    }


    public class BE_Area
    {
        public int IdArea { get; set; }
        public string Nombre { get; set; }
    }
}
