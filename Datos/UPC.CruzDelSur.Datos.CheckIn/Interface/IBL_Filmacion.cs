using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;
namespace UPC.CruzDelSur.Datos.CheckIn.Interface
{
    public interface IBL_Filmacion
    {
        List<BE_Filmacion> f_ListadoFilmaciones(DateTime fechaInicio, string estado);
        int f_RegistrarFilmacion(string codBus, string iniGrab, string finGrab, string rutaVideo, string estado);
        int f_ActualizarFilmacion(string SolFilmacion, string iniGrab, string finGrab, string rutaVideo, string estado);
    }
}
