using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AFD.Web.Startup))]
namespace AFD.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
