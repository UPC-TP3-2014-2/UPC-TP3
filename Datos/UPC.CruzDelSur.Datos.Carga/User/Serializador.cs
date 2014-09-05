using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UPC.CruzDelSur.Datos.Carga.User.MapeoXML;

namespace UPC.CruzDelSur.Datos.Carga.User 
{ 
    
    public class Serializador
    {
        public static string _mapeadorSQL = "MapeadorSQL";
        public static List<MapaXML> diccionarioglobalSQL = new List<MapaXML>();
        public static List<string> _entidadesSQL = new List<string>();
        public static Validacion _validacion = new Validacion();
        public Cache.CacheUtil _cacheUtil = new Cache.CacheUtil();

        /// <summary>
        /// Inicializador de la clase
        /// Carga la lista de Entidades(_entidadesSQL) en memoria,
        /// leyéndolas del archivo de configuración XML indicado en la sección appSettings en el web.config, identificado por la clave _mapeadorSQL (MapeadorSQL)
        /// </summary>
        public Serializador()
        {
            if (_entidadesSQL == null | _entidadesSQL.Count == 0)
            {
                _entidadesSQL = MapeadorXML.ObtenerEntidades(_mapeadorSQL);
            }
        }
        
        /// <summary>
        /// Convierte una Lista de Objetos tipo T a una cadena conteniendo su representación XML
        /// </summary>
        /// <typeparam name="T">Tipo de los objetos de la lista</typeparam>
        /// <param name="_listaObjetos">Lista de objetos a procesar</param>
        /// <param name="nodoXML">Nodo XML</param>
        /// <returns>Representación XML de la lista de objetos, devuelta como cadena</returns>
        public string ListaObjetosToXml<T>(IList<T> _listaObjetos, string nodoXML) where T : new()
        {
            StringBuilder _XmlResult= new StringBuilder();
            string _xmlItem = "";
            foreach (T item in _listaObjetos)
            {
                _xmlItem = SerializarObjeto<T>(item);
                _XmlResult.Append(_xmlItem);
            }
            return _XmlResult.ToString();
        }

        /// <summary>
        /// Serializa un objeto del tipo T en formato XML
        /// </summary>
        /// <typeparam name="T">Tipo del objeto</typeparam>
        /// <param name="_objeto">Objeto</param>
        /// <returns>Representación XML del objeto, devuelta como cadena</returns>
        public String SerializarObjeto<T>(T _objeto) where T : new()
        {
            List<PropertyInfo> _listaPropiedades;
            _listaPropiedades = _cacheUtil.InicializarCacheReflection<T>();
            String XmlizedString = null;
            StringBuilder XmlObjeto = new StringBuilder();
            string _tipo = typeof(T).Name.ToString();
            XmlObjeto.Append("<" + _tipo + ">");
            try
            {
                for (int j = 0; j < _listaPropiedades.Count; j++)
                {
                        PropertyInfo info = _listaPropiedades[j] as PropertyInfo;
                        if ((info != null))
                        {
                            object Valor = new object();
                            Valor = info.GetValue(_objeto, null);
                            String nombre = info.Name.ToString();
                            if (Valor != null)
                            {
                                if (_validacion.ValidarParametrosSimples(Valor,false))
                                {
                                    XmlObjeto.Append("<" + nombre + ">");
                                    XmlObjeto.Append(Valor);
                                    XmlObjeto.Append("</" + nombre + ">");
                                }
                                else if (_entidadesSQL.Contains(Valor.GetType().ToString()))
                                {
                                    XmlObjeto.Append("<" + nombre + ">");
                                    XmlObjeto.Append(ExtraerPropiedadObjetoCompuesto(Valor, nombre));
                                    XmlObjeto.Append("</" + nombre + ">");
                                }
                            }
                        }
                }
                XmlObjeto.Append("</" + _tipo + ">");
                XmlizedString = XmlObjeto.ToString();
                return XmlizedString;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Convierte en XML una propiedad de un objeto
        /// </summary>
        /// <param name="_objeto">Objeto</param>
        /// <param name="_propiedad">Propiedad a convertir en XML</param>
        /// <returns>Representación XML de la propiedad del objeto, devuelta como cadena</returns>
        public String ExtraerPropiedadObjetoCompuesto(object _objeto, String _propiedad) 
        {
            List<PropertyInfo> _listaPropiedades;
            _listaPropiedades = _cacheUtil.InicializarCacheReflection(_objeto);
 
            StringBuilder XmlObjeto = new StringBuilder();
            string _tipo = _objeto.GetType().Name.ToString();

            //XmlObjeto.Append("<" + _tipo + ">");
            try
            {
                for (int j = 0; j < _listaPropiedades.Count; j++)
                {
                    PropertyInfo info = _listaPropiedades[j] as PropertyInfo;
                    if (info.Name == _propiedad)
                    {
                        if ((info != null))
                        {
                            object Valor = new object();
                            Valor = info.GetValue(_objeto, null);
                            String nombre = info.Name.ToString();
                            if (_validacion.ValidarParametrosSimples(Valor,false))
                            {
                                //XmlObjeto.Append("<" + nombre + ">");
                                XmlObjeto.Append(Valor);
                                return XmlObjeto.ToString();
                                //XmlObjeto.Append("</" + nombre + ">");
                            }
                            else if (_entidadesSQL.Contains(nombre))
                            {
                            }
                        }
                    }

                }
                //XmlObjeto.Append("</" + _tipo + ">");
                //XmlizedString = XmlObjeto.ToString();
                //return XmlizedString;
                return null;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }


        /// <summary> 
        /// Converts a single XML tree to the type of T 
        /// </summary> 
        /// <typeparam name="T">Type to return</typeparam> 
        /// <param name="xml">XML string to convert</param> 
        /// <returns></returns> 
        public T XmlToObjeto<T>(string xml)
        {
            using (var xmlStream = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(XmlReader.Create(xmlStream));
            }
        }

        /// <summary> 
        /// Converts the XML to a list of T
        /// </summary> 
        /// <typeparam name="T">Type to return</typeparam> 
        /// <param name="xml">XML string to convert</param> 
        /// <param name="nodePath">XML Node path to select <example>//People/Person</example></param> 
        /// <returns></returns> 
        public List<T> XmlToListaObjetos<T>(string xml, string nodePath)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            var returnItemsList = new List<T>();
            foreach (XmlNode xmlNode in xmlDocument.SelectNodes(nodePath))
            {
                returnItemsList.Add(XmlToObjeto<T>(xmlNode.OuterXml));
            }

            return returnItemsList;
        }

        /// <summary>
        /// Method to convert a custom Object to XML string
        /// </summary>
        /// <param name="pObject">Object that is to be serialized to XML</param>
        /// <returns>XML string</returns>
        public String SerializeObject<T>(T pObject) where T : new()
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));

                TextWriter textWriter = new StreamWriter(memoryStream);
                xs.Serialize(textWriter, pObject);
                textWriter.Close();
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        private String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>

        private Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

    } 
}
