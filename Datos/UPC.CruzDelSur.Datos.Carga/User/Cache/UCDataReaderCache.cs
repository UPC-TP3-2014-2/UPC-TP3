using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace UPC.CruzDelSur.Datos.Carga.User.Cache
{
    public class UCDataReaderCache
    {
        private Hashtable _camposDataReader;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Hashtable Campos
        {
            get
            {
                if (_camposDataReader == null)
                    _camposDataReader = new Hashtable();
                return _camposDataReader;
            }

            set { _camposDataReader = value; }
        }

        /// <summary>
        /// Carga en cache las columnas de un DataReader, asociadas a un Procedimiento Almacenado
        /// </summary>
        /// <param name="dr">DataReader</param>
        /// <param name="_nombreProcedimiento">Nombre del Procedimiento Almacenado</param>
        public void CargarCampos(DbDataReader dr, string _nombreProcedimiento)
        {
            if (_camposDataReader == null)
            {
                _camposDataReader = new Hashtable();
                _camposDataReader[_nombreProcedimiento] = LlenarLista(dr);
            }

            if (_camposDataReader[_nombreProcedimiento] == null)
            {
                _camposDataReader[_nombreProcedimiento] = LlenarLista(dr);
            }
        }

        /// <summary>
        /// Itera las columnas de un DataReader y las devuelve en una lista
        /// </summary>
        /// <param name="dr">DataReader</param>
        /// <returns>Lista de cadenas conteniendo los nombres de los campos devueltos por procedimiento almacenado</returns>
        public List<string> LlenarLista(DbDataReader dr)
        {
            DataTable _columasDataReader;
            int _campos;
            List<string> listaCampos = new List<string>();
            _columasDataReader = dr.GetSchemaTable();
            _campos = _columasDataReader.Rows.Count;
            for (int i = 0; i < _campos; i++)
            {
                string columnName = ((string)_columasDataReader.Rows[i]["ColumnName"]);
                listaCampos.Add(columnName);
            }
            return listaCampos;
        }

    }
}
