using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Datos.Contratos
{
    public interface IDetalleCargaRepositorio
    {
        List<UPC.CruzDelSur.Negocio.Modelo.Carga.DetalleCarga> f_ListaDetalleCarga(Int32 pCODIGO_CARGA);

    }
}
