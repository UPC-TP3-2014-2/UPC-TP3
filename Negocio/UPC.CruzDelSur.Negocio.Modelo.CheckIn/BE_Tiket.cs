using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.CheckIn
{
    public class BE_Tiket
    {

        public string Codigo { get; set; }
        public string Numero { get; set; }
        public string Peso { get; set; }
        public string Tamano { get; set; }
        public string CodBarra { get; set; }
        public string EstadoEquipaje { get; set; }
        public string TipoEtiqueta { get; set; }
        public int CodBoleto { get; set; }
    }
}
