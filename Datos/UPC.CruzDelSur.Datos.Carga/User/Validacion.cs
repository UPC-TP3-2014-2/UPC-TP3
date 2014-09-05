using System;

namespace UPC.CruzDelSur.Datos.Carga.User
{
    public class Validacion
    {
        /// <summary>
        /// Valida el valor de los parámetros con tipos de datos primitivos
        /// </summary>
        /// <param name="valor">Un objeto</param>
        /// <returns>Verdadero si es un objeto de un tipo primitivo de datos</returns>
        public bool ValidarParametrosSimples(object valor, bool PermiteCadenasVacias)
        {
            //PARA NO TOMAR EN CUENTA UN ATRIBUTO DEL OBJETO COMO VALOR DE UN PARAMETRO DEL PROC. ALMACENADO
            //NO DEBE SER STRING "", NEGATIVO(-1) NI DATETIME #12:00:00 AM#
            bool valido = false;
            if (valor != null)
            {
                string _tipo = valor.GetType().ToString();
                switch (_tipo)
                {
                    case "System.String":
                        if (PermiteCadenasVacias)
                        {
                            valido = true;
                        }
                        else if (Convert.ToString(valor) != Convert.ToString(""))
                        {
                            valido = true;
                        }
                        break;
                    case "System.int":
                    case "System.Int8":
                    case "System.Int16":
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Decimal":
                    case "System.Double":
                        if (Convert.ToInt32(valor) != Convert.ToInt32(-1))
                        {
                            valido = true;
                        }
                        break;
                    case "System.DateTime":
                        if (Convert.ToString(valor) != Convert.ToString("01/01/1900 12:00:00 a.m."))
                        {
                            valido = true;
                        }
                        break;
                    case "System.Boolean":
                        valido = true;
                        break;
                }
            }
            else
            {
                valido = false;
            }
            return valido;
        }
    }
}
