using System;
using System.ComponentModel.DataAnnotations;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class CargoDesempenado
    {
        public int Id { get; set; }

        public Persona Persona { get; set; }

        [Required]
        public int PersonaId { get; set; }

        public virtual Area Area { get; set; }

        [Required]
        public int AreaId { get; set; }

        public virtual Cargo Cargo { get; set; }

        [Required]
        public int CargoId { get; set; }

        [Required]
        public DateTime Desde { get; set; }

        public DateTime? Hasta { get; set; }
    }
}