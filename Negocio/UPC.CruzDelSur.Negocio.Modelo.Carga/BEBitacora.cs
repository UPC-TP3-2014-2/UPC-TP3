using System;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class BEBitacora
    {

    public int 	IdBitacora { get; set; }
    public DateTime	Fecha { get; set; }
    public DateTime	HoraPartida { get; set; }
    public DateTime	HoraLlegada { get; set; }
    public DateTime	FechaRegistra { get; set; }
    public string	UsuarioRegistra { get; set; }
    public DateTime	FechaModifica { get; set; }
    public string	UsuarioModifica { get; set; }
    public BEProgramacionRuta IdProgramacionRuta { get; set; }


    public BEBitacora()
        {
            IdBitacora  = -1;
            Fecha = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            HoraPartida =Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            HoraLlegada =Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            FechaRegistra =Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioRegistra = "";
            FechaModifica =Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioModifica = "";
            IdProgramacionRuta = new BEProgramacionRuta();
         }


    }
}
