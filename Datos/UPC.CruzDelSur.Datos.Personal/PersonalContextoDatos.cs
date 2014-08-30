using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Newtonsoft.Json.Linq;
using UPC.CruzDelSur.Datos.Contratos;

namespace UPC.CruzDelSur.Datos.Personal
{
    public class PersonalContextoDatos : IContextoDatos
    {
        private readonly EFContextProvider<PersonalDbContext> _contextProvider =
            new EFContextProvider<PersonalDbContext>();

        public PersonalContextoDatos()
        {
            Personas = new PersonasRepositorio(Contexto);
        }

        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }

        public IPersonasRepositorio Personas { get; private set; }

        private PersonalDbContext Contexto
        {
            get { return _contextProvider.Context; }
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
    }
}