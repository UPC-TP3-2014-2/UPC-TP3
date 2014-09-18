using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Datos.Contratos
{
    public interface ICargaRepositorio
    {
        int f_ActualizarEstadoCarga(String pVCH_ESTADO, String pINT_CODIGO_CARGA);
        int f_AgregarCarga(UPC.CruzDelSur.Negocio.Modelo.Carga.Carga oBE_Carga);
        List<UPC.CruzDelSur.Negocio.Modelo.Carga.Carga> f_ListadoCarga(String pOPT, String pNroDocumento);
        UPC.CruzDelSur.Negocio.Modelo.Carga.Carga f_ListadoUnoCarga(Int32 pCODIGO_CARGA);
    }
}
