using System;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class BEUnidadTransporte
    {
        public int 	IdVehiculo  { get; set; }
        public string Placa  { get; set; }
        public string Color  { get; set; }
        public string TipoVehiculo  { get; set; }
        public DateTime FechaIngreso  { get; set; }
        public int 	NroPasajeros  { get; set; }
        public string NroSerieMotor  { get; set; }
        public string Estado  { get; set; }
        public DateTime FechaRegistra  { get; set; }
        public string UsuarioRegistra  { get; set; }
        public DateTime FechaModifica  { get; set; }
        public string UsuarioModifica  { get; set; }
        public BEModelo IdModelo  { get; set; }

        public BEUnidadTransporte()
        {
            IdVehiculo = -1;
            Placa = "";
            Color = "";
            TipoVehiculo = "";
            FechaIngreso = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            NroPasajeros = -1;
            NroSerieMotor = "";
            Estado = "";
            FechaRegistra =  Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioRegistra = "";
            FechaModifica =  Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioModifica = "";
            IdModelo = new BEModelo();
         }

    }
}
