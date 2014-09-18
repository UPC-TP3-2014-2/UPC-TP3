using System;
using System.ComponentModel.DataAnnotations;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class SolicitudPersonal : Solicitud
    {
        [Required]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        public int AreaId { get; set; }

        public virtual Area Area { get; set; }

        [Required]
        public int CargoId { get; set; }

        public Cargo Cargo { get; set; }

        public decimal Salario { get; set; }

        public string Inicio { get; set; }

        public string Contrato { get; set; }

        public int TipoEducacionId { get; set; }

        public virtual TipoEducacion TipoEducacion { get; set; }

        public string EducacionDescripcion { get; set; }

        public string ExperienciaLaboral { get; set; }

        public string Funciones { get; set; }

        public string Requisitos { get; set; }
    }
}