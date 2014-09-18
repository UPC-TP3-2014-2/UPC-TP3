using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class Cliente
    {
        public String DOCUMENTO { get; set; }
        public String NOMBRES { get; set; }
        public String APELLIDOS { get; set; }
        public String DIRECCION { get; set; }
        public String CORREO { get; set; }
        public String TELEFONO { get; set; }        
        public Nullable<Int32> UBIGEO { get; set; }

    }
}
