using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestingToSeeIfShitWorks.Startup))]
namespace TestingToSeeIfShitWorks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
