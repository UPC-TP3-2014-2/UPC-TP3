using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CruzDelSur.Datos.Contratos
{
    public interface IProductoRepositorio
    {
        List<UPC.CruzDelSur.Negocio.Modelo.Carga.Producto> f_ListadoProducto(String pVCH_DESCRIPCION);
        UPC.CruzDelSur.Negocio.Modelo.Carga.Producto f_ListadoUnoProducto(int pCODIGO_PRODUCTO);
    }
}
