using System;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class BEConductor
    {
        public int IdConductor { get; set; }
        public string categoria { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }
        public string Estado { get; set; }
        public string Correo { get; set; }
        public DateTime	FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaModifica { get; set; }
        public string UsuarioModifica { get; set; }

         public BEConductor()
        {
            IdConductor = -1;
            categoria  = "";
            Nombres  = "";
            Apellidos  = "";
            Direccion  = "";
            Password  = "";
            Estado  = "";
            Correo  = "";
            FechaRegistra = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioRegistra  = "";
            FechaModifica = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioModifica = "";
         }
    }
}
