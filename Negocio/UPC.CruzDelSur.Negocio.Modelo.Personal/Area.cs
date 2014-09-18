using System.Collections.Generic;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class Area
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}