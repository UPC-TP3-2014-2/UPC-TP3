using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class SolicitudCapacitacion : Solicitud
    {
        [Required]
        public DateTime FechaPlanificada { get; set; }

        [Required]
        public int TrabajadorId { get; set; }

        public virtual Persona Trabajador { get; set; }

        [Required]
        public int CapacitacionId { get; set; }

        public virtual Capacitacion Capacitacion { get; set; }
    }
}