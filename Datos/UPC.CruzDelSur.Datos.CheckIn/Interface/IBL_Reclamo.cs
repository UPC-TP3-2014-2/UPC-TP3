using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.CruzDelSur.Negocio.Modelo.CheckIn;

namespace UPC.CruzDelSur.Datos.CheckIn.Interface
{
    public interface IBL_Reclamo
    {
        List<BE_Reclamo> f_buscaBoletoPasajero(string nroboleto, string dni);
        BE_Reclamo f_registrarReclamo(string nroboleto, int idTipoSolicitud, int idArea, string motivo);
        List<BE_TipoSolicitud> f_listaTipoSolicitud();
        List<BE_Area> f_listaArea();
    }
}
