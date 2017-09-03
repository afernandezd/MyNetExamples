using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AFD.Hangfire.Startup))]
namespace AFD.Hangfire
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
