using System;
using System.ComponentModel.DataAnnotations;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class SolicitudCapacitacion : Solicitud
    {
        [Required]
        [Range(typeof(DateTime), "07/08/2014", "05/02/2015", // TODO: Implement a custom annotation for this
            ErrorMessage = "La capacitacion puede ser planificada hasta con 6 meses de anticipacion")]
        public DateTime FechaPlanificada { get; set; }

        [Required(ErrorMessage = "Debe especificar la persona a la que se brindara la capacitacion")]
        public int TrabajadorId { get; set; }

        public virtual Persona Trabajador { get; set; }

        [Required(ErrorMessage = "Debe especificar la capacitación objetivo")]
        public int CapacitacionId { get; set; }

        public virtual Capacitacion Capacitacion { get; set; }
    }
}