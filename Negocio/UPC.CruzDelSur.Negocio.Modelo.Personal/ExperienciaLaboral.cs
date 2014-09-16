using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class ExperienciaLaboral : DetalleHojaVida
    {
        [Required(ErrorMessage = "Debe especificar el cargo")]
        public string Cargo { get; set; }
    }
}