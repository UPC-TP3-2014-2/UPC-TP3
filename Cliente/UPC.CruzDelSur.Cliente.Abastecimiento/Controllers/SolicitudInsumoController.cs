﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UPC.CruzDelSur.Modelo.Abastecimiento;
using UPC.CruzDelSur.Negocio.Abastecimiento;

namespace UPC.CruzDelSur.Cliente.Abastecimiento.Controllers
{
    public class SolicitudInsumoController : ApiController
    {
        protected SolicitudInsumoNegocio SolicitudInsumoNegocio = new SolicitudInsumoNegocio();

        [HttpGet]
        public IEnumerable<SolicitudInsumo> Get()
        {
            return SolicitudInsumoNegocio.ObtenerTodos();
        }


        [HttpGet]
        public SolicitudInsumo Get(int id)
        {
            return SolicitudInsumoNegocio.ObtenerPorId(id);
        }


        [HttpPost]
        public SolicitudInsumo Post(SolicitudInsumo solicitudInsumo)
        {
            solicitudInsumo.FechaSolicitud = DateTime.Now;
            solicitudInsumo.Estado = 1;
            SolicitudInsumoNegocio.Insertar(solicitudInsumo);
            return solicitudInsumo;
        }


        [HttpPut]
        public SolicitudInsumo Put(SolicitudInsumo solicitudInsumo)
        {
            SolicitudInsumoNegocio.Actualizar(solicitudInsumo);
            return solicitudInsumo;
        }





    }
}