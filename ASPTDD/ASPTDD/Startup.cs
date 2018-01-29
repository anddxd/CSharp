using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPTDD.Startup))]
namespace ASPTDD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
