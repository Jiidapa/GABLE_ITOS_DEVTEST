using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GableTest.Startup))]
namespace GableTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
