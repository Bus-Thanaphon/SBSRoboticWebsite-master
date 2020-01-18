using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Robotic.WebUI.Startup))]
namespace Robotic.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
