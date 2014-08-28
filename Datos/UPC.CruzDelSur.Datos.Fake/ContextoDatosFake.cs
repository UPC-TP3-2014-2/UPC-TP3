using UPC.CruzDelSur.Datos.Contratos;

namespace UPC.CruzDelSur.Datos.Fake
{
    public class ContextoDatosFake : IContextoDatos
    {
        public ContextoDatosFake()
        {
            Personas = new PersonasRepositorioFake();
        }

        public IPersonasRepositorio Personas { get; private set; }
    }
}