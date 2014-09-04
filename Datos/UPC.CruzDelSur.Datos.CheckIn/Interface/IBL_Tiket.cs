using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;


namespace UPC.CruzDelSur.Datos.CheckIn.Interface
{
    public interface IBL_Tiket
    {
        List<BE_Tiket> f_listarTiket();
    }
}
