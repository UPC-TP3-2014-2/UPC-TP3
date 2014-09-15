using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UPC.CruzDelSur.Cliente.Abastecimiento
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Solicitud_Insumo",
                url: "SolicitudInsumo",
                defaults: new { controller = "SolicitudInsumo", action = "Index" }
                );

            routes.MapRoute(
                name: "Abastecimiento",
                url: "Abastecimiento",
                defaults: new { controller = "Abastecimiento", action = "Index" }
                );
			
			routes.MapRoute(
				name: "Home",
				url: "",
				defaults: new { controller = "Home", action = "Index" }
			);
		}
	}
}