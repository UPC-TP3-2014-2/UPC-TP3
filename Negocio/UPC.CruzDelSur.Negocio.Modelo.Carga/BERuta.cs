using System;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class BERuta
    {
        public int	IdRuta { get; set; }
        public string	Descripcion { get; set; }
        public string	Origen { get; set; }
        public string	Destino { get; set; }
        public string	Estado { get; set; }
        public int	Directo { get; set; }
        public DateTime	FechaRegistra { get; set; }
        public string	UsuarioRegistra { get; set; }
        public DateTime	FechaModifica { get; set; }
        public string UsuarioModifica { get; set; }

        public BERuta()
        {
            IdRuta = -1;
            Descripcion  = "";
            Origen = "";
            Destino = "";
            Estado = "";
            Directo = -1;
            FechaRegistra = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioRegistra = "";
            FechaModifica= Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioModifica = "";
        }

    }
}
