using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace UPC.CruzDelSur.Cliente.Carga.Controller.GestionCarga
{
    public class ServletGestionCarga : System.Web.UI.Page
    {



        public void ListarClientes(GridView gvClientes, List<ParametroGenerico> _ArrayParam)
        {
            List<BEMG_ES04_Cliente> _oMG_ES04_Cliente = new List<BEMG_ES04_Cliente>();
            _oMG_ES04_Cliente = BLMG_ES04_Cliente.ListarMG_ES04_Cliente(_ArrayParam);

            if (_oMG_ES04_Cliente.Count() >= 1)
            {
                gvClientes.DataSource = _oMG_ES04_Cliente;
                gvClientes.DataBind();
            }
            else
            {
                //FuncionJavascript("No se encontraron rutas para la unidad de transporte", "error");
            }
        }
        public void ListarProgramacionRuta(GridView gvProgramacion, List<ParametroGenerico> _ArrayParam)
        {
            List<BEMK_ProgramacionRuta> _oMK_ProgramacionRuta = new List<BEMK_ProgramacionRuta>();
            _oMK_ProgramacionRuta = BLMK_ProgramacionRuta.ListarMK_ProgramacionRuta(_ArrayParam);

            if (_oMK_ProgramacionRuta.Count() >= 1)
            {
                gvProgramacion.DataSource = _oMK_ProgramacionRuta;
                gvProgramacion.DataBind();
            }
            else
            {
                //FuncionJavascript("No se encontraron rutas para la unidad de transporte", "error");
            }
        }
        public BEMK_ProgramacionRuta ListarUnoProgramacionRuta(List<ParametroGenerico> _ArrayParam)
        {
            BEMK_ProgramacionRuta _oMK_ProgramacionRuta = new BEMK_ProgramacionRuta();
            _oMK_ProgramacionRuta = BLMK_ProgramacionRuta.ListarUnoMK_ProgramacionRuta(_ArrayParam);
            return _oMK_ProgramacionRuta;
            
        }
        public BEMG_ES04_Cliente ListarUnoCliente(List<ParametroGenerico> _ArrayParam)
        {
            BEMG_ES04_Cliente _oBEMG_ES04_Cliente = new BEMG_ES04_Cliente();
            _oBEMG_ES04_Cliente  = BLMG_ES04_Cliente.ListarUnoMG_ES04_Cliente(_ArrayParam);
            return _oBEMG_ES04_Cliente;

        }

        public void ListarProductos(GridView gvProductos, List<ParametroGenerico> _ArrayParam)
        {
            List<BEMG_ES03_Producto> _oBEMG_ES03_Producto = new List<BEMG_ES03_Producto>();
            _oBEMG_ES03_Producto = BLMG_ES03_Producto.ListarMG_ES03_Producto(_ArrayParam);

            if (_oBEMG_ES03_Producto.Count() >= 1)
            {
                gvProductos.DataSource = _oBEMG_ES03_Producto;
                gvProductos.DataBind();
            }
            else
            {
                //FuncionJavascript("No se encontraron rutas para la unidad de transporte", "error");
            }
        }


        public BEMG_ES03_Producto ListarUnoProductos( List<ParametroGenerico> _ArrayParam)
        {
            BEMG_ES03_Producto _oBEMG_ES03_Producto = new BEMG_ES03_Producto();
            _oBEMG_ES03_Producto = BLMG_ES03_Producto.ListarUnoMG_ES03_Producto(_ArrayParam);

            return _oBEMG_ES03_Producto;
        }

        public int InsertarFichaCarga(BEMG_ES01_FichaCarga _BEMG_ES01_FichaCarga, List<BEMG_ES02_DetalleFCarga> _loBEMG_ES02_DetalleFCarga)
        {
            

            return BLMG_ES01_FichaCarga.InsertarMG_ES01_FichaCarga(_BEMG_ES01_FichaCarga, _loBEMG_ES02_DetalleFCarga);
        }



        public BEMG_ES01_FichaCarga ListarUnoFichas(List<ParametroGenerico> _ArrayParam)
        {
            BEMG_ES01_FichaCarga _oBEMG_ES03_Producto = new BEMG_ES01_FichaCarga();
            _oBEMG_ES03_Producto = BLMG_ES01_FichaCarga.ListarUnoMG_ES01_FichaCarga(_ArrayParam);

            return _oBEMG_ES03_Producto;
        }

        public void ListarFichas(GridView gvFichas, List<ParametroGenerico> _ArrayParam)
        {
            List<BEMG_ES01_FichaCarga> _oMG_ES01_FichaCarga = new List<BEMG_ES01_FichaCarga>();
            _oMG_ES01_FichaCarga = BLMG_ES01_FichaCarga .ListarMG_ES01_FichaCarga(_ArrayParam);

            if (_oMG_ES01_FichaCarga.Count() >= 1)
            {
                gvFichas.DataSource = _oMG_ES01_FichaCarga;
                gvFichas.DataBind();
            }
            else
            {
                //FuncionJavascript("No se encontraron rutas para la unidad de transporte", "error");
            }
        }


    }
}
