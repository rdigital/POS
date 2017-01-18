using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenLayersWebAPI.Startup))]
namespace OpenLayersWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
