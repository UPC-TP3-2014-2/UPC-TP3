﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Modelo.Abastecimiento
{
    public class SolicitudInsumo
    {
        public int Id { get; set; }
        public SolicitudCocina SolicitudCocina { get; set; }
        public Insumo Insumo { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public bool Estado { get; set; }
    }
}
