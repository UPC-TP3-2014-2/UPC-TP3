using System.ComponentModel.DataAnnotations;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class Educacion : DetalleHojaVida
    {
        [Required]
        public int TipoId { get; set; }

        public virtual TipoEducacion Tipo { get; set; }

        [Required]
        public string GradoObtenido { get; set; }
    }
}