using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace UPC.CruzDelSur.Datos.Carga.User.Cache
{
    public class CacheUtil
    {
        public UCReflectionCache cacheReflection = new UCReflectionCache();
        public UCDataReaderCache cacheDataReader = new UCDataReaderCache();

        /// <summary>
        ///  Carga en cache las Propiedades de una Entidad, asociado al nombre de la Entidad
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <returns>Lista de propiedades de la entidad</returns>
        public List<PropertyInfo> InicializarCacheReflection<T>() where T : new()
        {
            List<PropertyInfo> _listaPropiedades;
            Type _tipoEntidad = typeof(T);
            cacheReflection.CargarPropiedades(_tipoEntidad);
            _listaPropiedades = cacheReflection.Propiedades[_tipoEntidad.FullName] as List<PropertyInfo>;
            return _listaPropiedades;
        }

        /// <summary>
        /// Carga en cache las Propiedades de una Entidad, asociado al nombre de la Entidad
        /// </summary>
        /// <param name="_objeto">Instancia de la entidad</param>
        /// <returns>Lista de propiedades de la entidad</returns>
        public List<PropertyInfo> InicializarCacheReflection(object _objeto)
        {
            Type _tipoEntidad = _objeto.GetType();
            cacheReflection.CargarPropiedades(_tipoEntidad);
            return  cacheReflection.Propiedades[_tipoEntidad.FullName] as List<PropertyInfo>;
        }

        /// <summary>
        /// Carga en cache los campos del DataReader, asociado a un Procedimiento almacenado
        /// </summary>
        /// <param name="dr">DataReader</param>
        /// <param name="_nombreProcedimiento">Nombre del Procedimiento Almacenado</param>
        /// <returns>Lista de cadenas conteniendo los nombres de los campos devueltos por procedimiento almacenado</returns>
        public List<string> InicializarCacheDataReader(DbDataReader dr, string _nombreProcedimiento)
        {
            List<string> _listaCampos;
            cacheDataReader.CargarCampos(dr, _nombreProcedimiento);
            _listaCampos = cacheDataReader.Campos[_nombreProcedimiento] as List<string>;
            return _listaCampos;
        }
    }
}
