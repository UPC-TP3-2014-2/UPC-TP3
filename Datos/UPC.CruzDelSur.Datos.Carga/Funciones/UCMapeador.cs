using System;
using System.Data;
using System.Linq;
using System.Reflection;
using UPC.CruzDelSur.Datos.Carga.Global;

namespace UPC.CruzDelSur.Datos.Carga.Funciones
{
    public class UCMapeador
    {
        private SQL oSQL = new SQL();
        private bool ColumnExists(IDataReader reader, string columnName)
        {
            if (reader.GetSchemaTable().Columns.Contains(columnName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasColumn(IDataReader _dr, string columnName)
        {            
            for (Int32 i = 0; i < _dr.FieldCount; i++)
            {
                if ((_dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return true;
                }
            }
            return false;
        }
        public void ReaderToObject(IDataReader reader, object oBE)
        {            
            PropertyInfo[] Propiedades = oBE.GetType().GetProperties();
            Int32 v_Propiedades = Propiedades.Count();
            //for (Int32 i = 0; i < Propiedades.Count; i++)
            for (Int32 i = 0; i < v_Propiedades; i++)
            {
                if (FieldExists(reader, Propiedades[i].Name))
                {
                    Propiedades[i].SetValue(oBE, reader[Propiedades[i].Name], null);
                }
            }
        }
        public bool FieldExists(IDataReader reader, string fieldName)
        {
            reader.GetSchemaTable().DefaultView.RowFilter = String.Format("ColumnName= '{0}'", fieldName);
            return (reader.GetSchemaTable().DefaultView.Count > 0);
        }

    }
}
