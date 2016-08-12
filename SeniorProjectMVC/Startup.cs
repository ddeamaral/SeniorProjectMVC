using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeniorProjectMVC.Startup))]
namespace SeniorProjectMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
