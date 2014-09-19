﻿using System;
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
				url: "SolicitudInsumo/{action}/{id}",
				defaults: new { controller = "SolicitudInsumo", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Insumo",
				url: "Insumo/{action}/{id}",
				defaults: new { controller = "Insumo", action = "Index", id = UrlParameter.Optional }
			);


			routes.MapRoute(
				name: "Solicitud_Cocina",
				url: "SolicitudCocina/{action}/{id}",
				defaults: new { controller = "SolicitudCocina", action = "Index", id = UrlParameter.Optional }
			);


			routes.MapRoute(
				name: "Home",
				url: "",
				defaults: new { controller = "Home", action = "Index" }
			);
		}
	}
}