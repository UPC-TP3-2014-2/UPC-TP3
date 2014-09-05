using System;
using System.Collections.Generic;
using System.Xml;

namespace UPC.CruzDelSur.Datos.Carga.User.MapeoXML
{
    public static class LectorXML
    {
        /// <summary>
        /// Devuelve una lista de Entidades, leyendo el fichero de configuración indicado en la sección appSettings en el web.config, 
        /// identificado por la clave _mapeador (en este caso, MapeadorSQL)
        /// </summary>
        /// <param name="_mapeador">Nombre de la clave en la sección appSettings en el web.config</param>
        /// <returns>Lista de cadenas conteniendo los nombres de las entidades</returns>
        public static List<string> ListarEntidades(string _mapeador)
        {
            List<string> _entidades = new List<string>();

            try
            {
                XmlDocument _XmlDocMapeador = null;
                XmlNodeList _XmlNodeListEntidades = null;
                _XmlDocMapeador = new XmlDocument();
                _XmlDocMapeador.Load(System.Configuration.ConfigurationManager.AppSettings.Get(_mapeador).ToString());
                string _grupoEntidades = ObtenerNombreGrupo(ref _XmlDocMapeador);
                _XmlNodeListEntidades = _XmlDocMapeador.SelectNodes("/configuracion/grupo/entidades/entidad");
                foreach (XmlNode m_node in _XmlNodeListEntidades)
                {
                    string nombreAttribute = m_node.Attributes.GetNamedItem("nombre").Value;
                    _entidades.Add(_grupoEntidades + "." + nombreAttribute);
                }
            }
            catch (Exception errorVariable)
            {
                Console.Write(errorVariable.ToString());
            }

            return _entidades;

        }

        /// <summary>
        ///  Devuelve las relaciones entre Entidades en una lista de MapaXML, leyendo el fichero de configuración indicado en la sección appSettings en el web.config, 
        ///  identificado por la clave _mapeador (en este caso, MapeadorSQL)
        /// </summary>
        /// <param name="_mapeador">Nombre de la clave en la sección appSettings en el web.config</param>
        /// <returns>Lista de MapaXML conteniendo las relaciones entre las entidades</returns>
        public static List<MapaXML> CargarMapa(string _mapeador)
        {
            List<MapaXML> _relaciones = new List<MapaXML>();

            try
            {
                XmlDocument _XmlDocMapeador = null;
                XmlNodeList _XmlNodeListRelaciones = null;
                _XmlDocMapeador = new XmlDocument();
                _XmlDocMapeador.Load(System.Configuration.ConfigurationManager.AppSettings.Get(_mapeador).ToString());
                string _grupoEntidades = ObtenerNombreGrupo(ref _XmlDocMapeador);
                _XmlNodeListRelaciones = _XmlDocMapeador.SelectNodes("/configuracion/grupo/relaciones/relacion");
                foreach (XmlNode m_node in _XmlNodeListRelaciones)
                {
                    MapaXML _relacion = new MapaXML();
                    _relacion.DESTINOATRIBUTO = _grupoEntidades + "." + m_node.Attributes.GetNamedItem("destino").Value;
                    _relacion.ORIGENATRIBUTO = _grupoEntidades + "." + m_node.Attributes.GetNamedItem("origen").Value;
                    _relaciones.Add(_relacion);
                }

            }
            catch (Exception errorVariable)
            {
                Console.Write(errorVariable.ToString());
            }

            return _relaciones;

        }

        /// <summary>
        /// Obtiene el nombre del grupo XML en el documento especificado
        /// </summary>
        /// <param name="_XmlDocMapeador">Documento XML con la lista de entidades y sus relacioens</param>
        /// <returns>Nombre del grupo en el nodo /configuracion/grupo</returns>
        public static string ObtenerNombreGrupo(ref XmlDocument _XmlDocMapeador)
        {
            string _nombre = "";
            XmlNode _XmlNodeListGrupo = null;
            _XmlNodeListGrupo = _XmlDocMapeador.SelectSingleNode("/configuracion/grupo");
            _nombre = _XmlNodeListGrupo.Attributes.GetNamedItem("nombre").Value;
            return _nombre;

        }

    }
}
