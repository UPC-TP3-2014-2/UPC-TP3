using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace UPC.CruzDelSur.Datos.Carga.User.Cache
{
    public class UCReflectionCache
    {
        private Hashtable _propiedades;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Hashtable Propiedades
        {
            get
            {
                if (_propiedades == null)
                    _propiedades = new Hashtable();
                return _propiedades;
            }

            set { _propiedades = value; }
        }

        /// <summary>
        /// Carga en cache las propiedades de un Tipo de una Entidad, usando un Hashtable
        /// </summary>
        /// <param name="targetType">Tipo de Entidad</param>
        public void CargarPropiedades(Type targetType)
        {
            if (_propiedades == null)
            {
                _propiedades = new Hashtable();
                _propiedades[targetType.FullName] =  LlenarLista(targetType);
            }

            if (_propiedades[targetType.FullName] == null)
            {
                _propiedades[targetType.FullName] = LlenarLista(targetType);
            }
        }

        /// <summary>
        /// Itera las propiedades (usando Reflection) de un Tipo de una Entidad, y las devuelve en una lista, sin excluir las clases heredadas
        /// </summary>
        /// <param name="targetType">Tipo de Entidad</param>
        /// <returns>Lista de propiedades de la Entidad</returns>
        public List<PropertyInfo> LlenarLista(Type targetType)
        {
            //var flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
            var flags = BindingFlags.Instance | BindingFlags.Public;
            List<PropertyInfo> propertyList = new List<PropertyInfo>();
            PropertyInfo[] objectProperties = targetType.GetProperties(flags);
            foreach (PropertyInfo currentProperty in objectProperties)
            {
                propertyList.Add(currentProperty);
            }
            return propertyList;
        }

    }
}
