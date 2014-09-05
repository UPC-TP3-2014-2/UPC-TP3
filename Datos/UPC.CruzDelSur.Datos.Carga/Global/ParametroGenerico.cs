namespace UPC.CruzDelSur.Datos.Carga.Global
{
    public class ParametroGenerico
    {
        private string _nombre;
        private object _valor;
        public string nombre
        {
            get
            {
                return (_nombre);
            }
            set
            {
                _nombre = value;
            }
        }

        public object valor
        {
            get
            {
                return (_valor);
            }
            set
            {
                _valor = value;
            }
        }
    }
}
