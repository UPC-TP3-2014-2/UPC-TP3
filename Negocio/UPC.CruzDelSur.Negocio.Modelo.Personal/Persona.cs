﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class Persona
    {
        public int Id { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }

        [Required]
        public int TipoDocumentoId { get; set; }

        [Required]
        public string NroDocumento { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        public string Foto { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public virtual ICollection<DetalleHojaVida> DetallesHojaVida { get; set; }

        public virtual ICollection<CargoDesempenado> CargosDesempenados { get; set; }
    }
}