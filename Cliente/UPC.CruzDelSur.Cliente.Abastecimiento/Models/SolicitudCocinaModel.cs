using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Models
{
    public class SolicitudCocinaModel
    {

        public int Id { get; set; }

        [Display(Name = "Ruta Programada")]
        [Required(ErrorMessage = "Ingrese la ruta programada.")]
        public int RutaProgramadaId { get; set; }

        [Display(Name = "Refrigerio")]
        [Required(ErrorMessage = "Ingrese el refrigerio.")]
        public int RefrigerioId { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Ingrese la cantidad del refrigerio.")]
        public int Cantidad { get; set; }


        public SolicitudCocina GetSolicitudCocina()
        {
            return new SolicitudCocina()
            {
                Id = this.Id,
                ProgramacionRuta = new ProgramacionRuta() { Id = this.RutaProgramadaId },
                Refrigerio = new Refrigerio() { Id = this.RefrigerioId },
                Cantidad = this.Cantidad, 
                Estado = true
            };
        }


    }
}