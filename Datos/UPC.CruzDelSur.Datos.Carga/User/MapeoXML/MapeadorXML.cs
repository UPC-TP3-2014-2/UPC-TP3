using System.Collections.Generic;

namespace UPC.CruzDelSur.Datos.Carga.User.MapeoXML
{
    public static class MapeadorXML
    {

        public static List<Diccionario> _enciclopedia = new List<Diccionario>();

        /// <summary>
        /// Busca el origen de una propiedad(_propiedadbase) en una entidad(_tipoentidadbase) en un modelo(_mapeador)
        /// </summary>
        /// <param name="_tipoentidadbase">Tipo de la entidad base (padre, origen)</param>
        /// <param name="_propiedadbase">Nombre de la propiedad en la entidad base (padre, origen) </param>
        /// <param name="_mapeador">Nombre de la clave en la sección appSettings en el web.config</param>
        /// <returns>El nombre de la propiedad en la entidad hija (destino)</returns>
        public static string Mapear(string _tipoentidadbase, string _propiedadbase, string _mapeador)
        {
            Diccionario _diccionario = new Diccionario();
            _diccionario = ObtenerDiccionario(_mapeador);

            List<MapaXML> _relaciones = new List<MapaXML>();
            _relaciones = _diccionario.Mapa;

            if (_diccionario == null | _relaciones.Count == 0 | _relaciones == null)
            {
                _relaciones = CargarMapa(_mapeador);
            }
            string res = "";

            for (int i = 0; i <= _relaciones.Count - 1; i++)
            {
                if (_relaciones[i].DESTINOATRIBUTO == _tipoentidadbase + "." + _propiedadbase)
                {
                    res = _relaciones[i].ORIGENATRIBUTO;
                    return res;
                }
                else
                {
                    res = "";
                }
            }

            return res;
        }

        /// <summary>
        /// Carga en cache la lista de Entidades y las Relaciones entre ellas, y devuelve la Lista de Relaciones
        /// </summary>
        /// <param name="_mapeador">Nombre de la clave en la sección appSettings en el web.config</param>
        /// <returns>Lista de Relaciones</returns>
        public static List<MapaXML> CargarMapa(string _mapeador)
        {
            List<MapaXML> _relaciones = new List<MapaXML>();
            List<string> _entidades = new List<string>();

            if (ExisteDiccionario(_mapeador) == false)
            {
                _relaciones = LectorXML.CargarMapa(_mapeador);
                _entidades = LectorXML.ListarEntidades(_mapeador);
                AgregarDiccionario(_mapeador, _relaciones, _entidades);
            }

            return _relaciones;

        }

        /// <summary>
        /// Devuelve la lista de Entidades del Modelo
        /// </summary>
        /// <param name="_nombre">Nombre del modelo, indicado por el Nombre de la clave en la sección appSettings en el web.config</param>
        /// <returns>Lista de Entidades</returns>
        public static List<string> ObtenerEntidades(string _nombre)
        {
            List<string> _entidades = new List<string>();
            Diccionario _diccionario = new Diccionario();
            _diccionario = ObtenerDiccionario(_nombre);
            if ((_diccionario != null))
            {
                _entidades = ObtenerDiccionario(_nombre).Entidades;
            }
            else
            {
                CargarMapa(_nombre);
                _entidades = ObtenerEntidades(_nombre);
            }
            return _entidades;

        }

        /// <summary>
        /// Agrega una relación al Diccionario
        /// </summary>
        /// <param name="_nombre">Nombre del modelo, indicado por el Nombre de la clave en la sección appSettings en el web.config</param>
        /// <param name="_relaciones">Lista de Relaciones</param>
        /// <param name="_entidades">Lista de Entidades</param>
        /// <returns></returns>
        public static bool AgregarDiccionario(string _nombre, List<MapaXML> _relaciones, List<string> _entidades)
        {
            bool _agrega = true;

            _agrega = !ExisteDiccionario(_nombre);
            if (_agrega)
            {
                Diccionario _diccionarioNuevo = new Diccionario();
                _diccionarioNuevo.Nombre = _nombre;
                _diccionarioNuevo.Mapa = _relaciones;
                _diccionarioNuevo.Entidades = _entidades;
                _enciclopedia.Add(_diccionarioNuevo);
            }

            return _agrega;

        }

