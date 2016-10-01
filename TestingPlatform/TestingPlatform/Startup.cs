using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestingPlatform.Startup))]
namespace TestingPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
