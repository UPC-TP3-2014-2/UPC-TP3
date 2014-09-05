using System;

namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class BEProgramacionRuta
    {

        public int IdProgramacionRuta { get; set; }
        public DateTime FechaOrigen { get; set; }
        public DateTime FechaDestino { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaModifica { get; set; }
        public string UsuarioModifica { get; set; }
        public BETipoServicio IdTipoServicio { get; set; }
        public BEConductor IdConductor { get; set; }
        public BERuta IdRuta { get; set; }
        public BEUnidadTransporte IdVehiculo { get; set; }

        public BEProgramacionRuta()
        {
            IdProgramacionRuta = -1;
            FechaOrigen = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            FechaDestino = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            FechaRegistra = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioRegistra = "";
            FechaModifica = Convert.ToDateTime("#1/01/1900 12:00:00 AM#");
            UsuarioModifica = "";
            IdTipoServicio  = new BETipoServicio();
            IdConductor  =  new BEConductor();
            IdRuta  = new BERuta();
            IdVehiculo  = new BEUnidadTransporte();
        }

    }
}
