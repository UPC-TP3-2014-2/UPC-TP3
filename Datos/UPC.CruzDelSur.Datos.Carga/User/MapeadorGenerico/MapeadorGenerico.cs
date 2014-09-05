using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using UPC.CruzDelSur.Datos.Carga.User.MapeoXML;

namespace UPC.CruzDelSur.Datos.Carga.User.MapeadorGenerico
{
    public class MapeadorGenerico
    {
        public static string _mapeadorSQL = "MapeadorSQL";
        public static List<MapaXML> diccionarioglobalSQL = new List<MapaXML>();
        public static List<string> _entidadesSQL = new List<string>();
        public Cache.CacheUtil _cacheUtil = new Cache.CacheUtil();

        /// <summary>
        /// Inicializador de la clase
        /// Carga la lista de Entidades(_entidadesSQL) y las Relaciones entre ellas (diccionarioglobalSQL) en memoria,
        /// leyéndolas del archivo de configuración XML indicado en la sección appSettings en el web.config, identificado por la clave _mapeadorSQL (MapeadorSQL)
        /// </summary>
        public MapeadorGenerico()
        {

            if (diccionarioglobalSQL == null | diccionarioglobalSQL.Count == 0)
            {
                diccionarioglobalSQL = MapeadorXML.CargarMapa(_mapeadorSQL);
            }
            if (_entidadesSQL == null | _entidadesSQL.Count == 0)
            {
                _entidadesSQL = MapeadorXML.ObtenerEntidades(_mapeadorSQL);
            }
        }

        /// <summary>
        /// Mapea un DataReader a una Lista de Objetos
        /// </summary>
        /// <typeparam name="T">Tipo genérico de la entidad</typeparam>
        /// <param name="dr">DataReader</param>
        /// <param name="_nombreProcedimiento">Nombre del Procedimiento Almacenado</param>
        /// <returns>Lista de entidades del tipo T</returns>
        public List<T> MapearDataReaderListaObjetos<T>(DbDataReader dr, string _nombreProcedimiento) where T : new()
        {
            List<PropertyInfo> _listaPropiedades;
            _listaPropiedades = _cacheUtil.InicializarCacheReflection<T>();
            List<string> _listaCampos;
            _listaCampos = _cacheUtil.InicializarCacheDataReader(dr, _nombreProcedimiento);
            List<T> _resultado = new List<T>();
            while (dr.Read())
            {
                T _objetoItem = GenerarObjetoDeDataReader<T>(dr, _listaPropiedades, _listaCampos);
                _resultado.Add(_objetoItem);
            }
            dr.Close();
            return _resultado;
        }

        /// <summary>
        /// Mapea un DataReader a un solo Objeto
        /// </summary>
        /// <typeparam name="T">Tipo genérico de la entidad</typeparam>
        /// <param name="dr">DataReader</param>
         /// <param name="_nombreProcedimiento">Nombre del Procedimiento Almacenado</param>
        /// <returns>Entidad del tipo T</returns>
        public T MapearDataReaderObjeto<T>(DbDataReader dr, string _nombreProcedimiento) where T : new()
        {
            List<PropertyInfo> _listaPropiedades;
            _listaPropiedades = _cacheUtil.InicializarCacheReflection<T>();
            List<string> _listaCampos;
            _listaCampos = _cacheUtil.InicializarCacheDataReader(dr, _nombreProcedimiento);
            dr.Read();
            T _resultado = GenerarObjetoDeDataReader<T>(dr, _listaPropiedades, _listaCampos);
            return _resultado;
        }

        /// <summary>
        /// Genera un objeto del tipo T iterando en los valores de las columnas de un DataReader
        /// </summary>
        /// <typeparam name="T">Tipo genérico de la entidad</typeparam>
        /// <param name="dr">DataReader</param>
        /// <param name="_listaPropiedades">Lista de propiedades de la entidad de tipo T</param>
        /// <param name="_listaCampos">Lista de campos del DataReader asociado</param>
        /// <returns>Entidad del tipo T, inicializada con los valores recibidos del DataReader</returns>
        private T GenerarObjetoDeDataReader<T>(DbDataReader dr, List<PropertyInfo> _listaPropiedades, List<string> _listaCampos) where T : new()
        {
            int _campos = _listaCampos.Count;
            T _resultado = new T();
            Object[] _registro = new Object[_campos];
            dr.GetValues(_registro);
            for (int i = 0; i < _campos; i++)
            {
                string _nombreColumna = _listaCampos[i].ToString().ToUpper();
                object _valorColumna = _registro[i];
                for (int j = 0; j < _listaPropiedades.Count; j++)
                {
                    if (_listaPropiedades[j].Name.ToUpper() == _nombreColumna)
                    {
                        PropertyInfo info = _listaPropiedades[j] as PropertyInfo;
                        if ((info != null) && info.CanWrite)
                        {
                            if (_valorColumna.GetType() == info.PropertyType)
                            {
                                info.SetValue(_resultado, _valorColumna, null);
                                break;
                            }
                            else
                            {
                                var c = TypeDescriptor.GetConverter(_valorColumna);
                                if (c.CanConvertTo(info.PropertyType))
                                {
                                    info.SetValue(_resultado, c.ConvertTo(_valorColumna, info.PropertyType), null);
                                    break;
                                }
                            }

                            if (_entidadesSQL.Contains(info.PropertyType.ToString()))
                            {
                                ObjectCreateMethod _MetodoDinamico = new ObjectCreateMethod(info.PropertyType);
                                object _nuevaEntidad = _MetodoDinamico.CreateInstance();
                                _nuevaEntidad = GenerarObjetoCompuesto(_nombreColumna, _valorColumna, _nuevaEntidad);
                                info.SetValue(_resultado, _nuevaEntidad, null);
                                break;
                            }
                        }
                    }
                }
            }
            return _resultado;
        }

