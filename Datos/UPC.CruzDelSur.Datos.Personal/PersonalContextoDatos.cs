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
            Areas = new AreasRepositorio(Contexto);
            Educaciones = new EducacionesRepositorio(Contexto);
            ExperienciasLaborales = new ExperienciasLaboralesRepositorio(Contexto);
            Capacitaciones = new CapacitacionesRepositorio(Contexto);
            Cargos = new CargosRepositorio(Contexto);
            Personas = new PersonasRepositorio(Contexto);
            SolicitudesCapacitacion = new SolicitudesCapacitacionRepositorio(Contexto);
            SolicitudesPersonal = new SolicitudesPersonalRepositorio(Contexto);
            TiposDocumento = new TiposDocumentoRepositorio(Contexto);
            TiposEducacion = new TiposEducacionRepositorio(Contexto);
        }

        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }

        public IAreasRepositorio Areas { get; private set; }
        public IPersonasRepositorio Personas { get; private set; }
        public IEducacionesRepositorio Educaciones { get; private set; }
        public IExperienciasLaboralesRepositorio ExperienciasLaborales { get; private set; }
        public ISolicitudesCapacitacionRepositorio SolicitudesCapacitacion { get; private set; }
        public ITiposDocumentoRepositorio TiposDocumento { get; private set; }
        public ICargosRepositorio Cargos { get; private set; }
        public ICapacitacionesRepositorio Capacitaciones { get; private set; }
        public ITiposEducacionRepositorio TiposEducacion { get; private set; }
        public ISolicitudesPersonalRepositorio SolicitudesPersonal { get; private set; }

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