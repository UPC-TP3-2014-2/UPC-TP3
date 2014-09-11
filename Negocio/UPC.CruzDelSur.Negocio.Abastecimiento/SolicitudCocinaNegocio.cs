using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CruzDelSur.Datos.Abastecimiento;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Modelo.Abastecimiento;

namespace UPC.CruzDelSur.Negocio.Abastecimiento
{
    public class SolicitudCocinaNegocio
    {

        protected ISolicitudCocinaRepositorio Repositorio = SolicitudCocinaRepositorio.ObtenerInstancia();


        public void Insertar(SolicitudCocina solicitudCocina)
        {
            Repositorio.Insertar(solicitudCocina);
        }

    }
}
