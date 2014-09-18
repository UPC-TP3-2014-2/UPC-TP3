using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Datos.Contratos
{
    public interface IProgramacion_Ruta
    {
        List<UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta> f_Programacion_Ruta(Int32 pAgenciaDestino);
        UPC.CruzDelSur.Negocio.Modelo.Carga.Programacion_Ruta f_UnoProgramacion_Ruta(Int32 pAgenciaDestino);
    }
}
