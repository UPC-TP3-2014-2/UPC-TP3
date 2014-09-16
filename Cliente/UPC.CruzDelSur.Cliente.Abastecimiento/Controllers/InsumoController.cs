using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.CruzDelSur.Modelo.Abastecimiento;
using UPC.CruzDelSur.Negocio.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class InsumoController : Controller
    {

		InsumoNegocio InsumoNegocio = new InsumoNegocio();

		[HttpPost]
		public JsonResult Search()
		{

			var Listado = new List<object>();

			foreach (Insumo Insumo in InsumoNegocio.ObtenerTodos())
			{
				Listado.Add(
					new
					{
						Id = Insumo.Id, 
						Descripcion = Insumo.Descripcion
					}
				);
			}

			return Json(Listado, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult SearchById(int id)
		{
			Insumo Insumo = InsumoNegocio.ObtenerPorId(id);
			return Json(Insumo, JsonRequestBehavior.AllowGet);
		}
    }
}
