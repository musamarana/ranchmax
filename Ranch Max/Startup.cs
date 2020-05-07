using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ranch_Max.Startup))]
namespace Ranch_Max
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
