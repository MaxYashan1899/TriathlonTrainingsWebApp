using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TriathlonTrainingsWebApp.Startup))]
namespace TriathlonTrainingsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
