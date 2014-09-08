using System.Linq;
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
            Educaciones = new EducacionesRepositorio(Contexto);
            ExperienciasLaborales = new ExperienciasLaboralesRepositorio(Contexto);
            SolicitudesCapacitacion = new SolicitudesCapacitacionRepositorio(Contexto);
            TiposDocumento = new TiposDocumentoRepositorio(Contexto);
            Cargos = new CargosRepositorio(Contexto);
            Capacitaciones = new CapacitacionesRepositorio(Contexto);
        }

        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }

        public IPersonasRepositorio Personas { get; private set; }
        public IEducacionesRepositorio Educaciones { get; private set; }
        public IExperienciasLaboralesRepositorio ExperienciasLaborales { get; private set; }
        public ISolicitudesCapacitacionRepositorio SolicitudesCapacitacion { get; private set; }
        public ITiposDocumentoRepositorio TiposDocumento { get; private set; }
        public ICargosRepositorio Cargos { get; private set; }
        public ICapacitacionesRepositorio Capacitaciones { get; private set; }

        private PersonalDbContext Contexto
        {
            get { return _contextProvider.Context; }
        }

        public IQueryable<AuditEntry> AuditEntries
        {
            get { return Contexto.AuditEntries; }
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
    }
}