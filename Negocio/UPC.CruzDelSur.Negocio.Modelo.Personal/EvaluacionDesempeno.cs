using System;

namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class EvaluacionDesempeno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Nota { get; set; }
        public string Observaciones { get; set; }

        public int EvaluadorId { get; set; }
        public virtual Persona Evaluador { get; set; }

        public int EvaluadoId { get; set; }
        public virtual Persona Evaluado { get; set; }
    }
}