using System;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class AuditEntry
    {
        public int Id { get; set; }
        public string Table { get; set; }
        public string EventType { get; set; }
        public string UserName { get; set; }
        public DateTime EventTime { get; set; }
        public int RecordId { get; set; }
    }
}