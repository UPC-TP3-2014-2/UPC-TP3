using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Datos.Contratos
{
    public interface IClienteRepositorio
    {
        List<UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente> f_ListadoCliente(String pNroDocumento);
        UPC.CruzDelSur.Negocio.Modelo.Carga.Cliente f_UnoCliente(String pDocumento);
    }
}