        /// <summary>
        /// Verifica si ya existe un ítem en el Diccionario
        /// </summary>
        /// <param name="_nombre">Nombre del modelo, indicado por el Nombre de la clave en la sección appSettings en el web.config</param>
        /// <returns>Existe o no existe</returns>
        public static bool ExisteDiccionario(string _nombre)
        {
            bool _existe = false;

            foreach (Diccionario _diccionario in _enciclopedia)
            {
                if (_diccionario.Nombre == _nombre)
                {
                    _existe = true;
                    break;
                }
            }
            return _existe;

        }

        /// <summary>
        /// Devuelve el índice de un elemento en el Diccionario
        /// </summary>
        /// <param name="_nombre">Nombre del modelo, indicado por el Nombre de la clave en la sección appSettings en el web.config</param>
        /// <returns>Indice del modelo en la Enciclopedia (lista de modelos)</returns>
        public static int ObtenerIndice(string _nombre)
        {
            int _indice = -1;

            for (int i = 0; i <= _enciclopedia.Count - 1; i++)
            {
                if (_enciclopedia[i].Nombre == _nombre)
                {
                    _indice = i;
                    break;
                }
            }

            return _indice;

        }

        /// <summary>
        /// Elimina un ítem del Diccionario
        /// </summary>
        /// <param name="_nombre">Nombre de un modelo, indicado por el Nombre de la clave en la sección appSettings en el web.config</param>
        /// <returns>Elimina un ítem de la enciclopedia (lista de modelos)</returns>
        public static bool EliminarDiccionario(string _nombre)
        {
            bool _elimina = false;

            for (int i = 0; i <= _enciclopedia.Count - 1; i++)
            {
                if (_enciclopedia[i].Nombre == _nombre)
                {
                    _enciclopedia.RemoveAt(i);
                    _elimina = true;
                    break;
                }
            }

            return _elimina;

        }

        /// <summary>
        /// Devuelve un ítem(Diccionario) de la Enciclopedia
        /// Existirá un Diccionario por cada modelo de base de datos
        /// </summary>
        /// <param name="_nombre"></param>
        /// <returns>Diccionario de la Enciclopedia, representando un modelo de datos</returns>
        public static Diccionario ObtenerDiccionario(string _nombre)
        {
            Diccionario _diccionario = new Diccionario();
            int _indice = -1;

            if (ExisteDiccionario(_nombre) == true)
            {
                _indice = ObtenerIndice(_nombre);
                if (_indice > -1)
                {
                    _diccionario = _enciclopedia[_indice];
                }
            }

            if (_indice == -1)
            {
                return null;
            }
            else
            {
                return _diccionario;
            }

        }

    }

    /// <summary>
    /// Representa una Relacíón entre 2 Entidades de un modelo
    /// Ejemplo: la propiedad ENFactura.IdPais.IdPais(destino) hace referencia a la propiedad ENPais.IdPais(origen)
    /// </summary>
    public class MapaXML
    {

        private string mDESTINOATRIBUTO;

        private string mORIGENATRIBUTO;
        public string DESTINOATRIBUTO
        {
            get { return (mDESTINOATRIBUTO); }
            set { mDESTINOATRIBUTO = value; }
        }

        public string ORIGENATRIBUTO
        {
            get { return (mORIGENATRIBUTO); }
            set { mORIGENATRIBUTO = value; }
        }

    }


    /// <summary>
    /// Representa un Modelo, con una Entidad y sus Relaciones
    /// Pueden existir varios Diccionarios, los cuales serán agregados a una Enciclopedia
    /// Ejemplo: si nuestra apliación funcionará con 2 bases de datos, una SQL y una Oracle, tendríamos una Enciclopedia conteniendo 2 Diccionarios.
    /// Cada Diccionario estaría identificado por el nombre de la BD respectiva, y contendría la lista de Entidades y sus relaciones correspondientes.
    /// Además, se debería indicar sus nombre en la sección appSettings en el web.config
    /// </summary>
    public class Diccionario
    {

        private string _nombre;
        private List<MapaXML> _mapa;
        private List<string> _entidades;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Lista de Relaciones entre las entidades de un modelo
        /// </summary>
        public List<MapaXML> Mapa
        {
            get { return _mapa; }
            set { _mapa = value; }
        }

        /// <summary>
        /// Lista de Entidades de un modelo
        /// </summary>
        public List<string> Entidades
        {
            get { return _entidades; }
            set { _entidades = value; }
        }

    }

}
