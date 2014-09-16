using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class SolicitudPersonal : Solicitud
    {
        public DateTime FechaVencimiento { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
    }
}