using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public abstract class Solicitud
    {
        protected Solicitud()
        {
            FechaRegistro = DateTime.Now;
            Estado = EstadoSolicitud.Pendiente;
        }

        public int Id { get; set; }
        public bool Archivada { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaResolucion { get; set; }
        public EstadoSolicitud Estado { get; set; }
        public string Observaciones { get; set; }
        public string DetallesResolucion { get; set; }
    }
}