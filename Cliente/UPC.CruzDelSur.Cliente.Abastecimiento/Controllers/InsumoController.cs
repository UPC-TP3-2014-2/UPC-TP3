using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UPC.CruzDelSur.Modelo.Abastecimiento;
using UPC.CruzDelSur.Negocio.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class InsumoController : ApiController
    {

        InsumoNegocio InsumoNegocio = new InsumoNegocio();

        [HttpGet]
        public IEnumerable<Insumo> Get()
        {
            return InsumoNegocio.ObtenerTodos();
        }


        [HttpGet]
        public Insumo Get(int id)
        {
            return InsumoNegocio.ObtenerPorId(id);
        }

    }
}
