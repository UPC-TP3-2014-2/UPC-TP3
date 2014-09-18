using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;
using Breeze.ContextProvider;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using UPC.CruzDelSur.Datos.Personal;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Cliente.Personal.Controllers
{
    [BreezeController]
    public class BreezeController : ApiController
    {
        // Todo: inject via an interface rather than "new" the concrete class
        readonly PersonalContextoDatos _context = new PersonalContextoDatos();
        readonly ITraceWriter _tracer = GlobalConfiguration.Configuration.Services.GetTraceWriter();

        [HttpGet]
        public string Metadata()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "Obteniendo metadata del repositorio");
            string metadata;
            try
            {
                metadata = _context.Metadata;
            }
            catch (Exception ex)
            {
                new LogEvent(ex).Raise();
                _tracer.Error(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, ex);
                throw;
            }

            return metadata;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "Guardando cambios");
            SaveResult saveResult;
            try
            {
                saveResult = _context.SaveChanges(saveBundle);

                if (saveResult.Errors != null && saveResult.Errors.Any())
                {
                    var errors = saveResult.Errors.OfType<EntityError>().Select(e => e.ErrorMessage);
                    _tracer.Warn(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName,
                        "Se encontraron errores de validacion: {0}", string.Join(", ", errors));
                }
            }
            catch (Exception ex)
            {
                new LogEvent(ex).Raise();
                _tracer.Error(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, ex);
                throw;
            }

            return saveResult;
        }

        [HttpGet]
        public IQueryable<AuditEntry> AuditEntries()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "Obteniendo Auditorias");

            return _context.AuditEntries;
        }

        [HttpGet]
        public IQueryable<Educacion> Educaciones()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "Obteniendo Educaciones");

            return _context.Educaciones.ObtenerTodos();
        }

        [HttpGet]
        public IQueryable<ExperienciaLaboral> ExperienciasLaborales()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "Obteniendo Experiencias Laborales");

            return _context.ExperienciasLaborales.ObtenerTodos();
        }

        [HttpGet]
        public IQueryable<Persona> Personas()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "Obteniendo Personas");

            return _context.Personas.ObtenerTodos();
        }

        [HttpGet]
        public IQueryable<SolicitudCapacitacion> SolicitudesCapacitacion()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "Obteniendo Solicitudes de Capacitacion");

            return _context.SolicitudesCapacitacion.ObtenerTodos();
        }

        [HttpGet]
        public IQueryable<SolicitudPersonal> SolicitudesPersonal()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "Obteniendo Solicitudes de Personal");

            return _context.SolicitudesPersonal.ObtenerTodos();
        }

        [HttpGet]
        public object Lookups()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "Obteniendo Datos de Consulta");

            return new
            {
                Areas = _context.Areas.ObtenerTodos(),
                Capacitaciones = _context.Capacitaciones.ObtenerTodos(),
                Cargos = _context.Cargos.ObtenerTodos(),
                TiposDocumento = _context.TiposDocumento.ObtenerTodos(),
                TiposEducacion = _context.TiposEducacion.ObtenerTodos(),
            };
        }

        // Diagnostic
        [HttpGet]
        public string Ping()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "pong");

            return "pong";
        }
    }
}
