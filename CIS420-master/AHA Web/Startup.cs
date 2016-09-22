using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AHA_Web.Startup))]
namespace AHA_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
