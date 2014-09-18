using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UPC.CruzDelSur.Cliente.Carga.Startup))]
namespace UPC.CruzDelSur.Cliente.Carga
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