        /// <summary>
        /// Genera un objeto y establece una de sus propiedades según el nombre y valor de columna recibidos
        /// No es recursivo, no permite ir más allá del segundo nivel en la jerarqía de objetos
        /// </summary>
        /// <param name="_nombreColumna">Nombre de columna en el DataReader</param>
        /// <param name="_valorColumna">Valor de columna en el DataReader</param>
        /// <param name="_entidad">Entidad a la cual se le debe establecer la propiedad "_nombreColumna"  con el valor "_valorColumna"</param>
        /// <returns>Entidad con una propiedad establecida</returns>

        private object GenerarObjetoCompuesto(string _nombreColumna, object _valorColumna, object _entidad)
        {
            List<PropertyInfo> _listaPropiedades;
            _listaPropiedades = _cacheUtil.InicializarCacheReflection(_entidad);

            for (int j = 0; j < _listaPropiedades.Count; j++)
            {
                if (_listaPropiedades[j].Name.ToUpper() == _nombreColumna)
                {
                    PropertyInfo info = _listaPropiedades[j] as PropertyInfo;
                    if ((info != null) && info.CanWrite)
                    {
                        if (_valorColumna.GetType() == info.PropertyType)
                        {
                            info.SetValue(_entidad, _valorColumna, null);
                            break;
                        }
                        else
                        {
                            var c = TypeDescriptor.GetConverter(_valorColumna);
                            if (c.CanConvertTo(info.PropertyType))
                            {
                                info.SetValue(_entidad, c.ConvertTo(_valorColumna, info.PropertyType), null);
                                break;
                            }
                        }
                    }
                }
            }
            return _entidad;
        }

        /// <summary>
        /// Instancia un objeto basado en un tipo específico
        /// </summary>
        /// <param name="t">Tipo de entidad, dinámico</param>
        /// <returns>Entidad del tipo T</returns>
        public static object GetNewObject(Type t)
        {
            //object _nuevaEntidad = GetNewObject(info.PropertyType);
            try
            {
                return t.GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte un DataReader en un DataTable
        /// </summary>
        /// <param name="reader">DataReader devuelto por la base de datos</param>
        /// <returns>DataTable</returns>
        public DataTable DataReaderEnDataTable(DbDataReader reader)
        {
            DataTable _resultado = new DataTable();
            if ((reader != null))
            {
                _resultado.Load(reader);
            }
            return _resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_registro"></param>
        /// <param name="_nombreColumna"></param>
        /// <returns>Existe o no</returns>
        public bool ColumnaExistaEnDataRow(DataRow _registro, string _nombreColumna)
        {
            if (_registro.Table.Columns.Contains(_nombreColumna))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_registro"></param>
        /// <param name="_nombreColumna"></param>
        /// <returns>Existe o no</returns>
        public bool ColumnaExistaEnDataRow(DbDataReader _registro, string _nombreColumna)
        {
            if (_registro.GetSchemaTable().Columns.Contains(_nombreColumna))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Convierte un Registro en una instancia de una Entidad
        /// </summary>
        /// <param name="_registro">Registro</param>
        /// <param name="_objeto">Instancia de una Entidad</param>
        public void ConvertirRegistroEnObjeto(DataRow _registro, object _objeto)
        {
            List<PropertyInfo> _listaPropiedades;
            _listaPropiedades = _cacheUtil.InicializarCacheReflection(_objeto);

            //PropertyInfo[] Propiedades = _objeto.GetType().GetProperties();

            for (int i = 0; i <= _listaPropiedades.Count() - 1; i++)
            {
                if (ColumnaExistaEnDataRow(_registro, _listaPropiedades[i].Name))
                {
                    object Valor = _registro[_listaPropiedades[i].Name];
                    string tipo = null;
                    tipo = Valor.GetType().ToString();
                    if ((Valor != null))
                    {
                        switch (tipo)
                        {
                            case "System.String":
                                _listaPropiedades[i].SetValue(_objeto, Convert.ToString(_registro[_listaPropiedades[i].Name]), null);
                                break;
                            case "System.Int8":
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                                _listaPropiedades[i].SetValue(_objeto, Convert.ToInt32(_registro[_listaPropiedades[i].Name]), null);
                                break;
                            case "System.Decimal":
                                _listaPropiedades[i].SetValue(_objeto, Convert.ToDecimal(_registro[_listaPropiedades[i].Name]), null);
                                break;
                            case "System.DateTime":
                                _listaPropiedades[i].SetValue(_objeto, (DateTime)_registro[_listaPropiedades[i].Name], null);
                                break;
                        }
                    }
                }
            }
        }
    }
}
