using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using CRUZDELSUR.BusinessLogic;
using System.Web.UI.WebControls;
using C.Data.Global;
using CRUZDELSUR.Entities;
using System.Web.Extensions;

namespace CRUZDELSUR.Controller
{
    public class ServletFlota : System.Web.UI.Page
    {
        BLProgramacionRuta _BLProgramacionRuta = new BLProgramacionRuta();
        BLBitacora _BLBitacora = new BLBitacora();


        public void InsertarBitacora(BEBitacora _BEBitacora) {
            _BLBitacora.InsertarBitacora(_BEBitacora, null);
        }

        public void cargarRutasXVehiculo(DropDownList ddlRuta, List<ParametroGenerico> _ArrayParam,
                                         DropDownList ddlTipoIncidencia
                                        )
        {
            List<BERuta> _oBERuta = new List<BERuta>();
            _oBERuta = _BLProgramacionRuta.ListarRutasXVehiculo(_ArrayParam);

            if (_oBERuta.Count() >= 1)
            {
                ddlRuta.DataSource = _oBERuta;
                ddlRuta.DataTextField = "Descripcion";
                ddlRuta.DataValueField = "IdRuta";
                ddlRuta.DataBind();
                cargarTipoIncidencia(ddlTipoIncidencia);
                //deshabilitarFormulario(true);
            }
            else {
                FuncionJavascript("No se encontraron rutas para la unidad de transporte", "error");
            }
        }

        public void cargarTipoIncidencia(DropDownList ddl)
        {
            BLTipoIncidencia _BLTipoIncidencia = new BLTipoIncidencia();

            ddl.DataSource = _BLTipoIncidencia.ListarTipoIncidencia();
            ddl.DataTextField = "Descripcion";
            ddl.DataValueField = "IdTipoIncidencia";
            ddl.DataBind();
        }

        public void FuncionJavascript(string Mensaje, string _NombreFuncion)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('" + Mensaje + "');");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), _NombreFuncion, Convert.ToString(sb), true);
        }


    }
}
