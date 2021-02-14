using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(adogme.Startup))]
namespace adogme
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
