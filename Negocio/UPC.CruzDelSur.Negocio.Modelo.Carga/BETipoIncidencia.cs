using System;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class BETipoIncidencia
    {

        public int IdTipoIncidencia { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaModifica { get; set; }
        public string UsuarioModifica { get; set; }

        public BETipoIncidencia()
        {
            IdTipoIncidencia = -1;
            Descripcion = "";
            Estado = "";
            FechaRegistra = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioRegistra = "";
            FechaModifica = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioModifica = "";
        }

    }
}
