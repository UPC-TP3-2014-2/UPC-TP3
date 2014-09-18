using System;
using System.ComponentModel.DataAnnotations;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public abstract class DetalleHojaVida
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe especificar una institucion")]
        public string Institucion { get; set; }

        [Required(ErrorMessage = "Debe especificar la fecha de inicio")]
        public DateTime Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public string Observaciones { get; set; }

        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }
    }
}