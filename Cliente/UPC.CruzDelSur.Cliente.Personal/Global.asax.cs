using System.Web.Http;
using System.Web.Http.Tracing;

namespace UPC.CruzDelSur.Cliente.Personal
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
        }
    }
}
