using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class Persona
    {
        public int Id { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }

        [Required(ErrorMessage = "Debe especificar un tipo de documento")]
        public int TipoDocumentoId { get; set; }

        [Required(ErrorMessage = "Debe especificar un numero de documento")]
        public string NroDocumento { get; set; }

        [Required(ErrorMessage = "Debe especificar un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe especificar un apellido")]
        public string Apellidos { get; set; }

        [Required]
        [Range(typeof(DateTime), "01/01/1900", "01/01/1996", // TODO: Implement a custom annotation for this
            ErrorMessage = "La pesona debe ser mayor de 18 años")]
        public DateTime FechaNacimiento { get; set; }

        public string Foto { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public virtual ICollection<DetalleHojaVida> DetallesHojaVida { get; set; }

        [Required(ErrorMessage = "Debe especificar un cargo")]
        public int CargoId { get; set; }

        public virtual Cargo Cargo { get; set; }
    }
}