using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Datos.Contratos
{
    public interface IContextoDatos
    {
        IPersonasRepositorio Personas { get; }
        IEducacionesRepositorio Educaciones { get; }
        IExperienciasLaboralesRepositorio ExperienciasLaborales { get; }
        ISolicitudesCapacitacionRepositorio SolicitudesCapacitacion { get; }
        ITiposDocumentoRepositorio TiposDocumento { get; }
        ICargosRepositorio Cargos { get; }
    }
}