using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;


namespace UPC.CruzDelSur.Datos.CheckIn.Interface
{
    public interface IBL_Boleto
    {
        List<BE_Boleto> f_ListadoBoleto(string nroboleto, string dni);
        List<BE_Boleto> f_CheckIn(string nroboleto);
        List<BE_Boleto> f_CancelarCheckIn(string nroboleto);
        List<BE_Boleto> f_ConsultarAsientosVehiculo(int CodVehiculo);
        BE_Boleto f_ActualizarAsiento(string nroboleto, string nroasiento, string nroasientol);
    }
}
