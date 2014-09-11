using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Models
{
    public class SolicitudInsumoModel
    {

        public int Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public SolicitudCocina SolicitudCocina { get; set; }

    }
}