﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace UPC.CruzDelSur.Negocio.Modelo.CheckIn
{
    public class Conexion
    {
        public static string CadenaConexion = ConfigurationManager.AppSettings["ConexionDB"].ToString();        
    }
}
